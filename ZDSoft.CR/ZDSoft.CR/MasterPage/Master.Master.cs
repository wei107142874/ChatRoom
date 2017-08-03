using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDSoft.CR.Domain;
using ZDSoft.CR.Helpers;
using ZDSoft.CR.Service;
using ZDSoft.CR.Web;

namespace ZDSoft.CR.MasterPage
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string userName = Session["UserName"].ToString();
                lbName.Text = userName;
                UserInfo user = DataFactory.CreateObject<IUserService>().GetUserNameByUserInfo(userName);
                char userType = user.UserType;
            }
        }
        protected void btn_Zhuxiao_Click(object sender, EventArgs e)
        {
            int roomID = Convert.ToInt32(Request.QueryString["rid"]);
            int userID = AppHelper.LoginedUser.UserID;
            UserInfo users = DataFactory.CreateObject<IUserService>().GetUserIDByUserInfo(userID);
            char userType = users.UserType;
            bool rv;
            int ra;
            if (userType == '2')
            {
                //!!!
                userType = '0';
                rv = DataFactory.CreateObject<IRoomService>().Delete_RoomUser_Update_UserType(userID, userType);
            }

            if (userType == '3')
            {
                //房主只能返回大厅之后注销
                Response.Write("<script>alert('管理员只能在返回大厅之后才能下线')</script>");
                return;

                //根据roomID删除Chat表中的信息
                ra = DataFactory.CreateObject<IChatService>().GetRoomID_DeleteChat(roomID);
                if (ra < 1)
                {
                    return;
                }

                //删除RoomUser中的用户信息
                ra = DataFactory.CreateObject<IRoomService>().Delete_RoomUser(userID);

                RoomInfo room = DataFactory.CreateObject<IRoomService>().UserIDrepetition(userID);
                roomID = room.RoomID;
                //查询RoomUser是否有数据
                RoomUser ru = DataFactory.CreateObject<IRoomService>().GetRoomIDByRoomUser(roomID);

                //如果没有就删除RoomInfo房间信息，并修改用户状态
                if (ru == null)
                {
                    userType = '0';
                    rv = DataFactory.CreateObject<IRoomService>().Delete_RoomInfo_Update_userType(userID, userType);
                    //Session["UserID"] = userID;
                }

                else if (ru != null)
                {

                    //修改 状态 为0
                    userType = '0';
                    ra = DataFactory.CreateObject<IUserService>().Update_UserType(userID, userType);

                    VUUR vr = DataFactory.CreateObject<IVUURService>().GetRoomIDByVUUR(roomID);
                    userID = vr.UserID;
                    userType = '3';

                    rv = DataFactory.CreateObject<IRoomService>().Update_RoomInfoUserID_Update_userType(roomID, userID, userType);

                    //将userType=3的用户的名字放在管理员上面
                    //UserInfo user = DataFactory.CreateObject<IUserService>().GetUserTypeByUserInfo(userType);
                    //lbNickName.Text = user.NickName;
                }
                //UserInfo user = new UserInfo();
                //user.UserID = AppHelper.LoginedUser.UserID;
                //user.ZhuxiaoDate = DateTime.Now;
                //user.UserType = '0';
                //int rs = DataFactory.CreateObject<IUserService>().User_ZhuxiaoDate(user);

                //Session.Clear();
            }
            if (userType == '4')
            {
                //根据roomID查询出最小的RoomUserID且userType为2的信息
                VUUR vr = DataFactory.CreateObject<IVUURService>().Select_MinRoomUserID(roomID);

                //如果没有就直接退出房间
                if (vr == null)
                {
                    userType = '0';
                    rv = DataFactory.CreateObject<IRoomService>().Delete_RoomUser_Update_UserType(userID, userType);
                    Response.Redirect("~/Login.aspx");
                }

                int roomuserID = vr.RoomUserID;
                userType = '4';

                //将这条信息的userType改为4

                ra = DataFactory.CreateObject<IVUURService>().GetRoomUserID_Update_userType(roomuserID, userType);

                userType = '0';
                rv = DataFactory.CreateObject<IRoomService>().Delete_RoomUser_Update_UserType(userID, userType);
                if (rv == false)
                {
                    return;
                }
            }
            UserInfo user = new UserInfo();
            user.UserID = AppHelper.LoginedUser.UserID;
            user.ZhuxiaoDate = DateTime.Now;
            user.UserType = '0';
            int rc = DataFactory.CreateObject<IUserService>().User_ZhuxiaoDate(user);

            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}