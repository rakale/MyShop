﻿using Abc.Aids.Logging;
using System;
using System.Net;

namespace Abc.Aids.Services {

    public static class WebService {

        public static string Load(string url) {
            var num = 0;

            while (num <= 3) {
                num++;
                using var client = new WebClient();

                try { return client.DownloadString(url); } catch (Exception e) { Log.Exception(e); }
            }

            return string.Empty;
        }

    }

}