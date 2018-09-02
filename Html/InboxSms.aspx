<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="InboxSms.aspx.cs" Inherits="html_InboxSms" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="MainDiv">
                <div class="InnerDiv">
                    <center>
                        <table class="tblSubFull2">
                            <tr>
                                <td colspan="2" align="center">
                                    <center>
                                        <img src="../KResource/Images/QuickSmsImg.png" width="30px" height="20px" alt="" /><span
                                            class="spanTitle"> Inbox</span>
                                    </center>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvItem" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        OnPageIndexChanging="gvItem_PageIndexChanging" CssClass="gridview">
                                        <Columns>
                                            <asp:BoundField HeaderText="Sender" DataField="SendFrom"></asp:BoundField>
                                            <asp:BoundField HeaderText="Message" DataField="sentMessage"></asp:BoundField>
                                            <asp:BoundField HeaderText="Date" DataField="SendDateTime"></asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </center>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
