<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    EnableViewStateMac="true" CodeFile="UserInfo.aspx.cs" Inherits="Html_UserInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Collections" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Data " %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function ClientValidate(source, arguments) {
            var File_Name = arguments.Value;
            var index = File_Name.indexOf(".");
            var str = File_Name.substring(index + 1);

            if (index != "-1") {
                if (str == "jpg" || str == "JPG" || str == "GIF" || str == "gif" || str == "BMP" || str == "bmp" || str == "PNG" || str == "png" || str == "jpeg" || str == "JPEG") {
                    arguments.IsValid = true;
                }
                else {
                    arguments.IsValid = false;
                }
            }
            else {
                arguments.IsValid = false;
            }
        }
    </script>

    <%
        List<UserRegistrationBLL> uList = new List<UserRegistrationBLL>();
        uList = UserProfileHeaderInfo();
    %>
    <div class="MainDiv">
        <div class="InnerDiv">
            <%--Heading Start here--%>
            <table class="tblSubFull2">
                <tr>
                    <td colspan="2">
                        <div>
                            <br />
                            <center>
                                <span class="spanTitle">Welcome :
                                    <asp:Label ID="lblProfileName" runat="server" Text=""><%--<%=name %>--%></asp:Label></span></center>
                            <br />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 20%;" align="center">
                        <div style="width: 120px; height: 120px; border: 1px solid #888888; background: #fff; border-radius: 5px">
                            <div style="margin-bottom: 10px; margin-left: 10px; margin-right: 10px; margin-top: 10px;">
                                <asp:Image ID="profileImage" runat="server" Height="100px" Width="100px" />
                            </div>
                        </div>
                    </td>
                    <td>
                        <div>
                            Name :
                            <asp:Label ID="myName" runat="server" Text=""><%=name %></asp:Label>
                        </div>
                        <div>
                            City :
                            <asp:Label ID="myCity" runat="server" Text=""><%=city %></asp:Label>
                        </div>
                        <div>
                            DOB ::
                            <asp:Label ID="myDOB" runat="server" Text=""><%=dob %></asp:Label>
                        </div>
                        <div>
                            Recent Visitor::
                            <%for (int x = 0; x < uList.Count; x++)
                              {              
                            %>
                            <a style="color: orange;" href="../html/ViewAddress.aspx?uId=<%=uList[x].usrUserId %>">
                                <%=uList[x].usrRecentVisitorName %>,</a>
                            <%} %>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:LinkButton ID="lnkChangePhoto" runat="server" Text="Change Photo" class="Pagelink">
                        </asp:LinkButton><img src="../KResource/Images/camera-icon.png" width="30px" height="20px"
                            alt="" />
                    </td>
                    <td align="right">
                        <asp:LinkButton ID="LinkButton1" runat="server" Text="My Heritage" class="Pagelink"
                            PostBackUrl="~/html/heritage/MethodInvokeWithJQuery.aspx"></asp:LinkButton><img src="../KResource/Images/FamilyImg1.png"
                                width="30px" height="20px" alt="" />
                        &nbsp;
                        <%-- <asp:LinkButton ID="lnkProfileSettings" runat="server" Text="Profile Setting" class="Pagelink" PostBackUrl="~/Html/profileSetting1.aspx"></asp:LinkButton><img
                            src="../KResource/Images/ProSetting.png" alt="" width="30px" height="20px" />--%>
                    </td>
                </tr>
            </table>
            <hr />
            <%--Heading end here--%>
            <asp:UpdatePanel ID="main" runat="server">
                <ContentTemplate>
                    <%--Contact info start here--%>
                    <span style="padding-top: 20px;">
                        <div>
                            <table class="tblSubFull2">
                                <tr>
                                    <td align="left">
                                        <img src="../KResource/Images/AddressImg.png" alt="" width="30px" height="30px" /><span
                                            class="spanTitle"> Contact Address</span>
                                    </td>
                                    <td align="right" width="50%">
                                        <asp:LinkButton ID="lnkEditContact" runat="server" CssClass="LinkCss">Edit <img src="../KResource/Images/EditImg.png" alt="" width="20px" height="20px"/></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:GridView ID="gvContactDisplay" AutoGenerateColumns="false" runat="server" Width="100%"
                            ShowHeader="false" OnSelectedIndexChanged="gvContactDisplay_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table class="tblSubFull2">
                                            <tr>
                                                <td align="left">Detail Address :
                                                </td>
                                                <td align="left" width="50%">
                                                    <asp:Label ID="myAddress" runat="server" Text='<%#Eval("usrAddress") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Area/Village/Town:
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label19" runat="server" Text='<%#Eval("usrArea") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">City :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("usrCity") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">District :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("usrDistrict") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">State :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("usrState") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">PIN :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("usrPIN") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Mobile No :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label12" runat="server" Text='<%#Eval("usrMobileNo") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Alt Mobile No :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label30" runat="server" Text='<%#Eval("usrAltMobileNo") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Phone Number (R):
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("usrPhoneNo") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Phone Number (O) :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label26" runat="server" Text='<%#Eval("OfficeNo") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Fax No :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label28" runat="server" Text='<%#Eval("FaxNo") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Email Id :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label32" runat="server" Text='<%#Eval("usrEmailId") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Website :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label34" runat="server" Text='<%#Eval("Website") %>'></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </span>
                    <hr />
                    <asp:ModalPopupExtender ID="mdlContact" runat="server" TargetControlID="lnkEditContact"
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
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblErrorContact" runat="server" ForeColor="red" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Name :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="fteURFirstName" runat="server" TargetControlID="txtFirstName"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:TextBox ID="txtMiddleName" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtMiddleName"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:TextBox ID="txtLastName" runat="server" Width="110px" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="fteURLastName" runat="server" TargetControlID="txtLastName"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Address :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtAddress" runat="server" Width="240px" Height="30" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Area/Village/Town :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtUserArea" runat="server" OnTextChanged="txtUserArea_TextChanged"
                                                AutoPostBack="true" CssClass="ccstxt"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" ServicePath="~/Resources/Services/AutoComplete.asmx"
                                                ServiceMethod="GetArea" TargetControlID="txtUserArea" MinimumPrefixLength="1"
                                                CompletionSetCount="12" DelimiterCharacters="" Enabled="True">
                                            </asp:AutoCompleteExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">State :
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cmbState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbState_SelectedIndexChanged"
                                                CssClass="cssddlwidth">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Your State"
                                                ValidationGroup="savegrpcontact" Display="None" ControlToValidate="cmbState"
                                                InitialValue=""></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">District :
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cmbDistrict" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbDistrict_SelectedIndexChanged"
                                                CssClass="cssddlwidth">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Your District"
                                                ValidationGroup="savegrpcontact" Display="None" ControlToValidate="cmbDistrict"
                                                InitialValue=""></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">City :
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cmbCity" runat="server" CssClass="cssddlwidth">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Your City"
                                                ValidationGroup="savegrpcontact" Display="None" ControlToValidate="cmbCity" InitialValue=""></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">PIN :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPin" runat="server" MaxLength="6" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="ftbPin" runat="server" TargetControlID="txtPin"
                                                FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Date Of Birth :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDOB" runat="server" MaxLength="10" CssClass="ccstxt" Enabled="false"></asp:TextBox>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/KResource/Images/CreateEvent.png"
                                                Width="15px" Height="15px"></asp:Image>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDOB"
                                                PopupButtonID="Image1">
                                            </asp:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Mobile Number :
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblMobilePrefix" runat="server" Text="  +91-" Font-Size="Small"></asp:Label>
                                            <asp:TextBox ID="txtMobileNumber" runat="server" ReadOnly="true" CssClass="ccstxt"
                                                Enabled="false"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="ftbMobileNumber" runat="server" TargetControlID="txtMobileNumber"
                                                FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Show To :
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlControlMobile" runat="server" CssClass="cssddlwidth">
                                                <asp:ListItem Value="1">Everyone</asp:ListItem>
                                                <asp:ListItem Value="0">Only Friend</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Alt. Mobile Number :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtAltMobileNumber" runat="server" MaxLength="10" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="ftbAltMobileNo" runat="server" TargetControlID="txtAltMobileNumber"
                                                FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Phone Number (R) :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPhoneNumber" runat="server" MaxLength="11" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="ftbPhoneNumber" runat="server" TargetControlID="txtPhoneNumber"
                                                FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ValidationExpression="^[0-9]{10,}$"
                                                ValidationGroup="savegrpcontact" runat="server" ControlToValidate="txtMobileNumber"
                                                ErrorMessage="Minimum 10 Numbers Required." Display="None">
                                            </asp:RegularExpressionValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RegularExpressionValidator5">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Phone Number (O) :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPhoneOffice" runat="server" MaxLength="11" CssClass="ccstxt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Fax No :
                                        </td>
                                        <td class="tdTextInner" align="left">
                                            <asp:TextBox ID="txtFaxNo" runat="server" MaxLength="11" CssClass="ccstxt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Email Id :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtEmailId" runat="server" CssClass="ccstxt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Website :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtWebsite" runat="server" CssClass="ccstxt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right"></td>
                                        <td align="left">
                                            <asp:Button ID="btnUpdateContact" ValidationGroup="savegrpcontact" Text="Update"
                                                CssClass="cssbtn" runat="server" OnClientClick="return ClientValidate()" OnClick="btnUpdateContact_Click" />
                                            &nbsp;
                                            <asp:Button ID="btnCloseContact" Text="Cancel" CssClass="cssbtn" runat="server" />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </asp:Panel>
                    <%--Contact info end here--%>
                    <%--Start of Professional Information--%>
                    <span style="padding-top: 20px;">
                        <div>
                            <table class="tblSubFull2">
                                <tr>
                                    <td align="left">
                                        <img src="../KResource/Images/Personalinfo.png" width="30px" height="30px" alt="" /><span
                                            class="spanTitle"> Professional Information</span>
                                    </td>
                                    <td align="right" width="50%">
                                        <asp:LinkButton ID="lnkEditProfessional" runat="server" CssClass="LinkCss">Edit <img src="../KResource/Images/EditImg.png" alt="" width="20px" height="20px"/></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:GridView ID="gvProfessionalInfo" AutoGenerateColumns="false" runat="server"
                            ShowHeader="false" Width="100%" OnSelectedIndexChanged="gvProfessionalInfo_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table class="tblSubFull2">
                                            <tr>
                                                <td align="left">Highest Qualification :
                                                </td>
                                                <td align="left" width="50%">
                                                    <asp:Label ID="myUserId" runat="server" Text='<%#Eval("usrHighestQualification") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Board / University :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="myAddress" runat="server" Text='<%#Eval("usrBoardUniversity") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Profession :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("usrProfession") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Industry/Work Area :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("usrIndustry") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Company Name :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("usrCompanyName") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Carrer Skill :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("usrCarrerSkill") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Carrer Interest:
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label12" runat="server" Text='<%#Eval("usrCarrerInterest") %>'></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </span>
                    <asp:ModalPopupExtender ID="mdlProfessional" runat="server" TargetControlID="lnkEditProfessional"
                        PopupControlID="pnlEditProfessional" BackgroundCssClass="modalBackground" CancelControlID="btnCloseProfessional"
                        PopupDragHandleControlID="pnlEditProfessional">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlEditProfessional" runat="server" class="ModalPop">
                        <div class="csspop">
                            <center>
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            <center>
                                                <img src="../KResource/Images/Personalinfo.png" width="30px" height="30px" alt="" />
                                                <span class="spanHeader">Professional Information Update</span>
                                            </center>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblErrProfessional" runat="server" ForeColor="red" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Highest Qualification :
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cmbQualification" runat="server" CssClass="cssddlwidth">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Board/University :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtBoardUniversity" runat="server" OnTextChanged="txtBoardUniversity_TextChanged"
                                                AutoPostBack="true" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="ftbBoardUniversity" runat="server" TargetControlID="txtBoardUniversity"
                                                FilterType="LowercaseLetters,UppercaseLetters,Custom" ValidChars=" .,()&/_">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" ServicePath="~/Resources/Services/AutoComplete.asmx"
                                                ServiceMethod="GetBoardUniversity" TargetControlID="txtBoardUniversity" MinimumPrefixLength="1"
                                                CompletionSetCount="12" DelimiterCharacters="" Enabled="True">
                                            </asp:AutoCompleteExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Profession:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtprofession" runat="server" OnTextChanged="txtprofession_TextChanged"
                                                CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="ftetxtprofession" runat="server" TargetControlID="txtprofession"
                                                FilterType="LowercaseLetters,UppercaseLetters,Custom" ValidChars=" .,()&/_">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" ServicePath="~/Resources/Services/AutoComplete.asmx"
                                                ServiceMethod="GetProfession" TargetControlID="txtprofession" MinimumPrefixLength="1"
                                                CompletionSetCount="12" DelimiterCharacters="" Enabled="True">
                                            </asp:AutoCompleteExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Industry/Work Area:
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cmbIndustry" runat="server" CssClass="cssddlwidth">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Company Name:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCompanyName" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="fteUserComanyName" runat="server" TargetControlID="txtCompanyName"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ,.&()_/">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Carrer Skill:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCarrerSkill" runat="server" CssClass="ccstxt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Carrer Interest:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCarrerInterest" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right"></td>
                                        <td align="left">
                                            <asp:Button ID="btnUpdateProfessional" Text="Update" ValidationGroup="a" CssClass="cssbtn"
                                                runat="server" OnClientClick="return ClientValidate()" OnClick="btnUpdateProfessional_Click" />
                                            &nbsp;
                                            <asp:Button ID="btnCloseProfessional" Text="Cancel" CssClass="cssbtn" runat="server" />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </asp:Panel>
                    <%--End Of Professional Information--%>
                    <%--Start of Social Information--%>
                    <hr />
                    <span style="padding-top: 20px;">
                        <div>
                            <table class="tblSubFull2">
                                <tr>
                                    <td align="left">
                                        <img src="../KResource/Images/DocumentImg.png" width="30px" height="30px" alt="" /><span
                                            class="spanTitle"> Special Information</span>
                                    </td>
                                    <td align="right" width="50%">
                                        <asp:LinkButton ID="lnkEditSocial" runat="server" CssClass="LinkCss">Edit <img src="../KResource/Images/EditImg.png" alt="" width="20px" height="20px"/></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:GridView ID="gvSocialInfo" runat="server" AutoGenerateColumns="false" ShowHeader="false"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table class="tblSubFull2">
                                            <tr>
                                                <td align="left">Driving Licence No :
                                                </td>
                                                <td align="left" width="50%">
                                                    <asp:Label ID="myUserIdealMatch" runat="server" Text='<%#Eval("usrIdealMatch") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Aadhar Card No :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="myBestFeature" runat="server" Text='<%#Eval("usrBestFeature") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Voting Card No :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("usrBuild") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">PAN Card No :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label6" runat="server" Text='<%#Eval("usrPoliticalView") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">My Height :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("usrHeight") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">My Favorate Books :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("usrBooks") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">My Favorate Music :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("usrMusic") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <%--<tr class="grdTr">
                                                        <td class="grdTdLabel">
                                                            <asp:Label ID="Label14" Visible="false" runat="server" Text="Socail Member Of :"></asp:Label>
                                                        </td>
                                                        <td class="grdTdValue">
                                                            <asp:Label ID="Label15" Visible="false" runat="server" Text='<%#Eval("usrMebSocial") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr class="grdTr">
                                                        <td class="grdTdLabel">
                                                            <asp:Label ID="Label16" Visible="false" runat="server" Text="Political Member Of :"></asp:Label>
                                                        </td>
                                                        <td class="grdTdValue">
                                                            <asp:Label ID="Label18" Visible="false" runat="server" Text='<%#Eval("usrMebPolitical") %>'></asp:Label>
                                                        </td>
                                                    </tr>--%>
                                            <tr>
                                                <td align="left">My Religion:
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label15" runat="server" Text='<%#Eval("Religion") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">My Caste:
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label77" runat="server" Text='<%#Eval("usrCaste") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">My Caste Category:
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label79" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </span>
                    <asp:ModalPopupExtender ID="mdlSocial" runat="server" TargetControlID="lnkEditSocial"
                        PopupControlID="pnlEditSocial" BackgroundCssClass="modalBackground" CancelControlID="btnCloseSocial"
                        PopupDragHandleControlID="pnlEditSocial">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlEditSocial" runat="server" class="ModalPop">
                        <div class="csspop">
                            <center>
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            <center>
                                                <img src="../KResource/Images/DocumentImg.png" width="30px" height="30px" alt="" /><span
                                                    class="spanHeader"> Special Information Update</span>
                                            </center>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblErrSocial" runat="server" ForeColor="red" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Driving Licence No :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtIdealMatch" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="ftbIdealMatch" runat="server" TargetControlID="txtIdealMatch"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()&' ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Aadhar Card No :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtBestFeature" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="fteBestfeature" runat="server" TargetControlID="txtBestFeature"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()&' ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Woting Card No :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtBuild" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="fteBuild" runat="server" TargetControlID="txtBuild"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()&' ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">PAN Card No :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPoliticalView" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="ftePoliticalView" runat="server" TargetControlID="txtPoliticalView"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()&' ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">My Height :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtHeight" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="fteHeight" runat="server" TargetControlID="txtHeight"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()&' ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">My Favorate Books :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtBooks" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="fteBooks" runat="server" TargetControlID="txtBooks"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()&' ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">My Favorate Music :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtMusic" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="fteMusic" runat="server" TargetControlID="txtMusic"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()&' ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label11" runat="server" Visible="false" ForeColor="#fff" Text="Social Membership:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtMembershipSocial" runat="server" Visible="false" OnTextChanged="txtMembershipSocial_TextChanged"
                                                AutoPostBack="true" CssClass="ccstxt"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" ServicePath="~/Resources/Services/AutoComplete.asmx"
                                                ServiceMethod="GetSocialMembership" TargetControlID="txtMembershipSocial" MinimumPrefixLength="1"
                                                CompletionSetCount="12" DelimiterCharacters="" Enabled="True">
                                            </asp:AutoCompleteExtender>
                                            <asp:FilteredTextBoxExtender ID="fteSocialMembership" runat="server" TargetControlID="txtMembershipSocial"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars="/-_,.()&' ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label12" runat="server" Visible="false" ForeColor="#fff" Text="Political Membership:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtMembershipPolitical" Visible="false" runat="server" OnTextChanged="txtMembershipPolitical_TextChanged"
                                                AutoPostBack="true" CssClass="ccstxt"></asp:TextBox>
                                            <asp:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" ServicePath="~/Resources/Services/AutoComplete.asmx"
                                                ServiceMethod="GetPoliticalMembership" TargetControlID="txtMembershipPolitical"
                                                MinimumPrefixLength="1" CompletionSetCount="12" DelimiterCharacters="" Enabled="True">
                                            </asp:AutoCompleteExtender>
                                            <asp:FilteredTextBoxExtender ID="ftePoliticalMembership" runat="server" TargetControlID="txtMembershipPolitical"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars="/-_,.()&' ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Religion:
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlreligion" runat="server" CssClass="cssddlwidth">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Category:
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="cssddlwidth">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Caste:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCaste" runat="server" CssClass="ccstxt"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td align="left">
                                            <asp:Button ID="btnUpdateSocial" Text="Update" CssClass="cssbtn" runat="server" OnClientClick="return ClientValidate()"
                                                OnClick="btnUpdateSocial_Click" />
                                            &nbsp;
                                            <asp:Button ID="btnCloseSocial" Text="Cancel" CssClass="cssbtn" runat="server" />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </asp:Panel>
                    <%--End of Spacial Information--%>
                    <%-- Start of family information--%>
                    <hr />
                    <span style="padding-top: 20px;">
                        <div>
                            <table class="tblSubFull2">
                                <tr>
                                    <td align="left">
                                        <img src="../KResource/Images/FamilyImg1.png" width="30px" height="25px" alt="" /><span
                                            class="spanTitle"> Family Information</span>
                                    </td>
                                    <td align="right" width="50%">
                                        <asp:LinkButton ID="lnkFamilyInfo" runat="server" CssClass="LinkCss">Edit <img src="../KResource/Images/EditImg.png" alt="" width="20px" height="20px"/></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:GridView ID="gvFamilyInfo" runat="server" AutoGenerateColumns="false" Width="100%"
                            ShowHeader="false">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table class="tblSubFull2">
                                            <tr>
                                                <td align="left">Life Partner :
                                                </td>
                                                <td align="left" width="50%">
                                                    <asp:Label ID="lblFIlfptr" runat="server" Text='<%#Eval("usrFIlfptr") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td align="left">Son/Daughter First
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Name :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblFIname1" runat="server" Text='<%#Eval("usrFIname1") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Gender :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblFIgender1" runat="server" Text='<%#Eval("usrFIgender1") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">School :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblFIschool1" runat="server" Text='<%#Eval("usrFIschool1") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Class :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblFIclass1" runat="server" Text='<%#Eval("usrFIclass1") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Roll No :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblFIrollNo1" runat="server" Text='<%#Eval("usrFIrollNo1") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td align="left">Son/Daughter Second
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Name :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblFIname2" runat="server" Text='<%#Eval("usrFIname2") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Gender :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblFIgender2" runat="server" Text='<%#Eval("usrFIgender2") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">School :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblFIschool2" runat="server" Text='<%#Eval("usrFIschool2") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Class :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblFIclass2" runat="server" Text='<%#Eval("usrFIclass2") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Roll No :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblFIrollNo2" runat="server" Text='<%#Eval("usrFIrollNo2") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td align="left">Son/Daughter Third
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Name :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblFIname3" runat="server" Text='<%#Eval("usrFIname3") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Gender :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblFIgender3" runat="server" Text='<%#Eval("usrFIgender3") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">School :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblFIschool3" runat="server" Text='<%#Eval("usrFIschool3") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Class :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblFIclass3" runat="server" Text='<%#Eval("usrFIclass3") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">Roll No :
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblFIrollNo3" runat="server" Text='<%#Eval("usrFIrollNo3") %>'></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </span>
                    <asp:ModalPopupExtender ID="mpopupFamilyInfo" runat="server" TargetControlID="lnkFamilyInfo"
                        PopupControlID="pnlEditFamilyInfo" BackgroundCssClass="modalBackground" CancelControlID="btnCloseFamilyInfo">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlEditFamilyInfo" runat="server" class="ModalPop">
                        <div class="csspop">
                            <center>
                                <table>
                                    <tr>
                                        <td colspan="6">
                                            <center>
                                                <img src="../KResource/Images/FamilyImg1.png" width="30px" height="25px" alt="" /><span
                                                    class="spanHeader"> Family Information Update</span>
                                            </center>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <asp:Label ID="Label42" runat="server" ForeColor="red" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"></td>
                                        <td align="right">Life Partner:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFIlfptr" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtFIlfptr"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()&' ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td colspan="2"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">Son/Daughter First
                                        </td>
                                        <td colspan="2" align="center">Son/Daughter Second
                                        </td>
                                        <td colspan="2" align="center">Son/Daughter Third
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Name:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFIname1" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtFIname1"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()&' ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td align="right">Name:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFIname2" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtFIname2"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()&' ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td align="right">Name :
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFIname3" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="txtFIname3"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()&' ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Gender:
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlFIgendet1" runat="server" CssClass="cssddlwidth">
                                                <asp:ListItem Text="Male" Selected="True" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Female" Selected="False" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">Gender:
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlFIgender2" runat="server" CssClass="cssddlwidth">
                                                <asp:ListItem Text="Male" Selected="True" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Female" Selected="False" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">Gender:
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlFIgender3" runat="server" CssClass="cssddlwidth">
                                                <asp:ListItem Text="Male" Selected="True" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Female" Selected="False" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">School:
                                        </td>
                                        <%--<td class="tdTextInner" align="center">
                                        <asp:TextBox ID="txtFIschool1" runat="server" Width="140px" onfocus="ChangeCSS(this, event)"
                                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtFIschool1"
                                            FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()&' ">
                                        </asp:FilteredTextBoxExtender>
                                    </td>--%>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlFIschool1" runat="server" CssClass="cssddlwidth">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">School:
                                        </td>
                                        <%--<td class="tdTextInner" align="center">
                                        <asp:TextBox ID="txtFIschool2" runat="server" Width="140px" onfocus="ChangeCSS(this, event)"
                                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtFIschool2"
                                            FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()&' ">
                                        </asp:FilteredTextBoxExtender>
                                    </td>--%>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlFIschool2" runat="server" CssClass="cssddlwidth">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">School:
                                        </td>
                                        <%--<td class="tdTextInner" align="center">
                                        <asp:TextBox ID="txtFIschool3" runat="server" Width="140px" onfocus="ChangeCSS(this, event)"
                                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" TargetControlID="txtFIschool3"
                                            FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()&' ">
                                        </asp:FilteredTextBoxExtender>
                                    </td>--%>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlFIschool3" runat="server" CssClass="cssddlwidth">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Class:
                                        </td>
                                        <%--<td class="tdTextInner" align="center">
                                        <asp:TextBox ID="txtFIclass1" runat="server" Width="140px" onfocus="ChangeCSS(this, event)"
                                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtFIclass1"
                                            FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()&' ">
                                        </asp:FilteredTextBoxExtender>
                                    </td>--%>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlFIclass1" runat="server" CssClass="cssddlwidth">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">Class:
                                        </td>
                                        <%--<td class="tdTextInner" align="center">
                                        <asp:TextBox ID="txtFIclass2" runat="server" Width="140px" onfocus="ChangeCSS(this, event)"
                                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtFIclass2"
                                            FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()&' ">
                                        </asp:FilteredTextBoxExtender>
                                    </td>--%>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlFIclass2" runat="server" CssClass="cssddlwidth">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">Class:
                                        </td>
                                        <%--<td class="tdTextInner" align="center">
                                        <asp:TextBox ID="txtFIclass3" runat="server" Width="140px" onfocus="ChangeCSS(this, event)"
                                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" TargetControlID="txtFIclass3"
                                            FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()&' ">
                                        </asp:FilteredTextBoxExtender>
                                    </td>--%>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlFIclass3" runat="server" CssClass="cssddlwidth">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Roll No:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFIrollNo1" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtFIrollNo1"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()&' ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td align="right">Roll No:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFIrollNo2" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtFIrollNo2"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()&' ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td align="right">Roll No:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFIrollNo3" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" TargetControlID="txtFIrollNo3"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()&' ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2"></td>
                                        <td align="left">
                                            <asp:Button ID="btnUpdateFamilyInfo" Text="Update" CssClass="cssbtn" runat="server"
                                                OnClick="btnUpdateFamilyInfo_Click" />
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnCloseFamilyInfo" Text="Cancel" CssClass="cssbtn" runat="server" />
                                        </td>
                                        <td colspan="2">
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </asp:Panel>
                    <%--End of Family Information--%>
                    <%--Start of Social Information--%>
                    <hr />
                    <span style="padding-top: 20px;">
                        <div>
                            <table class="tblSubFull2">
                                <tr>
                                    <td align="left">
                                        <img src="../KResource/Images/MemberImg.png" alt="" width="30px" height="30px" />
                                        <span class="spanTitle">Details about various memberships</span>
                                    </td>
                                    <td align="right" width="50%">
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <table class="tblSubFull2">
                            <tr>
                                <td align="left">Social Group
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblSocial" runat="server"></asp:Label>
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <asp:LinkButton ID="lnkSocialGroup" runat="server" OnClick="lnkSocialGroup_Click"
                                        CssClass="LinkCss">Edit <img src="../KResource/Images/EditImg.png" alt="" width="20px" height="20px"/></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">Professional Group
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblProfessional" runat="server"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:LinkButton ID="lnkProfessional" runat="server" CssClass="LinkCss">Edit <img src="../KResource/Images/EditImg.png" alt="" width="20px" height="20px"/></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">Bussiness Group
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblBussiness" runat="server"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:LinkButton ID="lnkBussinessGroup" runat="server" CssClass="LinkCss">Edit <img src="../KResource/Images/EditImg.png" alt="" width="20px" height="20px"/></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">Political Group
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblPolitical" runat="server"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:LinkButton ID="lnkPolitical" runat="server" CssClass="LinkCss">Edit <img src="../KResource/Images/EditImg.png" alt="" width="20px" height="20px"/></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">MemberOf
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblMemberOf" runat="server"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:LinkButton ID="lnkMemberOf" runat="server" CssClass="LinkCss">Edit <img src="../KResource/Images/EditImg.png" alt="" width="20px" height="20px"/></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">Favorite News Papers Group
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblFNPaper" runat="server"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:LinkButton ID="lnkFavNewsPaper" runat="server" CssClass="LinkCss">Edit <img src="../KResource/Images/EditImg.png" alt="" width="20px" height="20px"/></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">Favorite News channels Group
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblFNChaneel" runat="server"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:LinkButton ID="lnkFavNewsChannel" runat="server" CssClass="LinkCss">Edit <img src="../KResource/Images/EditImg.png" alt="" width="20px" height="20px"/></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </span>
                    <hr />
                    <span style="padding-top: 20px;">
                        <div>
                            <table class="tblSubFull2">
                                <tr>
                                    <td align="left" width="50%">
                                        <img src="../KResource/Images/shockImg.png" width="30px" height="25px" alt="" /><span
                                            class="spanTitle"> About Electric Consumer No.</span>
                                    </td>
                                    <td align="right" width="50%"></td>
                                </tr>
                            </table>
                        </div>
                        <table class="tblSubFull2">
                            <tr>
                                <td align="left">Consumer No
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblConsumerNo" runat="server"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:LinkButton ID="lnkConsumerNo" runat="server" CssClass="LinkCss">Edit <img src="../KResource/Images/EditImg.png" alt="" width="20px" height="20px"/></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </span>
                    <%--Other Info end Here--%>
                    <%--Change Social Group Start Here--%>
                    <asp:ModalPopupExtender ID="mdlSocialGroup" runat="server" TargetControlID="lnkSocialGroup"
                        PopupControlID="pnlSocialGroup" BackgroundCssClass="modalBackground" CancelControlID="btnSocialGroupCancel"
                        PopupDragHandleControlID="pnlSocialGroup">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlSocialGroup" runat="server" class="ModalPop">
                        <div class="csspop">
                            <center>
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            <center>
                                                <img src="../KResource/Images/MemberImg.png" alt="" width="30px" height="30px" />
                                                <span class="spanHeader">Update Social Group </span>
                                            </center>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Select Social Group
                                        </td>
                                        <td align="left">
                                            <asp:ListBox ID="lstSocial" runat="server" SelectionMode="Multiple" Width="177px"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td align="left">
                                            <asp:Button ID="btnSocialGroup" Text="Update" CssClass="cssbtn" runat="server" OnClick="btnSocialGroup_Click" />
                                            &nbsp;
                                            <asp:Button ID="btnSocialGroupCancel" Text="Cancel" CssClass="cssbtn" runat="server" />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </asp:Panel>
                    <%--Chagne Social Group end here--%>
                    <%--Change Professional Group Start Here--%>
                    <asp:ModalPopupExtender ID="mdlProfessionalGroup" runat="server" TargetControlID="lnkProfessional"
                        PopupControlID="pnlProfessionalGroup" BackgroundCssClass="modalBackground" CancelControlID="btnProfessionalGroupCancel"
                        PopupDragHandleControlID="pnlProfessionalGroup">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlProfessionalGroup" runat="server" class="ModalPop">
                        <div class="csspop">
                            <center>
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            <center>
                                                <img src="../KResource/Images/MemberImg.png" alt="" width="30px" height="30px" /><span
                                                    class="spanHeader"> Update Professional Group </span>
                                            </center>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Select Professional Group
                                        </td>
                                        <td align="left">
                                            <asp:ListBox ID="lstProfessional" runat="server" SelectionMode="Multiple" Width="177px"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td align="left">
                                            <asp:Button ID="btnProfessionalGroup" Text="Update" CssClass="cssbtn" runat="server"
                                                OnClick="btnProfessionalGroup_Click" />
                                            &nbsp;
                                            <asp:Button ID="btnProfessionalGroupCancel" Text="Cancel" CssClass="cssbtn" runat="server" />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </asp:Panel>
                    <%--Chagne Professional Group end here--%>
                    <%--Change Bussiness Group Start Here--%>
                    <asp:ModalPopupExtender ID="mdlBussinessGroup" runat="server" TargetControlID="lnkBussinessGroup"
                        PopupControlID="pnlBussinessGroup" BackgroundCssClass="modalBackground" CancelControlID="btnBussinessGroupCancel"
                        PopupDragHandleControlID="pnlBussinessGroup">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlBussinessGroup" runat="server" class="ModalPop">
                        <div class="csspop">
                            <center>
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            <center>
                                                <img src="../KResource/Images/MemberImg.png" alt="" width="30px" height="30px" />
                                                <span class="spanHeader">Update Bussiness Group</span>
                                            </center>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Select Bussiness Group
                                        </td>
                                        <td align="left">
                                            <asp:ListBox ID="lstBussiness" runat="server" SelectionMode="Multiple" Width="177px"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="btnBussinessGroup" Text="Update" CssClass="cssbtn" runat="server"
                                                OnClick="btnBussinessGroup_Click" />
                                            &nbsp;
                                            <asp:Button ID="btnBussinessGroupCancel" Text="Cancel" CssClass="cssbtn" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </asp:Panel>
                    <%--Chagne Bussiness Group end here--%>
                    <%--Change Political Group Start Here--%>
                    <asp:ModalPopupExtender ID="mdlPoliticalGroup" runat="server" TargetControlID="lnkPolitical"
                        PopupControlID="pnlPoliticalGroup" BackgroundCssClass="modalBackground" CancelControlID="btnPoliticalGroupCancel"
                        PopupDragHandleControlID="pnlPoliticalGroup">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlPoliticalGroup" runat="server" class="ModalPop">
                        <div class="csspop">
                            <center>
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            <center>
                                                <img src="../KResource/Images/MemberImg.png" alt="" width="30px" height="30px" />
                                                <span class="spanHeader">Update Political Group</span>
                                            </center>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Select Political Group
                                        </td>
                                        <td align="left">
                                            <asp:ListBox ID="lstPolitical" runat="server" SelectionMode="Multiple" Width="177px"
                                                AutoPostBack="True"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="btnPoliticalGroup" Text="Update" CssClass="cssbtn" runat="server"
                                                OnClick="btnPoliticalGroup_Click" />
                                            &nbsp;
                                            <asp:Button ID="btnPoliticalGroupCancel" Text="Cancel" CssClass="cssbtn" runat="server" />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </asp:Panel>
                    <%--Chagne Political end here--%>
                    <%--Change Member of Start Here--%>
                    <asp:ModalPopupExtender ID="mdlMemberOf" runat="server" TargetControlID="lnkMemberOf"
                        PopupControlID="pnlMemberOf" BackgroundCssClass="modalBackground" CancelControlID="btnMemberOfCancel"
                        PopupDragHandleControlID="pnlMemberOf">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlMemberOf" runat="server" class="ModalPop">
                        <div class="csspop">
                            <center>
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            <center>
                                                <img src="../KResource/Images/MemberImg.png" alt="" width="30px" height="30px" /><span
                                                    class="spanHeader"> Update Member Of</span>
                                            </center>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Select Member Of
                                        </td>
                                        <td align="left">
                                            <asp:ListBox ID="lstMemberOf" runat="server" SelectionMode="Multiple" Width="177px"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <asp:Button ID="btnMemberOf" Text="Update" CssClass="cssbtn" runat="server" OnClick="btnMemberOf_Click" />
                                            &nbsp;
                                            <asp:Button ID="btnMemberOfCancel" Text="Cancel" CssClass="cssbtn" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </asp:Panel>
                    <%--Chagne photo end here--%>
                    <%--Change News paper of Start Here--%>
                    <asp:ModalPopupExtender ID="mpUpNewspaper" runat="server" TargetControlID="lnkFavNewsPaper"
                        PopupControlID="pnlNewsPaper" BackgroundCssClass="modalBackground" CancelControlID="btnPnlNewsPaperCancel"
                        PopupDragHandleControlID="pnlNewsPaper">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlNewsPaper" runat="server" class="ModalPop">
                        <div class="csspop">
                            <center>
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            <center>
                                                <img src="../KResource/Images/MemberImg.png" alt="" width="30px" height="30px" /><span
                                                    class="spanHeader"> Update Favorite News Papers Group</span>
                                            </center>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Select Favorite News Papers Group
                                        </td>
                                        <td align="left">
                                            <asp:ListBox ID="lstNewsPaper" runat="server" SelectionMode="Multiple" Width="177px"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td align="left">
                                            <asp:Button ID="btnPnlNWSUpdate" Text="Update" CssClass="cssbtn" runat="server" OnClick="btnPnlNWSUpdate_Click" />
                                            &nbsp;
                                            <asp:Button ID="btnPnlNewsPaperCancel" Text="Cancel" CssClass="cssbtn" runat="server" />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </asp:Panel>
                    <%--Chagne News Paper end here--%>
                    <%--Change Channel of Start Here--%>
                    <asp:ModalPopupExtender ID="mpUpVhannel" runat="server" TargetControlID="lnkFavNewsChannel"
                        PopupControlID="pnlNewspaperUpdate" BackgroundCssClass="modalBackground" CancelControlID="btnMPChanCancel"
                        PopupDragHandleControlID="pnlNewspaperUpdate">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlNewspaperUpdate" runat="server" class="ModalPop">
                        <div class="csspop">
                            <center>
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            <center>
                                                <img src="../KResource/Images/MemberImg.png" alt="" width="30px" height="30px" /><span
                                                    class="spanHeader"> Update Favorite News channels Group</span>
                                            </center>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Select Favorite News channels Group
                                        </td>
                                        <td align="left">
                                            <asp:ListBox ID="lstChannel" runat="server" SelectionMode="Multiple" Width="177px"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td align="left">
                                            <asp:Button ID="btnChannelUpdate" Text="Update" CssClass="cssbtn" runat="server"
                                                OnClick="btnChannelUpdate_Click" />
                                            &nbsp;
                                            <asp:Button ID="btnMPChanCancel" Text="Cancel" CssClass="cssbtn" runat="server" />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </asp:Panel>
                    <%--Chagne channel end here--%>
                    <%--Change Social Group Start Here--%>
                    <asp:ModalPopupExtender ID="mdlConsumer" runat="server" TargetControlID="lnkConsumerNo"
                        PopupControlID="pnlConsumerNo" BackgroundCssClass="modalBackground" CancelControlID="btnConsumerNoCancel"
                        PopupDragHandleControlID="pnlConsumerNo">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlConsumerNo" runat="server" class="ModalPop">
                        <div class="csspop">
                            <center>
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            <center>
                                                <img src="../KResource/Images/shockImg.png" width="30px" height="25px" alt="" /><span
                                                    class="spanHeader"> Update Electric Meter Consumer No</span>
                                            </center>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblConsumerError" runat="server" ForeColor="red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">Enter your Consumer No
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtConsumerNo" runat="server" CssClass="ccstxt"></asp:TextBox>
                                            <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" CssClass="cssbtn" Text="Add" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td align="left">
                                            <asp:ListBox ID="lstConsumerNo" runat="server" SelectionMode="Multiple" Width="177px"></asp:ListBox>
                                            <br />
                                            <asp:Button ID="Remove" OnClick="btnRemove_Click" runat="server" CssClass="cssbtn"
                                                Text="Remove" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="lbl"></td>
                                        <td align="left">
                                            <asp:Button ID="btnAddConsumerNo" Text="Update" CssClass="cssbtn" runat="server"
                                                OnClick="btnAddConsumerNo_Click" />
                                            &nbsp;
                                            <asp:Button ID="btnConsumerNoCancel" Text="Cancel" CssClass="cssbtn" runat="server" />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--Change Photo Start Here--%>
            <asp:ModalPopupExtender ID="mdlChangePhoto" runat="server" TargetControlID="lnkChangePhoto"
                PopupControlID="pnlPhotoUpload" BackgroundCssClass="modalBackground" CancelControlID="btnCancel"
                PopupDragHandleControlID="pnlPhotoUpload">
            </asp:ModalPopupExtender>
            <asp:Panel ID="pnlPhotoUpload" runat="server" class="ModalPop">
                <div class="csspop">
                    <center>
                        <table>
                            <tr>
                                <td colspan="2">
                                    <center>
                                        <span class="spanHeader">Change your photo</span>
                                    </center>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Select Photo
                                </td>
                                <td align="left">
                                    <asp:FileUpload ID="photoUpload" runat="server" onkeypress="return false;" onkeydown="return false;" />
                                    <asp:RequiredFieldValidator ID="reqFileUpload" runat="server" ErrorMessage="* Please select an image to upload."
                                        Display="Dynamic" ControlToValidate="photoUpload" ValidationGroup="imageupload"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ClientValidate"
                                        ValidationGroup="imageupload" ControlToValidate="photoUpload" Display="Dynamic"
                                        ErrorMessage="* Please  Select [ GIF , JPEG , BMP, PNG ] Images Only">
                                    </asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left">
                                    <asp:Button ID="btnChange" Text="Change" CssClass="cssbtn" runat="server" OnClientClick="return ClientValidate()"
                                        OnClick="btnChange_Click" />
                                    &nbsp;
                                    <asp:Button ID="btnCancel" Text="Cancel" CssClass="cssbtn" runat="server" />
                                    <br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </center>
                </div>
            </asp:Panel>
            <%--Chagne photo end here--%>
            <%--Chagne photo end here--%>
        </div>
    </div>
</asp:Content>
