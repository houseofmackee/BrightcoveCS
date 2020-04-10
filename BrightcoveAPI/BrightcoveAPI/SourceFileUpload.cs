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
using System.Json;
using Amazon.S3;
using Amazon.S3.Transfer;
using RestSharp;

namespace BrightcoveAPI
{

	public class SourceFileUploadProgressEventArgs : EventArgs
	{
		public long TotalBytes { get; }
		public long TransferredBytes { get; }

		public SourceFileUploadProgressEventArgs(long longTotal, long longTransferred)
		{
			TotalBytes = longTotal;
			TransferredBytes = longTransferred;
		}
	}
	
    public class SourceFileUpload : Base
	{
		public override string API_VERSION => "v1";
        public override string BaseURL => String.Format("https://ingest.api.brightcove.com/{0}/accounts", API_VERSION);

		private string myStrVideoID = string.Empty;

        public event EventHandler<SourceFileUploadProgressEventArgs> SourceFileUploadProgressEvent;

        #region Constructors
        public SourceFileUpload(OAuthToken oauthToken, string strAccountID, string strVideoID) : base(oauthToken, strAccountID)
		{
			myStrVideoID = strVideoID;
		}
        #endregion


        public string GetS3URL(string strVideoID, string strSourceName)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}/upload-urls/{3}",
                                              BaseURL, AccountID, strVideoID, strSourceName);
            myCall.Token = Token.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }

        public string UploadFile(string strFullPath) => UploadFile(Token, AccountID, myStrVideoID, strFullPath);

		/// <summary>
		/// Uploads the file.
		/// </summary>
		/// <returns>The file.</returns>
		/// <param name="oauthToken">Oauth token.</param>
		/// <param name="strAccountID">String account identifier.</param>
		/// <param name="strVideoID">String video identifier.</param>
		/// <param name="strFullPath">String full path.</param>
		public string UploadFile(OAuthToken oauthToken, string strAccountID, string strVideoID, string strFullPath )
		{
			if (!Helper.IsDigitsOnly(strVideoID))
			{
                throw new BrightcoveAPIException("Video ID is not valid.");
			}

            if (!Helper.IsDigitsOnly(strAccountID))
			{
                throw new BrightcoveAPIException("Account ID is not valid.");
			}

            string strFilename = Path.GetFileName(strFullPath);
			string strFilenameURI = Uri.EscapeDataString(strFilename);

			///////////////////////////////////////////////////////////////////////////
			/// Use Source File Upload API to create a S3 upload URL for the video
			///////////////////////////////////////////////////////////////////////////
			//Console.Write("Creating S3 URL for '{0}': ", strFilename);

            string strApiResponse = GetS3URL(strVideoID, strFilenameURI);

            dynamic createAssetResponse = SimpleJson.DeserializeObject(strApiResponse);
            //var createAssetResponse = JsonValue.Parse(strApiResponse);

            if (strApiResponse.Contains("error_code"))
			{
                throw new BrightcoveAPIException(createAssetResponse[0]["error_code"]);
				//Console.WriteLine("Failed ({0}).", createAssetResponse[0]["error_code"]);
				//return(string.Empty);
			}

			//Console.WriteLine("Done.");

			//Console.WriteLine("API URL used: {0}", strClientURL);
			//Console.WriteLine("Response: {0}", createAssetResponse);

			///////////////////////////////////////////////////////////////////////////
			/// Copy needed data from the API response for ease of use
			///////////////////////////////////////////////////////////////////////////
			string strBucketName = createAssetResponse["bucket"];
			string strKeyName = createAssetResponse["object_key"];
			string strAccessKey = createAssetResponse["access_key_id"];
			string strSecretAccessKey = createAssetResponse["secret_access_key"];
			string strToken = createAssetResponse["session_token"];
			string strAPIRequestURL = createAssetResponse["api_request_url"];

			///////////////////////////////////////////////////////////////////////////
			/// Use Amazon S3 API to upload local file to the generated S3 URL
			///////////////////////////////////////////////////////////////////////////
			//Console.Write("Uploading to S3: 0/0");
			//Console.SetCursorPosition(0, Console.CursorTop);

			try
			{
				var s3Client = new AmazonS3Client(strAccessKey, strSecretAccessKey, strToken, Amazon.RegionEndpoint.USEast1);
				var fileTransferUtility = new TransferUtility(s3Client);

				// Use TransferUtilityUploadRequest to configure options.
				// In this example we subscribe to an event.
				var uploadRequest = new TransferUtilityUploadRequest
				{
					BucketName = strBucketName,
					FilePath = strFullPath,
					Key = strKeyName
				};

				//Console.WriteLine("BucketName: {0}", strBucketName);
				//Console.WriteLine("FilePath: {0}", strFullPath);
				//Console.WriteLine("Key: {0}", strKeyName);

				uploadRequest.UploadProgressEvent +=
									new EventHandler<UploadProgressArgs>
										(uploadRequest_UploadPartProgressEvent);

				fileTransferUtility.Upload(uploadRequest);
				//Console.WriteLine("Upload completed: {0}", strAPIRequestURL);
			}
			catch (AmazonS3Exception e)
			{
				throw e;
				//Console.WriteLine(e.Message, e.InnerException);
				//return(string.Empty);
			}

			return (strAPIRequestURL);
		}

		///////////////////////////////////////////////////////////////////////////
		/// Callback to display progress of Amazon S3 multipart upload
		///////////////////////////////////////////////////////////////////////////
		private void uploadRequest_UploadPartProgressEvent(object sender, UploadProgressArgs e)
		{
			// Process event.
			//Console.Write("Uploading to S3: {0}/{1}", e.TransferredBytes, e.TotalBytes);
			//Console.SetCursorPosition(0, Console.CursorTop);

			SourceFileUploadProgressEvent?.Invoke(this, new SourceFileUploadProgressEventArgs(e.TotalBytes, e.TransferredBytes));
		}
	}
}
