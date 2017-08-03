using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDSoft.CR.Domain;
using System.Data;
using System.Data.SqlClient;

namespace ZDSoft.CR.Manager
{
   public class RoomManager
    {

       public RoomUser roomUser(SqlDataReader reader)
       {
           RoomUser ru=new RoomUser();
           while(reader.Read())
           {
               ru.RoomID=Convert.ToInt32(reader["RoomID"]);
               ru.RoomUserID = Convert.ToInt32(reader["RoomUserID"]);
               ru.UserID = Convert.ToInt32(reader["UserID"]);
           }
           return ru;
       }
       public UserInfo GetUserNameByUserID(string userName)
        {
            string sql = "sp_GetUserNameByUserID";

            SqlParameter[] sqlParameter = new SqlParameter[]{
                new SqlParameter("@UserName",userName)
            };
            UserInfo user=null;

            using (SqlDataReader reder = SqlHelper.GetDataReader(CommandType.StoredProcedure, sql, sqlParameter))
            {
                while (reder.Read())
                {
                    user = new UserInfo();
                    user.UserID =Convert.ToInt32(reder["UserID"]);
                }
            }
            return user;
        }

       //public DataSet GetUserIDByRoomInfo(int userID)
       //{
       //    string sql = "sp_GetUserIDByRoomInfo";

       //    SqlParameter[] sqlParameter = new SqlParameter[]{
       //        new SqlParameter("@UserID",userID),
       //    };
       //    return SqlHelper.Fill(CommandType.StoredProcedure, sql, sqlParameter);
       //}

       public int CreateRoom(RoomInfo room)
       {
           string sql = "sp_CreateRoom";

           SqlParameter[] sqlParameter = new SqlParameter[]{
               new SqlParameter("@RoomName",room.RoomName),
               new SqlParameter("@RommDesc",room.RommDesc),
               new SqlParameter("@UserID",room.UserID)
           };

           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,sql,sqlParameter);
       }

       public RoomInfo Room(SqlDataReader reader)
       {
           RoomInfo room = new RoomInfo();
           room.UserID =Convert.ToInt32(reader["UserID"]);
           room.RoomID = Convert.ToInt32(reader["RoomID"]);
           room.RoomName = reader["RoomName"].ToString();
           room.RommDesc = reader["RommDesc"].ToString();
           return room;
       }
       public RoomInfo UserIDrepetition(int userID)
       {
           string sql = "sp_UserIDrepetition";

           SqlParameter[] sqlParameter = new SqlParameter[]{
              
               new SqlParameter("@UserID",userID)
           };
           RoomInfo room = null;
           using (SqlDataReader reader=SqlHelper.GetDataReader(CommandType.StoredProcedure,sql,sqlParameter))
           {
               while(reader.Read())
               {
                   room = Room(reader);
               }
           }
           return room;
       }
       public DataSet RoomInfo()
       {
           return SqlHelper.Fill(CommandType.Text,"select * from RoomInfo");
       }

       public int Insert_UserIDRoomID(int userID, int roomID)
       {
           string sql = "sp_Insert_UserIDRoomID";

           SqlParameter[] sqlParameter = new SqlParameter[]
           {
               new SqlParameter("@UserID",userID),
               new SqlParameter("@RoomID",roomID),
               new SqlParameter("@GOtoRoomDate",DateTime.Now)
           };
           return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, sql, sqlParameter);
       }

       public RoomUser Select_RoomUser(int userID)
       {
           string sql = string.Format("select * from RoomUser where UserID={0}",userID);

           RoomUser ru = null;
           using (SqlDataReader reader = SqlHelper.GetDataReader(CommandType.Text, sql))
           {
               while(reader.Read())
               {
                   ru = roomUser(reader);
               }
           }
           return ru;
       }

       public int Delete_RoomUser(int userID, SqlTransaction trans)
       {
           string sql = string.Format("Delete RoomUser where UserID={0}", userID);

           return SqlHelper.ExecuteNonQuery(CommandType.Text, sql);
       }

       public RoomUser RoomUsers(SqlDataReader reader)
       {
           RoomUser ru = new RoomUser();
          
               ru.RoomID =Convert.ToInt32(reader["RoomID"]);
               ru.RoomUserID = Convert.ToInt32(reader["RoomUserID"]);
               ru.UserID = Convert.ToInt32(reader["UserID"]);
               ru.GOtoRoomDate = reader["GOtoRoomDate"].ToString();
           return ru;
       }
       public RoomUser GetUserIDByRoomRoom(int userID)
       {
           string sql = string.Format("Select * from RoomUser Where UserID={0}", userID);

           RoomUser ru = null;
           using(SqlDataReader reader=SqlHelper.GetDataReader(CommandType.Text,sql)){
               while (reader.Read())
               {
                   ru = new RoomUser();
                   ru.RoomID =Convert.ToInt32(reader["RoomID"]);
               }
           }
           return ru;
       }

       public RoomUser GetUserIDRoomIDByRoomUser(int userID, int roomID)
       {
           string sql = string.Format("Select * from RoomUser Where UserID={0} and RoomID={1}", userID,roomID);

           RoomUser ru = null;
           using (SqlDataReader reader = SqlHelper.GetDataReader(CommandType.Text, sql))
           {
               while (reader.Read())
               {
                   ru = new RoomUser();
                   ru = RoomUsers(reader);
               }
           }
           return ru;
       }

       public RoomInfo GetRoomIDByRoomInfo(int roomID)
       {
           string sql = string.Format("Select * from RoomInfo Where RoomID={0}", roomID);

           RoomInfo room = null;
           using (SqlDataReader reader = SqlHelper.GetDataReader(CommandType.Text, sql))
           {
               while (reader.Read())
               {
                   room = new RoomInfo();
                   room = Room(reader);
               }
           }
           return room;
       }

       public int Delete_RoomUser(int userID)
       {
           string sql = string.Format("Delete RoomUser where UserID={0}", userID);

           return SqlHelper.ExecuteNonQuery(CommandType.Text, sql);
       }

       public RoomUser GetRoomIDByRoomUser(int roomID)
       {
           string sql = string.Format("Select * from RoomUser Where RoomID={0}", roomID);

           RoomUser ru = null;
           using (SqlDataReader reader = SqlHelper.GetDataReader(CommandType.Text, sql))
           {
               while (reader.Read())
               {
                   ru = new RoomUser();
                   ru = RoomUsers(reader);
               }
           }
           return ru;
       }

       public void GetUserIDDeleteRoomInfo(int userID, SqlTransaction trans)
       {
           string sql = string.Format("Delete RoomInfo where UserID={0}", userID);

           SqlHelper.ExecuteNonQuery(CommandType.Text, sql);
       }

       public int GetRoomIDByCount(int roomid)
       {
          string sql = string.Format("select count(*) from RoomUser where RoomID={0}", roomid);
          int count =SqlHelper.Count(CommandType.Text, sql);
          return count;
       }

       public void Update_RoomInfoUserID(int roomID, int userID, SqlTransaction trans)
       {
           string sql = string.Format("update RoomInfo  SET  UserID={0} Where RoomID={1}", userID,roomID);
           SqlHelper.ExecuteNonQuery(CommandType.Text, sql);
       }

       public int GetRoomIDByRoomUserCount(int roomID)
       {
           string sql =string.Format("Select count(*) from RoomUser Where RoomID={0}",roomID);
           return SqlHelper.Count(CommandType.Text, sql);
       }

       public int GetRoomIDUpdateRoomInfo(RoomInfo room)
       {
           string sql = "sp_GetRoomIDUpdateRoomInfo";

           SqlParameter[] sqlParameter = new SqlParameter[]{
               new SqlParameter("@RoomName",room.RoomName),
               new SqlParameter("@RommDesc",room.RommDesc),
               new SqlParameter("@UserID",room.UserID)
           };
           int rv = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, sql, sqlParameter);
           return rv;
       }

       public RoomUser GetRoomIDUserIDByRoomUser(int roomID, int userID)
       {
           string sql = string.Format("Select * from RoomUser Where RoomID={0} and UserID={1}", roomID,userID);

           RoomUser ru = null;
           using (SqlDataReader reader = SqlHelper.GetDataReader(CommandType.Text, sql))
           {
               while (reader.Read())
               {
                   ru = new RoomUser();
                   ru = RoomUsers(reader);
               }
           }
           return ru;
       }
    }
}
