<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="PasswordRecover.aspx.cs" Inherits="UI_PasswordRecover" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="MainDiv">
        <div class="InnerDiv">
            <table class="tblSubFull2">
                <tr>
                    <td align="left">
                        <br />
                        <br />
                        <center>
                            <img src="../KResource/Images/ForgetPassImg.png" width="40px" height="30px"/><span class="spanTitle">  Forgot/Resend Password</span></center>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        If you have forgotten password or not received password of your account, no problem,
                        we will help you out. Please enter your Mobile No which you used to register with
                        us. We will send you the details.
                    </td>
                </tr>
            </table>
            <table class="tblSubFull2">
                <tr>
                    <td align="right">
                        Registered Mobile No:
                        <asp:Label ID="lblMobPrefix" runat="server" Text="+91" Font-Bold="true"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtFPMobileNo" runat="server" MaxLength="10" CssClass="ccstxt"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="ftbtxtFPMobileNo" runat="server" FilterType="Numbers"
                            TargetControlID="txtFPMobileNo">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td align="left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Mobile No...!"
                            Display="None" ControlToValidate="txtFPMobileNo" ValidationGroup="b"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                        </asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2" align="left">
                        <asp:Button ID="btnPasswordRecover" ValidationGroup="b" runat="server" Text="Recover My Password"
                            OnClick="btnPasswordRecover_Click" CssClass="cssbtn" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        If still your problem persists, mail us to <a href="mailto:support@myct.in">support@myct.in</a>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
