<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="CustomizedSMS.aspx.cs" Inherits="html_CustomizedSMS" Title="Untitled Page" %>

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

    <div class="MainDiv">
        <div class="InnerDiv">
            <div>
                <table class="tblSubFull2">
                    <tr>
                        <td colspan="2">
                            <center>
                                <img src="../KResource/Images/QuickSmsImg.png" width="30px" height="20px" alt="" /><span
                                    class="spanTitle"> Customized SMS</span>
                            </center>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
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
        </div>
    </div>
</asp:Content>
