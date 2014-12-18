<%@ Page Title="Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="_01.LibrarySystem.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 runat="server" id="PageTitle"></h2>
    <asp:ListView runat="server" ID="BooksSearchResults" SelectMethod="BooksSearchResults_GetData" ItemType="_01.LibrarySystem.Models.Book">
        <ItemTemplate>
            <li>
                <asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/BookDetails.aspx/id={0}", Item.Id) %>'><%#: Item.Title %><em> by <%#: Item.Author %></em></asp:HyperLink>
                (Category: <%#: Item.Category.Name %>)
            </li>
        </ItemTemplate>
        <LayoutTemplate>
            <ul>
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </ul>
        </LayoutTemplate>
    </asp:ListView>
    <asp:HyperLink runat="server" CssClass="btn btn-link" NavigateUrl="~/Default.aspx">Back to books</asp:HyperLink>
</asp:Content>
