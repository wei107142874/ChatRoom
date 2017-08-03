using SecurityDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDSoft.CR.Domain;
using ZDSoft.CR.Service;
using ZDSoft.CR.Web;

namespace ZDSoft.CR
{
    public partial class Registered : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSever_Click(object sender, EventArgs e)
        {
            UserInfo user = new UserInfo();

            user.UserName = this.tbxUserName.Text.Trim();
            if(user.UserName.Length<6)
            {
                Response.Write("<script>alert('用户名长度不能小于6位')</script>");
                return;
            }

            string userName = user.UserName;
            UserInfo u = DataFactory.CreateObject<IUserService>().GetUserNameByUserInfo(userName);
            if (u == null)
            {
                user.NickName = this.tbxNickName.Text.Trim();

                
                //if (this.tbxPassword.Text != this.tbxConfirmPassword.Text)
                //{
                //    Response.Write("<script>alert('密码不能为空')</script>");
                //    return;
                //}
                this.tbxPassword.Text = Security.MD5(this.tbxPassword.Text);
                user.HeadUrl = this.ddlDepartment.SelectedItem.Value;
                user.Password = this.tbxPassword.Text;
                user.RegisteredDate = DateTime.Now;

                int rv = DataFactory.CreateObject<IUserService>().User_Registered(user);

                if (rv < 0)
                {
                    Response.Write("<script>alert('注册发生异常')</script>");
                    return;
                }
                else
                {
                    Response.Redirect("Login.aspx", false);
                }
            }
            else
            {
                Response.Write("<script>alert('该用户名已存在')</script>");
                return;
            }
        }
    }
}