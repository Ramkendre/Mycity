<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="MenuMaster1.aspx.cs" Inherits="MarketingAdmin_MenuMaster1" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<table cellpadding="0" cellspacing="0" width="70%" border="1" ><tr><td align="center">
            <div style="width: 80%">
                </div>
    <div class="grid" style="width: 70%">
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
                                   
                                     <asp:GridView ID="gvMenu" runat="server" Width="100%" CssClass="datatable" 
                                      CellPadding="5" CellSpacing="0" GridLines="None" AutoGenerateColumns="False" 
                                        EmptyDataText="Menu List is not available." 
                                         onselectedindexchanged="gvMenu_SelectedIndexChanged" >   
                                       
                                        
                                        <Columns>
                                            <asp:HyperLinkField DataNavigateUrlFields="pageurl" Text="&lt;img src='../resources1/images/ICON.png' border=0&amp;gt"
                                                DataNavigateUrlFormatString="#">
                                                <ItemStyle Width="5%" HorizontalAlign="Right" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField DataNavigateUrlFields="pageurl" DataTextField="pagename" DataNavigateUrlFormatString="{0}"
                                                ControlStyle-Font-Size="10pt">
                                                <ItemStyle Width="40%" HorizontalAlign="Center" />
                                            </asp:HyperLinkField>
                                            
                                            
                                        </Columns>
                                   
                                        <RowStyle CssClass="row" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <PagerStyle CssClass="pager-row" />
                                    </asp:GridView>
                                    
                                    <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                    <asp:HyperLink ID="HyperLink1"  runat="server" NavigateUrl="~/MarketingAdmin/EmployeeReports.aspx">Employee Report</asp:HyperLink>
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
     </td></tr></table>
            </ContentTemplate></asp:UpdatePanel>
</asp:Content>

