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
    public partial class CMS : Base
    {
        #region Get Subscriptions List functionality
        public string GetSubscriptionsList() => GetSubscriptionsList(Token, AccountID);
        public string GetSubscriptionsList(string strAccountID) => GetSubscriptionsList(Token, strAccountID);
        public string GetSubscriptionsList(OAuthToken theToken, string strAccountID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/subscriptions", BaseURL, strAccountID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Create Subscription functionality
        public string CreateSubscription(string strJSONBody) => CreateSubscription(Token, AccountID, strJSONBody);
        public string CreateSubscription(string strAccountID, string strJSONBody) => CreateSubscription(Token, strAccountID, strJSONBody);
        public string CreateSubscription(OAuthToken theToken, string strAccountID, string strJSONBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/subscriptions", BaseURL, strAccountID);
            myCall.Method = Method.POST;
            myCall.Token = theToken.Token;
            myCall.JSONBody = strJSONBody;

            return (myCall.Execute());
        }
        #endregion

        #region Get Subscription functionality
        public string GetSubscription(string strSubscriptionID) => GetSubscription(Token, AccountID, strSubscriptionID);
        public string GetSubscription(string strAccountID, string strSubscriptionID) => GetSubscription(Token, strAccountID, strSubscriptionID);
        public string GetSubscription(OAuthToken theToken, string strAccountID, string strSubscriptionID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/subscriptions/{2}", BaseURL, strAccountID, strSubscriptionID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion


        #region Delete Subscription functionality
        public string DeleteSubscription(string strSubscriptionID) => DeleteSubscription(Token, AccountID, strSubscriptionID);
        public string DeleteSubscription(string strAccountID, string strSubscriptionID) => DeleteSubscription(Token, strAccountID, strSubscriptionID);
        public string DeleteSubscription(OAuthToken theToken, string strAccountID, string strSubscriptionID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/subscriptions/{2}", BaseURL, strAccountID, strSubscriptionID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.DELETE;

            return (myCall.Execute());
        }
        #endregion
    }
}
