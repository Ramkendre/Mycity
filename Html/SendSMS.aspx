<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="SendSMS.aspx.cs" Inherits="Html_SendSMS" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>--%>
    <link href="../CSS/OutBox.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
        function myfun() {
            var textString = document.getElementById('<%=txtMsgBox.ClientID%>').value;
            var textString1 = document.getElementById('<%=txtGroupSMSMsg.ClientID%>').value;
            var textString2 = document.getElementById('<%=txtMsgBox.ClientID%>').value;
            //    alert (textString);
            var tfun2 = convertChar2CP(textString);
            //       alert (tfun2 );
            var textFin = convertCP2UTF16(tfun2);
            //       alert (textFin );
            document.getElementById('<%=txtUnicoded.ClientID%>').value = textFin;
        }
        function convertChar2CP(textString) {
            var outputString = "";
            var haut = 0;
            var n = 0;
            for (var i = 0; i < textString.length; i++) {
                var b = textString.charCodeAt(i);
                if (b < 0 || b > 0xFFFF) {
                    outputString += '!erreur ' + dec2hex(b) + '!';
                }
                if (haut != 0) {
                    if (0xDC00 <= b && b <= 0xDFFF) {
                        outputString += dec2hex(0x10000 + ((haut - 0xD800) << 10) + (b - 0xDC00)) + ' ';
                        haut = 0;
                        continue;
                    } else {
                        outputString += '!erreur ' + dec2hex(haut) + '!';
                        haut = 0;
                    }
                }
                if (0xD800 <= b && b <= 0xDBFF) {
                    haut = b;
                } else {
                    outputString += dec2hex(b) + ' ';
                }
            }
            return (outputString.replace(/ $/, ''));
        }


        function convertCP2UTF16(textString) {
            var outputString = "";
            textString = textString.replace(/^\s+/, '');
            if (textString.length == 0) {
                return "";
            }
            textString = textString.replace(/\s+/g, ' ');
            var listArray = textString.split(' ');
            for (var i = 0; i < listArray.length; i++) {
                var n = parseInt(listArray[i], 16);
                if (i > 0) {
                    outputString += '';
                }
                if (n <= 0xFFFF) {
                    outputString += dec2hex4(n);
                } else if (n <= 0x10FFFF) {
                    n -= 0x10000
                    outputString += dec2hex4(0xD800 | (n >> 10)) + ' ' + dec2hex4(0xDC00 | (n & 0x3FF));
                } else {
                    outputString += '!erreur ' + dec2hex(n) + '!';
                }
            }
            return (outputString);
        }


        function dec2hex(textString) {
            return (textString + 0).toString(16).toUpperCase();
        }

        function dec2hex2(textString) {
            var hexequiv = new Array("0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F");
            return hexequiv[(textString >> 4) & 0xF] + hexequiv[textString & 0xF];
        }

        function dec2hex4(textString) {
            var hexequiv = new Array("0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F");
            return hexequiv[(textString >> 12) & 0xF] + hexequiv[(textString >> 8) & 0xF] + hexequiv[(textString >> 4) & 0xF] + hexequiv[textString & 0xF];
        }


    </script>

    <script language="javascript" type="text/javascript">
        function textCounter(ctr1) {

            if (ctr1.value.length >= 80) {
                ctr1.value = ctr1.value.substring(0, 80);
            }
        }        
    </script>

    <script language="javascript" type="text/javascript">
        function AllowOnlyNumericEntery() {
            // Get the ASCII value of the key that the user entered
            var key = window.event.keyCode;


            if ((key >= 65 && key <= 90) || (key >= 97 && key <= 122)) {
                alert('Please enter only 10 digit mobile numbers with comma seprated.');

                return;
            }

        }
    </script>

    <script language="javascript" type="text/javascript">
        function AllowOnlyNumeric1() {
            // Get the ASCII value of the key that the user entered
            var key = window.event.keyCode;
            if ((key >= 65 && key <= 90) || (key >= 97 && key <= 122) || (key >= 46 && key <= 57) || key == 46 || key == 13 || key == 32) {
                var a = document.getElementById("<%=txtMsgBox.ClientID%>").value.length;

                document.getElementById("<%=txtCharCount.ClientID%>").value = a + 0;
                if (a + 0 == 160) {
                    alert('Message length is greater than 160, So SMS Count = 2. Are you aggri?');
                } else if (a + 1 == 306) {
                    alert('Message length >= 306, So SMS Count = 3. Are you aggri?');
                } else if (a + 0 == 459) {
                    alert('Message length >= 459, So SMS Count = 4. Are you aggri?');
                } else if (a + 0 == 612) {
                    alert('Message length >= 612, So SMS Count = 5. Are you aggri?');
                } else if (a + 0 == 765) {
                    alert('Message length >= 765, So SMS Count = 6. Are you aggri?');
                } else if (a + 0 == 918) {
                    alert('Message length >= 480, So SMS Count = 7. Are you aggri?');
                } else if (a + 0 == 1071) {
                    alert('Message length >= 1071, So SMS Count = 8. Are you aggri?');
                } else if (a + 0 == 1224) {
                    alert('Message length >= 1224, So SMS Count = 9. Are you aggri?');
                } else if (a + 0 == 1377) {
                    alert('Message length >= 1377, So SMS Count = 10. Are you aggri?');
                } else if (a + 0 == 1530) {
                    alert('Message length >= 1530, So SMS Count = 11. Are you aggri?');
                }

                return;
            }
            else {

                window.event.returnValue = null;
            }
        }

        function AllowOnlyNumeric2() {

            var key = window.event.keyCode;
            if ((key >= 65 && key <= 90) || (key >= 97 && key <= 122) || (key >= 46 && key <= 57) || key == 46 || key == 13 || key == 32) {

                a = document.getElementById("<%=txtSendMsg.ClientID%>").value.length;

                document.getElementById("<%=txtCharCount1.ClientID%>").value = a + 0;

                if (a + 0 == 160) {

                    alert('Message length >= 160, So SMS Count = 2. Are you aggri?');

                } else if (a + 0 == 306) {
                    alert('Message length >= 306, So SMS Count = 3. Are you aggri?');
                } else if (a + 0 == 459) {
                    alert('Message length >= 459, So SMS Count = 4. Are you aggri?');
                } else if (a + 0 == 612) {
                    alert('Message length >= 612, So SMS Count = 5. Are you aggri?');
                } else if (a + 0 == 765) {
                    alert('Message length >= 765, So SMS Count = 6. Are you aggri?');
                } else if (a + 0 == 918) {
                    alert('Message length >= 480, So SMS Count = 7. Are you aggri?');
                } else if (a + 0 == 1071) {
                    alert('Message length >= 1071, So SMS Count = 8. Are you aggri?');
                } else if (a + 0 == 1224) {
                    alert('Message length >= 1224, So SMS Count = 9. Are you aggri?');
                } else if (a + 0 == 1377) {
                    alert('Message length >= 1377, So SMS Count = 10. Are you aggri?');
                } else if (a + 0 == 1530) {
                    alert('Message length >= 1530, So SMS Count = 11. Are you aggri?');
                }


                return;
            }
            else {
                window.event.returnValue = null;
            }
        }

        function messagedisplay() {
            var key = window.event.keyCode;
            if ((key >= 65 && key <= 90) || (key >= 97 && key <= 122) || (key >= 46 && key <= 57) || key == 46 || key == 13 || key == 32) {
                a = document.getElementById("<%=txtCharCount1.ClientID%>").value
                if (a >= 160) {
                    document.getElementById("lblSendMsgCount").innerText = "Message considered as 2 SMS";
                }
                else {
                    document.getElementById("lblSendMsgCount").innerText = "";
                }
                return;
            }
            else {
                window.event.returnValue = null;
            }
        }

        function AllowOnlyNumeric3() {
            // Get the ASCII value of the key that the user entered
            var key = window.event.keyCode;
            if ((key >= 65 && key <= 90) || (key >= 97 && key <= 122) || (key >= 46 && key <= 57) || key == 46 || key == 13 || key == 32) {
                var a = document.getElementById("<%=txtGroupSMSMsg.ClientID%>").value.length;

                document.getElementById("<%=txtCharCount2.ClientID%>").value = a + 0;
                if (a + 0 == 160 || a + 0 >= 160) {
                    alert('Message length >= 160, So SMS Count = 2. Are you aggri?');

                } else if (a + 0 == 306) {
                    alert('Message length >= 306, So SMS Count = 3. Are you aggri?');
                } else if (a + 0 == 459) {
                    alert('Message length >= 459, So SMS Count = 4. Are you aggri?');
                } else if (a + 0 == 612) {
                    alert('Message length >= 612, So SMS Count = 5. Are you aggri?');
                } else if (a + 0 == 765) {
                    alert('Message length >= 765, So SMS Count = 6. Are you aggri?');
                } else if (a + 0 == 918) {
                    alert('Message length >= 480, So SMS Count = 7. Are you aggri?');
                } else if (a + 0 == 1071) {
                    alert('Message length >= 1071, So SMS Count = 8. Are you aggri?');
                } else if (a + 0 == 1224) {
                    alert('Message length >= 1224, So SMS Count = 9. Are you aggri?');
                } else if (a + 0 == 1377) {
                    alert('Message length >= 1377, So SMS Count = 10. Are you aggri?');
                } else if (a + 0 == 1530) {
                    alert('Message length >= 1530, So SMS Count = 11. Are you aggri?');
                }
                return;
            }
            else {

                window.event.returnValue = null;
            }
        }

        function AllowOnlyNumeric4() {
            // Get the ASCII value of the key that the user entered
            var key = window.event.keyCode;
            if ((key >= 65 && key <= 90) || (key >= 97 && key <= 122) || (key >= 46 && key <= 57) || key == 46 || key == 13 || key == 32) {
                var a = document.getElementById("<%=txtCustMessage.ClientID%>").value.length;

                document.getElementById("<%=txtchrcount.ClientID%>").value = a + 0;
                if (a + 0 == 160 || a + 0 >= 160) {
                    alert('Message length >= 160, So SMS Count = 2. Are you aggri?');

                } else if (a + 0 == 306) {
                    alert('Message length >= 306, So SMS Count = 3. Are you aggri?');
                } else if (a + 0 == 459) {
                    alert('Message length >= 459, So SMS Count = 4. Are you aggri?');
                } else if (a + 0 == 612) {
                    alert('Message length >= 612, So SMS Count = 5. Are you aggri?');
                } else if (a + 0 == 765) {
                    alert('Message length >= 765, So SMS Count = 6. Are you aggri?');
                } else if (a + 0 == 918) {
                    alert('Message length >= 480, So SMS Count = 7. Are you aggri?');
                } else if (a + 0 == 1071) {
                    alert('Message length >= 1071, So SMS Count = 8. Are you aggri?');
                } else if (a + 0 == 1224) {
                    alert('Message length >= 1224, So SMS Count = 9. Are you aggri?');
                } else if (a + 0 == 1377) {
                    alert('Message length >= 1377, So SMS Count = 10. Are you aggri?');
                } else if (a + 0 == 1530) {
                    alert('Message length >= 1530, So SMS Count = 11. Are you aggri?');
                }
                return;
            }
            else {

                window.event.returnValue = null;
            }
        }


        function AllowOnlyNumeric5() {
            // Get the ASCII value of the key that the user entered
            var key = window.event.keyCode;
            if ((key >= 65 && key <= 90) || (key >= 97 && key <= 122) || (key >= 46 && key <= 57) || key == 46 || key == 13 || key == 32) {
                var a = document.getElementById("<%=txtRemindMsg.ClientID%>").value.length;

                document.getElementById("<%=txtRemindCharcount.ClientID%>").value = a + 0;
                if (a + 0 == 160 || a + 0 >= 160) {
                    alert('Message length >= 160, So SMS Count = 2. Are you aggri?');

                } else if (a + 0 == 306) {
                    alert('Message length >= 306, So SMS Count = 3. Are you aggri?');
                } else if (a + 0 == 459) {
                    alert('Message length >= 459, So SMS Count = 4. Are you aggri?');
                } else if (a + 0 == 612) {
                    alert('Message length >= 612, So SMS Count = 5. Are you aggri?');
                } else if (a + 0 == 765) {
                    alert('Message length >= 765, So SMS Count = 6. Are you aggri?');
                } else if (a + 0 == 918) {
                    alert('Message length >= 480, So SMS Count = 7. Are you aggri?');
                } else if (a + 0 == 1071) {
                    alert('Message length >= 1071, So SMS Count = 8. Are you aggri?');
                } else if (a + 0 == 1224) {
                    alert('Message length >= 1224, So SMS Count = 9. Are you aggri?');
                } else if (a + 0 == 1377) {
                    alert('Message length >= 1377, So SMS Count = 10. Are you aggri?');
                } else if (a + 0 == 1530) {
                    alert('Message length >= 1530, So SMS Count = 11. Are you aggri?');
                }
                return;
            }
            else {

                window.event.returnValue = null;
            }
        }
         
         
    </script>

    <script language="javascript" type="text/javascript">
        function openPopup(strOpen) {
            open(strOpen, "Message",
         "status=1, width=600, height=400, top=100, left=300");
        }
      
    </script>

    <script type="text/javascript" language="javascript">

        function validateQuickSMS() {

            if (document.getElementById('<%=txtSendMsg.ClientID%>').value == "") {
                alert("Message Should not be Empty");
                return false;
            }
            else {
                this.disabled = true;
                this.value = 'Sending...';
                __doPostBack('btnSubmitSMSGroup', '')
                return true;
            }
        }
    
    </script>

    <script type="text/javascript" language="javascript">

        function validateGroupSMS() {

            if (document.getElementById('<%=txtGroupSMSMsg.ClientID%>').value == "") {
                alert("SMS Text should not be empty");
                return false;
            }
            else {
                this.disabled = true;
                this.value = 'Sending...';
                __doPostBack('btnSubmitSMSGroup', '')
            }
        }
    </script>

    <style type="text/css">
        /* Style Sheet Attributes */.ajax__tab_lightblue-theme .ajax__tab_header
        {
            font-family: 'Calibri' , sans-serif;
            font-weight: 500;
            font-size: 16px;
        }
        .ajax__tab_lightblue-theme .ajax__tab_header .ajax__tab_outer
        {
            background-color: #A4DED5;
            margin: 0px 0.16em 0px 0px;
            padding: 1px 0px 1px 0px;
            vertical-align: bottom;
            border-radius: 5px 5px 0px 0px;
        }
        .ajax__tab_lightblue-theme .ajax__tab_header .ajax__tab_tab
        {
            color: #000;
            padding: 0.35em 0.75em;
            margin-right: 0.01em;
        }
        .ajax__tab_lightblue-theme .ajax__tab_hover .ajax__tab_outer
        {
            background-color: #8FBEB7;
        }
        .ajax__tab_lightblue-theme .ajax__tab_active .ajax__tab_tab
        {
            color: #000;
        }
        .ajax__tab_lightblue-theme .ajax__tab_active .ajax__tab_outer
        {
            background-image: #ffffff;
        }
        .ajax__tab_lightblue-theme .ajax__tab_body
        {
            font-family: verdana,tahoma,helvetica;
            font-size: 10pt;
            padding: 0.25em 0.5em;
            background-color: #ffffff;
            border-top-width: 0px;
        }
    </style>
    <div class="MainDiv">
        <div class="InnerDiv">
            <center>
                <br />
                <span class="spanTitle">Send SMS</span>
                <br />
                <br />
            </center>
            <div style="margin-left: 5px;">
                <asp:TabContainer ID="tabParentSMSControl" runat="server" ActiveTabIndex="0" AutoPostBack="true"
                    Font-Size="Medium" CssClass="ajax__tab_lightblue-theme">
                    <asp:TabPanel ID="tabChildQuickSMS" runat="server">
                        <HeaderTemplate>
                            Quick SMS</HeaderTemplate>
                        <ContentTemplate>
                            <center>
                                <table class="tblSubFull2">
                                    <tr>
                                        <td align="left">
                                            <img src="../KResource/Images/QuickSmsImg.png" width="30px" height="20px" alt="" /><span
                                                class="spanTitle">Quick SMS</span>
                                            <br />
                                            <asp:Label ID="lblQuickGeneralBalance" ForeColor="Red" runat="server"></asp:Label>
                                            <center>
                                                <table>
                                                    <tr>
                                                        <td colspan="2" align="right">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            First Name:
                                                        </td>
                                                        <td align="right">
                                                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="ccstxt" ToolTip="Enter the First Name"></asp:TextBox>
                                                            <asp:FilteredTextBoxExtender ID="fteFirstNameDisplay" runat="server" Enabled="True"
                                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" TargetControlID="txtFirstName"
                                                                ValidChars=" ">
                                                            </asp:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            Last Name:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtLastName" runat="server" CssClass="ccstxt" ToolTip="Enter the Last Name"></asp:TextBox><asp:FilteredTextBoxExtender
                                                                ID="fteLastName" runat="server" Enabled="True" FilterType="Custom, UppercaseLetters, LowercaseLetters"
                                                                TargetControlID="txtLastName" ValidChars=" ">
                                                            </asp:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            MobileNo:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtMobileNo" MaxLength="10" runat="server" CssClass="ccstxt"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Button ID="btnSearch" runat="server" CssClass="cssbtn" OnClick="btnSearch_Click"
                                                                Text="Search" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2" style="height: 30px">
                                                            <label class="" visible="false">
                                                            </label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </center>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:GridView ID="gvFriendContact" runat="server" AutoGenerateColumns="False" EmptyDataText="No Friends Added In your Profile"
                                                Width="100%" AllowPaging="True" PageSize="15" DataKeyNames="usrMobileNo" AllowSorting="True"
                                                CssClass="gridview" OnPageIndexChanging="gvFriendContact_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField DataField="usrFullName" HeaderText="Name">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="usrMobileNo" HeaderText="Mobile Number">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelectFriend" runat="server" Text="Select" /></ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <table>
                                                <tr>
                                                    <td align="right">
                                                        Message
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtSendMsg" runat="server" onkeyup="AllowOnlyNumeric2()" TextMode="MultiLine"
                                                            onkeypress="messagedisplay()" Height="100px" Width="200px" ToolTip="Enter Message"></asp:TextBox>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        Character Count
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtCharCount1" runat="server" Height="25px" Width="70px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td style="width: 35%" align="left">
                                                        <asp:Button ID="btnSendSMS" runat="server" CssClass="cssbtn" OnClick="btnSendSMS_Click"
                                                            Text="Send SMS" ValidationGroup="vgSendSMS" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="tabChildGroupSMS" runat="server" Height="100%" CssClass="noPrint">
                        <HeaderTemplate>
                            Group SMS</HeaderTemplate>
                        <ContentTemplate>
                            <center>
                                <table class="tblSubFull2">
                                    <tr>
                                        <td colspan="2" align="left">
                                            <img src="../KResource/Images/GrpSMSImg.png" width="30px" height="20px" alt="" />
                                            <span class="spanTitle">Group SMS</span>
                                            <br />
                                            <asp:Label ID="lblGroupGeneralBalance" ForeColor="Red" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            First Name:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtGroupSMSFirst" runat="server" CssClass="ccstxt" ToolTip="Enter the First Name"></asp:TextBox><asp:FilteredTextBoxExtender
                                                ID="FilteredTextBoxExtender1" runat="server" Enabled="True" FilterType="Custom, UppercaseLetters, LowercaseLetters"
                                                TargetControlID="txtGroupSMSFirst" ValidChars=" ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Last Name:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtGroupSMSLast" runat="server" CssClass="ccstxt" ToolTip="Enter the Last Name"></asp:TextBox><asp:FilteredTextBoxExtender
                                                ID="FilteredTextBoxExtender2" runat="server" Enabled="True" FilterType="Custom, UppercaseLetters, LowercaseLetters"
                                                TargetControlID="txtGroupSMSLast" ValidChars=" ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Select Group:
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlMyFriendGroupSMS" runat="server" Width="140px" CssClass="cssddlwidth">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">FR1</asp:ListItem>
                                                <asp:ListItem Value="2">FR2</asp:ListItem>
                                                <asp:ListItem Value="3">FR3</asp:ListItem>
                                                <asp:ListItem Value="4">FR4</asp:ListItem>
                                                <asp:ListItem Value="5">FR5</asp:ListItem>
                                                <asp:ListItem Value="6">FR6</asp:ListItem>
                                                <asp:ListItem Value="7">FR7</asp:ListItem>
                                                <asp:ListItem Value="8">FR8</asp:ListItem>
                                                <asp:ListItem Value="9">FR9</asp:ListItem>
                                                <asp:ListItem Value="10">FR10</asp:ListItem>
                                                <asp:ListItem Value="11">FR11</asp:ListItem>
                                                <asp:ListItem Value="12">FR12</asp:ListItem>
                                                <asp:ListItem Value="13">FR13</asp:ListItem>
                                                <asp:ListItem Value="14">FR14</asp:ListItem>
                                                <asp:ListItem Value="15">FR15</asp:ListItem>
                                                <asp:ListItem Value="16">FR16</asp:ListItem>
                                                <asp:ListItem Value="17">FR17</asp:ListItem>
                                                <asp:ListItem Value="18">FR18</asp:ListItem>
                                                <asp:ListItem Value="19">FR19</asp:ListItem>
                                                <asp:ListItem Value="20">FR20</asp:ListItem>
                                                <asp:ListItem Value="21">FR21</asp:ListItem>
                                                <asp:ListItem Value="22">FR22</asp:ListItem>
                                                <asp:ListItem Value="23">FR23</asp:ListItem>
                                                <asp:ListItem Value="24">FR24</asp:ListItem>
                                                <asp:ListItem Value="25">FR25</asp:ListItem>
                                                <asp:ListItem Value="26">FR26</asp:ListItem>
                                                <asp:ListItem Value="27">FR27</asp:ListItem>
                                                <asp:ListItem Value="28">FR27</asp:ListItem>
                                                <asp:ListItem Value="29">FR29</asp:ListItem>
                                                <asp:ListItem Value="30">FR30</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="left">
                                            <br />
                                            <asp:Button ID="btnViewSendGroupSMS" runat="server" CssClass="cssbtn" OnClick="btnViewSendGroupSMS_Click"
                                                Text="Click To View Group" />
                                        </td>
                                    </tr>
                                </table>
                                <table class="tblSubFull2">
                                    <tr>
                                        <td align="left">
                                            <asp:CheckBox ID="chkAllContact" runat="server" Text="Select All" OnCheckedChanged="chkAllContact_CheckedChanged"
                                                AutoPostBack="True" Visible="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:GridView ID="gvGroupSMSContact" runat="server" AutoGenerateColumns="False" DataKeyNames="usrMobileNo"
                                                PageSize="15" AllowPaging="True" OnPageIndexChanging="gvGroupSMSContact_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField DataField="usrFullName" HeaderText="Name">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="usrMobileNo" HeaderText="Mobile Number">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelectFriend" runat="server" Text="Select" /></ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                                <table class="tblSubFull2">
                                    <tr>
                                        <td align="right">
                                            Message Text:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtGroupSMSMsg" runat="server" Width="200px" Height="100px" onkeyup="AllowOnlyNumeric3()"
                                                ToolTip="Enter Message" TextMode="MultiLine" AutoPostBack="True" OnTextChanged="txtGroupSMSMsg_TextChanged"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Character Count
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCharCount2" runat="server" Height="25px" Width="70px" OnClientClick="javascript:AllowOnlyNumeric3();"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnSubmitSMSGroup" runat="server" Text="Send" ValidationGroup="vgGroupSendSMS"
                                                CssClass="cssbtn" onmouseover="this.style.background='#1360be'" onmouseout="this.style.background='#4190f1'"
                                                OnClick="btnSubmitSMSGroup_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="PaidSMS" runat="server">
                        <HeaderTemplate>
                            Promotional SMS</HeaderTemplate>
                        <ContentTemplate>
                            <table class="tblSubFull2">
                                <tr>
                                    <td align="left">
                                        <img src="../KResource/Images/QuickSmsImg.png" width="30px" height="20px" alt="" /><span
                                            class="spanTitle">Promotional SMS</span>
                                        <br />
                                        Balance is:<asp:Label ID="lblPaidBal" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Message Type:
                                    </td>
                                    <td align="left">
                                        <asp:RadioButton ID="rbtnEnglish" runat="server" AutoPostBack="True" OnCheckedChanged="rbtnEnglish_CheckedChanged" /><label
                                            class="lbl">English</label>
                                        <asp:RadioButton ID="rbtnMarathi" runat="server" AutoPostBack="True" OnCheckedChanged="rbtnMarathi_CheckedChanged" /><label
                                            class="lbl">Marathi</label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Mobile Number:
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtMoNo" onkeypress="AllowOnlyNumericEntery()" runat="server" Height="100px"
                                            TextMode="MultiLine" Width="330px"></asp:TextBox>
                                        Comma Seprated. Eg:
                                        <asp:TextBox ID="txtUnicoded" runat="server" Width="1px" Height="1px"></asp:TextBox><label
                                            class="lbl">9881991453,9422325020,...</label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Enter Message Here
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtMsgBox" onkeyup="AllowOnlyNumeric1()" runat="server" Height="100px"
                                            TextMode="MultiLine" Width="330px"></asp:TextBox>
                                        (160*1=160 Char=1 SMS,153*2=306 Char= 2 SMS)
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Character Count
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtCharCount" runat="server" Height="25px" Width="50px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSendPaidSms" runat="server" Text="Send SMS" CssClass="cssbtn"
                                            OnClientClick="myfun();" OnClick="btnSendPaidSms_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Button ID="Button1" runat="server" Text="Promotional Group SMS Services" OnClick="Button1_Click"
                                            CssClass="cssbtn" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Button ID="btnOutbox" runat="server" Text="Promotional SMS Outbox" Width="240px"
                                            Font-Bold="True" Font-Size="Medium" OnClick="btnOutbox_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" CancelControlID="btnCancelOutbox"
                                            TargetControlID="btnOutbox" PopupControlID="OutBoxPopUp" DynamicServicePath=""
                                            Enabled="True">
                                        </asp:ModalPopupExtender>
                                        <asp:Panel ID="OutBoxPopUp" runat="server" CssClass="OutboxClass">
                                            <table width="500px">
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:Label ID="Label11" runat="server" Text="PROMOTIONAL SMS OUTBOX"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="Label12" runat="server" Text="SMS From Date:"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox><asp:CalendarExtender
                                                            ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate" Enabled="True">
                                                        </asp:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="Label13" runat="server" Text="SMS Upto Date:"></asp:Label>
                                                    </td>
                                                    <td align="center">
                                                        <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender1"
                                                            runat="server" TargetControlID="txtToDate" Enabled="True">
                                                        </asp:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:Button ID="Button2" runat="server" Text="SEARCH" OnClick="Button2_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="Red"
                                                            BorderStyle="Solid">
                                                            <Columns>
                                                                <asp:BoundField HeaderText="ID" DataField="ID">
                                                                    <ItemStyle Width="15px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField HeaderText="Send To" DataField="SendTo">
                                                                    <ItemStyle Width="20px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField HeaderText="Message" DataField="sms">
                                                                    <ItemStyle Width="400px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField HeaderText="Status" DataField="FlagStatus">
                                                                    <ItemStyle Width="20px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField HeaderText="Date" DataField="sendDateTime">
                                                                    <ItemStyle Width="20px" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" colspan="2">
                                                        <asp:Button ID="btnCancelOutbox" runat="server" Text="CLOSE" Font-Bold="True" Font-Size="Medium" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="CustomizedSMS" runat="server" Height="100%">
                        <HeaderTemplate>
                            Customized SMS
                        </HeaderTemplate>
                        <ContentTemplate>
                            <div>
                                <table class="tblSubFull2">
                                    <tr>
                                        <td align="left">
                                            <img src="../KResource/Images/QuickSmsImg.png" width="30px" height="20px" alt="" /><span
                                                class="spanTitle"> Customized SMS</span>
                                            <br />
                                            Balance is:
                                            <asp:Label ID="lblCustpaidbal" runat="server" ForeColor="Red"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Select File
                                        </td>
                                        <td align="left">
                                            <asp:FileUpload ID="fileupload" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnUpload" runat="server" CssClass="cssbtn" Text="Upload" OnClick="btnUpload_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 118px; text-align: right;">
                                        </td>
                                        <td style="width: 51px; text-align: left;">
                                            <div id="divMobile" runat="server" visible="False">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblttlCustSMS" runat="server" CssClass="lbl" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtCustMobile" runat="server" TextMode="MultiLine" Height="91px"
                                                                Width="240px" Enabled="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblMessage" runat="server" CssClass="lbl" Text="Enter Message"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCustMessage" runat="server" CssClass="tdText" TextMode="MultiLine"
                                                onkeyup="AllowOnlyNumeric4()" Height="130px" Width="248px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Character Count
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtchrcount" runat="server" Width="95px" CssClass="ccstxt" Enabled="False"></asp:TextBox>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 118px; text-align: right;">
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnCustSend" runat="server" CssClass="cssbtn" Text="Send" OnClick="btnCustSend_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:TabPanel>
                    <asp:TabPanel ID="ReminderSMS1" runat="server" Height="100%">
                        <HeaderTemplate>
                            Reminder SMS</HeaderTemplate>
                        <ContentTemplate>
                            <table class="tblSubFull2">
                                <tr>
                                    <td align="left">
                                        <img src="../KResource/Images/QuickSmsImg.png" width="30px" height="20px" alt="" /><span
                                            class="spanTitle">Reminder SMS</span>
                                        <br />
                                        Balance is:<asp:Label ID="lblremindbal" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Mobile Number:
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtReminMobileno" onkeypress="AllowOnlyNumericEntery()" runat="server"
                                            Height="100px" TextMode="MultiLine" Width="330px"></asp:TextBox>
                                        Comma Seprated. Eg:9881991453,9422325020
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Select Date To Schedule
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="ccstxt"></asp:TextBox>
                                        <img id="imgDate" alt="" src="../resources1/images/calendarclick.gif" style="height: 19px;
                                            width: 19px" />
                                        <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtDate"
                                            PopupButtonID="imgDate" Enabled="True">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblTime" runat="server" CssClass="lbl" Text="Select Time"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlTime" runat="server" CssClass="cssddlwidth">
                                            <asp:ListItem>00</asp:ListItem>
                                            <asp:ListItem>01</asp:ListItem>
                                            <asp:ListItem>02</asp:ListItem>
                                            <asp:ListItem>03</asp:ListItem>
                                            <asp:ListItem>04</asp:ListItem>
                                            <asp:ListItem>05</asp:ListItem>
                                            <asp:ListItem>06</asp:ListItem>
                                            <asp:ListItem>07</asp:ListItem>
                                            <asp:ListItem>08</asp:ListItem>
                                            <asp:ListItem>09</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                            <asp:ListItem>13</asp:ListItem>
                                            <asp:ListItem>14</asp:ListItem>
                                            <asp:ListItem>15</asp:ListItem>
                                            <asp:ListItem>16</asp:ListItem>
                                            <asp:ListItem>17</asp:ListItem>
                                            <asp:ListItem>18</asp:ListItem>
                                            <asp:ListItem>19</asp:ListItem>
                                            <asp:ListItem>20</asp:ListItem>
                                            <asp:ListItem>21</asp:ListItem>
                                            <asp:ListItem>22</asp:ListItem>
                                            <asp:ListItem>23</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                        <asp:Label ID="lblMinute" runat="server" CssClass="lbl" Text="Select Minutes"></asp:Label>
                                        &nbsp;<asp:DropDownList ID="ddlMinutes" runat="server" CssClass="cssddlwidth">
                                            <asp:ListItem>00</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>20</asp:ListItem>
                                            <asp:ListItem>30</asp:ListItem>
                                            <asp:ListItem>40</asp:ListItem>
                                            <asp:ListItem>50</asp:ListItem>
                                            <asp:ListItem>59</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Enter Message Here
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtRemindMsg" runat="server" Height="100px" Width="330px" onkeyup="AllowOnlyNumeric5()"
                                            TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Character Count
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtRemindCharcount" runat="server" Height="25px" Width="50px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="Button4" runat="server" CssClass="cssbtn" OnClientClick="myfun();"
                                            Text="Send SMS" OnClick="Button4_Click" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>
            </div>
        </div>
    </div>
</asp:Content>
