<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server" />
        <div>
            <h1>Employees</h1>
            <asp:GridView ID="GridViewEmployees"
                runat="server" AutoGenerateColumns="False" 
                DataKeyNames="EmployeeID" 
                DataSourceID="EntityDataSourceEmployees" 
                OnSelectedIndexChanged="GridViewEmployees_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" ReadOnly="True" SortExpression="EmployeeID" Visible="false" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="TitleOfCourtesy" HeaderText="TitleOfCourtesy" SortExpression="TitleOfCourtesy" />
                    <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" SortExpression="BirthDate" />
                    <asp:BoundField DataField="HireDate" HeaderText="HireDate" SortExpression="HireDate" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                    <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                    <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" SortExpression="PostalCode" />
                    <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                    <asp:BoundField DataField="HomePhone" HeaderText="HomePhone" SortExpression="HomePhone" />
                    <asp:BoundField DataField="Extension" HeaderText="Extension" SortExpression="Extension" />
                    <asp:BoundField DataField="ReportsTo" HeaderText="ReportsTo" SortExpression="ReportsTo" />
                </Columns>
                </asp:GridView>
            <br />
            <asp:EntityDataSource ID="EntityDataSourceEmployees" 
                runat="server" 
                ConnectionString="name=NorthwindEntities" 
                DefaultContainerName="NorthwindEntities" 
                EnableFlattening="False" 
                EntitySetName="Employees" 
                EntityTypeFilter="Employee"
                Include="Orders">
            </asp:EntityDataSource>
            <asp:EntityDataSource 
                ID="EntityDataSourceOrders" 
                runat="server" 
                ConnectionString="name=NorthwindEntities" 
                DefaultContainerName="NorthwindEntities" 
                EnableFlattening="False" 
                EntitySetName="Orders" 
                EntityTypeFilter="Order"
                Where="it.EmployeeID=@EmployeeID" Include="Employee">
                <WhereParameters>
                    <asp:ControlParameter Name="EmployeeID" Type="Int32"
                        ControlID="GridViewEmployees" />
                </WhereParameters>
            </asp:EntityDataSource>
            <asp:UpdateProgress ID="UpdateProgressOrders" runat="server" DisplayAfter="100">
                <ProgressTemplate>
                    <img src="Images/Loading.gif" alt="Loading..." width="50" height="50" />
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <h1>Orders</h1>
            <asp:UpdatePanel ID="UpdatePanelOrders" runat="server" UpdateMode="Conditional">

                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridViewEmployees"
                            EventName="SelectedIndexChanged" />
                    </Triggers>

                    <ContentTemplate>
                        <asp:GridView ID="GridViewOrders"
                                runat="server" 
                            DataSourceID="EntityDataSourceOrders">
                            </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
