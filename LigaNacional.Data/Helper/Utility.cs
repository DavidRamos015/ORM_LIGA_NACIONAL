using System;

namespace LigaNacional.Data.Helper
{
    public class Utility
    {
        public static bool RemoteConnection = true;// en false se conectara localmente caso contrario al servidor remoto
        public static bool UseSqlServerDb = false; // en false usara  MySql, en true usara SQLServer

        public static string MsjNeedToLogin = "It requires a login to use this functionality.";

        public static string AplicationName = "LigaNacional";
        public static string UrlAplication = "http://" + AplicationName + ".apphb.com";
        
        public static string ConnectionString
        {
            get
            {
                var connection = RemoteConnection ? "LigaNacional.Remote" : "LigaNacional.Local";
                var dbms = UseSqlServerDb ? ".MSSQL" : ".MySQL";

                return connection + dbms;
            }
        }

        public static string UrlWebApi()
        {
            var url = RemoteConnection ? "\'http://liganacional.apphb.com/api/v1/\'" : "\'http://localhost:6490/api/v1/\'";
            return url;

        }

        public static DateTime ServerDate()
        {
            return DateTime.Now;
        }


    }
}
