<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="AllUploadFile.aspx.cs" Inherits="MarketingAdmin_AllUploadFile" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%" border="1">
        <tr>
            <td>
                <center>
                    <table class="tables">
                        <tr>
                            <td colspan="2">
                                <center>
                                    <h3>
                                        Upload File MPCC, BJS, SMT</h3>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Select File Upload Commitee
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUploadCenter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUploadCenter_SelectedIndexChanged">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem Value="1">MPCC (Shidori)</asp:ListItem>
                                    <asp:ListItem Value="2">SMT</asp:ListItem>
                                    <asp:ListItem Value="3">BJS</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Enter The month and Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>e.g Sept13, Oct13,...
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <div>
                                    <fieldset>
                                        <legend>Upload PDF File</legend>
                                        <input type="file" size="65" runat="server" id="FileUpload1">
                                        <asp:Button ID="btnShidori" runat="server" Text="Upload" OnClick="btnShidori_Click" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                    </fieldset>
                                    <br />
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                            PageSize="10" AllowPaging="true">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="ID"></asp:BoundField>
                                <asp:BoundField DataField="Committee_name" HeaderText="Committee_name"></asp:BoundField>
                                <asp:BoundField DataField="Committee_url" HeaderText="Committee_url"></asp:BoundField>
                                <asp:BoundField DataField="FileName" HeaderText="FileName"></asp:BoundField>
                                <asp:BoundField DataField="EntryDate" HeaderText="EntryDate"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </center>
            </td>
        </tr>
    </table>
</asp:Content>
