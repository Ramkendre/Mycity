<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master"
    AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="Admin_UserList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%" border="1">
                <tr>
                    <td align="center">
                        <div style="width: 70%">
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
                                                <td align="center" colspan="3" style="height: 44px">
                                                    <asp:Label ID="lblHeader" runat="server" Text="User List" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 44px">
                                                </td>
                                                <td align="center" style="height: 44px">
                                                    <asp:Button ID="btnSubmit" runat="server" CssClass="button" OnClick="btnSubmit_Click"
                                                        Text="Add New User" />
                                                    &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="button" OnClick="btnBack_Click"
                                                        Text="Back" />
                                                    &nbsp;
                                                </td>
                                                <td align="center" style="height: 44px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="height: 44px">
                                                    &nbsp;<asp:Label ID="Label1" runat="server" Text="Active Users:"></asp:Label><asp:Label
                                                        ID="lblActiveCount" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="height: 44px">
                                                    <asp:GridView ID="gvUser" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                        CellPadding="5" CellSpacing="0" CssClass="mGrid" EmptyDataText="User List is not available."
                                                        GridLines="None" PageSize="5" OnPageIndexChanging="gvUser_PageIndexChanging"
                                                        OnRowCommand="gvUser_RowCommand" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="MID" HeaderText="Id">
                                                                <HeaderStyle HorizontalAlign="left" Width="10%" />
                                                                <ItemStyle HorizontalAlign="left" Width="10%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="usrFirstName" HeaderText="User Name">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%" />
                                                                <ItemStyle HorizontalAlign="left" Width="30%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="city" HeaderText="City">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%" />
                                                                <ItemStyle HorizontalAlign="left" Width="30%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="District" HeaderText="District">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%" />
                                                                <ItemStyle HorizontalAlign="left" Width="30%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="RoleName" HeaderText="Role">
                                                                <HeaderStyle HorizontalAlign="left" Width="10%" />
                                                                <ItemStyle HorizontalAlign="left" Width="10%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="usrMobileNo" HeaderText="ContactNo">
                                                                <HeaderStyle HorizontalAlign="left" Width="20%" />
                                                                <ItemStyle HorizontalAlign="left" Width="20%" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Modify">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%#Bind("MID")%>'
                                                                        CommandName="Modify" ImageUrl="../resources1/images/ico_yes1.gif" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <PagerStyle CssClass="pager-row" />
                                                    </asp:GridView>
                                                    <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="height: 44px">
                                                    &nbsp;<asp:Label ID="Label2" runat="server" Text="DeActive Users:"></asp:Label><asp:Label
                                                        ID="lblDeactiveCount" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="center" style="height: 44px">
                                                    <asp:GridView ID="gvDeactive" runat="server" Width="100%" CssClass="mGrid" OnPageIndexChanging="gvUser_PageIndexChanging"
                                                        CellPadding="5" CellSpacing="1" GridLines="None" AutoGenerateColumns="False"
                                                        AllowPaging="True" EmptyDataText="User List is not available." PageSize="5"
                                                        OnRowCommand="gvDeactive_RowCommand" OnRowDataBound="gvDeactive_RowDataBound">
                                                        <Columns>
                                                        <asp:BoundField DataField="MID" HeaderText="Id">
                                                                <HeaderStyle HorizontalAlign="left" Width="10%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="usrFirstName" HeaderText="User Name">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="city" HeaderText="City">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="District" HeaderText="City">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="RoleName" HeaderText="Role">
                                                                <HeaderStyle HorizontalAlign="left" Width="10%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="usrMobileNo" HeaderText="ContactNo">
                                                                <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Modify">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%#Bind("MID")%>'
                                                                        CommandName="Modify" ImageUrl="../resources1/images/ico_yes1.gif" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <PagerStyle CssClass="pager-row" />
                                                    </asp:GridView>
                                                    <asp:Label ID="lblId1" runat="server" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
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
