<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="TodaysReports.aspx.cs" Inherits="Html_TodaysReports" Title="Untitled Page"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <style type="text/css">
        /* Style Sheet Attributes */.ajax__tab_lightblue-theme .ajax__tab_header
        {
            font-family: 'Calibri' , sans-serif;
            font-weight: 500;
            font-size: 16px;
        }
        .ajax__tab_lightblue-theme .ajax__tab_header .ajax__tab_outer
        {
            background-color: #A4DED5;
            margin: 0px 0.16em 0px 0px;
            padding: 1px 0px 1px 0px;
            vertical-align: bottom;
            border-radius: 5px 5px 0px 0px;
        }
        .ajax__tab_lightblue-theme .ajax__tab_header .ajax__tab_tab
        {
            color: #000;
            padding: 0.35em 0.75em;
            margin-right: 0.01em;
        }
        .ajax__tab_lightblue-theme .ajax__tab_hover .ajax__tab_outer
        {
            background-color: #8FBEB7;
        }
        .ajax__tab_lightblue-theme .ajax__tab_active .ajax__tab_tab
        {
            color: #000;
        }
        .ajax__tab_lightblue-theme .ajax__tab_active .ajax__tab_outer
        {
            background-image: #ffffff;
        }
        .ajax__tab_lightblue-theme .ajax__tab_body
        {
            font-family: verdana,tahoma,helvetica;
            font-size: 10pt;
            padding: 0.25em 0.5em;
            background-color: #ffffff;
            border-top-width: 0px;
        }
        .linkPage
        {
            font-family: 'Calibri' , sans-serif;
            font-weight: bold;
            height: 30px;
            font-size: 15px;
            color: #164854;
        }
    </style>
    <div style="width: 90%; margin-left: 5%;">
        <div style="width: 45%; text-align: center; float: right; background-color: White;
            border: 2px outset;">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Todays</asp:LinkButton>
        </div>
        <div style="width: 45%; text-align: center; float: left; background-color: White;
            border: 2px outset;">
            <asp:LinkButton ID="lnkComboReport" runat="server" OnClick="lnkComboReport_Click">Select Date</asp:LinkButton>
        </div>
    </div>
    <br />
    <div style="margin-top: 20px;">
        <asp:MultiView ID="MultiView1" runat="server" OnActiveViewChanged="MultiView1_ActiveViewChanged">
            <asp:View ID="View1" runat="server">
                <table>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblEvent" runat="server" Text="Select Event"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlEvent" runat="server" Width="100px">
                                <asp:ListItem>--Select--</asp:ListItem>
                                <asp:ListItem>Birthday</asp:ListItem>
                                <asp:ListItem>Meeting</asp:ListItem>
                                <asp:ListItem>Marrige</asp:ListItem>
                                <asp:ListItem>Complaint</asp:ListItem>
                                <asp:ListItem>Followup</asp:ListItem>
                                <asp:ListItem>Death</asp:ListItem>
                                <asp:ListItem>News</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblDate" runat="server" Text="Enter Date" Width="100px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBirthdate" runat="server" Width="100px"></asp:TextBox>
                            <asp:Image ID="Image2" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                                runat="server" />
                            <asp:CalendarExtender ID="CEBD" PopupButtonID="Image2" runat="server" Format="yyyy-MM-dd"
                                TargetControlID="txtBirthdate">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                        </td>
                    </tr>
                    <%--<tr>
                        <td align="center">
                            <asp:Button ID="btnExportToExcel" runat="server" OnClick="btnExportToExcel_Click" Text="Export to excel" />
                        </td>
                    </tr>
                    --%>
                    </table>
                    <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gvItemD" runat="server" AutoGenerateColumns="False" BackColor="#A8A8A8"
                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                Width="100%">
                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                <Columns>
                                    <asp:BoundField DataField="BID" HeaderText="BID" Visible="false" />
                                    <asp:BoundField DataField="NameOfPerson" HeaderText="Name Of Person" />
                                    <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                                    <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" DataFormatString="{0:MM/dd/yyyy}" />
                                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                    <asp:BoundField DataField="SMsg" HeaderText="SMsg" />
                                    <asp:BoundField DataField="MDescp" HeaderText="MDescp" />
                                    <asp:BoundField DataField="RemDate" HeaderText="Remainder Date" DataFormatString="{0:MM/dd/yyyy}" />
                                    <asp:BoundField DataField="Time" HeaderText="Time" />
                                </Columns>
                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#A8A8A8" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:GridView ID="gvItemBC" runat="server" AutoGenerateColumns="False" BackColor="#A8A8A8"
                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                Width="100%">
                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                <Columns>
                                    <asp:BoundField DataField="firstName" HeaderText="Child Name" />
                                    <asp:BoundField DataField="m" HeaderText="MobileNo" />
                                    <asp:BoundField DataField="BID" HeaderText="BID" Visible="false" />
                                    <asp:BoundField DataField="NameOfPerson" HeaderText="Name Of Person" />
                                    <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                                    <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" DataFormatString="{0:MM/dd/yyyy}" />
                                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                    <asp:BoundField DataField="SMsg" HeaderText="SMsg" />
                                    <asp:BoundField DataField="MDescp" HeaderText="MDescp" />
                                    <%--<asp:BoundField DataField="RemDate" HeaderText="Remainder Date" DataFormatString="{0:MM/dd/yyyy}" />--%>
                                    <%--<asp:BoundField DataField="Time" HeaderText="Time" />--%>
                                </Columns>
                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#A8A8A8" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvItemDe" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                Width="100%">
                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                <Columns>
                                    <asp:BoundField DataField="DID" HeaderText="DID" Visible="false" />
                                    <asp:BoundField DataField="NameOfAccused" HeaderText="Name Of Accused" />
                                    <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
                                    <asp:BoundField DataField="Time" HeaderText="Time" />
                                    <asp:BoundField DataField="Location" HeaderText="Location" />
                                    <asp:BoundField DataField="SDescp" HeaderText="SDescp" />
                                    <asp:BoundField DataField="Relative" HeaderText="Relative" />
                                    <asp:BoundField DataField="Relation" HeaderText="Relation" />
                                    <asp:BoundField DataField="PVisit" HeaderText="Personal Visit" />
                                    <asp:BoundField DataField="MDescp" HeaderText="MDescp" />
                                </Columns>
                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvItemDeC" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                Width="100%">
                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                <Columns>
                                    <asp:BoundField DataField="firstName" HeaderText="Child Name" />
                                    <asp:BoundField DataField="m" HeaderText="MobileNo" />
                                    <asp:BoundField DataField="DID" HeaderText="DID" Visible="false" />
                                    <asp:BoundField DataField="NameOfAccused" HeaderText="Name Of Accused" />
                                    <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
                                    <asp:BoundField DataField="Time" HeaderText="Time" />
                                    <asp:BoundField DataField="Location" HeaderText="Location" />
                                    <asp:BoundField DataField="SDescp" HeaderText="SDescp" />
                                    <asp:BoundField DataField="Relative" HeaderText="Relative" />
                                    <asp:BoundField DataField="Relation" HeaderText="Relation" />
                                    <asp:BoundField DataField="PVisit" HeaderText="Personal Visit" />
                                    <asp:BoundField DataField="MDescp" HeaderText="MDescp" />
                                </Columns>
                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvItemM" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                Width="86%">
                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                <Columns>
                                    <asp:BoundField DataField="ID" Visible="false" />
                                    <asp:BoundField DataField="ETitle" HeaderText="Event Title" />
                                    <asp:BoundField DataField="MeetingType" HeaderText="Meeting Type" />
                                    <asp:BoundField DataField="Location" HeaderText="Location" />
                                    <asp:BoundField DataField="FrmDate" HeaderText="FrmDate" />
                                    <asp:BoundField DataField="UptoDate" HeaderText="UptoDate" />
                                    <asp:BoundField DataField="FrmTime" HeaderText="FrmTime" />
                                    <asp:BoundField DataField="UptoTime" HeaderText="UptoTime" />
                                    <asp:BoundField DataField="Descp" HeaderText="Descp" />
                                    <asp:BoundField DataField="RemDate" HeaderText="RemDate" />
                                    <asp:BoundField DataField="RemTime" HeaderText="RemTime" />
                                    <asp:BoundField DataField="RepRemainder" HeaderText="RepRemainder" />
                                </Columns>
                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvItemMc" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                Width="86%">
                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                <Columns>
                                    <asp:BoundField DataField="firstName" HeaderText="Child Name" />
                                    <asp:BoundField DataField="m" HeaderText="MobileNo" />
                                    <asp:BoundField DataField="ID" Visible="false" />
                                    <asp:BoundField DataField="ETitle" HeaderText="Event Title" />
                                    <asp:BoundField DataField="MeetingType" HeaderText="Meeting Type" />
                                    <asp:BoundField DataField="Location" HeaderText="Location" />
                                    <asp:BoundField DataField="FrmDate" HeaderText="FrmDate" />
                                    <asp:BoundField DataField="UptoDate" HeaderText="UptoDate" />
                                    <asp:BoundField DataField="FrmTime" HeaderText="FrmTime" />
                                    <asp:BoundField DataField="UptoTime" HeaderText="UptoTime" />
                                    <asp:BoundField DataField="Descp" HeaderText="Descp" />
                                    <asp:BoundField DataField="RemDate" HeaderText="RemDate" />
                                    <asp:BoundField DataField="RemTime" HeaderText="RemTime" />
                                    <asp:BoundField DataField="RepRemainder" HeaderText="RepRemainder" />
                                </Columns>
                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvItemN" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                Width="100%">
                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                <Columns>
                                    <asp:BoundField DataField="NID" HeaderText="NID" Visible="false" />
                                    <asp:BoundField DataField="NewsHead" HeaderText="News Head" />
                                    <asp:BoundField DataField="NewsDetails" HeaderText="NewsDetails" />
                                    <asp:BoundField DataField="NPaper" HeaderText="NPaper" />
                                    <asp:BoundField DataField="Role" HeaderText="Role" />
                                    <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
                                    <asp:BoundField DataField="Time" HeaderText="Time" />
                                    <asp:BoundField DataField="TypeOfNews" HeaderText="TypeOfNews" />
                                    <asp:BoundField DataField="Location" HeaderText="Location" />
                                    <asp:BoundField DataField="Feedback" HeaderText="Feedback" />
                                </Columns>
                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvItemNC" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                Width="100%">
                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                <Columns>
                                    <asp:BoundField DataField="firstName" HeaderText="Child Name" />
                                    <asp:BoundField DataField="m" HeaderText="MobileNo" />
                                    <asp:BoundField DataField="NID" HeaderText="NID" Visible="false" />
                                    <asp:BoundField DataField="NewsHead" HeaderText="News Head" />
                                    <asp:BoundField DataField="NewsDetails" HeaderText="NewsDetails" />
                                    <asp:BoundField DataField="NPaper" HeaderText="NPaper" />
                                    <asp:BoundField DataField="Role" HeaderText="Role" />
                                    <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
                                    <asp:BoundField DataField="Time" HeaderText="Time" />
                                    <asp:BoundField DataField="TypeOfNews" HeaderText="TypeOfNews" />
                                    <asp:BoundField DataField="Location" HeaderText="Location" />
                                    <asp:BoundField DataField="Feedback" HeaderText="Feedback" />
                                </Columns>
                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvItemMa" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                Width="81%">
                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"></asp:BoundField>
                                    <asp:BoundField DataField="BrideName" HeaderText="Bride"></asp:BoundField>
                                    <asp:BoundField DataField="GroomName" HeaderText="Groom"></asp:BoundField>
                                    <asp:BoundField DataField="InvitionFrom" HeaderText="Invition From"></asp:BoundField>
                                    <asp:BoundField DataField="Date" HeaderText="Date Of Marriage"></asp:BoundField>
                                    <asp:BoundField DataField="Time" HeaderText="Time Of Marriage"></asp:BoundField>
                                    <asp:BoundField DataField="Location" HeaderText="Location" Visible="false"></asp:BoundField>
                                    <asp:BoundField DataField="PersonName" HeaderText="Person Name"></asp:BoundField>
                                    <asp:BoundField DataField="MobileNumber" HeaderText="Mobile No"></asp:BoundField>
                                    <asp:BoundField DataField="PVisit" HeaderText="PVisit"></asp:BoundField>
                                    <asp:BoundField DataField="MDescp" HeaderText="MDescp"></asp:BoundField>
                                    <asp:BoundField DataField="RemDate" HeaderText="Remainder Date" />
                                    <asp:BoundField DataField="RemTime" HeaderText="Remainder Time" />
                                </Columns>
                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GvItemMaC" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                Width="81%">
                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                <Columns>
                                    <asp:BoundField DataField="firstName" HeaderText="Child Name" />
                                    <asp:BoundField DataField="m" HeaderText="MobileNo" />
                                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"></asp:BoundField>
                                    <asp:BoundField DataField="BrideName" HeaderText="Bride"></asp:BoundField>
                                    <asp:BoundField DataField="GroomName" HeaderText="Groom"></asp:BoundField>
                                    <asp:BoundField DataField="InvitionFrom" HeaderText="Invition From"></asp:BoundField>
                                    <asp:BoundField DataField="Date" HeaderText="Date Of Marriage"></asp:BoundField>
                                    <asp:BoundField DataField="Time" HeaderText="Time Of Marriage"></asp:BoundField>
                                    <asp:BoundField DataField="Location" HeaderText="Location" Visible="false"></asp:BoundField>
                                    <asp:BoundField DataField="PersonName" HeaderText="Person Name"></asp:BoundField>
                                    <asp:BoundField DataField="MobileNumber" HeaderText="Mobile No"></asp:BoundField>
                                    <asp:BoundField DataField="PVisit" HeaderText="PVisit"></asp:BoundField>
                                    <asp:BoundField DataField="MDescp" HeaderText="MDescp"></asp:BoundField>
                                    <asp:BoundField DataField="RemDate" HeaderText="Remainder Date" />
                                    <asp:BoundField DataField="RemTime" HeaderText="Remainder Time" />
                                </Columns>
                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvItemC" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" Width="100%" CellPadding="3"
                                CellSpacing="2">
                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                <Columns>
                                    <asp:BoundField DataField="firstName" HeaderText="Child Name" />
                                    <asp:BoundField DataField="m" HeaderText="MobileNo" />
                                    <asp:BoundField DataField="CID" HeaderText="CID" />
                                    <asp:BoundField DataField="CompType" HeaderText="CompType" />
                                    <asp:BoundField DataField="Date" HeaderText="Date" />
                                    <asp:BoundField DataField="CompSub" HeaderText="CompSub" />
                                    <asp:BoundField DataField="CompName" HeaderText="CompName" />
                                    <asp:BoundField DataField="CompDetails" HeaderText="CompDetails" />
                                    <asp:BoundField DataField="CompFDept" HeaderText="CompFDept" />
                                    <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                                    <asp:BoundField DataField="Address" HeaderText="Address" />
                                </Columns>
                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvItemCC" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" Width="100%" CellPadding="3"
                                CellSpacing="2">
                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                <Columns>
                                    <asp:BoundField DataField="CID" HeaderText="CID" />
                                    <asp:BoundField DataField="CompType" HeaderText="CompType" />
                                    <asp:BoundField DataField="Date" HeaderText="Date" />
                                    <asp:BoundField DataField="CompSub" HeaderText="CompSub" />
                                    <asp:BoundField DataField="CompName" HeaderText="CompName" />
                                    <asp:BoundField DataField="CompDetails" HeaderText="CompDetails" />
                                    <asp:BoundField DataField="CompFDept" HeaderText="CompFDept" />
                                    <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                                    <asp:BoundField DataField="Address" HeaderText="Address" />
                                </Columns>
                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:TabContainer runat="server" ID="TabContainer1" Width="100%" ActiveTabIndex="0"
                                        AutoPostBack="true" CssClass="ajax__tab_lightblue-theme">
                                        <asp:TabPanel ID="tabToday" runat="server" Width="100%">
                                            <HeaderTemplate>
                                                Birthday
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <table>
                                                    <tr>
                                                        <td colspan="2" style="color: Navy; font-size: 16px">
                                                            <asp:Label ID="Label1" Text="Birthday Report" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvItemTB" runat="server" AutoGenerateColumns="False" BackColor="#A8A8A8"
                                                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                                                Width="111%">
                                                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="BID" HeaderText="BID" Visible="false" />
                                                                    <asp:BoundField DataField="NameOfPerson" HeaderText="Name Of Person" />
                                                                    <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                                                                    <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" DataFormatString="{0:MM/dd/yyyy}" />
                                                                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                                                    <asp:BoundField DataField="SMsg" HeaderText="SMsg" />
                                                                    <asp:BoundField DataField="MDescp" HeaderText="MDescp" />
                                                                    <asp:BoundField DataField="RemDate" HeaderText="Remainder Date" DataFormatString="{0:MM/dd/yyyy}" />
                                                                    <asp:BoundField DataField="Time" HeaderText="Time" />
                                                                </Columns>
                                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#A8A8A8" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Button ID="btnExportToExcel" runat="server" OnClick="btnExportToExcel_Click"
                                                                Text="Export to excel" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton ID="lnkShowBday" runat="server" OnClick="lnkShowBday_Click">Show Child Record</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvItemB" runat="server" AutoGenerateColumns="False" BackColor="#A8A8A8"
                                                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                                                Width="100%">
                                                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="firstName" HeaderText="child Name" />
                                                                    <asp:BoundField DataField="m" HeaderText="child MobileNo" />
                                                                    <asp:BoundField DataField="BID" HeaderText="BID" Visible="false" />
                                                                    <asp:BoundField DataField="NameOfPerson" HeaderText="Name Of Person" />
                                                                    <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                                                                    <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" DataFormatString="{0:MM/dd/yyyy}" />
                                                                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                                                    <asp:BoundField DataField="SMsg" HeaderText="SMsg" />
                                                                    <asp:BoundField DataField="MDescp" HeaderText="MDescp" />
                                                                </Columns>
                                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#A8A8A8" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="TabPanel1" runat="server" Width="100%">
                                            <HeaderTemplate>
                                                Death
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <table>
                                                    <tr>
                                                        <td colspan="2" style="color: Navy; font-size: 16px;">
                                                            <asp:Label ID="Label2" Text="Death Report" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvItemDeath" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                                                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                                                Width="100%">
                                                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="DID" HeaderText="DID" Visible="false" />
                                                                    <asp:BoundField DataField="NameOfAccused" HeaderText="Name Of Accused" />
                                                                    <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
                                                                    <asp:BoundField DataField="Time" HeaderText="Time" />
                                                                    <asp:BoundField DataField="Location" HeaderText="Location" />
                                                                    <asp:BoundField DataField="SDescp" HeaderText="SDescp" />
                                                                    <asp:BoundField DataField="Relative" HeaderText="Relative" />
                                                                    <asp:BoundField DataField="Relation" HeaderText="Relation" />
                                                                    <asp:BoundField DataField="PVisit" HeaderText="Personal Visit" />
                                                                    <asp:BoundField DataField="MDescp" HeaderText="MDescp" />
                                                                </Columns>
                                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton ID="lnkShowDeath" runat="server" OnClick="lnkShowDeath_Click">Show Child Record</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvItemDC" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                                                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                                                Width="100%">
                                                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="firstName" HeaderText="child Name" />
                                                                    <asp:BoundField DataField="m" HeaderText="child MobileNo" />
                                                                    <asp:BoundField DataField="DID" HeaderText="DID" Visible="false" />
                                                                    <asp:BoundField DataField="NameOfAccused" HeaderText="Name Of Accused" />
                                                                    <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
                                                                    <asp:BoundField DataField="Time" HeaderText="Time" />
                                                                    <asp:BoundField DataField="Location" HeaderText="Location" />
                                                                    <asp:BoundField DataField="SDescp" HeaderText="SDescp" />
                                                                    <asp:BoundField DataField="Relative" HeaderText="Relative" />
                                                                    <asp:BoundField DataField="Relation" HeaderText="Relation" />
                                                                    <asp:BoundField DataField="PVisit" HeaderText="Personal Visit" />
                                                                    <asp:BoundField DataField="MDescp" HeaderText="MDescp" />
                                                                </Columns>
                                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="TabPanel2" runat="server" Width="100%">
                                            <HeaderTemplate>
                                                News
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <table>
                                                    <tr>
                                                        <td colspan="2" style="color: Navy; font-size: 16px">
                                                            <asp:Label ID="lbln" Text="Todays News" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvItemNew1" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                                                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                                                Width="100%">
                                                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="NID" HeaderText="NID" Visible="false" />
                                                                    <asp:BoundField DataField="NewsHead" HeaderText="News Head" />
                                                                    <asp:BoundField DataField="NewsDetails" HeaderText="NewsDetails" />
                                                                    <asp:BoundField DataField="NPaper" HeaderText="NPaper" />
                                                                    <asp:BoundField DataField="Role" HeaderText="Role" />
                                                                    <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
                                                                    <asp:BoundField DataField="Time" HeaderText="Time" />
                                                                    <asp:BoundField DataField="TypeOfNews" HeaderText="TypeOfNews" />
                                                                    <asp:BoundField DataField="Location" HeaderText="Location" />
                                                                    <asp:BoundField DataField="Feedback" HeaderText="Feedback" />
                                                                </Columns>
                                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton ID="lnkShowNews" runat="server" OnClick="lnkShowNews_Click">Show Child Record</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvItemNewC" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                                                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                                                Width="100%">
                                                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="firstName" HeaderText="child Name" />
                                                                    <asp:BoundField DataField="m" HeaderText="child MobileNo" />
                                                                    <asp:BoundField DataField="NID" HeaderText="NID" Visible="false" />
                                                                    <asp:BoundField DataField="NewsHead" HeaderText="News Head" />
                                                                    <asp:BoundField DataField="NewsDetails" HeaderText="NewsDetails" />
                                                                    <asp:BoundField DataField="NPaper" HeaderText="NPaper" />
                                                                    <asp:BoundField DataField="Role" HeaderText="Role" />
                                                                    <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
                                                                    <asp:BoundField DataField="Time" HeaderText="Time" />
                                                                    <asp:BoundField DataField="TypeOfNews" HeaderText="TypeOfNews" />
                                                                    <asp:BoundField DataField="Location" HeaderText="Location" />
                                                                    <asp:BoundField DataField="Feedback" HeaderText="Feedback" />
                                                                </Columns>
                                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="TabPanel3" runat="server" Width="100%">
                                            <HeaderTemplate>
                                                Meeting
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <table>
                                                    <tr>
                                                        <td colspan="2" style="color: Navy; font-size: 16px">
                                                            <asp:Label ID="Label4" Text="Todays Meeting" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvItemMeet" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                                                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                                                Width="100%">
                                                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="ID" Visible="false" />
                                                                    <asp:BoundField DataField="ETitle" HeaderText="Event Title" />
                                                                    <asp:BoundField DataField="MeetingType" HeaderText="Meeting Type" />
                                                                    <asp:BoundField DataField="Location" HeaderText="Location" />
                                                                    <asp:BoundField DataField="FrmDate" HeaderText="FrmDate" />
                                                                    <asp:BoundField DataField="UptoDate" HeaderText="UptoDate" />
                                                                    <asp:BoundField DataField="FrmTime" HeaderText="FrmTime" />
                                                                    <asp:BoundField DataField="UptoTime" HeaderText="UptoTime" />
                                                                    <asp:BoundField DataField="Descp" HeaderText="Descp" />
                                                                    <asp:BoundField DataField="RemDate" HeaderText="RemDate" />
                                                                    <asp:BoundField DataField="RemTime" HeaderText="RemTime" />
                                                                    <asp:BoundField DataField="RepRemainder" HeaderText="RepRemainder" />
                                                                </Columns>
                                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton ID="lnkShowMeet" runat="server" OnClick="lnkShowMeet_Click">Show Child Record</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvItemMeetC" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                                                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                                                Width="86%">
                                                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="firstName" HeaderText="child Name" />
                                                                    <asp:BoundField DataField="m" HeaderText="child MobileNo" />
                                                                    <asp:BoundField DataField="ID" Visible="false" />
                                                                    <asp:BoundField DataField="ETitle" HeaderText="Event Title" />
                                                                    <asp:BoundField DataField="MeetingType" HeaderText="Meeting Type" />
                                                                    <asp:BoundField DataField="Location" HeaderText="Location" />
                                                                    <asp:BoundField DataField="FrmDate" HeaderText="FrmDate" />
                                                                    <asp:BoundField DataField="UptoDate" HeaderText="UptoDate" />
                                                                    <asp:BoundField DataField="FrmTime" HeaderText="FrmTime" />
                                                                    <asp:BoundField DataField="UptoTime" HeaderText="UptoTime" />
                                                                    <asp:BoundField DataField="Descp" HeaderText="Descp" />
                                                                    <asp:BoundField DataField="RemDate" HeaderText="RemDate" />
                                                                    <asp:BoundField DataField="RemTime" HeaderText="RemTime" />
                                                                    <asp:BoundField DataField="RepRemainder" HeaderText="RepRemainder" />
                                                                </Columns>
                                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="TabPanel4" runat="server" Width="100%">
                                            <HeaderTemplate>
                                                Marriage
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <table>
                                                    <tr>
                                                        <td colspan="2" style="color: Navy; font-size: 16px">
                                                            <asp:Label ID="Label5" Text="Todays Marriage" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvItemMarry" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                                                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                                                Width="81%">
                                                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                                                <Columns>
                                                                    
                                                                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"></asp:BoundField>
                                                                    <asp:BoundField DataField="BrideName" HeaderText="Bride"></asp:BoundField>
                                                                    <asp:BoundField DataField="GroomName" HeaderText="Groom"></asp:BoundField>
                                                                    <asp:BoundField DataField="InvitionFrom" HeaderText="Invition From"></asp:BoundField>
                                                                    <asp:BoundField DataField="Date" HeaderText="Date Of Marriage"></asp:BoundField>
                                                                    <asp:BoundField DataField="Time" HeaderText="Time Of Marriage"></asp:BoundField>
                                                                    <asp:BoundField DataField="Location" HeaderText="Location" Visible="false"></asp:BoundField>
                                                                    <asp:BoundField DataField="PersonName" HeaderText="Person Name"></asp:BoundField>
                                                                    <asp:BoundField DataField="MobileNumber" HeaderText="Mobile No"></asp:BoundField>
                                                                    <asp:BoundField DataField="PVisit" HeaderText="PVisit"></asp:BoundField>
                                                                    <asp:BoundField DataField="MDescp" HeaderText="MDescp"></asp:BoundField>
                                                                    <asp:BoundField DataField="RemDate" HeaderText="Remainder Date" />
                                                                    <asp:BoundField DataField="RemTime" HeaderText="Remainder Time" />
                                                                </Columns>
                                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton ID="lnkShowMarryC" runat="server" OnClick="lnkShowMarryC_Click">Show Child Record</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvItemMarryC" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                                                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"
                                                                Width="81%">
                                                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="firstName" HeaderText="child Name" />
                                                                    <asp:BoundField DataField="m" HeaderText="child MobileNo" />
                                                                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"></asp:BoundField>
                                                                    <asp:BoundField DataField="BrideName" HeaderText="Bride"></asp:BoundField>
                                                                    <asp:BoundField DataField="GroomName" HeaderText="Groom"></asp:BoundField>
                                                                    <asp:BoundField DataField="InvitionFrom" HeaderText="Invition From"></asp:BoundField>
                                                                    <asp:BoundField DataField="Date" HeaderText="Date Of Marriage"></asp:BoundField>
                                                                    <asp:BoundField DataField="Time" HeaderText="Time Of Marriage"></asp:BoundField>
                                                                    <asp:BoundField DataField="Location" HeaderText="Location" Visible="false"></asp:BoundField>
                                                                    <asp:BoundField DataField="PersonName" HeaderText="Person Name"></asp:BoundField>
                                                                    <asp:BoundField DataField="MobileNumber" HeaderText="Mobile No"></asp:BoundField>
                                                                    <asp:BoundField DataField="PVisit" HeaderText="PVisit"></asp:BoundField>
                                                                    <asp:BoundField DataField="MDescp" HeaderText="MDescp"></asp:BoundField>
                                                                    <asp:BoundField DataField="RemDate" HeaderText="Remainder Date" />
                                                                    <asp:BoundField DataField="RemTime" HeaderText="Remainder Time" />
                                                                </Columns>
                                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#000000" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                        <asp:TabPanel ID="TabPanel5" runat="server" Width="150%">
                                            <HeaderTemplate>
                                                Complaint
                                            </HeaderTemplate>
                                            <ContentTemplate>
                                                <table>
                                                    <tr>
                                                        <td colspan="2" style="color: Navy; font-size: 16px">
                                                            <asp:Label ID="Label6" Text="Todays Complaint" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvItemComp1" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                                                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" Width="100%" CellPadding="3"
                                                                CellSpacing="2">
                                                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="CID" HeaderText="CID" />
                                                                    <asp:BoundField DataField="CompType" HeaderText="CompType" />
                                                                    <asp:BoundField DataField="Date" HeaderText="Date" />
                                                                    <asp:BoundField DataField="CompSub" HeaderText="CompSub" />
                                                                    <asp:BoundField DataField="CompName" HeaderText="CompName" />
                                                                    <asp:BoundField DataField="CompDetails" HeaderText="CompDetails" />
                                                                    <asp:BoundField DataField="CompFDept" HeaderText="CompFDept" />
                                                                    <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                                                                    <asp:BoundField DataField="Address" HeaderText="Address" />
                                                                </Columns>
                                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton ID="lnkShowCompC" runat="server" OnClick="lnkShowCompC_Click">Show Child Record</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvItemCompC" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84"
                                                                BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" Width="100%" CellPadding="3"
                                                                CellSpacing="2">
                                                                <RowStyle BackColor="#E8E8E8" ForeColor="#000000" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="firstName" HeaderText="child Name" />
                                                                    <asp:BoundField DataField="m" HeaderText="child MobileNo" />
                                                                    <asp:BoundField DataField="CID" HeaderText="CID" />
                                                                    <asp:BoundField DataField="CompType" HeaderText="CompType" />
                                                                    <asp:BoundField DataField="Date" HeaderText="Date" />
                                                                    <asp:BoundField DataField="CompSub" HeaderText="CompSub" />
                                                                    <asp:BoundField DataField="CompName" HeaderText="CompName" />
                                                                    <asp:BoundField DataField="CompDetails" HeaderText="CompDetails" />
                                                                    <asp:BoundField DataField="CompFDept" HeaderText="CompFDept" />
                                                                    <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                                                                    <asp:BoundField DataField="Address" HeaderText="Address" />
                                                                </Columns>
                                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                                <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:TabPanel>
                                    </asp:TabContainer>
                                </ContentTemplate>
                                <%-- <Triggers>
                <asp:PostBackTrigger ControlID="btnExportToExcel" />
                <%--<asp:AsyncPostBsackTrigger ControlID="btnExportToExcel" />
                </Triggers>--%>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
