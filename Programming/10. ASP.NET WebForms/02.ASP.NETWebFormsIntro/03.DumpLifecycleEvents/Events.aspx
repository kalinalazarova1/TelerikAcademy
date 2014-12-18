<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="_03.DumpLifecycleEvents.Events" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lifecycle Events</title>
</head>
<body>
    <h2>Lifecycle Events:</h2>
    <div runat="server" id="Result"></div>
    <form id="formMain" runat="server">
        <asp:Button ID="ButtonOK" Text="OK" runat="server"
            OnInit="ButtonOK_Init" OnLoad="ButtonOK_Load" OnClick="ButtonOK_Click"
            OnPreRender="ButtonOK_PreRender" />
    </form>
</body>
</html>
