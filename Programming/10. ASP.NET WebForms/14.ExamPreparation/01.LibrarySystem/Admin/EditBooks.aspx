<%@ Page Title="Edit Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBooks.aspx.cs" Inherits="_01.LibrarySystem.Admin.EditBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Books</h1>
    <asp:ListView 
        runat="server" 
        ID="BooksListView" 
        ItemType="_01.LibrarySystem.Models.Book"
        DataKeyNames="Id" 
        SelectMethod="BooksListView_GetData" 
        DeleteMethod="BooksListView_DeleteItem" 
        InsertMethod="BooksListView_InsertItem"
        OnItemInserted="BooksListView_ItemInserted" 
        UpdateMethod="BooksListView_UpdateItem">
        <LayoutTemplate>
            <div class="row">
                <div>
                    <table class="table table-bordered table-hover table-condensed table-striped table-responsive">
                        <tr>
                            <th style="text-align: center;">
                                <asp:LinkButton 
                                    runat="server" 
                                    ID="SortByTitle"
                                    CommandName="Sort" 
                                    Text="Title"
                                    CommandArgument="Title"/>
                            </th>
                            <th style="text-align: center;">
                                <asp:LinkButton 
                                    runat="server" 
                                    ID="SortByAuthor"
                                    CommandName="Sort" 
                                    Text="Author"
                                    CommandArgument="Author"/>
                            </th>
                            <th style="text-align: center;">
                                <asp:LinkButton 
                                    runat="server" 
                                    ID="SortByISBN"
                                    CommandName="Sort" 
                                    Text="ISBN"
                                    CommandArgument="ISBN"/>
                            </th>
                            <th style="text-align: center;">
                                <asp:LinkButton 
                                    runat="server" 
                                    ID="SortBySite"
                                    CommandName="Sort" 
                                    Text="Web Site"
                                    CommandArgument="Site"/>
                            </th>
                            <th style="text-align: center;">
                                <asp:LinkButton 
                                    runat="server" 
                                    ID="SortByCategory"
                                    CommandName="Sort" 
                                    Text="Category"
                                    CommandArgument="Category.Name"/>
                            </th>
                            <th style="text-align: center;" class="col-md-1" >Action</th>
                        </tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                        <tr>
                            <td colspan="6">
                                <asp:DataPager ID="DataPagerBooks" runat="server" PagedControlID="BooksListView" PageSize="5">
                                <Fields>
                                    <asp:NumericPagerField />
                                </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                    <asp:Button runat="server" ID="InsertBook" Text="Create New" OnClick="InsertBook_Click" CssClass="btn btn-xs" />
                </div>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#: Item.Title %></td>
                <td><%#: Item.Author %></td>
                <td><%#: Item.ISBN %></td>
                <td><a href="<%#: Item.Site %>"><%#: Item.Site %></a></td>
                <td><%#: Item.Category.Name %></td>
                <td>
                    <asp:Button runat="server" CommandName="Edit" Text="Edit" CssClass="btn bt-default btn-xs" />
                    <asp:Button runat="server" CommandName="Delete" Text="Delete" CssClass="btn bt-default btn-xs" />
                </td>
            </tr>
        </ItemTemplate>
        <InsertItemTemplate>
            <tr>
                <td colspan="6">
                    <h4>Create New Book</h4>
                        <div class="form-horizontal">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="BookTitle" CssClass="col-lg-2 control-label">Title: </asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox runat="server" ID="BookTitle" Text="<%#: BindItem.Title %>" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="BookAuthor" CssClass="col-lg-2 control-label">Author: </asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox runat="server" ID="BookAuthor" Text="<%#: BindItem.Author %>" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="BookISBN" CssClass="col-lg-2 control-label">ISBN: </asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox runat="server" ID="BookISBN" Text="<%#: BindItem.ISBN %>" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="BookSite" CssClass="col-lg-2 control-label">Web Site: </asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox runat="server" ID="BookSite" Text="<%#: BindItem.Site %>" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="BookSite" CssClass="col-lg-2 control-label">Description: </asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox runat="server" ID="BookDescription" Text="<%#: BindItem.Description %>" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="BookTitle" CssClass="col-lg-2 control-label">Category: </asp:Label>
                                <div class="col-lg-3">
                                    <asp:DropDownList 
                                    runat="server" 
                                    ID="CateogriesDropDown" 
                                    DataTextField="Name" 
                                    DataValueField="Id" 
                                    ItemType="_01.LibrarySystem.Models.Category" 
                                    SelectedValue="<%#: BindItem.CategoryId %>"  
                                    SelectMethod="Categories_GetData" 
                                    CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-10 col-lg-offset-2">
                                    <asp:Button runat="server" ID="Insert" CssClass="btn" Text="Create" CommandName="Insert" />
                                    <asp:Button runat="server" ID="Cancel" Text="Cancel" CssClass="btn" OnClick="Cancel_Click" />
                                </div>
                            </div>
                    </div>
                </td>  
            </tr>
        </InsertItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="EditTitle" Text="<%#: BindItem.Title %>"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="EditAuthor" Text="<%#: BindItem.Author %>"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="EditIsbn" Text="<%#: BindItem.ISBN %>"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="EditSite" Text="<%#: BindItem.Site %>"></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList 
                        runat="server" 
                        ID="EditCategoryDropDown" 
                        DataTextField="Name" 
                        DataValueField="Id" 
                        ItemType="_01.LibrarySystem.Models.Category" 
                        SelectedValue="<%#: BindItem.CategoryId %>"  
                        SelectMethod="Categories_GetData" ></asp:DropDownList>
                </td>
                <td  class="col-md-1" >
                    <asp:Button runat="server" CommandName="Update" Text="Update" CssClass="btn bt-default btn-xs" />
                    <asp:Button runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn bt-default btn-xs" />
                </td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <tr>
                <td colspan="6">No Books</td>
            </tr>
        </EmptyDataTemplate>
    </asp:ListView>
    <div>
        <asp:HyperLink runat="server" CssClass="btn btn-link" NavigateUrl="~/Default.aspx">Back to books</asp:HyperLink>
    </div>
</asp:Content>
