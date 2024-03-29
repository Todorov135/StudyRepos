﻿using System;
using Telephony.Models.Interface;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowseable
    {
        public string BrowseURL(string url)
        {
            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            return $"Calling... {number}";
        }
    }
}
