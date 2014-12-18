<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegForm.aspx.cs" Inherits="_04.RegistrationForm.RegForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
</head>
<body>
    <form id="Form" runat="server">
        <asp:Label runat="server" AssociatedControlID="FirstName" >First Name:</asp:Label>
        <asp:TextBox runat="server" ID="FirstName" ></asp:TextBox><br />
        <asp:Label runat="server" AssociatedControlID="LastName" >Last Name:</asp:Label>
        <asp:TextBox runat="server" ID="LastName" ></asp:TextBox><br />
        <asp:Label runat="server" AssociatedControlID="FacultyNumber" >Faculty Number:</asp:Label>
        <asp:TextBox runat="server" ID="FacultyNumber" ></asp:TextBox><br />
        <asp:Label runat="server" AssociatedControlID="Uni" >Univercity:</asp:Label>
        <asp:DropDownList runat="server" ID="Uni"></asp:DropDownList><br />
        <asp:Label runat="server" AssociatedControlID="Spec" >Specialty:</asp:Label>
        <asp:DropDownList runat="server" ID="Spec"></asp:DropDownList><br />
        <asp:Label runat="server" AssociatedControlID="SelectedCourses" >Courses:</asp:Label>
        <asp:ListBox runat="server" ID="SelectedCourses" SelectionMode="Multiple"></asp:ListBox><br />
        <asp:Button runat="server" UseSubmitBehavior="true" Text="Submit" OnClick="OnSubmit_Click" />
    </form>
    <div runat="server" id="Content"></div>
</body>
</html>
