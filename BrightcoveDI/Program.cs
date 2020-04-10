/*
 * Copyright (c) 2020 MacKenzie Glanzer @HouseOfMackee
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is furnished
 * to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.IO;
using BrightcoveAPI;
using RestSharp;

/*
 * Short C# example of how to use the Brightcove APIs and the Amazon S3 APIs to upload
 * a video from the local storage to Video Cloud.
 */
namespace BrightcoveDI
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			///////////////////////////////////////////////////////////////////////////
			/// Check if a filename was passed as an argument
			///////////////////////////////////////////////////////////////////////////
			if (args.Length == 0)
			{
				Console.WriteLine("Usage: bcdi <filename>");
				return;
			}

			///////////////////////////////////////////////////////////////////////////
			/// Check if the file exists
			///////////////////////////////////////////////////////////////////////////
			string strFullPath = args[0];
			string strFilenameNoExt = Path.GetFileNameWithoutExtension(strFullPath);

			if (!File.Exists(strFullPath))
			{
				Console.WriteLine("***ERROR: File '{0}' doesn't exist.", strFullPath);
				return;
			}

			///////////////////////////////////////////////////////////////////////////
			/// Set up API authentication information
			/// 
			/// This is expecting a file called api.json to be in the current user's
			/// home directory. The content should look like this:
			/// {
			/// 	"AccountID" : "YourAccountID",
			/// 	"ClientID" : "YourClientID",
			/// 	"ClientSecret" : "YourClientSecret"
			/// }
			///////////////////////////////////////////////////////////////////////////

			var myAPIAuth = APIAuthentication.FromFile((Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/account_config.json"));

			/// in case the api.json file wasn't found set some dummy defaults
			if (myAPIAuth == null)
			{
				Console.WriteLine("Error getting API authentication info, using invalid generic values.");
				myAPIAuth = new APIAuthenticationInfo();
				myAPIAuth.AccountID = "1234";
				myAPIAuth.ClientID = "5678";
				myAPIAuth.ClientSecret = "abcd";
			}

			///////////////////////////////////////////////////////////////////////////
			/// Obtain Access Token from OAUTH API
			///////////////////////////////////////////////////////////////////////////
			Console.Write("Getting the OAUTH token: ");
			var theToken = new OAuthToken(myAPIAuth.ClientID, myAPIAuth.ClientSecret);
			Console.WriteLine("Done.");

			///////////////////////////////////////////////////////////////////////////
			/// Use CMS API to create the video asset
			///////////////////////////////////////////////////////////////////////////
			CMS cmsAPI = new CMS(theToken, myAPIAuth.AccountID);
			Console.Write("Creating Brightcove asset for '{0}': ", strFilenameNoExt);
			string strVideoID;
			try
			{
				strVideoID = cmsAPI.CreateVideo(strFilenameNoExt);
			}
			catch (CMS.BrightcoveAPIException e)
			{
				Console.WriteLine("Exception: {0}", e.Message);
				return;
			}
			Console.WriteLine("Done (ID {0}).", strVideoID);

			///////////////////////////////////////////////////////////////////////////
			/// Use Source File Upload API to create a S3 upload URL for the video
			/// and use the AWS S3 API to upload the local file(s)
			///////////////////////////////////////////////////////////////////////////
			SourceFileUpload sfuUploader = new SourceFileUpload(theToken, myAPIAuth.AccountID, strVideoID);
			string strVideoURL = sfuUploader.UploadFile(strFullPath);

			///////////////////////////////////////////////////////////////////////////
			/// Use Dynamic Ingest API to ingest uploaded file into Video Cloud
			///////////////////////////////////////////////////////////////////////////
			Console.WriteLine("\nExecuting Dynamic Ingest.");

            DynamicIngest myDI = new DynamicIngest(theToken, myAPIAuth.AccountID);

			string strJSONContent = "{" +
									"	\"master\": {" +
									"		\"url\": \"" + strVideoURL + "\"" +
									"	}," +
                                    //"   \"callbacks\": [ \"https://hookb.in/vaPPdpMX\" ]" +
									"	\"capture-images\": true" +
									"}";

			Console.WriteLine("API response: {0}", myDI.IngestMediaAsset(strVideoID, strJSONContent));
            Console.WriteLine("Done.");
		}
	}
}
