<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="VidhanMeetingDetails.aspx.cs" Inherits="MarketingAdmin_VidhanMeetingDetails"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%" border="1">
        <tr>
            <td>
                <div>
                    <center>
                        <div style="border: 1px solid #888888;">
                            <div>
                                <table class="tables" width="80%">
                                    <tr>
                                        <td colspan="2">
                                            <h3 style="text-align: center">
                                                Meeting Details
                                            </h3>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            Today Meeting Date:
                                            <asp:Label ID="lblDate" runat="server" Text="No date" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <center>
                                                <div style="margin-bottom: 20px; margin-top: 20px; border: 1px solid #2F4F4F; height: auto;
                                                    width: 502px;">
                                                    <asp:GridView ID="gvToday" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                        BorderColor="#DEDFDE" BorderWidth="1px" DataKeyNames="Id" ForeColor="Black" GridLines="Vertical"
                                                        Width="500px" EmptyDataText="No Data Found" ToolTip="Details of Items">
                                                        <RowStyle BackColor="#F7F7DE" Height="30px" />
                                                        <Columns>
                                                            <asp:BoundField DataField="Id" HeaderText="Id">
                                                                <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Committee_name" HeaderText="Committee Name" HeaderStyle-Width="500px">
                                                                <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                                <ItemStyle HorizontalAlign="Center" Width="300px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="RoomNo" HeaderText="Room No" HeaderStyle-Width="500px">
                                                                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                                <ItemStyle HorizontalAlign="Center" Width="100px" Font-Bold="true" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TimeDetails" HeaderText="Time" HeaderStyle-Width="500px">
                                                                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                                <ItemStyle HorizontalAlign="Center" Width="100px" Font-Bold="true" />
                                                            </asp:BoundField>
                                                            <%--  <asp:BoundField DataField="EntryDate" HeaderText="Date" HeaderStyle-Width="500px">
                                                                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                                <ItemStyle HorizontalAlign="Center" Width="100px" Font-Bold="true" />
                                                            </asp:BoundField>--%>
                                                        </Columns>
                                                        <FooterStyle BackColor="#CCCC99" />
                                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#009999" Font-Bold="True" Font-Size="1.1em" ForeColor="White"
                                                            Height="30px" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </div>
                                            </center>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                    </center>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
