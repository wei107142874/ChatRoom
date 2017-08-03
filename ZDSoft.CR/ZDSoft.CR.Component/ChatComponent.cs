using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDSoft.CR.Domain;
using ZDSoft.CR.Manager;
using ZDSoft.CR.Service;
using System.Data;

namespace ZDSoft.CR.Component
{
   public class ChatComponent :IChatService
    {
       ChatManager chatManager = new ChatManager();
        public int Insert(Chat chat)
        {
            return chatManager.Insert(chat);
        }
       

        public int GetRoomID_DeleteChat(int roomID)
        {
            return chatManager.GetRoomID_DeleteChat(roomID);
        }


        public DataSet Select_Chat(Chat ca)
        {
            return chatManager.Select_Chat(ca);
        }

        public int GetRoomIDByChatCount(int roomID)
        {
            return chatManager.GetRoomIDByChatCount(roomID);
        }

        public Chat GetRoomIDByChat(int roomID)
        {
            return chatManager.GetRoomIDByChat(roomID);
        }


        public DataSet GetrUserNameByChat(Chat ca)
        {
            return chatManager.GetrUserNameByChat(ca);
        }
    }
}
