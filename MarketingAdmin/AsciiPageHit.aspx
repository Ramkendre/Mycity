<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="AsciiPageHit.aspx.cs" Inherits="MarketingAdmin_AsciiPageHit" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table class="tables" width="100%">
            <tr>
                <td>
                    <center>
                        <div style="border: 1px solid #888888;">
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <h3>
                                                Ascii Page Hits</h3>
                                        </center>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <center>
                                            <div id="Errordiv" runat="server" visible="false" style="border:1px solid red; height:30px;width:300px;background:#fff">
                                                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                            </div>
                                        </center>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Enter the text
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMgs" runat="server" TextMode="MultiLine" Height="100px" Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <br />
                                        <asp:Button ID="btnSubmit" runat="server" Text="Show Ascii Code" CssClass="btn" OnClick="btnSubmit_Click" />
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAscii" runat="server" TextMode="MultiLine" Height="100px" Width="300px"
                                            Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Enter the Mobile No :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="txtcss" MaxLength="10"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom, Numbers"
                                            TargetControlID="txtMobileNo">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Paste Ascii Code :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMgsUrl" runat="server" Height="35px" Width="196px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnHint" runat="server" Text="Hits URL" OnClick="btnHint_Click" CssClass="btn" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </div>
                    </center>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
