<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_02.World.WebForms.Default" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:EntityDataSource 
            ID="EntityDataSourceContinents" 
            runat="server" 
            ConnectionString="name=WorldEntities" 
            DefaultContainerName="WorldEntities" 
            EnableFlattening="False" 
            EntitySetName="Continents">
        </asp:EntityDataSource>
    
    </div>
        <h1>Continents</h1>
        <asp:ListBox 
            ID="ListBoxContinents" 
            runat="server" 
            AutoPostBack="True" 
            DataSourceID="EntityDataSourceContinents" 
            DataTextField="Name" 
            DataValueField="Id">
        </asp:ListBox>

        <asp:EntityDataSource 
            ID="EntityDataSourceCountries" 
            runat="server" 
            ConnectionString="name=WorldEntities" 
            DefaultContainerName="WorldEntities" 
            EnableDelete="True" 
            EnableFlattening="False" 
            EnableInsert="True" 
            EnableUpdate="True" 
            EntitySetName="Countries" 
            Include="Continent"
            Where="it.ContinentID=@ContID">
            <WhereParameters>
                <asp:ControlParameter Name="ContID" Type="Int32" ControlID="ListBoxContinents" />
            </WhereParameters>
        </asp:EntityDataSource>

        <h1>Countries</h1>
        <asp:GridView 
            ID="GridViewCountries" 
            runat="server" 
            AllowPaging="true"
            AllowSorting ="true" 
            AutoGenerateColumns="False" 
            DataKeyNames="Id" 
            OnSelectedIndexChanged="GridViewCountries_SelectedIndexChanged" 
            DataSourceID="EntityDataSourceCountries">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="ContinentId" ReadOnly="True" HeaderText="ContinentId" SortExpression="ContinentId" />
                <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
                <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language" />
                <asp:ImageField DataImageUrlField="Id" ReadOnly="true" DataImageUrlFormatString="~/ImageHttpHandler.ashx?id={0}" HeaderText="Flag">
                    <ControlStyle Height="20px" Width="30px" />
                </asp:ImageField>
            </Columns>
            <EmptyDataTemplate>
                No Countries found
            </EmptyDataTemplate>
        </asp:GridView>
        <br />
        Country Name:
        <asp:TextBox ID="txtCountryName" runat="server"></asp:TextBox><br />
        Country Population:
        <asp:TextBox ID="txtCountryPopulation" runat="server"></asp:TextBox><br />
        Country Language:
        <asp:TextBox ID="txtCountryLanguage" runat="server"></asp:TextBox><br />
        Country Flag:
        <asp:FileUpload ID="flagPicture" runat="server" />
        <br />
        <asp:Button ID="btnSaveCountry" runat="server" OnClick="btnSaveCountry_Click" Text="Save Country" />
        <br />
        Change Flag:
        <asp:Literal runat="server" ID="ChangeFlagCountryName" />
        <asp:FileUpload ID="changeFlagPicture"  runat="server" />
        <asp:Button ID="btnChangeFlag" runat="server" OnClick="btnChangeFlag_Click" Text="Save Flag" />

        <asp:EntityDataSource 
            ID="EntityDataSourceTowns" 
            runat="server" 
            ConnectionString="name=WorldEntities" 
            DefaultContainerName="WorldEntities" 
            EnableDelete="True"
            EnableFlattening="False" 
            EnableInsert="True" 
            EnableUpdate="True" 
            EntitySetName="Towns"
            Include="Country"
            Where="it.CountryID=@CounID">
            <WhereParameters>
                <asp:ControlParameter Name="CounID" Type="Int32" ControlID="GridViewCountries" />
            </WhereParameters>
        </asp:EntityDataSource>

        <h1>Towns</h1>
        <asp:ListView 
            ID="ListViewTowns" 
            runat="server" 
            DataKeyNames="Id" 
            DataSourceID="EntityDataSourceTowns" 
            InsertItemPosition="None" 
            OnItemInserted="ListViewTowns_ItemInserted">
            <EditItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        <asp:Label ID="IdLabel1" runat="server" Text='<%#: Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%#: Bind("Name") %>' />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="NameTextBox" ErrorMessage="Field Name is required."></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%#: Bind("Population") %>' />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="PopulationTextBox" ErrorMessage="Field Population is required."></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="CountryIdTextBox" runat="server" Text='<%#: Bind("CountryId") %>' />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="CountryIdTextBox" ErrorMessage="Field CountryId is required."></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="CountryNameLabel" runat="server" Text='<%#: Eval("Country.Name") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
                <asp:Button ID="ShowInsertTemplate" runat="server" Text="Insert Form" OnClick="ButtonInsertFormTown_Click" />
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" OnClick="CancelButton_Click" Text="Cancel" />
                    </td>
                    <td>
                        <asp:Label ID="IdLabelInsert" runat="server" Text='<%#: Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%#: Bind("Name") %>' />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="NameTextBox" ErrorMessage="Field Name is required"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%#: Bind("Population") %>' />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="NameTextBox" ErrorMessage="Field Population is required"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="CountryIdTextBox" runat="server" Text='<%#: Bind("CountryId") %>' />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="NameTextBox" ErrorMessage="Field CountryId is required"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="CountryTextBox" runat="server" Text='<%#: Eval("Country") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="IdLabel" runat="server" Text='<%#: Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%#: Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%#: Eval("Population") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CountryIdLabel" runat="server" Text='<%#: Eval("CountryId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%#: Eval("Country.Name") %>' />
                    </td>
                </tr>
                
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                <tr runat="server" style="">
                                    <th runat="server">
                                        Actions
                                    </th>
                                    <th runat="server">
                                        <asp:LinkButton runat="server" ID="SortById" CommandName="Sort" CommandArgument="Id">
                                        Id
                                        </asp:LinkButton>
                                    </th>
                                    <th runat="server">
                                        <asp:LinkButton runat="server" ID="SortByName" CommandName="Sort" CommandArgument="Name">
                                        Name
                                        </asp:LinkButton>
                                    </th>
                                    <th runat="server">
                                        <asp:LinkButton runat="server" ID="SortByPopulation" CommandName="Sort" CommandArgument="Population">
                                        Population
                                        </asp:LinkButton>
                                    </th>
                                    <th runat="server">CountryId</th>
                                    <th runat="server">Country</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="ShowInsertTemplate" runat="server" Text="Insert Form" OnClick="ButtonInsertFormTown_Click" />
                <asp:DataPager ID="DataPagerTowns" runat="server" PagedControlID="ListViewTowns" PageSize="2">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="true"
                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowLastPageButton="true"
                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
            </Fields>
        </asp:DataPager>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    </td>
                    <td>
                        <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Eval("CountryId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        
    </form>
</body>
</html>
