using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDSoft.CR.Service;
using ZDSoft.CR.Domain;
using ZDSoft.CR.Manager;
using System.Data;
using System.Data.SqlClient;

namespace ZDSoft.CR.Component
{
    public class RoomComponent : IRoomService
    {
        RoomManager manager = new RoomManager();
        UserManager usermanager = new UserManager();
        public UserInfo GetUserNameByUserID(string userName)
        {
            return manager.GetUserNameByUserID(userName);
        }
        //public DataSet GetUserIDByRoomInfo(int userID)
        //{
        //    return manager.GetUserIDByRoomInfo(userID);
        //}
        public int CreateRoom(RoomInfo room)
        {
            return manager.CreateRoom(room);
        }

        public RoomInfo UserIDrepetition(int userID)
        {
            return manager.UserIDrepetition(userID);
        }
        public DataSet RoomInfo()
        {
            return manager.RoomInfo();
        }
        public int Insert_UserIDRoomID(int userID, int roomID)
        {
            return manager.Insert_UserIDRoomID(userID, roomID);
        }

        public RoomUser Select_RoomUser(int userID)
        {
            return manager.Select_RoomUser(userID);
        }

        public bool Delete_RoomUser_Update_UserType(int userID, char userType)
        {
            bool rv = false;
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    //删除表中信息
                    manager.Delete_RoomUser(userID, trans);

                    //更新UserType='1'

                    usermanager.Update_UserTypeISone(userID, userType, trans);

                    trans.Commit();
                    rv = true;

                }
                catch (Exception ex)
                {
                    //发生错误，执行的回滚操作
                    trans.Rollback();
                }
            }
            //返回最后的执行状态
            return rv;
        }

        public RoomUser GetUserIDByRoomRoom(int userID)
        {
            return manager.GetUserIDByRoomRoom(userID);
        }


        public RoomUser GetUserIDRoomIDByRoomUser(int userID, int roomID)
        {
            return manager.GetUserIDRoomIDByRoomUser(userID, roomID);
        }


        public RoomInfo GetRoomIDByRoomInfo(int roomID)
        {
            return manager.GetRoomIDByRoomInfo(roomID);
        }


        public int Delete_RoomUser(int userID)
        {
            return manager.Delete_RoomUser(userID);
        }


        public RoomUser GetRoomIDByRoomUser(int roomID)
        {
            return manager.GetRoomIDByRoomUser(roomID);
        }


        public bool Delete_RoomInfo_Update_userType(int userID, char userType)
        {
            bool rv = false;
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    manager.GetUserIDDeleteRoomInfo(userID, trans);
                    usermanager.Update_UserType(userType, userID, trans);
                    trans.Commit();
                    rv = true;
                }
                catch (Exception ex)
                {
                    //发生错误，执行的回滚操作
                    trans.Rollback();
                }
            }
            return rv;
        }
        public int GetRoomIDByCount(int roomid)
        {
            return manager.GetRoomIDByCount(roomid);
        }


        public bool Update_RoomInfoUserID_Update_userType(int roomID, int userID, char userType)
        {
            bool rv = false;
            using (SqlConnection conn = SqlHelper.GetConnection())
            {
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    manager.Update_RoomInfoUserID(roomID, userID, trans);

                    usermanager.Update_UserTypeTrans(userID, userType, trans);

                    trans.Commit();

                    rv = true;
                }
                catch (Exception ex)
                {
                    //发生错误，执行的回滚操作
                    trans.Rollback();
                }
            }
            return rv;
        }


        public int GetRoomIDByRoomUserCount(int roomID)
        {
            return manager.GetRoomIDByRoomUserCount(roomID);
        }

        public int GetRoomIDUpdateRoomInfo(RoomInfo room)
        {
            return manager.GetRoomIDUpdateRoomInfo(room);
        }


        public RoomUser GetRoomIDUserIDByRoomUser(int roomID, int userID)
        {
            return manager.GetRoomIDUserIDByRoomUser(roomID, userID);
        }
    }
}

