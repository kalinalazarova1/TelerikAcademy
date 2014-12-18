<%@ Page Title="News" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="NewsSystem.News" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <h1><%: Title %></h1>
    <asp:Repeater runat="server" ID="ArticlesRepeater" ItemType="NewsSystem.Models.Article" SelectMethod="ArticlesRepeater_GetData">
        <HeaderTemplate>
            <h2>Most popular articles</h2>
        </HeaderTemplate>
        <ItemTemplate>
             <div class="row">
                <h3><asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/ArticlesDetails.aspx?Id={0}", Item.Id) %>'><%#: Item.Title %></asp:HyperLink> <small><%#: Item.Category.Name %></small></h3>
                <p>
                    <%#: Item.Content.Length > 300 ? Item.Content.Substring(0, 299) + "..." : Item.Content  %>
                </p>
                <p>Likes: <%# Item.Likes.Sum(l => l.Value) %></p>
                <div>
                    <i>by <%#: Item.Author.UserName %></i>
                    <i>created on: <%# Item.DateCreated %></i>
                </div>
             </div>
        </ItemTemplate>
    </asp:Repeater>
    <h2>All categories</h2>
    <div class="row">
        <asp:ListView 
        runat="server" 
        ID="lvCategories" 
        ItemType="NewsSystem.Models.Category" 
        SelectMethod="lvCategories_GetData">
        <ItemTemplate>
            <div class="col-md-6">
                <h3 runat="server"><%#: Item.Name %></h3>
                <asp:ListView 
                    runat="server" 
                    ID="lvArticles" 
                    ItemType="NewsSystem.Models.Article" 
                    DataSource="<%# Item.Articles.OrderByDescending(a => a.DateCreated).Take(3) %>" 
                    DataKeyNames="Id">
                    <ItemTemplate>
                        <li><asp:HyperLink runat="server" NavigateUrl='<%# string.Format("~/ArticlesDetails.aspx?Id={0}", Item.Id) %>' ><strong><%#: Item.Title %></strong><em> by <%#: Item.Author.UserName %></em></asp:HyperLink></li>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        No articles
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
