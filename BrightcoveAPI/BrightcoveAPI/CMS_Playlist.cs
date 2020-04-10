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
        #region Get Playlists functionality
        public string GetPlaylists() => GetPlaylists(Token, AccountID);
        public string GetPlaylists(string strAccountID) => GetPlaylists(Token, strAccountID);
        public string GetPlaylists(OAuthToken theToken, string strAccountID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/playlists", BaseURL, strAccountID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Get Playlist Count functionality
        public int GetPlaylistCount() => GetPlaylistCount(Token, AccountID);
        public int GetPlaylistCount(OAuthToken theToken, string strAccountID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/counts/playlists", BaseURL, strAccountID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            string apiresponse = myCall.Execute();

            dynamic playlistCountResponse = SimpleJson.DeserializeObject(apiresponse);

            if (apiresponse.Contains("error_code"))
            {
                return -1;
            }
            return Int32.Parse(String.Format("{0}", playlistCountResponse["count"]));
        }
        #endregion


        #region Get Playlist by ID functionality
        public string GetPlaylistByID(string strPlaylistID) => GetPlaylistByID(Token, AccountID, strPlaylistID);
        public string GetPlaylistByID(string strAccountID, string strPlaylistID) => GetPlaylistByID(Token, strAccountID, strPlaylistID);
        public string GetPlaylistByID(OAuthToken theToken, string strAccountID, string strPlaylistID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/playlists/{2}", BaseURL, strAccountID, strPlaylistID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Get Video Count in Playlist functionality
        public int GetVideoCountInPlaylist(string strPlaylistID) => GetVideoCountInPlaylist(Token, AccountID, strPlaylistID);
        public int GetVideoCountInPlaylist(string strAccountID, string strPlaylistID) => GetVideoCountInPlaylist(Token, strAccountID, strPlaylistID);
        public int GetVideoCountInPlaylist(OAuthToken theToken, string strAccountID, string strPlaylistID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/counts/playlists/{2}/videos", BaseURL, strAccountID, strPlaylistID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            string apiresponse = myCall.Execute();

            dynamic playlistVideoCountResponse = SimpleJson.DeserializeObject(apiresponse);

            if (apiresponse.Contains("error_code"))
            {
                return -1;
            }
            return Int32.Parse(String.Format("{0}", playlistVideoCountResponse["count"]));
        }
        #endregion

        #region Get Videos in Playlist functionality
        public string GetVideosInPlaylist(string strPlaylistID) => GetVideosInPlaylist(Token, AccountID, strPlaylistID);
        public string GetVideosInPlaylist(string strAccountID, string strPlaylistID) => GetVideosInPlaylist(Token, strAccountID, strPlaylistID);
        public string GetVideosInPlaylist(OAuthToken theToken, string strAccountID, string strPlaylistID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/playlists/{2}/videos", BaseURL, strAccountID, strPlaylistID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Create Playlist functionality
        public string CreatePlaylist(string strJSONBody) => CreatePlaylist(Token, AccountID, strJSONBody);
        public string CreatePlaylist(string strAccountID, string strJSONBody) => CreatePlaylist(Token, strAccountID, strJSONBody);
        public string CreatePlaylist(OAuthToken theToken, string strAccountID, string strJSONBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/playlists", BaseURL, strAccountID);
            myCall.Method = Method.POST;
            myCall.Token = theToken.Token;
            myCall.JSONBody = strJSONBody;

            return (myCall.Execute());
        }
        #endregion

        #region Update Playlist functionality
        public string UpdatePlaylist(string strPlaylistID, string strJSONBody) => UpdatePlaylist(Token, AccountID, strPlaylistID, strJSONBody);
        public string UpdatePlaylist(string strAccountID, string strPlaylistID, string strJSONBody) => UpdatePlaylist(Token, strAccountID, strPlaylistID, strJSONBody);
        public string UpdatePlaylist(OAuthToken theToken, string strAccountID, string strPlaylistID, string strJSONBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/playlists/{2}", BaseURL, strAccountID, strPlaylistID);
            myCall.Method = Method.PATCH;
            myCall.Token = theToken.Token;
            myCall.JSONBody = strJSONBody;

            return (myCall.Execute());
        }
        #endregion

        #region Delete Playlist functionality
        public string DeletePlaylist(string strPlaylistID) => DeletePlaylist(Token, AccountID, strPlaylistID);
        public string DeletePlaylist(string strAccountID, string strPlaylistID) => DeletePlaylist(Token, strAccountID, strPlaylistID);
        public string DeletePlaylist(OAuthToken theToken, string strAccountID, string strPlaylistID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/playlists/{2}", BaseURL, strAccountID, strPlaylistID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.DELETE;

            return (myCall.Execute());
        }
        #endregion

    }
}
