<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="Report.aspx.cs" Inherits="html_Report" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="95%" border="1">
                <tr>
                    <td align="center">
                        <div style="width: 100%">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="tables">
                                <tr>
                                    <td colspan="2" style="height: 20px;">
                                        <table style="width: 100%" class="tables" cellspacing="2" cellpadding="2">
                                            <tr>
                                                <td colspan="4">
                                                    <asp:TabContainer ID="Tab" runat="server" ActiveTabIndex="1" Width="100%">
                                                        <asp:TabPanel ID="tabGeneralInfo" runat="server">
                                                            <HeaderTemplate>
                                                                <label for="">
                                                                    LongCode Report</label></HeaderTemplate>
                                                            <ContentTemplate>
                                                                <table class="tblSubFull1">
                                                               <tr>
                                                               <td>
                                                                   <asp:Label ID="lblFrmdate" runat="server" Text="From Date" CssClass="lbl"></asp:Label>
                                                                   <asp:TextBox ID="txtFrmDate" runat="server"></asp:TextBox>
                                                                   <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                                                       TargetControlID="txtFrmDate" Enabled="True">
                                                                   </asp:CalendarExtender>
                                                                   
                                                               </td>
                                                               <td>
                                                               <asp:Label ID="lblTodate" runat="server" Text="To Date" CssClass="lbl"></asp:Label>
                                                                   <asp:TextBox ID="txtTodate" runat="server"></asp:TextBox>
                                                                   <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                                                                       TargetControlID="txtTodate" Enabled="True">
                                                                   </asp:CalendarExtender>
                                                               </td>
                                                               <td>
                                                                   <asp:Button ID="btnGetRecord" runat="server" Text="Get Record" 
                                                                       onclick="btnGetRecord_Click" CssClass="button" />
                                                               </td>
                                                               </tr>
                                                                <tr>
                                                                 <td style="height: 20px;">
                                                                     Status=0(Delivered) <br />Status=1(UnDelivered)
                                                            </td>
                                                                 
                                                                </tr>
                                                                    <tr>
                                                                        <td style="height: 20px;">
                                                                            <div class="grid" style="width: 100%">
                                                                                <div class="rounded">
                                                                                    <div class="top-outer">
                                                                                        <div class="top-inner">
                                                                                            <div class="top">
                                                                                                &nbsp;&nbsp;<span style="color: #FF0000">*</span></div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="mid-outer">
                                                                                        <div class="mid-inner">
                                                                                            <div class="mid">
                                                                                                <div class="pager">
                                                                                                    <asp:GridView ID="gvUser" runat="server" Width="90%" CssClass="mGrid" CellPadding="5"
                                                                                                        GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True"  
                                                                                                        EmptyDataText="Record Is Not Found" 
                                                                                                        OnPageIndexChanging="gvUser_PageIndexChanging">
                                                                                                        <Columns>
                                                                                                            <asp:BoundField DataField="msgTo" HeaderText="To">
                                                                                                                <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                                                                <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="msgDate" HeaderText="Date">
                                                                                                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="sendername" HeaderText="Sender Name">
                                                                                                                <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                                                                <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                                                            </asp:BoundField>
                                                                                                             <asp:BoundField DataField="Msg"  HeaderText="Message">
                                                                                                                <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                                                                <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="Flagstatus" HeaderText="Status">
                                                                                                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
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
                                                                    <tr>
                                                                    <td>
                                                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="button" 
                                                                            onclick="btnBack_Click" />
                                                                    </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:TabPanel>
                                                        <asp:TabPanel ID="tabProfessionInfo" runat="server">
                                                            <HeaderTemplate>
                                                                <label for="">
                                                                    Website Report</label></HeaderTemplate>
                                                            <ContentTemplate>
                                                                <table class="tblSubFull1">
                                                                  <tr>
                                                               <td>
                                                                   <asp:Label ID="lblFrmdt" runat="server" Text="From Date" CssClass="lbl"></asp:Label>
                                                                   <asp:TextBox ID="txtFromDate1" runat="server"></asp:TextBox>
                                                                   <asp:CalendarExtender ID="CalendarExtender3" runat="server" 
                                                                       TargetControlID="txtFromDate1" Enabled="True">
                                                                   </asp:CalendarExtender>
                                                                   
                                                               </td>
                                                               <td>
                                                               <asp:Label ID="lbltodt" runat="server" Text="To Date"></asp:Label>
                                                                   <asp:TextBox ID="txtTodate1" runat="server"></asp:TextBox>
                                                                   <asp:CalendarExtender ID="CalendarExtender4" runat="server" 
                                                                       TargetControlID="txtTodate1" Enabled="True">
                                                                   </asp:CalendarExtender>
                                                               </td>
                                                               <td>
                                                                   <asp:Button ID="btnRecord" runat="server" Text="Get Record" onclick="btnRecord_Click"  CssClass="button"   />
                                                                    
                                                               </td>
                                                               </tr>
                                                                   <tr>
                                                                 <td style="height: 20px;">
                                                                     Status=0(Delivered) <br />Status=1(UnDelivered)
                                                            </td>
                                                                 
                                                                </tr> 
                                                                    <tr>
                                                                        <td style="height: 20px;">
                                                                            <div class="grid" style="width: 100%">
                                                                                <div class="rounded">
                                                                                    <div class="top-outer">
                                                                                        <div class="top-inner">
                                                                                            <div class="top">
                                                                                                &nbsp;&nbsp;</div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="mid-outer">
                                                                                        <div class="mid-inner">
                                                                                            <div class="mid">
                                                                                                <div class="pager">
                                                                                                    <asp:GridView ID="gvWebsiteReport" runat="server" Width="90%" CssClass="datatable"
                                                                                                        CellPadding="5" GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True"
                                                                                                        EmptyDataText="Record Is Not Found" 
                                                                                                        OnPageIndexChanging="gvWebsiteReport_PageIndexChanging">
                                                                                                        <Columns>
                                                                                                            <asp:BoundField DataField="ReceiverMobile" HeaderText="To">
                                                                                                                <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                                                                <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="date" HeaderText="Date">
                                                                                                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="Msg" HeaderText="Message">
                                                                                                                <HeaderStyle HorizontalAlign="Center" Width="30%"></HeaderStyle>
                                                                                                                <ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
                                                                                                            </asp:BoundField>
                                                                                                            <asp:BoundField DataField="status" HeaderText="Status">
                                                                                                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                                                            </asp:BoundField>
                                                                                                        </Columns>
                                                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                                                        <PagerStyle CssClass="pager-row" />
                                                                                                        <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                                                                    </asp:GridView>
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
                                                                    <tr>
                                                                    <td>
                                                                    <asp:Button ID="btnBack1" runat="server" Text="Back" CssClass="button" 
                                                                            OnClick="btnBack1_Click" />
                                                                    </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:TabPanel>
                                                    </asp:TabContainer>
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
