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
    public partial class UpdateRoom1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (AppHelper.LoginedUser == null)
                {
                    Response.Redirect("Login.aspx");
                }
                getRoomInfo();
            }
        }

        public void getRoomInfo()
        {
            int roomID = Convert.ToInt32(Request.QueryString["rid"]);

            RoomInfo ro = DataFactory.CreateObject<IRoomService>().GetRoomIDByRoomInfo(roomID);

            this.tbxRoomDesc.Text = ro.RommDesc;
            this.tbxRoomName.Text = ro.RoomName;
        }
        protected void btn_UpdateRoom_Click(object sender, EventArgs e)
        {
            int roomID =Convert.ToInt32(Request.QueryString["rid"]);


            int userID = AppHelper.LoginedUser.UserID;
            RoomInfo room = new RoomInfo();
            room.UserID = userID;
            room.RoomName = this.tbxRoomName.Text;
            room.RommDesc = this.tbxRoomDesc.Text;
            int rv= DataFactory.CreateObject<IRoomService>().GetRoomIDUpdateRoomInfo(room);

            Response.Redirect(string.Format("ChatRoom.aspx?rid={0}", roomID));
        }
    }
}