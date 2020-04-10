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
        #region Get Folders functionality
        public string GetFolders() => GetFolders(Token, AccountID, "");
        public string GetFolders(string strAccountID, string strQuery) => GetFolders(Token, strAccountID, strQuery);
        public string GetFolders(OAuthToken theToken, string strAccountID, string strQuery)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/folders?{2}", BaseURL, strAccountID, strQuery);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion


        #region Get Videos in Folders functionality
        public string GetVideosInFolders(string strFolderID) => GetVideosInFolders(Token, AccountID, strFolderID, "");
        public string GetVideosInFolders(string strFolderID, string strQuery) => GetVideosInFolders(Token, AccountID, strFolderID, strQuery);
        public string GetVideosInFolders(string strAccountID, string strFolderID, string strQuery) => GetVideosInFolders(Token, strAccountID, strFolderID, strQuery);
        public string GetVideosInFolders(OAuthToken theToken, string strAccountID, string strFolderID, string strQuery)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/folders/{2}/videos?{3}", BaseURL, strAccountID, strFolderID, strQuery);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion


        #region Add Video to Folder functionality
        public string AddVideoToFolder(string strFolderID, string strVideoID) => AddVideoToFolder(Token, AccountID, strFolderID, strVideoID);
        public string AddVideoToFolder(string strAccountID, string strFolderID, string strVideoID) => AddVideoToFolder(Token, strAccountID, strFolderID, strVideoID);
        public string AddVideoToFolder(OAuthToken theToken, string strAccountID, string strFolderID, string strVideoID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/folders/{2}/videos/{3}", BaseURL, strAccountID, strFolderID, strVideoID);
            myCall.Method = Method.PUT;
            myCall.Token = theToken.Token;

            return (myCall.Execute());
        }
        #endregion


        #region Remove Video from Folder functionality
        public string RemoveVideoFromFolder(string strFolderID, string strVideoID) => RemoveVideoFromFolder(Token, AccountID, strFolderID, strVideoID);
        public string RemoveVideoFromFolder(string strAccountID, string strFolderID, string strVideoID) => RemoveVideoFromFolder(Token, strAccountID, strFolderID, strVideoID);
        public string RemoveVideoFromFolder(OAuthToken theToken, string strAccountID, string strFolderID, string strVideoID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/folders/{2}/videos/{3}", BaseURL, strAccountID, strFolderID, strVideoID);
            myCall.Method = Method.DELETE;
            myCall.Token = theToken.Token;

            return (myCall.Execute());
        }
        #endregion


        #region Create Folder functionality
        public string CreateFolder(string strJSONBody) => CreateFolder(Token, AccountID, strJSONBody);
        public string CreateFolder(string strAccountID, string strJSONBody) => CreateFolder(Token, strAccountID, strJSONBody);
        public string CreateFolder(OAuthToken theToken, string strAccountID, string strJSONBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/folders", BaseURL, strAccountID);
            myCall.Method = Method.POST;
            myCall.Token = theToken.Token;
            myCall.JSONBody = strJSONBody;

            return (myCall.Execute());
        }
        #endregion


        #region Update Folder Name functionality
        public string UpdateFolderName(string strFolderID, string strJSONBody) => UpdateFolderName(Token, AccountID, strFolderID, strJSONBody);
        public string UpdateFolderName(string strAccountID, string strFolderID, string strJSONBody) => UpdateFolderName(Token, strAccountID, strFolderID, strJSONBody);
        public string UpdateFolderName(OAuthToken theToken, string strAccountID, string strFolderID, string strJSONBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/folders/{2}", BaseURL, strAccountID, strFolderID);
            myCall.Method = Method.PATCH;
            myCall.Token = theToken.Token;
            myCall.JSONBody = strJSONBody;

            return (myCall.Execute());
        }
        #endregion


        #region Delete Folder functionality
        public string DeleteFolder(string strFolderID) => DeleteFolder(Token, AccountID, strFolderID);
        public string DeleteFolder(string strAccountID, string strFolderID) => DeleteFolder(Token, strAccountID, strFolderID);
        public string DeleteFolder(OAuthToken theToken, string strAccountID, string strFolderID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/folders/{2}", BaseURL, strAccountID, strFolderID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.DELETE;

            return (myCall.Execute());
        }
        #endregion


        #region Get Folder Information functionality
        public string GetFolderInformation(string strFolderID) => GetFolderInformation(Token, AccountID, strFolderID);
        public string GetFolderInformation(string strAccountID, string strFolderID) => GetFolderInformation(Token, strAccountID, strFolderID);
        public string GetFolderInformation(OAuthToken theToken, string strAccountID, string strFolderID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/folders/{2}", BaseURL, strAccountID, strFolderID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion
    }
}
