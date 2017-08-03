using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDSoft.CR.Domain;

namespace ZDSoft.CR.Service
{
    public interface IUserService
    {

        int User_Registered(UserInfo user);

        UserInfo GetUserNameByUserInfo(string userName);

        UserInfo GetUser(string userName, string password);

        int User_LoginDate(UserInfo user);

        int User_ZhuxiaoDate(UserInfo user);

        UserInfo Select_LoginDate(UserInfo loginUser);

        int Update_UserTypeIStwo(char userType,int userID);

        UserInfo GetUserIDByUserInfo(int userID);


        int Update_UserType(int userID, char userType);

        UserInfo GetUserTypeByUserInfo(char userType);
    }
}
