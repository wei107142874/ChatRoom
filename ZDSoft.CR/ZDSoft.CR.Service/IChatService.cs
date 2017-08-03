using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZDSoft.CR.Domain;
using System.Data;

namespace ZDSoft.CR.Service
{
    public interface IChatService
    {
        int Insert(Chat chat);

        int GetRoomID_DeleteChat(int roomID);

        System.Data.DataSet Select_Chat(Chat ca);

        int GetRoomIDByChatCount(int roomID);

        Chat GetRoomIDByChat(int roomID);

        System.Data.DataSet GetrUserNameByChat(Chat ca);
    }
}
