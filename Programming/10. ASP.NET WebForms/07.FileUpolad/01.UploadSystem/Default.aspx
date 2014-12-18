<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_01.UploadSystem.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upolad System</title>
</head>
<body>
    <form id="FileUploadForm" runat="server">
        <h2>Please upload only zipped text files:</h2>
    <asp:FileUpload ID="FileUploadControl" runat="server" />
        <asp:Button runat="server" ID="UploadButton" Text="Upload" OnClick="UploadButton_Click" />
        <br />
        <asp:Repeater runat="server" ID="FilesRepeater" ItemType="_02.FileUpload.Data.FileModel" SelectMethod="FilesRepeater_GetData">
            <ItemTemplate>
                <div>
                    <h3 runat="server"><%#: Item.Name %></h3>
                    <p runat="server"><%#: Item.Content %></p>
                </div>
            </ItemTemplate>
            <HeaderTemplate>
                <h1>All Files:</h1>
            </HeaderTemplate>
            <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
