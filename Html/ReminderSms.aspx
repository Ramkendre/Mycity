<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="ReminderSms.aspx.cs" Inherits="html_ReminderSms" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
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


        function AllowOnlyNumericEntery() {
            // Get the ASCII value of the key that the user entered
            var key = window.event.keyCode;


            if ((key >= 65 && key <= 90) || (key >= 97 && key <= 122)) {
                alert('Please enter only 10 digit mobile numbers with comma seprated.');

                return;
            }

        }


    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="MainDiv">
                <div class="InnerDiv">
                    <center>
                        <table class="tblSubFull2">
                            <tr>
                                <td colspan="2">
                                    <center>
                                        <img src="../KResource/Images/QuickSmsImg.png" width="30px" height="20px" alt="" /><span
                                            class="spanTitle">Reminder SMS</span>
                                    </center>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
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
                    </center>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
