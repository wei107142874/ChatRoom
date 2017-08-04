using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ZDSoft.CR.Domain;

namespace ZDSoft.CR.Service
{
   public interface IRoomService
    {

       UserInfo GetUserNameByUserID(string userName);


       //DataSet GetUserIDByRoomInfo(int userID);

       int CreateRoom(RoomInfo room);


       RoomInfo UserIDrepetition(int userID);

       DataSet RoomInfo();

       int Insert_UserIDRoomID(int userID, int roomID);

       RoomUser Select_RoomUser(int userID);

       bool Delete_RoomUser_Update_UserType(int userID,char userType);

       RoomUser GetUserIDByRoomRoom(int userID);

       RoomUser GetUserIDRoomIDByRoomUser(int userID, int roomID);

       RoomInfo GetRoomIDByRoomInfo(int roomID);

       int Delete_RoomUser(int userID);

       RoomUser GetRoomIDByRoomUser(int roomID);

       bool Delete_RoomInfo_Update_userType(int userID, char userType);
       int GetRoomIDByCount(int roomid);

       bool Update_RoomInfoUserID_Update_userType(int roomID,int userID, char userType);

       int GetRoomIDByRoomUserCount(int roomID);

       int GetRoomIDUpdateRoomInfo(RoomInfo room);

       RoomUser GetRoomIDUserIDByRoomUser(int roomID, int userID);
        List<RoomUser> GetRUByRoomId(int roomId);
    }
}
