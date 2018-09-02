<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="Hirarchyreport.aspx.cs" Inherits="MarketingAdmin_Hirarchyreport" Title="Untitled Page"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%" border="1">
        <tr>
            <td align="center">
                <div style="width: 100%">
                    <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                        <tr>
                            <td colspan="2" style="height: 20px;">
                                <span class="warning1" style="color: Red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                                    <tr>
                                        <td colspan="2">
                                            <h3 style="text-align: center">
                                                <asp:Label ID="lblHeader" runat="server" Text="Hirarchy Report"></asp:Label>
                                            </h3>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <center>
                                                <asp:RadioButtonList ID="btnRadio" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                                    OnSelectedIndexChanged="btnRadio_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">ALL Report</asp:ListItem>
                                                    <asp:ListItem Value="1">All To Head Master</asp:ListItem>
                                                    <asp:ListItem Value="2">Head Master And Class Teacher</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </center>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <center>
                                                <asp:Label ID="lblError" Visible="False" runat="server" CssClass="error"></asp:Label>
                                                <br />
                                                <asp:Button ID="btnDownloadExl" runat="server" Text="Download To Excel" CssClass="button"
                                                    OnClick="btnDownloadExl_Click" />
                                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="button" PostBackUrl="~/MarketingAdmin/MenuMaster1.aspx?pageid=53" />
                                            </center>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <center>
                                    <asp:Panel ID="Panel1" runat="Server">
                                        <div class="grid" style="width: 100%">
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
                                                                <asp:GridView ID="gvschoolcode" runat="server" Width="100%" CssClass="datatable"
                                                                    OnRowCommand="gvschoolcode_RowCommand" OnPageIndexChanging="gvschoolcode_PageIndexChanging"
                                                                    CellPadding="5" CellSpacing="0" GridLines="None" AutoGenerateColumns="False"
                                                                    AllowPaging="True" EmptyDataText="Data Not Available" PageSize="15" OnSelectedIndexChanged="gvschoolcode_SelectedIndexChanged">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="ID" HeaderText="TID">
                                                                            <HeaderStyle HorizontalAlign="left" Width="5%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="5%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="SchoolCode" HeaderText="School Code">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r11" HeaderText="CT Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="CT_MNo" HeaderText="CT MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="CT" HeaderText="CT Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r10" HeaderText="HM Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="HM_MNo" HeaderText="HM MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="HM" HeaderText="HM Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r9" HeaderText="CH Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="CH_MNo" HeaderText="CH MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="CH" HeaderText="CH Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r8" HeaderText="ExtO Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ExtO_MNo" HeaderText="ExtO MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ExtO" HeaderText="ExtO Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r7" HeaderText="BEO Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="BEO_MNo" HeaderText="BEO MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="BEO" HeaderText="BEO Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r6" HeaderText="DEO Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DEO_MNo" HeaderText="DEO MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DEO" HeaderText="DEO Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r5" HeaderText="EO Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="EO_MNo" HeaderText="EO MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="EO" HeaderText="EO Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r4" HeaderText="DDE Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DDE_MNo" HeaderText="DDE MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DDE" HeaderText="DDE Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r3" HeaderText="DE Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DE_MNo" HeaderText="DE MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DE" HeaderText="DE Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r2" HeaderText="DSE Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DSE_MNo" HeaderText="DSE MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DSEName" HeaderText="DSE Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                    <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <PagerStyle CssClass="pager-row" />
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
                                    </asp:Panel>
                                    <asp:Panel ID="Panel2" runat="Server">
                                        <div class="grid" style="width: 100%">
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
                                                                <asp:GridView ID="gvHmTeacher" runat="server" Width="100%" CssClass="datatable" CellPadding="5"
                                                                    CellSpacing="0" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                                                    EmptyDataText="Data Not Available" PageSize="15" OnPageIndexChanging="gvHmTeacher_PageIndexChanging">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="ID" HeaderText="TID">
                                                                            <HeaderStyle HorizontalAlign="left" Width="5%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="SchoolCode" HeaderText="School Code">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r11" HeaderText="CT Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="10%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="CT_MNo" HeaderText="CT MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="CT" HeaderText="CT Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r10" HeaderText="HM Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="HM_MNo" HeaderText="HM MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="HM" HeaderText="HM Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="20%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                    <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <PagerStyle CssClass="pager-row" />
                                                                </asp:GridView>
                                                                <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
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
                                    </asp:Panel>
                                    <asp:Panel ID="Panel3" runat="Server">
                                        <div class="grid" style="width: 100%">
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
                                                                <asp:GridView ID="gvToHM" runat="server" Width="100%" CssClass="datatable" CellPadding="5"
                                                                    CellSpacing="0" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                                                    EmptyDataText="Data Not Available" PageSize="15" 
                                                                    onpageindexchanging="gvToHM_PageIndexChanging">
                                                                    <Columns>
                                                                      <asp:BoundField DataField="SchoolCode" HeaderText="SchoolCode">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r10" HeaderText="HM Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="HM_MNo" HeaderText="HM MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="HM" HeaderText="HM Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r9" HeaderText="CH Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="CH_MNo" HeaderText="CH MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="CH" HeaderText="CH Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r8" HeaderText="ExtO Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ExtO_MNo" HeaderText="ExtO MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="ExtO" HeaderText="ExtO Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r7" HeaderText="BEO Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="BEO_MNo" HeaderText="BEO MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="BEO" HeaderText="BEO Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r6" HeaderText="DEO Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DEO_MNo" HeaderText="DEO MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DEO" HeaderText="DEO Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r5" HeaderText="EO Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="EO_MNo" HeaderText="EO MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="EO" HeaderText="EO Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r4" HeaderText="DDE Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DDE_MNo" HeaderText="DDE MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DDE" HeaderText="DDE Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r3" HeaderText="DE Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DE_MNo" HeaderText="DE MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DE" HeaderText="DE Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="r2" HeaderText="DSE Role">
                                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DSE_MNo" HeaderText="DSE MNo.">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="DSEName" HeaderText="DSE Name">
                                                                            <HeaderStyle HorizontalAlign="left" Width="15%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                    <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <PagerStyle CssClass="pager-row" />
                                                                </asp:GridView>
                                                                <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
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
                                    </asp:Panel>
                                </center>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
