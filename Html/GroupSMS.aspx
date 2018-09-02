<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="GroupSMS.aspx.cs" Inherits="html_GroupSMS" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
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

        
        
    </script>
<%--
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>--%>
            <div class="MainDiv">
                <div class="InnerDiv">
                    <center>
                        <table class="tblSubFull2">
                            <tr>
                                <td colspan="2">
                                    <center>
                                        <img src="../KResource/Images/GrpSMSImg.png" width="30px" height="20px" alt="" />
                                        <span class="spanTitle">Group SMS</span>
                                        <br />
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2">
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
                                    <asp:DropDownList ID="ddlMyFriendGroupSMS" runat="server" Width="140px" CssClass="cssddlwidth"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlMyFriendGroupSMS_SelectedIndexChanged">
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
                                    <asp:CheckBox ID="chkAllContact" runat="server" Text="Select All " OnCheckedChanged="chkAllContact_CheckedChanged"
                                        AutoPostBack="True" Visible="False" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:CheckBox ID="ChkbxAllGroupcnt" runat="server" Text="Send to all group contacts"
                                        AutoPostBack="true" OnCheckedChanged="ChkbxAllGroupcnt_CheckedChanged" Visible="false" />
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
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <table class="tblSubFull2">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblMessage" runat="server" CssClass="lbl" Text="Enter Message"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCustMessage" runat="server" CssClass="tdText" TextMode="MultiLine"
                                        onkeyup="AllowOnlyNumeric4()" Height="120px" Width="248px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr><td></td></tr>
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
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Button ID="btnSubmitSMSGroup" runat="server" Text="Send" ValidationGroup="vgGroupSendSMS"
                                        CssClass="cssbtn" OnClick="btnSubmitSMSGroup_Click" />
                                </td>
                            </tr>
                        </table>
                    </center>
                </div>
            </div>
     <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
