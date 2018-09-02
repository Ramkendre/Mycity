<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="StaffReport.aspx.cs" Inherits="MarketingAdmin_StaffReport" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>--%>
<%--<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
<script type="text/javascript">
function openPopup(productid, productname, price) {
window.open('newpopupwindow.aspx?productid=' + productid + '&productname=' + escape(productname) + '&price=' + price, "Popup", "width=200,height=200");
}
</script>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="outsidediv">
        <div class="headingdiv">
            <div align="center" class="style1" style="background-color: #87CEFA;">
                <span id="Span2" class="spanTitle" runat="server">Staff Report</span>
            </div>
        </div>
        <hr />
        <div style="width: 100%; margin-left: 5%;">
            <div style="width: 45%; text-align: center; float: left; background-color: #BFF7EE;
                border: 2px outset;">
                <asp:LinkButton ID="lnkStaffAttend" runat="server" OnClick="lnkStaffAttend_Click"> Staff Attendance
                </asp:LinkButton>
            </div>
            <div style="width: 45%; text-align: center; float: left; background-color: #BFF7EE;
                border: 2px outset;">
                <asp:LinkButton ID="lnkStaffAbsenty" runat="server" OnClick="lnkStaffAbsenty_Click"> Staff Absenty Report
                </asp:LinkButton>
            </div>
            <%--<div style="width: 45%; text-align: center; float: left; background-color: #BFF7EE;
                border: 2px outset;">
                <asp:LinkButton ID="lnkImage" runat="server" OnClick="lnkImage_Click"> Teacher Image Report
                </asp:LinkButton>
            </div>--%>
        </div>
        <asp:MultiView ID="MultiView1" runat="server" OnActiveViewChanged="MultiView1_ActiveViewChanged">
            <asp:View ID="View1" runat="server">
                <table>
                <tr>
                            <td colspan="4" align="center" class="style1" style="width: 100px;">
                                <span id="Span4" class="spanTitle" runat="server">Staff Attendance </span>
                            </td>
                        </tr>
                    <tr>
                        <td>
                            Select Date:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDateSP" runat="server" CssClass="txtcss"></asp:TextBox>
                            
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="yyyy-MM-dd"
                                TargetControlID="txtDateSP">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                   <tr>
                    <td align="left">
                        Enter SchoolCode number To search :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtSchoolCodeSP" runat="server" Width="120px" Height="18px" OnTextChanged="txtSchoolCodeSP_TextChanged"
                            AutoPostBack="true"></asp:TextBox>
                        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSchoolCodeSP"
                            MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="11" CompletionInterval="100"
                            ServiceMethod="SchoolCode">
                        </asp:AutoCompleteExtender>
                        <asp:Button ID="btnSerchSP" runat="server" Font-Bold="true" ForeColor="Maroon" Text="Search"
                            Width="129px" OnClick="btnSerchSP_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Select SchoolCode:
                    </td>
                    <td align="left">
                        <%--<asp:TextBox ID="txtSchoolCode" runat="server" Width="130px" Height="20px"></asp:TextBox>--%>
                        <asp:DropDownList ID="DDLSchoolCodeSP" runat="server" AutoPostBack="true" Width="129px">
                        </asp:DropDownList>
                    </td>
                </tr>
                    <tr>
                    <td></td>
                    
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Font-Bold="true" ForeColor="Maroon" Text="Submit"
                                Width="129px" OnClick="btnSubmit_Click" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gvItemSAT" runat="server" AutoGenerateColumns="false" CssClass="gridview">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <%--<ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>--%>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Time" DataField="Time" />
                                    <asp:BoundField HeaderText="Date" DataField="Date" />
                                    <%--<asp:BoundField HeaderText="Image" DataField="Image" />--%>
                                    <asp:TemplateField HeaderText="Image">
                                        <ItemTemplate>
                                            <asp:Image ID="img" runat="server" ImageUrl='<%# "~/StormHandler.ashx?pid="+ Eval("PID") %>'
                                                Height="70px" Width="70px" BorderColor="#164854" BorderWidth="1px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="T_Name" DataField="T_Name" />
                                    <%--<asp:TemplateField HeaderText="Teacher Name">
                                    <ItemTemplate>
                                        <a href="#" class="gridViewToolTip" onclick='openPopup("<%# Eval("PID")%>","<%# Eval("Image")%>")'>test</a>
                                    </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:BoundField HeaderText="TeacherMobileNo" DataField="tt" />
                                   
                                    <asp:BoundField HeaderText="schoolcode" DataField="schoolcode" />
                                    <asp:BoundField HeaderText="role" DataField="role" />
                                    <asp:BoundField HeaderText="HM_MobileNo" DataField="HM_MobileNo" />
                                    <asp:BoundField HeaderText="TeacherMobileNo" DataField="OwnerMobNo" />
                                    <asp:BoundField HeaderText="OwnIMEI_No" DataField="OwnIMEI_No" />
                                    <asp:BoundField HeaderText="currentDate" DataField="currentDate" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <table>
                    <tr>
                        <td>
                            Select Date:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDateA" runat="server" CssClass="txtcss"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="yyyy-MM-dd"
                                TargetControlID="txtDateA">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Enter SchoolCode::
                        </td>
                        <td>
                            <asp:TextBox ID="txtSchoolCodeA" runat="server"></asp:TextBox>
                            <asp:Button ID="btnSubmitT" runat="server" Font-Bold="true" ForeColor="Maroon" Text="Submit"
                                Width="129px" OnClick="btnSubmitT_Click" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gvItemT" runat="server" AutoGenerateColumns="false" CssClass="gridview">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="StaffAbsId" DataField="StaffAbsId" />
                                    <asp:BoundField HeaderText="T_Name" DataField="T_Name" />
                                    <asp:BoundField HeaderText="T_MobileNo" DataField="T_MobileNo" />
                                    <asp:BoundField HeaderText="Role" DataField="Role" />
                                    <asp:BoundField HeaderText="Remark" DataField="Remark" />
                                    <asp:BoundField HeaderText="AbsentOption" DataField="AbsentOption" />
                                    <asp:BoundField HeaderText="Time" DataField="Time" />
                                    <asp:BoundField HeaderText="date" DataField="date" />
                                    <asp:BoundField HeaderText="SchoolCode" DataField="SchoolCode" />
                                    <asp:BoundField HeaderText="CurrentDate" DataField="CurrentDate" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
