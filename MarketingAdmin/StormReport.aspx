<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="StormReport.aspx.cs" Inherits="MarketingAdmin_StormReport" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="outsidediv">
        <div class="headingdiv">
            <div align="center" class="style1" style="background-color: #87CEFA;">
                <span id="Span2" class="spanTitle" runat="server">RoleWise Report</span>
            </div>
            <hr />
            <div style="width: 100%; margin-left: 5%;">
                <div style="width: 22%; text-align: center; float: left; background-color: #BFF7EE;
                    border: 2px outset;">
                    <asp:LinkButton ID="lnkEO" runat="server" OnClick="lnkEO_Click">EO Report 
                    </asp:LinkButton>
                </div>
                <div style="width: 22%; text-align: center; float: left; background-color: #BFF7EE;
                    border: 2px outset;">
                    <asp:LinkButton ID="lnkBEO" runat="server" OnClick="lnkBEO_Click">BEO Report 
                    </asp:LinkButton>
                </div>
                <div style="width: 22%; text-align: center; float: left; background-color: #BFF7EE;
                    border: 2px outset;">
                    <asp:LinkButton ID="lnkExT" runat="server" OnClick="lnkExT_Click">Extension Officer</asp:LinkButton>
                </div>
                <div style="width: 25%; text-align: center; float: left; background-color: #BFF7EE;
                    border: 2px outset;">
                    <asp:LinkButton ID="lnkCH" runat="server" OnClick="lnkCH_Click">Cluster Head Report</asp:LinkButton>
                </div>
            </div>
            <asp:MultiView ID="MultiView1" runat="server" OnActiveViewChanged="MultiView1_ActiveViewChanged">
                <asp:View ID="View1" runat="server">
                    <table>
                    <tr>
                            <td colspan="4" align="center" class="style1" style="width: 100px;">
                                <span id="Span3" class="spanTitle" runat="server">EO Report </span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Select Date:
                                </td>
                                <td align="left">
                                <asp:TextBox ID="txtDate" runat="server" OnTextChanged="txtDate_TextChanged" CssClass="txtcss"
                                    AutoPostBack="true"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="yyyy-MM-dd"
                                    TargetControlID="txtDate">
                                </asp:CalendarExtender>
                                <asp:Button ID="btnSubmit" runat="server" text="Submit" CssClass="txtcss" OnClick="btnSubmit_Click"/>
                               
                            </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr>
                        <td align="left"></td>
                        <td align="left"> <asp:Button ID="btnExportToExcel" runat="server" Font-Bold="true" ForeColor="Maroon"
                                    Text="Export to excel" CssClass="txtcss" OnClick="btnExportToExcel_Click" /></td>
                        </tr>
                        </table>
                        <table>
                        <tr>
                        
                            <td >
                                <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" CssClass="gridview"
                                    FooterStyle-HorizontalAlign="Center" ShowFooter="true" OnRowDataBound="gvItem_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="TALUKA" DataField="CityName" />
                                        <%--<asp:BoundField HeaderText="ToatalStaff" DataField="ToatalStaff" />--%>
                                        <asp:TemplateField HeaderText="TOTAL SCHOOLS">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalSchool" runat="server" Text='<%#Eval("TotalSchool") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblAllTotalSchool" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="REPORTED SCHOOLS">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalReportedSchool" runat="server" Text='<%#Eval("TotalReportedSchool") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblAllTotalReportedSchool" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                       
                                        
                                        <asp:TemplateField HeaderText="TOTAL TEACHER">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblToatalStaff" runat="server" Text='<%#Eval("ToatalStaff") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblAllToatalStaff" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                         <asp:TemplateField HeaderText="PRESENT TEACHER">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("TotalPresentStaff") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalAll" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                         <asp:TemplateField HeaderText="ABSENT TEACHER">
                                            <ItemTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblTotalAbsentStaff" runat="server" Text='<%#Eval("TotalAbsentStaff") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllTotalAbsentStaff" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                         <asp:TemplateField HeaderText="ON LEAVE">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblOnCLStaff" runat="server" Text='<%#Eval("OnCLStaff") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllOnCLStaff" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                         <asp:TemplateField HeaderText="ON TOUR">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblOutdoorOnOfficeleave" runat="server" Text='<%#Eval("OutdoorOnOfficeleave") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllOutdoorOnOfficeleave" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                                                              
                                         <asp:TemplateField HeaderText="LATE TEACHER">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblLateAttendance" runat="server" Text='<%#Eval("LateAttendance") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllLateAttendance" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                         <asp:TemplateField HeaderText="NONREPORTED STAFF">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblNotReportedStaff" runat="server" Text='<%#Eval("NotReportedStaff") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblAllNotReportedStaff" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="TOTAL STUDENT">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalStud" runat="server" Text='<%#Eval("TotalStudent") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalAllStud" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                         <asp:TemplateField HeaderText="PRESENT STUDENT">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalPStudCount" runat="server" Text='<%#Eval("TotalPresentStudCount") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalpAllStudC" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="ABSENT STUDENT">
                                            <ItemTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblTotalAbsentStudent" runat="server" Text='<%#Eval("TotalAbsentStudent") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblAllTotalAbsentStudent" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <%--<asp:BoundField HeaderText="TotalPresentStaff" DataField="TotalPresentStaff" />--%>
                                       
                                        
                                        
                                        <%--<asp:BoundField HeaderText="TotalPresentStudCount" DataField="TotalPresentStudCount" />--%>
                                       
                                        <%--<asp:BoundField HeaderText="TotalAbsentStudCount" DataField="TotalAbsentStudCount" />--%>
                                        
                                        <asp:TemplateField HeaderText="HALF DAY LEAVE">
                                            <ItemTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblhalfDayleave" runat="server" Text='<%#Eval("halfDayleave") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblAllhalfDayleave" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EARNED LEAVE">
                                            <ItemTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblearnedleave" runat="server" Text='<%#Eval("earnedleave") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblAllearnedleave" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MATERNITY LEAVE">
                                            <ItemTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblmaternityleave" runat="server" Text='<%#Eval("maternityleave") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblAllmaternityleave" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="ON MEDICAL LEAVE">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblOnmedicalLeave" runat="server" Text='<%#Eval("OnmedicalLeave") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllOnmedicalLeave" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="ON TRAINING">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblOntraining" runat="server" Text='<%#Eval("Ontraining") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllOntraining" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ABSENT WITHOUT NOTICE">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblAbsentWithoutNotice" runat="server" Text='<%#Eval("AbsentWithoutNotice") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllAbsentWithoutNotice" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                       
                                    </Columns>
                                    <FooterStyle BackColor="#cccccc" Font-Bold="True" ForeColor="Black" HorizontalAlign="Left" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <table>
                         <tr>
                            <td colspan="4" align="center" class="style1" style="width: 100px;">
                                <span id="Span5" class="spanTitle" runat="server">BEO Report </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Select Date:
                                <asp:TextBox ID="txtDateBEO" runat="server" OnTextChanged="txtDateBEO_TextChanged"
                                    CssClass="txtcss" AutoPostBack="true"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="yyyy-MM-dd"
                                    TargetControlID="txtDateBEO">
                                </asp:CalendarExtender>
                                <asp:Button ID="btnExportToExcelBEO" runat="server" Font-Bold="true" ForeColor="Maroon"
                                    Text="Export to excel" Width="129px" OnClick="btnExportToExcelBEO_Click" />
                            </td>
                        </tr>
                   
                        <tr>
                            <td>
                                <asp:GridView ID="gvItemBEO" runat="server" AutoGenerateColumns="false" CssClass="gridview"
                                    FooterStyle-HorizontalAlign="Center" ShowFooter="true" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="EXTOMobNo" DataField="EXTOMobNo" />
                                        <%--<asp:BoundField HeaderText="ToatalStaff" DataField="ToatalStaff" />--%>
                                        <asp:TemplateField HeaderText="TotalSchool">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalSchool" runat="server" Text='<%#Eval("TotalSchool") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblAllTotalSchool" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TotalReportedSchool">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalReportedSchool" runat="server" Text='<%#Eval("TotalReportedSchool") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblAllTotalReportedSchool" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ToatalStaff">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblToatalStaff" runat="server" Text='<%#Eval("ToatalStaff") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblAllToatalStaff" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField HeaderText="TotalPresentStaff" DataField="TotalPresentStaff" />--%>
                                        <asp:TemplateField HeaderText="TotalPresentStaff">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("TotalPresentStaff") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalAll" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TotalAbsentStaff">
                                            <ItemTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblTotalAbsentStaff" runat="server" Text='<%#Eval("TotalAbsentStaff") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllTotalAbsentStaff" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TotalStudent">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalStud" runat="server" Text='<%#Eval("TotalStudent") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalAllStud" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField HeaderText="TotalPresentStudCount" DataField="TotalPresentStudCount" />--%>
                                        <asp:TemplateField HeaderText="TotalPresentStudCount">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalPStudCount" runat="server" Text='<%#Eval("TotalPresentStudCount") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalpAllStudC" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField HeaderText="TotalAbsentStudCount" DataField="TotalAbsentStudCount" />--%>
                                        <asp:TemplateField HeaderText="TotalAbsentStudCount">
                                            <ItemTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblTotalAbsentStudent" runat="server" Text='<%#Eval("TotalAbsentStudent") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblAllTotalAbsentStudent" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="OnCLStaff">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblOnCLStaff" runat="server" Text='<%#Eval("OnCLStaff") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllOnCLStaff" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="OnmedicalLeave">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblOnmedicalLeave" runat="server" Text='<%#Eval("OnmedicalLeave") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllOnmedicalLeave" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="OutdoorOnOfficeleave">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblOutdoorOnOfficeleave" runat="server" Text='<%#Eval("OutdoorOnOfficeleave") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllOutdoorOnOfficeleave" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ontraining">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblOntraining" runat="server" Text='<%#Eval("Ontraining") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllOntraining" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="AbsentWithoutNotice">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblAbsentWithoutNotice" runat="server" Text='<%#Eval("AbsentWithoutNotice") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllAbsentWithoutNotice" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="LateAttendance">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblLateAttendance" runat="server" Text='<%#Eval("LateAttendance") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllLateAttendance" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#cccccc" Font-Bold="True" ForeColor="Black" HorizontalAlign="Left" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <table>
                    <tr>
                            <td colspan="4" align="center" class="style1" style="width: 100px;">
                                <span id="Span1" class="spanTitle" runat="server">Extention Officer Report </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Select Date:
                                <asp:TextBox ID="txtDateEXTO" runat="server" OnTextChanged="txtDateEXTO_TextChanged"
                                    CssClass="txtcss" AutoPostBack="true"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="yyyy-MM-dd"
                                    TargetControlID="txtDateEXTO">
                                </asp:CalendarExtender>
                                <asp:Button ID="btnExportToExcelEXTO" runat="server" Font-Bold="true" ForeColor="Maroon"
                                    Text="Export to excel" Width="129px" OnClick="btnExportToExcelEXTO_Click" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gvItemEXTO" runat="server" AutoGenerateColumns="false" FooterStyle-HorizontalAlign="Center"
                                    ShowFooter="true" OnRowDataBound="gvItemEXTO_RowDataBound" CssClass="gridview">
                                     <Columns>
                                        <asp:TemplateField HeaderText="Sr.No">
                                            <ItemTemplate>
                                            <%#Container.DataItemIndex +1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="CHMobNo" DataField="CHMobNo" />
                                        <%--<asp:BoundField HeaderText="ToatalStaff" DataField="ToatalStaff" />--%>
                                        <asp:TemplateField HeaderText="ToatalStaff">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblToatalStaff" runat="server" Text='<%#Eval("ToatalStaff") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblAllToatalStaff" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField HeaderText="TotalPresentStaff" DataField="TotalPresentStaff" />--%>
                                        <asp:TemplateField HeaderText="TotalPresentStaff">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("TotalPresentStaff") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalAll" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TotalAbsentStaff">
                                            <ItemTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblTotalAbsentStaff" runat="server" Text='<%#Eval("TotalAbsentStaff") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllTotalAbsentStaff" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TotalStudent">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalStud" runat="server" Text='<%#Eval("TotalStudent") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalAllStud" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField HeaderText="TotalPresentStudCount" DataField="TotalPresentStudCount" />--%>
                                        <asp:TemplateField HeaderText="TotalPresentStudCount">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalPStudCount" runat="server" Text='<%#Eval("TotalPresentStudCount") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalpAllStudC" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="TotalAbsentStudCount">
                                            <ItemTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblTotalAbsentStudent" runat="server" Text='<%#Eval("TotalAbsentStudent") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblAllTotalAbsentStudent" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="OnCLStaff">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblOnCLStaff" runat="server" Text='<%#Eval("OnCLStaff") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllOnCLStaff" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="OnmedicalLeave">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblOnmedicalLeave" runat="server" Text='<%#Eval("OnmedicalLeave") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllOnmedicalLeave" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="OutdoorOnOfficeleave">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblOutdoorOnOfficeleave" runat="server" Text='<%#Eval("OutdoorOnOfficeleave") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllOutdoorOnOfficeleave" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ontraining">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblOntraining" runat="server" Text='<%#Eval("Ontraining") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllOntraining" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="AbsentWithoutNotice">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblAbsentWithoutNotice" runat="server" Text='<%#Eval("AbsentWithoutNotice") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllAbsentWithoutNotice" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="LateAttendance">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblLateAttendance" runat="server" Text='<%#Eval("LateAttendance") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllLateAttendance" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#cccccc" Font-Bold="True" ForeColor="Black" HorizontalAlign="Left" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View4" runat="server">
                    <table>
                    <tr>
                            <td colspan="4" align="center" class="style1" style="width: 100px;">
                                <span id="Span4" class="spanTitle" runat="server">Cluster Head Report </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Select Date:
                                <asp:TextBox ID="txtDateCH" runat="server" OnTextChanged="txtDateCH_TextChanged"
                                    CssClass="txtcss" AutoPostBack="true"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;
                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="yyyy-MM-dd"
                                    TargetControlID="txtDateCH">
                                </asp:CalendarExtender>
                                <asp:Button ID="btnExportToExcelCH" runat="server" Font-Bold="true" ForeColor="Maroon"
                                    Text="Export to excel" Width="129px" OnClick="btnExportToExcelCH_Click" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gvItemCH" runat="server" AutoGenerateColumns="false" FooterStyle-HorizontalAlign="Center"
                                    ShowFooter="true" OnRowDataBound="gvItemCH_RowDataBound" CssClass="gridview">
                                     <Columns>
                                        <asp:TemplateField HeaderText="Sr.No">
                                            <ItemTemplate>
                                            <%#Container.DataItemIndex +1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Taluka" DataField="CityName" />
                                        <asp:BoundField HeaderText="HMMobNo" DataField="HMMobNo" />
                                        <asp:TemplateField HeaderText="ToatalStaff">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblToatalStaff" runat="server" Text='<%#Eval("ToatalStaff") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblAllToatalStaff" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField HeaderText="TotalPresentStaff" DataField="TotalPresentStaff" />--%>
                                        <asp:TemplateField HeaderText="TotalPresentStaff">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("TotalPresentStaff") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalAll" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TotalAbsentStaff">
                                            <ItemTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblTotalAbsentStaff" runat="server" Text='<%#Eval("TotalAbsentStaff") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllTotalAbsentStaff" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TotalStudent">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalStud" runat="server" Text='<%#Eval("TotalStudent") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalAllStud" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField HeaderText="TotalPresentStudCount" DataField="TotalPresentStudCount" />--%>
                                        <asp:TemplateField HeaderText="TotalPresentStudCount">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalPStudCount" runat="server" Text='<%#Eval("TotalPresentStudCount") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblTotalpAllStudC" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="TotalAbsentStudCount">
                                            <ItemTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblTotalAbsentStudent" runat="server" Text='<%#Eval("TotalAbsentStudent") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblAllTotalAbsentStudent" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="OnCLStaff">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblOnCLStaff" runat="server" Text='<%#Eval("OnCLStaff") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllOnCLStaff" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="OnmedicalLeave">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblOnmedicalLeave" runat="server" Text='<%#Eval("OnmedicalLeave") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllOnmedicalLeave" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="OutdoorOnOfficeleave">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblOutdoorOnOfficeleave" runat="server" Text='<%#Eval("OutdoorOnOfficeleave") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllOutdoorOnOfficeleave" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ontraining">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblOntraining" runat="server" Text='<%#Eval("Ontraining") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllOntraining" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="AbsentWithoutNotice">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblAbsentWithoutNotice" runat="server" Text='<%#Eval("AbsentWithoutNotice") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllAbsentWithoutNotice" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="LateAttendance">
                                            <ItemTemplate>
                                                <div style="text-align: right;">
                                                    <asp:Label ID="lblLateAttendance" runat="server" Text='<%#Eval("LateAttendance") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div style="text-align: right">
                                                    <asp:Label ID="lblAllLateAttendance" runat="server"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#cccccc" Font-Bold="True" ForeColor="Black" HorizontalAlign="Left" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>
