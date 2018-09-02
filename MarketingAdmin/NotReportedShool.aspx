<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="NotReportedShool.aspx.cs" Inherits="MarketingAdmin_NotReportedShool"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="outsidediv">
        <div class="headingdiv">
            <div align="center" class="style1" style="background-color: #87CEFA;">
                <span id="Span2" class="spanTitle" runat="server">Not Reported School</span>
            </div>
        </div>
        <hr />
        <table>
           
            <tr>
                <td>
                    Select Date:
                </td>
                <td>
                    <asp:TextBox ID="txtDateSP" runat="server" CssClass="txtcss" Width="130px" Height="20px"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="yyyy-MM-dd"
                        TargetControlID="txtDateSP">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <%--<tr>
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
            </tr>--%>
            <tr>
                <td align="left">
                    Enter SchoolCode number:
                </td>
                <td align="left">
                    <asp:TextBox ID="txtSchoolCodeSP" runat="server" Width="130px" Height="20px"></asp:TextBox>
                  <%--  <asp:DropDownList ID="DDLSchoolCodeSP" runat="server" AutoPostBack="true" Width="129px">
                    </asp:DropDownList>--%>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
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
                            <asp:BoundField HeaderText="School Code" DataField="schoolcode" />
                            <%--<asp:BoundField HeaderText="HM MobileNO" DataField="HMNO" />--%>
                            <asp:BoundField HeaderText="Staff Present Report" DataField="SPR" />
                            <asp:BoundField HeaderText="Staff Absent Report" DataField="SAR" />
                           <asp:BoundField HeaderText="Class Report" DataField="ClassRpt" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    Total Not Reported School:&nbsp;<asp:Label ID="lblnotreportedcount" runat="server" Text=""></asp:Label><br />
                    Total Not Reported Staff :&nbsp;<asp:Label ID="lblnotreportedstaff" runat="server" Text=""></asp:Label><br />
                    Total Not Reported Class :&nbsp;<asp:Label ID="lblnotreportedclass" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
