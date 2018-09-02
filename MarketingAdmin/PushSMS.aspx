<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="PushSMS.aspx.cs" Inherits="MarketingAdmin_PushSMS" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <table cellpadding="0" cellspacing="0" width="100%" border="1">
                <tr>
                    <td align="center">
                        <div style="width: 70%">
                            <table cellpadding="0" cellspacing="0" border="0" class="tables" style="width: 98%;
                                height: 169px">
                                <tr>
                                    <td style="height: 20px;">
                                        <table style="width: 97%; height: 67px;" class="tblAdminSubFull1" cellspacing="0px">
                                            <tr>
                                                <td align="center" style="height: 31px;" colspan="3">
                                                    <asp:Label ID="Label1" runat="server" Text="Edit SMS and PUSH" Font-Size="X-Large"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Flag =0(Delivered)&nbsp;&nbsp; Flag=1(UnDelivered)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="width: 135px; height: 31px;">
                                                    <asp:Label ID="lblCurrentDate" runat="server" Text="Date :"></asp:Label>
                                                </td>
                                                <td style="height: 31px">
                                                    <asp:TextBox ID="txtCurrDate" runat="server" ReadOnly="True"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkSelectDate" runat="server" AutoPostBack="True" OnCheckedChanged="chkSelectDate_CheckedChanged"
                                                        Text="Select Date" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="3" style="height: 31px;">
                                                    <asp:Panel ID="panel1" runat="server">
                                                        <table class="tblAdminSubFull1">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblfrom" runat="server" Text="Date From"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate">
                                                                    </asp:CalendarExtender>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblto" runat="server" Text="Date To"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                                                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate">
                                                                    </asp:CalendarExtender>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnRecords" runat="server" Height="22px" OnClick="btnRecords_Click"
                                                                        Text="Get Records" CssClass="button" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="height: 31px;" colspan="3">
                                                    <asp:GridView ID="gvLongCodeSMS" runat="server" AllowPaging="true" AutoGenerateColumns="False"
                                                        PageSize="10" OnPageIndexChanging="gvLongCodeSMS_PageIndexChanging" CssClass="mGrid"
                                                        OnRowCommand="gvLongCodeSMS_RowCommand" OnRowEditing="gvLongCodeSMS_RowEditing"
                                                        OnRowUpdating="gvLongCodeSMS_RowUpdating" Width="100%" EmptyDataText="No records" 
                                                        onrowcancelingedit="gvLongCodeSMS_RowCancelingEdit">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="ID">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblID" runat="server" Font-Size="Small" Text='<%# Bind("pk") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Mobile No">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMobile" runat="server" Font-Size="Small" Text='<%# Bind("mobile") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Message">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtMsg" runat="server" Font-Size="Small" Text='<%# Bind("Message") %>'
                                                                        TextMode="MultiLine" Width="95%"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMsg" runat="server" Font-Size="Small" Text='<%# Bind("Message") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                           
                                                            <asp:TemplateField HeaderText="Flag">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblFlag" runat="server" Font-Size="Small" Text='<%# Bind("smsStatus") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblFlag1" runat="server" Font-Size="Small" Text='<%# Bind("SendDate") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Edit" ShowHeader="False">
                                                                <EditItemTemplate>
                                                                    <asp:LinkButton ID="lbkUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                                                        Text="PUSH"></asp:LinkButton>
                                                                    <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                        Text="CANCEL"></asp:LinkButton>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                                                        Text="Edit"></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                           <%-- <tr>
                                                <td align="center" colspan="3" style="height: 31px;">
                                                    <asp:Button ID="btnBack" runat="server" CssClass="button" OnClick="btnBack_Click"
                                                        Text="Back" />
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </div>
                    </td>
                </tr>
            </table>
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
