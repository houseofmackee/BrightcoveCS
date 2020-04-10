/*
<<<<<<< HEAD
 * Copyright (c) 2018 MacKenzie Glanzer @HouseOfMackee
=======
 * Copyright (c) 2020 MacKenzie Glanzer @HouseOfMackee
>>>>>>> 73c0eac... Information housekeeping
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

namespace BrightcoveAPI
{
    public partial class CMS : Base
	{
		public override string API_VERSION => "v1";
        public override string BaseURL => String.Format("https://cms.api.brightcove.com/{0}/accounts", API_VERSION);

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BrightcoveAPI.CMS"/> class.
        /// </summary>
        /// <param name="theToken">The token.</param>
        /// <param name="strAccountID">String account identifier.</param>
        public CMS(OAuthToken theToken, string strAccountID) : base( theToken, strAccountID ) { }
		#endregion
	}
}
