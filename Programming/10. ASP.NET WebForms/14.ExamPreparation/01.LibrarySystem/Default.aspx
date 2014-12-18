<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_01.LibrarySystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group row">
    <h1 runat="server">Books</h1>
        <asp:Button runat="server" ID="Search" CssClass="btn btn-default pull-right" OnClick="Search_Click" Text="Search"/>
        <asp:TextBox runat="server" ID="SearchWord" CssClass="pull-right form-control" placeholder="Search by book title / author..."></asp:TextBox>
    </div>
    <div class="row">
        <asp:ListView 
        runat="server" 
        ID="lvCategories" 
        ItemType="_01.LibrarySystem.Models.Category" 
        SelectMethod="lvCategories_GetData"
        GroupItemCount="3">
        <GroupTemplate>
            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
        </GroupTemplate>
        <ItemTemplate>
            <div class="col-md-4">
                <h3 runat="server"><%#: Item.Name %></h3>
                <asp:ListView 
                    runat="server" 
                    ID="lvBooks" 
                    ItemType="_01.LibrarySystem.Models.Book" 
                    DataSource="<%# Item.Books %>" 
                    DataKeyNames="Id">
                    <ItemTemplate>
                        <li><asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/BookDetails.aspx?id={0}", Item.Id) %>' ><%#: Item.Title %><em> by <%#: Item.Author %></em></asp:HyperLink></li>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <em>No books in this category.</em>
                    </EmptyDataTemplate>
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                        </ul>
                    </LayoutTemplate>
                </asp:ListView>
            </div>
        </ItemTemplate>  
    </asp:ListView>
    </div>
</asp:Content>
