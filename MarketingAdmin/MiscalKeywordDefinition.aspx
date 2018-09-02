<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master"
    AutoEventWireup="true" CodeFile="MiscalKeywordDefinition.aspx.cs" Inherits="MarketingAdmin_MiscalKeywordDefinition" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<script language="javascript" type="text/javascript">
        function validateKeywordName() {
            if (document.getElementById('<%=txtKeywordName.ClientID %>').value == "") {
                alert("Please Enter Keyword Name");
                return false;
            }
            else {
                return true;
            }
        }
        function ShowDate(sender, args) {
            if (sender._textbox.get_element().value == "") {
                var todayDate = new Date();
                sender._selectedDate = todayDate;


            }
        }
    </script>

   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <table cellpadding="0" cellspacing="0" width="100%" border="1">
                <tr>
                    <td>
                        <asp:TabContainer ID="tabParentSMSControl" runat="server" Width="100%" ActiveTabIndex="0"
                            AutoPostBack="true" Font-Bold="True" Font-Size="Medium">
                            <asp:TabPanel ID="tabChildQuickSMS" runat="server" Height="100%" CssClass="noPrint">
                                <HeaderTemplate>
                                    Personal Keywords</HeaderTemplate>
                                <ContentTemplate>
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
                                                    <table style="width: 97%; height: 290px;" class="tblAdminSubFull1" cellspacing="0px">
                                                        <tr>
                                                            <td align="center" colspan="6">
                                                                <asp:Label ID="lblKeywordDefinition" runat="server" Text="Define Keywords" Font-Bold="True"
                                                                    Font-Size="Large"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                &nbsp;&nbsp;<asp:Label ID="lblError" runat="server" CssClass="error" Visible="False"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left">
                                                                <asp:Label ID="lblKeywordName" runat="server" Text="Keyword Name"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td style="text-align: left">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtKeywordName" runat="server" CssClass="txtcss1" Width="232px"></asp:TextBox>
                                                            </td>
                                                            <td style="text-align: left">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td style="text-align: left">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left; height: 26px;">
                                                                <asp:Label ID="lblKeywordDescription" runat="server" Text="Keyword Description"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left; height: 26px;">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td style="text-align: left; height: 26px;">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td style="text-align: left; height: 26px;">
                                                                <asp:TextBox ID="txtKeywordDescription" runat="server" CssClass="txtcss1" Width="232px"></asp:TextBox>
                                                            </td>
                                                            <td style="text-align: left; height: 26px;">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td style="text-align: left; height: 26px;">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left">
                                                                <asp:Label ID="Label1" runat="server" Text="Enter E-mail Address"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td style="text-align: left">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="txtcss1" Height="71px" Width="232px"
                                                                    TextMode="MultiLine"></asp:TextBox>&nbsp;&nbsp;
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:Label ID="lblemailmessage" runat="server" CssClass="lbl" Text="For multiple email id plz use comma ( , ) seperator"></asp:Label><br />
                                                                <br />
                                                            </td>
                                                            <td style="text-align: left">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left">
                                                                <asp:Label ID="lblEmailSub" runat="server" Text="Enter Email Subject"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td style="text-align: left">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtEmailSub" runat="server" CssClass="txtcss1" Width="232px"></asp:TextBox>
                                                            </td>
                                                            <td style="text-align: left">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td style="text-align: left">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left">
                                                                <asp:Label ID="Label3" runat="server" Text="Forward to Mobile No"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td style="text-align: left">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtFwdMobileno" runat="server" CssClass="txtcss1" Height="71px"
                                                                    Width="232px" TextMode="MultiLine"></asp:TextBox>&nbsp;&nbsp;
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:Label ID="lblemailmessage0" runat="server" CssClass="lbl" Text="For multiple mobile no.  plz use comma ( , ) seperator"></asp:Label><br />
                                                                <br />
                                                            </td>
                                                            <td style="text-align: left">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left">
                                                                <asp:Label ID="lblResponseMsg" runat="server" Text="Response Message"></asp:Label>
                                                            </td>
                                                            <td style="text-align: left">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td style="text-align: left">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td style="text-align: left">
                                                                <asp:TextBox ID="txtResponseMessage" runat="server" TextMode="MultiLine" CssClass="txtcss1"
                                                                    Width="232px" Height="71px"></asp:TextBox>
                                                            </td>
                                                            <td style="text-align: left">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td style="text-align: left">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
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
                                                        </tr>
                                                        <tr>
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
                                                        </tr>
                                                        <tr>
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
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: left" colspan="3">
                                                                &nbsp;&nbsp;
                                                            </td>
                                                            <td style="text-align: left" colspan="3">
                                                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" CssClass="button"
                                                                     Text="Submit" />&nbsp;
                                                                <asp:Button ID="btnCancel" runat="server" CssClass="button" OnClick="btnCancel_Click"
                                                                    Text="Cancel" />&nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" CssClass="button"
                                                                        OnClick="btnBack_Click" Text="Back" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" style="text-align: left">
                                                                <asp:GridView ID="gvKeywordDefinition" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                    CssClass="mGrid" OnPageIndexChanging="gvKeywordDefinition_PageIndexChanging"
                                                                    OnSelectedIndexChanged="gvKeywordDefinition_SelectedIndexChanged" 
                                                                    OnRowCommand="gvKeywordDefinition_RowCommand" 
                                                                    onrowdeleting="gvKeywordDefinition_RowDeleting">
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
                                                                </asp:GridView>
                                                            </td>
                                                            <asp:Label ID="lblId" runat="server"></asp:Label></tr>
                                                    </table>
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="TabPanel1" runat="server" Height="100%" CssClass="noPrint">
                                <HeaderTemplate>
                                    Inbox</HeaderTemplate>
                                <ContentTemplate>
                                    <div align="center" style="width: 100%">
                                        <table class="tblAdminSubFull1">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="Large"
                                                        ForeColor="#006699" Text="Inbox"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbltotalInbox" runat="server" ForeColor="Red" Text="Total Message :"></asp:Label>
                                                    &nbsp;<asp:Label
                                                        ID="lblcount" runat="server" ForeColor="Red"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvInbox" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                        CellPadding="5" CssClass="mGrid" EmptyDataText="No records" OnPageIndexChanging="gvInbox_PageIndexChanging"
                                                        PageSize="15" Width="100%" OnPageIndexChanged="gvInbox_PageIndexChanged">
                                                        <Columns>
                                                            <asp:BoundField DataField="senderMobileNo" HeaderText="Mobile No">
                                                                <HeaderStyle HorizontalAlign="Left" Width="30%" />
                                                                <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="receivedSmsBody" HeaderText="Message">
                                                                <HeaderStyle HorizontalAlign="Left" Width="30%" />
                                                                <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="receivedDateTime" HeaderText="Date &amp; time">
                                                                <HeaderStyle HorizontalAlign="Left" Width="100%" />
                                                                <ItemStyle HorizontalAlign="Left" Width="100%" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <PagerStyle CssClass="pager-row" />
                                                        <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ContentTemplate>
                            </asp:TabPanel>
                        </asp:TabContainer>
                    </td>
                </tr>
            </table>
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
