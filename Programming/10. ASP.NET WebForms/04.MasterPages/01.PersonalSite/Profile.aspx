<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="_01.PersonalSite.Profile" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
    <title>Personal Profile</title>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <h2>My Profile</h2>
    <div>
        <asp:Image ImageUrl="~/imgs/me.jpg" runat="server" />
        <p>Name: Somebody Somewhere</p>
        <p>Born: 23/12/1998</p>
        <p>Lives: Internet</p>
    </div>
</asp:Content>
