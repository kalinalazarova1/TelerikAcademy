<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hello.aspx.cs" Inherits="_01.Hello.Hello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hello</title>
</head>
<body>
    <form id="NameForm" runat="server">
        <asp:Label runat="server" AssociatedControlID="Name">Please, enter your name: </asp:Label>
        <asp:TextBox runat="server" ID="Name" />
        <asp:Button runat="server" OnClick="OnSayHello_Click" Text="Say Hello" />
    </form>
    <asp:Label runat="server" ID="Greeting"></asp:Label>
</body>
</html>
