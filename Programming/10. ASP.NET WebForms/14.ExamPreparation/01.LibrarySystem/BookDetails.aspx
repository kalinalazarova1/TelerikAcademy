<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="_01.LibrarySystem.BookDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="BookFormView" runat="server" ItemType="_01.LibrarySystem.Models.Book" SelectMethod="BookFormView_GetItem">
        <ItemTemplate>
            <h1>Book Details</h1>
            <h3 runat="server" id="Title"><%#: Item.Title %></h3>
            <h4><em>by <%#: Item.Author %></em></h4>
            <h5><em><%#: Item.ISBN %></em></h5>
            <p><em>Web Site: <a href="<%#: Item.Site %>"><%#: Item.Site %></a></em></p>
            <p><%#: Item.Description %></p>
        </ItemTemplate>        
    </asp:FormView>
    <asp:HyperLink runat="server" CssClass="btn btn-link" NavigateUrl="~/Default.aspx">Back to books</asp:HyperLink>
</asp:Content>
