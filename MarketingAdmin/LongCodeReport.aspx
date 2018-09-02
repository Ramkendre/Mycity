<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="LongCodeReport.aspx.cs" Inherits="MarketingAdmin_LongCodeReport" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <table cellpadding="0" cellspacing="0" width="100%" border="1">
        <tr>
            <td align="center">
                <table style="width: 97%; height: 290px;" class="tblAdminSubFull1" cellspacing="0px">
                    <tr>
                        <td align="center" style="height: 44px">
                            <asp:Label ID="lblHeader" runat="server" Text="LongCode Report" Font-Bold="True"
                                Font-Size="X-Large"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 44px">
                            <asp:Button ID="btnGridtoexcel" runat="server" Text="Download To Excel" OnClick="btnGridtoexcel_Click"
                                CssClass="button" />
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnback" runat="server" Text="Back" CssClass="button" OnClick="btnback_Click"
                                Width="108px" />
                        </td>
                    </tr>
                    <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Total Count:" ForeColor="Red"></asp:Label>&nbsp;&nbsp;
                        <asp:Label ID="lbltotalcount" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                     
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvLongCodeReport" runat="server" AutoGenerateColumns="False" OnPageIndexChanged="gvLongCodeReport_PageIndexChanged"
                                OnPageIndexChanging="gvLongCodeReport_PageIndexChanging" AllowPaging="true" PageSize="10">
                                <Columns>
                                 <asp:BoundField DataField="PK" HeaderText="Id">
                                        <HeaderStyle HorizontalAlign="left" Width="10%" />
                                        <ItemStyle HorizontalAlign="left" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="mobile" HeaderText="Mobile Number">
                                        <HeaderStyle HorizontalAlign="left" Width="30%" />
                                        <ItemStyle HorizontalAlign="left" Width="30%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Message" HeaderText="Message">
                                        <HeaderStyle HorizontalAlign="left" Width="50%" />
                                        <ItemStyle HorizontalAlign="left" Width="50%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="shortcode" HeaderText="Date">
                                        <HeaderStyle HorizontalAlign="left" Width="20%" />
                                        <ItemStyle HorizontalAlign="left" Width="20%" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
