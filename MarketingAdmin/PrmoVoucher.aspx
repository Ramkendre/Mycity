<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="PrmoVoucher.aspx.cs" Inherits="Add_User" %>
    

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<style type ="text/css" >

.ddlclass
{
	width: 140px;
	height: 20px;
}

.txtclass
{
	width: 140px;
	height: 20px;
}

</style>
    <asp:Accordion ID="Accordion1" runat="server" FramesPerSecond="200">
        <Panes>
            <%--<asp:AccordionPane ID="AccordionPaneAddUser" runat="server">
                <Header>
                    <div style="background-color:#0d7074; height:25px; text-align:center; color:White; font-weight:bold; border:1px ridge white; border-radius:8px; ">
                        Add User
                    </div>
                </Header>
                <Content>
                    <div style="width: 60%; text-align: center; margin-left: 20%; border: 2px solid black;">
                        <div style="background-color: White;">
                            <table style="width: 100%; height: 200px;">
                                <tr style="background-color: #3BD7D7;">
                                    <td colspan="2" style="color: White; font-size: 20px;">
                                        <b>Register User</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="30%" style="color: #009999;">
                                        Role :
                                    </td>
                                    <td align="left" width="50%">
                                        <asp:DropDownList ID="ddlRole" runat="server" CssClass="ddlclass">
                                        <asp:ListItem>Testing Role
                                        </asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="30%" style="color: #009999;">
                                        Firm Name/Agency :
                                    </td>
                                    <td align="left" width="50%">
                                        <asp:TextBox ID="txtFirmName" runat="server" PlaceHolder="Firm Name" CssClass="txtclass"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="30%" style="color: #009999;">
                                        Contact Person :
                                    </td>
                                    <td align="left" width="50%">
                                        <asp:TextBox ID="txtFirstName" runat="server" PlaceHolder="First Name" CssClass="txtclass"></asp:TextBox>
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="txtLastName" runat="server" PlaceHolder="Last Name" CssClass="txtclass"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="30%" style="color: #009999;">
                                        Mobile No :
                                    </td>
                                    <td align="left" width="50%">
                                        <asp:TextBox ID="txtMobileNo" runat="server" PlaceHolder="Mobile No" CssClass="txtclass"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="30%" style="color: #009999;">
                                        Email Id :
                                    </td>
                                    <td align="left" width="50%">
                                        <asp:TextBox ID="txtEmail" runat="server" PlaceHolder="Email Id" CssClass="txtclass"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="30%" style="color: #009999;">
                                        Detail Address :
                                    </td>
                                    <td align="left" width="50%">
                                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Height="60px" Width="260px"
                                            PlaceHolder="Detail Address"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="30%" style="color: #009999;">
                                        State :
                                    </td>
                                    <td align="left" width="50%">
                                        <asp:DropDownList ID="ddlState" runat="server" CssClass="ddlclass">
                                         <asp:ListItem>State
                                        </asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="30%" style="color: #009999;">
                                        District :
                                    </td>
                                    <td align="left" width="50%">
                                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="ddlclass">
                                         <asp:ListItem>District
                                        </asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="30%" style="color: #009999;">
                                        Taluka :
                                    </td>
                                    <td align="left" width="50%">
                                        <asp:DropDownList ID="ddlTaluka" runat="server" CssClass="ddlclass">
                                         <asp:ListItem>taluka
                                        </asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="30%" style="color: #009999;">
                                        Pincode :
                                    </td>
                                    <td align="left" width="50%">
                                        <asp:TextBox ID="txtPincode" runat="server" PlaceHolder="Pincode" CssClass="txtclass"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="30%">
                                    </td>
                                    <td align="left" width="50%">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" ForeColor="White" Font-Bold="true"
                                            Width="80px" Height="35px" Font-Size="Large" Style="background-color: #3BD7D7;"
                                            OnClick="btnSubmit_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />
                        <div style="background-color: White;">
                            <asp:GridView ID="gvcodelist" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#3BD7D7"
                                Width="100%" AllowPaging="true" PageSize="20">
                                <Columns>
                                    <asp:BoundField DataField="UsrRole" HeaderText="Usr Role" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UsrFirmName" HeaderText="Firm Name" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UsrFirstName" HeaderText="First Name" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UsrLastName" HeaderText="Last Name" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UsrMobNo" HeaderText="Mobile No" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UsrEmailId" HeaderText="Email Id" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UsrAddress" HeaderText="Address" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UsrState" HeaderText="State" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UsrDistrict" HeaderText="District" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UsrTaluka" HeaderText="Taluka" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UsrPincode" HeaderText="Pincode" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </Content>
            </asp:AccordionPane>--%>
            <asp:AccordionPane ID = "AccordionPaneCoupneGenerate" runat ="server" >
            <Header>
                <div style="background-color:#0d7074;height:25px; text-align:center; color:White; font-weight:bold; border:1px ridge white; border-radius:8px;" >
                        Create Voucher
                    </div>
            </Header>
            <Content>
                <div style=" width: 60%; text-align: center; margin-left: 20%; border: 2px solid black;">
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
                    <td align="right" width="40%" style="color: #009999;" >
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
                            Width="80px" Height="35px" Font-Size="Large" 
                            Style="background-color: #3BD7D7;" onclick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div style="background-color: White;">
            <asp:GridView ID="gvcodelist" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#3BD7D7"
                Width="100%" AllowPaging="true" PageSize="20" 
                onpageindexchanging="gvcodelist_PageIndexChanging">
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
            
            </Content>    
            </asp:AccordionPane>
            <asp:AccordionPane ID="AccordionPaneCoupne" runat="server">
                <Header>
                    <div style="background-color:#0d7074;height:25px; text-align:center; color:White; font-weight:bold; border:1px ridge white; border-radius:8px;" >
                        Coupan Details
                    </div>
                </Header>
                <Content>
                    <div style="width: 70%; text-align: center; margin-left: 15%; border: 2px solid black;">
                        <div style="background-color: White;">
                            <table style="width: 100%; height: 200px;">
                                <tr style="background-color: #3BD7D7;">
                                    <td colspan="2" style="color: White; font-size: 20px;">
                                        <b>Coupan Allottment</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="30%" style="color: #009999;">
                                        Select State Stockiest :
                                    </td>
                                    <td align="left" width="50%">
                                        <asp:DropDownList ID="ddlStateStockiest" runat="server" CssClass="ddlclass">
                                        <asp:ListItem> State Stocklist </asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="30%" style="color: #009999;">
                                        Date of Allottment :
                                    </td>
                                    <td align="left" width="50%">
                                        <asp:TextBox ID="txtDateTime" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="30%" style="color: #009999;">
                                        Range of SrNo From :
                                    </td>
                                    <td align="left" width="50%">
                                        <asp:TextBox ID="txtSrnoFrom" runat="server" PlaceHolder="e.g: 1001"></asp:TextBox>
                                        To
                                        <asp:TextBox ID="txtSrnoTo" runat="server" PlaceHolder="e.g: 2000"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="30%">
                                    </td>
                                    <td align="left" width="50%">
                                        <asp:Button ID="Button1" runat="server" Text="Submit" ForeColor="White" Font-Bold="true"
                                            Width="80px" Height="35px" Font-Size="Large" Style="background-color: #3BD7D7;" OnClick="Button1_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />
                        <div style="background-color: White;">
                            <asp:GridView ID="gvCoupenDetails" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#3BD7D7"
                                Width="100%" AllowPaging="true" PageSize="20">
                                <Columns>
                                    <%--<asp:BoundField DataField="" HeaderText="SrNo" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="State_Stocklist" HeaderText="State Stockiests" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Date_Of_Allotment" HeaderText="Date Of Alltment" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="VoucherRange_From" HeaderText="Voucher From" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="VoucherRange_To" HeaderText="Voucher From" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </Content>
            </asp:AccordionPane>
        </Panes>
    </asp:Accordion>
</asp:Content>
