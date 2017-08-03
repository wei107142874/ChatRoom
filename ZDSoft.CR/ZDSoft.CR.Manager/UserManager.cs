using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ZDSoft.CR.Domain;
namespace ZDSoft.CR.Manager
{
    public class UserManager
    {
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int User_Registered(Domain.UserInfo user)
        {
            string sql = "[sp_Registered]";
            SqlParameter[] sqlParameter = new SqlParameter[]{
                new SqlParameter("@UserName",user.UserName),
                new SqlParameter("@Password",user.Password),
                new SqlParameter("@NickName",user.NickName),
                new SqlParameter("@HeadUrl",user.HeadUrl),
                new SqlParameter("@RegisteredDate",user.RegisteredDate),
            };
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, sql, sqlParameter);
        }

        public UserInfo Set(SqlDataReader reader)
        {
            UserInfo user = new UserInfo();
            user.UserName = reader["UserName"].ToString();
            user.Password = reader["Password"].ToString();
            user.LoginDate = reader["LoginDate"].ToString();
            user.UserID = Convert.ToInt32(reader["UserID"]);
            user.HeadUrl = reader["HeadUrl"].ToString();
            user.NickName = reader["NickName"].ToString();
            user.UserType = Convert.ToChar(reader["UserType"]);
            return user;
        }

        /// <summary>
        /// 根据用户名判断注册时用户名是否重复
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public UserInfo GetUserNameByUserInfo(string userName)
        {
            string sql = "[sp_GetUserNameByUserInfo]";
            SqlParameter[] sqlParameter = new SqlParameter[]{
                new SqlParameter("@UserName",userName),
            };

            UserInfo user = new UserInfo();
            user = null;
            using (SqlDataReader reader = SqlHelper.GetDataReader(CommandType.StoredProcedure, sql, sqlParameter))
            {
                while (reader.Read())
                {
                    user = Set(reader);
                }
            }
            return user;
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserInfo GetUser(string userName, string password)
        {
            string sql = "[sp_Login]";
            SqlParameter[] sqlParameter = new SqlParameter[]{
                new SqlParameter("@UserName",userName),
                new SqlParameter("@Password",password)
            };

            UserInfo user = null;
            using (SqlDataReader reader = SqlHelper.GetDataReader(CommandType.StoredProcedure, sql, sqlParameter))
            {
                while (reader.Read())
                {
                    user = new UserInfo();
                    user.UserName = reader["UserName"].ToString();
                    user.Password = reader["Password"].ToString();
                    user.UserID = Convert.ToInt32(reader["UserID"]);
                    user.NickName = reader["NickName"].ToString();
                    user.UserType = Convert.ToChar(reader["UserType"]);
                }
            }
            return user;
        }
        /// <summary>
        /// 更新登录时间
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int User_LoginDate(UserInfo user)
        {
            string sql = "sp_UpdateUser_LoginDate";
            SqlParameter[] sqlParameter = new SqlParameter[]{
                new SqlParameter("@LoginDate",user.LoginDate),
                new SqlParameter("@UserID",user.UserID),
                new SqlParameter("@UserType",user.UserType)
            };
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, sql, sqlParameter);
        }

        /// <summary>
        /// 更新注销时间
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int User_ZhuxiaoDate(UserInfo user)
        {
            string sql = "sp_UpdateUser_ZhuxiaoDate";

            SqlParameter[] sqlParameter = new SqlParameter[]{
                new SqlParameter("@ZhuxiaoDate",DateTime.Now),
                new SqlParameter("@UserID",user.UserID),
                new SqlParameter("@UserType",'0')
            };
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, sql, sqlParameter);
        }
        public UserInfo Select_LoginDate(UserInfo loginUser)
        {
            string sql = string.Format("select * from UserInfo where UserID={0}", loginUser.UserID);

            loginUser = null;
            using (SqlDataReader reader = SqlHelper.GetDataReader(CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    loginUser = new UserInfo();
                    loginUser = Set(reader);
                }
            }
            return loginUser;
        }

        /// <summary>
        /// 更新userType=2
        /// </summary>
        /// <param name="userType"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int Update_UserTypeIStwo(char userType, int userID)
        {
            string sql = string.Format("update UserInfo  SET  UserType={0} Where UserID={1}", userType, userID);
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql);
        }

        /// <summary>
        /// 更新userType=1
        /// </summary>
        /// <param name="userType"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public void Update_UserTypeISone(int userID, char userType, SqlTransaction trans)
        {
            string sql = string.Format("update UserInfo  SET  UserType={0} Where UserID={1}", userType, userID);
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql);
        }

        public UserInfo GetUserIDByUserInfo(int userID)
        {
            string sql = string.Format("select * from UserInfo where UserID={0}", userID);

            UserInfo user = null;
            using (SqlDataReader reader = SqlHelper.GetDataReader(CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    user = new UserInfo();
                    user = Set(reader);
                }
            }
            return user;
        }

        public void Update_UserType(char userType, int userID, SqlTransaction trans)
        {
            string sql = string.Format("update UserInfo  SET  UserType={0} Where UserID={1}", userType, userID);
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql);
        }

        public int Update_UserType(int userID, char userType)
        {
            string sql = string.Format("update UserInfo  SET  UserType={0} Where UserID={1}", userType, userID);
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql);
        }

        public void Update_UserTypeTrans(int userID, char userType, SqlTransaction trans)
        {
            string sql = string.Format("update UserInfo  SET  UserType={0} Where UserID={1}", userType, userID);
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql);
        }

        public UserInfo GetUserTypeByUserInfo(char userType)
        {
            string sql = string.Format("Select * from UserInfo where UserType={0}", userType);
            UserInfo user = null;
            using (SqlDataReader reader = SqlHelper.GetDataReader(CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    user = new UserInfo();
                    user = Set(reader);
                }
            }
            return user;
        }
    }
}
