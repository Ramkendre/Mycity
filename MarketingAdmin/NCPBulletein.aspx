<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="NCPBulletein.aspx.cs" Inherits="MarketingAdmin_NCPBulletein" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%" border="1">
                <tr>
                    <td align="center">
                        <asp:GridView ID="gvCommittees" runat="server" CssClass="mGrid" 
                            AutoGenerateColumns="False">
                          
                            <Columns>
                                <asp:BoundField DataField="Id" Visible="false">
                                    <HeaderStyle HorizontalAlign="Left" Width="30%" />
                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                </asp:BoundField>
                                <asp:HyperLinkField DataNavigateUrlFields="hiturl" DataTextField="Committee_name"
                                    DataNavigateUrlFormatString="{0}" ControlStyle-Font-Size="10pt">
                                    <ItemStyle Width="40%" HorizontalAlign="Center" />
                                </asp:HyperLinkField>
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

