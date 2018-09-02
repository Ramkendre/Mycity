<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="UserDisplay.aspx.cs" Inherits="Html_UserDisplay" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
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
                                                <img src="../KResource/Images/city-icon.png" width="30px" height="30px" alt="" />
                                                <span class="spanTitle">City Wise Search</span>
                                            </td>
                                        </tr>
                                    </table>
                                </Header>
                                <Content>
                                    <table width="100%">
                                        <tr>
                                            <td valign="top">
                                                <table class="tblSubFull2">
                                                    <tr>
                                                        <td align="center" colspan="2">
                                                            <img src="../KResource/Images/defaultImg.png" height="35px" width="35px" />
                                                            <span class="spanTitle">Search People In City:
                                                                <asp:Label ID="lblCityName" runat="server" Font-Bold="true" ForeColor="Maroon"><%=(Session["CityNameN"])%></asp:Label>
                                                                <br />
                                                                <br />
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            First Name:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtFirstName" runat="server" ToolTip="Enter the First Name" CssClass="ccstxt"></asp:TextBox>
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
                                                            <asp:TextBox ID="txtLastName" runat="server" ToolTip="Enter the Last Name" CssClass="ccstxt"></asp:TextBox>
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
                                                <asp:GridView ID="gvDisplayUserProfile" runat="server" AutoGenerateColumns="false"
                                                    EmptyDataText="No Record Matched" Width="100%" OnRowCommand="gvDisplayUserProfile_RowCommand"
                                                    AllowPaging="true" PageSize="7" OnPageIndexChanging="gvDisplayUserProfile_PageIndexChanging"
                                                    Style="margin-top: 0px" PagerStyle-HorizontalAlign="Center">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <table class="tblSubFull2">
                                                                    <tr>
                                                                        <td width="15%" align="left">
                                                                            <asp:Image ID="myIniProfileImage" runat="server" AlternateText="ProImage" ImageUrl='<%# "~/ImageHandler.ashx?userId="+ Eval("usrUserId") %>'
                                                                                Height="70px" Width="70px" BorderColor="#164854" BorderWidth="1px" />
                                                                        </td>
                                                                        <td width="40%" align="left">
                                                                            <asp:LinkButton ID="lnkName" CssClass="link" Font-Bold="true" ForeColor="Black" runat="server"
                                                                                Text='<%#Eval("usrFullName") %>' CommandName="GetAddress" CommandArgument='<%#Eval("usrUserId")%>'></asp:LinkButton>
                                                                        </td>
                                                                        <td width="25%" align="left">
                                                                            <asp:Label ID="myLocatin" runat="server" Text='<%#Eval("usrArea") %>'></asp:Label>
                                                                        </td>
                                                                        <td width="20%" align="right">
                                                                            <asp:LinkButton ID="lnkViewAddress" runat="server" CssClass="link" Font-Bold="true"
                                                                                Text="Address" CommandArgument='<%#Eval("usrUserId")%>' CommandName="GetAddress">View Address</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle Font-Bold="true" ForeColor="Green" Font-Size="10" />
                                                </asp:GridView>
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
                                                <img src="../KResource/Images/MobileImg.png" width="30px" height="30px" alt="" /><span
                                                    class="spanTitle">Search By Mobile Number</span>
                                            </td>
                                        </tr>
                                    </table>
                                </Header>
                                <Content>
                                    <table class="tblSubFull2">
                                        <tr>
                                            <td align="center" colspan="2">
                                                <img src="../KResource/Images/defaultImg.png" height="35px" width="35px" alt="" />
                                                <span class="spanTitle">Search People By Mobile Number
                                                    <br />
                                                    <br />
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Enter The Mobile No:
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtMobileNumber" runat="server" Width="120px" CssClass="ccstxt"
                                                    ValidationGroup="vgNewReg" MaxLength="10"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="ftbFirstMobileNo" runat="server" TargetControlID="txtMobileNumber"
                                                    FilterType="Numbers">
                                                </asp:FilteredTextBoxExtender>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMobileNumber"
                                                    ValidationGroup="vgNewReg" ErrorMessage="* Mobile No Required" Display="None"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ValidationExpression="^[0-9]{10,}$"
                                                    ValidationGroup="vgNewReg" runat="server" ControlToValidate="txtMobileNumber"
                                                    ErrorMessage="Minimum 10 Numbers Required." Display="None">
                                                </asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btnSearchMbl" runat="server" Text="Search" CssClass="cssbtn" OnClick="btnSearchMbl_Click"
                                                    ValidationGroup="vgNewReg" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="gvMobileNo" runat="server" AutoGenerateColumns="false" EmptyDataText="No Record Matched"
                                                    Width="100%" OnRowCommand="gvDisplayUserProfile_RowCommand" AllowPaging="true"
                                                    PageSize="7" OnPageIndexChanging="gvDisplayUserProfile_PageIndexChanging" Style="margin-top: 0px"
                                                    PagerStyle-HorizontalAlign="Center">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <table class="tblSubFull2">
                                                                    <tr>
                                                                        <td width="15%" align="left">
                                                                            <asp:Image ID="myIniProfileImage" runat="server" AlternateText="ProImage" ImageUrl='<%# "~/ImageHandler.ashx?userId="+ Eval("usrUserId") %>'
                                                                                Height="70px" Width="70px" BorderColor="#164854" BorderWidth="1px" />
                                                                        </td>
                                                                        <td width="40%" align="left">
                                                                            <asp:LinkButton ID="lnkName" CssClass="link" Font-Bold="true" ForeColor="Black" runat="server"
                                                                                Text='<%#Eval("FullName") %>' CommandName="GetAddress" CommandArgument='<%#Eval("FullName")%>'></asp:LinkButton>
                                                                        </td>
                                                                        <td width="20%" align="right">
                                                                            <asp:LinkButton ID="lnkViewAddress" runat="server" CssClass="link" Font-Bold="true"
                                                                                Text="Address" CommandArgument='<%#Eval("usrUserId")%>' CommandName="GetAddress">View Address</asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle Font-Bold="true" ForeColor="Green" Font-Size="10" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </Content>
                            </asp:AccordionPane>
                        </Panes>
                    </asp:Accordion>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
