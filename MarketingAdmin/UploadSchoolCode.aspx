<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="UploadSchoolCode.aspx.cs" Inherits="MarketingAdmin_UploadSchoolCode"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="90%" border="1">
                <tr>
                    <td align="center">
                        <div style="width: 80%">
                            <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                                <tr>
                                    <td colspan="2" style="height: 20px;">
                                        <span class="warning1" style="color: Red;"></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                                            <tr>
                                                <td colspan="2">
                                                    <h3 style="text-align: center">
                                                        <asp:Label ID="lblHeader" runat="server" Text="School Master Details"></asp:Label>
                                                    </h3>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    &nbsp;&nbsp;<asp:Label ID="lblError" Visible="False" runat="server" CssClass="error"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="bottom">
                                                    Select File :
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="U2" runat="server">
                                                        <ContentTemplate>
                                                            <asp:FileUpload ID="File_schoolcode" runat="server" Height="21px" Width="252px" />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="btnsave" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="bottom">
                                                    Total School :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSchool" runat="server" Text="" Font-Bold="true" ForeColor="red"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="bottom">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <td>
                                                        &nbsp;<asp:Button ID="btndownload" runat="server" CssClass="btn" Style="text-align: left"
                                                            Text="Download CSV Format" OnClick="btndownload_Click" />
                                                        &nbsp;
                                                        <asp:Button ID="btnsave" runat="server" CssClass="btn" OnClick="btnsave_Click1" Style="text-align: left"
                                                            Text="Submit" />
                                                        &nbsp;
                                                        <asp:Button ID="btnback" runat="server" CssClass="btn" Style="text-align: left" Text="Back"
                                                            PostBackUrl="~/MarketingAdmin/MenuMaster1.aspx?pageid=2" />
                                                    </td>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <div class="grid" style="width: 90%">
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
                                                                <asp:GridView ID="gvschoolcode" runat="server" Width="100%" CssClass="datatable"
                                                                    CellPadding="5" CellSpacing="0" GridLines="None" AutoGenerateColumns="False"
                                                                    AllowPaging="True" EmptyDataText="PDF FILE is not available." PageSize="10" OnPageIndexChanging="gvschoolcode_PageIndexChanging"
                                                                    OnRowCommand="gvschoolcode_RowCommand">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="SchoolId" HeaderText="Table ID">
                                                                            <HeaderStyle HorizontalAlign="left" Width="5%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="5%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="SchoolName" HeaderText="School Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Management" HeaderText="Management ">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="SchoolType" HeaderText="SchoolType ">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="LowClass" HeaderText="Low Class">
                                                                            <HeaderStyle HorizontalAlign="left" Width="5%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="5%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="HighClass" HeaderText="High Class">
                                                                            <HeaderStyle HorizontalAlign="left" Width="5%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="5%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                    <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <PagerStyle CssClass="pager-row" />
                                                                </asp:GridView>
                                                                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
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
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
