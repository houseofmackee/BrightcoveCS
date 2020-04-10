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
using RestSharp;

namespace BrightcoveAPI
{
    public class Analytics : Base
    {
        public override string API_VERSION => "v1";
        public override string BaseURL => String.Format("https://analytics.api.brightcove.com/{0}", API_VERSION);

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BrightcoveAPI.Analytics"/> class.
        /// </summary>
        /// <param name="theToken">The token.</param>
        /// <param name="strAccountID">String account identifier.</param>
        public Analytics(OAuthToken theToken, string strAccountID) : base(theToken, strAccountID) { }
        public Analytics(OAuthToken theToken) : base(theToken) { }
        #endregion

        /// <summary>
        /// Executes the API query call.
        /// </summary>
        /// <returns>The API response as JSON.</returns>
        /// <param name="strAPIQuery">String API Query.</param>
        private string ExecuteCall(string strAPIQuery)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = strAPIQuery;
            myCall.Method = Method.GET;
            myCall.Token = Token.Token;

            return (myCall.Execute());
        }

        public string GetAnalyticsReport(string strAccounts, string strQuery)
           => (ExecuteCall(String.Format("{0}/data?accounts={1}&{2}", BaseURL, strAccounts, strQuery)));

        #region Get Player Engagement
        public string GetPlayerEngagement(string strPlayerID) => (GetPlayerEngagement(strPlayerID, AccountID));

        public string GetPlayerEngagement(string strPlayerID, string strAccountID, string strURLParameters = "")
        {
            if (!Helper.IsDigitsOnly(strAccountID))
            {
                throw new BrightcoveAPIException(Helper.strAccountIDNotValid);
            }

            // https://analytics.api.brightcove.com/v1/engagement/accounts/:account_id/players/:player_id

            string strClientURL = String.Format("{0}/engagement/accounts/{1}/players/{2}?{3}",
                                                BaseURL, strAccountID, strPlayerID, strURLParameters);

            return (ExecuteCall(strClientURL));
        }
        #endregion

        #region Get Video Engagement
        public string GetVideoEngagement(string strVideoID) => (GetVideoEngagement(strVideoID, AccountID));

        public string GetVideoEngagement(string strVideoID, string strAccountID, string strURLParameters = "")
        {
            if (!Helper.IsDigitsOnly(strVideoID))
            {
                throw new BrightcoveAPIException(Helper.strVideoIDNotValid);
            }

            if (!Helper.IsDigitsOnly(strAccountID))
            {
                throw new BrightcoveAPIException(Helper.strAccountIDNotValid);
            }

            // https://analytics.api.brightcove.com/v1/engagement/accounts/:account_id/videos/:video_id

            string strClientURL = String.Format("{0}/engagement/accounts/{1}/videos/{2}?{3}",
                                                BaseURL, strAccountID, strVideoID, strURLParameters);

            return (ExecuteCall(strClientURL));
        }
        #endregion

        #region Get Alltime Video Views
        public string GetAlltimeVideoViews(string strVideoID) => (GetAlltimeVideoViews(strVideoID, AccountID));

        public string GetAlltimeVideoViews(string strVideoID, string strAccountID)
        {
            if (!Helper.IsDigitsOnly(strVideoID))
            {
                throw new BrightcoveAPIException(Helper.strVideoIDNotValid);
            }

            if (!Helper.IsDigitsOnly(strAccountID))
            {
                throw new BrightcoveAPIException(Helper.strAccountIDNotValid);
            }

            string strClientURL = String.Format("{0}/alltime/accounts/{1}/videos/{2}",
                                                BaseURL, strAccountID, strVideoID);

            return (ExecuteCall(strClientURL));
        }
        #endregion
    }
}
