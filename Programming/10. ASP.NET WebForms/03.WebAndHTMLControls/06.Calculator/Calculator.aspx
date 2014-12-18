<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="_06.Calculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculator</title>
    <link href="styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td><asp:Label runat="server" ID="Screen" CssClass="screen"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" CssClass="btn" Text="1" CommandName="1" OnCommand="Number_Command"/>
                    <asp:Button runat="server" CssClass="btn" Text="2" CommandName="2" OnCommand="Number_Command" />
                    <asp:Button runat="server" CssClass="btn" Text="3" CommandName="3" OnCommand="Number_Command"/>
                    <asp:Button runat="server" CssClass="btn" Text="+" CommandName="+" OnCommand="Operation_Command"/><br />
                    <asp:Button runat="server" CssClass="btn" Text="4" CommandName="4" OnCommand="Number_Command"/>
                    <asp:Button runat="server" CssClass="btn" Text="5" CommandName="5" OnCommand="Number_Command"/>
                    <asp:Button runat="server" CssClass="btn" Text="6" CommandName="6" OnCommand="Number_Command"/>
                    <asp:Button runat="server" CssClass="btn" Text="-" CommandName="-" OnCommand="Operation_Command"/><br />
                    <asp:Button runat="server" CssClass="btn" Text="7" CommandName="7" OnCommand="Number_Command"/>
                    <asp:Button runat="server" CssClass="btn" Text="8" CommandName="8" OnCommand="Number_Command"/>
                    <asp:Button runat="server" CssClass="btn" Text="9" CommandName="9" OnCommand="Number_Command"/>
                    <asp:Button runat="server" CssClass="btn" Text="X" CommandName="X" OnCommand="Operation_Command" /><br />
                    <asp:Button runat="server" CssClass="btn" Text="Clear" OnClick="Clear_Click" />
                    <asp:Button runat="server" CssClass="btn" Text="0" CommandName="0" OnCommand="Number_Command"/>
                    <asp:Button runat="server" CssClass="btn" Text="/" CommandName="/" OnCommand="Operation_Command"/>
                    <asp:Button runat="server" CssClass="btn" Text="&radic;" CommandName="sqrt" OnCommand="Operation_Command"/>
                </td>
            </tr>
            <tr>
                <td><asp:Button runat="server" ID="Equals" CssClass="equals" Text="=" OnClick="Equals_Click"/></td>
            </tr>
        </table>
    </form>
</body>
</html>
