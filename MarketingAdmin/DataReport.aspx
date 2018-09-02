<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="DataReport.aspx.cs" Inherits="MarketingAdmin_DataReport" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" align="left">
        <tr>
            <td>
                <div class="grid">
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
                                        <asp:GridView ID="gvdisplay" runat="server" Width="100%" CssClass="datatable" 
                                            CellPadding="5" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="Result is not available."
                                            PageSize="5">
                                            <Columns>
                                                <asp:BoundField DataField="P3" HeaderText="P3">
                                                    <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="P5" HeaderText="P5">
                                                    <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="P7" HeaderText="P7">
                                                    <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                </asp:BoundField>
                                               <%-- <asp:BoundField DataField="P9" HeaderText="P9">
                                                    <HeaderStyle HorizontalAlign="left" Width="20%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                </asp:BoundField>--%>
                                                <asp:BoundField DataField="send_date" HeaderText="Date">
                                                    <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                </asp:BoundField>
                                            </Columns>
                                            <RowStyle CssClass="row" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <PagerStyle CssClass="pager-row" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
