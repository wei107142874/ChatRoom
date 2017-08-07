using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDSoft.CR.Domain;
using ZDSoft.CR.Manager;
using ZDSoft.CR.Service;

namespace ZDSoft.CR.Component
{
   public class VUURComponent:IVUURService
    {
       VUURManager manager = new VUURManager();
       public VUUR GetRoomIDByVUUR(int roomID)
        {
            return manager.GetRoomIDByVUUR(roomID);
        }


       public VUUR Select_MinRoomUserID(int roomID)
       {
           return manager.Select_MinRoomUserID(roomID);
       }


       public int GetRoomUserID_Update_userType(int roomuserID, char userType)
       {
           return manager.GetRoomUserID_Update_userType(roomuserID, userType);
       }


       public VUUR GetRoomID_Select__VUUR(int roomID)
       {
           return manager.GetRoomID_Select__VUUR(roomID);
       }

        public IList<VUUR> GetVUURByRoomId(int roomId)
        {
            return manager.GetVUURByRoomId(roomId);
        }
    }
}
