<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditArticles.aspx.cs" Inherits="NewsSystem.Admin.EditArticles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView 
        runat="server" 
        ID="ArticlesListView" 
        ItemType="NewsSystem.Models.Article"
        DataKeyNames="Id" 
        SelectMethod="ArticlesListView_GetData" 
        DeleteMethod="ArticlesListView_DeleteItem" 
        InsertMethod="ArticlesListView_InsertItem" 
        InsertItemPosition="None"
        OnItemInserted="ArticlesListView_ItemInserted" 
        UpdateMethod="ArticlesListView_UpdateItem">
        <LayoutTemplate>
            <div class="row">
                <asp:LinkButton 
                    runat="server" 
                    ID="SortByTitle"
                    CommandName="Sort" 
                    Text="Sort by Title" 
                    CssClass="col-md-2 btn btn-default"
                    CommandArgument="Title"/>
                <asp:LinkButton 
                    runat="server" 
                    ID="SortByDate"
                    CommandName="Sort" 
                    Text="Sort by Date"
                    CssClass="col-md-2 btn btn-default"
                    CommandArgument="DateCreated"/>
                <asp:LinkButton 
                    runat="server" 
                    ID="SortByCategory"
                    CommandName="Sort" 
                    CssClass="col-md-2 btn btn-default"
                    Text="Sort by Category"
                    CommandArgument="Category.Name"/>
                <asp:LinkButton 
                    runat="server" 
                    ID="SortByLike"
                    CommandName="Sort" 
                    CssClass="col-md-2 btn btn-default"
                    Text="Sort by Likes"
                    CommandArgument="Like.Value"/>
            </div>
            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            <div class="row">
                <asp:DataPager ID="DataPagerArticles" runat="server" PagedControlID="ArticlesListView" PageSize="5">
                    <Fields>
                        <asp:NumericPagerField />
                    </Fields>
                    </asp:DataPager>
            </div>
            <asp:Button runat="server" ID="InsertArticle" Text="Insert New Article" OnClick="InsertArticle_Click" CssClass="btn btn-info pull-right" />
        </LayoutTemplate>
        <ItemTemplate>
            <div class="row">
			<h3><%#: Item.Title %>
				<asp:Button runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-info" />
                <asp:Button runat="server" CommandName="Delete" Text="Delete" CssClass="btn btn-danger" />
			</h3>
			<p>Category: <%#: Item.Category.Name %></p>
			<p>
				<%#: Item.Content.Length > 300 ? Item.Content.Substring(0, 299) + "..." : Item.Content  %>
			</p>
			<p>Likes count: <%# Item.Likes.Sum(l => l.Value) %></p>
			<div>
				<i>by <%#: Item.Author.UserName %></i>
				<i>created on: <%# Item.DateCreated %></i>
			</div>
		</div>
        </ItemTemplate>
        <InsertItemTemplate>
            <div class="row">
                <div class="form-horizontal">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ArticleTitle" CssClass="col-lg-2 control-label">Title: </asp:Label>
                        <div class="col-lg-10">
                            <asp:TextBox runat="server" ID="ArticleTitle" Text="<%#: BindItem.Title %>" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ArticleTitle" CssClass="text-danger" ErrorMessage="The title field is required." />
                            <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="ArticleTitle"
                            ValidationExpression="^[\s\S]{3,50}$"
                            CssClass="text-danger" ErrorMessage="The title length must be between 3 and 50 symbols." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="CategoriesDropDown" CssClass="col-lg-2 control-label">Category: </asp:Label>
                        <div class="col-lg-3">
                            <asp:DropDownList 
                            runat="server" 
                            ID="CategoriesDropDown" 
                            DataTextField="Name" 
                            DataValueField="Id" 
                            ItemType="NewsSystem.Models.Category" 
                            SelectedValue="<%#: BindItem.CategoryId %>"  
                            SelectMethod="Categories_GetData" 
                            CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ArticleContent" CssClass="col-lg-2 control-label">Content: </asp:Label>
                        <div class="col-lg-10">
                            <asp:TextBox runat="server" ID="ArticleContent" Text="<%#: BindItem.Content %>" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ArticleContent" CssClass="text-danger" ErrorMessage="The content field is required." />
                            <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="ArticleContent"
                            ValidationExpression="^[\s\S]{5,2000}$"
                            CssClass="text-danger" ErrorMessage="The content length must be between 5 and 2000 symbols." />
                        </div>
                    </div>
                        
                    <div class="form-group">
                        <div class="col-lg-10 col-lg-offset-2">
                            <asp:Button runat="server" ID="Insert" CssClass="btn" Text="Create" CommandName="Insert" />
                            <asp:Button runat="server" ID="Cancel" Text="Cancel" CssClass="btn" OnClick="Cancel_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </InsertItemTemplate>
        <EditItemTemplate>
            <div class="row">
			<h3><asp:TextBox runat="server" ID="ArticleTitle" Text="<%#: BindItem.Title %>"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ArticleTitle" CssClass="text-danger" ErrorMessage="The title field is required." />
                            <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="ArticleTitle"
                            ValidationExpression="^[\s\S]{3,50}$"
                            CssClass="text-danger" ErrorMessage="The title length must be between 3 and 50 symbols." />
				<asp:Button runat="server" CommandName="Update" Text="Save" CssClass="btn btn-success" />
                <asp:Button runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-danger" />
			</h3>
            </div>
            <div class="row">
			<div class="col-lg-3">
                <asp:DropDownList 
                runat="server" 
                ID="CateogriesDropDown" 
                DataTextField="Name" 
                DataValueField="Id" 
                ItemType="NewsSystem.Models.Category" 
                SelectedValue="<%#: BindItem.CategoryId %>"  
                SelectMethod="Categories_GetData" 
                CssClass="form-control"></asp:DropDownList>
            </div>
                </div>
            <div class="row">
			<p>
				<asp:TextBox runat="server" ID="ArticleDescription" Text="<%#: BindItem.Content %>" CssClass="form-control col-md-6" TextMode="MultiLine" Rows="8"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ArticleDescription" CssClass="text-danger" ErrorMessage="The content field is required." />
                            <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="ArticleDescription"
                            ValidationExpression="^[\s\S]{5,2000}$"
                            CssClass="text-danger" ErrorMessage="The content length must be between 5 and 2000 symbols." />
			</p>
		</div>
            <div class="row">
				<i>by <%#: Item.Author.UserName %></i>
				<i>created on: <%# Item.DateCreated %></i>
			</div>
        </EditItemTemplate>
        <EmptyDataTemplate>
            No Articles
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
