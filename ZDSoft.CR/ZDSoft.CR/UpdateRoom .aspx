<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Master.Master" AutoEventWireup="true" CodeBehind="UpdateRoom .aspx.cs" Inherits="ZDSoft.CR.UpdateRoom1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        input {
            opacity: 0.5;
        }

        #d1 {
            text-align: center;
            margin: auto;
            width:300px;
            height: 300px;
            background-image: url(Images/bj4.jpg);
            background-size: 300px 300px;
        }

        #d2 {
            width: 300px;
            height:100px;
            padding-top:30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div id="d1">
        <h1>修改房间信息</h1>
        <div id="d2">
            <asp:TextBox ID="tbxRoomName" runat="server" Widt="100px"></asp:TextBox><br /><br />
            <span style="opacity:0.6;">
                <asp:TextBox ID="tbxRoomDesc" runat="server" TextMode="MultiLine" Rows="5" Widt="100px"></asp:TextBox></span><br /><br />
            <span><asp:Button ID="btn_UpdateRoom" runat="server" Text="修改信息" OnClick="btn_UpdateRoom_Click" /></span>
        </div>
    </div>
</asp:Content>
