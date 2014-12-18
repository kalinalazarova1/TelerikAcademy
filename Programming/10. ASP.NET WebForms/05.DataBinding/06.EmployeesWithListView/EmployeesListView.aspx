<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesListView.aspx.cs" Inherits="_06.EmployeesWithListView.EmployeesListView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees With List View</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ListView ID="EmployeesDataListView" runat="server" ItemType="NorthwindData.Employees">
            <LayoutTemplate>
                <h3>Employees</h3>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>

            <ItemSeparatorTemplate>
                <hr />
            </ItemSeparatorTemplate>
            
            <ItemTemplate>
                <div>
                    <h4><%#: Item.FirstName %> <%#: Item.LastName %></h4>
                    Title: <%#: Item.Title %><br />
                    Hire Date: <%#: string.Format("{0:dd/MM/yyyy}", Item.HireDate) %>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <hr />
        <asp:DataPager ID="EmployeesDataPager" runat="server"
            PagedControlID="EmployeesDataListView" PageSize="4"
            QueryStringField="page">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="true"
                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowLastPageButton="true"
                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
            </Fields>
        </asp:DataPager>
    </form>
</body>
</html>
