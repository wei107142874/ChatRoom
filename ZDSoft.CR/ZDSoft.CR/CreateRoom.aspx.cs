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

namespace ZDSoft.CR
{
    public partial class CreateRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (AppHelper.LoginedUser == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnSever_Click(object sender, EventArgs e)
        {
            RoomInfo room = new RoomInfo();
            room.RommDesc = this.tbxRommDesc.Text;
            room.RoomName = this.tbxRoomName.Text;
            //room.UserID =Convert.ToInt32(Session["UserID"]);
            room.UserID = AppHelper.LoginedUser.UserID;
            int userID=room.UserID;

            //根据UserID查询User是否重复
            RoomInfo r=  DataFactory.CreateObject<IRoomService>().UserIDrepetition(userID);
            if (r == null)
            {
                //创建房间
                int rv = DataFactory.CreateObject<IRoomService>().CreateRoom(room);
                if (rv<1)
                {
                    Response.Write("<script>alert('创建房间失败')</script>");
                    return;
                }

                RoomInfo ro = DataFactory.CreateObject<IRoomService>().UserIDrepetition(userID);
                int roomID = ro.RoomID;
                
                // 在RoomUser表插入UserIDRoomID
                rv = DataFactory.CreateObject<IRoomService>().Insert_UserIDRoomID(userID, roomID);
                if (rv < 1)
                {
                    Response.Write("<script>alert('插入失败')</script>");
                    return;
                }

                //代表房主创建进入房间
                char userType = '3';
                
                rv = DataFactory.CreateObject<IUserService>().Update_UserTypeIStwo(userType,userID);

                string uid = userID.ToString();
                Response.Redirect(string.Format("ChatRoom.aspx?rid={0}", roomID));
               // Response.Redirect(string.Format("Home.aspx?UserID={0}", loginUser.UserID.ToString()));
            }
            else
            {
                Response.Write("<script>alert('警告警告！！！')</script>");
                return;
            }
        }
    }
}