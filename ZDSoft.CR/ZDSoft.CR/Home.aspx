<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ZDSoft.CR.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Style/Home.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-left: 100px; margin-top: 10px;"><a href="CreateRoom.aspx">创建房间</a></div>
    <div style="height: 570px;">
        <div style="margin-left: 100px;">
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="5" OnItemCommand="DataList1_ItemCommand">
                <ItemTemplate>
                    <div id="Content" style="background-image: url(Images/login1.jpg); background-size: 160px 130px;">
                        <div style="text-align: center"><%# Eval("RoomName") %></div>
                        <div style="margin-left: 10px;">
                            描述：<%# Eval("RommDesc") %><br />
                            <asp:Label ID="lbCount" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div style="text-align: center; margin-top: 3px;">
                        <asp:Button ID="btn_GoRoom" runat="server" CommandName="go" CommandArgument='<%# Bind("RoomID") %>' Text="进入房间" /></div>

                </ItemTemplate>

            </asp:DataList>
        </div>
    </div>
</asp:Content>
