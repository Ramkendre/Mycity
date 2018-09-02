<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="SmsReportUdise.aspx.cs" Inherits="MarketingAdmin_SmsReportUdise" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table class="tables" width="100%">
            <tr>
                <td>
                    <center>
                        <div style="border: 1px solid #888888;">
                            <div style="margin-right: 40px; float: left;">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMonth" runat="server" Text="" Font-Bold="true" Font-Size="10"></asp:Label>==
                                            <asp:Label ID="lblBill" runat="server" Text="" ForeColor="green" Font-Bold="true"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <br />
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <h3>
                                                Send SMS Report</h3>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></center>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Select Date :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="txtcss" MaxLength="10"></asp:TextBox>
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/calendarclick.gif" />
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" PopupButtonID="Image1"
                                            TargetControlID="txtDate">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Select Month :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="ddlcss">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            <asp:ListItem Value="1">Jan</asp:ListItem>
                                            <asp:ListItem Value="2">Feb</asp:ListItem>
                                            <asp:ListItem Value="3">Mar</asp:ListItem>
                                            <asp:ListItem Value="4">April</asp:ListItem>
                                            <asp:ListItem Value="5">May</asp:ListItem>
                                            <asp:ListItem Value="6">Jun</asp:ListItem>
                                            <asp:ListItem Value="7">July</asp:ListItem>
                                            <asp:ListItem Value="8">Aug</asp:ListItem>
                                            <asp:ListItem Value="9">Sept</asp:ListItem>
                                            <asp:ListItem Value="10">Oct</asp:ListItem>
                                            <asp:ListItem Value="11">Nov</asp:ListItem>
                                            <asp:ListItem Value="12">Dec</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Select Year :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="ddlcss">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            <asp:ListItem Value="1">2013</asp:ListItem>
                                            <asp:ListItem Value="2">2014</asp:ListItem>
                                            <asp:ListItem Value="3">2015</asp:ListItem>
                                            <asp:ListItem Value="4">2016</asp:ListItem>
                                            <asp:ListItem Value="5">2017</asp:ListItem>
                                            <asp:ListItem Value="6">2018</asp:ListItem>
                                            <asp:ListItem Value="7">2019</asp:ListItem>
                                            <asp:ListItem Value="8">2020</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" OnClick="btnSubmit_Click" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" 
                                            onclick="btnCancel_Click" />
                                        <asp:Button ID="btnBill" runat="server" Text="Total SMS" CssClass="btn" OnClick="btnBill_Click" />
                                        <asp:Button ID="btnDownload" runat="server" Text="Download" CssClass="btn" OnClick="btnDownload_Click" />
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView ID="gvToday" runat="server" AutoGenerateColumns="False" BackColor="White"
                                            BorderColor="#DEDFDE" BorderWidth="1px" ForeColor="Black" GridLines="Vertical"
                                            BorderStyle="Solid" EmptyDataText="No Data Found" AllowPaging="true" PageSize="20"
                                            ToolTip="Details of Items" OnPageIndexChanging="gvToday_PageIndexChanging">
                                            <RowStyle BackColor="#F7F7DE" Height="30px" />
                                            <Columns>
                                                <asp:BoundField DataField="SendFrom" HeaderText="SendFrom">
                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="sentMessage" HeaderText="Message">
                                                    <HeaderStyle HorizontalAlign="Center" Width="300px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="300px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TotalSMSSend" HeaderText="Total SMS Sent">
                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="smslength" HeaderText="SMS length">
                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="SMS Count" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCountSms" runat="server" Text="Label"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total SMS" HeaderStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalSMS" runat="server" Text="Label"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="EntryDate" HeaderText="Date">
                                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle BackColor="#CCCC99" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#009999" Font-Bold="True" Font-Size="1.1em" ForeColor="White"
                                                Height="30px" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </div>
                    </center>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
