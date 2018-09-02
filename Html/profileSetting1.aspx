<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="profileSetting1.aspx.cs" Inherits="html_pro_1" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">

        function confirmDelete() {
            var agree = confirm("Do you really want to Delete?");
            if (agree)
                return true;
            else
                return false;
        }

    </script>

    <script language="javascript" type="text/javascript">
        function validateChangeMobile() {
            if (document.getElementById('<%=txtNewMobileNo.ClientID%>').value != document.getElementById('<%=txtNewMobileNoN.ClientID %>').value) {
                alert("Mobile No Is Not Matching");
                return false;
            }
            else {
                var agr = confirm("Do You Really Want To Change Your Mobile No ? Paaword will be send to New Number.");
                if (agr)
                    return true;
                else
                    return false;
            }
            if (document.getElementById('<%=txtNewMobileNo.ClientID%>').value == "") {
                alert("Provide the New Mobile No");
                return false;
            }
            else if (document.getElementById('<%=txtNewMobileNo.ClientID%>').value.length < 10) {
                alert("New Mobile No Should be 10 Numbers");
                return false;
            }
            else {
                this.disabled = true;
                this.value = 'Changing Mobile...';
                __doPostBack('btnChangePassword', '');
            }
        }
    </script>

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

   
    <asp:UpdatePanel ID="updtPnlSendSMS" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="MainDiv">
                <div class="InnerDiv">
                    <div>
                        <div>
                            <center>
                                <span class="spanTitle">Profile Setting </span>
                                <br />
                                <br />
                            </center>
                        </div>
                        <div>
                            <table class="tblSubFull2">
                                <tr>
                                    <td valign="top">
                                        <asp:Accordion ID="acdLogin" runat="server" TransitionDuration="250" FramesPerSecond="40"
                                            RequireOpenedPane="false" SelectedIndex="0" defaultfocus="pnlExistUser" FadeTransitions="true"
                                            HeaderCssClass="acc-header" ContentCssClass="acc-content" HeaderSelectedCssClass="acc-selected">
                                            <Panes>
                                                <asp:AccordionPane ID="pnlExistUser" runat="server">
                                                    <Header>
                                                        <table class="innerTable">
                                                            <tr>
                                                                <td align="left">
                                                                    <img src="../KResource/Images/LoginImg.png" width="30px" height="30px" alt="" /><span
                                                                        class="spanTitle">  Change Password</span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </Header>
                                                    <Content>
                                                        <table class="tblSubFull2">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <center>
                                                                        <br />
                                                                        <span class="spanTitle">Change Password</span>
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
                                                    </Content>
                                                </asp:AccordionPane>
                                                <asp:AccordionPane ID="AccordionPane1" runat="server">
                                                    <Header>
                                                        <table class="innerTable">
                                                            <tr>
                                                                <td align="left">
                                                                    <img src="../KResource/Images/MobileImg.png" width="30px" height="30px" alt="" /><span
                                                                        class="spanTitle">  Change Number</span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </Header>
                                                    <Content>
                                                        <table class="tblSubFull2">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <center>
                                                                        <br />
                                                                        <span class="spanTitle">Change Mobile No</span>
                                                                        <br />
                                                                        <br />
                                                                    </center>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    Registered Mobile No:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblRegisteredMobileNo" ForeColor="red" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <label for="txtNewMobileNo">
                                                                        Enter the New Mobile No.:</label>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtNewMobileNoN" runat="server" ValidationGroup="vgpChangeMobileNo"
                                                                        CssClass="ccstxt" MaxLength="10"></asp:TextBox>
                                                                    <asp:FilteredTextBoxExtender ID="ftbMobileNoExtenderN" runat="server" TargetControlID="txtNewMobileNoN"
                                                                        FilterType="Numbers" Enabled="True">
                                                                    </asp:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    Re-Enter the New Mobile No.:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtNewMobileNo" runat="server" ValidationGroup="vgpChangeMobileNo"
                                                                        CssClass="ccstxt" MaxLength="10"></asp:TextBox>
                                                                    <asp:FilteredTextBoxExtender ID="ftbMobileNoExtender" runat="server" TargetControlID="txtNewMobileNo"
                                                                        FilterType="Numbers" Enabled="True">
                                                                    </asp:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Button ID="btnNewMobileNoRegister" runat="server" Text="Submit" ValidationGroup="vgpChangeMobileNo"
                                                                        OnClientClick="return validateChangeMobile(); " OnClick="btnNewMobileNoRegister_Click"
                                                                        CssClass="cssbtn" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </Content>
                                                </asp:AccordionPane>
                                                <asp:AccordionPane ID="AccordionPane2" runat="server">
                                                    <Header>
                                                        <table class="innerTable">
                                                            <tr>
                                                                <td align="left">
                                                                    <img src="../KResource/Images/GroupsImg.png" width="30px" height="30px" alt="" /><span
                                                                        class="spanTitle">  Define Group</span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </Header>
                                                    <Content>
                                                        <table class="tblSubFull2">
                                                            <tr>
                                                                <td>
                                                                    <center>
                                                                        <br />
                                                                        <span class="spanTitle">Define Group</span>
                                                                        <br />
                                                                    </center>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tdLabelInner" align="center">
                                                                    <%-- <asp:GridView ID="gvgroup" runat="server" AutoGenerateColumns="False" Font-Names="Arial"
                                                    Font-Size="11pt" OnRowCommand="gvgroup_RowCommand" Width="40%">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Group
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblGroupId" runat="server" Text='<%#Eval("Groupid") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Group Name</HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtGroupName" MaxLength="20" runat="server" Text='<%#Eval("GroupName") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle Width="40%" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>--%>
                                                                    <asp:GridView ID="gvgroup" runat="server" AutoGenerateColumns="False" OnRowCommand="gvgroup_RowCommand"
                                                                        BackColor="White">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Group">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblGroupId" runat="server" Text='<%#Eval("Groupid") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Group Name">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtGroupName" MaxLength="20" CssClass="ccstxt" runat="server" Text='<%#Eval("GroupName") %>'></asp:TextBox>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                    <asp:Button ID="btn_save" runat="server" Text="Update" OnClick="btn_save_Click" CssClass="cssbtn" />
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </Content>
                                                </asp:AccordionPane>
                                                <asp:AccordionPane ID="AccordionPane3" runat="server">
                                                    <Header>
                                                        <table class="innerTable">
                                                            <tr>
                                                                <td align="left">
                                                                    <img src="../KResource/Images/GroupsImg.png" width="30px" height="30px" alt="" /><span
                                                                        class="spanTitle">  Friend Setting</span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </Header>
                                                    <Content>
                                                        <div>
                                                            <table class="tblSubFull2">
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <center>
                                                                            <br />
                                                                            <span class="spanTitle">Update Friends Group</span>
                                                                            <br />
                                                                            <br />
                                                                        </center>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        First Name:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtFName" runat="server" CssClass="ccstxt"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        Last Name:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtLName" runat="server" CssClass="ccstxt"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        Mobile Number:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="ccstxt"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Button ID="btnSearchRel" runat="server" OnClick="btnSearchRel_Click" Text="Search"
                                                                            CssClass="cssbtn" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <div>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:GridView ID="gvRemoveFriend" runat="server" AutoGenerateColumns="False" EmptyDataText="No Friends Added In your Profile"
                                                                            Width="100%" AllowPaging="True" AllowSorting="True" OnRowCommand="gvRemoveFriend_RowCommand"
                                                                            CssClass="gridview" OnPageIndexChanging="gvRemoveFriend_PageIndexChanging" OnRowDataBound="gvRemoveFriend_RowDataBound">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="FriRelId" Visible="False">
                                                                                    <HeaderStyle HorizontalAlign="Left" Width="30%" />
                                                                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="name" HeaderText="Name">
                                                                                    <HeaderStyle HorizontalAlign="Left" Width="30%" />
                                                                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Relation" HeaderText="Relation">
                                                                                    <HeaderStyle HorizontalAlign="Left" Width="30%" />
                                                                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                                                </asp:BoundField>
                                                                                <asp:TemplateField HeaderText="Modify">
                                                                                    <ItemTemplate>
                                                                                        <%-- <asp:Button ID="btnEditFriend" runat="server" Text="Modify" CssClass="button" CommandArgument='<%#Eval("FriRelId") %>'
                                                        CommandName="Edit" />--%>
                                                                                        <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Eval("FriRelId") %>' runat="server"
                                                                                            ImageUrl="../resources1/images/ico_yes1.gif" CommandName="Edit"></asp:ImageButton>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Delete">
                                                                                    <ItemTemplate>
                                                                                        <%-- <asp:Button ID="btnDeleteFriend" runat="server" Text="Remove" CssClass="button" CommandArgument='<%#Eval("FriRelId") %>'
                                                        CommandName="Remove" OnClientClick="return confirmDelete()" />--%>
                                                                                        <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Eval("FriRelId") %>' runat="server"
                                                                                            ImageUrl="../resources1/images/close.gif" CommandName="Remove" OnClientClick="return confirmDelete()">
                                                                                        </asp:ImageButton>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                            <PagerStyle CssClass="pgr" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </Content>
                                                </asp:AccordionPane>
                                                <asp:AccordionPane ID="AccordionPane4" runat="server">
                                                    <Header>
                                                        <table class="innerTable">
                                                            <tr>
                                                                <td align="left">
                                                                    <img src="../KResource/Images/GroupsImg.png" width="30px" height="30px" alt="" /><span
                                                                        class="spanTitle">  Members</span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </Header>
                                                    <Content>
                                                        <div>
                                                            <table class="tblSubFull2">
                                                                <tr>
                                                                    <td colspan="3">
                                                                        <center>
                                                                            <br />
                                                                            <span class="spanTitle">Members</span>
                                                                            <br />
                                                                            <br />
                                                                        </center>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        Group Id
                                                                    </td>
                                                                    <td align="center">
                                                                        Group Name
                                                                    </td>
                                                                    <td align="left">
                                                                        Count
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        1
                                                                    </td>
                                                                    <td align="center">
                                                                        All
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblall" runat="server" Text='<%#Eval("FR1") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        2
                                                                    </td>
                                                                    <td align="center">
                                                                        FR2
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR2" runat="server" Text='<%#Eval("FR2") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        3
                                                                    </td>
                                                                    <td align="center">
                                                                        FR3
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR3" runat="server" Text='<%#Eval("FR3") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        4
                                                                    </td>
                                                                    <td align="center">
                                                                        FR4
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR4" runat="server" Text='<%#Eval("FR4") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        5
                                                                    </td>
                                                                    <td align="center">
                                                                        FR5
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR5" runat="server" Text='<%#Eval("FR5") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        6
                                                                    </td>
                                                                    <td align="center">
                                                                        FR6
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR6" runat="server" Text='<%#Eval("FR6") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        7
                                                                    </td>
                                                                    <td align="center">
                                                                        FR7
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR7" runat="server" Text='<%#Eval("FR7") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        8
                                                                    </td>
                                                                    <td align="center">
                                                                        FR8
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR8" runat="server" Text='<%#Eval("FR8") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        9
                                                                    </td>
                                                                    <td align="center">
                                                                        FR9
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR9" runat="server" Text='<%#Eval("FR9") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        10
                                                                    </td>
                                                                    <td align="center">
                                                                        FR10
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR10" runat="server" Text='<%#Eval("FR10") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        11
                                                                    </td>
                                                                    <td align="center">
                                                                        FR11
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR11" runat="server" Text='<%#Eval("FR11") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        12
                                                                    </td>
                                                                    <td align="center">
                                                                        FR12
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR12" runat="server" Text='<%#Eval("FR12") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        13
                                                                    </td>
                                                                    <td align="center">
                                                                        FR13
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR13" runat="server" Text='<%#Eval("FR13") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        14
                                                                    </td>
                                                                    <td align="center">
                                                                        FR14
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR14" runat="server" Text='<%#Eval("FR14") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        15
                                                                    </td>
                                                                    <td align="center">
                                                                        FR15
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR15" runat="server" Text='<%#Eval("FR15") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        16
                                                                    </td>
                                                                    <td align="center">
                                                                        FR16
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR16" runat="server" Text='<%#Eval("FR16") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        17
                                                                    </td>
                                                                    <td align="center">
                                                                        FR17
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR17" runat="server" Text='<%#Eval("FR17") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        18
                                                                    </td>
                                                                    <td align="center">
                                                                        FR18
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR18" runat="server" Text='<%#Eval("FR18") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        19
                                                                    </td>
                                                                    <td align="center">
                                                                        FR19
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR19" runat="server" Text='<%#Eval("FR19") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        20
                                                                    </td>
                                                                    <td align="center">
                                                                        FR20
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR20" runat="server" Text='<%#Eval("FR20") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        21
                                                                    </td>
                                                                    <td align="center">
                                                                        FR21
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR21" runat="server" Text='<%#Eval("FR21") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        22
                                                                    </td>
                                                                    <td align="center">
                                                                        FR22
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR22" runat="server" Text='<%#Eval("FR22") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        23
                                                                    </td>
                                                                    <td align="center">
                                                                        FR23
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR23" runat="server" Text='<%#Eval("FR23") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        24
                                                                    </td>
                                                                    <td align="center">
                                                                        FR24
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR24" runat="server" Text='<%#Eval("FR24") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        25
                                                                    </td>
                                                                    <td align="center">
                                                                        FR25
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR25" runat="server" Text='<%#Eval("FR25") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        26
                                                                    </td>
                                                                    <td align="center">
                                                                        FR26
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR26" runat="server" Text='<%#Eval("FR26") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        27
                                                                    </td>
                                                                    <td align="center">
                                                                        FR27
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR27" runat="server" Text='<%#Eval("FR27") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        28
                                                                    </td>
                                                                    <td align="center">
                                                                        FR28
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR28" runat="server" Text='<%#Eval("FR28") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        29
                                                                    </td>
                                                                    <td align="center">
                                                                        FR29
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR29" runat="server" Text='<%#Eval("FR29") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        30
                                                                    </td>
                                                                    <td align="center">
                                                                        FR30
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFR30" runat="server" Text='<%#Eval("FR30") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </Content>
                                                </asp:AccordionPane>
                                                <asp:AccordionPane ID="AccordionPane5" runat="server">
                                                    <Header>
                                                        <table class="innerTable">
                                                            <tr>
                                                                <td align="left">
                                                                    <img src="../KResource/Images/GroupsImg.png" width="30px" height="30px" alt="" /><span
                                                                        class="spanTitle">  Remove Groups</span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </Header>
                                                    <Content>
                                                        <table class="tblSubFull2">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <center>
                                                                        <br />
                                                                        <span class="spanTitle">Remove Group</span>
                                                                        <br />
                                                                        <br />
                                                                    </center>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" width="50%">
                                                                    Select Group:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlMyFriendGroup" runat="server" AutoPostBack="True" CssClass="cssddlwidth">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                        <asp:ListItem Value="1">FR1</asp:ListItem>
                                                                        <asp:ListItem Value="2">FR2</asp:ListItem>
                                                                        <asp:ListItem Value="3">FR3</asp:ListItem>
                                                                        <asp:ListItem Value="4">FR4</asp:ListItem>
                                                                        <asp:ListItem Value="5">FR5</asp:ListItem>
                                                                        <asp:ListItem Value="6">FR6</asp:ListItem>
                                                                        <asp:ListItem Value="7">FR7</asp:ListItem>
                                                                        <asp:ListItem Value="8">FR8</asp:ListItem>
                                                                        <asp:ListItem Value="9">FR9</asp:ListItem>
                                                                        <asp:ListItem Value="10">FR10</asp:ListItem>
                                                                        <asp:ListItem Value="11">FR11</asp:ListItem>
                                                                        <asp:ListItem Value="12">FR12</asp:ListItem>
                                                                        <asp:ListItem Value="13">FR13</asp:ListItem>
                                                                        <asp:ListItem Value="14">FR14</asp:ListItem>
                                                                        <asp:ListItem Value="15">FR15</asp:ListItem>
                                                                        <asp:ListItem Value="16">FR16</asp:ListItem>
                                                                        <asp:ListItem Value="17">FR17</asp:ListItem>
                                                                        <asp:ListItem Value="18">FR18</asp:ListItem>
                                                                        <asp:ListItem Value="19">FR19</asp:ListItem>
                                                                        <asp:ListItem Value="20">FR20</asp:ListItem>
                                                                        <asp:ListItem Value="21">FR21</asp:ListItem>
                                                                        <asp:ListItem Value="22">FR22</asp:ListItem>
                                                                        <asp:ListItem Value="23">FR23</asp:ListItem>
                                                                        <asp:ListItem Value="24">FR24</asp:ListItem>
                                                                        <asp:ListItem Value="25">FR25</asp:ListItem>
                                                                        <asp:ListItem Value="26">FR26</asp:ListItem>
                                                                        <asp:ListItem Value="27">FR27</asp:ListItem>
                                                                        <asp:ListItem Value="28">FR27</asp:ListItem>
                                                                        <asp:ListItem Value="29">FR29</asp:ListItem>
                                                                        <asp:ListItem Value="30">FR30</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:Button ID="btnSearch" runat="server" CssClass="cssbtn" Text="Search" OnClick="btnSearch_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Button ID="btnRemove" runat="server" CssClass="cssbtn" OnClick="btnRemove_Click"
                                                                        Text="Remove" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Remove Groups
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="Label9" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:GridView ID="gvAddressBook" runat="server" AutoGenerateColumns="False" Width="100%"
                                                            DataKeyNames="usrMobileNo" Font-Size="Large" CssClass="gridview">
                                                            <RowStyle BorderWidth="1px" />
                                                            <Columns>
                                                                <asp:BoundField DataField="usrFullName" HeaderText="Name">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle Width="5px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="usrMobileNo" HeaderText="Mobile Number">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle Width="5px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="usrAddress" HeaderText="Address">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle Width="5px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="usrPIN" HeaderText="Pincode">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle Width="5px" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <PagerStyle BorderStyle="None" BorderWidth="1px" />
                                                            <SelectedRowStyle BorderStyle="None" BorderWidth="1px" />
                                                            <EditRowStyle BorderStyle="None" BorderWidth="1px" Width="1px" Wrap="False" />
                                                        </asp:GridView>
                                                    </Content>
                                                </asp:AccordionPane>
                                            </Panes>
                                        </asp:Accordion>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
