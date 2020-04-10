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
using System.Collections.Generic;
using RestSharp;

namespace BrightcoveAPI
{
    public class DynamicIngest : Base
	{
		public class IngestMediaAssetRequestBody
		{
			// required structs/objects
			public struct sMaster
			{
				public string url;
				public bool use_archived_master;
			};

			public struct sTextTracks
			{
				public string url;
				public string srclang;
				public string kind;
				public string label;
				public bool @default;

			};

			public struct sImage
			{
				public string url;
				public int height;
				public int width;
			};

			// the actual body
			public sMaster master;
			public string profile;
			public sTextTracks[] text_tracks;
			public sImage poster;
			public sImage thumbnail;
			public bool capture_images;
			public string[] callbacks;
		}

        public override string API_VERSION => "v1";
        public override string BaseURL => String.Format("https://ingest.api.brightcove.com/{0}/accounts", API_VERSION);

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BrightcoveAPI.DynamicIngest"/> class.
        /// </summary>
        /// <param name="oauthToken">Oauth token.</param>
        /// <param name="strAccountID">String account identifier.</param>
        public DynamicIngest(OAuthToken oauthToken, string strAccountID) : base(oauthToken, strAccountID) { }
        #endregion

        /// <summary>
        /// Executes the call.
        /// </summary>
        /// <returns>The call.</returns>
        /// <param name="strVideoID">String video identifier.</param>
        /// <param name="strJSONBody">String JSONB ody.</param>
        public string IngestMediaAsset(string strVideoID, string strJSONBody) => IngestMediaAsset(Token, AccountID, strVideoID, strJSONBody);
        public string IngestMediaAsset(string strAccountID, string strVideoID, string strJSONBody) => IngestMediaAsset(Token, strAccountID, strVideoID, strJSONBody);
        public string IngestMediaAsset(OAuthToken theToken, string strAccountID, string strVideoID, string strJSONBody)
        {
            if (!Helper.IsDigitsOnly(strVideoID))
            {
                throw new BrightcoveAPIException(Helper.strVideoIDNotValid);
            }

            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}/ingest-requests", BaseURL, strAccountID, strVideoID);
            myCall.Method = Method.POST;
            myCall.Token = theToken.Token;
            myCall.JSONBody = strJSONBody;

            return (myCall.Execute());
        }

	}
}
