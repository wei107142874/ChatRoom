using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using ZDSoft.CR.Domain;

namespace ZDSoft.CR.Hubs
{
    [HubName("ChatHub")]
    public class ChatHub : Hub
    {
        public static List<UserInfo> users = new List<UserInfo>();

        //发送消息  
        public void SendMessage(string connectionId, string message)
        {
            //Clients.All.hello();
            var user = users.Where(s => s.ConnectionID == connectionId).FirstOrDefault(); 
            if (user != null)
            {
                Clients.Client(connectionId).addMessage(message + "" + DateTime.Now, Context.ConnectionId);
                //给自己发送，把用户的ID传给自己  
                Clients.Client(Context.ConnectionId).addMessage(message + "" + DateTime.Now, connectionId);
            }
            else
            {
                Clients.Client(Context.ConnectionId).showMessage("该用户已离线");
            }
        }
        [HubMethodName("getName")]
        public void GetName(string name)
        {
            //查询用户  
            var user = users.SingleOrDefault(u => u.ConnectionID == Context.ConnectionId);
            if (user != null)
            {
                user.UserName = name;
                Clients.Client(Context.ConnectionId).showId(Context.ConnectionId);
            }
            GetUsers();
        }

        /// <summary>  
        /// 重写连接事件  
        /// </summary>  
        /// <returns></returns>  
        public override Task OnConnected()
        {
            //查询用户  
            var user = users.Where(w => w.ConnectionID == Context.ConnectionId).SingleOrDefault();
            //判断用户是否存在，否则添加集合  
            if (user == null)
            {
                user = new UserInfo("", Context.ConnectionId);
                users.Add(user);
            }
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            var user = users.Where(p => p.ConnectionID == Context.ConnectionId).FirstOrDefault();
            //判断用户是否存在，存在则删除  
            if (user != null)
            {
                //删除用户  
                users.Remove(user);
            }
            GetUsers();//获取所有用户的列表  
            return base.OnDisconnected(stopCalled);
        }
        //获取所有用户在线列表  
        private void GetUsers()
        {
            var list = users.Select(s => new { s.UserName, s.ConnectionID }).ToList();
            string jsonList = JsonConvert.SerializeObject(list);
            Clients.All.getUsers(jsonList);
        }
    }
}