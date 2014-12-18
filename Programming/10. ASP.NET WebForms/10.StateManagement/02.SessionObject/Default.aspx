<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_02.SessionObject.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label runat="server" ID="TextInfo" ></asp:Label><br />
        Type some text here:<br />
        <asp:TextBox runat="server" ID="TextInput"></asp:TextBox>
        <asp:Button runat="server" ID="SaveInfo" OnClick="SaveInfo_Click" Text="Save" />
    </form>
</body>
</html>
