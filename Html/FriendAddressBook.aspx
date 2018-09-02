<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="FriendAddressBook.aspx.cs" Inherits="html_FriendAddressBook" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="MainDiv">
                <div class="InnerDiv">
                    <table class="tblSubFull2">
                        <tr>
                            <td>
                                <center>
                                    <img src="../KResource/Images/defaultImg.png" width="30px" height="20px" alt="" /><span
                                        class="spanTitle">Friends Address Book </span>
                                </center>
                                <hr />
                                <table class="tblSubFull2">
                                    <tr>
                                        <td align="right">
                                            First Name:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtGroupSMSFirst" runat="server" ToolTip="Enter the First Name"
                                                CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtGroupSMSFirst"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars=" " Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Last Name:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtGroupSMSLast" runat="server" ToolTip="Enter the Last Name" CssClass="ccstxt"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtGroupSMSLast"
                                                FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars=" " Enabled="True">
                                            </asp:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Select Group:
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlMyFriendGroup" runat="server" Width="140px" CssClass="cssddlwidth">
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="left">
                                            <br />
                                            <asp:Button ID="btnViewFriendInGroup" runat="server" Text="View Friends" CssClass="cssbtn"
                                                OnClick="btnViewFriendInGroup_Click" />
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                                <%--usrMobileNo,usrFirstName,usrLastName,usrAddress,usrDistrict,usrCity,usrPIN--%><%--AllowPaging="True"  OnPageIndexChanging="gvAddressBook_PageIndexChanging" OnSelectedIndexChanged="gvAddressBook_SelectedIndexChanged"--%>
                                <asp:GridView ID="gvAddressBook" runat="server" AutoGenerateColumns="False" DataKeyNames="usrMobileNo"
                                    Font-Size="Large" CssClass="gridview">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemStyle Width="10px" />
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" Text="Select<br>All"
                                                    OnCheckedChanged="AddresschkAll_CheckedChanged" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" /></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField ItemStyle-Width="5px" DataField="usrFullName" HeaderText="Name">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="5px" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="5px" DataField="usrMobileNo" HeaderText="Mobile Number">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="5px" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="5px" DataField="usrAddress" HeaderText="Address">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="5px" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="5px" DataField="usrPIN" HeaderText="Pincode">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="5px" />
                                        </asp:BoundField>
                                        <%--<asp:BoundField ItemStyle-Width="5px" DataField="usrDistrict" HeaderText="District">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="5px" />
                                </asp:BoundField>--%>
                                    </Columns>
                                </asp:GridView>
                                <br />
                                <asp:Button ID="btntest" runat="server" Text="Show selected" OnClick="btntest_Click"
                                    Visible="False" CssClass="cssbtn" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
