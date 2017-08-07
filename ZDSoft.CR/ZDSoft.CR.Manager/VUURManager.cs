using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDSoft.CR.Domain;
using System.Data;
using System.Data.SqlClient;

namespace ZDSoft.CR.Manager
{
   public class VUURManager
    {
       public VUUR VUURs(SqlDataReader reader)
       {
           VUUR vr = new VUUR();
           vr.NickName = reader["NickName"].ToString();
           vr.RoomID = Convert.ToInt32(reader["RoomID"]);
           vr.RoomUserID = Convert.ToInt32(reader["RoomUserID"]);
           vr.UserID = Convert.ToInt32(reader["UserID"]);
           vr.UserName = reader["UserName"].ToString();
           vr.UserType =Convert.ToChar(reader["UserType"]);
           return vr;
       }
        public VUUR GetRoomIDByVUUR(int roomID)
        {
            string sql = string.Format("select * from VUUR Where RoomID={0} and UserType={1}", roomID,'4');

            VUUR vr = null;
            using (SqlDataReader reader = SqlHelper.GetDataReader(CommandType.Text, sql))
            {
                while(reader.Read())
                {
                    vr = new VUUR();
                    vr = VUURs(reader);
                }
            }
            return vr;
        }

        public IList<VUUR> GetVUURByRoomId(int roomID)
        {
            string sql = string.Format("select * from VUUR Where RoomID={0}", roomID);

            IList<VUUR> vrList =new  List<VUUR>();
            using (SqlDataReader reader = SqlHelper.GetDataReader(CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    VUUR vr = new VUUR();
                    vr = new VUUR();
                    vr = VUURs(reader);
                    vrList.Add(vr);
                }
            }
            return vrList;
        }

        public VUUR Select_MinRoomUserID(int roomID)
        {
            string sql = string.Format("select top(1) * from VUUR Where RoomID={0} and UserType!='3' and UserType!='4' order  by RoomUserID asc", roomID);

            VUUR vr = null;
            using(SqlDataReader reader=SqlHelper.GetDataReader(CommandType.Text,sql))
            {
                while(reader.Read())
                {
                    vr = new VUUR();
                    vr = VUURs(reader);
                }
            }
            return vr;
        }

        public int GetRoomUserID_Update_userType(int roomuserID, char userType)
        {
            string sql = string.Format("Update VUUR set UserType={0} where RoomUserID={1}", userType, roomuserID);
            int rv = SqlHelper.ExecuteNonQuery(CommandType.Text, sql);
            return rv;
        }

        public VUUR GetRoomID_Select__VUUR(int roomID)
        {
            string sql = string.Format("select * from VUUR Where RoomID={0}", roomID);

            VUUR vr = null;
            using (SqlDataReader reader = SqlHelper.GetDataReader(CommandType.Text, sql))
            {
                while (reader.Read())
                {
                    vr = new VUUR();
                    vr = VUURs(reader);
                }
            }
            return vr;
        }
    }
}
