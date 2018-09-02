<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="StormAbsentyReport.aspx.cs" Inherits="MarketingAdmin_StormAbsentyReport"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="outsidediv">
        <div class="headingdiv">
            <div align="center" class="style1" style="background-color: #87CEFA;">
                <span id="Span2" class="spanTitle" runat="server">school Wise Absenty Report</span>
            </div>
            <table>
                <tr>
                    <td colspan="4" align="center" class="style1" style="width: 100px;">
                        <%--<span id="Span4" class="spanTitle" runat="server">Staff Attendance </span>--%>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Select Date:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDateSP" runat="server" CssClass="txtcss" Width="120px"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="yyyy-MM-dd"
                            TargetControlID="txtDateSP">
                        </asp:CalendarExtender>
                    </td>
                </tr>
                <tr><td></td><td></td></tr>
                <tr>
                    <td align="left">
                        Select Option:
                    </td>
                    <td align="left">
                        <%--<asp:TextBox ID="txtSchoolCode" runat="server" Width="130px" Height="20px"></asp:TextBox>--%>
                        <asp:DropDownList ID="ddlActiveOption" runat="server" AutoPostBack="true" Width="120px">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="1">ON CL</asp:ListItem>
                        <asp:ListItem Value="2">Medical Leave</asp:ListItem>
                        <asp:ListItem Value="3">Outdoor Office</asp:ListItem>
                        <asp:ListItem Value="4">On Training</asp:ListItem>
                        <asp:ListItem Value="5">Absent Without Notice</asp:ListItem>
                        <asp:ListItem Value="6">Late Attendance </asp:ListItem>
                        <asp:ListItem Value="7">Half Day Leave</asp:ListItem>
                        <asp:ListItem Value="8">Earned Leave</asp:ListItem>
                        <asp:ListItem Value="9">Maternity</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr><td></td><td></td></tr>
                <tr>
                    <td align="left">
                        Enter SchoolCode  :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtSchoolCodeSP" runat="server" Width="120px" Height="18px" OnTextChanged="txtSchoolCodeSP_TextChanged"
                            AutoPostBack="true"></asp:TextBox>
                        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSchoolCodeSP"
                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="11" CompletionInterval="100"
                            ServiceMethod="SchoolCode">
                        </asp:AutoCompleteExtender>
                        <%--<asp:Button ID="btnSerchSP" runat="server" Font-Bold="true" ForeColor="Maroon" Text="Search"
                            Width="129px" OnClick="btnSerchSP_Click" />--%>
                    </td>
                </tr>
             <%--<tr><td></td><td></td></tr>
                <tr>
                    <td align="left">
                        Select SchoolCode:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtSchoolCode" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        <asp:DropDownList ID="DDLSchoolCodeSP" runat="server" AutoPostBack="true" Width="120px">
                        </asp:DropDownList>
                    </td>
                </tr>--%>
                <tr><td></td><td></td></tr><tr><td></td><td></td></tr>
                <tr>
                    <td align="left">
                    </td>
                    <td align="left">
                        <asp:Button ID="btnSubmit" runat="server" Font-Bold="true" ForeColor="Maroon" Text="Submit"
                            Width="129px" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" CssClass="gridview">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr.No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="School Name" DataField="CompanyName" />
                                <asp:BoundField HeaderText="Teacher Name" DataField="T_Name" />
                                <asp:BoundField HeaderText="Teacher MobileNo" DataField="T_MobileNo" />
                                <asp:BoundField HeaderText="Role" DataField="Role" />
                                <asp:BoundField HeaderText="Remark" DataField="Remark" />
                                <%--<asp:BoundField HeaderText="AbsentOption" DataField="AbsentOption" />--%>
                                <asp:BoundField HeaderText="Time" DataField="Time" />
                                <asp:BoundField HeaderText="date" DataField="date" />
                                <asp:BoundField HeaderText="SchoolCode" DataField="s" />
                                <asp:BoundField HeaderText="currentDate" DataField="currentDate" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
