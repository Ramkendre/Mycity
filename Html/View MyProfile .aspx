<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="View MyProfile .aspx.cs" Inherits="Html_View_MyProfile_" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Collections" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Data " %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="MainDiv">
        <div class="InnerDiv">
            <asp:UpdatePanel ID="main" runat="server">
                <ContentTemplate>
                    <span style="padding-top: 80%;">
                        <div>
                            <table class="tblSubFull2">
                                <tr>
                                    <td align="left">
                                        <img src="../KResource/Images/AddressImg.png" alt="" width="30px" height="30px" /><span
                                            class="spanTitle"> Details</span>
                                    </td>
                                    <td align="right" width="50%">
                                        <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />
                        <br />
                        <div style="width: 100%;">
                            <div style="border: 1px solid black; height: 130px;">
                                <div style="width: 100%; text-align: center; background-color: #164854; color: White;">
                                    Personal Details
                                </div>
                                <br />
                                <div class="cssgridtext">
                                    Name:<asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                </div>
                                <div class="cssgridtext1">
                                    DOB:<asp:Label ID="lblDOB" runat="server" Text='<%#Eval("DOB") %>'></asp:Label>
                                </div>
                                <div style="width: 100%;">
                                    <div class="cssgridtext">
                                        MobileNo:<asp:Label ID="lblMobileNo" runat="server" Text='<%#Eval("MobileNo") %>'></asp:Label>
                                    </div>
                                    <div class="cssgridtext1">
                                        Gender:<asp:Label ID="Label2" runat="server" Text='<%#Eval("Gender") %>'></asp:Label>
                                    </div>
                                </div>
                                <div style="width: 100%;">
                                    <div class="cssgridtext">
                                        City:<asp:Label ID="lblCity" runat="server" Text='<%#Eval("City") %>'></asp:Label>
                                    </div>
                                    <div class="cssgridtext1">
                                        District:<asp:Label ID="lblDist" runat="server" Text='<%#Eval("District") %>'></asp:Label>
                                    </div>
                                </div>
                                <div style="width: 100%;">
                                    <div class="cssgridtext">
                                        State:<asp:Label ID="lblState" runat="server" Text='<%#Eval("State") %>'></asp:Label>
                                    </div>
                                    <div class="cssgridtext1">
                                        EmailId:<asp:Label ID="lblEmailId" runat="server" Text='<%#Eval("EmailId") %>'></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div style="border: 1px solid black; height: 90px;">
                                <div style="width: 100%;">
                                    <div style="width: 100%; text-align: center; background-color: #164854; color: White;">
                                        Educational Details</div>
                                    <br />
                                    <div class="cssgridtext">
                                        Qualification:<asp:Label ID="lblQualification" runat="server" Text='<%#Eval("Qualification") %>'></asp:Label>
                                    </div>
                                    <div class=" cssgridtext1">
                                        Specialization:<asp:Label ID="lblSpecialization" runat="server" Text='<%#Eval("Specialization") %>'></asp:Label>
                                    </div>
                                </div>
                                <div style="width: 100%;">
                                    <div class="cssgridtext">
                                        Institute Name:<asp:Label ID="lblInstName" runat="server" Text='<%#Eval("InstName") %>'></asp:Label>
                                    </div>
                                    <div class=" cssgridtext1">
                                        Year of Passout:<asp:Label ID="lblYearPassout" runat="server" Text='<%#Eval("YearPassout") %>'></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div style="border: 1px solid black; height: 110px;">
                                <div style="width: 100%;">
                                    <div style="width: 100%; text-align: center; background-color: #164854; color: White;">
                                        Work Experience</div>
                                    <br />
                                    <div class="cssgridtext">
                                        AreYou:<asp:Label ID="lblAreYou" runat="server" Text='<%#Eval("AreYou") %>'></asp:Label>
                                    </div>
                                    <div class=" cssgridtext1">
                                        Functional Area:<asp:Label ID="lblFArea" runat="server" Text='<%#Eval("FArea") %>'></asp:Label>
                                    </div>
                                    <div class="cssgridtext">
                                        Experience Year :
                                        <asp:Label ID="lblExperienceYr" runat="server" Text='<%#Eval("ExperienceYr") %>'></asp:Label>
                                    </div>
                                    <div class=" cssgridtext1">
                                        Experience Month :<asp:Label ID="lblExperienceMonth" runat="server" Text='<%#Eval("ExperienceMonth") %>'></asp:Label>
                                    </div>
                                    <div class="cssgridtext">
                                        CompName :<asp:Label ID="lblCName" runat="server" Text='<%#Eval("CompName") %>'></asp:Label>
                                    </div>
                                    <div class=" cssgridtext1">
                                        Job Title :<asp:Label ID="lblJTitle" runat="server" Text='<%#Eval("JTitle") %>'></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div style="border: 1px solid black; height: 70px;">
                                <div style="width: 100%;">
                                    <div style="width: 100%; text-align: center; background-color: #164854; color: White;">
                                        KeySkill
                                    </div>
                                    <br />
                                    <asp:Label ID="lblKeySkill" CssClass="cssgridtext" runat="server" Text='<%#Eval("KeySkill") %>'></asp:Label>
                                </div>
                            </div>
                        </div>
                    </span>
                    <asp:ModalPopupExtender ID="mdlDetails" runat="server" TargetControlID="lnkEdit"
                        PopupControlID="pnlEditContact" BackgroundCssClass="modalBackground" CancelControlID="btnCloseContact"
                        PopupDragHandleControlID="pnlEditContact">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlEditContact" runat="server" class="ModalPop">
                        <div class="csspop">
                            <center>
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            <center>
                                                <img src="../KResource/Images/AddressImg.png" alt="" width="30px" height="30px" />
                                                <span class="spanHeader">Contact Information Update</span>
                                            </center>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Name :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtName" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="fteName" runat="server" TargetControlID="txtName"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            DOB :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDOB" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtDOB"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            MobileNo :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtMobileNo" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtMobileNo"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            City :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCity" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtCity"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <tr>
                                            <td align="right">
                                                District :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDistrict" runat="server" CssClass="ccstxt"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtDistrict"
                                                    FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            State
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtState" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServicePath="~/Resources/Services/AutoComplete.asmx"
                                                ServiceMethod="GetArea" TargetControlID="txtState" MinimumPrefixLength="1" CompletionSetCount="12"
                                                DelimiterCharacters="" Enabled="True">
                                            </asp:AutoCompleteExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Email ID
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" ServicePath="~/Resources/Services/AutoComplete.asmx"
                                                ServiceMethod="GetArea" TargetControlID="txtEmail" MinimumPrefixLength="1" CompletionSetCount="12"
                                                DelimiterCharacters="" Enabled="True">
                                            </asp:AutoCompleteExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Gender :
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rbtn" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem>Female</asp:ListItem>
                                                <asp:ListItem>Male</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Qualification
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DDDLQualification" runat="server" AutoPostBack="true" CssClass="cssddlwidth">
                                            </asp:DropDownList>
                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Your District"
                                                ValidationGroup="savegrpcontact" Display="None" ControlToValidate="DDDLQualification"
                                                InitialValue=""></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2">
                                            </asp:ValidatorCalloutExtender>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Specialization
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DDLSpecialization" runat="server" AutoPostBack="true" CssClass="cssddlwidth">
                                            </asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Your District"
                                                ValidationGroup="savegrpcontact" Display="None" ControlToValidate="DDLSpecialization"
                                                InitialValue=""></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                                            </asp:ValidatorCalloutExtender>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            InstName
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtInstName" runat="server" CssClass="ccstxt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            YearPassout
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlYearPassout" runat="server" AutoPostBack="true" CssClass="cssddlwidth">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select Your District"
                                                ValidationGroup="savegrpcontact" Display="None" ControlToValidate="ddlYearPassout"
                                                InitialValue=""></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RequiredFieldValidator4">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                     <tr>
                    <td align="right">
                        Are You
                        <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rbtnAY" runat="server" 
                            AutoPostBack="true" RepeatDirection="Horizontal">
                            <asp:ListItem>Fresher</asp:ListItem>
                            <asp:ListItem>Experience</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                
                                    <tr>
                                        <td align="right">
                                            Functional Area
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlFArea" runat="server" AutoPostBack="true" CssClass="cssddlwidth">
                                            </asp:DropDownList>
                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select Your District"
                                                    ValidationGroup="savegrpcontact" Display="None" ControlToValidate="ddlQuali"
                                                    InitialValue=""></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator2">
                                                </asp:ValidatorCalloutExtender>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Experience
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlExperienceYr" runat="server" AutoPostBack="true" CssClass="cssddlwidth">
                                            </asp:DropDownList>
                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select Your District"
                                                    ValidationGroup="savegrpcontact" Display="None" ControlToValidate="ddlQuali"
                                                    InitialValue=""></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator2">
                                                </asp:ValidatorCalloutExtender>--%>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlExperienceMonth" runat="server" AutoPostBack="true" CssClass="cssddlwidth">
                                            </asp:DropDownList>
                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select Your District"
                                                    ValidationGroup="savegrpcontact" Display="None" ControlToValidate="ddlQuali"
                                                    InitialValue=""></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator2">
                                                </asp:ValidatorCalloutExtender>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Company Name
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCName" runat="server" CssClass="ccstxt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Job Title :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtJTitle" runat="server" CssClass="ccstxt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            KeySkill :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtKeySkill" runat="server" CssClass="ccstxt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnUpdateContact" ValidationGroup="savegrpcontact" Text="Update"
                                                CssClass="cssbtn" runat="server" />
                                            &nbsp;
                                            <asp:Button ID="btnCloseContact" Text="Cancel" CssClass="cssbtn" runat="server" />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
