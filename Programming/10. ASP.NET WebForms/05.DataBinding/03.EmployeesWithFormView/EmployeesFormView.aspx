<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesFormView.aspx.cs" Inherits="_03.EmployeesWithFormView.EmployeesFormView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees with Form View</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView runat="server" ID="EmployeesGridView" AutoGenerateColumns="false">
            <Columns>
                <asp:HyperLinkField runat="server" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="EmployeesFormView.aspx?id={0}" DataTextField="Name" HeaderText="Exployees"/>
            </Columns>
        </asp:GridView>
        <asp:FormView ID="EmployeeFormView" runat="server" ItemType="NorthwindData.Employees" DataKeyName="ID">
            <ItemTemplate>
                <h3><%#: Item.FirstName + " " + Item.LastName %></h3>
                <table border="0">
                    <tr>
                        <td>HomePhone:</td>
                        <td><%#: Item.HomePhone %></td>
                    </tr>
                    <tr>
                        <td>Notes:</td>
                        <td><%#: Item.Notes %></td>
                    </tr>
                </table>
                <hr />
            </ItemTemplate>
            <EditItemTemplate>
                <h3><%#: Item.FirstName + " " + Item.LastName %></h3>
                <table border="0">
                    <tr>
                        <td>HomePhone:</td>
                        <td><asp:TextBox ID="HomePhoneTextBox" runat="server" 
                            Text="<%#: Item.HomePhone %>" /> </td>
                    </tr>
                    <tr>
                        <td>Notes:</td>
                        <td><asp:TextBox ID="NotesTextBox" runat="server" 
                            Text="<%#: Item.Notes %>"  /> </td>
                    </tr>
                </table>
                <hr />
            </EditItemTemplate>
        </asp:FormView>
        <asp:MultiView ID="MultiViewButtons" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewNormalMode" runat="server">
                <asp:LinkButton ID="LinkButtonEdit" runat="server" OnClick="LinkButtonEdit_Click" Text="Edit" />
            </asp:View>
            <asp:View ID="ViewEditMode" runat="server">
                <asp:LinkButton ID="LinkButtonSave" runat="server" OnClick="LinkButtonSave_Click" Text="Save" />
                <asp:LinkButton ID="LinkButtonCancel" runat="server" OnClick="LinkButtonCancel_Click" Text="Cancel" />
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
