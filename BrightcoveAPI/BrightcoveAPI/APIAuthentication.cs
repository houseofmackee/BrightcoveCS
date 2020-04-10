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

using System.IO;
using RestSharp;

namespace BrightcoveAPI
{
	/// <summary>
	/// API Authentication Information storage class
	/// </summary>
	public class APIAuthenticationInfo
	{
		public string AccountID { get; set; }
		public string ClientID { get; set; }
		public string ClientSecret { get; set; }
	}

	/// <summary>
	/// API Authentication Information handling class.
	/// When a method in this class expects JSON data it should be in the following form:
	/// {
	/// 	"AccountID" : "YourAccountID",
	/// 	"ClientID" : "YourClientID",
	/// 	"ClientSecret" : "YourClientSecret"
	/// }
	/// </summary>
	public class APIAuthentication
	{
		/// <summary>
		/// Creates API Authentication Info object from a JSON string
		/// </summary>
		/// <returns>An APIAuthenticationInfo or null.</returns>
		/// <param name="strJSON">String A valid JSON string.</param>
		public static APIAuthenticationInfo FromJSON(string strJSON)
		{
			APIAuthenticationInfo tempInfo = new APIAuthenticationInfo();
			try
			{
                tempInfo = SimpleJson.DeserializeObject<APIAuthenticationInfo>(strJSON);
			}
			catch
			{
				tempInfo = null;
			}

			return tempInfo;
		}

		/// <summary>
		/// Creates API Authentication Info object from a JSON string loaded from a file
		/// </summary>
		/// <returns>An APIAuthenticationInfo or null.</returns>
		/// <param name="strFilename">String Full path to file containg the JSON.</param>
		public static APIAuthenticationInfo FromFile(string strFilename)
		{
			if (File.Exists(strFilename))
			{
				return FromJSON(File.ReadAllText(strFilename));
			}
			return null;
		}

		/// <summary>
		/// Creates API Authentication Info object from a JSON string loaded from an URL
		/// </summary>
		/// <returns>An APIAuthenticationInfo or null.</returns>
		/// <param name="strURL">String Full URI to file containg the JSON.</param>
		public static APIAuthenticationInfo FromURL(string strURL)
		{
			string result = string.Empty;
			using (var webClient = new System.Net.WebClient())
			{
				try { result = webClient.DownloadString(strURL); }
				catch { }
			}

			return FromJSON(result);
		}

		/// <summary>
		/// Seralizes an API Authentication Info object to a JSON string.
		/// </summary>
		/// <returns>A JSON string.</returns>
		/// <param name="apiInfo">APIAuthenticationInfo info object.</param>
		public static string ToString(APIAuthenticationInfo apiInfo)
		{
			return SimpleJson.SerializeObject(apiInfo);
		}

	}
}
