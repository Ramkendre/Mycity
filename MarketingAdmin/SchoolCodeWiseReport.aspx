<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="SchoolCodeWiseReport.aspx.cs" Inherits="MarketingAdmin_SchoolCodeWiseReport"
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
                    <asp:LinkButton ID="lnkStaffAttend" runat="server" OnClick="lnkSchoolCodeWiseReport_Click"> SchoolCode Wise Report
                    </asp:LinkButton>
                </div>
                <div style="width: 45%; text-align: center; float: left; background-color: #BFF7EE;
                    border: 2px outset;">
                    <asp:LinkButton ID="lnkStaffAbsenty" runat="server" OnClick="lnkSchoolCodeTimeWiseReport_Click"> SchoolCode Time Wise Report
                    </asp:LinkButton>
                </div>
            </div>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <table>
                        <tr>
                            <td align="left">
                                Select Date:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDate" runat="server" Width="120px" Height="18px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="yyyy-MM-dd"
                                    TargetControlID="txtDate">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Enter SchoolCode number To search :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSchoolCode" runat="server" Width="120px" Height="18px" OnTextChanged="txtSchoolCode_TextChanged"
                                    AutoPostBack="true"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtSchoolCode"
                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="11" CompletionInterval="100"
                                    ServiceMethod="SchoolCode">
                                </asp:AutoCompleteExtender>
                                <asp:Button ID="btnSerch" runat="server" Font-Bold="true" ForeColor="Maroon" Text="Search"
                                    Width="129px" OnClick="btnSerch_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Enter SchoolCode:
                            </td>
                            <td align="left">
                                <%--<asp:TextBox ID="txtSchoolCode" runat="server" Width="130px" Height="20px"></asp:TextBox>--%>
                                <asp:DropDownList ID="DDLSchoolCode" runat="server" AutoPostBack="true" Width="129px">
                                </asp:DropDownList>
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
                                        <asp:BoundField HeaderText="School Name" DataField="CompanyName" />
                                        <asp:BoundField HeaderText="Class Name" DataField="Name" />
                                        <asp:BoundField HeaderText="Division" DataField="Division" />
                                        <asp:BoundField HeaderText="TotalBoys" DataField="TotalBoys" />
                                        <%--<asp:BoundField HeaderText="TotalReportedSchool" DataField="TotalReportedSchool" />--%>
                                        <asp:BoundField HeaderText="TotalGirls" DataField="TotalGirls" />
                                        <asp:BoundField HeaderText="PresentBoys" DataField="PresentBoys" />
                                        <asp:BoundField HeaderText="PresentGirls" DataField="PresentGirls" />
                                        <%-- <asp:BoundField HeaderText="Total" DataField="Classcode" />--%>
                                        <asp:BoundField HeaderText="AbsentBoys" DataField="AbsentBoys" />
                                        <asp:BoundField HeaderText="AbsentGirls" DataField="AbsentGirls" />
                                        <asp:BoundField HeaderText="Date" DataField="Date" />
                                        <asp:BoundField HeaderText="Time" DataField="Time" />
                                        <asp:BoundField HeaderText="TeacherMobNo" DataField="TeacherMobNo" />
                                        <asp:BoundField HeaderText="TotalStudent" DataField="TotalStudent" />
                                        <asp:BoundField HeaderText="TotalPresentStudent" DataField="TotalPresentStudent" />
                                        <asp:BoundField HeaderText="CurrrentDate" DataField="CurrrentDate" />
                                        <asp:BoundField HeaderText="HM_Mobileno" DataField="HM_Mobileno" />
                                        <asp:BoundField HeaderText="OwnerMobileNo" DataField="OwnerMobileNo" />
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
                                Select Date:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDateT" runat="server" Width="100px" Height="18px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="yyyy-MM-dd"
                                    TargetControlID="txtDateT">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Time
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtTime" runat="server" Width="100px" Height="18px"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MEEE" TargetControlID="txtTime" Mask="99:99:99" runat="server"
                                    MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                    AcceptAMPM="true" MaskType="Time">
                                </asp:MaskedEditExtender>
                                <%--<em style="font-style: italic; color: rgb(102, 102, 102); font-family: Tahoma, Arial, sans-serif;
                                    font-size: 12px; font-variant: normal; font-weight: normal; letter-spacing: normal;
                                    line-height: 18px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none;
                                    white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto;
                                    -webkit-text-stroke-width: 0px;"><span style="font-size: 8pt;">Tip: Type &#39;A&#39;
                                        or &#39;P&#39;  AM/PM</span></em>--%>
                            </td>
                           
                            <td align="left">
                                Time
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtTime2" runat="server" Width="100px" Height="18px"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" TargetControlID="txtTime2" Mask="99:99:99" runat="server"
                                    MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                    AcceptAMPM="true" MaskType="Time">
                                </asp:MaskedEditExtender>
                               <%-- <em style="font-style: italic; color: rgb(102, 102, 102); font-family: Tahoma, Arial, sans-serif;
                                    font-size: 12px; font-variant: normal; font-weight: normal; letter-spacing: normal;
                                    line-height: 18px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none;
                                    white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto;
                                    -webkit-text-stroke-width: 0px;"><span style="font-size: 8pt;">Tip: Type &#39;A&#39;
                                        or &#39;P&#39;  AM/PM</span></em>--%>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Enter SchoolCode number To search :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSCode" runat="server" Width="120px" Height="18px" OnTextChanged="txtSchoolCode_TextChanged"
                                    AutoPostBack="true"></asp:TextBox>
                                <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtSCode"
                                    MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="11" CompletionInterval="100"
                                    ServiceMethod="SchoolCodeT">
                                </asp:AutoCompleteExtender>
                                <asp:Button ID="btnSearchT" runat="server" Font-Bold="true" ForeColor="Maroon" Text="Search"
                                    Width="129px" OnClick="btnSearchT_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Select SchoolCode:
                            </td>
                            <td align="left">
                                <%--<asp:TextBox ID="txtSchoolCode" runat="server" Width="130px" Height="20px"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddlSCode" runat="server" AutoPostBack="true" Width="129px">
                                </asp:DropDownList>
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
                                        <asp:BoundField HeaderText="School Name" DataField="CompanyName" />
                                        <asp:BoundField HeaderText="Class Name" DataField="Name" />
                                        <asp:BoundField HeaderText="Division" DataField="Division" />
                                        <asp:BoundField HeaderText="TotalBoys" DataField="TotalBoys" />
                                        <%--<asp:BoundField HeaderText="TotalReportedSchool" DataField="TotalReportedSchool" />--%>
                                        <asp:BoundField HeaderText="TotalGirls" DataField="TotalGirls" />
                                        <asp:BoundField HeaderText="PresentBoys" DataField="PresentBoys" />
                                        <asp:BoundField HeaderText="PresentGirls" DataField="PresentGirls" />
                                        <%-- <asp:BoundField HeaderText="Total" DataField="Classcode" />--%>
                                        <asp:BoundField HeaderText="AbsentBoys" DataField="AbsentBoys" />
                                        <asp:BoundField HeaderText="AbsentGirls" DataField="AbsentGirls" />
                                        <asp:BoundField HeaderText="Date" DataField="Date" />
                                        <asp:BoundField HeaderText="Time" DataField="Time" />
                                        <asp:BoundField HeaderText="TeacherMobNo" DataField="TeacherMobNo" />
                                        <asp:BoundField HeaderText="TotalStudent" DataField="TotalStudent" />
                                        <asp:BoundField HeaderText="TotalPresentStudent" DataField="TotalPresentStudent" />
                                        <asp:BoundField HeaderText="CurrrentDate" DataField="CurrrentDate" />
                                        <asp:BoundField HeaderText="HM_Mobileno" DataField="HM_Mobileno" />
                                        <asp:BoundField HeaderText="OwnerMobileNo" DataField="OwnerMobileNo" />
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
