<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="JobseekerProfile.aspx.cs" Inherits="MarketingAdmin_JobseekerProfile" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Collections" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Data " %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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

 
<div align="left" style="width: 100%">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
 <tr><td>Search By Mobile No</td>
   <td><asp:TextBox ID="txtMobileNo" runat="server"></asp:TextBox> </td></tr>
 <tr><td></td>
  <td><asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Search" 
          onclick="btnSearch_Click" />
     </td></tr>
     
  <tr><td></td>
  <td><asp:Label ID="lblError" runat="server" CssClass="Error" Visible="false"></asp:Label>
     </td></tr> 
     </table> 
</div>
<div id="UserInfo" runat="server" visible="false" align="left" style="width: 100%" >
<%
        List<UserRegistrationBLL> uList = new List<UserRegistrationBLL>();
        uList = UserProfileHeaderInfo();
    %>
<table class="tblSubFull" border="1" height="400px">
        <tr>
            <td valign="top">
                <%--Heading Start here--%>
                <table class="tblSubFull">
                    <tr>
                        <td colspan="2">
                            <div class="searchResultHeader">
                                 <asp:Label ID="lblProfileHead" runat="server" Text="Welcome :: "></asp:Label>
                                <asp:Label ID="lblProfileName" runat="server" Text=""><%=name %></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 20%;" align="left">
                            <asp:Image ID="profileImage" runat="server" AlternateText="MyImage" Height="100px"
                                Width="100px" />
                        </td>
                        <td>
                            <div>
                               <asp:Label ID="lblName" runat="server" Text="Name ::" CssClass="text1"></asp:Label>
                                <asp:Label ID="myName" runat="server" Text="" Font-Size="Small" CssClass="text2"><%=name %></asp:Label>
                                </div>
                            <div>
                               <asp:Label ID="lblCity" runat="server" Text="City ::" CssClass="text1"></asp:Label>
                                <asp:Label ID="myCity" runat="server" Text="" Font-Size="Small" CssClass="text2"><%=city %></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="lblDOB" runat="server" Text="DOB ::" CssClass="text1"></asp:Label>
                                <asp:Label ID="myDOB" runat="server" Text="" Font-Size="Small" CssClass="text2"><%=dob %></asp:Label>
                             </div>
                           
                        </td>
                    </tr>
                   
                    <tr>
                      <td align="left">
                            <asp:LinkButton ID="lnkChangePhoto" runat="server" Text="Change Photo" CssClass="link"
                                Font-Size="12px">
                            </asp:LinkButton>
                        </td>
                    </tr>
                    
                </table>
                 <asp:UpdatePanel ID="main" runat="server">
                    <ContentTemplate>
                        <%--Contact info start here--%>
                        <span style="padding-top: 20px;">
                            <div class="searchResultHeader">
                                <table width="100%">
                                    <tr>
                                        <td align="left" width="50%">
                                            <asp:Label ID="Label20" runat="server" Text="Contact Address" CssClass="link"></asp:Label>
                                        </td>
                                        <td align="right" width="50%">
                                            <asp:LinkButton ID="lnkEditContact" runat="server" CssClass="link">Edit</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <asp:GridView ID="gvContactDisplay" AutoGenerateColumns="false" runat="server" Width="100%"
                                ShowHeader="false">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <table class="grdTable">
                                                <tr class="grdTr">
                                                    <td class="grdTdLabel">
                                                        <asp:Label ID="lblAddress" runat="server" Text="Detail Address :"></asp:Label>
                                                    </td>
                                                    <td class="grdTdValue">
                                                        <asp:Label ID="myAddress" runat="server" Text='<%#Eval("usrAddress") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="grdTr">
                                                    <td class="grdTdLabel">
                                                        <asp:Label ID="Label18" runat="server" Text="Area/Village/Town:"></asp:Label>
                                                    </td>
                                                    <td class="grdTdValue">
                                                        <asp:Label ID="Label19" runat="server" Text='<%#Eval("usrArea") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="grdTr">
                                                    <td class="grdTdLabel">
                                                        <asp:Label ID="Label5" runat="server" Text="City :"></asp:Label>
                                                    </td>
                                                    <td class="grdTdValue">
                                                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("usrCity") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="grdTr">
                                                    <td class="grdTdLabel">
                                                        <asp:Label ID="Label3" runat="server" Text="District :"></asp:Label>
                                                    </td>
                                                    <td class="grdTdValue">
                                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("usrDistrict") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="grdTr">
                                                    <td class="grdTdLabel">
                                                        <asp:Label ID="Label1" runat="server" Text="State :"></asp:Label>
                                                    </td>
                                                    <td class="grdTdValue">
                                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("usrState") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="grdTr">
                                                    <td class="grdTdLabel">
                                                        <asp:Label ID="Label7" runat="server" Text="PIN :"></asp:Label>
                                                    </td>
                                                    <td class="grdTdValue">
                                                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("usrPIN") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                
                                                <tr class="grdTr">
                                                    <td class="grdTdLabel">
                                                        <asp:Label ID="Label11" runat="server" Text="Mobile No :"></asp:Label>
                                                    </td>
                                                    <td class="grdTdValue">
                                                        <asp:Label ID="Label12" runat="server" Text='<%#Eval("usrMobileNo") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="grdTr">
                                                    <td class="grdTdLabel">
                                                        <asp:Label ID="Label29" runat="server" Text="Alt Mobile No :"></asp:Label>
                                                    </td>
                                                    <td class="grdTdValue">
                                                        <asp:Label ID="Label30" runat="server" Text='<%#Eval("usrAltMobileNo") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="grdTr">
                                                    <td class="grdTdLabel">
                                                        <asp:Label ID="Label9" runat="server" Text="Phone Number (R):"></asp:Label>
                                                    </td>
                                                    <td class="grdTdValue">
                                                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("usrPhoneNo") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="grdTr">
                                                    <td class="grdTdLabel">
                                                        <asp:Label ID="Label25" runat="server" Text="Phone Number (O) :"></asp:Label>
                                                    </td>
                                                    <td class="grdTdValue">
                                                        <asp:Label ID="Label26" runat="server" Text='<%#Eval("OfficeNo") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="grdTr">
                                                    <td class="grdTdLabel">
                                                        <asp:Label ID="Label27" runat="server" Text="Fax No :"></asp:Label>
                                                    </td>
                                                    <td class="grdTdValue">
                                                        <asp:Label ID="Label28" runat="server" Text='<%#Eval("FaxNo") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="grdTr">
                                                    <td class="grdTdLabel">
                                                        <asp:Label ID="Label31" runat="server" Text="Email Id :"></asp:Label>
                                                    </td>
                                                    <td class="grdTdValue">
                                                        <asp:Label ID="Label32" runat="server" Text='<%#Eval("usrEmailId") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="grdTr">
                                                    <td class="grdTdLabel">
                                                        <asp:Label ID="Label33" runat="server" Text="Website :"></asp:Label>
                                                    </td>
                                                    <td class="grdTdValue">
                                                        <asp:Label ID="Label34" runat="server" Text='<%#Eval("Website") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </span>
                        <asp:ModalPopupExtender ID="mdlContact" runat="server" TargetControlID="lnkEditContact"
                            PopupControlID="pnlEditContact" BackgroundCssClass="modalBackground" CancelControlID="btnCloseContact"
                            PopupDragHandleControlID="pnlEditContact">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="pnlEditContact" runat="server" Width="700px" Height="100px"  CssClass="ModalWindow">
                            <table border="0" style="border-width: thin; width: 100%; padding:20px; background-color: #E0C9D8;
                                display: block;" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="2" class="lblLogin" style="color: Green;">
                                        Contact Information Update
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="tdLabelInner">
                                        <asp:Label ID="lblErrorContact" runat="server" CssClass="Error" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="Label21" runat="server" Text="Name :"></asp:Label>
                                    </td>
                                    <td class="" align="left">
                                        <asp:TextBox ID="txtFirstName" runat="server" Width="110px" onfocus="ChangeCSS(this, event)"
                                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="fteURFirstName" runat="server" TargetControlID="txtFirstName"
                                            FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ">
                                        </asp:FilteredTextBoxExtender>
                                        <asp:TextBox ID="txtMiddleName" runat="server" Width="80px" onfocus="ChangeCSS(this, event)"
                                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtMiddleName"
                                            FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ">
                                        </asp:FilteredTextBoxExtender>
                                        <asp:TextBox ID="txtLastName" runat="server" Width="110px" onfocus="ChangeCSS(this, event)"
                                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="fteURLastName" runat="server" TargetControlID="txtLastName"
                                            FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="lblAddress" runat="server" Text="Address :"></asp:Label>
                                    </td>
                                    <td class="tdTextInner" align="left">
                                        <asp:TextBox ID="txtAddress" runat="server" Width="240px" TextMode="MultiLine" onfocus="ChangeCSS(this, event)"
                                            Height="30px" onblur="ChangeCSS(this, event)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="Label22" runat="server" Text="Area/Village/Town :"></asp:Label>
                                    </td>
                                    <td class="tdTextInner" align="left">
                                        <asp:TextBox ID="txtUserArea" runat="server" Width="140px" OnTextChanged="txtUserArea_TextChanged"
                                            AutoPostBack="true" onfocus="ChangeCSS(this, event)" onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        <asp:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server" ServicePath="~/Resources/Services/AutoComplete.asmx"
                                            ServiceMethod="GetArea" TargetControlID="txtUserArea" MinimumPrefixLength="1"
                                            CompletionSetCount="12" DelimiterCharacters="" Enabled="True">
                                        </asp:AutoCompleteExtender>
                                    </td>
                                </tr>
                                <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="lblState" runat="server" Text="State :"></asp:Label>
                                    </td>
                                    <td class="tdTextInner" align="left">
                                        <asp:DropDownList ID="cmbState" runat="server" Width="150px" AutoPostBack="true"
                                            OnSelectedIndexChanged="cmbState_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Your State"
                                            ValidationGroup="savegrpcontact" Display="None" ControlToValidate="cmbState"
                                            InitialValue=""></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="lblDistrict" runat="server" Text="District :"></asp:Label>
                                    </td>
                                    <td class="tdTextInner" align="left">
                                        <asp:DropDownList ID="cmbDistrict" runat="server" Width="150px" AutoPostBack="true"
                                            OnSelectedIndexChanged="cmbDistrict_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Your District"
                                            ValidationGroup="savegrpcontact" Display="None" ControlToValidate="cmbDistrict"
                                            InitialValue=""></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="Label23" runat="server" Text="City :"></asp:Label>
                                    </td>
                                    <td class="tdTextInner" align="left">
                                        <asp:DropDownList ID="cmbCity" runat="server" Width="150px">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Your City"
                                            ValidationGroup="savegrpcontact" Display="None" ControlToValidate="cmbCity" InitialValue=""></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="lblPin" runat="server" Text="PIN :"></asp:Label>
                                    </td>
                                    <td class="tdTextInner" align="left">
                                        <asp:TextBox ID="txtPin" runat="server" Width="140px" MaxLength="6" onfocus="ChangeCSS(this, event)"
                                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="ftbPin" runat="server" TargetControlID="txtPin"
                                            FilterType="Numbers">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                                            <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth :"></asp:Label>
                                    </td>
                                    <td class="tdTextInner" align="left">
                                        <asp:TextBox ID="txtDOB" runat="server" Width="140px" MaxLength="10" onfocus="ChangeCSS(this, event)"
                                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        <asp:TextBoxWatermarkExtender ID="txtWtrMrk" runat="server" TargetControlID="txtDOB"
                                            WatermarkText="DD/MM/YYYY" WatermarkCssClass="watermark">
                                        </asp:TextBoxWatermarkExtender>
                                        <asp:FilteredTextBoxExtender ID="ftbDOBExtender" runat="server" TargetControlID="txtDOB"
                                            FilterType="Numbers,Custom" ValidChars="/">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="lblMobileNumber" runat="server" Text="Mobile Number :"></asp:Label>
                                    </td>
                                    <td class="tdTextInner" align="left">
                                     
                                        <asp:Label ID="lblMobilePrefix" runat="server" Text="  +91-" Font-Size="Small"></asp:Label>
                                        <asp:TextBox ID="txtMobileNumber" runat="server" Width="100px" ReadOnly="true" onfocus="ChangeCSS(this, event)"
                                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="ftbMobileNumber" runat="server" TargetControlID="txtMobileNumber"
                                            FilterType="Numbers">
                                        </asp:FilteredTextBoxExtender>
                                        <asp:Label ID="lblShow" runat="server" class="" Text="Show To :" Style="font-size: small;">
                                        </asp:Label>
                                       
                                        <asp:DropDownList ID="ddlControlMobile" runat="server">
                                            <asp:ListItem Value="1">Everyone</asp:ListItem>
                                            <asp:ListItem Value="0">Only Friend</asp:ListItem>
                                        </asp:DropDownList>
                                        
                                    </td>
                                </tr>
                                <tr class="trInnerTable">
                                    <td align="left" class="tdLabelInner">
                                        <asp:Label ID="lblAltMobileNumber" runat="server" Text="Alt. Mobile Number :"></asp:Label>
                                    </td>
                                    <td align="left" class="tdTextInner">
                                        <asp:TextBox ID="txtAltMobileNumber" runat="server" MaxLength="10" Width="140px"
                                            onfocus="ChangeCSS(this, event)" onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="ftbAltMobileNo" runat="server" TargetControlID="txtAltMobileNumber"
                                            FilterType="Numbers">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                
                                <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number (R) :"></asp:Label>
                                    </td>
                                    <td class="tdTextInner" align="left">
                                        <asp:TextBox ID="txtPhoneNumber" runat="server" Width="140px" MaxLength="11" onfocus="ChangeCSS(this, event)"
                                            onblur="ChangeCSS(this, event)"></asp:TextBox>
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
                                <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="Label35" runat="server" Text="Phone Number (O) :"></asp:Label>
                                    </td>
                                    <td class="tdTextInner" align="left">
                                        <asp:TextBox ID="txtPhoneOffice" runat="server" Width="140px" MaxLength="11" onfocus="ChangeCSS(this, event)"
                                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        
                                       
                                    </td>
                                </tr>
                                <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="Label36" runat="server" Text="Fax No :"></asp:Label>
                                    </td>
                                    <td class="tdTextInner" align="left">
                                        <asp:TextBox ID="txtFaxNo" runat="server" Width="140px" MaxLength="11" onfocus="ChangeCSS(this, event)"
                                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        
                                       
                                    </td>
                                </tr>
                                 <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="Label38" runat="server" Text="Email Id :"></asp:Label>
                                    </td>
                                    <td class="tdTextInner" align="left">
                                        <asp:TextBox ID="txtEmailId" runat="server" Width="140px" onfocus="ChangeCSS(this, event)"
                                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        
                                       
                                    </td>
                                </tr>
                                <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="Label37" runat="server" Text="Website :"></asp:Label>
                                    </td>
                                    <td class="tdTextInner" align="left">
                                        <asp:TextBox ID="txtWebsite" runat="server" Width="140px" onfocus="ChangeCSS(this, event)"
                                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        
                                       
                                    </td>
                                </tr>
                                
    
                                <tr>
                                    <td class="lbl">
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Button ID="btnUpdateContact" ValidationGroup="savegrpcontact" Text="Update"
                                            CssClass="button" runat="server" BorderColor="Maroon" OnClientClick="return ClientValidate()"
                                            OnClick="btnUpdateContact_Click" />
                                        &nbsp;
                                        <asp:Button ID="btnCloseContact" Text="Cancel" CssClass="button" runat="server" BorderColor="Maroon" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </asp:Panel>
                        <%--Contact info end here--%>
                        <%--Start of Professional Information--%>
                        <span style="padding-top: 20px;">
                            <div class="searchResultHeader">
                                <table width="100%">
                                    <tr>
                                        <td align="left" width="50%">
                                            <asp:Label ID="lblProfessionalmsg" runat="server" Text="Professional Information"
                                                CssClass="link"></asp:Label>
                                        </td>
                                        <td align="right" width="50%">
                                            <asp:LinkButton ID="lnkEditProfessional" runat="server" CssClass="link">Edit</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <asp:GridView ID="gvProfessionalInfo" AutoGenerateColumns="false" runat="server"
                                ShowHeader="false" Width="100%" 
                            onselectedindexchanged="gvProfessionalInfo_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <table class="grdTable">
                                                <tr class="grdTr">
                                                    <td class="grdTdLabel">
                                                        <asp:Label ID="Label17" runat="server" Text="Highest Qualification :"></asp:Label>
                                                    </td>
                                                    <td class="grdTdValue">
                                                        <asp:Label ID="myUserId" runat="server" Text='<%#Eval("usrHighestQualification") %>'></asp:Label>
                                                    </td>
                                                    <tr class="grdTr">
                                                        <td class="grdTdLabel">
                                                            <asp:Label ID="lblAddress" runat="server" Text="Board / University  :"></asp:Label>
                                                        </td>
                                                        <td class="grdTdValue">
                                                            <asp:Label ID="myAddress" runat="server" Text='<%#Eval("usrBoardUniversity") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr class="grdTr">
                                                        <td class="grdTdLabel">
                                                            <asp:Label ID="Label1" runat="server" Text="Profession :"></asp:Label>
                                                        </td>
                                                        <td class="grdTdValue">
                                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("usrProfession") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr class="grdTr">
                                                        <td class="grdTdLabel">
                                                            <asp:Label ID="Label3" runat="server" Text="Industry/Work Area :"></asp:Label>
                                                        </td>
                                                        <td class="grdTdValue">
                                                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("usrIndustry") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr class="grdTr">
                                                        <td class="grdTdLabel">
                                                            <asp:Label ID="Label7" runat="server" Text="Company Name :"></asp:Label>
                                                        </td>
                                                        <td class="grdTdValue">
                                                            <asp:Label ID="Label8" runat="server" Text='<%#Eval("usrCompanyName") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr class="grdTr">
                                                        <td class="grdTdLabel">
                                                            <asp:Label ID="Label9" runat="server" Text="Carrer Skill :"></asp:Label>
                                                        </td>
                                                        <td class="grdTdValue">
                                                            <asp:Label ID="Label10" runat="server" Text='<%#Eval("usrCarrerSkill") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr class="grdTr">
                                                        <td class="grdTdLabel">
                                                            <asp:Label ID="Label11" runat="server" Text="Carrer Interest:"></asp:Label>
                                                        </td>
                                                        <td class="grdTdValue">
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
                        <asp:Panel ID="pnlEditProfessional" runat="server" Width="500px" CssClass="ModalWindow">
                            <table border="0" style="border-width: thin; width: 100%; background-color: #E0C9D8;
                                display: block;" cellpadding="2" cellspacing="2">
                                <tr>
                                    <td colspan="2" class="lblLogin" style="color: Green;">
                                        Professional Information Update
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="tdLabelInner">
                                        <asp:Label ID="lblErrProfessional" runat="server" CssClass="Error" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="lblHighestQualification" runat="server" Text="Highest Qualification :"></asp:Label>
                                    </td>
                                    <td class="tdTextInner" align="center">
                                        <asp:DropDownList ID="cmbQualification" runat="server" Width="140px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="lblBoardUniversity" runat="server" Text="Board/University : "></asp:Label>
                                    </td>
                                    <td class="tdTextInner" align="center">
                                        <asp:TextBox ID="txtBoardUniversity" runat="server" Width="140px" OnTextChanged="txtBoardUniversity_TextChanged"
                                            AutoPostBack="true" onfocus="ChangeCSS(this, event)" onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="ftbBoardUniversity" runat="server" TargetControlID="txtBoardUniversity"
                                            FilterType="LowercaseLetters,UppercaseLetters,Custom" ValidChars=" .,()&/_">
                                        </asp:FilteredTextBoxExtender>
                                        <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" ServicePath="~/Resources/Services/AutoComplete.asmx"
                                            ServiceMethod="GetBoardUniversity" TargetControlID="txtBoardUniversity" MinimumPrefixLength="1"
                                            CompletionSetCount="12" DelimiterCharacters="" Enabled="True">
                                        </asp:AutoCompleteExtender>
                                    </td>
                                </tr>
                                <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="lblProfession" runat="server" Text="Profession:"></asp:Label>
                                    </td>
                                    <td class="tdTextInner" align="center">
                                        <asp:TextBox ID="txtprofession" runat="server" Width="140px" OnTextChanged="txtprofession_TextChanged"
                                            onfocus="ChangeCSS(this, event)" onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="ftetxtprofession" runat="server" TargetControlID="txtprofession"
                                            FilterType="LowercaseLetters,UppercaseLetters,Custom" ValidChars=" .,()&/_">
                                        </asp:FilteredTextBoxExtender>
                                        <asp:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" ServicePath="~/Resources/Services/AutoComplete.asmx"
                                            ServiceMethod="GetProfession" TargetControlID="txtprofession" MinimumPrefixLength="1"
                                            CompletionSetCount="12" DelimiterCharacters="" Enabled="True">
                                        </asp:AutoCompleteExtender>
                                    </td>
                                </tr>
                                <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="lblIndustry" runat="server" Text="Industry/Work Area:"></asp:Label>
                                    </td>
                                    <td class="tdTextInner" align="center">
                                        <asp:DropDownList ID="cmbIndustry" runat="server" Width="140px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="lblCompanyName" runat="server" Text="Company Name:"></asp:Label>
                                    </td>
                                    <td class="tdTextInner" align="center">
                                        <asp:TextBox ID="txtCompanyName" runat="server" Width="140px" onfocus="ChangeCSS(this, event)"
                                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="fteUserComanyName" runat="server" TargetControlID="txtCompanyName"
                                            FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ,.&()_/">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="lblCarrerSkill" runat="server" Text="Carrer Skill:"></asp:Label>
                                    </td>
                                    <td class="tdTextInner" align="center">
                                        <asp:TextBox ID="txtCarrerSkill" runat="server" Width="140px" onfocus="ChangeCSS(this, event)"
                                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="trInnerTable">
                                    <td class="tdLabelInner" align="left">
                                        <asp:Label ID="lblCarrerInterest" runat="server" Text="Carrer Interest:"></asp:Label>
                                    </td>
                                    <td class="tdTextInner" align="center">
                                        <asp:TextBox ID="txtCarrerInterest" runat="server" Width="140px" onfocus="ChangeCSS(this, event)"
                                            onblur="ChangeCSS(this, event)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl">
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Button ID="btnUpdateProfessional" Text="Update" ValidationGroup="a" CssClass="button"
                                            runat="server" BorderColor="Maroon" OnClientClick="return ClientValidate()" OnClick="btnUpdateProfessional_Click" />
                                        &nbsp;
                                        <asp:Button ID="btnCloseProfessional" Text="Cancel" CssClass="button" runat="server"
                                            BorderColor="Maroon" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <%--End Of Professional Information--%>
                        
                        
                       
                        
                        
                       
                       
                       
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:ModalPopupExtender ID="mdlChangePhoto" runat="server" TargetControlID="lnkChangePhoto"
                    PopupControlID="pnlPhotoUpload" BackgroundCssClass="modalBackground" CancelControlID="btnCancel"
                    PopupDragHandleControlID="pnlPhotoUpload">
                </asp:ModalPopupExtender>
                <asp:Panel ID="pnlPhotoUpload" runat="server" Width="350px" CssClass="ModalWindow">
                    <table border="0" style="border-width: thin; width: 100%; background-color: #E0C9D8;
                        display: block;" cellpadding="2" cellspacing="2">
                        <tr>
                            <td colspan="2" class="lblLogin" style="color: Green;">
                                Change your photo
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left; padding-left: 20px; width: 40%;" class="lbl">
                                Select Photo
                            </td>
                            <td style="text-align: left;">
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
                            <td class="lbl">
                            </td>
                            <td style="text-align: left;">
                                <asp:Button ID="btnChange" Text="Change" CssClass="button" runat="server" BorderColor="Maroon"
                                    OnClientClick="return ClientValidate()" OnClick="btnChange_Click" />
                                &nbsp;
                                <asp:Button ID="btnCancel" Text="Cancel" CssClass="button" runat="server" BorderColor="Maroon" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                        
                        
                      
                       
                       
                      
            </td>
        </tr>
    </table>
</div>
            
</asp:Content>

