<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EventPrint.aspx.cs" Inherits="html_EventPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        @media print
        {
            body
            {
                background-color: #FFFFFF;
                background-image: none;
                color: #000000;
            }
            .hidewhileprinting
            {
                display: none;
            }
        }
    </style>

    <script type="text/javascript">

        window.print();
       
    </script>

</head>
<body>
    <%--<asp:Image ID="Image2" runat="server" ImageUrl="~/resources1/images/GaneshPhoto.jpg"
                                            Width="142px" />--%>
    <form id="form1" runat="server">
    <div>
        <center>
            <div style="margin-top: 40px">
                <div id="DivId" style="width: 700px; height: 500px; background-color: #dddddd; border: 1px solid #009999;">
                    <div style="margin-top: 100px">
                        <table>
                            <tr>
                                <td align="left">
                                    To
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Shri/Smt -
                                    <asp:Label ID="lblPreshak" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Address -
                                    <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Dear Sir/Madam,
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Received your
                                    invitation of marriage of
                                    <asp:Label ID="lblBrideName" runat="server" Text="" isCharKey=""></asp:Label>
                                    &nbsp;and&nbsp;
                                    <asp:Label ID="lblGroomName" runat="server" Text=""></asp:Label>
                                    <br />
                                    on date
                                    <asp:Label ID="lblDateOfMarrage" runat="server" Text=""></asp:Label>
                                    .<br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblMgs" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Thanks You
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="right">
                                    Your Faithfully
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblFaithfully" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:Button ID="PrintButton" runat="server" class="hidewhileprinting" Style="position: static;
                        border: solid 1px #1f345f; background-color: #009999; font-family: Arial; font-size: 12px;
                        color: White; font-weight: bold;" Text="Print"/>
                    <asp:Button ID="btnBack" runat="server" class="hidewhileprinting" Style="position: static;
                        border: solid 1px #1f345f; background-color: #009999; font-family: Arial; font-size: 12px;
                        color: White; font-weight: bold;" Text="Back" PostBackUrl="~/html/EventMyct.aspx" />
                </div>
            </div>
        </center>
    </div>
    <%-- <div>
        <center>
            <table>
                <tr>
                    <td colspan="2">
                        <div id="DivPrint" runat="server">
                            <table>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/resources1/images/GaneshPhoto.jpg"
                                            Width="142px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Bride Name:-
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        Groom Name:-
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        Invitaion From:-
                                        <asp:Label ID="lblInvitationFrom" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Date Of Merrage:-
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Time of Merrage:-
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTimeOfMarrage" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Location/Venue:-
                                    </td>
                                    <td>
                                        <asp:Label ID="lblLocation" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Preshek:-
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Mobile No:-
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Address:-
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                                                            </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="PrintButton" runat="server" class="hidewhileprinting" Style="position: static"
                            Text="Print" />
                        <asp:Button ID="btnBack" runat="server" class="hidewhileprinting" Style="position: static"
                            Text="Back" PostBackUrl="~/html/EventMyct.aspx" />
                    </td>
                </tr>
            </table>
        </center>
    </div>--%>
    </form>
</body>
</html>
