<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SumNumbers.aspx.cs" Inherits="WebApplication1.SumNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sum Numbers</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server">First Number: </asp:Label>
        <asp:TextBox runat="server" ID="first" /><br />
        <asp:Label runat="server">Second Number: </asp:Label>
        <asp:TextBox runat="server" ID="second" /><br />
        <asp:TextBox id="sum" runat="server" ReadOnly="true"></asp:TextBox>
        <asp:Button ID="SumButton" runat="server" OnClick="SumButton_Click" text="Sum"/>
    </div>
    </form>
</body>
</html>
