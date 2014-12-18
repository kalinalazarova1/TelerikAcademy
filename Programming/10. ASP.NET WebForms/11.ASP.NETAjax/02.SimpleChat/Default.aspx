<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_02.SimpleChat.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simple Chat</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <h2>Simple Chat</h2>
        <asp:UpdatePanel runat="server" ID="ChatUpdatePanel" UpdateMode="Conditional" >
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="TimerRefresh" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:Timer ID="TimerRefresh" runat="server" Interval="500" OnTick="TimerRefresh_Tick" />
                <asp:ListView ID="lvMessages"
                runat="server"  
                DataKeyNames="Id" 
                ItemType="_02.SimpleChat.Models.Message" 
                InsertItemPosition="None" 
                SelectMethod="lvMessages_GetData">
                <ItemTemplate>
                    <tr><td><strong><%#: Item.Author %></strong>(<%#: Item.TimeStamp.ToShortTimeString() %>)</td><td><%#: Item.Content %></td></tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <p>No messages</p>
                </EmptyDataTemplate>
                <LayoutTemplate>
                    <table border="1" runat="server" id="chat">
                        <tr runat="server" ><th runat="server" >Author</th><th runat="server" >Content</th></tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                    <asp:DataPager ID="DataPagerMessages" runat="server" PagedControlID="lvMessages" PageSize="10">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="true"
                        ShowNextPageButton="false" ShowPreviousPageButton="false" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowLastPageButton="true"
                        ShowNextPageButton="false" ShowPreviousPageButton="false" />
                </Fields>
            </asp:DataPager>

                </LayoutTemplate>
            </asp:ListView>
                </ContentTemplate>
            </asp:UpdatePanel>
        <table>
            <tr><th colspan="2">Create New Message:</th></tr>
            <tr>
                <td>By: <asp:TextBox ID="Author" runat="server" ></asp:TextBox></td>
                <td>Message: <asp:TextBox ID="Content" runat="server"></asp:TextBox></td>
            </tr>
            <tr><td><asp:Button runat="server" ID="SaveMessage" OnClick="SaveMessage_Click" Text="Save" /></td></tr>
        </table>
    </form>
</body>
</html>
