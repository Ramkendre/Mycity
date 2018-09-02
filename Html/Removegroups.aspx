<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="Removegroups.aspx.cs" Inherits="html_Removegroups" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updatepanel" runat="server">
        <ContentTemplate>
            <div class="MainDiv">
                <div class="InnerDiv">
                    <table class="tblSubFull2">
                        <tr>
                            <td colspan="2">
                                <center>
                                    <br />
                                    <img src="../KResource/Images/GroupsImg.png" width="30px" height="30px" alt="" />
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
                                <asp:DropDownList ID="ddlMyFriendGroup" runat="server" CssClass="cssddlwidth">
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
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
