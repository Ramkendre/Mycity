<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="uvajagarReport.aspx.cs" Inherits="MarketingAdmin_uvajagarReport" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%" border="1">
        <tr>
            <td align="center">
                <table style="width: 97%; height: 290px; margin-right: 0px;" 
                    class="tblAdminSubFull1" cellspacing="0px">
                    <tr>
                    <td colspan="3" style="text-align: center">
                    <asp:Label ID="Label3" runat="server" Text="CodeWise  Report" Font-Bold="True" 
                            Font-Size="X-Large"></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td colspan="3" style="text-align: center; height: 28px">
                    </td>
                    </tr>
                    <tr>
                    <td style="text-align: left; width: 104px; height: 40px">
                    <asp:Label ID="Label1" runat="server" Text="Select Code:"></asp:Label>
                    </td>
                    <td style="width: 150px; text-align: left; height: 40px">
                        <asp:TextBox ID="txtcode" runat="server"></asp:TextBox>
                    </td>
                    <td style="text-align: left; height: 40px">
                        <asp:Button ID="btnView" runat="server" Text="View" CssClass="button" 
                            Height="29px" Width="79px" onclick="btnView_Click" />
                    &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="button" Height="29px" 
                            onclick="btnCancel_Click" Text="Cancel" Width="71px" />
                    </td>
                     </tr>
                    <tr>
                    <td style="text-align: left; width: 104px; height: 40px">
                    <asp:Label ID="Label2" runat="server" Text="Total Count:" ForeColor="Red" Visible="false"></asp:Label>
                    </td>
                    <td style="width: 150px; text-align: left; height: 40px">
                         <asp:Label ID="lblCount" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                    </td>
                    <td style="text-align: left; height: 40px">
                        &nbsp;</td>
                     </tr>
                    <tr>
                    <td colspan="3" style="text-align: left; height: 40px">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="10">
                         <Columns>
                                 <asp:BoundField DataField="id" HeaderText="Id">
                                        <HeaderStyle HorizontalAlign="left" Width="10%" />
                                        <ItemStyle HorizontalAlign="left" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Name" HeaderText="Name">
                                        <HeaderStyle HorizontalAlign="left" Width="30%" /> 
                                        <ItemStyle HorizontalAlign="left" Width="30%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="usrMobileNo" HeaderText="MobileNo">
                                        <HeaderStyle HorizontalAlign="left" Width="60%" />
                                        <ItemStyle HorizontalAlign="left" Width="60%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="usrAddress" HeaderText="Address">
                                        <HeaderStyle HorizontalAlign="left" Width="60%" />
                                        <ItemStyle HorizontalAlign="left" Width="60%" />
                                    </asp:BoundField>
                                   
                                </Columns>
                        </asp:GridView>
                    </td>
                     </tr>
                     </table>
            </td>
        </tr>
    </table>
</asp:Content>
