<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registered.aspx.cs" Inherits="ZDSoft.CR.Registered" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    用户名：<asp:TextBox ID="tbxUserName" runat="server"></asp:TextBox><br />
    头像：<asp:TextBox ID="tbxHeadUrl" runat="server"></asp:TextBox><br />
    昵称：<asp:TextBox ID="tbxNickUserName" runat="server"></asp:TextBox><br />
    密码：<asp:TextBox ID="tbxPassword" runat="server"></asp:TextBox><br />
    确认密码：<asp:TextBox ID="tbxConfirmPassword" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="btnSever" runat="server" Text="注册" onclick="btnSever_Click" 
            style="width: 40px" />

    </div>
    </form>
</body>
</html>
