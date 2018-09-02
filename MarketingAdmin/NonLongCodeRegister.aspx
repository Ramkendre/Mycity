<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="NonLongCodeRegister.aspx.cs" Inherits="MarketingAdmin_NonLongCodeRegister"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%" border="1">
                <tr>
                    <td align="center">
                        <table style="width: 97%; height: 67px;" class="tblAdminSubFull1" cellspacing="0px">
                            <tr>
                                <td align="center" style="height: 31px;">
                                    <asp:Label ID="Label1" runat="server" Text="Non RegisteredMisCall Report" Font-Size="X-Large"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="height: 31px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" style="height: 31px;" colspan="3">
                                    <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" 
                                        CssClass="mGrid" Height="161px" EmptyDataText="No records">
                                        <Columns>
                                         <asp:BoundField DataField="Id" HeaderText="Id">
                                                <HeaderStyle HorizontalAlign="left" Width="5%" />
                                                <ItemStyle HorizontalAlign="left" Width="5%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="IMEINO" HeaderText="IMEINO">
                                                <HeaderStyle HorizontalAlign="left" Width="30%" />
                                                <ItemStyle HorizontalAlign="left" Width="30%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SIMNO" HeaderText="SIMNO">
                                                <HeaderStyle HorizontalAlign="left" Width="30%" />
                                                <ItemStyle HorizontalAlign="left" Width="30%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Miscal_Date" HeaderText="Date">
                                                <HeaderStyle HorizontalAlign="left" Width="20%" />
                                                <ItemStyle HorizontalAlign="left" Width="20%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Status" HeaderText="Status">
                                                <HeaderStyle HorizontalAlign="left" Width="15%" />
                                                <ItemStyle HorizontalAlign="left" Width="15%" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="height: 31px;">
                                    <asp:Button ID="btnBack" runat="server" CssClass="button"
                                        Text="Back" onclick="btnBack_Click" />
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
