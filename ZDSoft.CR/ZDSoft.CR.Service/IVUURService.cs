using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDSoft.CR.Domain;

namespace ZDSoft.CR.Service
{
    public interface IVUURService
    {
        VUUR GetRoomIDByVUUR(int roomID);

        VUUR Select_MinRoomUserID(int roomID);

        int GetRoomUserID_Update_userType(int roomuserID, char userType);

        VUUR GetRoomID_Select__VUUR(int roomID);

        IList<VUUR> GetVUURByRoomId(int roomId);
    }
}
