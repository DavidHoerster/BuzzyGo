using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace BuzzyGo.Utilities
{
    public static class ConnectionStringHelper
    {
        public static String GetCQRSConnectionString()
        {
            String connString = RoleEnvironment.GetConfigurationSettingValue("BuzzyQuerySideConnectionString");

            if (String.IsNullOrWhiteSpace(connString))
            {
                //check configuration file
                connString = ConfigurationManager.ConnectionStrings["BuzzyQuerySideConnectionString"].ConnectionString;
            }

            return connString;
        }

        public static String GetEventStoreConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[""].ConnectionString;
        }

    }
}
