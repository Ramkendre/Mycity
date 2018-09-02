<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="MyctReport.aspx.cs" Inherits="MarketingAdmin_MyctReport" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="outsidediv">
        <div class="headingdiv">
            <div align="center" class="style1" style="background-color: #87CEFA;">
                <span id="Span2" class="spanTitle" runat="server">MyCT All APP Details Report</span>
            </div>
        </div>
        <hr />
        <div style="width: 100%; margin-left: 5%;">
            <div style="width: 45%; text-align: center; float: left; background-color: #BFF7EE;
                border: 2px outset;">
                <asp:LinkButton ID="lnkRegUser" runat="server" OnClick="lnkRegUser_Click"> All Registered User According to AppName
                </asp:LinkButton>
            </div>
            <div style="width: 45%; text-align: center; float: left; background-color: #BFF7EE;
                border: 2px outset;">
                <asp:LinkButton ID="lnkStaffAbsenty" runat="server" OnClick="lnkStaffAbsenty_Click"> ReferenceNo Wise Report
                </asp:LinkButton>
            </div>
            <%--<div style="width: 45%; text-align: center; float: left; background-color: #BFF7EE;
                border: 2px outset;">
                <asp:LinkButton ID="lnkImage" runat="server" OnClick="lnkImage_Click"> Teacher Image Report
                </asp:LinkButton>
            </div>--%>
        </div>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
            <br /><br />
                <div align="center" style="background-color:Lime">
                    <span id="Span3" class="spanTitle" runat="server">All Registered Users </span>
                </div>
                <table>
                    <tr>
                        <td colspan="4" align="center" class="style1" style="width: 100px;">
                            <%-- <span id="Span4" class="spanTitle" runat="server">All Registered Users 
                            </span>--%>
                        </td>
                    </tr>
                    <tr>
                        <%--<td><asp:LinkButton ID="lnkbtncount" runat="server" Text="How Many User Registered "</td>--%>
                    </tr>
                    <tr>
                        <td align="left">
                            Enter Project Name:
                        </td>
                        <td align="left">
                           
                             <asp:DropDownList ID="ddlAllProjectName" runat="server" CssClass="ddlcss">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="EZEEMARKETING">EzeeMarketing</asp:ListItem>
                                <asp:ListItem Value="CLASSAPP">Ezee Class</asp:ListItem>
                                <asp:ListItem Value="MYPANCHAYAT">My Panchayat</asp:ListItem>
                                <asp:ListItem Value="MYPALIKA">My Palika</asp:ListItem>
                                <asp:ListItem Value="MYCTAPP">MyCity</asp:ListItem>  
                                <asp:ListItem Value="BACHATGAT">Bachat Gat</asp:ListItem>
                                <asp:ListItem Value="MEMBERAPP">Member App</asp:ListItem>
                                <asp:ListItem Value="EZEESTORM">Ezee Strom</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Select Date:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDate" runat="server" CssClass="txtcss"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="yyyy-MM-dd"
                                TargetControlID="txtDate">
                            </asp:CalendarExtender>
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
                <div>
                    <asp:Label ID="lblcount" runat="server"></asp:Label>
                </div>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" CssClass="gridview"
                                AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="keyword" DataField="keyword" />
                                   <%-- <asp:BoundField HeaderText="strDevId" DataField="strDevId" />--%>
                                    <asp:BoundField HeaderText="firstName" DataField="firstName" />
                                    <asp:BoundField HeaderText="lastName" DataField="lastName" />
                                    <asp:BoundField HeaderText="firmName" DataField="firmName" />
                                    <asp:BoundField HeaderText="mobileNo" DataField="mobileNo" />
                                    <asp:BoundField HeaderText="address" DataField="address" />
                                    <asp:BoundField HeaderText="eMailId" DataField="eMailId" />
                                    <%--<asp:BoundField HeaderText="typeOfUse_Id" DataField="typeOfUse_Id" />--%>
                                    <asp:BoundField HeaderText="EntryDate" DataField="EntryDate" DataFormatString="{0:yyyy-MM-dd}"/>
                                    <asp:BoundField HeaderText="RefMobileNo" DataField="RefMobileNo" />
                                    <%--<asp:BoundField HeaderText="State" DataField="State" />--%>
                                    <%--<asp:BoundField HeaderText="District" DataField="District" />--%>
                                    <asp:BoundField HeaderText="District" DataField="DistrictName" />
                                    <%--<asp:BoundField HeaderText="usertype" DataField="usertype" />--%>
                                    <asp:BoundField HeaderText="Qualification" DataField="Qualification" />
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
                            <span id="Span1" class="spanTitle" runat="server">All Registered User According to RefMobNo</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Enter RefmobileNo Name:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtRefMobileNo" runat="server" Width="130px" Height="20px"></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                        <td>
                            Select Project Name:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProjectName" runat="server" CssClass="ddlcss">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="EZEEMARKETING">EzeeMarketing</asp:ListItem>
                                <asp:ListItem Value="CLASSAPP">Ezee Class</asp:ListItem>
                                <asp:ListItem Value="MYPANCHAYAT">My Panchayat</asp:ListItem>
                                <asp:ListItem Value="MYPALIKA">My Palika</asp:ListItem>
                                <asp:ListItem Value="MYCTAPP">MyCity</asp:ListItem>  
                                <asp:ListItem Value="BACHATGAT">Bachat Gat</asp:ListItem>
                                <asp:ListItem Value="MEMBERAPP">Member App</asp:ListItem>
                                <asp:ListItem Value="EZEESTORM">Ezee Strom</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <%-- <tr>
                        <td>
                            Select Date:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDate" runat="server" CssClass="txtcss"></asp:TextBox>
                            
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="yyyy-MM-dd"
                                TargetControlID="txtDate">
                            </asp:CalendarExtender>
                        </td>
                    </tr>--%>
                     <tr style="width:7px">
                        <td>
                        </td>
                        <td>
                           
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit2" runat="server" Font-Bold="true" ForeColor="Maroon" Text="Submit"
                                Width="129px" OnClick="btnSubmit2_Click" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gvItem2" runat="server" AutoGenerateColumns="false" CssClass="gridview">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Project" DataField="keyword" />
                                   <%-- <asp:BoundField HeaderText="strDevId" DataField="strDevId" />--%>
                                    <asp:BoundField HeaderText="firstName" DataField="firstName" />
                                    <asp:BoundField HeaderText="lastName" DataField="lastName" />
                                    <asp:BoundField HeaderText="firmName" DataField="firmName" />
                                    <asp:BoundField HeaderText="mobileNo" DataField="mobileNo" />
                                    <asp:BoundField HeaderText="address" DataField="address" />
                                    <asp:BoundField HeaderText="eMailId" DataField="eMailId" />
                                   <%-- <asp:BoundField HeaderText="typeOfUse_Id" DataField="typeOfUse_Id" />--%>
                                    <asp:BoundField HeaderText="EntryDate" DataField="EntryDate" DataFormatString="{0:dd/MM/yyyy}"/>
                                    <asp:BoundField HeaderText="RefMobileNo" DataField="RefMobileNo" />
                                    <%--<asp:BoundField HeaderText="State" DataField="State" />--%>
                                    <asp:BoundField HeaderText="District" DataField="DistrictName" />
                                    <%--<asp:BoundField HeaderText="usertype" DataField="usertype" />--%>
                                    <asp:BoundField HeaderText="Qualification" DataField="Qualification" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
