<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="HMPersonalPresentyAbsenty.aspx.cs" Inherits="MarketingAdmin_HMPersonalPresentyAbsenty"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="outsidediv">
        <div class="headingdiv">
            <div align="center" class="style1" style="background-color: #87CEFA;">
                <span id="Span2" class="spanTitle" runat="server">School Code Wise Report</span>
            </div>
            <hr />
            <br />
            <div style="width: 100%; margin-left: 5%;">
                <div style="width: 45%; text-align: center; float: left; background-color: #BFF7EE;
                    border: 2px outset;">
                    <asp:LinkButton ID="lnkHMPresenty" runat="server" OnClick="lnkHMPresenty_Click"> Teachers Presenty Report
                    </asp:LinkButton>
                </div>
                <div style="width: 45%; text-align: center; float: left; background-color: #BFF7EE;
                    border: 2px outset;">
                    <asp:LinkButton ID="lnkHMAbsenty" runat="server" OnClick="lnkHMAbsenty_Click"> Teachers Absenty Report
                    </asp:LinkButton>
                </div>
            </div>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <table>
                        <tr>
                            <td align="left">
                                Enter HMMobile Number :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMobileNoP" runat="server" Width="120px" Height="18px"></asp:TextBox>
                                
                            </td>
                        </tr>
                         <tr>
                            <td align="left">
                                Select From Date:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFrmDateP" runat="server" Width="120px" Height="18px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="yyyy-MM-dd"
                                    TargetControlID="txtFrmDateP">
                                </asp:CalendarExtender>
                            </td>
                             <td align="left">
                                To Date:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtToDateP" runat="server" Width="120px" Height="18px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="yyyy-MM-dd"
                                    TargetControlID="txtToDateP">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Font-Bold="true" ForeColor="Maroon" Text="Submit"
                                    Width="129px" OnClick="btnSubmit_Click" EmptyDataText="No Records" ShowHeader="False" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" CssClass="gridview"
                                    EmptyDataText="No Records For This School Code">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Time" DataField="Time" />
                                        <asp:BoundField HeaderText="Date" DataField="Date" />
                                        <%--<asp:BoundField HeaderText="Image" DataField="Image" />--%>
                                        <asp:BoundField HeaderText="T_Name" DataField="T_Name" />
                                        <%--<asp:BoundField HeaderText="TotalReportedSchool" DataField="TotalReportedSchool" />--%>
                                        <asp:BoundField HeaderText="T_MobileNo" DataField="T_MobileNo" />
                                        <asp:BoundField HeaderText="schoolcode" DataField="schoolcode" />
                                        <asp:BoundField HeaderText="role" DataField="role" />
                                        <%-- <asp:BoundField HeaderText="Total" DataField="Classcode" />--%>
                                        <asp:BoundField HeaderText="HM_MobileNo" DataField="HM_MobileNo" />
                                        <asp:BoundField HeaderText="OwnerMobNo" DataField="OwnerMobNo" />
                                        <%--<asp:BoundField HeaderText="CurrrentDate" DataField="CurrrentDate" />--%>
                                       
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <table>
                        <tr>
                            <td align="left">
                              Enter HMMobile Number :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMobileNoA" runat="server" Width="120px" Height="18px"></asp:TextBox>
                                
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Select From Date:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFrmDateA" runat="server" Width="120px" Height="18px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="yyyy-MM-dd"
                                    TargetControlID="txtFrmDateA">
                                </asp:CalendarExtender>
                            </td>
                             <td align="left">
                                To Date:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtToDateA" runat="server" Width="120px" Height="18px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="yyyy-MM-dd"
                                    TargetControlID="txtToDateA">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnSubmitT" runat="server" Font-Bold="true" ForeColor="Maroon" Text="Submit"
                                    Width="129px" OnClick="btnSubmitT_Click" EmptyDataText="No Records" ShowHeader="False" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gvItemT" runat="server" AutoGenerateColumns="false" CssClass="gridview"
                                    EmptyDataText="No Records For This School Code">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Time" DataField="Time" />
                                        <asp:BoundField HeaderText="date" DataField="date" />
                                        <%--<asp:BoundField HeaderText="Image" DataField="Image" />--%>
                                        <asp:BoundField HeaderText="T_Name" DataField="T_Name" />
                                        <%--<asp:BoundField HeaderText="TotalReportedSchool" DataField="TotalReportedSchool" />--%>
                                        <asp:BoundField HeaderText="T_MobileNo" DataField="T_MobileNo" />
                                        <asp:BoundField HeaderText="schoolcode" DataField="schoolcode" />
                                        <asp:BoundField HeaderText="role" DataField="role" />
                                        <%-- <asp:BoundField HeaderText="Total" DataField="Classcode" />--%>
                                        <%--<asp:BoundField HeaderText="HM_MobileNo" DataField="HM_MobileNo" />--%>
                                        <%--<asp:BoundField HeaderText="OwnerMobNo" DataField="OwnerMobNo" />--%>
                                        <%--<asp:BoundField HeaderText="CurrrentDate" DataField="CurrrentDate" />--%>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>
