<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="MyctProjects.aspx.cs" Inherits="MarketingAdmin_MyctProjects" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="outsidediv">
        <div class="headingdiv">
            <div align="center" class="style1" style="background-color: #87CEFA;">
                <span id="Span2" class="spanTitle" runat="server">MyCT All APP Details Report</span>
            </div>
        </div>
        <hr />
        <div style="width: 100%; margin-left: 5%;">
            <div style="width: 25%; text-align: center; float: left; background-color: #BFF7EE;
                border: 2px outset;">
                <asp:LinkButton ID="lnkRegUser" runat="server" OnClick="lnkRegUser_Click"> WebBased Projects
                </asp:LinkButton>
            </div>
            <div style="width: 25%; text-align: center; float: left; background-color: #BFF7EE;
                border: 2px outset;">
                <asp:LinkButton ID="lnkApp" runat="server" OnClick="lnkApp_Click"> AppWise Projects
                </asp:LinkButton>
            </div>
            <div style="width: 25%; text-align: center; float: left; background-color: #BFF7EE;
                border: 2px outset;">
                <asp:LinkButton ID="lnkBack" runat="server" OnClick="lnkBack_Click"> BackOffice Projects
                </asp:LinkButton>
            </div>
        </div>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
            <br /><br />
                <div align="center" style="background-color:Lime">
                    <span id="Span3" class="spanTitle" runat="server">WebBased Projects </span>
                </div>
                <%--<table>
                    <tr>
                        <td colspan="4" align="center" class="style1" style="width: 100px;">--%>
                            <%-- <span id="Span4" class="spanTitle" runat="server">All Registered Users 
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <%--<td><asp:LinkButton ID="lnkbtncount" runat="server" Text="How Many User Registered "</td>--%>
                    <%--</tr>
                    <tr>
                        <td align="left">
                            Enter Project Name:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPName" runat="server" Width="130px" Height="20px"></asp:TextBox>
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
                    <td><asp:LinkButton ID="lnksend" runat="server" Text="Report" OnClick="lnksend_Click"></asp:LinkButton></td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Font-Bold="true" ForeColor="Maroon" Text="Submit"
                                Width="129px" OnClick="btnSubmit_Click" />
                        </td>
                    </tr>
                </table>--%>
                <div>
                    <asp:Label ID="lblcount" runat="server"></asp:Label>
                </div>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" CssClass="gridview"
                                >
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="ProjectName" DataField="ProjectName" />
                                    <asp:BoundField HeaderText="ProjectType" DataField="ProjectType" />
                                    <%--<asp:BoundField HeaderText="firstName" DataField="firstName" />--%>
                                   
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
             <br /><br />
                <div align="center" style="background-color:Lime">
                    <span id="Span1" class="spanTitle" runat="server">AppBased Projects </span>
                </div>
                <%--<table>
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
                    </tr>--%>
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
                    </tr>
               <%--     <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit2" runat="server" Font-Bold="true" ForeColor="Maroon" Text="Submit"
                                Width="129px" OnClick="btnSubmit2_Click" />
                        </td>
                    </tr>
                </table>--%>
               <div>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </div>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gvItemApp" runat="server" AutoGenerateColumns="false" CssClass="gridview"
                                >
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="ProjectName" DataField="ProjectName" />
                                    <asp:BoundField HeaderText="ProjectType" DataField="ProjectType" />
                                    <%--<asp:BoundField HeaderText="firstName" DataField="firstName" />--%>
                                   
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:View>
             <asp:View ID="View3" runat="server">
             <br /><br />
                <div align="center" style="background-color:Lime">
                    <span id="Span4" class="spanTitle" runat="server">BackOffice Projects </span>
                </div>
                <%--<table>
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
                    </tr>--%>
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
                    </tr>
               <%--     <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit2" runat="server" Font-Bold="true" ForeColor="Maroon" Text="Submit"
                                Width="129px" OnClick="btnSubmit2_Click" />
                        </td>
                    </tr>
                </table>--%>
               <div>
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </div>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gvItemBack" runat="server" AutoGenerateColumns="false" CssClass="gridview"
                                >
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="ProjectName" DataField="ProjectName" />
                                    <asp:BoundField HeaderText="ProjectType" DataField="ProjectType" />
                                    <%--<asp:BoundField HeaderText="firstName" DataField="firstName" />--%>
                                   
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </div>



</asp:Content>

