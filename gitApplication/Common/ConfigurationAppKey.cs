using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gitApplication.Common
{
    public static class ConfigurationAppKey
    {
        public static string ApiUrl = System.Configuration.ConfigurationManager.AppSettings["ApiUrl"] ?? string.Empty ;

    }
}