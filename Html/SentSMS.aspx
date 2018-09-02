<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="SentSMS.aspx.cs" Inherits="html_SentSMS" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function openPopup(strOpen) {
            open(strOpen, "Message",
         "status=1, width=600, height=400, top=100, left=300");
        }
      
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="MainDiv">
                <div class="InnerDiv">
                    <center>
                        <table class="tblSubFull2">
                            <tr>
                                <td colspan="2">
                                    <center>
                                        <img src="../KResource/Images/QuickSmsImg.png" width="30px" height="20px" alt="" />
                                        <span class="spanTitle">Sent Message</span>
                                    </center>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    From Date
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtfrmdate" runat="server" CssClass="ccstxt"></asp:TextBox>
                                    <img src="../resources1/images/calendarclick.gif" id="imgFrom" alt="" style="height: 19px;
                                        width: 19px" />
                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtfrmdate"
                                        PopupButtonID="imgFrom" Enabled="True">
                                    </asp:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbltodate" runat="server" CssClass="lbl" Text="To Date"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txttodate1" runat="server" CssClass="ccstxt"></asp:TextBox>
                                    <img src="../resources1/images/calendarclick.gif" id="imgTo" alt="" style="height: 19px;
                                        width: 19px" />
                                    <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txttodate1"
                                        PopupButtonID="imgTo" Enabled="True">
                                    </asp:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Search By Mobile
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtSearchMobile" runat="server" CssClass="ccstxt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="left">
                                    <asp:Button ID="Button3" runat="server" CssClass="cssbtn" Height="24px" OnClick="Button3_Click"
                                        Text="Get" Width="52px"></asp:Button>
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="grdsntmsg" runat="server" AllowPaging="True" AllowSorting="True"
                            CssClass="gridview" AutoGenerateColumns="False" EmptyDataText="Not Sent any Message"
                            OnPageIndexChanging="grdsntmsg_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID"></asp:BoundField>
                                <asp:BoundField DataField="sendFrom" HeaderText="From"></asp:BoundField>
                                <asp:BoundField DataField="SendTo" HeaderText="To"></asp:BoundField>
                                <asp:BoundField DataField="sendDateTime" HeaderText="Date"></asp:BoundField>
                                <asp:BoundField DataField="sentMessage" HeaderText="Message"></asp:BoundField>
                                <asp:TemplateField HeaderText="Details">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <a href="javascript:openPopup('../PopUpFile/SmsDetails.aspx?Id=<%# Eval("ID") %>')">
                                            Show Details</a>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </center>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
