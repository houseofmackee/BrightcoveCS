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
    public partial class Live : Base
    {
        #region Create Ad Configuration functionality
        public string CreateAdConfiguration(string strJsonBody) => CreateAdConfiguration(APIKey, strJsonBody);
        public string CreateAdConfiguration(string strAPIKey, string strJsonBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/ssai/application", BaseURL);
            myCall.APIKey = strAPIKey;
            myCall.JSONBody = strJsonBody;
            myCall.Method = Method.POST;

            return (myCall.Execute());
        }
        #endregion

        #region Update Ad Configuration functionality
        public string UpdateAdConfiguration(string strAppID, string strJsonBody) => UpdateAdConfiguration(APIKey, strAppID, strJsonBody);
        public string UpdateAdConfiguration(string strAPIKey, string strAppID, string strJsonBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/ssai/application/{1}", BaseURL, strAppID);
            myCall.APIKey = strAPIKey;
            myCall.JSONBody = strJsonBody;
            myCall.Method = Method.PUT;

            return (myCall.Execute());
        }
        #endregion

        #region Delete Ad Configuration functionality
        public string DeleteAdConfiguration(string strAppID) => DeleteAdConfiguration(APIKey, strAppID);
        public string DeleteAdConfiguration(string strAPIKey, string strAppID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/ssai/application/{1}", BaseURL, strAppID);
            myCall.APIKey = strAPIKey;
            myCall.Method = Method.DELETE;

            return (myCall.Execute());
        }
        #endregion

        #region Get Account Ad Configurations functionality
        public string GetAccountAdConfigurations() => GetAccountAdConfigurations(APIKey);
        public string GetAccountAdConfigurations(string strAPIKey, string strAccountID="")
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/ssai/applications/{1}", BaseURL, strAccountID);
            myCall.APIKey = strAPIKey;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Get Ad Configuration functionality
        public string GetAdConfiguration(string strAppID) => GetAdConfiguration(APIKey, strAppID);
        public string GetAdConfiguration(string strAPIKey, string strAppID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/ssai/application/{1}", BaseURL, strAppID);
            myCall.APIKey = strAPIKey;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion


        #region Ingest Slate Media Source Asset functionality
        public string IngestSlateMediaSourceAsset(string strJsonBody) => IngestSlateMediaSourceAsset(APIKey, strJsonBody);
        public string IngestSlateMediaSourceAsset(string strAPIKey, string strJsonBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/ssai/slates", BaseURL);
            myCall.APIKey = strAPIKey;
            myCall.JSONBody = strJsonBody;
            myCall.Method = Method.POST;

            return (myCall.Execute());
        }
        #endregion

        #region Delete Slate Media Source Asset functionality
        public string DeleteSlateMediaSourceAsset(string strMSAID) => DeleteSlateMediaSourceAsset(APIKey, strMSAID);
        public string DeleteSlateMediaSourceAsset(string strAPIKey, string strMSAID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/ssai/slates/{1}", BaseURL, strMSAID);
            myCall.APIKey = strAPIKey;
            myCall.Method = Method.DELETE;

            return (myCall.Execute());
        }
        #endregion

        #region Get Slate Media Source Assets functionality
        public string GetSlateMediaSourceAssets() => GetSlateMediaSourceAssets(APIKey);
        public string GetSlateMediaSourceAssets(string strAPIKey, string strAccountID = "")
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/ssai/slates/{1}", BaseURL, strAccountID);
            myCall.APIKey = strAPIKey;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Create Beacon Set functionality
        public string CreateBeaconSet(string strJsonBody) => CreateBeaconSet(APIKey, strJsonBody);
        public string CreateBeaconSet(string strAPIKey, string strJsonBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/ssai/beaconset", BaseURL);
            myCall.APIKey = strAPIKey;
            myCall.JSONBody = strJsonBody;
            myCall.Method = Method.POST;

            return (myCall.Execute());
        }
        #endregion

        #region Update Beacon Set functionality
        public string UpdateBeaconSet(string strBeaconSetID, string strJsonBody) => UpdateBeaconSet(APIKey, strBeaconSetID, strJsonBody);
        public string UpdateBeaconSet(string strAPIKey, string strBeaconSetID, string strJsonBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/ssai/beaconset/{1}", BaseURL, strBeaconSetID);
            myCall.APIKey = strAPIKey;
            myCall.JSONBody = strJsonBody;
            myCall.Method = Method.PUT;

            return (myCall.Execute());
        }
        #endregion

        #region Get Beacon Sets functionality
        public string GetBeaconSets(string strAccountID) => GetBeaconSets(APIKey, strAccountID);
        public string GetBeaconSets(string strAPIKey, string strAccountID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/ssai/beaconsets/{1}", BaseURL, strAccountID);
            myCall.APIKey = strAPIKey;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Get Beacon Sets For User functionality
        public string GetBeaconSetsForUser() => GetBeaconSetsForUser(APIKey);
        public string GetBeaconSetsForUser(string strAPIKey)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/ssai/beaconsets", BaseURL);
            myCall.APIKey = strAPIKey;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Delete Beacon Set functionality
        public string DeleteBeaconSet(string strBeaconSetID) => DeleteBeaconSet(APIKey, strBeaconSetID);
        public string DeleteBeaconSet(string strAPIKey, string strBeaconSetID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/ssai/beaconset/{1}", BaseURL, strBeaconSetID);
            myCall.APIKey = strAPIKey;
            myCall.Method = Method.DELETE;

            return (myCall.Execute());
        }
        #endregion
    }
}
