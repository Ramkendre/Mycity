<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master"
    AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="MarketingAdmin_MarketingHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="90%" border="1">
                <tr>
                    <td align="center">
                        <div style="width: 80%">
                            <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                                <tr>
                                    <td style="height: 20px;">
                                        <span class="warning1" style="color: Red;"></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                                            <tr>
                                                <td colspan="2">
                                                    <h4>
                                                        Welcome To Mr./Mrs: &nbsp;<%=Session["Name"]%>
                                                    </h4>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    &nbsp;&nbsp;<asp:Label ID="lblError" Visible="False" runat="server" CssClass="error"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td valign="bottom">
                                                    <asp:Label ID="lblfname" runat="server" Text="Select Your Role"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlrole" CssClass="ddlcss" runat="server">
                                                    </asp:DropDownList>
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
                                                        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnsave" runat="server" CssClass="btn" OnClick="btnsave_Click1"  
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
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
