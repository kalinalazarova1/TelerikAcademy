<%@ Page Title="EditCategories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="_01.LibrarySystem.Categories.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Categories</h1>
    <asp:ListView 
        runat="server" 
        ID="CategoriesListView" 
        ItemType="_01.LibrarySystem.Models.Category"
        DataKeyNames="Id" 
        SelectMethod="CategoriesListView_GetData" 
        DeleteMethod="CategoriesListView_DeleteItem" 
        InsertMethod="CategoriesListView_InsertItem"
        OnItemInserted="CategoriesListView_ItemInserted" 
        UpdateMethod="CategoriesListView_UpdateItem">
        <LayoutTemplate>
            <div class="row">
                <div class="col-md-5">
                    <table class="table table-bordered table-hover table-condensed table-striped table-responsive">
                        <tr>
                            <td>
                                <asp:LinkButton 
                                    runat="server" 
                                    ID="SortByName"
                                    CommandName="Sort" 
                                    Text="Category Name"
                                    CommandArgument="Name"/>
                            </td>
                            <th style="text-align: center;">Action</th>
                        </tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                        <tr>
                            <td colspan="2">
                                <asp:DataPager ID="DataPagerCategories" runat="server" PagedControlID="CategoriesListView" PageSize="5">
                                <Fields>
                                    <asp:NumericPagerField />
                                </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                    <asp:Button runat="server" ID="InsertCategory" Text="Create New" OnClick="InsertCategory_Click" CssClass="btn btn-xs" />
                </div>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#: Item.Name %></td>
                <td>
                    <asp:Button runat="server" CommandName="Edit" Text="Edit" CssClass="btn bt-default btn-xs" />
                    <asp:Button runat="server" CommandName="Delete" Text="Delete" CssClass="btn bt-default btn-xs" />
                </td>
            </tr>
        </ItemTemplate>
        <InsertItemTemplate>
            <tr>
                <td colspan="2">
                    <h4>Create New Category</h4>
                        <div>
                            <asp:Label runat="server" AssociatedControlID="CategoryName">Category: </asp:Label>
                            <asp:TextBox runat="server" ID="CategoryName" Text="<%#: BindItem.Name %>"></asp:TextBox><br />
                            <asp:Button runat="server" ID="Insert" CssClass="btn btn-xs" Text="Create" CommandName="Insert" />
                            <asp:Button runat="server" ID="Cancel" Text="Cancel" CssClass="btn btn-xs" OnClick="Cancel_Click" />
                    </div>
                </td>  
            </tr>
        </InsertItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                   <asp:TextBox runat="server" ID="EditName" Text="<%#: BindItem.Name %>"></asp:TextBox>
                </td>
                <td>
                    <asp:Button runat="server" CommandName="Update" Text="Update" CssClass="btn bt-default btn-xs" />
                    <asp:Button runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn bt-default btn-xs" />
                </td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <tr>
                <td colspan="2">No categories</td>
            </tr>
        </EmptyDataTemplate>
    </asp:ListView>
    <div>
        <asp:HyperLink runat="server" CssClass="btn btn-link" NavigateUrl="~/Default.aspx">Back to books</asp:HyperLink>
    </div>
</asp:Content>
