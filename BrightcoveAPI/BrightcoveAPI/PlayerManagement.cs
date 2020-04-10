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
    public class PlayerManagement : Base
    {
        public override string API_VERSION => "v2";

        public override string BaseURL => String.Format("https://players.api.brightcove.com/{0}/accounts", API_VERSION);

        public PlayerManagement(OAuthToken oauthToken, string strAccountID) : base(oauthToken, strAccountID) { }

        #region GetSinglePlayer functionality
        public string GetSinglePlayer(string strPlayerID) => GetSinglePlayer(Token, AccountID, strPlayerID);
        public string GetSinglePlayer(string strAccountID, string strPlayerID) => GetSinglePlayer(Token, strAccountID, strPlayerID);
        public string GetSinglePlayer(OAuthToken theToken, string strAccountID, string strPlayerID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/players/{2}", BaseURL, strAccountID, strPlayerID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Get All Players functionality
        public string GetAllPlayers() => GetAllPlayers(Token, AccountID);
        public string GetAllPlayers(string strAccountID) => GetAllPlayers(Token, strAccountID);
        public string GetAllPlayers(OAuthToken theToken, string strAccountID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/players", BaseURL, strAccountID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Create Player functionality
        public string CreatePlayer(string strJSONBody) => CreatePlayer(Token, AccountID, strJSONBody);
        public string CreatePlayer(string strAccountID, string strJSONBody) => CreatePlayer(Token, strAccountID, strJSONBody);
        public string CreatePlayer(OAuthToken theToken, string strAccountID, string strJSONBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/players", BaseURL, strAccountID);
            myCall.Method = Method.POST;
            myCall.Token = theToken.Token;
            myCall.JSONBody = strJSONBody;

            return (myCall.Execute());
        }
        #endregion

        #region Update Player functionality
        public string UpdatePlayer(string strPlayerID, string strJSONBody) => UpdatePlayer(Token, AccountID, strPlayerID, strJSONBody);
        public string UpdatePlayer(string strAccountID, string strPlayerID, string strJSONBody) => UpdatePlayer(Token, strAccountID, strPlayerID, strJSONBody);
        public string UpdatePlayer(OAuthToken theToken, string strAccountID, string strPlayerID, string strJSONBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/players/{2}", BaseURL, strAccountID, strPlayerID);
            myCall.Method = Method.PATCH;
            myCall.Token = theToken.Token;
            myCall.JSONBody = strJSONBody;

            return (myCall.Execute());
        }
        #endregion

        #region Publish Player functionality
        public string PublishPlayer(string strPlayerID) => PublishPlayer(Token, AccountID, strPlayerID, "");
        public string PublishPlayer(string strPlayerID, string strJSONBody) => PublishPlayer(Token, AccountID, strPlayerID, strJSONBody);
        public string PublishPlayer(string strAccountID, string strPlayerID, string strJSONBody) => PublishPlayer(Token, strAccountID, strPlayerID, strJSONBody);
        public string PublishPlayer(OAuthToken theToken, string strAccountID, string strPlayerID, string strJSONBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/players/{2}/publish", BaseURL, strAccountID, strPlayerID);
            myCall.Method = Method.POST;
            myCall.Token = theToken.Token;
            myCall.JSONBody = strJSONBody;

            return (myCall.Execute());
        }
        #endregion

        #region Delete Player functionality
        public string DeletePlayer(string strPlayerID) => DeletePlayer(Token, AccountID, strPlayerID);
        public string DeletePlayer(string strAccountID, string strPlayerID) => DeletePlayer(Token, strAccountID, strPlayerID);
        public string DeletePlayer(OAuthToken theToken, string strAccountID, string strPlayerID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/players/{2}", BaseURL, strAccountID, strPlayerID);
            myCall.Method = Method.DELETE;
            myCall.Token = theToken.Token;

            return (myCall.Execute());
        }
        #endregion
    }
}
