 <%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master"
    AutoEventWireup="true" CodeFile="AddNewUser.aspx.cs" Inherits="MarketingAdmin_AddNewUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" style="border-width: thin; width: 100%; display: block;" cellpadding="2"
        cellspacing="2">
        <tr>
            <td colspan="3" class="searchResultHeader">
                <asp:Label ID="lblAddFriendRelative" runat="server" Text="Add New User"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 20px;">
                <span class="warning1" style="color: Red;">Fields marked with * are compulsory.</span>
            </td>
        </tr>
       
       
        
    </table>
</asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%" border="1">
                <tr>
                    <td align="center">
                        <div style="width: 82%">
                            <table cellpadding="0" cellspacing="0" border="0" class="tables" style="width: 98%;
                                height: 332px">
                                <tr>
                                    <td style="height: 20px;">
                                        <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                    </td> 
                                </tr>
                                <tr>
                                    <td style="height: 20px;">
                                        <table style="width: 97%; height: 290px;" class="tblAdminSubFull1" cellspacing="0px">
                                            <tr>
                                                <td align="center" colspan="3">
                                                    <asp:Label ID="lblHeader" runat="server" Text="" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    &nbsp;&nbsp;<asp:Label ID="lblError" runat="server" CssClass="error" Text="Label"
                                                        Visible="false"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 378px">
                                                    <asp:Label ID="lblCityConf" runat="server" CssClass="lbl" Text="City Location"></asp:Label>
                                                </td>
                                                <td style="width: 519px">
                                                    <asp:RadioButtonList ID="rdoCityLocation" runat="server" AutoPostBack="True" Font-Size="Small"
                                                        OnSelectedIndexChanged="rdoCityLocation_SelectedIndexChanged" RepeatColumns="2"
                                                        RepeatDirection="Horizontal">
                                                        <asp:ListItem Selected="True" Text="Same City" Value="SC"></asp:ListItem>
                                                        <asp:ListItem Selected="False" Text="Different City" Value="DC"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rdoCityLocation"
                                                        ErrorMessage="Select Location" InitialValue="" ValidationGroup="vgNewFriRelReg"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:Panel ID="pnlSelectLocation" runat="server">
                                                        <table class="tblSubFull">
                                                            <tr>
                                                                <td id="subheading" align="left" class="tdLabelInner" colspan="2">
                                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="#3D3D3D" Text="Select Your City "></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="tdLabelInner">
                                                                    <asp:Label ID="Label5" runat="server" CssClass="lbl" Text=" Select State:*:"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="cmbState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbState_SelectedIndexChanged"
                                                                        Width="120px">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="cmbState"
                                                                        ErrorMessage="Select State" InitialValue=""></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="tdLabelInner">
                                                                    <asp:Label ID="Label4" runat="server" CssClass="lbl" Text=" Select District:*:"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="cmbDistrict" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbDistrict_SelectedIndexChanged"
                                                                        Width="120px">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="cmbDistrict"
                                                                        ErrorMessage="Select Firstly State" InitialValue=""></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="tdLabelInner">
                                                                    <asp:Label ID="Label1" runat="server" CssClass="lbl" Text=" Select City:*:"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="cmbCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbCity_SelectedIndexChanged"
                                                                        Width="120px">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="cmbCity"
                                                                        ErrorMessage="Select Firstly District" InitialValue=""></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr class="trInnerTable">
                                                <td style="width: 431px; text-align: left; height: 46px;" colspan="0">
                                                    <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Select Role"></asp:Label>
                                                </td>
                                                <td style="text-align: left; height: 46px; width: 519px" colspan="0">
                                                    <asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="True" Height="18px" meta:resourcekey="ddlRoleResource1"
                                                        OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" Width="198px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="tdLabelInner" style="text-align: left; height: 46px">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlRole"
                                                        Display="None" ErrorMessage="* Select Role" meta:resourcekey="RequiredFieldValidator2Resource1"
                                                        SetFocusOnError="True" ValidationGroup="vgNewFriRelReg"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="true"
                                                        TargetControlID="RequiredFieldValidator2">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr class="trInnerTable">
                                                <td style="width: 431px; text-align: left;" colspan="0" rowspan="0">
                                                    <asp:Label ID="Label2" runat="server" Text="Mobile No" CssClass="lbl"></asp:Label>
                                                </td>
                                                <td style="text-align: left; width: 519px" colspan="0">
                                                    <asp:TextBox ID="txtMobileNumber" runat="server" Width="140px" MaxLength="10" OnTextChanged="txtMobileNumber_TextChanged"
                                                        Height="22px"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="fteFrRlMobileNo" runat="server" TargetControlID="txtMobileNumber"
                                                        FilterType="Numbers">
                                                    </asp:FilteredTextBoxExtender>
                                                    <asp:TextBoxWatermarkExtender ID="mobile" runat="server" WatermarkText="Enter User Mobile No."
                                                        TargetControlID="txtMobileNumber" WatermarkCssClass="watermarked">
                                                    </asp:TextBoxWatermarkExtender>
                                                </td>
                                                <td class="tdErrorInner" style="text-align: left">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMobileNumber"
                                                        ValidationGroup="vgNewFriRelReg" ErrorMessage="* Mobile No Required" Display="None"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ValidationExpression="^[0-9]{10,}$"
                                                        ValidationGroup="vgNewFriRelReg" runat="server" ControlToValidate="txtMobileNumber"
                                                        ErrorMessage="Minimum 10 Numbers Required." Display="None"> </asp:RegularExpressionValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator4">
                                                    </asp:ValidatorCalloutExtender>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RegularExpressionValidator5">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr class="trInnerTable">
                                                <td style="height: 69px; width: 431px; text-align: left;" colspan="0" rowspan="0">
                                                    <asp:Label ID="Label6" runat="server" Text="Date Of Join" CssClass="lbl"></asp:Label>
                                                </td>
                                                <td style="height: 69px; text-align: left; width: 519px;" colspan="0" 
                                                    rowspan="0">
                                                    <asp:TextBox ID="txtDOB" runat="server" Width="140px" MaxLength="10" Height="22px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="txtDOB_CalendarExtender" runat="server" Enabled="True"
                                                        TargetControlID="txtDOB" Format="dd/MM/yyyy">
                                                    </asp:CalendarExtender>
                                                    (dd/MM/yyyy)
                                                </td>
                                                <td class="tdErrorInner" style="height: 69px; text-align: left;">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDOB"
                                                        ValidationGroup="vgNewFriRelReg" ErrorMessage="* Date  Required" Display="None"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator1">
                                                    </asp:ValidatorCalloutExtender>
                                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" WatermarkText="Select Date of Join"
                                                        TargetControlID="txtDOB" WatermarkCssClass="watermarked">
                                                    </asp:TextBoxWatermarkExtender>
                                                </td>
                                            </tr>
                                            <tr class="trInnerTable" id="trCommittee" runat="server" visible="false">
                                                <td style="height: 69px; width: 431px; text-align: left;" colspan="0" rowspan="0">
                                                    <asp:Label ID="lblCommittee" runat="server" Text="Select Committee" CssClass="lbl"></asp:Label>
                                                </td>
                                                <td style="height: 69px; text-align: left; width: 519px;" colspan="0" 
                                                    rowspan="0">
                                                   <%-- <asp:DropDownList ID="ddlCommitee" runat="server" Height="25px" Width="181px">
                                                    </asp:DropDownList>--%>
                                                    <div class="container" style="height: 179px; width: 396px">
                                                    <table>
                                                    <tr>
                                                    <td style="align:right;" align="left">
                                                    <asp:CheckBoxList ID="chkCommitee" runat="server" Width="371px" RepeatColumns="1" 
                                                            Height="168px" Font-Size="Small">
                                                    </asp:CheckBoxList>
                                                    </td>
                                                    </tr>
                                                    </table>
                                                    
                                                    </div>
                                                </td>
                                               
                                            </tr>
                                            <div id="SubGroupname" runat="server" visible="false">
                                                <tr class="trInnerTable">
                                                    <td class="tdLabelInner" style="height: 42px; width: 431px; text-align: left;">
                                                        <asp:Label ID="lblSelectGroup" runat="server" CssClass="lbl" Text="Select Group"></asp:Label>
                                                    </td>
                                                    <td style="height: 42px; text-align: left; width: 519px;" colspan="0">
                                                        <asp:DropDownList ID="ddlGroupName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGroupName_SelectedIndexChanged"
                                                            Width="150px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="tdErrorInner" style="height: 42px; text-align: left;">
                                                    </td>
                                                </tr>
                                                <tr class="trInnerTable">
                                                    <td style="height: 51px; width: 431px; text-align: left;" colspan="0" rowspan="0">
                                                        <asp:Label ID="lblSelectSubGruop" runat="server" CssClass="lbl" Text="Select SubGroup"></asp:Label>
                                                    </td>
                                                    <td style="height: 51px; text-align: left; width: 519px;" colspan="0">
                                                        <asp:DropDownList ID="ddlSubGroupName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubGroupName_SelectedIndexChanged"
                                                            Width="150px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="tdErrorInner" style="height: 51px; text-align: left;">
                                                    </td>
                                                </tr>
                                                <tr class="trInnerTable">
                                                    <td class="tdLabelInner" style="height: 31px; width: 431px; text-align: left;">
                                                    </td>
                                                    <td class="tdTextInner" style="height: 31px; text-align: left; width: 519px;">
                                                        <asp:Label ID="lblName" runat="server" CssClass="lbl" Visible="false"></asp:Label>
                                                    </td>
                                                    <td class="tdErrorInner" style="height: 31px; text-align: left;">
                                                    </td>
                                                </tr>
                                            </div>
                                             <tr class="trInnerTable" id="trmenuselection" visible="false" runat="server">
                                                <td class="tdLabelInner" style="height: 30px; width: 431px; text-align: left;">
                                                    <asp:Label ID="lblmenu" runat="server" Text="Select Menu"></asp:Label>
                                                </td>
                                                
                                                <td class="tdErrorInner" style="height: 30px; text-align: left;">
                                                    <asp:DropDownList ID="ddlmenselection" runat="server">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Public</asp:ListItem>
                                                    <asp:ListItem Value="2">Government</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr class="trInnerTable">
                                                <td class="tdLabelInner" style="height: 30px; width: 431px; text-align: left;">
                                                </td>
                                                <td style="height: 30px; text-align: left; width: 519px;" colspan="0">
                                                    <asp:Button ID="btnSubmit" runat="server" CssClass="button" OnClick="btnSubmit_Click"
                                                        Text="Submit" ValidationGroup="vgNewFriRelReg" Width="80px" />
                                                    &nbsp;<asp:Button ID="btnDelete" runat="server" CssClass="button" OnClick="btnDelete_Click"
                                                        Text="Delete" Width="81px" />
                                                    &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="button" OnClick="btnBack_Click"
                                                        Text="Back" />
                                                </td>
                                                <td class="tdErrorInner" style="height: 30px; text-align: left;">
                                                </td>
                                            </tr>
                                             
                                            <tr>
                                                <td colspan="3" align="center" style="padding-right: 20px; font-weight: 700;">
                                                    &nbsp;&nbsp; &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
