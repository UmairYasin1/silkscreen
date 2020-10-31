using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaroonPOSWeb.Common
{
    public class Enum
    {
        public static class UserType
        {
            public static string Admin = "Adm";
            public static string WebUser = "WebUsr";
        }

        public static class UserRoleSetup
        {
            public static bool IsAdd = true;
            public static bool IsEdit = true;
            public static bool IsDelete = true;
            public static bool IsSelect = true;
        }
    }
}