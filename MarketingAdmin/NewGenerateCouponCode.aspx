<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="NewGenerateCouponCode.aspx.cs" Inherits="MarketingAdmin_NewGenerateCouponCode" %>

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
                                                            <h3 style="color: Green; margin-left: 200px;">Coupon Generation</h3>
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
                                                            <asp:Label runat="server" ID="lblFirstnoOfSeries" Text="First no. of Series"></asp:Label></td>
                                                        <span class="warning1" style="color: Red;">*&nbsp;</span>
                                            </td>
                                            <td style="width: 628px; text-align: left">
                                                <asp:TextBox ID="txtseries" runat="server" PlaceHolder="e.g: 50100001" CssClass="txtclass"></asp:TextBox>
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
                                                    <asp:Label ID="lblTotalnoOfcodestobegenerated" runat="server" Text="Total no. of codes to be generated"></asp:Label>
                                                </td>
                                                <td style="width: 10%; text-align: left">
                                                    <asp:TextBox ID="txttotacodes" runat="server" PlaceHolder="e.g: 1000" CssClass="txtclass"></asp:TextBox>
                                                    <%-- &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbljrName" runat="server" Text="" Visible="false"></asp:Label>--%>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttotacodes" ErrorMessage="Please Enter Total No of Code to be generated." ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1" style="text-align: center; width: 210px;">
                                                    <asp:Label ID="lblScratchcodelength" runat="server" Text="Scratch code length"></asp:Label>
                                                </td>
                                                <td style="width: 10%; text-align: left">
                                                    <asp:TextBox ID="txtscratchcode" runat="server" PlaceHolder="e.g: 5" CssClass="txtclass"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtscratchcode" ErrorMessage="*" ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1" style="text-align: center; width: 210px;">
                                                    <asp:Label ID="lblAlphaNumeric" runat="server" Text="Alpha-Numeric"></asp:Label>
                                                </td>
                                                <td style="width: 10%; text-align: left">
                                                    <asp:RadioButtonList ID="rdobtnYesNo" runat="server" RepeatDirection="Vertical">
                                                        <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
                                                        <asp:ListItem Value="2">No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rdobtnYesNo" ErrorMessage="Please Select any one" ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1" style="text-align: center; width: 210px;">
                                                    <asp:Label runat="server" ID="lblDategeneration" Text="Date of Code Generation"></asp:Label></td>
                    </td>
                    <td style="width: 10%; text-align: left">
                        <asp:TextBox ID="txtDate" runat="server" ReadOnly="True" CssClass="txtclass"></asp:TextBox>
                    </td>
                    <td>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDate" ErrorMessage="Please Select Pin Code" ValidationGroup="B">*</asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" style="text-align: center; width: 210px;">
                        <asp:Label runat="server" ID="lblAssigntoMktperson" Text="Enter Mobile No"></asp:Label></td>
                    </td>
                                                <td style="width: 10%; text-align: left">
                                                    <asp:TextBox ID="txtAssigntoMktperson" runat="server" PlaceHolder="Enter Mobile No" MaxLength="10" CssClass="txtclass"></asp:TextBox>
                                                </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAssigntoMktperson" ErrorMessage="Please Enter Mobile No" ValidationGroup="B">*</asp:RequiredFieldValidator>
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
                <asp:GridView ID="gvcodelist" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No Data Found..." ShowHeaderWhenEmpty="true"
                    AutoGenerateColumns="False" Font-Names="Arial" Font-Size="11pt" AllowPaging="True" ShowFooter="True" OnPageIndexChanging="gvcodelist_PageIndexChanging"
                    PageSize="10" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="2">
                    <Columns>
                        <asp:BoundField DataField="SrNo" HeaderText="Sr No">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Scratchcode" HeaderText="Scratch code">
                            <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                            <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                        </asp:BoundField>
                    </Columns>
                    <%-- <FooterStyle BackColor="#33adff" ForeColor="#003399" />--%>
                    <HeaderStyle BackColor="#33adff" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <%--<SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <sortedascendingcellstyle backcolor="#EDF6F6" />
                    <sortedascendingheaderstyle backcolor="#0D4AC4" />
                    <sorteddescendingcellstyle backcolor="#D6DFDF" />
                    <sorteddescendingheaderstyle backcolor="#002876" />--%>
                </asp:GridView>
                <%--<asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>--%>
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

