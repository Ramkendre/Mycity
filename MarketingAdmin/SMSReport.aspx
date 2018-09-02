<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="SMSReport.aspx.cs" Inherits="MarketingAdmin_SMSReport" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function openPopup(strOpen) {
            open(strOpen, "Message",
         "status=1, width=300, height=200, top=100, left=300");
        }
    </script>

    <table cellpadding="0" cellspacing="0" width="100%" border="1">
        <tr>
            <td align="center">
                <div>
                    <table class="tblAdminSubFull1">
                        <tr>
                            <td align="center" colspan="8" style="height: 33px">
                                <asp:Label ID="lblHeader" runat="server" Text="SMS Report" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 88px; text-align: right;">
                                <asp:Label ID="lblfrmdate" runat="server" CssClass="lbl" Text="From Date"></asp:Label>
                            </td>
                            <td style="width: 51px; text-align: left;">
                                <asp:TextBox ID="txtfrmdate" runat="server" Enabled="true"></asp:TextBox>
                            </td>
                            <td style="width: 88px; text-align: left;">
                                <div id="pnlLoading1">
                                   
                                    <img src="../resources1/images/calendarclick.gif" id="imgFrom" alt=""
                                        style="height: 19px; width: 19px" />
                                </div>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfrmdate"
                                    PopupButtonID="imgFrom">
                                </asp:CalendarExtender>
                            </td>
                            <td style="width: 88px; text-align: right;">
                                <asp:Label ID="lbltodate" runat="server" CssClass="lbl" Text="To Date"></asp:Label>
                            </td>
                            <td style="text-align: left; width: 109px;">
                                <asp:TextBox ID="txttodate" runat="server" Enabled="true"></asp:TextBox>
                            </td>
                            <td style="text-align: left; width: 210px;">
                                <div id="Div1">
                                    <img src="../resources1/images/calendarclick.gif" id="imgTo" alt="" style="height: 19px; width: 19px" />
                                    
                                </div>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                                        PopupButtonID="imgTo">
                                    </asp:CalendarExtender>
                            </td>
                            <td style="text-align: left; width: 264px;">
                                <asp:Button ID="btnSearch" runat="server" CssClass="button" OnClick="btnSearch_Click"
                                    Text="Get" Height="24px" Width="52px" />
                            </td>
                            <td style="text-align: left">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 11px;" colspan="8">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 109px">
                                <asp:Label ID="lblcode" runat="server" Text="Tool Used" CssClass="lbl"></asp:Label>
                                &nbsp;
                            </td>
                            <td style="width: 51px; text-align: left;">
                                <asp:DropDownList ID="ddlcode" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: left; " colspan="3">
                                &nbsp;
                            </td>
                            <td style="text-align: left; width: 264px;">
                                &nbsp;
                            </td>
                            <td style="text-align: left; width: 239px;">
                                &nbsp;
                            </td>
                            <td style="text-align: left">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" style="text-align: left">
                                <asp:Label ID="lblttlsms" runat="server" Text="Total SMS:" ForeColor="Red" Visible="false"></asp:Label>
                                <asp:Label ID="lbltotalsms" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
                            </td>
                            <td colspan="3" style="text-align: left">
                                <asp:Label ID="lblsms" runat="server" Text="SMSCount:" ForeColor="Red" Visible="false"></asp:Label>
                                <asp:Label ID="lbltotal" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="8">
                                <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False" EmptyDataText="No Report"
                                    CssClass="mGrid" Width="100%" AllowPaging="true" PageSize="20" OnPageIndexChanging="gvReport_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="Id">
                                            <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SendFrom" HeaderText="From">
                                            <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SendTo" HeaderText="To">
                                            <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                        </asp:BoundField>
                                        <%--<asp:BoundField DataField="sentMessage" HeaderText="Message">
                                            <HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                        </asp:BoundField>--%>
                                        <asp:BoundField DataField="sendDateTime" HeaderText="Date">
                                            <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ProjectName" HeaderText="Tool">
                                            <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="smslength" HeaderText="Count">
                                            <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <%--<asp:LinkButton ID="lnkmsg" runat="server" CommandName="Msg" CommandArgument='<%#Eval("ID") %>'
                                                    Text="Msg"></asp:LinkButton>--%>
                                                <a href="javascript:openPopup('../Message.aspx?Message=<%# Eval("sentMessage") %>')">
                                                    Msg</a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="8" style="text-align: left">
                                <asp:Button ID="btnBack" runat="server" CssClass="button" Text="Back" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
