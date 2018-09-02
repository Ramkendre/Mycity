<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="ShowChildRecord.aspx.cs" Inherits="MarketingAdmin_ShowChildRecord"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="outsidediv">
        <div class="headingdiv">
            <div align="center" class="style1" style="background-color: #87CEFA;">
                <span id="Span2" class="spanTitle" runat="server">Basic Report</span>
            </div>
            <hr />
            <div style="width: 100%; margin-left: 5%;">
                <div style="width: 40; text-align: center; float: left; background-color: #BFF7EE;
                    border: 2px outset;">
                    <asp:LinkButton ID="lnkAppReg" runat="server" OnClick="lnkAppReg_Click">AppUsers Under Given No 
                    </asp:LinkButton>
                </div>
                <div style="width: 30%; text-align: center; float: left; background-color: #BFF7EE;
                    border: 2px outset;">
                    <asp:LinkButton ID="lnkCTeacher" runat="server" OnClick="lnkCTeacher_Click">ClassTeacher Under HM 
                    </asp:LinkButton>
                </div>
                <div style="width: 30%; text-align: center; float: left; background-color: #BFF7EE;
                    border: 2px outset;">
                    <asp:LinkButton ID="lnkHMTeacher" runat="server" OnClick="lnkHMTeacher_Click">Total Staff Of School</asp:LinkButton>
                </div>
            </div>
            <asp:MultiView ID="MultiView1" runat="server" OnActiveViewChanged="MultiView1_ActiveViewChanged">
                <asp:View ID="View1" runat="server">
                    <table>
                         <tr>
                            <td colspan="4" align="center" class="style1" style="width: 100px;">
                                <span id="Span4" class="spanTitle" runat="server">AppUsers Under Given No(TreeReport Details) </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Enter MobileNo:
                            </td>
                            <td>
                                <asp:TextBox ID="txtMobNo" runat="server"></asp:TextBox>
                                <asp:Button ID="btnSubmit" runat="server" Font-Bold="true" ForeColor="Maroon" Text="Submit"
                                    Width="129px" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" CssClass="gridview" EmptyDataText="No Records">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="first Name" DataField="firstName" />
                                        <asp:BoundField HeaderText="last Name" DataField="lastName" />
                                        <asp:BoundField HeaderText="School Name" DataField="firmName" />
                                        <asp:BoundField HeaderText="Qualification" DataField="Qualification" />
                                        <asp:BoundField HeaderText="mobile No" DataField="mobileNo" />
                                        <asp:BoundField HeaderText="RefMobile No" DataField="RefMobileNo" />
                                        <asp:BoundField HeaderText="Entry Date" DataField="EntryDate" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <table>
                         <tr>
                            <td colspan="4" align="center" class="style1" style="width: 100px;">
                                <span id="Span3" class="spanTitle" runat="server">ClassTeacher Under HM </span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Enter HM MobileNo:
                            </td>
                            <td>
                                <asp:TextBox ID="txtMobNoT" runat="server"></asp:TextBox>
                                <asp:Button ID="btnSubmitT" runat="server" Font-Bold="true" ForeColor="Maroon" Text="Submit"
                                    Width="129px" OnClick="btnSubmitT_Click" />
                            </td>
                        </tr>
                        <%-- <tr>
                            <td>
                                Select Date:
                                <asp:TextBox ID="txtDateT" runat="server" CssClass="txtcss"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="yyyy-MM-dd"
                                    TargetControlID="txtDateT">
                                </asp:CalendarExtender>
                            </td>
                        </tr>--%>
                        <%-- <tr>
                            <td>
                                
                            </td>
                        </tr>--%>
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
                                        <asp:BoundField HeaderText="School Name" DataField="CompanyName" />
                                        <asp:BoundField HeaderText="SessionID" DataField="Session" />
                                        <asp:BoundField HeaderText="SectionID" DataField="Division" />
                                        <asp:BoundField HeaderText="Class " DataField="Name" />
                                        <asp:BoundField HeaderText="T_MobileNo" DataField="T_MobileNo" />
                                        <asp:BoundField HeaderText="T_FullName" DataField="T_FullName" />
                                        <%--<asp:BoundField HeaderText="T_emailID" DataField="T_emailID" />--%>
                                        <asp:BoundField HeaderText="ReferenceMobileNo" DataField="ReferenceMobileNo" />
                                        <asp:BoundField HeaderText="CurrentDate" DataField="CurrentDate" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <table>
                        <tr>
                            <td colspan="4" align="center" class="style1" style="width: 100px;">
                                <span id="Span1" class="spanTitle" runat="server">Total Staff Of School</span>
                            </td>
                        </tr>
                        <%--<tr>
                            <td>
                                Enter SchoolCode:
                            </td>
                            <td>
                                <asp:TextBox ID="txtSchoolCode" runat="server"></asp:TextBox>
                                <asp:Button ID="Button1" runat="server" Font-Bold="true" ForeColor="Maroon" Text="Submit"
                                    Width="129px" OnClick="btnSubmitL_Click" />
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="left">
                                Enter SchoolCode number To search :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSchoolCode" runat="server" Width="129px" Height="15px" OnTextChanged="txtSchoolCode_TextChanged"
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
                            <td>
                            </td>
                            <td>
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
                            <td align="center">
                                <asp:Button ID="btnSubmitL" runat="server" Font-Bold="true" ForeColor="Maroon" Text="Submit"
                                    Width="129px" OnClick="btnSubmitL_Click" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gvItemL" runat="server" AutoGenerateColumns="false" CssClass="gridview">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="CompanyId" DataField="CompanyName" />
                                        <asp:BoundField HeaderText="LoginId" DataField="LoginId" />
                                        <asp:BoundField HeaderText="UserName" DataField="UserName" />
                                        <asp:BoundField HeaderText="ContactNo" DataField="ContactNo" />
                                        <asp:BoundField HeaderText="Address" DataField="Address" />
                                        <asp:BoundField HeaderText="Role" DataField="RoleName" />
                                        <asp:BoundField HeaderText="Active" DataField="a" />
                                      <%--  <asp:BoundField HeaderText="Role" DataField="RoleName" />--%>
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
