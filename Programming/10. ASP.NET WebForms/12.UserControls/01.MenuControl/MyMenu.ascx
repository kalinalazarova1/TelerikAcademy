<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyMenu.ascx.cs" Inherits="_01.MenuControl.MyMenu" %>

<asp:DataList runat="server" ID="DataListId" ItemType="_01.MenuControl.Models.Link" RepeatDirection="Horizontal" >
    <ItemTemplate>
        <a runat="server" href="<%#: Item.Url %>"><%#: Item.Title %></a>
    </ItemTemplate>
</asp:DataList>
