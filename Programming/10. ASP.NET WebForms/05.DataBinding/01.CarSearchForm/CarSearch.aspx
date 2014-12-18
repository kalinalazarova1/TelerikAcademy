<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarSearch.aspx.cs" Inherits="_01.CarSearchForm.CarSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Car Search</title>
</head>
<body>
    <form id="CarSearchForm" runat="server">
        <asp:Label runat="server" AssociatedControlID="ProducerDropDown">Producer: </asp:Label>
        <asp:DropDownList runat="server" ID="ProducerDropDown" AutoPostBack="true" OnSelectedIndexChanged="ProducerDropDown_SelectedIndexChanged" ItemType="_01.CarSearchForm.Producer"></asp:DropDownList><br />
        <asp:Label runat="server" AssociatedControlID="ModelDropDown">Model: </asp:Label>
        <asp:DropDownList runat="server" ID="ModelDropDown"></asp:DropDownList><br />
        <asp:Label runat="server" AssociatedControlID="ExtrasCheckBoxList">Extras: </asp:Label>
        <asp:CheckBoxList runat="server" ID="ExtrasCheckBoxList"></asp:CheckBoxList><br />
        <asp:Label runat="server" AssociatedControlID="EnginRadioButtonList">Engine: </asp:Label>
        <asp:RadioButtonList runat="server" ID="EnginRadioButtonList"></asp:RadioButtonList><br />
        <asp:Button runat="server" Text="Search" OnClick="Search_Click"/><br />
        <hr />
        <asp:Literal runat="server" ID="Result"></asp:Literal>
    </form>
</body>
</html>
