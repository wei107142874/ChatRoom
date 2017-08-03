using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZDSoft.CR.Domain
{
    public class Chat
    {
        public int ChatContentID { get; set; }
        public string SendUserName { get; set; }
        public string ReceiveUserName { get; set; }
        public string SendDateTime { get; set; }
        public string MsgContent { get; set; }
        public int RoomID { get; set; }
    }
}
