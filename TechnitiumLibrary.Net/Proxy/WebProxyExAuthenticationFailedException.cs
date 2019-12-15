﻿/*
Technitium Library
Copyright (C) 2019  Shreyas Zare (shreyas@technitium.com)

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.

*/

using System;

namespace TechnitiumLibrary.Net.Proxy
{
    public class WebProxyExAuthenticationFailedException : NetProxyAuthenticationFailedException
    {
        #region constructors

        public WebProxyExAuthenticationFailedException()
            : base()
        { }

        public WebProxyExAuthenticationFailedException(string message)
            : base(message)
        { }

        public WebProxyExAuthenticationFailedException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected WebProxyExAuthenticationFailedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }
}