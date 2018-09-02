<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KeyDetails.aspx.cs" Inherits="PopUpFile_KeyDetails" %>

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
                    Keyword Name :
                </td>
                <td align="left" width="50%">
                    <asp:Label ID="lblKeywordName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Keyword Syntax :
                </td>
                <td align="left">
                    <asp:Label ID="lblKeywordSyntax" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Keyword purpose :
                </td>
                <td align="left">
                    <asp:Label ID="lblKeywordPurpose" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Keyword Discription :
                </td>
                <td align="left">
                    <asp:Label ID="lblKeyDiscip" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Website / Group :
                </td>
                <td align="left">
                    <asp:Label ID="lblWebsiteGroup" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left">
                    Create Date :
                </td>
                <td align="left">
                    <asp:Label ID="lblEntryDate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
