using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemoteAction.Config
{
    public class AppConfigManger
    {
        private static AppConfig AppConfig;

        public static void Init(AppConfig appConfig)
        {
            AppConfig = appConfig;
        }

        public static AppConfig GetConfig()
        {
            return AppConfig;
        }
    }
}
