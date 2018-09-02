<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TodayReport.aspx.cs" Inherits="Html_TodayReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body bgcolor="#EFFAFA">
    <form id="form1" runat="server">
    <div style="width: 90%; margin-left: 5%;">
        <div style="width: 45%; text-align: center; float: right; background-color: White;
            border: 2px outset;">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Todays</asp:LinkButton>
        </div>
        <div style="width: 45%; text-align: center; float: left; background-color: White;
            border: 2px outset;">
            <asp:LinkButton ID="lnkComboReport" runat="server" OnClick="lnkComboReport_Click">ComboWise Report</asp:LinkButton>
        </div>
    </div>
    <br />
    <div style="margin-top: 20px;">
        <asp:MultiView ID="MultiView1" runat="server" OnActiveViewChanged="MultiView1_ActiveViewChanged">
            <asp:View ID="View1" runat="server">
                     <div style="width: 90%; text-align: center; margin-left: 5%; border: 2px solid black;">
                   <div style="background-color: White;">
                        <table style="width:100%;height:200px;text-align:center">
                        <tr style="background-color: #3BD7D7;">
                                <td colspan="2" style="color: White; text-align:center; font-size: 20px;">
                                 <b>Todays ComboReport</b>
                                </td>
                                </tr>
                            <tr>
                                <td align="right" width="30%" style="color: #009999;">
                                    <asp:Label ID="lbltxt" runat="server" Text="Select Meeting Type"></asp:Label>
                                </td>
                                <td align="left" width="50%">
                                    <asp:DropDownList ID="ddltxt" runat="server" AutoPostBack="true">
                                        <asp:ListItem>--select--</asp:ListItem>
                                        <asp:ListItem>personal</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%" style="color:#009999;">
                                    <asp:Label ID="lblnews" runat="server" Text="Select News Paper">
                                    </asp:Label>
                                </td>
                                <td align="left" width="50%">
                                    <asp:DropDownList ID="ddlnews" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlnews_SelectedIndexChanged">
                                        <asp:ListItem>--select--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%" style="color:#009999;">
                                    <asp:Label ID="lblCType" runat="server" Text="Select Complaint Type"></asp:Label>
                                </td>
                                <td align="left" width="50%">
                                    <asp:DropDownList ID="ddlCtype" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCtype_SelectedIndexChanged">
                                        <asp:ListItem>--select--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%" style="color:#009999;">
                                    Select Followup Status
                                </td>
                                <td align="left" width="90%">
                                    <asp:DropDownList ID="DDLStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLStatus_SelectedIndexChanged">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <table>
                    <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false">
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
                    </asp:GridView>
                </table>
                <asp:GridView runat="server" AutoGenerateColumns="false" ID="gvItemNews">
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
                </asp:GridView>
                <asp:GridView ID="gvItemComp" runat="server" AutoGenerateColumns="false" Width="80%">
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
                </asp:GridView>
                <asp:GridView ID="gvItemFollowuo" runat="server" AutoGenerateColumns="False" 
                    BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" Width="80%" 
                    CellPadding="3" CellSpacing="2">
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <Columns>
                        <asp:BoundField DataField="CFID" HeaderText="CFID" Visible="false" />
                        <asp:BoundField DataField="CID" HeaderText="CID" />
                        <asp:BoundField DataField="Date" HeaderText="Date" />
                        <asp:BoundField DataField="Remark" HeaderText="Remark" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:BoundField DataField="Name" HeaderText="Status" />
                 </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </asp:View>
            <asp:View ID="view2" runat="server">
               <table style="width:100%;height:40px;text-align:center">
                        <tr style="background-color: #48C2C2;">
                                <td colspan="2" style="color: White; text-align:center; font-size: 20px;">
                            <b>Todays Report</b>
                        </td>
                    </tr>
                </table>
                <table>
               <tr>
                        <td colspan="2" style="color:Navy;font-size:20px">
                            <asp:Label ID="Label1" Text="Birthday Report" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr><td>
                
                    <asp:GridView ID="gvItemTB" runat="server" AutoGenerateColumns="False" BackColor="#A8A8A8" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" CellSpacing="2" Width="111%" >
                         <RowStyle BackColor="#E8E8E8" ForeColor="#000000"  />
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
                   
                    </td></tr>
                </table>
                <table>
                <tr>
                        <td colspan="2" style="color:Navy;font-size:20px;">
                            <asp:Label ID="Label2" Text="Death Report" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr><td>
                  
                    <asp:GridView ID="gvItemDeath" runat="server" AutoGenerateColumns="False" 
                        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" CellSpacing="2" Width="111%">
                        <RowStyle BackColor="#E8E8E8" ForeColor="#000000"  />
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
                    </td></tr>
                </table>
                <table>
                 <tr>
                 <td colspan="2" style="color:Navy;font-Size:20px">
                 <asp:Label ID="lbln" Text="Todays News" runat="server"></asp:Label>
                 </td>
                 </tr>
                 <tr><td>
                 
                    <asp:GridView ID="gvItemNew1" runat="server" AutoGenerateColumns="False" 
                        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" CellSpacing="2" Width="118%">
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
                  </td></tr>
                </table>
                <table>
                   <tr>
                 <td colspan="2" style="color:Navy;font-Size:20px">
                            <asp:Label ID="Label4" Text="Todays Meeting" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr><td>
                    <asp:GridView ID="gvItemMeet" runat="server" AutoGenerateColumns="False" 
                        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" CellSpacing="2" Width="86%">
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
                    </td></tr>
                </table>
                <table>
                   <tr>
                 <td colspan="2" style="color:Navy;font-Size:20px">
                            <asp:Label ID="Label5" Text="Todays Marriage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr><td>
                    <asp:GridView ID="gvItemMarry" runat="server" AutoGenerateColumns="False" 
                        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" CellSpacing="2" Width="81%">
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
                    </td></tr>
                </table>
                <table>
                  <tr>
                 <td colspan="2" style="color:Navy;font-Size:20px">
                            <asp:Label ID="Label6" Text="Todays Complaint" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr><td>
                    <asp:GridView ID="gvItemComp1" runat="server" AutoGenerateColumns="False" 
                        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" Width="115%"  
                        CellPadding="3" CellSpacing="2">
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
                    </td></tr>
                </table>
                <table>
                 <tr>
                 <td colspan="2" style="color:Navy;font-Size:20px">
                            <asp:Label ID="Label7" Text="Todays Followup" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr><td>
                    <asp:GridView ID="gvItemfollow" runat="server" AutoGenerateColumns="False" 
                        BackColor="#3BD7D7
                        " BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" CellSpacing="2" Width="350%">
                        <RowStyle BackColor="#E8E8E8" ForeColor="#8C4510" />
                        <Columns>
                            <asp:BoundField DataField="CFID" HeaderText="CFID" Visible="false" />
                            <asp:BoundField DataField="CID" HeaderText="CID" />
                            <asp:BoundField DataField="Date" HeaderText="Date" />
                            <asp:BoundField DataField="Remark" HeaderText="Remark" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <%--<asp:BoundField DataField="Name" HeaderText="Status" />--%>
                        </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#325E80" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                    </td></tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </div>
    </form>
</body>
</html>
