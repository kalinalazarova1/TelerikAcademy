<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" %>

<asp:Content ID="ContentPage" runat="server"
    ContentPlaceHolderID="ContentPlaceHolderPageContent">
    <h1 id="welcome-text">Welcome to our International Company Inc. web site</h1>
    <asp:HyperLink runat="server" NavigateUrl="~/Bulgaria/BulgariaHome.aspx" 
        Text="Bulgaria" CssClass="bg-icon"/>
    <asp:HyperLink runat="server" NavigateUrl="~/US/USHome.aspx"
         Text="United States" CssClass="us-icon"/>
    <asp:HyperLink runat="server" NavigateUrl="~/Germany/GermanyHome.aspx" 
        Text="Germany" CssClass="germany-icon"/>
</asp:Content>
