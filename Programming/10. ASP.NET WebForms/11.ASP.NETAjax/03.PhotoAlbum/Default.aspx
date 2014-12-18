<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_03.PhotoAlbum.Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>  


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Main.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.0.3.min.js"></script>
</head>
<body>
    <form id="formDefault" runat="server">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManagerSlider" runat="server"></ajaxToolkit:ToolkitScriptManager>
        <h1 style="text-align: center;">Ajax Control Toolkit Slideshow</h1>
        <asp:Image ID="ImageHolder" runat="server" />
        <ajaxToolkit:SlideShowExtender ID="ImageHolder_SlideShowExtender" runat="server"
            Enabled="True" ImageDescriptionLabelID="LabelDescription"
            SlideShowServiceMethod="GetSlides" AutoPlay="true"
            NextButtonID="ButtonNext" PreviousButtonID="ButtonPrevious"
            TargetControlID="ImageHolder" Loop="true">
        </ajaxToolkit:SlideShowExtender>
        <br />
        <div style="text-align: center;">
            <asp:Button ID="ButtonPrevious" runat="server" Text="<<" />
            <asp:Button ID="ButtonNext" runat="server" Text=">>" />
            <asp:Label ID="LabelDescription" runat="server"></asp:Label>
        </div>
    </form>
    <script>
        (function () {
            $("#formDefault").on("click", ".image-holder", function (ev) {
                var path = $(".description").text();

                window.open(path + '.png', 'Popup', 'toolbar=no, location=yes, status=no, menubar=no, scrollbars=no, resizable=no, width=332, height=429, left=430, top=23');
            });
        })();
    </script>
</body>
</html>

</body>
</html>
