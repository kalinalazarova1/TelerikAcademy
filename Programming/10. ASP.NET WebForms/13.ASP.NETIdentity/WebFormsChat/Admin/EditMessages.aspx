<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditMessages.aspx.cs" Inherits="WebFormsChat.Admin.EditMessages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Messages</h1>
    <asp:ListView 
        runat="server" 
        ID="MessagesListView" 
        ItemType="WebFormsChat.Models.Message"
        DataKeyNames="Id" 
        SelectMethod="MessagesListView_GetData" 
        InsertMethod="MessagesListView_InsertItem"
        OnItemInserted="MessagesListView_ItemInserted" 
        UpdateMethod="MessagesListView_UpdateItem">
        <LayoutTemplate>
            <div class="row">
                <div>
                    <table class="table table-bordered table-hover table-condensed table-striped table-responsive">
                        <tr>
                            <th style="text-align: center;">
                                <asp:Literal 
                                    runat="server" 
                                    Text="User"/>
                            </th>
                            <th style="text-align: center;">
                                <asp:LinkButton 
                                    runat="server" 
                                    ID="SortByDate"
                                    CommandName="Sort" 
                                    Text="Time Stamp"
                                    CommandArgument="CreationDate"/>
                            </th>
                            <th style="text-align: center;">
                                <asp:LinkButton 
                                    runat="server" 
                                    ID="SortByContent"
                                    CommandName="Sort" 
                                    Text="Content"
                                    CommandArgument="Content"/>
                            </th>
                            <th style="text-align: center;" class="col-md-1" >Action</th>
                        </tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                        <tr>
                            <td colspan="4">
                                <asp:DataPager ID="DataPagerMessages" runat="server" PagedControlID="MessagesListView" PageSize="10">
                                <Fields>
                                    <asp:NumericPagerField />
                                </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                    <asp:Button runat="server" ID="InsertMessage" Text="Create New" OnClick="InsertMessage_Click" CssClass="btn btn-xs" />
                </div>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#: Item.User.UserName %></td>
                <td><%#: Item.CreationDate %></td>
                <td><%#: Item.Content %></td>
                <td>
                    <asp:Button runat="server" CommandName="Edit" Text="Edit" CssClass="btn bt-default btn-xs" />
                </td>
            </tr>
        </ItemTemplate>
        <InsertItemTemplate>
            <tr>
                <td colspan="6">
                    <h4>Create New Message</h4>
                        <div class="form-horizontal">
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="MessageTitle" CssClass="col-lg-2 control-label">Content: </asp:Label>
                                <div class="col-lg-10">
                                    <asp:TextBox runat="server" ID="MessageTitle" Text="<%#: BindItem.Content %>" CssClass="form-control"></asp:TextBox>
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
                    <asp:TextBox runat="server" ID="EditAuthor" ReadOnly="true" Text="<%#: Item.User.UserName %>"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="EditDate" ReadOnly="true" Text="<%#: Item.CreationDate %>"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="EditContent" Text="<%#: BindItem.Content %>"></asp:TextBox>
                </td>
                <td  class="col-md-1" >
                    <asp:Button runat="server" CommandName="Update" Text="Update" CssClass="btn bt-default btn-xs" />
                    <asp:Button runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn bt-default btn-xs" />
                </td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <tr>
                <td colspan="6">No Messages</td>
            </tr>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
