<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LikeControl.ascx.cs" Inherits="NewsSystem.LikeControl" %>

<div>Likes</div>
<div>
    <asp:Literal runat="server" ID="UserLiteral" Visible="false"></asp:Literal>
    <asp:Literal runat="server" ID="ArticleLiteral" Visible="false"></asp:Literal>
    <div runat="server" id="content">
    <asp:Button runat="server" ID="Up" CssClass="btn btn-default" ButtonType="Button" Text="Up"  />
    <asp:Literal runat="server" ID="LikesLiteral" />
    <asp:Button runat="server" ID="Down" class="btn btn-default" OnClick="Down_Click" Text="Down" />
    </div>
</div>
