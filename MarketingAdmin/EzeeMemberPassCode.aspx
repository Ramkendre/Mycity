<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="EzeeMemberPassCode.aspx.cs" Inherits="MarketingAdmin_EzeeMemberPassCode" %>

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
                                                            <h3 style="color: Green; margin-left: 200px;">Generate Passcode</h3>
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
                                                            <asp:Label runat="server" ID="lbltypeofgroup" Text="Type Of Group"></asp:Label></td>
                                                        <span class="warning1" style="color: Red;">*&nbsp;</span>
                                            </td>
                                            <td style="width: 628px; text-align: left">
                                                <asp:DropDownList ID="ddlTypeofGroup" runat="server">
                                                    <asp:ListItem Value="0">SELECT</asp:ListItem>
                                                    <asp:ListItem Value="1"> Personal</asp:ListItem>
                                                    <asp:ListItem Value="2">Political</asp:ListItem>
                                                    <asp:ListItem Value="3">Apartment</asp:ListItem>
                                                    <asp:ListItem Value="4"> Community</asp:ListItem>
                                                </asp:DropDownList>
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
                                                    <asp:Label ID="lblVision" runat="server" Text="Enter Vision"></asp:Label>
                                                </td>
                                                <td style="width: 10%; text-align: left">
                                                    <asp:TextBox ID="txtVision" runat="server" PlaceHolder="" CssClass="txtclass"></asp:TextBox>
                                                    <%-- &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbljrName" runat="server" Text="" Visible="false"></asp:Label>--%>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVision" ErrorMessage="Please Enter Total No of Code to be generated." ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="auto-style1" style="text-align: center; width: 210px;">
                                                    <asp:Label ID="lblnameofwork" runat="server" Text="Enter Name of Group"></asp:Label>
                                                </td>
                                                <td style="width: 10%; text-align: left">
                                                    <asp:TextBox ID="txtNameOfGroup" runat="server" PlaceHolder="" CssClass="txtclass"></asp:TextBox>
                                                    <%-- &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbljrName" runat="server" Text="" Visible="false"></asp:Label>--%>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNameOfGroup" ErrorMessage="*" ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="auto-style1" style="text-align: center; width: 210px;">
                                                    <asp:Label ID="lbl" runat="server" Text="Working For"></asp:Label>
                                                </td>
                                                <td style="width: 10%; text-align: left">
                                                    <asp:TextBox ID="txtWorkingFor" runat="server" PlaceHolder="" CssClass="txtclass"></asp:TextBox>
                                                    <%-- &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbljrName" runat="server" Text="" Visible="false"></asp:Label>--%>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtWorkingFor" ErrorMessage="*" ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="auto-style1" style="text-align: center; width: 210px;">
                                                    <asp:Label ID="lblMission" runat="server" Text="Enter Mission"></asp:Label>
                                                </td>
                                                <td style="width: 10%; text-align: left">
                                                    <asp:TextBox ID="txtMission" runat="server" PlaceHolder="" CssClass="txtclass"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMission" ErrorMessage="*" ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1" style="text-align: center; width: 210px;">
                                                    <asp:Label ID="lbladdress" runat="server" Text="Enter Address"></asp:Label>
                                                </td>
                                                <td style="width: 10%; text-align: left">
                                                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" CssClass="txtclass"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAddress" ErrorMessage="Please Select any one" ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style1" style="text-align: center; width: 210px;">
                                                    <asp:Label runat="server" ID="lblmobileNo" Text="Enter Mobile No"></asp:Label></td>
                    </td>
                    <td style="width: 10%; text-align: left">
                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="txtclass"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="*" ValidationGroup="B">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" style="text-align: center; width: 210px;">
                        <asp:Label runat="server" ID="lblcontactperson" Text="Enter Contact Person"></asp:Label></td>
                    </td>
                                                <td style="width: 10%; text-align: left">
                                                    <asp:TextBox ID="txtContactPerson" runat="server" PlaceHolder="" MaxLength="10" CssClass="txtclass"></asp:TextBox>
                                                </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtContactPerson" ErrorMessage="Please Enter Mobile No" ValidationGroup="B">*</asp:RequiredFieldValidator>
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
            </td>
                </tr>
            </table>
            </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

