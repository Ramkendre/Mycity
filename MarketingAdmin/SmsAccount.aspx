<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="SmsAccount.aspx.cs" Inherits="MarketingAdmin_SmsAccount" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <center>
            <div style="border: 1px solid #888888;">
                <div>
                    <table class="tables" width="80%">
                        <tr>
                            <td>
                                <h3 style="text-align: center">
                                    Send SMS Account
                                </h3>
                                <br />
                                <center>
                                    <asp:RadioButtonList ID="rblChk" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                        OnSelectedIndexChanged="rblChk_SelectedIndexChanged">
                                        <asp:ListItem Value="1">Today Report</asp:ListItem>
                                        <asp:ListItem Value="2">Details</asp:ListItem>
                                        <asp:ListItem Value="3">Search</asp:ListItem>
                                        
                                    </asp:RadioButtonList>
                                </center>
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="Panel1" runat="server">
                        <table class="tables" width="80%">
                            <tr>
                                <td>
                                    Message
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMgs" runat="server" TextMode="MultiLine" Width="250px" Height="80px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Send Date
                                </td>
                                <td>
                                    <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Send From
                                </td>
                                <td>
                                    <asp:Label ID="lblSendFrom" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Send To
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSendto" runat="server" TextMode="MultiLine" Width="250px" Height="80px"></asp:TextBox>
                                </td>
                                <td>
                                    Total =<asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="btnDetails" runat="server" Text="Details" CssClass="btn" />
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server">
                        <table class="tables" width="80%">
                            <tr>
                                <td>
                                    Enter Mobile No
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMobileNo" runat="server" CssClass="txtcss"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Select Date
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDateForm" runat="server" CssClass="txtcss"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtDateForm">
                                    </asp:CalendarExtender>
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/resources1/images/calendarclick.gif"
                                        Width="15px" Height="15px" />
                                </td>
                                <td>
                                </td>
                            </tr>
                           
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn" OnClick="btnSearch_Click" />
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel3" runat="server">
                        <table class="tables" width="80%">
                            <tr>
                                <td>
                                    Total Today Counter=
                             
                                    <asp:Label ID="lblCounter" runat="server" Text="0"></asp:Label>
                                </td>
                               
                            </tr>
                        </table>
                        <div class="pager">
                            <asp:GridView ID="gvToday" runat="server" Width="90%" CssClass="mGrid" CellPadding="5"
                                CellSpacing="0" GridLines="None" AutoGenerateColumns="False" EmptyDataText="No Data available.">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="SendFrom" HeaderText="SendFrom"></asp:BoundField>
                                    <asp:BoundField DataField="Total_Sent" HeaderText="Total_Sent "></asp:BoundField>
                                </Columns>
                                <RowStyle CssClass="row" HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <PagerStyle CssClass="pager-row" />
                            </asp:GridView>
                            <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <div>
                    <asp:GridView ID="gvItem" runat="server" Width="600px" CssClass="mGrid" CellPadding="5"
                        CellSpacing="0" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                        EmptyDataText="No Data available." PageSize="10" OnRowCommand="gvItem_RowCommand"
                        OnPageIndexChanging="gvItem_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID">
                                <HeaderStyle HorizontalAlign="left" Width="40px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="left" Width=""></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="SendFrom" HeaderText="SendFrom">
                                <HeaderStyle HorizontalAlign="left" Width="100px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="left" Width=""></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="SendTo" HeaderText="SendTo ">
                                <HeaderStyle HorizontalAlign="left" Width="100px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="left" Width="100px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="sentMessage" HeaderText="sentMessage ">
                                <HeaderStyle HorizontalAlign="left" Width="200px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="left" Width="200px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="EntryDate" HeaderText="sendDateTime ">
                                <HeaderStyle HorizontalAlign="left" Width="50px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="left" Width="50px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="smslength" HeaderText="smslength ">
                                <HeaderStyle HorizontalAlign="left" Width="50px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="left" Width="50px"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Details">
                                <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("ID") %>' runat="server"
                                        ImageUrl="~/Resources/resources1/images/ico_yes1.gif" CommandName="Details">
                                    </asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="row" HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <PagerStyle CssClass="pager-row" />
                    </asp:GridView>
                    <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                </div>
        </center>
    </div>
</asp:Content>
