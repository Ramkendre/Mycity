<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="FriendRelative.aspx.cs" Inherits="Html_FriendRelative" EnableEventValidation="false"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="main" runat="server">
        <ContentTemplate>
            <div class="MainDiv">
                <div class="InnerDiv">
                    <table class="tblSubFull2">
                        <tr>
                            <td colspan="2" align="left">
                                <center>
                                    <img src="../KResource/Images/defaultImg.png" width="30px" height="20px" alt="" /><span
                                        class="spanTitle"> Add Friend & Relative </span>
                                </center>
                                <hr />
                            </td>
                        </tr>
                        <%--<tr>
                            <td>
                                <img src="../KResource/Images/defaultImg.png" width="30px" height="20px" /><asp:HyperLink
                                    ID="hypaddressbook" runat="server" CssClass="Pagelink" Text="Friends Address Book"
                                    NavigateUrl="~/html/FriendAddressBook.aspx"></asp:HyperLink>
                            </td>
                            <td>
                                <br />
                            </td>
                        </tr>--%>
                        <tr>
                            <td valign="top">
                                Search Friend & Relative<br />
                                (By Registered Mobile No):
                            </td>
                            <td align="left">
                                <asp:Label ID="lblExtnd" runat="server" Text="+91-" Font-Bold="true" Font-Size="Small"></asp:Label>
                                <asp:TextBox ID="txtSearchFriRel" runat="server" MaxLength="10" ToolTip="Enter MobileNo"
                                    CssClass="ccstxt" ValidationGroup="vgpSrchFrRl"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="fbeSearchFriRel" runat="server" TargetControlID="txtSearchFriRel"
                                    FilterType="Numbers">
                                </asp:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="vgpSrchFrRl"
                                    Display="None" ControlToValidate="txtSearchFriRel" ErrorMessage="*Please enter mobile no"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="^[0-9]{10,10}$"
                                    ValidationGroup="vgpSrchFrRl" runat="server" ControlToValidate="txtSearchFriRel"
                                    ErrorMessage="Minimum 10 Digits Required." Display="None">
                                </asp:RegularExpressionValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator5">
                                </asp:ValidatorCalloutExtender>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RegularExpressionValidator1">
                                </asp:ValidatorCalloutExtender>
                                <asp:Button ID="btnSearchFriRel" runat="server" Text="Search" OnClick="btnSearchFriRel_Click"
                                    ValidationGroup="vgpSrchFrRl" AccessKey="S" CssClass="cssbtn" />
                                <br />
                                <br />
                                <asp:GridView ID="gvFriendRelativeSearch" runat="server" AutoGenerateColumns="false"
                                    EmptyDataText="No records matching found" OnRowCommand="gvFriendRelativeSearch_RowCommand"
                                    OnSelectedIndexChanged="gvFriendRelativeSearch_SelectedIndexChanged">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <table class="tblSubFull2">
                                                    <tr>
                                                        <td style="width: 15%;">
                                                            <label>
                                                                Pic</label>
                                                        </td>
                                                        <td style="width: 35%;">
                                                            <label>
                                                                Name</label>
                                                        </td>
                                                        <td style="width: 20%;">
                                                            <label>
                                                                City</label>
                                                        </td>
                                                        <td style="width: 15%;">
                                                            <label>
                                                                Group</label>
                                                        </td>
                                                        <td style="width: 15%;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td style="width: 15%;">
                                                            <%--ImageUrl='<%# "~/ImageHandler.ashx?userId="+ Eval("id") %>'--%>
                                                            <asp:Image ID="frirelSearchProfileImage" runat="server" AlternateText="ProImage"
                                                                BorderColor="#164854" BorderWidth="1px" Height="70px" ImageUrl='<%# "~/ImageHandler.ashx?userId="+ Eval("usrUserId") %>'
                                                                Width="70px" />
                                                        </td>
                                                        <td style="width: 35%;">
                                                            <asp:Label ID="lblSearchFriRelName" runat="server" Text='<%#Eval("usrFullName") %>'></asp:Label>
                                                        </td>
                                                        <td style="width: 20%;">
                                                            <asp:Label ID="lblSearchFriRelCity" runat="server" Text='<%#Eval("usrCity") %>'></asp:Label>
                                                        </td>
                                                        <td style="width: 15%;">
                                                            <asp:DropDownList ID="cmbGroupType" runat="server" DataTextField="GroupName" DataValueField="GroupId">
                                                                <%--CssClass="cssddlwidth"--%>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 20%;">
                                                            <asp:Button ID="btnAddSearchFriRel" runat="server" CommandArgument='<%#Eval("usrUserId")+","+Eval("usrFullName")%>'
                                                                CommandName="AddFriRel" CssClass="cssbtn" Text="Add" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Panel ID="pnlFriend" runat="server">
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr style="width: 100%;">
                            <td>
                                <label style="font-size: large; font-style: normal; font-weight: bold;" class="lbl">
                                    *</label>
                                Add Not Registered Friend & Relative:
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkAddFriRel" runat="server" Text="Add New Friend" 
                                    OnClick="lnkAddFriRel_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <center>
                        <table class="tblSubFull2">
                            <tr>
                                <td colspan="2">
                                    <center>
                                        <span class="spanTitle">Upload Friend List</span>
                                    </center>
                                    <asp:Label ID="lblAddFriendList" runat="server" Font-Bold="True" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <img src="../KResource/Images/GroupsImg.png" width="60px" height="55" />
                                </td>
                                <td align="right">
                                    <asp:Button ID="btnDowmLoad" runat="server" Text="DownLoad Friend List Format for CSV" OnClick="btnDowmLoad_Click"
                                        CssClass="cssbtn" />
                                        <asp:Button ID="btnDownloadExcel" runat="server" Text="Download Friend List Format For Excel" OnClick="btnDownloadExcel_Click" CssClass="cssbtn" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Upload Friend List:
                                </td>
                                <td align="left">
                                    <asp:UpdatePanel ID="upfile" runat="server">
                                        <ContentTemplate>
                                            <asp:FileUpload ID="CSVUpload" runat="server" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnUpload" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="lblResult" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Button ID="btnUpload" runat="server" CssClass="cssbtn" OnClick="btnUpload_Click"
                                        Text="Upload Friends" />
                                         <asp:Label ID="lblStatus" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lblMessage" runat="server" Text="" Visible="false"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <hr />
                        <table class="tblSubFull2">
                            <tr>
                                <td colspan="3">
                                    <center>
                                        <span class="spanTitle">Search Added Friend & Relative</span>
                                        <br />
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <center>
                                        <img src="../KResource/Images/defaultImg.png" width="50px" height="50px" />
                                        <br />
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    First Name:
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextfirstN" runat="server" ToolTip="Enter the First Name" CssClass="ccstxt"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="fteFirstNameDisplay" runat="server" TargetControlID="txtFirstName"
                                        FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Last Name:
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextlastN" runat="server" ToolTip="Enter the Last Name" CssClass="ccstxt"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="fteLastName" runat="server" TargetControlID="txtLastName"
                                        FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Button ID="Button1" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="cssbtn" />
                                </td>
                            </tr>
                        </table>
                    </center>
                    <hr />
                    <table class="tblSubFull2">
                        <tr>
                            <td align="center">
                                <asp:Panel ID="pnlfrndRel" runat="server">
                                    <table>
                                        <tr>
                                            <td>
                                                <center>
                                                    <span class="spanTitle">Friend & Relative </span>
                                                </center>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:DataList ID="dlFriendRelative" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                                                    Width="100%" CellSpacing="2" CellPadding="2" OnItemCommand="dlFriendRelative_ItemCommand">
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/ImageHandler.ashx?id="+ Eval("id") %>'
                                                            Height="80px" Width="80px" />
                                                        <br />
                                                        <asp:LinkButton ID="lnkFriRelName" runat="server" Text='<%#Eval("FullName") %>' CommandArgument='<%#Eval("userid") %>'></asp:LinkButton>
                                                        <asp:LinkButton ID="lnkUserid" runat="server" Visible="false" CommandArgument='<%#Eval("userid") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                    <%-- Pop up for adding new Friends--%>
                    <hr />
                    <asp:ModalPopupExtender ID="mdlAddContact" runat="server" TargetControlID="lnkAddFriRel"
                        PopupControlID="pnlEditContact" BackgroundCssClass="modalBackground" CancelControlID="btnCloseContact"
                        PopupDragHandleControlID="pnlEditContact">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlEditContact" runat="server" class="ModalPop">
                        <div class="csspop">
                            <center>
                                <table>
                                    <tr>
                                        <td colspan="3">
                                            <center>
                                                <span class="spanHeader">Add Friend & Relative </span>
                                            </center>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            First Name :*
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFirstName" runat="server" Width="140px" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="fteFrRlFirstName" runat="server" TargetControlID="txtFirstName"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtFirstName"
                                                ValidationGroup="vgNewFriRelReg" runat="server" ErrorMessage="First Name Required *"
                                                Display="None"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator2">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Last Name :*
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtLastName" runat="server" Width="140px" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="fteFrRlLastName" runat="server" TargetControlID="txtLastName"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtLastName"
                                                ValidationGroup="vgNewFriRelReg" runat="server" ErrorMessage="* Last Name Required"
                                                Display="None"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RequiredFieldValidator3">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Mobile No. :*
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtMobileNumber" runat="server" Width="140px" MaxLength="10" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="fteFrRlMobileNo" runat="server" TargetControlID="txtMobileNumber"
                                                FilterType="Numbers">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td align="left">
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
                                    <tr>
                                        <td>
                                            Relation. :*
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtRelation" runat="server" ValidationGroup="vgNewFriRelReg" Width="140px"
                                                CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="fteFrRlRelation" runat="server" TargetControlID="txtRelation"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars="/-_,.()& ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td align="left">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRelation"
                                                ValidationGroup="vgNewFriRelReg" ErrorMessage="* Relation Required" Display="None"></asp:RequiredFieldValidator>
                                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server" TargetControlID="RequiredFieldValidator4">
                                            </asp:ValidatorCalloutExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Relation Group. :*
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cmbFriendGroup" runat="server" Width="140px" CssClass="cssddlwidth">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblAddress" runat="server" Text="Address :"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtAddress" runat="server" Width="180px" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtAddress"
                                                FilterType="UppercaseLetters,LowercaseLetters,Custom,Numbers" ValidChars="/-_,.()& ">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                        <td align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCityConf" runat="server" Text="City Location:"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:RadioButtonList ID="rdoCityLocation" runat="server" AutoPostBack="true" RepeatColumns="2"
                                                RepeatDirection="Horizontal" Font-Size="Small" OnSelectedIndexChanged="rdoCityLocation_SelectedIndexChanged">
                                                <asp:ListItem Selected="True" Text="Same City" Value="SC"></asp:ListItem>
                                                <asp:ListItem Selected="False" Text="Different City" Value="DC"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            (Same City =
                                            <%=Session["CityNameN"]%>)
                                        </td>
                                        <tr>
                                            <td colspan="3">
                                                <asp:Panel ID="pnlSelectLocation" runat="server">
                                                    <table class="tblSubFull2">
                                                        <tr>
                                                            <td id="subheading" align="center" colspan="2" style="background-color: #E7E7E7;">
                                                                <asp:Label ID="Label3" runat="server" Font-Bold="true" ForeColor="#3D3D3D" Text=":: Select Your City ::"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Select State:
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="cmbState" runat="server" AutoPostBack="true" CssClass="cssddlwidth"
                                                                    OnSelectedIndexChanged="cmbState_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="cmbState"
                                                                    ErrorMessage="***" InitialValue=""></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Select District:
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="cmbDistrict" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbDistrict_SelectedIndexChanged"
                                                                    CssClass="cssddlwidth">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="cmbDistrict"
                                                                    ErrorMessage="***" InitialValue=""></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Select City:
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="cmbCity" runat="server" CssClass="cssddlwidth">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="cmbCity"
                                                                    ErrorMessage="***" InitialValue=""></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3">
                                                <asp:Button ID="btnSubmit" runat="server" CssClass="cssbtn" OnClick="btnSubmit_Click"
                                                    Text="Add Friend &amp; Relative" ValidationGroup="vgNewFriRelReg" />
                                                &nbsp;
                                                <asp:Button ID="btnCloseContact" runat="server" CssClass="cssbtn" Text="Close" />
                                            </td>
                                        </tr>
                                    </tr>
                                </table>
                            </center>
                        </div>
                    </asp:Panel>
                    <%--popup end here--%>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
