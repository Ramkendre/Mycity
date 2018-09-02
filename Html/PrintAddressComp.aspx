<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintAddressComp.aspx.cs"
    Inherits="html_PrintAddressComp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script src="../Scripts/TurmsC.js" type="text/javascript"></script>

    <style type="text/css">
        @media print
        {
            input#btnPrint
            {
                display: none;
            }
        }
        label
        {
            width: 100px;
        }
    </style>
    <style type="text/css">
        .protected
        {
            -moz-user-select: none;
            -webkit-user-select: none;
            user-select: none;
        }
    </style>

    <script language="javascript" type="text/javascript">
        function disableselect(e) {
            return false
        }
        function reEnable() {
            return true
        }
        document.onselectstart = new Function("return false")
        if (window.sidebar) {
            document.onmousedown = disableselect                    // for mozilla           
            document.onclick = reEnable
        }
        function clickIE() {
            if (document.all) {
                (message);
                return false;
            }
        }
        document.oncontextmenu = new Function("return false")
        var element = document.getElementById('tbl');
        element.onmousedown = function() { return false; }        // For Mozilla Browser
    </script>

    <link rel="stylesheet" type="text/css" href="../CSS/StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <div>
            <input id="btnPrint" type="button" value="Print" onclick="window.print()" />
            <asp:Label ID="Label2" runat="server" Text="" Visible="false"></asp:Label>
        </div>
        <div style="margin-top: 20px; width: 900px; height: auto" onclick="click()" id="test"
            onmousedown='return false;' onselectstart='return false;'>
            <asp:DataList ID="Datalist1" runat="server" RepeatDirection="Horizontal" RepeatColumns="3"
                RepeatLayout="Table" Width="900px" on>
                <ItemTemplate>
                    <div class="protected">
                        <%-- <table cellspacing="15px">
                            <tr>
                                <td id="id23" runat="server" style="width: 330px; font-size: 18px">
                                    <asp:Label ID="Label3" runat="server" Font-Bold="true" Text='<%#Eval("usrFullName")%>'></asp:Label><br />
                                    <span style="font-weight: bold">Add:</span>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("usrAddress")%>'></asp:Label>
                                    <br />
                                    <span style="font-weight: bold">Pin.:</span>
                                    <%#Eval("usrPIN")%>
                                    &nbsp;<span style="font-weight: bold">(Via www.myct.in)</span>
                                </td>
                            </tr>
                        </table>--%>
                        <table cellspacing="15px" width="400px">
                            <tr>
                                <td id="id23" runat="server" style="width: 330px; font-size: 18px">
                                    <asp:Label ID="Label5" runat="server" Font-Bold="true" Text='<%#Eval("usrCompanyName")%>'></asp:Label><br />
                                    <asp:Label ID="Label3" runat="server" Font-Bold="true" Text='<%#Eval("usrFullName")%>'></asp:Label><br />
                                    <span style="font-weight: bold">Add:</span>
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("usrAddress")%>'></asp:Label>
                                    <br />
                                    <span style="font-weight: bold">Mobile no:</span>
                                    <%#Eval("usrMobileno")%>
                                    &nbsp;<span style="font-weight: bold"><br />(Via www.myct.in)</span>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </center>
    </form>
</body>
</html>
<%--, District: <%#Eval("distName")%>--%>
<%-- City:<asp:Label ID="Label5" runat="server" Text='<%#Eval("cityName")%>'></asp:Label>,
                                District:<asp:Label ID="Label6" runat="server" Text='<%#Eval("distName")%>'></asp:Label>--%>
<%-- <tr align="right">
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Via.myct.in" Font-Bold="True" Font-Underline="False"
                                            ForeColor="Black"></asp:Label>
                                    </td>
                                </tr>--%>
<%--<AlternatingItemStyle BorderStyle="Solid" BorderWidth="1px" />
            <ItemStyle BorderStyle="Solid" BorderWidth="1px" />--%>