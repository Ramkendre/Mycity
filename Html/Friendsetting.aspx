<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="Friendsetting.aspx.cs" Inherits="html_Friendsetting" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="MainDiv">
        <div class="InnerDiv">
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
        </div>
    </div>
</asp:Content>
