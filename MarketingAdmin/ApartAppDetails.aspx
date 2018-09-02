<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="ApartAppDetails.aspx.cs" Inherits="MarketingAdmin_ApartAppDetails"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div>
            <div style="border: 1px solid #888888;">
                <center>
                    <table class="tables">
                        <tr>
                            <td colspan="2">
                                <center>
                                    <span style="color: Black; font-size: 1em; font-weight: bold">Andorid Application Member</span>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Select Mobile No
                            </td>
                            <td>
                                <asp:TextBox ID="txtMobileno" runat="server" CssClass="text"></asp:TextBox>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="button" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Panel ID="Panel2" runat="server">
                                    <center>
                                        <table>
                                            <tr>
                                                <td>
                                                    Full Name
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFullName" runat="server" CssClass="text" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    IMEI No
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtIMEINo" runat="server" CssClass="text"> </asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    SIM No
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSIMNo" runat="server" CssClass="text"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Reference Mobile No
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRefMobileNo" runat="server" CssClass="text" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Purpose
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlPurpose" runat="server" CssClass="dropdownlist">
                                                        <asp:ListItem Value="4">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">Personal</asp:ListItem>
                                                        <asp:ListItem Value="1">Community</asp:ListItem>
                                                        <asp:ListItem Value="2">Political</asp:ListItem>
                                                        <asp:ListItem Value="3">Apartment</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Party Name
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPartyName" runat="server" CssClass="text"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    PassCode
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPasscode" runat="server" CssClass="text"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Key Version
                                                </td>
                                                <td>
                                                   <%-- <asp:DropDownList ID="ddlKeyVersion" runat="server" CssClass="dropdownlist">
                                                        <asp:ListItem Value="4">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1">eZeeMemberApp130</asp:ListItem>
                                                    </asp:DropDownList>--%>
                                                     <asp:TextBox ID="txtKeyVersion" runat="server" CssClass="text" Text="eZeeMemberApp130" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:RadioButtonList ID="rdbActive" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                                        <asp:ListItem Value="0">DeActive</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" OnClick="btnSubmit_Click" />
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" 
                                                        onclick="btnCancel_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                <center>
                                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                                        <table width="400px">
                                            <tr>
                                                <td>
                                                    Full Name
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblFullName" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Apps Mobile No
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblAppMobileNo" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Reference Mobile No
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblRefMobileNo" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Purpose
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPurpose" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Party Name
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPartyName" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Register Date
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblRegDate" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Pass Code
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPassCode" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="gvItem" runat="server" CssClass="mGrid" AutoGenerateColumns="false"
                                    OnRowCommand="gvItem_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="100px">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="EzeeApp_Id" HeaderText="EzeeApp_Id" Visible="false"></asp:BoundField>
                                        <asp:BoundField DataField="IMEINo" HeaderText="IMEINo"></asp:BoundField>
                                        <asp:BoundField DataField="SIMNo" HeaderText="SIMNo"></asp:BoundField>
                                        <asp:BoundField DataField="MemberName" HeaderText="MemberName"></asp:BoundField>
                                        <asp:BoundField DataField="AppMobileNo" HeaderText="AppMobileNo"></asp:BoundField>
                                        <asp:BoundField DataField="Purpose" HeaderText="Purpose"></asp:BoundField>
                                        <asp:BoundField DataField="Active" HeaderText="Authority"></asp:BoundField>
                                        <asp:TemplateField HeaderText="Details" ItemStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnDetails" runat="server" ImageUrl="~/Resources/resources1/images/ico_yes1.gif"
                                                    CommandArgument='<%#Bind("EzeeApp_Id") %>' CommandName="Details" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Active" ItemStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnActive" runat="server" ImageUrl="~/Resources/resources1/images/ico_yes1.gif"
                                                    CommandArgument='<%#Bind("EzeeApp_Id") %>' CommandName="Active" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="De-Active" ItemStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnDeactive" runat="server" ImageUrl="~/Resources/resources1/images/close.gif"
                                                    CommandArgument='<%#Bind("EzeeApp_Id") %>' CommandName="DeActive" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </center>
            </div>
        </div>
    </div>
</asp:Content>
