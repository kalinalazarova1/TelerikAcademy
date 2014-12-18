﻿<%@ Page Language="C#" Title="Registration Form" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="_01_02.RegistrationForm.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h2><%: Title %>.</h2>
    <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Username" CssClass="col-md-2 control-label">Username</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="Username" CssClass="form-control" placeholder='Username' MaxLength="30" />
                <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="Username"
                    ValidationExpression=".{3}.*"
                    CssClass="text-danger" ErrorMessage="Minimum username length is 3." />
                <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="Username"
                    CssClass="text-danger" ErrorMessage="The username field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">First Name</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" placeholder='First Name' MaxLength="30" />
                <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="FirstName"
                    ValidationExpression=".{3}.*"
                    CssClass="text-danger" ErrorMessage="Minimum first name length is 3." />
                <asp:RequiredFieldValidator Display="Dynamic" runat="server" ControlToValidate="FirstName"
                    CssClass="text-danger" ErrorMessage="The first name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 control-label">Last Name</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="LastName" CssClass="form-control" placeholder='Last Name' MaxLength="30" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="LastName"
                    ValidationExpression=".{3}.*"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Minimum last name length is 3." />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The last name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Age" CssClass="col-md-2 control-label">Age</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="Age" CssClass="form-control" placeholder='Age' MaxLength="30" TextMode="Number" />
                <asp:RangeValidator runat="server" ControlToValidate="Age" CssClass="text-danger" MinimumValue="18" MaximumValue="81" Display="Dynamic" ErrorMessage="The age should be between 18 and 81" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The last name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" Display="Dynamic" TextMode="Email" placeholder="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The email field is required." />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="Email"
                    ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Email format is invalid" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Address" CssClass="col-md-2 control-label">Address</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="Address" CssClass="form-control" Display="Dynamic" placeholder='Address' MaxLength="200" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Address"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The address field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Phone" CssClass="col-md-2 control-label"  Display="Dynamic">Telephone</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="Phone" CssClass="form-control" Display="Dynamic" TextMode="Phone" placeholder="Telephone" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Phone"
                    CssClass="text-danger" ErrorMessage="The telephone field is required." />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="Phone"
                    ValidationExpression="[0-9]{4,15}"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Phone format is invalid only numbers are allowed" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label" Display="Dynamic">Password</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" Display="Dynamic" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label" Display="Dynamic" >Confirm password</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control"  Display="Dynamic"  />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Accept" CssClass="col-md-2 control-label" Display="Dynamic" >I accept</asp:Label>
            <div class="col-md-8">
                <asp:CheckBox runat="server" ID="Accept" />
                <asp:CustomValidator runat="server" ID="CheckBoxRequired" EnableClientScript="true" OnServerValidate="CheckBoxRequired_ServerValidate"
                ClientValidationFunction="CheckBoxRequired_ClientValidate">You must select this box to proceed.</asp:CustomValidator>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-8">
                <asp:Button runat="server" ID="Register" Text="Register" OnClick="Register_Click" CssClass="btn btn-primary" />
                <a href="/" class="btn btn-default">Cancel</a>
            </div>
        </div>
    </div>
    </form>
</body>
</html>