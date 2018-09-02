<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SmsDetails.aspx.cs" Inherits="PopUpFile_SmsDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../KResource/CSS/ControllerCSS.css" rel="stylesheet" type="text/css" />
    <link href="../KResource/CSS/Home.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="tblSubFull2" border="1">
            <tr>
                <td align="left">
                    Send From :
                </td>
                <td align="left" width="50%">
                    <asp:Label ID="lblSendFrom" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Sent To :
                </td>
                <td align="left">
                    <asp:Label ID="lblSendTo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Send Message :
                </td>
                <td align="left">
                    <asp:Label ID="lblSentMgs" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Date :
                </td>
                <td align="left">
                    <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
