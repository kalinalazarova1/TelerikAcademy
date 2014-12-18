<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Escaping.aspx.cs" Inherits="_03.HTMLEscaping.Escaping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Escaping Text</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label runat="server" AssociatedControlID="Origin">Please enter text: </asp:Label><br />
        <asp:TextBox runat="server" ID="Origin" TextMode="MultiLine"></asp:TextBox><br />
        <asp:Button runat="server" OnClick="OnProcessInput_Click" Text="Process Input"/><br />
        <asp:Label runat="server"  ID="ResultLabel" AssociatedControlID="Result"></asp:Label><br />
        <asp:TextBox runat="server" ID="Result" ReadOnly="true" TextMode="MultiLine"></asp:TextBox><br />
    </form>
</body>
</html>
