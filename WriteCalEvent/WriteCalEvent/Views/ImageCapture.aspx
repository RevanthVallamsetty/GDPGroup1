<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="ImageCapture.aspx.cs" Inherits="WriteCalEvent.ImageCapture" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="~/Scripts/bootstrap.js"></script>
    <script src='<%=ResolveUrl("~/Webcam_Plugin/jquery.webcam.js") %>' type="text/javascript"></script>
    <script type="text/javascript">
        var pageUrl = '<%=ResolveUrl("~/Views/ImageCapture.aspx") %>';
        $(function () {
            jQuery("#webcam").webcam({
                width: 320,
                height: 240,
                mode: "save",
                swffile: '<%=ResolveUrl("~/Webcam_Plugin/jscam.swf") %>',
                debug: function (type, status) {
                    $('#camStatus').append(type + ": " + status + '<br /><br />');
                },
                onSave: function (data) {
                    $.ajax({
                        type: "POST",
                        url: pageUrl + "/GetCapturedImage",
                        data: '',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (r) {
                            $("[id*=imgCapture]").css("visibility", "visible");
                            $("[id*=imgCapture]").attr("src", r.d);
                        },
                        failure: function (response) {
                            alert(response.d);
                        }
                    });
                },
                onCapture: function () {
                    webcam.save(pageUrl);
                }
            });
        });
        function Capture() {
            webcam.capture();
            return false;
        }
    </script>

    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <u>Live Camera</u>
            </td>
            <td></td>
            <td align="center">
                <u>Captured Picture</u>
            </td>
        </tr>
        <tr>
            <td>
                <div id="webcam">
                </div>
            </td>
            <td>&nbsp;
            </td>
            <td>
                <asp:Image ID="imgCapture" runat="server" Style="visibility: hidden; width: 320px; height: 240px" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnCapture" Text="Capture" runat="server" OnClientClick="return Capture();" />
    <br />
    <span id="camStatus"></span>
</asp:Content>

