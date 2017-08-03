using SecurityDemo;
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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnSever_Click(object sender, EventArgs e)
        {
            //MD5解密
            this.tbxPassword.Text = Security.MD5(this.tbxPassword.Text);
            string userName = tbxUserName.Text;
            string password = tbxPassword.Text;
            Session["UserName"] = userName;


            IUserService service = DataFactory.CreateObject<IUserService>();
            UserInfo loginUser = service.GetUser(userName, password);
            if (loginUser == null)
            {
                Response.Write("<script>alert('用户名或者密码错误')</script>");
                return;
            }
            //if (this.tbxValideCode.Text.Trim().ToLower() != Session["ValidateCode"].ToString().ToLower())
            //{
            //    Response.Write("<script>alert('验证码输入错误')</script>");
            //    return;
            //}

            UserInfo user = DataFactory.CreateObject<IUserService>().GetUserNameByUserInfo(userName);

            
            if (user.LoginDate != "")
            {
                //查询上次登录时间
                UserInfo loginDate = DataFactory.CreateObject<IUserService>().Select_LoginDate(loginUser);


                if (user.UserType == '1')
                {
                    //注销并返回登陆页
                    user.UserID = loginUser.UserID;
                    user.LoginDate = (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss.fff");
                    int rv = DataFactory.CreateObject<IUserService>().User_ZhuxiaoDate(user);

                    Response.Write("<script>alert('该用户已登录,请正常注销，给你带来的不便，敬请谅解')</script>");
                    return;
                }

                if (user.UserType == '2' || user.UserType == '3' || user.UserType=='4')
                {
                    user.UserID = loginUser.UserID;
                    int userID = user.UserID;

                    RoomUser ru = DataFactory.CreateObject<IRoomService>().GetUserIDByRoomRoom(userID);
                    int roomID = ru.RoomID;
                   //Response.Redirect(string.Format("Home.aspx?rid={0}", roomID));
                    AppHelper.LoginedUser = loginUser;
                    Response.Redirect(string.Format("ChatRoom.aspx?rid={0}", roomID));
                }

                //user.LoginDate = (DateTime.Now).ToString("HHmmss");
                //string dow = user.LoginDate;
                //string dt =(Convert.ToDateTime(loginDate.ZhuxiaoDate)).ToString("HHmmss");
                //int aa = Convert.ToInt32(dow) - Convert.ToInt32(dt);
                //if (aa < 30)
                //{
                //    Response.Write("<script>alert('登录太频繁，请稍后再试')</script>");
                //    return;
                //}
            }

            //获取登录时间，更改用户状态
            user.LoginDate = (DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss.fff");
            user.UserID = loginUser.UserID;
            user.UserType = '1';
            int r = DataFactory.CreateObject<IUserService>().User_LoginDate(user);

            AppHelper.LoginedUser = loginUser;

            Response.Redirect(string.Format("Home.aspx?UserID={0}", loginUser.UserID.ToString()));
            Response.Write("<script>alert('登录成功')</script>");
        }
    }
}