<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicTacToe.aspx.cs" Inherits="_05.TicTacToe.TicTacToe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tic Tac Toe</title>
    <link href="styles.css" rel="stylesheet" />
</head>
<body>
    <h1>Tic Tac Toe</h1>
    <h3>The player always starts first and the computer never loses (if you want to win see the comments in Play method)</h3>
    <form id="form1" runat="server">
        <asp:Literal runat="server" ID="Message"></asp:Literal><br />
        <asp:Button runat="server" CssClass="field" OnCommand="Play_Command" CommandArgument="0" ID="cell0"/>
        <asp:Button runat="server" CssClass="field" OnCommand="Play_Command" CommandArgument="1" ID="cell1"/>
        <asp:Button runat="server" CssClass="field" OnCommand="Play_Command" CommandArgument="2" ID="cell2"/><br />
        <asp:Button runat="server" CssClass="field" OnCommand="Play_Command" CommandArgument="3" ID="cell3"/>
        <asp:Button runat="server" CssClass="field" OnCommand="Play_Command" CommandArgument="4" ID="cell4"/>
        <asp:Button runat="server" CssClass="field" OnCommand="Play_Command" CommandArgument="5" ID="cell5"/><br />
        <asp:Button runat="server" CssClass="field" OnCommand="Play_Command" CommandArgument="6" ID="cell6"/>
        <asp:Button runat="server" CssClass="field" OnCommand="Play_Command" CommandArgument="7" ID="cell7"/>
        <asp:Button runat="server" CssClass="field" OnCommand="Play_Command" CommandArgument="8" ID="cell8"/><br />
        <asp:Button runat="server" Text="Start New Game" OnClick="Restart_Click" />
    </form>
</body>
</html>
