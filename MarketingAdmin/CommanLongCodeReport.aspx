<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="CommanLongCodeReport.aspx.cs" Inherits="MarketingAdmin_CommanLongCodeReport" EnableEventValidation="false"%>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <div style="width: 100%;" align="center">
                &nbsp;<table cellpadding="0" cellspacing="0" width="80%" border="1">
                    <tr>
                        <td align="center">
                            <div id="div" style="width: 100%; margin-right: 7px;">
                                <table cellpadding="0" cellspacing="0" border="0" width="70%" class="tables">
                                    <div style="width: 96%">
                                        <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                                            <tr>
                                                <td style="height: 20px;">
                                                    <table style="width: 81%;" class="tables" cellspacing="2" cellpadding="2">
                                                        <tr>
                                                            <td colspan="2" align="center" style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                                <h3 style="color: Green; margin-left: 250px;">Comman LongCode Report</h3>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="width: 628px; text-align: Center;">
                                                                <asp:Label ID="lblSelectTable" runat="server" Font-Bold="true" Font-Names="Arial"
                                                                    Font-Size="11pt" Text="Select Table"></asp:Label>
                                                                <span class="warning1" style="color: Red;">*&nbsp;</span>
                                                            </td>
                                                            <td style="width: 628px; text-align: center">
                                                                <asp:DropDownList ID="ddlMstTable" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMstTable_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <br />
                                                        <tr>
                                                            <td style="width: 628px; text-align: Center;">
                                                                <asp:Label ID="lblslctField" runat="server" Font-Bold="true" Font-Names="Arial"
                                                                    Font-Size="11pt" Text="Select Field"></asp:Label>
                                                                <span class="warning1" style="color: Red;">*&nbsp;</span>
                                                            </td>
                                                            <td style="width: 628px; text-align: center;">
                                                                <asp:Label ID="lblSlctoperator" runat="server" Font-Bold="true" Font-Names="Arial"
                                                                    Font-Size="11pt" Text="Select Operator"></asp:Label>
                                                                <span class="warning1" style="color: Red;">*&nbsp;</span>
                                                            </td>
                                                            <td style="width: 628px; text-align: left;">&nbsp;
                                                               <asp:Label ID="lblSlctFielditem" runat="server" Font-Bold="true" Font-Names="Arial" Visible="true"
                                                                   Font-Size="11pt" Text="Select Field Item"></asp:Label>
                                                                <asp:Label ID="lblSlctDate" runat="server" Font-Bold="true" Visible="false" Font-Names="Arial"
                                                                    Font-Size="11pt" Text="Select Date"></asp:Label>
                                                            </td>
                                                            <td style="width: 628px; text-align: left;">&nbsp;
                                                             
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 276px; text-align: Center;">
                                                                <asp:DropDownList ID="ddlField" runat="server" OnSelectedIndexChanged="ddlField_SelectedIndexChanged" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 34%; text-align: center;">
                                                                <asp:DropDownList ID="ddlOperator" runat="server">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">=</asp:ListItem>
                                                                    <asp:ListItem Value="2">!=</asp:ListItem>
                                                                    <asp:ListItem Value="3">></asp:ListItem>
                                                                    <asp:ListItem Value="4">>=</asp:ListItem>
                                                                    <asp:ListItem Value="5"><</asp:ListItem>
                                                                    <asp:ListItem Value="6">Search By First Letter</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 18%; text-align: right;">
                                                                <asp:DropDownList ID="ddlFieldItem" runat="server" Visible="false" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                                <asp:TextBox ID="txtSrchNumber" runat="server" Visible="false"></asp:TextBox>
                                                                <%--  <asp:TextBox ID="txtDate" runat="server" Visible="false" TextMode="Date"></asp:TextBox><br />--%>

                                                                <asp:TextBox ID="txtDate" runat="server" Width="100"></asp:TextBox>
                                                                <asp:CalendarExtender ID="dtpTransDate_CalendarExtender" runat="server"
                                                                    Enabled="True" Format="d MMM yyyy" TargetControlID="txtDate">
                                                                </asp:CalendarExtender>

                                                                <asp:TextBox ID="txtSrchChar" runat="server" Visible="false"></asp:TextBox>
                                                                <%--  <asp:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy"
                                                                    PopupButtonID="imgFromDate" TargetControlID="txtSrchNumber">
                                                                </asp:CalendarExtender>--%>
                                                                <%-- <img id="imgFromDate" align="middle" alt="ezeesofts &amp; Co." border="0" height="24"
                                                                    src="../resources/images/calendarclick.gif" />--%>
                                                            </td>
                                                            <%-- <td align="left" style="width: 18%; text-align: Center;">
                                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn" Width="70px" OnClick="btnAdd_Click" />
                                                            </td>--%>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td align="left" style="width: 37%; text-align: center">
                                                                <asp:CheckBoxList runat="server" ID="ChkAddList">
                                                                </asp:CheckBoxList>
                                                            </td>
                                                            <td></td>
                                                        </tr>
                                                        <%-- <tr>
                                                        <td>Enter Institute Mobile No:
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtIHMobNo" runat="server" MaxLength="10" CssClass="txtcss"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RequriedIhMobNo" runat="server" ControlToValidate="txtIHMobNo" Text="*" ValidationGroup="Dspl"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>--%>
                                                        <div class="Space">
                                                        </div>
                                                        <tr>
                                                            <td style="width: 5%; text-align: center">
                                                                <asp:Label ID="lblshwField" runat="server" Text="Show Field" Font-Bold="true" Font-Names="Arial" Font-Size="11pt">

                                                                </asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <%-- <td style="width:5%; text-align:right">
                                                                <asp:Label ID="lblshwField" runat="server" Text="Show Field" Font-Bold="true" Font-Names="Arial" Font-Size="11pt">

                                                                </asp:Label>
                                                            </td>--%>
                                                            <td style="width: 15%; text-align: left">
                                                                <asp:ListBox ID="lstbox1" runat="server" Width="200px" Height="170px" SelectionMode="Multiple"></asp:ListBox>
                                                            </td>
                                                            <td style="width: 10%; text-align: center">
                                                                <asp:Button ID="btnRight" runat="server" Text=" >> " CssClass="btn" OnClick="btnRight_Click" /><br />
                                                                <br />
                                                                <asp:Button ID="btnleft" runat="server" Text=" << " CssClass="btn" OnClick="btnleft_Click" />
                                                            </td>
                                                            <td>
                                                                <asp:ListBox ID="lstbox2" runat="server" Width="180px" Height="170px" SelectionMode="Multiple"></asp:ListBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <div style="margin-left: 130px;">
                                                        &nbsp;&nbsp; 
                                                        <asp:Button ID="btdisplay" runat="server" Text="Display" CssClass="btn" OnClick="btdisplay_Click" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                 <asp:Button ID="btnExportToExcel" runat="server" Text="ExportToExcel" CssClass="btn" OnClick="btnExportToExcel_Click" />
                                                        <%--ValidationGroup="Dspl" />--%>
                                                    </div>
                                                    <%-- <div class="btnDispaly">
                                                    <asp:Button ID="btnExportToExcel" runat="server" Text="ExportToExcel" CssClass="btn" OnClick="btnExportToExcel_Click" />
                                                </div>--%>
                                                    <div class="SpcBwnBtnAndGv">
                                                    </div>
                                                    <div class="SpcBwnBtnAndGv">
                                                        <table style="margin-left: 0px;">
                                                            <tr>
                                                                <td>Record Count:
                                                                    <asp:Label ID="lblCount" runat="server" Font-Bold="true" Font-Size="14pt"></asp:Label>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </div>
                                                    <div class="grid" style="width: 100%;">
                                                        <%--margin-left: 130px;--%>
                                                        <div class="rounded">
                                                            <div class="top-outer">
                                                                <div class="top-inner">
                                                                    <div class="top">
                                                                        &nbsp;
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="mid-outer">
                                                                <div class="mid-inner">
                                                                    <div class="mid">
                                                                        <div class="pager">
                                                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="true" PageSize="30" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="datatable" EmptyDataText="Not Found Record.">
                                                                            </asp:GridView>
                                                                            <asp:GridView ID="GridView2" runat="server" Visible="false">
                                                                            </asp:GridView>
                                                                            <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="bottom-outer">
                                                                <div class="bottom-inner">
                                                                    <div class="bottom">
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        <%--</ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
        </Triggers>
    </asp:UpdatePanel>--%>
</asp:Content>

