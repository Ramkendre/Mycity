<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="PushedAttendance.aspx.cs" Inherits="MarketingAdmin_PushedAttendance"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <center>
            <div style="margin-top: 20px; border: 1px solid #888888; width: 80%; font-family:Calibri;">
                <table style="width: 70%; height: 150px;" cellspacing="0px">
                    <tr>
                        <td align="center" style="height: 44px" colspan="2">
                            <span style="color: Black; font-size: 1em; font-weight: bold">Attendance SMS Report</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Cuurent Time
                        </td>
                        <td align="left">
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Message Text
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtMgs" runat="server" CssClass="txtcss1" TextMode="MultiLine" Width="200px"
                                Height="50px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <br />
                            Message Id
                        </td>
                        <td align="left">
                            <br />
                            <asp:Label ID="lblId" runat="server" Text="" ForeColor="Red" Style="font-weight: 700"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <br />
                            Mobile No
                        </td>
                        <td align="left">
                            <br />
                            <asp:Label ID="lblMobileNo" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <br />
                            Date
                        </td>
                        <td align="left">
                            <br />
                            <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left" style="height: 44px">
                            <asp:Button ID="btnPushMgs" runat="server" Text="Push Message" CssClass="button"
                                OnClick="btnPushMgs_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" Width="108px"
                                OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                </table>
            </div>
            <div style="margin-top: 20px; margin-bottom: 20px; border: 1px solid #888888; width: 80%">
                <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" OnPageIndexChanged="gvLongCodeReport_PageIndexChanged"
                    OnPageIndexChanging="gvLongCodeReport_PageIndexChanging" AllowPaging="true" PageSize="10"
                    CssClass="mGrid" Width="100%" OnRowCommand="gvItem_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="PK" HeaderText="Id">
                            <HeaderStyle HorizontalAlign="left" Width="10%" />
                            <ItemStyle HorizontalAlign="left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="mobile" HeaderText="Mobile Number">
                            <HeaderStyle HorizontalAlign="left" Width="15%" />
                            <ItemStyle HorizontalAlign="left" Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Message" HeaderText="Message">
                            <HeaderStyle HorizontalAlign="left" Width="50%" />
                            <ItemStyle HorizontalAlign="left" Width="50%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="shortcode" HeaderText="Date">
                            <HeaderStyle HorizontalAlign="left" Width="15%" />
                            <ItemStyle HorizontalAlign="left" Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FlagStatus" HeaderText="Status">
                            <HeaderStyle HorizontalAlign="left" Width="20%" />
                            <ItemStyle HorizontalAlign="left" Width="20%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Push Message">
                            <ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("PK") %>' runat="server"
                                    ImageUrl="~/Resources/resources1/images/ico_yes1.gif" CommandName="Push"></asp:ImageButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </center>
    </div>
</asp:Content>
