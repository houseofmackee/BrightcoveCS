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
using System.Timers;
using RestSharp;

namespace BrightcoveAPI
{
	/// <summary>
	/// OAuth token info.
	/// </summary>
	class OAuthInfo
	{
		public string access_token { get; set; }
		public string token_type { get; set; }
		public int expires_in { get; set; }
	}

	/// <summary>
	/// OAuth token handling class.
	/// </summary>
    public class OAuthToken
	{
        private const String API_VERSION = "v4";
		private const int TOKEN_EXPIRY_LIMIT = 5;
		private APIAuthenticationInfo myAPIAuth;
		private bool bWithTimer;
		private OAuthInfo myTokenInfo = null;
		private System.Timers.Timer myTimer = null;

        public string BaseURL => String.Format("https://oauth.brightcove.com/{0}", API_VERSION);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BrightcoveAPI.OAuthToken"/> class.
        /// </summary>
        /// <param name="strID">String Client ID.</param>
        /// <param name="strSecret">String Client Secret.</param>
        /// <param name="bTimer">If set to <c>true</c> (default) use timer for token expiry.</param>
        public OAuthToken(string strID, string strSecret, bool bTimer = true)
		{
			myAPIAuth = new APIAuthenticationInfo();
			myAPIAuth.ClientID = strID;
			myAPIAuth.ClientSecret = strSecret;
			bWithTimer = bTimer;
			myTokenInfo = new OAuthInfo();
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="T:BrightcoveAPI.OAuthToken"/> is reclaimed by garbage collection.
		/// </summary>
		~OAuthToken()
		{
			StopTimer();
		}

		/// <summary>
		/// Returns the OAuth token. Will create a new token if the previous token is near expiry.
		/// </summary>
		/// <returns>The OAuth token.</returns>
		public string Token
		{
			get
			{
				if (ExpiresIn() < TOKEN_EXPIRY_LIMIT)
				{
					RequestNewToken();
				}
				return myTokenInfo.access_token;
			}

			private set { }
		}

        /// <summary>
        /// Returns the time until the token expires (in seconds).
        /// </summary>
        /// <returns>The token expiry time.</returns>
        public int ExpiresIn() => myTokenInfo.expires_in;

        /// <summary>
        /// Requests a new token and, if enabled, starts the expiry countdown.
        /// </summary>
        private void RequestNewToken()
		{
            var client = new RestClient( String.Format("{0}/access_token?grant_type=client_credentials", BaseURL) );
			var request = new RestRequest();

			request.Method = Method.POST;
			request.AddHeader("Accept", "application/x-www-form-urlencoded");
			request.Parameters.Clear();
			request.AddParameter("client_id", myAPIAuth.ClientID);
			request.AddParameter("client_secret", myAPIAuth.ClientSecret);

			// execute the request
			IRestResponse<OAuthInfo> response = client.Execute<OAuthInfo>(request);
			//Console.WriteLine("Successfully received token. Valid for {0} seconds.", response.Data.expires_in);

			myTokenInfo = response.Data;

			if(bWithTimer)
				SetTimer();
		}

		/// <summary>
		/// Sets the timer to call the countdown method in one second intervals.
		/// </summary>
		private void SetTimer()
		{
			// if a timer is already running stop and dispose of it
			StopTimer();

			if (ExpiresIn() > 0)
			{
				// Create a timer with a one second interval.
				myTimer = new System.Timers.Timer(1000);

				// Hook up the Elapsed event for the timer. 
				myTimer.Elapsed += OnCountdown;
				myTimer.AutoReset = true;
				myTimer.Enabled = true;
			}
		}

		/// <summary>
		/// Stops the timer and disposes it.
		/// </summary>
		private void StopTimer()
		{
			if (myTimer != null)
			{
				myTimer.Stop();
				myTimer.Dispose();
				myTimer = null;
			}
		}

		/// <summary>
		/// Decreases the token's expiry counter every second.
		/// </summary>
		/// <param name="source">Object source (unused).</param>
		/// <param name="e">ElapsedEventArgs e (unused).</param>
		private void OnCountdown(Object source, ElapsedEventArgs e)
		{
			if (--myTokenInfo.expires_in < TOKEN_EXPIRY_LIMIT)
			{
				StopTimer();
				myTokenInfo.expires_in = 0;
			}
		}
	}
}

