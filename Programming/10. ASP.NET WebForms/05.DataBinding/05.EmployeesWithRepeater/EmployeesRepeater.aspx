<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesRepeater.aspx.cs" Inherits="_05.EmployeesWithRepeater.EmployeesRepeater" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee with repeater</title>
</head>
<body>
    <form id="form1" runat="server">
        <h3>Employees</h3>
        <asp:Repeater ID="EmployeesItemsRepeater" runat="server" ItemType="NorthwindData.Employees">
            <ItemTemplate>
                <h3>Name: <%#: Item.FirstName %> <%#: Item.LastName %></h3>
                <p><strong>Position: </strong><%#: Item.Title %></p>
                <p><strong>Date of Birth: </strong><%#: Item.BirthDate %></p>
                <p><strong>Notes: </strong><%#: Item.Notes %>  </p>
                <hr />
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
