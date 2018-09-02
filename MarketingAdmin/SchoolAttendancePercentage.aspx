<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchoolAttendancePercentage.aspx.cs"
    Inherits="MarketingAdmin_SchoolAttendancePercentage" MasterPageFile="~/Master/MarketingMaster.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <div>
                    <center>
                        <div style="border: 1px solid #888888;">
                            <div>
                                <center>
                                    <table class="tables">
                                        <tr>
                                            <td colspan="2">
                                                <h3 style="text-align: center">
                                                    School Attendance Details
                                                </h3>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                Today Attendence:
                                                <asp:Label ID="lblDate" runat="server" Text="No date" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                Mobile Number: &nbsp;&nbsp;
                                                <asp:TextBox ID="txtmobile" runat="server" CssClass="txtcss"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                School Code: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:TextBox ID="txtschool" runat="server" CssClass="txtcss"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn" OnClick="btnsearch_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                                <table class="tables">
                                    <tr>
                                        <td colspan="2">
                                            <center><%--PageSize="20" AllowPaging="true"--%>
                                                <div style="margin-bottom: 20px; margin-top: 20px; height: 300px; overflow: scroll;
                                                    border: 1px solid #0d7074; width: 888px;">
                                                    <asp:GridView ID="gvToday" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                        BorderColor="#DEDFDE" BorderWidth="1px" ForeColor="Black" GridLines="Vertical" 
                                                        Width="100%" EmptyDataText="No Data Found" ToolTip="Details of Items" OnRowCommand="gvToday_RowCommand"
                                                        BorderStyle="None" OnPageIndexChanging="gvToday_PageIndexChanging" Height="201px"
                                                        Style="margin-left: 0px">
                                                        <RowStyle BackColor="#F7F7DE" Height="30px" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                                <ItemStyle Width="20px"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="mobile" HeaderText="Mobile" HeaderStyle-Width="400px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FName" HeaderText="First Name" HeaderStyle-Width="400px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="LName" HeaderText="Last Name" HeaderStyle-Width="400px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BoysAttendance" HeaderText="'%' Boys Present" HeaderStyle-Width="400px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="GirlAttendance" HeaderText="'%' Girl Present" HeaderStyle-Width="400px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SchoolAttendance" HeaderText="'%' School Attendance" HeaderStyle-Width="400px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SchoolCode" HeaderText="School Code" HeaderStyle-Width="400px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                                                            </asp:BoundField>
                                                            <%--  <asp:BoundField DataField="EntryDate" HeaderText="Date" HeaderStyle-Width="500px">
                                                                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                                <ItemStyle HorizontalAlign="Center" Width="100px" Font-Bold="true" />
                                                            </asp:BoundField>--%>
                                                            <asp:TemplateField HeaderText="Show School Attendance">
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="ImageButton1" CommandArgument='<%#Bind("mobile")%>' runat="server"
                                                                        Text="Show Class Attendance" CssClass="btn" CommandName="Show"></asp:Button>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#CCCC99" />
                                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#3d8c8f" Font-Bold="True" Font-Size="1.1em" ForeColor="White"
                                                            Height="30px" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </div>
                                            </center>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </center>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
