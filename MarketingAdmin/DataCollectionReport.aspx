<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="DataCollectionReport.aspx.cs" Inherits="MarketingAdmin_DataCollectionReport"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <table style="width: 97%; height: 290px;" class="tblAdminSubFull1" cellspacing="0px">
                <tr>
                    <td align="center" colspan="4" style="height: 44px">
                        <asp:Label ID="lblHeader" runat="server" Text="Whole Data Report" Font-Bold="True"
                            Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center" style="height: 44px">
                        <asp:GridView ID="gvdisplay" runat="server" Width="100%" CssClass="mGrid" CellPadding="5"
                            AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="Result is not available."
                            PageSize="5">
                            <Columns>
                                <asp:BoundField DataField="fullname" HeaderText="Name">
                                    <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="P5" HeaderText="Tanker">
                                    <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="P7" HeaderText="Trip">
                                    <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="P9" HeaderText="Small">
                                    <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="P11" HeaderText="Big">
                                    <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="P11" HeaderText="mregs">
                                    <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="send_date" HeaderText="Date">
                                    <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:BoundField>
                                
                            </Columns>
                            <RowStyle CssClass="row" HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <PagerStyle CssClass="pager-row" />
                        </asp:GridView>
                        <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="mGrid" CellPadding="5"
                            AutoGenerateColumns="False">
                             <Columns>
                                <asp:BoundField DataField="" HeaderText="">
                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="p5" HeaderText="Total">
                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                </asp:BoundField>
                               <asp:BoundField DataField="p7" HeaderText="Total">
                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="p9" HeaderText="Total">
                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="p11" HeaderText="Total">
                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="p13" HeaderText="Total">
                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="" HeaderText="">
                                    <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                </asp:BoundField>
                                
                            </Columns>
                        </asp:GridView>
                      
                        <tr>
                            <td align="center" colspan="2" style="height: 44px">
                                <asp:Button ID="btnBack" runat="server" CssClass="button" Text="Back" />
                                &nbsp;
                                <asp:Button ID="btnSendmail" runat="server" Text="Send Mail" CssClass="button" 
                                    onclick="btnSendmail_Click" />
                            </td>
                        </tr>
                </tr>
            </table>
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
