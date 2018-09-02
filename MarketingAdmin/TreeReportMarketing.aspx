<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="TreeReportMarketing.aspx.cs" Inherits="MarketingAdmin_TreeReportMarketing"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%" border="1">
        <tr>
            <td colspan="2" style="height: 20px;">
                <table style="width: 97%; height: 290px;" class="tblAdminSubFull1" cellspacing="0px">
                    <tr>
                        <td align="center" style="height: 28px">
                            <asp:Label ID="lblHeader" runat="server" Text="Tree Report of Marketing Person" Font-Bold="True"
                                Font-Size="X-Large"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 28px">
                            <asp:TreeView ID="TreeView1" ExpandDepth="0" PopulateNodesFromClient="true" ShowLines="true"
                                ShowExpandCollapse="true" runat="server" OnTreeNodePopulate="TreeView1_TreeNodePopulate" />
                        </td>
                    </tr>
                    <tr align="center">
                        <td>
                            <asp:Button ID="btnback" runat="server" Text="Back" CssClass="button" />
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
