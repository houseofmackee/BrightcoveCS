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
    public class SSAI
    {
        [Serializable()]
        public class SSAIAPIException : Exception
        {
            public SSAIAPIException() : base() { }
            public SSAIAPIException(string message) : base(message) { }
            public SSAIAPIException(string message, System.Exception inner) : base(message, inner) { }

            // A constructor is needed for serialization when an
            // exception propagates from a remoting server to the client. 
            protected SSAIAPIException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            { }
        }

        public const string API_VERSION = "v1";
        private string myStrAccountID = string.Empty;
        private OAuthToken myOAuthToken = null;


        private OAuthToken Token
        {
            get { return myOAuthToken; }
            set
            {
                if (value is OAuthToken)
                {
                    myOAuthToken = value;
                }
                else
                {
                    throw new SSAIAPIException(Helper.strOAuthTokenNotValid);
                }
            }
        }

        public string AccountID
        {
            get { return myStrAccountID; }
            private set
            {
                if (Helper.IsDigitsOnly(value))
                {
                    myStrAccountID = value;
                }
                else
                {
                    throw new SSAIAPIException(Helper.strAccountIDNotValid);
                }
            }
        }

        public string BaseURL => String.Format("https://ssai.api.brightcove.com/{0}/accounts", API_VERSION);

		#region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BrightcoveAPI.SSAI"/> class.
        /// </summary>
        /// <param name="oauthToken">Oauth token.</param>
        /// <param name="strAccountID">String account identifier.</param>
		public SSAI(OAuthToken oauthToken, string strAccountID)
		{
			AccountID = strAccountID;
			Token = oauthToken;
		}
		#endregion

        public string ExecuteCall()
        {
            return "";
        }

        public string ListAdConfigurations()
        {
            return (ExecuteCall());
        }

        public string GetAdConfiguration()
        {

			return (ExecuteCall());
		}

        public string CreateAdConfiguration()
        {
			return (ExecuteCall());
		}
	}
}
