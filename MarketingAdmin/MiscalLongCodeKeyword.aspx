<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="MiscalLongCodeKeyword.aspx.cs" Inherits="MarketingAdmin_MiscalLongCodeKeyword"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <table cellpadding="0" cellspacing="0" width="100%" border="1">
                <tr>
                    <td align="center">
                        <div style="width: 82%">
                            <table cellpadding="0" cellspacing="0" border="0" class="tables" style="width: 98%;
                                height: 332px">
                                <tr>
                                    <td style="height: 20px;">
                                        <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;">
                                        <table style="width: 97%; height: 294px;" class="tblAdminSubFull1" cellspacing="0px">
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:Label ID="lblKeywordDefinition" runat="server" Text="Keywords" Font-Bold="True"
                                                        Font-Size="Large"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left; width: 141px;">
                                                    <asp:Label ID="lblKeywordName" runat="server" Text="Keyword Name"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="txtKeywordName" runat="server" CssClass="txtcss1" Width="232px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left; height: 26px; width: 141px;">
                                                    <asp:Label ID="lblKeywordDescription" runat="server" Text="Keyword Description"></asp:Label>
                                                </td>
                                                <td style="text-align: left; height: 26px;">
                                                    <asp:TextBox ID="txtKeywordDescription" runat="server" CssClass="txtcss1" Width="232px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left; width: 141px;">
                                                    <asp:Label ID="Label1" runat="server" Text="Enter E-mail Address"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="txtcss1" Height="71px" Width="232px"
                                                        TextMode="MultiLine"></asp:TextBox>&nbsp;&nbsp;
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblemailmessage" runat="server" CssClass="lbl" Text="For multiple email id plz use comma ( , ) seperator"></asp:Label><br />
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left; width: 141px;">
                                                    <asp:Label ID="lblEmailSub" runat="server" Text="Enter Email Subject"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="txtEmailSub" runat="server" CssClass="txtcss1" Width="232px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left; width: 141px;">
                                                    <asp:Label ID="Label3" runat="server" Text="Forward to Mobile No"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="txtFwdMobileno" runat="server" CssClass="txtcss1" Height="71px"
                                                        Width="232px" TextMode="MultiLine"></asp:TextBox>&nbsp;&nbsp;
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblemailmessage0" runat="server" CssClass="lbl" Text="For multiple mobile no.  plz use comma ( , ) seperator"></asp:Label><br />
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left; width: 141px;">
                                                    <asp:Label ID="lblResponseMsg" runat="server" Text="Response Message"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="txtResponseMessage" runat="server" TextMode="MultiLine" CssClass="txtcss1"
                                                        Width="232px" Height="71px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <%--   <tr>
                                                <td colspan="3" style="text-align: left">
                                                    <asp:Label ID="Label4" runat="server" Text="Keyword for"></asp:Label>
                                                </td>
                                                <td colspan="3" style="text-align: left">
                                                    <asp:DropDownList ID="ddlkeyword" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                                                        Width="232px">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1">Personal</asp:ListItem>
                                                        <asp:ListItem Value="2">Registration</asp:ListItem>
                                                        <asp:ListItem Value="3">Data</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>--%>
                                            <%--   <tr>
                                                <td colspan="3" style="text-align: left">
                                                    <asp:Label ID="Label5" runat="server" Text="Status" Visible="False"></asp:Label>
                                                </td>
                                                <td colspan="3" style="text-align: left">
                                                    <asp:DropDownList ID="DropDownList1" runat="server" Visible="False">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                        <asp:ListItem>Active</asp:ListItem>
                                                        <asp:ListItem>DeActive</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>--%>
                                            <%--    <tr>
                                                <td colspan="3" style="text-align: left">
                                                </td>
                                                <td id="chkregistration" runat="server" colspan="3" style="text-align: left" visible="False">
                                                    <asp:CheckBoxList ID="chkRegSelection" runat="server">
                                                        <asp:ListItem Value="1" Text="Name"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Address"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Pincode"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="EmailId"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td style="text-align: left; width: 141px; height: 56px;">
                                                    <asp:Label ID="lblResponseMsg0" runat="server" Text="Collect Data On"></asp:Label>
                                                </td>
                                                <td style="text-align: left; height: 56px;">
                                                    <asp:RadioButtonList ID="rdbButton" runat="server" 
                                                        OnSelectedIndexChanged="rdbButton_SelectedIndexChanged" AutoPostBack="True">
                                                       <%-- <asp:ListItem Value="0" Text="General LongCode"></asp:ListItem>--%>
                                                        <asp:ListItem Value="1" Text="Personal Mobile LongCode"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left; width: 141px;">
                                                    <asp:Label ID="lblDataMobile" runat="server" Text="Enter Mobile No." Visible="false"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="txtDataMobile" runat="server" CssClass="txtcss1" Width="232px" Visible="false"></asp:TextBox>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="button" 
                                                        Visible="false" onclick="btnSearch_Click" />
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left; width: 141px;">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:Button ID="btnSubmit" runat="server" CssClass="button" OnClick="btnSubmit_Click"
                                                        OnClientClick="return validateKeywordName();" Text="Submit" />
                                                    &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="button"
                                                        Text="Cancel" />
                                                    &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="button"
                                                        Text="Back" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" style="text-align: left">
                                                   <%-- <asp:GridView ID="gvKeywordDefinition" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                        CssClass="mGrid" OnPageIndexChanging="gvKeywordDefinition_PageIndexChanging"
                                                        OnSelectedIndexChanged="gvKeywordDefinition_SelectedIndexChanged" OnRowCommand="gvKeywordDefinition_RowCommand"
                                                        OnRowDeleting="gvKeywordDefinition_RowDeleting">
                                                        <Columns>
                                                            <asp:BoundField DataField="id" HeaderText="Id" />
                                                            <asp:BoundField DataField="keywordName" HeaderText="KeywordName" />
                                                            <asp:BoundField DataField="keywordDescription" HeaderText="Description" />
                                                            <asp:BoundField DataField="ResponseMessage" HeaderText="ResponseMessage" />
                                                            <asp:BoundField DataField="creationDate" HeaderText="CreatedOn" />
                                                            <asp:TemplateField HeaderText="Modify">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%#Bind("id")%>'
                                                                        CommandName="Modify" ImageUrl="../resources1/images/ico_yes1.gif" /></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton4" runat="server" CommandArgument='<%#Bind("id") %>'
                                                                        CommandName="Delete" ImageUrl="~/resources1/images/close.gif" /></ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>--%>
                                                </td>
                                                <asp:Label ID="lblId" runat="server"></asp:Label>
                                            </tr>
                        </div>
                    </td>
                </tr>
            </table>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
