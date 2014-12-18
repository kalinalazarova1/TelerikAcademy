<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="NewsSystem.Admin.EditCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView 
        runat="server" 
        ID="CategoriesListView" 
        ItemType="NewsSystem.Models.Category"
        DataKeyNames="Id" 
        SelectMethod="CategoriesListView_GetData" 
        DeleteMethod="CategoriesListView_DeleteItem" 
        InsertMethod="CategoriesListView_InsertItem" 
        InsertItemPosition="LastItem" 
        UpdateMethod="CategoriesListView_UpdateItem">
        <LayoutTemplate>
            <div class="container body-content">
                <div class="row">
                <div class="col-md-3">
                    <asp:LinkButton 
                        runat="server" 
                        ID="SortByName"
                        CommandName="Sort" 
                        Text="Category Name"
                        CommandArgument="Name" CssClass="btn btn-default"/>
                </div>
                </div>
                <div class="row">
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:DataPager ID="DataPagerCategories" runat="server" PagedControlID="CategoriesListView" PageSize="5">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="false" ShowNextPageButton="false" ShowPreviousPageButton="true" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowLastPageButton="false" ShowNextPageButton="true" ShowPreviousPageButton="false" />

                        </Fields>
                        </asp:DataPager>
                    </div>
                 </div>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="row">
			    <div class="col-md-3"><%#: Item.Name %></div>
			    <asp:Button runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-info" />
                <asp:Button runat="server" CommandName="Delete" Text="Delete" CssClass="btn btn-danger" />
		    </div>
        </ItemTemplate>
        <InsertItemTemplate>
            <div class="row">
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="CategoryName" Text="<%#: BindItem.Name %>"></asp:TextBox>
                </div>
                <asp:Button runat="server" ID="Insert" CssClass="btn btn-info" Text="Create" CommandName="Insert" />
                <asp:Button runat="server" ID="Cancel" Text="Cancel" CssClass="btn btn-danger" CommandName="Cancel" />
            </div>
        </InsertItemTemplate>
        <EditItemTemplate>
            <div class="row">
                <div class="col-md-3">
                   <asp:TextBox runat="server" ID="EditName" Text="<%#: BindItem.Name %>"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="EditName" CssClass="text-danger" ErrorMessage="The name field is required." />
                </div>
                <asp:Button runat="server" CommandName="Update" Text="Save" CssClass="btn btn-success" />
                <asp:Button runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-danger" />
            </div>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <div class="row">
                <div class="col-md-3">No categories</div>
            </div>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
