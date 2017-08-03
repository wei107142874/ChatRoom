using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZDSoft.CR.Domain;

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
            user.UserName = this.tbxUserName.Text;
            user.HeadUrl = this.tbxHeadUrl.Text;
            user.NickName = this.tbxNickUserName.Text;
            user.Password = this.tbxPassword.Text;

            if (this.tbxPassword.Text == this.tbxConfirmPassword.Text)
            {

            }
        }
    }
}