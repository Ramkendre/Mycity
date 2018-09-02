<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="NewDistributeCouponCode.aspx.cs" Inherits="MarketingAdmin_NewDistributeCouponCode" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%" border="1" align="center">
                <tr>
                    <td align="center">
                        <div id="div" style="width: 100%; margin-right: 7px;">
                            <table cellpadding="0" cellspacing="0" border="0" width="70%" class="tables">
                                <div style="width: 96%">
                                    <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                                        <tr>
                                            <td style="height: 20px;">
                                                <table style="width: 81%; margin-left: 148px;" class="tables" cellspacing="2" cellpadding="2">
                                                    <tr>
                                                        <td colspan="2" align="center" style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                            <h3 style="color: Green; margin-left: 150px;">Distribute Coupon Code</h3>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td colspan="3">
                                                            <span class="warning1" style="color: red;">Fields marked with * are mandatory.</span>
                                                        </td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td colspan="3" align="center">
                                                            <asp:Label ID="lblError" runat="server" Visible="false" Style="color: red; font-size: 21px"></asp:Label>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td style="text-align: Center; width: 210px;" class="auto-style1">
                                                            <asp:Label runat="server" ID="lblFromSrNo" Text="From Serial No"></asp:Label></td>
                                                        <span class="warning1" style="color: Red;">*&nbsp;</span>
                                            </td>
                                            <td style="width: 628px; text-align: left">
                                                <asp:TextBox ID="txtFromSrNo" runat="server" PlaceHolder="e.g 1000" CssClass="txtclass"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <caption>
                                            <br />
                                            <tr>
                                                <td class="auto-style1" style="width: 210px"></td>
                                                <td align="left" style="width: 37%; text-align: center"></td>
                                                <td></td>
                                            </tr>
                                            <div class="Space">
                                            </div>
                                            <tr>

                                                <td class="auto-style1" style="text-align: center; width: 210px;">
                                                    <asp:Label ID="lblToSrNo" runat="server" Text="To Serial No"></asp:Label>
                                                </td>
                                                <td style="width: 10%; text-align: left">
                                                    <asp:TextBox ID="txtToSrNo" runat="server" PlaceHolder="e.g 1010" CssClass="txtclass"></asp:TextBox>
                                                    <%-- &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbljrName" runat="server" Text="" Visible="false"></asp:Label>--%>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtToSrNo" ErrorMessage="*" ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1" style="text-align: center; width: 210px;">
                                                    <asp:Label ID="lblProjectName" runat="server" Text="Select Project Name"></asp:Label>
                                                </td>
                                                <td style="width: 10%; text-align: left">
                                                    <asp:DropDownList ID="ddlProjectName" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1">MyCity</asp:ListItem>
                                                        <asp:ListItem Value="2">EzeeMarketing</asp:ListItem>
                                                        <asp:ListItem Value="3">EzeeTest</asp:ListItem>
                                                        <asp:ListItem Value="4">ClassApp</asp:ListItem>
                                                        <asp:ListItem Value="5">MyPanchayat</asp:ListItem>
                                                        <asp:ListItem Value="6">EzeeStrom</asp:ListItem>
                                                        <asp:ListItem Value="7">BachatGat</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlProjectName" ErrorMessage="*" ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1" style="text-align: center; width: 210px;">
                                                    <asp:Label ID="lblcodefor" runat="server" Text="Select For"></asp:Label>
                                                </td>
                                                <td style="width: 10%; text-align: left">
                                                    <asp:DropDownList ID="ddlCodeFor" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1">Representative</asp:ListItem>
                                                        <asp:ListItem Value="2">Vision</asp:ListItem>
                                                        <asp:ListItem Value="3">Mission</asp:ListItem>
                                                        <asp:ListItem Value="4">Vision&Mission</asp:ListItem>
                                                        <asp:ListItem Value="5">Polling day activity</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlCodeFor" ErrorMessage="*" ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1" style="text-align: center; width: 210px;">
                                                    <asp:Label runat="server" ID="lblAdminMobNo" Text="Enter Admin Mobile No"></asp:Label></td>
                    </td>
                    <td style="width: 10%; text-align: left">
                        <asp:TextBox ID="txtAdminMobNo" runat="server" PlaceHolder="Enter Mobile No" MaxLength="10" CssClass="txtclass"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAdminMobNo" ErrorMessage="*" ValidationGroup="B">*</asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1" style="text-align: center; width: 210px;">
                        <asp:Label runat="server" ID="lblAmount" Text="Enter Amount"></asp:Label></td>
                    </td>
                                                <td style="width: 10%; text-align: left">
                                                    <asp:TextBox ID="txtAmount" runat="server" PlaceHolder="e.g 101" CssClass="txtclass"></asp:TextBox>
                                                </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAmount" ErrorMessage="*" ValidationGroup="B">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                </caption>
            </table>
            <br />
            <div class="SpcBwnBtnAndGv" align="center">
                <asp:Button Text="Submit" ID="btnSubmit" CssClass="btn btn-default" ValidationGroup="B" runat="server" OnClick="btnSubmit_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
            <br />
            <div align="center">
                <asp:GridView ID="gvDistributeCode" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                    AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True" OnPageIndexChanging="gvDistributeCode_PageIndexChanging"
                    PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="2">
                    <Columns>
                        <asp:BoundField DataField="SrNo" HeaderText="Sr No">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="referenceMobNo" HeaderText="Admin MobNo">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CodeForName" HeaderText="For Name">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                    </Columns>
                    <%-- <FooterStyle BackColor="#33adff" ForeColor="#003399" />--%>
                    <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                </asp:GridView>
            </div>
            </td>
                </tr>
            </table>
            </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <%--  <asp:PostBackTrigger ControlID="btnExportToExcel" />--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

