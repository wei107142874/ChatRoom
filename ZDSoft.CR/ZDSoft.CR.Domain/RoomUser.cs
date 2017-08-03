using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZDSoft.CR.Domain
{
   public class RoomUser
    {
       public int RoomUserID { get; set; }
       public int UserID { get; set; }
       public int RoomID { get; set; }
       public string GOtoRoomDate { get; set; }
    }
}
