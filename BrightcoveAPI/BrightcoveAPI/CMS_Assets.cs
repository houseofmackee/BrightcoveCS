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
        #region Get Assets functionality
        public string GetAssets(string strVideoID) => GetAssets(Token, AccountID, strVideoID);
        public string GetAssets(string strAccountID, string strVideoID) => GetAssets(Token, strAccountID, strVideoID);
        public string GetAssets(OAuthToken theToken, string strAccountID, string strVideoID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}/assets", BaseURL, strAccountID, strVideoID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Get Rendition List functionality
        public string GetRenditionList(string strVideoID) => GetRenditionList(Token, AccountID, strVideoID);
        public string GetRenditionList(string strAccountID, string strVideoID) => GetRenditionList(Token, strAccountID, strVideoID);
        public string GetRenditionList(OAuthToken theToken, string strAccountID, string strVideoID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}/assets/renditions", BaseURL, strAccountID, strVideoID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Get Rendition functionality
        public string GetRendition(string strVideoID, string strAssetID) => GetRendition(Token, AccountID, strVideoID, strAssetID);
        public string GetRendition(string strAccountID, string strVideoID, string strAssetID) => GetRendition(Token, strAccountID, strVideoID, strAssetID);
        public string GetRendition(OAuthToken theToken, string strAccountID, string strVideoID, string strAssetID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}/assets/renditions/{3}", BaseURL, strAccountID, strVideoID, strAssetID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Add Rendition functionality
        public string AddRendition(string strVideoID, string strJSONBody) => AddRendition(Token, AccountID, strVideoID, strJSONBody);
        public string AddRendition(string strAccountID, string strVideoID, string strJSONBody) => AddRendition(Token, strAccountID, strVideoID, strJSONBody);
        public string AddRendition(OAuthToken theToken, string strAccountID, string strVideoID, string strJSONBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}/assets/renditions", BaseURL, strAccountID, strVideoID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.POST;
            myCall.JSONBody = strJSONBody;

            return (myCall.Execute());
        }
        #endregion

        #region UpdateRendition functionality
        public string UpdateRendition(string strVideoID, string strAssetID, string strJSONBody) => UpdateRendition(Token, AccountID, strVideoID, strAssetID, strJSONBody);
        public string UpdateRendition(string strAccountID, string strVideoID, string strAssetID, string strJSONBody) => UpdateRendition(Token, strAccountID, strVideoID, strAssetID, strJSONBody);
        public string UpdateRendition(OAuthToken theToken, string strAccountID, string strVideoID, string strAssetID, string strJSONBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}/assets/renditions/{3}", BaseURL, strAccountID, strVideoID, strAssetID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.PATCH;
            myCall.JSONBody = strJSONBody;

            return (myCall.Execute());
        }
        #endregion

        #region Delete Rendition functionality
        public string DeleteRendition(string strVideoID, string strAssetID) => DeleteRendition(Token, AccountID, strVideoID, strAssetID);
        public string DeleteRendition(string strAccountID, string strVideoID, string strAssetID) => DeleteRendition(Token, strAccountID, strVideoID, strAssetID);
        public string DeleteRendition(OAuthToken theToken, string strAccountID, string strVideoID, string strAssetID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}/assets/renditions/{3}", BaseURL, strAccountID, strVideoID, strAssetID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.DELETE;

            return (myCall.Execute());
        }
        #endregion

        #region Get Dynamic Renditions functionality
        public string GetDynamicRenditions(string strVideoID) => GetDynamicRenditions(Token, AccountID, strVideoID);
        public string GetDynamicRenditions(string strAccountID, string strVideoID) => GetDynamicRenditions(Token, strAccountID, strVideoID);
        public string GetDynamicRenditions(OAuthToken theToken, string strAccountID, string strVideoID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}/assets/dynamic_renditions", BaseURL, strAccountID, strVideoID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion
    }
}
