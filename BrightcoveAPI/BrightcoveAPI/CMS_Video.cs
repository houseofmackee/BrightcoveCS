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
using System.Collections.Generic;
using RestSharp;

namespace BrightcoveAPI
{
    public partial class CMS : Base
    {
        #region Create Video functionality
        /// <summary>
        /// Creates the asset.
        /// </summary>
        /// <returns>The asset.</returns>
        /// <param name="strAssetName">String asset name.</param>
        /// <param name="strRefID">String reference identifier.</param>
        /// <exception cref="Base.BrightcoveAPIException">Thrown when the CMS API call returns an error.</exception>
        public string CreateVideo(string strAssetName, string strRefID = "") =>
            CreateVideo(Token, AccountID, strAssetName, strRefID);

        /// <summary>
        /// Creates the asset.
        /// </summary>
        /// <returns>The asset.</returns>
        /// <param name="theToken">The token.</param>
        /// <param name="strAccountID">String account identifier.</param>
        /// <param name="strAssetName">String asset name.</param>
        /// <param name="strRefID">String reference identifier.</param>
        /// <exception cref="Base.BrightcoveAPIException">Thrown when the CMS API call returns an error.</exception>
        public string CreateVideo(OAuthToken theToken, string strAccountID, string strAssetName, string strRefID = "")
        {
            // create and populate the request body object
            var createAssetRequestBody = new CVORequestBody();

            createAssetRequestBody.name = strAssetName;
            createAssetRequestBody.reference_id = strRefID;

            return CreateVideo(theToken, strAccountID, createAssetRequestBody);
        }

        /// <summary>
        /// Creates the asset.
        /// </summary>
        /// <returns>The asset.</returns>
        /// <param name="theToken">The token.</param>
        /// <param name="strAccountID">String account identifier.</param>
        /// <param name="theBody">The body.</param>
        /// <exception cref="Base.BrightcoveAPIException">Thrown when the CMS API call returns an error.</exception>
        public string CreateVideo(OAuthToken theToken, string strAccountID, CVORequestBody theBody)
        {
            if (!Helper.IsDigitsOnly(strAccountID))
            {
                throw new BrightcoveAPIException(Helper.strAccountIDNotValid);
            }

            var client = new RestClient(String.Format("{0}/{1}/videos", BaseURL, strAccountID));
            var request = new RestRequest();

            // serialize the object to JSON
            string strJSONBody = SimpleJson.SerializeObject(theBody);

            request.Parameters.Clear();

            request.Method = Method.POST;
            request.AddHeader("Content-type", "application/json");
            request.AddParameter("Authorization", "Bearer " + theToken.Token, ParameterType.HttpHeader);
            request.AddParameter("application/json", strJSONBody, ParameterType.RequestBody);

            IRestResponse apiresponse = client.Execute(request);

            dynamic createAssetResponse = SimpleJson.DeserializeObject(apiresponse.Content);

            if (apiresponse.Content.Contains("error_code"))
            {
                throw new BrightcoveAPIException(createAssetResponse[0]["error_code"]);
            }

            return createAssetResponse["id"];
        }
        #endregion



        #region Get Videos functionality
        public string GetVideos() => GetVideos(Token, AccountID);
        public string GetVideos(string strQueryString) => GetVideos(Token, AccountID, strQueryString);
        public string GetVideos(string strAccountID, string strQueryString) => GetVideos(Token, strAccountID, strQueryString);
        public string GetVideos(OAuthToken theToken, string strAccountID, string strQueryString = "")
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos?{2}", BaseURL, strAccountID, strQueryString);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion



        #region Get Video Count functionality
        public int GetVideoCount() => GetVideoCount(Token, AccountID);
        public int GetVideoCount(string strAccountID) => GetVideoCount(Token, strAccountID);
        public int GetVideoCount(OAuthToken theToken, string strAccountID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/counts/videos", BaseURL, strAccountID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            string apiresponse = myCall.Execute();

            dynamic videoCountResponse = SimpleJson.DeserializeObject(apiresponse);

            if (apiresponse.Contains("error_code"))
            {
                return -1;
            }
            return Int32.Parse(String.Format("{0}", videoCountResponse["count"]));
        }
        #endregion


        #region Get Video functionality
        public string GetVideoByID(string strVideoID) => GetVideo(Token, AccountID, strVideoID);
        public string GetVideoByID(string strAccountID, string strVideoID) => GetVideo(Token, strAccountID, strVideoID);
        public string GetVideoByID(OAuthToken theToken, string strAccountID, string strVideoID) => GetVideo(theToken, strAccountID, strVideoID);

        public string GetVideoByRefID(string strRefID) => GetVideoByRefID(Token, AccountID, strRefID);
        public string GetVideoByRefID(string strAccountID, string strRefID) => GetVideoByRefID(Token, strAccountID, strRefID);
        public string GetVideoByRefID(OAuthToken theToken, string strAccountID, string strRefID) => GetVideo(theToken, strAccountID, String.Format("ref:{0}", strRefID));

        public string GetVideo(string strVideoID) => GetVideo(Token, AccountID, strVideoID);
        public string GetVideo(string strAccountID, string strVideoID) => GetVideo(Token, strAccountID, strVideoID);
        public string GetVideo(OAuthToken theToken, string strAccountID, string strVideoID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}", BaseURL, strAccountID, strVideoID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion




        #region Update Video functionality
        public string UpdateVideo(string strVideoID, string strJsonBody) => UpdateVideo(Token, AccountID, strVideoID, strJsonBody);
        public string UpdateVideo(string strAccountID, string strVideoID, string strJsonBody) => UpdateVideo(Token, strAccountID, strVideoID, strJsonBody);
        public string UpdateVideo(OAuthToken theToken, string strAccountID, string strVideoID, string strJsonBody)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}", BaseURL, strAccountID, strVideoID);
            myCall.Token = theToken.Token;
            myCall.JSONBody = strJsonBody;
            myCall.Method = Method.PATCH;

            return (myCall.Execute());
        }
        #endregion



        #region Get Video Sources functionality
        public string GetVideoSources(string strVideoID) => GetVideoSources(Token, AccountID, strVideoID);
        public string GetVideoSources(string strAccountID, string strVideoID) => GetVideoSources(Token, strAccountID, strVideoID);
        public string GetVideoSources(OAuthToken theToken, string strAccountID, string strVideoID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}/sources", BaseURL, strAccountID, strVideoID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion


        #region Get Video Images functionality
        public string GetVideoImages(string strVideoID) => GetVideoImages(Token, AccountID, strVideoID);
        public string GetVideoImages(string strAccountID, string strVideoID) => GetVideoImages(Token, strAccountID, strVideoID);
        public string GetVideoImages(OAuthToken theToken, string strAccountID, string strVideoID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}/images", BaseURL, strAccountID, strVideoID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Get Digital Master Info functionality
        public string GetDigitalMasterInfo(string strVideoID) => GetDigitalMasterInfo(Token, AccountID, strVideoID);
        public string GetDigitalMasterInfo(string strAccountID, string strVideoID) => GetDigitalMasterInfo(Token, strAccountID, strVideoID);
        public string GetDigitalMasterInfo(OAuthToken theToken, string strAccountID, string strVideoID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}/digital_master", BaseURL, strAccountID, strVideoID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Delete Digital Master functionality
        public string DeleteDigitalMaster(string strVideoID) => DeleteDigitalMaster(Token, AccountID, strVideoID);
        public string DeleteDigitalMaster(string strAccountID, string strVideoID) => DeleteDigitalMaster(Token, strAccountID, strVideoID);
        public string DeleteDigitalMaster(OAuthToken theToken, string strAccountID, string strVideoID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}/digital_master", BaseURL, strAccountID, strVideoID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.DELETE;

            return (myCall.Execute());
        }
        #endregion


        #region Get Playlists for Video functionality
        public string GetPlaylistsForVideo(string strVideoID) => GetPlaylistsForVideo(Token, AccountID, strVideoID);
        public string GetPlaylistsForVideo(string strAccountID, string strVideoID) => GetPlaylistsForVideo(Token, strAccountID, strVideoID);
        public string GetPlaylistsForVideo(OAuthToken theToken, string strAccountID, string strVideoID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}/references", BaseURL, strAccountID, strVideoID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion


        #region Remove Video from all Playlists functionality
        public string RemoveVideoFromAllPlaylists(string strVideoID) => RemoveVideoFromAllPlaylists(Token, AccountID, strVideoID);
        public string RemoveVideoFromAllPlaylists(string strAccountID, string strVideoID) => RemoveVideoFromAllPlaylists(Token, strAccountID, strVideoID);
        public string RemoveVideoFromAllPlaylists(OAuthToken theToken, string strAccountID, string strVideoID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}/references", BaseURL, strAccountID, strVideoID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.DELETE;

            return (myCall.Execute());
        }
        #endregion

        #region Delete Video functionality
        public string DeleteVideo(string strVideoID) => DeleteVideo(Token, AccountID, strVideoID);
        public string DeleteVideo(string strAccountID, string strVideoID) => DeleteVideo(Token, strAccountID, strVideoID);
        public string DeleteVideo(OAuthToken theToken, string strAccountID, string strVideoID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}", BaseURL, strAccountID, strVideoID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.DELETE;

            return (myCall.Execute());
        }
        #endregion


        #region Get Status of Ingest Jobs functionality
        public string GetStatusOfIngestJobs(string strVideoID) => GetStatusOfIngestJobs(Token, AccountID, strVideoID);
        public string GetStatusOfIngestJobs(string strAccountID, string strVideoID) => GetStatusOfIngestJobs(Token, strAccountID, strVideoID);
        public string GetStatusOfIngestJobs(OAuthToken theToken, string strAccountID, string strVideoID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}/ingest_jobs", BaseURL, strAccountID, strVideoID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Get Status of Ingest Job functionality
        public string GetStatusOfIngestJob(string strVideoID, string strJobID) => GetStatusOfIngestJob(Token, AccountID, strVideoID, strJobID);
        public string GetStatusOfIngestJob(string strAccountID, string strVideoID, string strJobID) => GetStatusOfIngestJob(Token, strAccountID, strVideoID, strJobID);
        public string GetStatusOfIngestJob(OAuthToken theToken, string strAccountID, string strVideoID, string strJobID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/videos/{2}/ingest_jobs/{3}", BaseURL, strAccountID, strVideoID, strJobID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Get Custom Fields functionality
        public string GetCustomFields() => GetCustomFields(Token, AccountID);
        public string GetCustomFields(string strAccountID) => GetCustomFields(Token, strAccountID);
        public string GetCustomFields(OAuthToken theToken, string strAccountID)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = String.Format("{0}/{1}/video_fields", BaseURL, strAccountID);
            myCall.Token = theToken.Token;
            myCall.Method = Method.GET;

            return (myCall.Execute());
        }
        #endregion

        #region Create Video Object structures

        public class GeoInfo
        {
            public string[] countries = null;   // optional
                                                // String[]
                                                // array of ISO 3166 list of 2-letter codes in lower-case
                                                // Default value: null

            public bool exclude_countries = false;  // optional
                                                    // Boolean
                                                    // if true, country array is treated as a list of countries excluded from viewing
                                                    // Default value: false

            public bool restricted = false;   // optional
                                              // Boolean
                                              // whether geo-restriction is enabled for this video
                                              // Default value: false
            public GeoInfo()
            {
                countries = new string[] { };
            }
        }

        // CVO = Create Video Object
        public class CVOResponse
        {
            public string id;
            public string account_id;
            public string[] ad_keys;
            public bool complete;
            public string created_at;
            public string[] cue_points;
            public Dictionary<string, string> custom_fields;
            public string delivery_type;
            public string description;
            public string digital_master_id;
            public string duration;
            public string economics;
            public string folder_id;
            public GeoInfo geo;
            public bool has_digital_master;
            public Dictionary<string, string> images;
            public string link;
            public string long_description;
            public string name;
            public string original_filename;
            public string published_at;
            public string reference_id;
            public string[] schedule;
            public string[] sharing;
            public string state;
            public string[] tags;
            public string[] text_tracks;
            public string updated_at;
        }

        public class CVORequestBody
        {
            public string name;                 // name String video title Size range: 1..255
            public string description = "";     // optional String video short description Size range: 0..250
            public string long_description = "";// optional String video long description Size range: 0..5000
            public string reference_id = "";    // optional String video reference-id(must be unique within the account) Size range: ..150
            public string state = "ACTIVE";     // optional
                                                // String
                                                // state determines whether the video is playable or not
                                                // Default value: ACTIVE
                                                // Allowed values: "ACTIVE", "INACTIVE"
            public string[] tags;   // optional
                                    // String[]
                                    // array of tags
                                    // Default value: []

            public Dictionary<string, string> custom_fields;   // optional
                                                               // Object
                                                               // map of fieldname-value pairs
                                                               // Default value: {}
            public GeoInfo geo;     // optional
                                    // Object
                                    // map of geo-filtering properties
                                    // Default value: {}

            public Dictionary<string, string> schedule; // optional
                                                        // Object
                                                        // map of scheduling properties
                                                        // Default value: {}

            //public string starts_at = null;   // optional
            // DateString
            // start date-time of availability in ISO-8601 format
            // Default value: null

            //public string ends_at = null;   // optional
            // DateString
            // end date-time of availability in ISO-8601 format
            // Default value: null

            public CVORequestBody()
            {
                tags = new string[] { };
                custom_fields = new Dictionary<string, string>();
                schedule = new Dictionary<string, string>();
            }
        }
        #endregion
    }
}
