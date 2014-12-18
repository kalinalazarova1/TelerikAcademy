<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticlesDetails.aspx.cs" Inherits="NewsSystem.ArticlesDetails" %>
<%@ Register Src="~/LikeControl.ascx" TagPrefix="my" TagName="LikeControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:FormView ID="ArticleFormView" runat="server" ItemType="NewsSystem.Models.Article" SelectMethod="ArticleFormView_GetItem">
        <ItemTemplate>
            <table cellspacing="0" style="border-collapse:collapse;">
		        <tbody><tr>
			        <td colspan="2">
                        <%--<div class="like-control col-md-1">
						<my:LikeControl runat="server" ArticleId="<%# Item.Id %>" ReaderId="<%# this.User.Identity.GetUserId() %>" />
					    </div>--%>
				        <h2><%#: Item.Title %><small>Category: <%#: Item.Category.Name %></small></h2>
				        <p><%#: Item.Content %></p>
				        <p>
					        <span>Author: <%#: Item.Author.UserName %></span>
					        <span class="pull-right"><%# Item.DateCreated %></span>
				        </p>
			        </td>
		        </tr>
		        </tbody>
	        </table>
        </ItemTemplate>        
    </asp:FormView>
</asp:Content>
