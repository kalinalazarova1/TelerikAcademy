<%@ Page Language="C#"
     AutoEventWireup="true"
     CodeBehind="RandomNumber.aspx.cs"
     Inherits="_02.WebServerControls.RandomNumber"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Random Number In Range</title>
</head>
<body>
    <form runat="server">
        <asp:Label runat="server" AssociatedControlID="Min">Lower Limit: </asp:Label>
        <asp:TextBox runat="server" ID="Min"></asp:TextBox><br />
        <asp:Label runat="server" AssociatedControlID="Max">Upper Limit: </asp:Label>
        <asp:TextBox runat="server" ID="Max"></asp:TextBox><br />
        <asp:Button runat="server" ID="Generate" Text="Generate" OnClick="Generate_Click" /><br />
        <asp:Literal runat="server" ID="GeneratedNumber" ></asp:Literal>
    </form>
</body>
</html>
