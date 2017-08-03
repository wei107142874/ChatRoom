using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDSoft.CR.Domain;
using ZDSoft.CR.Helpers;
using ZDSoft.CR.Service;
using ZDSoft.CR.Web;

namespace ZDSoft.CR
{
    public partial class ChatRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (AppHelper.LoginedUser == null)
                {
                    Response.Redirect("Login.aspx");
                }
                tb_roomId.Style.Add("display", "none");
                this.tb_roomId.Text = Request.QueryString["rid"];
                BindsysUser();
                ViewState["RoomID"] = Convert.ToInt32(Request.QueryString["rid"]);
                //time(null, null);
                
            }
        }


        public void BindsysUser()
        {
            int roomID = Convert.ToInt32(Request.QueryString["rid"]);
            string userName = Session["UserName"].ToString();
            UserInfo user = DataFactory.CreateObject<IUserService>().GetUserNameByUserInfo(userName);
            int userID = user.UserID;
            char userType = user.UserType;

            //将管理员昵称显示到控件上
            if (userType == '2' || userType == '3' || user.UserType == '4')
            {
                RoomInfo room = DataFactory.CreateObject<IRoomService>().GetRoomIDByRoomInfo(roomID);
                userID = room.UserID;

                UserInfo uid = DataFactory.CreateObject<IUserService>().GetUserIDByUserInfo(userID);
                //lbNickName.Text = uid.NickName;
            }

            if (userType == '2')
            {
                //查询RoomUser是否只有两条数据
                int count = DataFactory.CreateObject<IRoomService>().GetRoomIDByCount(roomID);
                if (count == 2)
                {
                    userID = AppHelper.LoginedUser.UserID;
                    userType = '4';
                    //如果是就将状态改为 4
                    int rv = DataFactory.CreateObject<IUserService>().Update_UserType(userID, userType);
                }
            }
        }

        public void btn_leaveRoom_Click(object sender, EventArgs e)
        {
            int roomID = Convert.ToInt32(Request.QueryString["rid"]);

            int userID = AppHelper.LoginedUser.UserID;
            string userName = AppHelper.LoginedUser.UserName;
            UserInfo user = DataFactory.CreateObject<IUserService>().GetUserNameByUserInfo(userName);
            char userType = user.UserType;
            bool rv;
            int ra;
            if (userType == '3')
            {
                //查询RoomUser是否只剩一条数据
                ra = DataFactory.CreateObject<IRoomService>().GetRoomIDByRoomUserCount(roomID);
                //如果是就根据roomID删除Chat表中的信息
                if (ra == 1)
                {
                    ra = DataFactory.CreateObject<IChatService>().GetRoomID_DeleteChat(roomID);
                }
                //删除RoomUser中的用户信息
                ra = DataFactory.CreateObject<IRoomService>().Delete_RoomUser(userID);
                if (ra < 1)
                {
                    return;
                }

                //查询RoomUser是否有数据
                RoomUser ru = DataFactory.CreateObject<IRoomService>().GetRoomIDByRoomUser(roomID);

                //如果没有就删除RoomInfo房间信息，并修改用户状态
                if (ru == null)
                {
                    userType = '1';
                    rv = DataFactory.CreateObject<IRoomService>().Delete_RoomInfo_Update_userType(userID, userType);
                    //Session["UserID"] = userID;
                    Response.Redirect("Home.aspx");
                }

                 //当RoomUser表不为空时
                else if (ru != null)
                {
                    //修改 状态 为1
                    userType = '1';
                    ra = DataFactory.CreateObject<IUserService>().Update_UserType(userID, userType);


                    VUUR vr = DataFactory.CreateObject<IVUURService>().GetRoomIDByVUUR(roomID);
                    userID = vr.UserID;
                    userType = '3';

                    //将用户为4的ID更新到RoomUser表中
                    rv = DataFactory.CreateObject<IRoomService>().Update_RoomInfoUserID_Update_userType(roomID, userID, userType);

                    userType = '3';
                    // ！！！将userType=3的用户的名字放在管理员上面
                    UserInfo users = DataFactory.CreateObject<IUserService>().GetUserTypeByUserInfo(userType);
                    //lbNickName.Text = users.NickName;
                }
            }
            if (userType == '2')
            {
                userType = '1';
                rv = DataFactory.CreateObject<IRoomService>().Delete_RoomUser_Update_UserType(userID, userType);
            }
            //当备选房主离开时
            if (userType == '4')
            {
                //根据roomID查询出最小的RoomUserID且userType为2的信息
                VUUR vr = DataFactory.CreateObject<IVUURService>().Select_MinRoomUserID(roomID);

                //如果没有就直接退出房间
                if (vr == null)
                {
                    userType = '1';
                    rv = DataFactory.CreateObject<IRoomService>().Delete_RoomUser_Update_UserType(userID, userType);
                    Response.Redirect("Home.aspx");
                }


                int roomuserID = vr.RoomUserID;
                userType = '4';

                //将这条信息的userType改为4

                ra = DataFactory.CreateObject<IVUURService>().GetRoomUserID_Update_userType(roomuserID, userType);

                userType = '1';
                rv = DataFactory.CreateObject<IRoomService>().Delete_RoomUser_Update_UserType(userID, userType);
                if (rv == false)
                {
                    return;
                }
            }

            Response.Redirect("Home.aspx");
            //int rv = DataFactory.CreateObject<IRoomService>().leaveRoomDate(roomID);
        }

        protected void Btn_Sever_Click(object sender, EventArgs e)
        {
            int roomID = Convert.ToInt32(Request.QueryString["rid"]);

            VUUR vr = DataFactory.CreateObject<IVUURService>().GetRoomID_Select__VUUR(roomID);
            //string mc = this.tbxMsgContent.Text;
            string sName = AppHelper.LoginedUser.UserName;
            string rName = "";
            string sendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            Chat chat = new Chat();
            //chat.MsgContent = mc;
            chat.ReceiveUserName = rName;
            chat.RoomID = roomID;
            chat.SendDateTime = sendTime;
            chat.SendUserName = sName;

            int rv = DataFactory.CreateObject<IChatService>().Insert(chat);

        }

        //public void time(object sender, EventArgs e)
        //{
        //    System.Timers.Timer timer = new System.Timers.Timer();
        //    timer.Enabled = true;
        //    timer.Interval = 3000;
        //    int roomID = Convert.ToInt32(ViewState["RoomID"]);
        //    int count = DataFactory.CreateObject<IChatService>().GetRoomIDByChatCount(roomID);
        //    if (count != AppHelper.LoginedUser.ct)
        //    {
        //        timer.Elapsed += new ElapsedEventHandler(counts);
        //    }
               
        //}
        //public void counts(object source, ElapsedEventArgs e)
        //{
        //    int roomID = Convert.ToInt32(ViewState["RoomID"]);
        //    int count = DataFactory.CreateObject<IChatService>().GetRoomIDByChatCount(roomID);
        //    if (count != AppHelper.LoginedUser.ct)
        //    {
        //        Timer1_Tick(null, null);
        //        this.Timer1.Interval = 1000;
        //    }
        //}

        //public void Timer1_Tick(object sender, EventArgs e)
        //{
        //    int roomID = Convert.ToInt32(ViewState["RoomID"]);
            
        //    //根据RoomID查询RoomUser
        //    //RoomUser ru = DataFactory.CreateObject<IRoomService>().GetRoomIDByRoomUser(roomID);


        //    //根据RoomID查询Chat的聊天信息
        //    //Chat ca = DataFactory.CreateObject<IChatService>().GetRoomIDByChat(roomID);

        //        //根据RoomID查询信息的条数
        //        int count = DataFactory.CreateObject<IChatService>().GetRoomIDByChatCount(roomID);
                
        //        if (count != AppHelper.LoginedUser.ct)
        //        {
        //            //执行DataSet
        //            Chat();
        //            this.Timer1.Interval = 600000;
        //        }
        //        //保存信息个数
        //        AppHelper.LoginedUser.ct = count;
               
        //}

        public void Chat()
        {
            int roomID = Convert.ToInt32(ViewState["RoomID"]);

            //根据RoomID查询Chat的聊天信息
            Chat ca = DataFactory.CreateObject<IChatService>().GetRoomIDByChat(roomID);

            DataSet ds = DataFactory.CreateObject<IChatService>().Select_Chat(ca);
            //this.GridView1.ShowHeader = false;
            //this.GridView1.DataSource = ds.Tables[0];
            //this.GridView1.DataBind();
        }
        protected void btn_ChangeInformation_Click(object sender, EventArgs e)
        {

            //
            int roomID = Convert.ToInt32(Request.QueryString["rid"]);
            string userName = AppHelper.LoginedUser.UserName;

            //在RoomInfo查询房主ID
            RoomInfo room = DataFactory.CreateObject<IRoomService>().GetRoomIDByRoomInfo(roomID);
            int userID = room.UserID;


            //根据RoomID,UserID在RoomUser查询房主的信息
            RoomUser ru = DataFactory.CreateObject<IRoomService>().GetRoomIDUserIDByRoomUser(roomID, userID);
            //当房主不为空时
            if (ru != null)
            {

                if (userID == AppHelper.LoginedUser.UserID)
                {
                    Response.Redirect(string.Format("UpdateRoom .aspx?rid={0}", roomID));
                    return;
                }
                else
                {
                    Response.Write("<script>alert('管理员才能更改房间信息')</script>");
                    return;
                }
            }
        }
    }
}