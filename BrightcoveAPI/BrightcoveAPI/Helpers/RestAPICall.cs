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
    public class RestAPICall
    {
        public string APICallURL = string.Empty;    // the API call URL
        public string APIKey = string.Empty;        // for Live API
        public string JSONBody = string.Empty;      // for calls that require JSON data
        public string Token = string.Empty;         // OAuth token for API calls
        public string Key = string.Empty;           // Policy Key for Playback API calls
        public Method Method = Method.GET;          // call method

        public void Clear()
        {
            APICallURL = string.Empty;
            APIKey = string.Empty;
            JSONBody = string.Empty;
            Token = string.Empty;
            Key = string.Empty;
            Method = Method.GET;
        }

        public string Execute()
        {
            if (APICallURL != string.Empty)
            {
                var client = new RestClient(APICallURL);
                var request = new RestRequest();
                request.Parameters.Clear();

                request.Method = Method;

                request.AddHeader("Content-type", "application/json");

                if (Token != string.Empty)
                {
                    request.AddParameter("Authorization", "Bearer " + Token, ParameterType.HttpHeader);
                }

                if( APIKey != string.Empty )
                {
                    request.AddHeader("X-API-KEY", APIKey);
                }

                if (Key != string.Empty)
                {
                    request.AddHeader("Accept", String.Format("application/json;pk={0}", Key));
                }

                // if there was a JSON body then set it
                if (JSONBody != string.Empty)
                {
                    if (!Helper.ValidateJSON(JSONBody))
                    {
                        throw new Base.BrightcoveAPIException(Helper.strJSONNotValid);
                    }
                    request.AddParameter("application/json", JSONBody, ParameterType.RequestBody);
                }

                IRestResponse apiresponse = client.Execute(request);

                return (apiresponse.Content);
            }
            return (string.Empty);
        }
    }
}
