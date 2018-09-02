<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="QuickSMS.aspx.cs" Inherits="html_QuickSMS" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
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
    </script>

    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <div class="MainDiv">
                <div class="InnerDiv">
                    <center>
                        <table class="tblSubFull2">
                            <tr>
                                <td colspan="2">
                                    <center>
                                        <img src="../KResource/Images/QuickSmsImg.png" width="30px" height="20px" alt="" /><span
                                            class="spanTitle">Quick SMS</span></center>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblQuickGeneralBalance" ForeColor="Red" runat="server"></asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    First Name:
                                </td>
                                <td align="left">
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
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:GridView ID="gvFriendContact" runat="server" AutoGenerateColumns="False" EmptyDataText="No Friends Added In your Profile"
                                        AllowPaging="True" PageSize="15" DataKeyNames="usrMobileNo" AllowSorting="True"
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
                                    <asp:TextBox ID="txtCharCount1" runat="server" Height="25px" Width="70px" Enabled="false"></asp:TextBox>
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
                    </center>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
