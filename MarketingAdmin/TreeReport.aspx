<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="TreeReport.aspx.cs" Inherits="MarketingAdmin_TreeReport" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    
       
            
               <div style="width: 100%; margin-left: 5%;">
            <div style="width: 45%; text-align: center; float: left; background-color: #BFF7EE;
                border: 2px outset;">
                <asp:LinkButton ID="lnkNameWise" runat="server" OnClick="lnkNameWise_Click"> Tree Report NameWise
                </asp:LinkButton>
            </div>
            <div style="width: 45%; text-align: center; float: left; background-color: #BFF7EE;
                border: 2px outset;">
                <asp:LinkButton ID="lnkMobileNoWise" runat="server" OnClick="lnkMobileNoWise_Click"> Tree Report MobileNoWise
                </asp:LinkButton>
            </div>
            <%--<div style="width: 45%; text-align: center; float: left; background-color: #BFF7EE;
                border: 2px outset;">
                <asp:LinkButton ID="lnkImage" runat="server" OnClick="lnkImage_Click"> Teacher Image Report
                </asp:LinkButton>
            </div>--%>
        </div>
        <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                <table cellpadding="0" cellspacing="0" width="100%" border="1">
                        <tr>
                            <td colspan="2" style="height: 20px;">
                                <table style="width: 97%; height: 290px;" class="tblAdminSubFull1" cellspacing="0px">
                                    <tr>
                                        <td align="center" style="height: 28px">
                                            <asp:Label ID="lblHeader" runat="server" Text="Tree Report of SubUser" Font-Bold="True"
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
                                    <asp:Button ID="btnback" runat="server" Text="Back" CssClass="button" 
                                            onclick="btnback_Click" />
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
    </asp:View>
                  <asp:View ID="View2" runat="server">
                <table cellpadding="0" cellspacing="0" width="100%" border="1">
                        <tr>
                            <td colspan="2" style="height: 20px;">
                                <table style="width: 97%; height: 290px;" class="tblAdminSubFull1" cellspacing="0px">
                                    <tr>
                                        <td align="center" style="height: 28px">
                                            <asp:Label ID="Label1" runat="server" Text="Tree Report of SubUser" Font-Bold="True"
                                                Font-Size="X-Large"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="height: 28px">
                                            <asp:TreeView ID="TreeView2" ExpandDepth="0" PopulateNodesFromClient="true" ShowLines="true"
                                                ShowExpandCollapse="true" runat="server" OnTreeNodePopulate="TreeView2_TreeNodePopulate" />
                                        </td>
                                    </tr>
                                    <tr align="center">
                                    <td>
                                    <asp:Button ID="btnback2" runat="server" Text="Back" CssClass="button" 
                                            onclick="btnback2_Click" />
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
    </asp:View>
     </asp:MultiView>
</asp:Content>
