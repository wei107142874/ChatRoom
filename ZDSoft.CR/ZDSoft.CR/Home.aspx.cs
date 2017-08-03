using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (AppHelper.LoginedUser == null)
                {
                    Response.Redirect("Login.aspx");
                }


                BindRoomInformation();

                int userID = Convert.ToInt32(Request.QueryString["UserID"]);
                Session["UserID"] = userID;
            }
        }
        public void BindRoomInformation()
        {
            int userID;

            string userName = AppHelper.LoginedUser.UserName;
            UserInfo user = DataFactory.CreateObject<IRoomService>().GetUserNameByUserID(userName);
            userID = user.UserID;
            DataSet ds = DataFactory.CreateObject<IRoomService>().RoomInfo();

            this.DataList1.DataSource = ds.Tables[0];
            this.DataList1.DataBind();
            // ViewState["UserID"] = userID;
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                int roomID = Convert.ToInt32(e.CommandArgument);
                int userID = AppHelper.LoginedUser.UserID;

                //查询RoomUser表中的数据
                RoomUser ru = DataFactory.CreateObject<IRoomService>().Select_RoomUser(userID);

                if (ru == null)
                {
                    char userType = '2';

                    int rv = DataFactory.CreateObject<IUserService>().Update_UserTypeIStwo(userType, userID);

                    //进入房间时在RoomUser表插入UserIDRoomID
                    rv = DataFactory.CreateObject<IRoomService>().Insert_UserIDRoomID(userID, roomID);
                    if (rv < 1)
                    {
                        return;
                    }

                }
                Response.Redirect(string.Format("ChatRoom.aspx?rid={0}", roomID));
            }
        }
    }
}