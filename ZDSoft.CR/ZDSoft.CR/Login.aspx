<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ZDSoft.CR.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Style/Login.css" />
</head>
    <script type="text/javascript">
        if (window.top.location.toString().toUpperCase().indexOf("LOGIN.ASPX") < 1) {
            window.top.location = "Login.aspx";
        }

        function ValidateCode() {
            document.getElementById("imgValidate").src = "ValidateImage.aspx?len=4&r=" + Math.random();
        }
    </script>
<body>
    <form id="form1" runat="server">
        <div id="sty1" style="background-image: url(Images/bj2.jpg);">
            <div id="content">
                用户名：<asp:TextBox ID="tbxUserName" runat="server"></asp:TextBox><br />
                <br />
                <br />
                密码：&nbsp;<asp:TextBox ID="tbxPassword" runat="server" TextMode="Password"></asp:TextBox><br />
                <br />
                <br />
                <span style="color: red;">验证码：</span>
                <asp:TextBox ID="tbxValideCode" runat="server" Width="48px"></asp:TextBox>
                <img alt="" id="imgValidate" src="ValidateImage.aspx?len=4" onclick="ValidateCode()" />
                <br />
                <br />
                <br />
                <br />
                <div id="Server">
                    <span class="ser">
                        <asp:Button ID="btnSever" runat="server" Text="登录" OnClick="btnSever_Click" CommandArgument='<%# Bind("UserID") %>'/></span>
                    <span class="ser"><a href="Registered.aspx">注册</a></span>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
