<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_01.MenuControl.Default" %>
<%@ Register Src="~/MyMenu.ascx" TagPrefix="my" TagName="Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test My Menu</title>
    <link href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <my:Menu runat="server" ID="MainMenu" CssClass="my-menu"></my:Menu>
    </form>
</body>
</html>
