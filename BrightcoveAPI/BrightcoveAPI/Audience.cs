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
using RestSharp;

namespace BrightcoveAPI
{
    public class Audience : Base
    {
        public override string API_VERSION => "v1";

        public override string BaseURL => String.Format("https://audience.api.brightcove.com/{0}/accounts", API_VERSION);

        public Audience(OAuthToken oauthToken, string strAccountID) : base(oauthToken, strAccountID) { }

        #region Get View Events functionality
        public string GetViewEvents() => GetViewEvents(Token, AccountID);
        public string GetViewEvents(string strAccountID) => GetViewEvents(Token, strAccountID);
        public string GetViewEvents(OAuthToken theToken, string strAccountID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/view_events", BaseURL, strAccountID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Get Leads functionality
        public string GetLeads() => GetLeads(Token, AccountID);
        public string GetLeads(string strAccountID) => GetLeads(Token, strAccountID);
        public string GetLeads(OAuthToken theToken, string strAccountID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/leads", BaseURL, strAccountID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion    
    }
}
