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
        #region Create Live Job functionality
        public string CreateLiveJob(string strJsonBody) => CreateLiveJob(APIKey, strJsonBody);
        public string CreateLiveJob(string strAPIKey, string strJsonBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/jobs", BaseURL);
            myCall.APIKey = strAPIKey;
            myCall.JSONBody = strJsonBody;
            myCall.Method = Method.POST;

            return (myCall.Execute());
        }
        #endregion


        #region Get Live Jobs functionality
        public string GetLiveJobs() => GetLiveJobs(APIKey);
        public string GetLiveJobs(string strAPIKey)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/ui/jobs/live", BaseURL);
            myCall.APIKey = strAPIKey;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Get Live Job Details functionality
        public string GetLiveJobDetails(string strLiveJobID) => GetLiveJobDetails(APIKey, strLiveJobID);
        public string GetLiveJobDetails(string strAPIKey, string strLiveJobID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/jobs/{1}", BaseURL, strLiveJobID);
            myCall.APIKey = strAPIKey;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Stop Live Job functionality
        public string StopLiveJob(string strLiveJobID) => StopLiveJob(APIKey, strLiveJobID);
        public string StopLiveJob(string strAPIKey, string strLiveJobID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/jobs/{1}/cancel", BaseURL, strLiveJobID);
            myCall.APIKey = strAPIKey;
            myCall.Method = Method.PUT;

            return (myCall.Execute());
        }
        #endregion    

        #region Activate SEP Stream functionality
        public string ActivateSEPStream(string strLiveJobID) => ActivateSEPStream(APIKey, strLiveJobID);
        public string ActivateSEPStream(string strAPIKey, string strLiveJobID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/jobs/{1}/activate", BaseURL, strLiveJobID);
            myCall.APIKey = strAPIKey;
            myCall.Method = Method.PUT;

            return (myCall.Execute());
        }
        #endregion

        #region Deactivate SEP Stream functionality
        public string DeactivateSEPStream(string strLiveJobID) => DeactivateSEPStream(APIKey, strLiveJobID);
        public string DeactivateSEPStream(string strAPIKey, string strLiveJobID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/jobs/{1}/deactivate", BaseURL, strLiveJobID);
            myCall.APIKey = strAPIKey;
            myCall.Method = Method.PUT;

            return (myCall.Execute());
        }
        #endregion


        #region Manual Ad Cue Point Insertion functionality
        public string ManualAdCuePointInsertion(string strLiveJobID, string strJsonBody) => ManualAdCuePointInsertion(APIKey, strLiveJobID, strJsonBody);
        public string ManualAdCuePointInsertion(string strAPIKey, string strLiveJobID, string strJsonBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/jobs/{1}/cuepoint", BaseURL, strLiveJobID);
            myCall.APIKey = strAPIKey;
            myCall.JSONBody = strJsonBody;
            myCall.Method = Method.POST;

            return (myCall.Execute());
        }
        #endregion


        #region Insert ID3 Timed Metadata functionality
        public string InsertID3TimedMetadata(string strLiveJobID, string strJsonBody) => InsertID3TimedMetadata(APIKey, strLiveJobID, strJsonBody);
        public string InsertID3TimedMetadata(string strAPIKey, string strLiveJobID, string strJsonBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/jobs/{1}/id3tag", BaseURL, strLiveJobID);
            myCall.APIKey = strAPIKey;
            myCall.JSONBody = strJsonBody;
            myCall.Method = Method.POST;

            return (myCall.Execute());
        }
        #endregion
    }
}
