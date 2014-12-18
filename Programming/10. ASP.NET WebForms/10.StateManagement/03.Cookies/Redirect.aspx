<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Redirect.aspx.cs" Inherits="_03.Cookies.Redirect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Refresh the page after 10 seconds to see that cookie expires:<br />
        <asp:Literal runat="server" ID="Info"></asp:Literal>
    </form>
</body>
</html>
