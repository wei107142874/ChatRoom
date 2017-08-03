<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ZDSoft.CR.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        用户名：<asp:TextBox ID="tbxUserName" runat="server"></asp:TextBox><br />
        密码：<asp:TextBox ID="TbxPassword" runat="server"></asp:TextBox><br />
        验证：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

    </div>
    <div>
        <asp:Button ID="btnSever" runat="server" Text="登录" />
        <a href="Registered.aspx">注册</a>
    </div>
    </form>
</body>
</html>
