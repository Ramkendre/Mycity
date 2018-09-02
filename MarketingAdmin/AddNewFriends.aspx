<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="AddNewFriends.aspx.cs" Inherits="MarketingAdmin_AddNewFriends" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="Panel1" runat="server">
    <ContentTemplate>
        <%--<asp:Panel ID="pnlEditContact" runat="server" Width="550px" CssClass="ModalWindow">--%>
            <table class="tblSubFull1" align="left">
                <tr>
                    <td colspan="3" class="searchResultHeader">
                        <asp:Label ID="lblAddFriendRelative" runat="server" Text="Add Friend & Relative"></asp:Label>
                    </td>
                </tr>
                <tr class="trInnerTable">
                    <td class="tdLabelInner" style="text-align: left">
                        <asp:Label ID="lblUserName" runat="server" Text="First Name :"></asp:Label>
                        <asp:Label ID="Label14" runat="server" Text="*" Width="2" CssClass="lblStar"></asp:Label>
                    </td>
                    <td class="tdTextInner" align="left">
                        <asp:TextBox ID="txtFirstName" runat="server" Width="140px" onfocus="ChangeCSS(this, event)"
                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="fteFrRlFirstName" runat="server" TargetControlID="txtFirstName"
                            FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td class="tdErrorInner" align="left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtFirstName"
                            ValidationGroup="vgNewFriRelReg" runat="server" ErrorMessage="* First Name Required"
                            Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator2">
                        </asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr class="trInnerTable">
                    <td class="tdLabelInner" style="text-align: left">
                        <asp:Label ID="Label1" runat="server" Text="Last Name :"></asp:Label>
                        <asp:Label ID="Label5" runat="server" Text="*" Width="2" CssClass="lblStar"></asp:Label>
                    </td>
                    <td class="tdTextInner" align="left">
                        <asp:TextBox ID="txtLastName" runat="server" Width="140px" onfocus="ChangeCSS(this, event)"
                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="fteFrRlLastName" runat="server" TargetControlID="txtLastName"
                            FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td class="tdErrorInner" align="left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtLastName"
                            ValidationGroup="vgNewFriRelReg" runat="server" ErrorMessage="* Last Name Required"
                            Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RequiredFieldValidator3">
                        </asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr class="trInnerTable">
                    <td class="tdLabelInner" style="text-align: left">
                        <asp:Label ID="Label2" runat="server" Text="Mobile No. :"></asp:Label>
                        <asp:Label ID="Label6" runat="server" Text="*" Width="2" CssClass="lblStar"></asp:Label>
                    </td>
                    <td class="tdTextInner" align="left">
                        <asp:TextBox ID="txtMobileNumber" runat="server" Width="140px" MaxLength="10" onfocus="ChangeCSS(this, event)"
                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="fteFrRlMobileNo" runat="server" TargetControlID="txtMobileNumber"
                            FilterType="Numbers">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td class="tdErrorInner" align="left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMobileNumber"
                            ValidationGroup="vgNewFriRelReg" ErrorMessage="* Mobile No Required" Display="None"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ValidationExpression="^[0-9]{10,}$"
                            ValidationGroup="vgNewFriRelReg" runat="server" ControlToValidate="txtMobileNumber"
                            ErrorMessage="Minimum 10 Numbers Required." Display="None">
                        </asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator4">
                        </asp:ValidatorCalloutExtender>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RegularExpressionValidator5">
                        </asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr class="trInnerTable">
                    <td class="tdLabelInner" style="text-align: left">
                        <asp:Label ID="Label4" runat="server" Text="Relation. :"></asp:Label>
                        <asp:Label ID="Label7" runat="server" Text="*" Width="2" CssClass="lblStar"></asp:Label>
                    </td>
                    <td class="tdTextInner" align="left">
                        <asp:TextBox ID="txtRelation" runat="server" ValidationGroup="vgNewFriRelReg" Width="140px"
                            onfocus="ChangeCSS(this, event)" onblur="ChangeCSS(this, event)"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="fteFrRlRelation" runat="server" TargetControlID="txtRelation"
                            FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars="/-_,.()& ">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td class="tdErrorInner" align="left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRelation"
                            ValidationGroup="vgNewFriRelReg" ErrorMessage="* Relation Required" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server" TargetControlID="RequiredFieldValidator4">
                        </asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr class="trInnerTable">
                    <td class="tdLabelInner" style="text-align: left">
                        <asp:Label ID="Label8" runat="server" Text="Relation Group. :"></asp:Label>
                        <asp:Label ID="Label9" runat="server" Text="*" Width="2" CssClass="lblStar"></asp:Label>
                    </td>
                    <td class="tdTextInner" align="left">
                        <asp:DropDownList ID="cmbFriendGroup" runat="server" Width="140px">
                        </asp:DropDownList>
                    </td>
                    <td class="tdErrorInner" align="left">
                    </td>
                </tr>
                <tr class="trInnerTable">
                    <td class="tdLabelInner" style="text-align: left">
                        <asp:Label ID="lblAddress" runat="server" Text="Address :"></asp:Label>
                    </td>
                    <td class="tdTextInner" align="left">
                        <asp:TextBox ID="txtAddress" runat="server" Width="180px" onfocus="ChangeCSS(this, event)"
                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtAddress"
                            FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()& ">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td class="tdErrorInner" align="left">
                    </td>
                </tr>
                <tr class="trInnerTable">
                    <td class="tdLabelInner" style="height: 40px; text-align: left">
                        <asp:Label ID="lblCityConf" runat="server" Text="City Location:"></asp:Label>
                    </td>
                    <td colspan="2" style="height: 40px; text-align: left">
                        <asp:RadioButtonList ID="rdoCityLocation" runat="server" AutoPostBack="true" RepeatColumns="2"
                            RepeatDirection="Horizontal" Font-Size="Small">
                            <asp:ListItem Selected="True" Text="Same City" Value="SC"></asp:ListItem>
                            <asp:ListItem Selected="False" Text="Different City" Value="DC"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" class="tdLabelInner">
                        (Same City =
                        <%=Session["CityNameN"]%>)
                    </td>
                    <tr>
                        <td colspan="3">
                            <asp:Panel ID="pnlSelectLocation" runat="server" Visible="false">
                                <table class="tblSubFull">
                                    <tr>
                                        <td id="subheading" align="center" colspan="2" style="background-color: #E7E7E7;">
                                            <asp:Label ID="Label3" runat="server" Font-Bold="true" ForeColor="#3D3D3D" Text=":: Select Your City ::"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="LabelBold">
                                            Select State:
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cmbState" runat="server" AutoPostBack="True" 
                                                Width="120px" OnSelectedIndexChanged="cmbState_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="cmbState"
                                                ErrorMessage="***" InitialValue=""></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="LabelBold">
                                            Select District:
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cmbDistrict" runat="server" AutoPostBack="True" 
                                                Width="120px" OnSelectedIndexChanged="cmbDistrict_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="cmbDistrict"
                                                ErrorMessage="***" InitialValue=""></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="LabelBold">
                                            Select City:
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cmbCity" runat="server" Width="120px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="cmbCity"
                                                ErrorMessage="***" InitialValue=""></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr class="trInnerTable">
                        <td align="center" colspan="3">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="button" Text="Add Friend &amp; Relative"
                                ValidationGroup="vgNewFriRelReg" onclick="btnSubmit_Click" />
                            &nbsp;
                            <asp:Button ID="btnBackContact" runat="server" CssClass="button" Text="Back" 
                                onclick="btnBackContact_Click" />
                        </td>
                    </tr>
                </tr>
            </table>
      <%--  </asp:Panel>--%>
        </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
