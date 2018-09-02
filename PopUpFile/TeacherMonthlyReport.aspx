<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeacherMonthlyReport.aspx.cs"
    Inherits="PopUpFile_TeacherMonthlyReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../resources1/stylesheet/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <table class="tables">
        <tr>
            <td>
                <form id="form1" runat="server">
                <div>
                    <div style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px; border: 1px solid #888888;
                        width: 80%">
                        <asp:GridView ID="gvItem" runat="server" Width="100%" CssClass="datatable" CellPadding="5"
                            CellSpacing="0" GridLines="None" AutoGenerateColumns="False" ToolTip="Details Of Student Attendence">
                            <RowStyle BackColor="#F7F7DE" Height="30px" />
                            <Columns>
                                <asp:BoundField DataField="usrFirstName" HeaderText="First Name">
                                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                                    <ItemStyle HorizontalAlign="left" Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="usrLastName" HeaderText="Last Name">
                                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                                    <ItemStyle HorizontalAlign="left" Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PK" HeaderText="Message Id">
                                    <HeaderStyle HorizontalAlign="left" Width="10%" />
                                    <ItemStyle HorizontalAlign="left" Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="mobile" HeaderText="Mobile Number">
                                    <HeaderStyle HorizontalAlign="left" Width="15%" />
                                    <ItemStyle HorizontalAlign="left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Message" HeaderText="Message">
                                    <HeaderStyle HorizontalAlign="left" Width="50%" />
                                    <ItemStyle HorizontalAlign="left" Width="50%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="shortcode" HeaderText="Date">
                                    <HeaderStyle HorizontalAlign="left" Width="15%" />
                                    <ItemStyle HorizontalAlign="left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FlagStatus" HeaderText="Status">
                                    <HeaderStyle HorizontalAlign="left" Width="20%" />
                                    <ItemStyle HorizontalAlign="left" Width="20%" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" />
                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#009999" Font-Bold="True" Font-Size="1.1em" ForeColor="White"
                                Height="30px" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </div>
                </div>
                </form>
            </td>
        </tr>
    </table>
</body>
</html>
