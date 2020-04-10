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
using System.Json;


namespace BrightcoveAPI
{
    public class Helper
    {
        public static string strVideoIDNotValid = "Video ID is not valid.";
        public static string strAccountIDNotValid = "Account ID is not valid.";
        public static string strJSONNotValid = "JSON is not valid.";
        public static string strOAuthTokenNotValid = "OAuth token is not valid.";
        public static string strPlaylistIDNotValid = "Playlist ID is not valid.";
        public static string strPolicyKeyNotValid = "Policy Key is not valid.";

        /// <summary>
        /// Checks a String if it contains digits only.
        /// </summary>
        /// <returns><c>true</c>, if String contains digits only, <c>false</c> otherwise.</returns>
        /// <param name="str">String.</param>
        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the json.
        /// </summary>
        /// <returns><c>true</c>, if json was validated, <c>false</c> otherwise.</returns>
        /// <param name="strJsonString">String json string.</param>
        public static bool ValidateJSON( string strJsonString )
        {
            try
            {
                var tmpObj = JsonValue.Parse(strJsonString);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
