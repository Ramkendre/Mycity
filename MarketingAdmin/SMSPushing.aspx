<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master"
    AutoEventWireup="true" CodeFile="SMSPushing.aspx.cs" Inherits="MarketingAdmin_SMSPushing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <%-- <asp:UpdatePanel ID="updtPnlCategory" runat="server">
        <ContentTemplate>--%>
            <table style="width: 100%" class="innerTable" cellspacing="7px">
                <tr>
                    <td colspan="3" align="center">
                        <h3>
                            <asp:Label ID="lblHeader" runat="server" Text="SMS Pushing"></asp:Label></h3>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        
                            <asp:Label ID="lblError" CssClass="Error" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tdLabel" style="width: 298px">
                        <asp:Label ID="lblSender" runat="server" Text="Sender Name"></asp:Label>
                        &nbsp;*
                    </td>
                    <td class="tdText">
                        <asp:TextBox ID="txtName" runat="server" Height="20px" Width="207px"></asp:TextBox>
                    </td>
                    <td class="tdError">
                    </td>
                </tr>
                <tr>
                    <td class="tdLabel" style="width: 298px">
                        <asp:Label ID="lblMessage" runat="server" Text=" Message : "></asp:Label>
                        *
                    </td>
                    <td class="tdText">
                        <asp:TextBox ID="txtMsg" TextMode="MultiLine" Rows="3" runat="server" Width="208px"></asp:TextBox>
                    </td>
                    <td class="tdError">
                    </td>
                </tr>
                <tr>
                    <td class="tdLabel" style="width: 298px">
                        <asp:Label ID="lblCity" runat="server" Text="Select Multiple City  :"></asp:Label>
                        &nbsp;*
                    </td>
                    <td class="tdText">
                        <asp:ListBox ID="lstCity" SelectionMode="Multiple" runat="server" 
                            Height="245px" Width="321px"></asp:ListBox>
                    </td>
                    <td class="tdError">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="tdLabel" style="width: 298px">
                        <asp:Label ID="lblTotal" runat="server" Text="Total Msg :"></asp:Label>
                        &nbsp;*
                    </td>
                    <td class="tdText">
                        <asp:TextBox ID="txtTotal" runat="server"></asp:TextBox>
                    </td>
                    <td class="tdError">
                    </td>
                </tr>
                <tr>
                    <td class="tdLabel" style="width: 298px">
                        <asp:Label ID="lblNoOfDatys" runat="server" Text="Total Days :"></asp:Label>
                        &nbsp;*
                    </td>
                    <td class="tdText">
                        <asp:TextBox ID="txtTotalDays" runat="server"></asp:TextBox>
                    </td>
                    <td class="tdError">
                    </td>
                </tr>
                <tr class="trInnerTable">
                    <td class="tdLabel" style="width: 298px">
                        <asp:Label ID="lblAddress0" runat="server" Text="Social Group :"></asp:Label>
                    </td>
                    <td class="tdTextInner" align="left">
                        <asp:ListBox ID="lstSocial" runat="server" SelectionMode="Multiple" Width="177px">
                        </asp:ListBox>
                    </td>
                    <td class="tdErrorInner" align="left">
                        &nbsp;
                    </td>
                </tr>
                <tr class="trInnerTable">
                    <td class="tdLabel" style="width: 298px">
                        <asp:Label ID="lblAddress1" runat="server" Text="Professional Group :"></asp:Label>
                    </td>
                    <td class="tdTextInner" align="left">
                        <asp:ListBox ID="lstProfessional" runat="server" SelectionMode="Multiple" Width="178px">
                        </asp:ListBox>
                    </td>
                    <td class="tdErrorInner" align="left">
                        &nbsp;
                    </td>
                </tr>
                <tr class="trInnerTable">
                    <td class="tdLabel" style="width: 298px">
                        <asp:Label ID="lblAddress2" runat="server" Text="Bussiness Group :"></asp:Label>
                    </td>
                    <td class="tdTextInner" align="left">
                        <asp:ListBox ID="lstBussiness" runat="server" SelectionMode="Multiple" Width="176px">
                        </asp:ListBox>
                    </td>
                    <td class="tdErrorInner" align="left">
                        &nbsp;
                    </td>
                </tr>
                <tr class="trInnerTable">
                    <td class="tdLabel" style="width: 298px">
                        <asp:Label ID="lblAddress3" runat="server" Text="Political Group :"></asp:Label>
                    </td>
                    <td class="tdTextInner" align="left">
                        <asp:ListBox ID="lstPolitical" runat="server" SelectionMode="Multiple" Width="177px">
                        </asp:ListBox>
                    </td>
                    <td class="tdErrorInner" align="left">
                        &nbsp;
                    </td>
                </tr>
                <tr class="trInnerTable">
                    <td class="tdLabel" style="width: 298px">
                        <asp:Label ID="lblAddress4" runat="server" Text="Member Of :"></asp:Label>
                    </td>
                    <td class="tdTextInner" align="left">
                        <asp:ListBox ID="lstMemberOf" runat="server" SelectionMode="Multiple" Width="174px">
                        </asp:ListBox>
                    </td>
                    <td class="tdErrorInner" align="left">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="tdLabel" style="width: 298px">
                        <asp:Label ID="lblStartFrom" runat="server" Text="Start From :"></asp:Label>
                        &nbsp;*
                    </td>
                    <td class="tdText">
                        <asp:TextBox ID="txtValidFrom" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="txtValidFrom_CalendarExtender" runat="server"
                            TargetControlID="txtValidFrom">
                        </asp:CalendarExtender>
                        (mm/dd/YYYY)<br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" SetFocusOnError="true"
                    ControlToValidate="txtValidFrom" ErrorMessage="* Specify Valid From Date" 
                    Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender" 
                    runat="server" TargetControlID="RequiredFieldValidator7">
                </asp:ValidatorCalloutExtender>
                        <br />
                    </td>
                    <td class="tdError">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button-submit"
                            OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                    </td>
                </tr>
            </table>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
