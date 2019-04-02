using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaintenanceWebUtilityWebForm2
{
    public class SessionKey
    {
        private static string userId = "_userId";
        private static string username = "_username";

        public static string UserId { get => userId; }
        public static string Username { get => username; }
    }
}