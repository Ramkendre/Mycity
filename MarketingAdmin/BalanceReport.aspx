<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="BalanceReport.aspx.cs" Inherits="MarketingAdmin_BalanceReport" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%" border="1">
                <tr>
                    <td align="center">
                        <div>
                            <table class="tblAdminSubFull1">
                                <tr>
                                    <td align="center" colspan="3">
                                        <asp:Label ID="lblHeader" runat="server" Text="Till Todays Balance" Font-Bold="True"
                                            Font-Size="X-Large"></asp:Label>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td>
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging"
                                            EmptyDataText="No Report" CssClass="mGrid" Width="100%" AllowPaging="true" PageSize="5">
                                            <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Id">
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="MobileNo" HeaderText="MobileNo">
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Message" HeaderText="Message">
                                                    <HeaderStyle HorizontalAlign="Center" Width="50%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="50%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SendDate" HeaderText="Date">
                                                    <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="No_smssent" HeaderText="Total no.of sms sent">
                                                    <HeaderStyle HorizontalAlign="Center" Width="50%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="50%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SMSLength" HeaderText="SMS Length">
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SMSCount" HeaderText="SMS Count">
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Pre_SMSbal" HeaderText="Previous Balance">
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField DataField="New_SMSbal" HeaderText="Current Balance">
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td>
                                        <asp:Button ID="btnBack" runat="server" CssClass="button" Text="Back" OnClick="btnBack_Click" />
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
