<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="_02.Employees.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees</title>
</head>
<body>
    <h3>Employees List</h3>
    <form id="form1" runat="server">
        <asp:GridView runat="server" ID="EmployeesGridView" AutoGenerateColumns="false">
            <Columns>
                <asp:HyperLinkField runat="server" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="EmpDetails.aspx?id={0}" DataTextField="Name" HeaderText="Exployees"/>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
