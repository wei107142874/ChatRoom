<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registered.aspx.cs" Inherits="ZDSoft.CR.Registered" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Style/Registered.css" />
</head>

<script type="text/javascript">
    function py() {
        Headportrait1 = document.getElementById("Headportrait1");
        ddlDepartment = document.getElementById("ddlDepartment");
        if (Headportrait1 != 0) {
            Headportrait1.src = ddlDepartment.value;
        }
    }
</script>

<body>
    <form id="form1" runat="server">
        <div style="margin: auto; width: 500px; text-align: center; position: relative; margin-top: 200px;">
            <div id="Headportrait">
                <img id="Headportrait1" runat="server" alt="" src="Images/Headportrait/Headportrait1.jpg" />
            </div>
            <div style="width: 230px; height: 200px">
                用户名：&nbsp;<asp:TextBox ID="tbxUserName" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="refUserName" runat="server" ControlToValidate="tbxUserName" ErrorMessage="请输入用户名"></asp:RequiredFieldValidator>
                
                <br />
                头像：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlDepartment" runat="server" Onchange="py();">
                        <asp:ListItem Value="Images/Headportrait/Headportrait1.jpg">请选择你的头像</asp:ListItem>
                        <asp:ListItem Value="Images/Headportrait/Headportrait2.png">头像②</asp:ListItem>
                        <asp:ListItem Value="Images/Headportrait/Headportrait3.jpg">头像③</asp:ListItem>
                        <asp:ListItem Value="Images/Headportrait/Headportrait4.jpg">头像④</asp:ListItem>
                    </asp:DropDownList>
                <br />
                <br />
                昵称：&nbsp;&nbsp;&nbsp;<asp:TextBox ID="tbxNickName" runat="server"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="refNickName" runat="server" ErrorMessage="请输入昵称" ControlToValidate="tbxNickName"></asp:RequiredFieldValidator><br />
                密码：&nbsp;&nbsp;&nbsp;<asp:TextBox ID="tbxPassword" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="refPassword" runat="server" ControlToValidate="tbxPassword" ErrorMessage="！！！不能为空"></asp:RequiredFieldValidator>
                <br />
                确认密码:<asp:TextBox ID="tbxConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="refConfirmPassword" runat="server" ErrorMessage="！！！必填" ControlToValidate="tbxConfirmPassword"></asp:RequiredFieldValidator>
                <br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbxPassword" ControlToValidate="tbxConfirmPassword" ErrorMessage="输入密码不一致"></asp:CompareValidator>
            </div>
            <div style="width:300px;">
               <span class="c1"><asp:Button ID="btnSever" runat="server" Text="注册" OnClick="btnSever_Click"
                    Style="width: 40px" /></span> 
                <span class="c1"><input id="Reset1" type="reset" value="清空" /></span>
            </div>
        </div>
    </form>
</body>
</html>
