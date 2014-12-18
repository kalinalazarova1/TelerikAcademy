<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_04.DeleteViewState.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="libs/jquery-1.11.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Literal ID="Result" runat="server"></asp:Literal><br />
        Type Something Here:
        <asp:TextBox ID="Test" runat="server"></asp:TextBox><br />
        <asp:Button ID="Sumbit" runat="server" Text="Submit with Viewstate" OnClick="Sumbit_Click" /><br />
        <div id="delete">
            <asp:Button ID="DeleteVS" runat="server" Text="Submit without Viewstate" OnClick="DeleteVS_Click" />
        </div>
        
    </div>
    </form>
    <script>
        $(document).ready(function() {
            $("#delete").on("click", function () {
                var viewState = document.getElementById('__VIEWSTATE');viewState.parentNode.removeChild(viewState);
            });
        });
    </script>
</body>
</html>
