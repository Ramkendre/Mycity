<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="SubmittedRecord.aspx.cs" Inherits="MarketingAdmin_SubmittedRecord"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" align="left">
        <tr>
            <td>
                <asp:GridView ID="gvdisplay" runat="server" Width="100%" CssClass="mGrid" CellPadding="5"
                    AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="Result is not available."
                    PageSize="5" OnPageIndexChanging="gvdisplay_PageIndexChanging" 
                    onrowcommand="gvdisplay_RowCommand" onrowdatabound="gvdisplay_RowDataBound" 
                    onrowdeleted="gvdisplay_RowDeleted">
                    <Columns>
                        <%-- <asp:BoundField DataField="FullName" HeaderText="Name">
                            <HeaderStyle HorizontalAlign="Left" Width="20%" />
                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                        </asp:BoundField>--%>
                        <asp:BoundField DataField="data_id" HeaderText="Id">
                            <HeaderStyle HorizontalAlign="Left" Width="20%" />
                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="usrMobileNo" HeaderText="Mobile No">
                            <HeaderStyle HorizontalAlign="Left" Width="20%" />
                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="p1" HeaderText="P1">
                            <HeaderStyle HorizontalAlign="Left" Width="10%" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="p2" HeaderText="P2">
                            <HeaderStyle HorizontalAlign="Left" Width="10%" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="p3" HeaderText="P3">
                            <HeaderStyle HorizontalAlign="Left" Width="10%" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="p4" HeaderText="P4">
                            <HeaderStyle HorizontalAlign="Left" Width="10%" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="p5" HeaderText="P5">
                            <HeaderStyle HorizontalAlign="Left" Width="10%" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="p7" HeaderText="P7">
                            <HeaderStyle HorizontalAlign="Left" Width="10%" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="p8" HeaderText="P8">
                            <HeaderStyle HorizontalAlign="Left" Width="10%" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="p9" HeaderText="P9">
                            <HeaderStyle HorizontalAlign="Left" Width="10%" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="p10" HeaderText="P10">
                            <HeaderStyle HorizontalAlign="Left" Width="10%" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="p11" HeaderText="P11">
                            <HeaderStyle HorizontalAlign="Left" Width="10%" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="p12" HeaderText="P12">
                            <HeaderStyle HorizontalAlign="Left" Width="10%" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="send_date" HeaderText="Date">
                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton4" runat="server" CommandArgument='<%#Bind("data_id") %>'
                                    CommandName="Delete" ImageUrl="~/resources1/images/close.gif" /></ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="row" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <PagerStyle CssClass="pager-row" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
