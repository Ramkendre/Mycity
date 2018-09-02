<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="UserRegistration.aspx.cs" Inherits="Html_UserRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
        function validateSignIn() {
            if (document.getElementById('<%=txtUserIdentity.ClientID%>').value == "") {
                alert("Please enter MobileNo.");
                return false;
            }
            else if (document.getElementById('<%=txtUserIdentity.ClientID%>').value.length < 10) {
                alert("Mobile No Length Should be 10 Numbers");
                return false;
            }
            else if (document.getElementById('<%=txtPassword.ClientID%>').value == "") {
                alert("Please enter Password.");
                return false;
            }
            else if (document.getElementById('<%=txtPassword.ClientID%>').value.length < 5) {
                alert("Password Length Should be 10 Numbers");
                return false;
            }
            else {
            }
        }
    </script>

    <div class="MainDiv">
        <div class="InnerDiv">
            <asp:Accordion ID="acdLogin" runat="server" TransitionDuration="250" FramesPerSecond="40"
                SelectedIndex="0" defaultfocus="pnlExistUser" FadeTransitions="true" HeaderCssClass="acc-header"
                ContentCssClass="acc-content" HeaderSelectedCssClass="acc-selected">
                <Panes>
                    <asp:AccordionPane ID="pnlExistUser" runat="server">
                        <Header>
                            <table class="innerTable">
                                <tr>
                                    <td align="left">
                                        <img src="../KResource/Images/LoginImg.png" width="30px" height="30px" alt=""/><span class="spanTitle">Sign in</span>
                                    </td>
                                </tr>
                            </table>
                        </Header>
                        <Content>
                            <table class="tblSubFull2">
                                <tr>
                                    <td>
                                        User Mobile No.: *
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUserIdentity" runat="server" Width="140px" MaxLength="10" CssClass="ccstxt">
                                        </asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="ftbMobileNo" runat="server" TargetControlID="txtUserIdentity"
                                            FilterType="Numbers">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="vgreg"
                                            Display="None" ControlToValidate="txtUserIdentity" ErrorMessage="*Please enter Mobile No "></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="^[0-9]{10,}$"
                                            ValidationGroup="vgreg" runat="server" ControlToValidate="txtUserIdentity" ErrorMessage="Minimum 10 Digits Required."
                                            Display="None">
                                        </asp:RegularExpressionValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator5">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RegularExpressionValidator1">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Password: *
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="140px" CssClass="ccstxt"
                                            MaxLength="15"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="ftePassword" runat="server" TargetControlID="txtPassword"
                                            FilterMode="InvalidChars" InvalidChars=" ~`'">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="vgreg"
                                            Display="None" ControlToValidate="txtPassword" ErrorMessage="* Please enter Password">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationExpression="^[0-9,a-z,A-Z]{4,35}$*"
                                            ValidationGroup="vgreg" runat="server" ControlToValidate="txtPassword" ErrorMessage="Minimum 4 Digits Required."
                                            Display="None">
                                        </asp:RegularExpressionValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator6">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="RegularExpressionValidator2">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td align="left" style="padding-right: 60px;">
                                                    <asp:Button ID="btnSignIn" runat="server" Text="Sign in" ValidationGroup="vgreg"
                                                        AccessKey="S" OnClick="btnSignIn_Click" CssClass="cssbtn" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img src="../images/arrow.gif" alt="Logo" />
                                                    <asp:LinkButton ID="lnkForgorPassword" runat="server" Text="Click Here... Forgot/Resend Password"
                                                        OnClick="lnkForgorPassword_Click" Font-Size="12px" ForeColor="Maroon" AccessKey="F">
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </Content>
                    </asp:AccordionPane>
                    <asp:AccordionPane ID="pnlNewUser" runat="server">
                        <Header>
                            <table class="innerTable">
                                <tr>
                                    <td align="left">
                                        <img src="../KResource/Images/RegisterImg.png" width="30px" height="30px" alt=""/> <span class="spanTitle">Click Here For New User Sign up</span>
                                    </td>
                                </tr>
                            </table>
                        </Header>
                        <Content>
                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
                            <table class="tblSubFull2">
                                <tr>
                                    <td>
                                        First Name : *
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="ccstxt"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="fteURFirstName" runat="server" TargetControlID="txtFirstName"
                                            FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtFirstName"
                                            ValidationGroup="vgNewReg" runat="server" ErrorMessage="* First Name Required"
                                            Display="None"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ValidationExpression="^[a-z,A-Z, ]{2,35}$"
                                            ValidationGroup="vgNewReg" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Single character not allowed."
                                            Display="None">
                                        </asp:RegularExpressionValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator2">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" TargetControlID="RegularExpressionValidator3">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Last Name : *
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLastName" runat="server" Width="120px" CssClass="ccstxt"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="fteURLastName" runat="server" TargetControlID="txtLastName"
                                            FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtLastName"
                                            ValidationGroup="vgNewReg" runat="server" ErrorMessage="* Last Name Required"
                                            Display="None"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ValidationExpression="^[a-z,A-Z, ]{2,35}$"
                                            ValidationGroup="vgNewReg" runat="server" ControlToValidate="txtLastName" ErrorMessage="Single character not allowed."
                                            Display="None">
                                        </asp:RegularExpressionValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RequiredFieldValidator3">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" TargetControlID="RegularExpressionValidator4">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Mobile No. : *
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMobileNumber" runat="server" Width="120px" CssClass="ccstxt"
                                            ValidationGroup="vgNewReg" MaxLength="10"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="ftbFirstMobileNo" runat="server" TargetControlID="txtMobileNumber"
                                            FilterType="Numbers">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMobileNumber"
                                            ValidationGroup="vgNewReg" ErrorMessage="* Mobile No Required" Display="None"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ValidationExpression="^[0-9]{10,}$"
                                            ValidationGroup="vgNewReg" runat="server" ControlToValidate="txtMobileNumber"
                                            ErrorMessage="Minimum 10 Numbers Required." Display="None">
                                        </asp:RegularExpressionValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator4">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" TargetControlID="RegularExpressionValidator5">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Address :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAddress" runat="server" Width="180px" CssClass="ccstxt"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="ftbAddress" runat="server" TargetControlID="txtAddress"
                                            FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()& ">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Gender: *
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="rdoGender" runat="server" Font-Size="Smaller" RepeatDirection="Horizontal"
                                            TextAlign="Right">
                                            <asp:ListItem Text="Male" Value="Male" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkAcceptTermCond" runat="server" Text="" /><a href="../html/TermCondition.aspx">
                                            <asp:Label ID="lblATC" runat="server" Text="Accept Term & Condition" Font-Size="12px"
                                                ForeColor="Maroon"></asp:Label></a>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Image ID="img" runat="server" Visible="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                            CausesValidation="true" CssClass="cssbtn" ValidationGroup="vgNewReg" OnClientClick="return " />
                                    </td>
                                </tr>
                            </table>
                        </Content>
                    </asp:AccordionPane>
                </Panes>
            </asp:Accordion>
        </div>
    </div>
</asp:Content>
