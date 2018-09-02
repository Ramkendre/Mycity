<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master"
    AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="MarketingAdmin_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%" border="1">
                <tr>
                    <td align="center">
                        <div style="width: 70%">
                            <table cellpadding="0" cellspacing="0" border="0" class="tables" style="width: 98%;
                                height: 332px">
                                <%--<tr>
                                    <td style="height: 20px;">
                                        <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td style="height: 20px;">
                                        <table style="width: 85%; height: 75px;" class="tblAdminSubFull1" cellspacing="0px">
                                            <tr>
                                                <td align="center" style="height: 22px" colspan="2">
                                                    <asp:Label ID="lblHeader" runat="server" Text="Report" Font-Bold="True"
                                                        Font-Size="X-Large"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    &nbsp;&nbsp;<asp:Label ID="lblError" runat="server" CssClass="error" Text="Label"
                                                        Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 22px">
                                                    <asp:Panel ID="pnlUser" runat="server">
                                                        <table class="tblAdminSubFull1" align="center">
                                                            <tr>
                                                                <td style="width: 130px">
                                                                    <label class="">
                                                                        MarketingPerson
                                                                    </label>
                                                                </td>
                                                                <td style="height: 22px">
                                                                    <asp:DropDownList ID="ddlMarketingPerson" runat="server" Width="140px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnViewAllEntry" runat="server" CssClass="button" OnClick="btnViewAllEntry_Click"
                                                                        Text="View" />
                                                                    &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="button" Text="Back" OnClick="btnBack_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                                <tr align="center">
                                                    <td style="height: 22px" colspan="2">
                                                        <asp:Label ID="lblttlrecord" runat="server" Text="Total No of Records :" Visible="false"></asp:Label>
                                                        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr align="center">
                                                    <td>
                                                        <div class="grid" style="width: 70%">
                                                            <div class="rounded">
                                                                <div class="top-outer">
                                                                    <div class="top-inner">
                                                                        <div class="top">
                                                                            &nbsp;
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="mid-outer">
                                                                    <div class="mid-inner">
                                                                        <div class="mid">
                                                                            <div class="pager">
                                                                                <asp:GridView ID="gvAddressBook" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                                    AllowPaging="True" PageSize="15" OnPageIndexChanging="gvAddressBook_PageIndexChanging"
                                                                                    EmptyDataText="No Records Found" CssClass="mGrid" CellSpacing="2">
                                                                                    <Columns>
                                                                                      
                                                                                        <asp:BoundField DataField="Name" HeaderText="Name">
                                                                                            <HeaderStyle HorizontalAlign="Center" Width="70%"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Center" Width="70%"></ItemStyle>
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="MobileNo" HeaderText="Mobile No">
                                                                                            <HeaderStyle HorizontalAlign="Left" Width="20%"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                                                                        </asp:BoundField>
                                                                                          <asp:BoundField DataField="RecordDate" HeaderText="Record Date">
                                                                                            <HeaderStyle HorizontalAlign="Left" Width="10%"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                                                        </asp:BoundField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="bottom-outer">
                                                                    <div class="bottom-inner">
                                                                        <div class="bottom">
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
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
