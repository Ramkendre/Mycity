<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="PromotionalSMS.aspx.cs" Inherits="html_PromotionalSMS" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function AllowOnlyNumericEntery() {
            // Get the ASCII value of the key that the user entered
            var key = window.event.keyCode;


            if ((key >= 65 && key <= 90) || (key >= 97 && key <= 122)) {
                alert('Please enter only 10 digit mobile numbers with comma seprated.');

                return;
            }

        }
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
    </script>

    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <div class="MainDiv">
                <div class="InnerDiv">
                    <table class="tblSubFull2">
                        <tr>
                            <td colspan="2">
                                <center>
                                    <img src="../KResource/Images/QuickSmsImg.png" width="30px" height="20px" alt="" /><span
                                        class="spanTitle">Promotional SMS</span>
                                </center>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
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
                                    CssClass="cssbtn" Visible="false" />
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
                                    Font-Bold="True" Font-Size="Medium" OnClick="btnOutbox_Click" Visible="false"/>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" CancelControlID="btnCancelOutbox"
                                    TargetControlID="btnOutbox" PopupControlID="OutBoxPopUp" DynamicServicePath=""
                                    Enabled="True">
                                </asp:ModalPopupExtender>
                                <asp:Panel ID="OutBoxPopUp" runat="server" CssClass="OutboxClass" Visible="false">
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
