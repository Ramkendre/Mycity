<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="DownloadReport.aspx.cs" Inherits="MarketingAdmin_DownloadReport" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="1" height="500px" width="100%">
<tr>
<td valign="top">
 <asp:TabContainer ID="tabParentSMSControl1" runat="server" Width="100%" ActiveTabIndex="0"
        AutoPostBack="true" Font-Bold="True" Font-Size="Medium">
        <asp:TabPanel ID="Wanted" runat="server">
        <HeaderTemplate>
            All Download Report
        </HeaderTemplate>
        <ContentTemplate>
           <table cellpadding="0" cellspacing="0" width="100%" border="1">
            <tr>
                <td align="center">
                    <div>
                        <table class="tblAdminSubFull1">
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Label ID="lblHeader" runat="server" Text="All Download Report" Font-Bold="True"
                                        Font-Size="X-Large"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="text-align: left; width: 112px;">
                                    <asp:Label ID="lblselectlink" runat="server" Text="Select Link:"></asp:Label>
                                </td>
                                <td align="center" style="text-align: left; width: 190px">
                                    <asp:DropDownList ID="ddlselectLink" runat="server" Width="150px">
                                    </asp:DropDownList>
                                </td>
                                <td style="text-align: left">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" OnClick="btnSubmit_Click" />
                                </td>
                                <%-- <td align="center">
                                <asp:Label ID="lblselectdate" runat="server" Text="Select Date:"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtFromdt" runat="server"></asp:TextBox>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtTodate" runat="server"></asp:TextBox>
                            </td>--%>
                            </tr>
                            <tr>
                                <td colspan="3" style="text-align: left">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="text-align: left">
                                    <asp:Label ID="Label1" runat="server" Text="Total Download:" Visible="false"></asp:Label>
                                    <asp:Label ID="lblcount" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr align="center">
                                <td colspan="3">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging"
                                        EmptyDataText="No Report" CssClass="mGrid" Width="100%" AllowPaging="true" PageSize="5">
                                        <Columns>
                                            <asp:BoundField DataField="VisitorId" HeaderText="Id">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="VisitDateTime" HeaderText="Date">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RequestURL" HeaderText="URL">
                                                <HeaderStyle HorizontalAlign="Center" Width="50%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" Width="50%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="IPAdd" HeaderText="IP Address">
                                                <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr align="center">
                                <td colspan="3">
                                    <%--<asp:Button ID="btnBack" runat="server" CssClass="button" Text="Back" OnClick="btnBack_Click" />--%>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="unwanted" runat="server">
        <HeaderTemplate>
            Download Report
        </HeaderTemplate>
        <ContentTemplate>
          <table cellpadding="0" cellspacing="0" width="100%" border="1">
            <tr>
                <td align="center">
                    <div>
                        <table class="tblAdminSubFull1">
                            <tr>
                                <td align="center" colspan="3">
                                    <asp:Label ID="Label2" runat="server" Text=" Download Report" Font-Bold="True"
                                        Font-Size="X-Large"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="text-align: left; width: 112px;">
                                    <asp:Label ID="Label3" runat="server" Text="Select Link:"></asp:Label>
                                </td>
                                <td align="center" style="text-align: left; width: 190px">
                                    <asp:DropDownList ID="ddlwanted" runat="server" Width="150px">
                                    </asp:DropDownList>
                                </td>
                                <td style="text-align: left">
                                    <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="button" 
                                        OnClick="Button1_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="text-align: left">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="text-align: left">
                                    <asp:Label ID="Label4" runat="server" Text="Total Download:" Visible="False"></asp:Label>
                                    <asp:Label ID="Label5" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr align="center">
                                <td colspan="3">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
                                        EmptyDataText="No Report" CssClass="mGrid" Width="100%" AllowPaging="True" 
                                        PageSize="5" onpageindexchanging="GridView2_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="VisitorId" HeaderText="Id">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="VisitDateTime" HeaderText="Date">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RequestURL" HeaderText="URL">
                                                <HeaderStyle HorizontalAlign="Center" Width="50%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" Width="50%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="IPAdd" HeaderText="IP Address">
                                                <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr align="center">
                                <td colspan="3">
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        </ContentTemplate>
        </asp:TabPanel>
        </asp:TabContainer>
</td>
</tr>
</table>
   
     
</asp:Content>
