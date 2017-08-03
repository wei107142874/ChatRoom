using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZDSoft.CR.Domain;

namespace ZDSoft.CR.Helpers
{
    public class AppHelper
    {
        public static UserInfo LoginedUser
        {
            get
            {
                UserInfo LoginedUser = HttpContext.Current.Session["User"] as UserInfo;
                return LoginedUser;
            }
            set
            {
                //保存登录信息
                HttpContext.Current.Session["user"] = value;
            }
        }
    }
}