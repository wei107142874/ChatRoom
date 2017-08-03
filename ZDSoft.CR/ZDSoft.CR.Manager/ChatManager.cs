using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ZDSoft.CR.Domain;

namespace ZDSoft.CR.Manager
{
   public  class ChatManager
    {

       public Chat Select(SqlDataReader reader)
       {
           Chat ca = new Chat();
           ca.ChatContentID =Convert.ToInt32(reader["ChatContentID"]);
           ca.RoomID = Convert.ToInt32(reader["RoomID"]);
           ca.MsgContent = reader["MsgContent"].ToString();
           ca.ReceiveUserName = reader["ReceiveUserName"].ToString();
           ca.SendDateTime = reader["SendDateTime"].ToString();
           ca.SendUserName = reader["SendUserName"].ToString();

           return ca;
       }
        public int Insert(Domain.Chat chat)
        {
            string sql = "sp_InsertChat";

            SqlParameter[] sqlParameter = new SqlParameter[]{
                new SqlParameter("@MsgContent",chat.MsgContent),
                new SqlParameter("@ReceiveUserName",chat.ReceiveUserName),
                new SqlParameter("@RoomID",chat.RoomID),
                new SqlParameter("@SendDateTime",chat.SendDateTime),
                new SqlParameter("@SendUserName",chat.SendUserName),
            };
          return  SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, sql, sqlParameter);
        }


        public int GetRoomID_DeleteChat(int roomID)
        {
            string sql = string.Format("Delete ChatContent Where roomID={0}", roomID);
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql);
        }

        public DataSet Select_Chat(Chat ca)
        {
            string sql = string.Format("select *  from ChatContent Where RoomID={0}", ca.RoomID);
            return SqlHelper.Fill(CommandType.Text, sql);
        }

        public int GetRoomIDByChatCount(int roomID)
        {
            string sql = string.Format("Select Count(*) from ChatContent", roomID);
            return SqlHelper.Count(CommandType.Text, sql);
        }

        public Chat GetRoomIDByChat(int roomID)
        {
            string sql = string.Format("select *  from ChatContent Where RoomID={0}", roomID);

            Chat ca = null;
            using (SqlDataReader reader = SqlHelper.GetDataReader(CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    ca = Select(reader);
                }
            }
            return ca;
        }

        public DataSet GetrUserNameByChat(Chat ca)
        {
            string sql = string.Format("select *  from ChatContent Where RoomID={0}", ca.RoomID);
            return SqlHelper.Fill(CommandType.Text, sql);
        }
    }
}
