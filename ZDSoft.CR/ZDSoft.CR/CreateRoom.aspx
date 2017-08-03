<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Master.Master" AutoEventWireup="true" CodeBehind="CreateRoom.aspx.cs" Inherits="ZDSoft.CR.CreateRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        input {
            opacity: 0.5;
        }

        #d {
            width: 300px;
            margin: auto;
            height: 200px;
            font-size: 20px;
            color: wheat;
        }

        #d1 {
            padding-top: 30px;
            background-image: url(Images/login.jpg);
            background-size: 300px 200px;
            width: 300px;
            height: 200px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="d">
        <div>
            <a href="Home.aspx">返回</a>
        </div>
        <div id="d1">
            房间名：<asp:TextBox ID="tbxRoomName" runat="server"></asp:TextBox><br />
            <br />
            房间描述：<span style="opacity: 0.4"><asp:TextBox ID="tbxRommDesc" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox></span>
        </div>
        <div>
            <asp:Button ID="btnSever" runat="server" Text="创建房间" OnClick="btnSever_Click" />
            <input id="Reset1" type="reset" value="重置" />
        </div>
    </div>
</asp:Content>
