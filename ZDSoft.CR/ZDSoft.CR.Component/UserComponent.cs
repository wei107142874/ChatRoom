using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDSoft.CR.Manager;
using ZDSoft.CR.Service;
using ZDSoft.CR.Domain;

namespace ZDSoft.CR.Component
{
    public class UserComponent :IUserService
    {
        UserManager manager = new UserManager();
        public int User_Registered(UserInfo user)
        {
            return manager.User_Registered(user);
        }

        public UserInfo GetUserNameByUserInfo(string userName)
        {
            return manager.GetUserNameByUserInfo(userName);
        }

        public UserInfo GetUser(string userName, string password)
        {
            return manager.GetUser(userName, password);
        }
        public int User_LoginDate(UserInfo user)
        {
            return manager.User_LoginDate(user);
        }
        public int User_ZhuxiaoDate(UserInfo user)
        {
            return manager.User_ZhuxiaoDate(user);
        }
        public UserInfo Select_LoginDate(UserInfo loginUser)
        {
            return manager.Select_LoginDate(loginUser);
        }

        public int Update_UserTypeIStwo(char userType,int userID)
        {
            return manager.Update_UserTypeIStwo(userType,userID);
        }

        public UserInfo GetUserIDByUserInfo(int userID)
        {
            return manager.GetUserIDByUserInfo(userID);
        }


        public int Update_UserType(int userID, char userType)
        {
            return manager.Update_UserType(userID, userType);
        }


        public UserInfo GetUserTypeByUserInfo(char userType)
        {
            return manager.GetUserTypeByUserInfo(userType);
        }
    }
}
