<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="AllSmsReport.aspx.cs" Inherits="MarketingAdmin_AllSmsReport" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div>
            <div style="border: 1px solid #888888;">
                <center>
                    <%--<table class="tables">
                        <tr>
                            <td>
                                <asp:RadioButtonList ID="rblChk" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                    OnSelectedIndexChanged="rblChk_SelectedIndexChanged">
                                    <asp:ListItem Value="1">Show ALL</asp:ListItem>
                                    <asp:ListItem Value="2">Catagory Wise</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="Panel1" runat="server">--%>
                        <table class="tables">
                            <tr>
                                <td colspan="2">
                                    <center>
                                        <span style="color: Black; font-size: 1em; font-weight: bold">All SMS Report</span>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Select Date
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                        Format="dd-MM-yyyy">
                                    </asp:CalendarExtender>
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="button" OnClick="btnSearch_Click" />
                                </td>
                            </tr>
                            <%--<tr>
                            <td>Category
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCatagory" runat="server" AutoPostBack="true" 
                                    onselectedindexchanged="ddlCatagory_SelectedIndexChanged">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem>LongCode</asp:ListItem>
                                    <asp:ListItem>UDISE</asp:ListItem>
                                    <asp:ListItem>NSS</asp:ListItem>
                                    <asp:ListItem>Miscal</asp:ListItem>
                                    <asp:ListItem>COM2MYCT</asp:ListItem>
                                    <asp:ListItem>Website</asp:ListItem>
                                    <asp:ListItem>QuickSMS</asp:ListItem>
                                    <asp:ListItem>ASCIIPage</asp:ListItem>
                                    <asp:ListItem>Test</asp:ListItem>
                                    <asp:ListItem>myctin</asp:ListItem>
                                    <asp:ListItem>PromotionalSMS</asp:ListItem>
                                    <asp:ListItem>MobileLongCode</asp:ListItem>
                                    <asp:ListItem>GroupSMS</asp:ListItem>
                                    <asp:ListItem>myct.in</asp:ListItem>
                                    <asp:ListItem>CollectorOffice</asp:ListItem>
                                    <asp:ListItem>NCPJLN</asp:ListItem>
                                    <asp:ListItem>AndroidLongCode</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>--%>
                            <tr>
                                <td>
                                    Long Code
                                </td>
                                <td>
                                    <asp:Label ID="lblLongCode" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Total
                                </td>
                                <td>
                                    <asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gvItem" runat="server" CssClass="mGrid" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="100px">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="SendFrom" HeaderText="SendFrom"></asp:BoundField>
                                            <asp:BoundField DataField="Total_Sent" HeaderText="Total_Sent"></asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                   <%-- </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server">
                        <table class="tables">
                            <tr>
                                <td>
                                    Catagory
                                </td>
                                <td>
                                    <asp:Label ID="lblcatagory" runat="server" Text="0"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Total
                                </td>
                                <td>
                                    <asp:Label ID="lblShowTotal" runat="server" Text="0"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gvShowId" runat="server" CssClass="mGrid" AutoGenerateColumns="false"
                                        AllowPaging="true" PageSize="20" 
                                        onpageindexchanging="gvShowId_PageIndexChanging" 
                                        onrowcommand="gvShowId_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="100px">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ID" HeaderText="SendFrom" Visible="false"></asp:BoundField>
                                            <asp:BoundField DataField="SendFrom" HeaderText="SendFrom"></asp:BoundField>
                                            <asp:BoundField DataField="Total_Sent" HeaderText="Total_Sent"></asp:BoundField>
                                            <asp:TemplateField HeaderText="Show">
                                                <ItemStyle HorizontalAlign="left"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Button ID="btnExcel" runat="server" CommandArgument='<%#Bind("ID")%>' CommandName="Show"
                                                        Text="Show Total" CssClass="button" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>--%>
                </center>
            </div>
        </div>
    </div>
</asp:Content>
