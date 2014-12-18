<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpDetails.aspx.cs" Inherits="_02.Employees.EmpDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees Details</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DetailsView runat="server" ID="EmployeeDetailView"></asp:DetailsView>
        <asp:Button runat="server" Text="Back to List" PostBackUrl="~/Employees.aspx" />
    </form>
</body>
</html>
