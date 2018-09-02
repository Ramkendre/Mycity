<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dynamic_code_generate.aspx.cs"
    Inherits="Dynamic_code_generate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .ddlclass
        {
            width: 120px;
        }
        .txtclass
        {
            width: 135px;
        }
    </style>
</head>
<body bgcolor="#EFFAFA">
    <form id="form1" runat="server">
    <div style="width: 60%; text-align: center; margin-left: 20%; border: 2px solid black;">
        <div style="background-color: White;">
            <table style="width: 100%; height: 350px;">
                <tr style="background-color: #3BD7D7;">
                    <td colspan="2" style="color: White; font-size: 20px;">
                        <b>Generate Codes</b>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="40%" style="color: #009999;">
                        First no. of Series :
                    </td>
                    <td align="left" width="40%">
                        <asp:TextBox ID="txtseries" runat="server" PlaceHolder="e.g: 50100001" CssClass="txtclass"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="40%" style="color: #009999;">
                        Total no. of codes to be generated :
                    </td>
                    <td align="left" width="40%">
                        <asp:TextBox ID="txttotacodes" runat="server" PlaceHolder="e.g: 1000" CssClass="txtclass"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="40%" style="color: #009999;">
                        Scratch code length :
                    </td>
                    <td align="left" width="40%">
                        <asp:TextBox ID="txtscratchcode" runat="server" PlaceHolder="e.g: 5" CssClass="txtclass"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="40%" style="color: #009999;">
                        Alpha-Numeric :
                    </td>
                    <td align="left" width="40%">
                        <asp:RadioButtonList ID="rdobtnYesNo" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                            <asp:ListItem Value="2">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="40%" style="color: #009999;">
                        Date of Code Generation :
                    </td>
                    <td align="left" width="40%">
                        <asp:TextBox ID="txtDate" runat="server" ReadOnly="True" CssClass="txtclass"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="40%">
                    </td>
                    <td align="left" width="40%">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" ForeColor="White" Font-Bold="true"
                            Width="80px" Height="35px" Font-Size="Large" Style="background-color: #3BD7D7;"
                            OnClick="btnSubmit_Click" />&nbsp; &nbsp;
                        <asp:Button ID="btnBack" runat="server" Text="Back" ForeColor="White" Font-Bold="true"
                            Width="80px" Height="35px" Font-Size="Large" 
                            Style="background-color: #3BD7D7;" onclick="btnBack_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div style="background-color: White;">
            <asp:GridView ID="gvcodelist" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#3BD7D7"
                Width="100%" AllowPaging="true" PageSize="20" OnPageIndexChanging="gvcodelist_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="SrNo" HeaderText="SrNo" HeaderStyle-ForeColor="White">
                        <HeaderStyle HorizontalAlign="Center" Width="" />
                        <ItemStyle HorizontalAlign="Center" Width="" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Scratchcode" HeaderText="Codes" HeaderStyle-ForeColor="White">
                        <HeaderStyle HorizontalAlign="Center" Width="" />
                        <ItemStyle HorizontalAlign="Center" Width="" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
