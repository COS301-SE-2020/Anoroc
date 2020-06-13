﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AnorocMobileApp.Models
{
    public class Constants
    {
        /*public static bool IsDev = true;
        public static readonly string GoogleClientID = "googleID on google project .apps.googleusercontent.com";
        public static readonly string GoogleClientSecret = "google secret on google project";
       
        public static readonly string FacebookAppID = "985395151878298";*/
        public static readonly string googleAPIKey = "//KEY HERE//";
        public static readonly string clientID = $"{googleAPIKey}.apps.googleusercontent.com";
        public static readonly string redirectUrl = $"com.googleusercontent.apps.{googleAPIKey}:/oauth2redirect";
    }

}
