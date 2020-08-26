using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IvyTalk.AspNet;

namespace IvyTalk.AspNetFramework.Test
{
    public static class Startup
    {
        public static void Register(HttpConfiguration config)
        {
            config.JsonSerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss.fff";
        }
    }
}