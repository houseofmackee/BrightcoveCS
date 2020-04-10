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
        #region List Channels functionality
        public string ListChannels() => ListChannels(Token, AccountID);
        public string ListChannels(string strAccountID) => ListChannels(Token, strAccountID);
        public string ListChannels(OAuthToken theToken, string strAccountID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/channels", BaseURL, strAccountID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Get Channel Details functionality
        public string GetChannelDetail(string strChannelName) => GetChannelDetail(Token, AccountID, strChannelName);
        public string GetChannelDetail(string strAccountID, string strChannelName) => GetChannelDetail(Token, strAccountID, strChannelName);
        public string GetChannelDetail(OAuthToken theToken, string strAccountID, string strChannelName)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/channels/{2}", BaseURL, strAccountID, strChannelName);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Update Channel functionality
        public string UpdateChannel(string strChannelName, string strJSONBody) => UpdateChannel(Token, AccountID, strChannelName, strJSONBody);
        public string UpdateChannel(string strAccountID, string strChannelName, string strJSONBody) => UpdateChannel(Token, strAccountID, strChannelName, strJSONBody);
        public string UpdateChannel(OAuthToken theToken, string strAccountID, string strChannelName, string strJSONBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/channels/{2}", BaseURL, strAccountID, strChannelName);
            myCall.Token = theToken.Token;
            myCall.Method = Method.PATCH;
            myCall.JSONBody = strJSONBody;

            return (myCall.Execute());
        }
        #endregion

        #region List Channel Affiliates functionality
        public string ListChannelAffiliates(string strChannelName) => ListChannelAffiliates(Token, AccountID, strChannelName);
        public string ListChannelAffiliates(string strAccountID, string strChannelName) => ListChannelAffiliates(Token, strAccountID, strChannelName);
        public string ListChannelAffiliates(OAuthToken theToken, string strAccountID, string strChannelName)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/channels/{2}/members", BaseURL, strAccountID, strChannelName);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Add Affiliate functionality
        public string AddAffiliate(string strChannelName, string strAffiliateAccountID) => AddAffiliate(Token, AccountID, strChannelName, strAffiliateAccountID);
        public string AddAffiliate(string strAccountID, string strChannelName, string strAffiliateAccountID) => AddAffiliate(Token, strAccountID, strChannelName, strAffiliateAccountID);
        public string AddAffiliate(OAuthToken theToken, string strAccountID, string strChannelName, string strAffiliateAccountID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/channels/{2}/members/{3}", BaseURL, strAccountID, strChannelName, strAffiliateAccountID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.PUT;

            return (myCall.Execute());
        }
        #endregion

        #region Remove Affiliate functionality
        public string RemoveAffiliate(string strChannelName, string strAffiliateAccountID) => RemoveAffiliate(Token, AccountID, strChannelName, strAffiliateAccountID);
        public string RemoveAffiliate(string strAccountID, string strChannelName, string strAffiliateAccountID) => RemoveAffiliate(Token, strAccountID, strChannelName, strAffiliateAccountID);
        public string RemoveAffiliate(OAuthToken theToken, string strAccountID, string strChannelName, string strAffiliateAccountID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/channels/{2}/members/{3}", BaseURL, strAccountID, strChannelName, strAffiliateAccountID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.DELETE;

            return (myCall.Execute());
        }
        #endregion

        #region List Contracts functionality
        public string ListContracts() => ListContracts(Token, AccountID);
        public string ListContracts(string strAccountID) => ListContracts(Token, strAccountID);
        public string ListContracts(OAuthToken theToken, string strAccountID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/contracts", BaseURL, strAccountID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Get Contract functionality
        public string GetContract(string strMasterAccountID) => GetContract(Token, AccountID, strMasterAccountID);
        public string GetContract(string strAccountID, string strMasterAccountID) => GetContract(Token, strAccountID, strMasterAccountID);
        public string GetContract(OAuthToken theToken, string strAccountID, string strMasterAccountID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/contracts/{2}", BaseURL, strAccountID, strMasterAccountID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Approve Contract functionality
        public string ApproveContract(string strMasterAccountID, string strJSONBody) => ApproveContract(Token, AccountID, strMasterAccountID, strJSONBody);
        public string ApproveContract(string strAccountID, string strMasterAccountID, string strJSONBody) => ApproveContract(Token, strAccountID, strMasterAccountID, strJSONBody);
        public string ApproveContract(OAuthToken theToken, string strAccountID, string strMasterAccountID, string strJSONBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/contracts/{2}", BaseURL, strAccountID, strMasterAccountID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.PATCH;
            myCall.JSONBody = strJSONBody;

            return (myCall.Execute());
        }
        #endregion

        #region List Shares functionality
        public string ListShares(string strVideoID) => ListShares(Token, AccountID, strVideoID);
        public string ListShares(string strAccountID, string strVideoID) => ListShares(Token, strAccountID, strVideoID);
        public string ListShares(OAuthToken theToken, string strAccountID, string strVideoID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}/shares", BaseURL, strAccountID, strVideoID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Share Video functionality
        public string ShareVideo(string strVideoID, string strJSONBody) => ShareVideo(Token, AccountID, strVideoID, strJSONBody);
        public string ShareVideo(string strAccountID, string strVideoID, string strJSONBody) => ShareVideo(Token, strAccountID, strVideoID, strJSONBody);
        public string ShareVideo(OAuthToken theToken, string strAccountID, string strVideoID, string strJSONBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}/shares", BaseURL, strAccountID, strVideoID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.POST;
            myCall.JSONBody = strJSONBody;

            return (myCall.Execute());
        }
        #endregion

        #region Accept Share functionality
        public string AcceptShare(string strVideoID, string strJSONBody) => AcceptShare(Token, AccountID, strVideoID, strJSONBody);
        public string AcceptShare(string strAccountID, string strVideoID, string strJSONBody) => AcceptShare(Token, strAccountID, strVideoID, strJSONBody);
        public string AcceptShare(OAuthToken theToken, string strAccountID, string strVideoID, string strJSONBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}", BaseURL, strAccountID, strVideoID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.PATCH;
            myCall.JSONBody = strJSONBody;

            return (myCall.Execute());
        }
        #endregion

        #region Unshare Video functionality
        public string UnshareVideo(string strVideoID, string strAffiliateAccountID) => UnshareVideo(Token, AccountID, strVideoID, strAffiliateAccountID);
        public string UnshareVideo(string strAccountID, string strVideoID, string strAffiliateAccountID) => UnshareVideo(Token, strAccountID, strVideoID, strAffiliateAccountID);
        public string UnshareVideo(OAuthToken theToken, string strAccountID, string strVideoID, string strAffiliateAccountID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}/shares/{3}", BaseURL, strAccountID, strVideoID, strAffiliateAccountID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.DELETE;

            return (myCall.Execute());
        }
        #endregion
    }
}
