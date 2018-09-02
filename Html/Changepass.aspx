<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="Changepass.aspx.cs" Inherits="html_Changepass" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function validateChangePassword() {

            if (document.getElementById('<%=txtOldPasswod.ClientID%>').value == "") {
                alert("Provide the Old Password");
                return false;
            }
            else if (document.getElementById('<%=txtOldPasswod.ClientID%>').value.length < 5) {
                alert("Old Password Should be atleast 5 Character");
                return false;
            }
            else if (document.getElementById('<%=txtNewPassword.ClientID%>').value == "") {
                alert("Provide the New Password");
                return false;
            }
            else if (document.getElementById('<%=txtNewPassword.ClientID%>').value.length < 5) {
                alert("New Password Should be atleast 5 Character");
                return false;
            }
            else if (document.getElementById('<%=txtOldPasswod.ClientID%>').value == "") {
                alert("Provide the Old Password");
                return false;
            }
            else if (document.getElementById('<%=txtOldPasswod.ClientID%>').value.length < 5) {
                alert("Reentered-Password Should be atleast 5  Character");
                return false;
            }
            else {
                this.disabled = true;
                this.value = 'Changing Password...';
                __doPostBack('btnChangePassword', '');
            }
        }
    </script>

    <div class="MainDiv">
        <div class="InnerDiv">
            <table class="tblSubFull2">
                <tr>
                    <td colspan="2">
                        <center>
                            <br />
                            <img src="../KResource/Images/LoginImg.png" width="30px" height="30px" alt="" /><span
                                class="spanTitle">Change Password</span>
                            <br />
                        </center>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Old Passowrd:
                    </td>
                    <td class="tdTextInner">
                        <asp:TextBox ID="txtOldPasswod" runat="server" TextMode="Password" MaxLength="15"
                            CssClass="ccstxt" ToolTip="Enter the Old Password"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtOldPasswod"
                            FilterType="Custom" FilterMode="InvalidChars" InvalidChars=" ">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        New Passowrd:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" ValidationGroup="vgpChangePassword"
                            MaxLength="15" ToolTip="Enter the Password" CssClass="ccstxt"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtNewPassword"
                            FilterType="Custom" FilterMode="InvalidChars" InvalidChars=" ">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Confirm Passowrd:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtConfirmNewPassword" runat="server" TextMode="Password" ValidationGroup="vgpChangePassword"
                            MaxLength="15" ToolTip="Re-Enter the Password" CssClass="ccstxt"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="fteConfPassword" runat="server" TargetControlID="txtConfirmNewPassword"
                            FilterType="Custom" FilterMode="InvalidChars" InvalidChars=" ">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td align="left">
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*Password Not Matching"
                            ValidationGroup="vgpChangePassword" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmNewPassword"
                            Display="None"></asp:CompareValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="CompareValidator1">
                        </asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click"
                            ValidationGroup="vgpChangePassword" CssClass="cssbtn" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
