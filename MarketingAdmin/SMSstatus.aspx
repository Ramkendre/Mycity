<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="SMSstatus.aspx.cs" Inherits="MarketingAdmin_SMSstatus" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%" border="1">
                <tr>
                    <td align="center">
                        <div style="width: 70%">
                            <table cellpadding="0" cellspacing="0" border="0" class="tables" style="width: 98%;
                                height: 332px">
                                <tr>
                                    <td style="height: 20px;">
                                        <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;">
                                        <table style="width: 97%; height: 76px;" class="tblAdminSubFull1" cellspacing="0px">
                                            <tr>
                                                <td align="center" colspan="2" style="height: 26px">
                                                    <asp:Label ID="lblHeader" runat="server" Text="SMS Status" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px">
                                                    <asp:Label ID="lblmobileno" runat="server" Text="Enter Mobile No."></asp:Label>
                                                </td>
                                                <td style="height: 20px">
                                                    <asp:TextBox ID="txtmobileno" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px">
                                                    <asp:Label ID="lblid" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                                <td style="height: 20px">
                                                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
                                                        CssClass="button" />
                                                    &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="button" OnClick="btnCancel_Click"
                                                        Text="Cancel" />
                                                    &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="button" OnClick="btnBack_Click"
                                                        Text="Back" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 20px">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 20px">
                                                    <asp:GridView ID="GridSMSstatus" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                        CellPadding="5" CellSpacing="0" CssClass="mGrid" EmptyDataText="No any records"
                                                        GridLines="Both" OnRowCommand="GridSMSstatus_RowCommand" OnRowDeleting="GridSMSstatus_RowDeleting"
                                                        PageSize="5" Width="100%" 
                                                        onpageindexchanging="GridSMSstatus_PageIndexChanging">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Id" DataField="id">
                                                                <HeaderStyle HorizontalAlign="left" Width="10%" />
                                                                <ItemStyle HorizontalAlign="left" Width="10%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FullName" HeaderText="FullName">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%" />
                                                                <ItemStyle HorizontalAlign="left" Width="30%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="usrMobileNo" HeaderText="MobileNo">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%" />
                                                                <ItemStyle HorizontalAlign="left" Width="30%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SMS_status" HeaderText="Status">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%" />
                                                                <ItemStyle HorizontalAlign="left" Width="30%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="sms_date" HeaderText="Date">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%" />
                                                                <ItemStyle HorizontalAlign="left" Width="30%" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton4" runat="server" CommandArgument='<%#Bind("id") %>'
                                                                        CommandName="Delete" ImageUrl="~/resources1/images/close.gif" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <PagerStyle CssClass="pager-row" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="GridSMSstatus" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
