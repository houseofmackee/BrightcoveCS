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
    public class Playback : Base
    {
        private bool myBoolIsIPRestricted = false;

        public bool IsIPRestricted
        {
            get { return myBoolIsIPRestricted; }
            private set { myBoolIsIPRestricted = value; }
        }

        public override string API_VERSION => "v1";
        public override string BaseURL => String.Format("https://{0}.api.brightcove.com/playback/{1}/accounts", (IsIPRestricted ? "edge-elb" : "edge"), API_VERSION);

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BrightcoveAPI.Playback"/> class.
        /// </summary>
        /// <param name="strAccountID">String account identifier.</param>
        /// <param name="strPolicyKey">String policy key.</param>
        /// <param name="isIPRestricted">If set to <c>true</c> account is IP restricted.</param>
        public Playback(string strAccountID, string strPolicyKey, bool isIPRestricted = false)
            : base(strAccountID, strPolicyKey)
                => IsIPRestricted = isIPRestricted;
        #endregion

        /// <summary>
        /// Executes the call.
        /// </summary>
        /// <returns>The call.</returns>
        /// <param name="strAPICall">String APIC all.</param>
        public string ExecuteCall(string strAPICall)
        {
            RestAPICall myCall = new RestAPICall();

            myCall.APICallURL = strAPICall;
            myCall.Method = Method.GET;
            myCall.Key = PolicyKey;

            return (myCall.Execute());
        }

        /// <summary>
        /// Gets the video.
        /// </summary>
        /// <returns>The video.</returns>
        /// <param name="strVideoID">String video identifier.</param>
        /// <param name="isRefID">If set to <c>true</c> is reference identifier.</param>
        public string GetVideo(string strVideoID, bool isRefID = false)
        {
			if (!isRefID)
			{
				if (!Helper.IsDigitsOnly(strVideoID))
				{
                    throw new BrightcoveAPIException(Helper.strVideoIDNotValid);
				}
			}
			return (ExecuteCall(String.Format("{0}/{1}/videos/{2}{3}", BaseURL, AccountID, (isRefID ? "ref:" : ""), strVideoID)));
        }

        /// <summary>
        /// Gets the videos.
        /// </summary>
        /// <returns>The videos.</returns>
        /// <param name="strSearchQuery">String search query.</param>
        public string GetVideos(string strSearchQuery) => (ExecuteCall(String.Format("{0}/{1}/videos?{2}", BaseURL, AccountID, strSearchQuery)));

        /// <summary>
        /// Gets the playlist.
        /// </summary>
        /// <returns>The playlist.</returns>
        /// <param name="strPlaylistID">String playlist identifier.</param>
        /// <param name="isRefID">If set to <c>true</c> is reference identifier.</param>
        public string GetPlaylist(string strPlaylistID, bool isRefID = false)
        {
            if(!isRefID)
            {
				if (!Helper.IsDigitsOnly(strPlaylistID))
				{
                    throw new BrightcoveAPIException(Helper.strPlaylistIDNotValid);
				}
			}
            return (ExecuteCall(String.Format("{0}/{1}/playlists/{2}{3}", BaseURL, AccountID, (isRefID ? "ref:" : ""), strPlaylistID)));
        }

    }
}
