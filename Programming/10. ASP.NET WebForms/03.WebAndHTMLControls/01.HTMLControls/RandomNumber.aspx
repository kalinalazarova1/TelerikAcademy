<%@ Page Language="C#"
     AutoEventWireup="true"
     CodeBehind="RandomNumber.aspx.cs"
     Inherits="_01.HTMLControls.RandomNumber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Random Number</title>
</head>
<body>
    <h2>Generate Random Number In Range:</h2>
    <form id="RangeForm" runat="server">
        <label runat="server" for="Min">Lower limit:</label>
        <input type="number" runat="server" id="Min" />
        <label runat="server" for="Max">Upper limit:</label>
        <input type="number" runat="server" id="Max" />
        <input type="submit" runat="server" value="Generate" onserverclick="OnGenerate_ServerClick"/>
    </form>
    Generated Random Number: <span runat="server" id="RamdomNumber"></span>
</body>
</html>
