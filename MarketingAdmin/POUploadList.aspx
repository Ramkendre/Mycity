<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="POUploadList.aspx.cs" Inherits="MarketingAdmin_POUploadList" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <table style="width: 97%; height: 290px;" class="tblAdminSubFull1" cellspacing="0px">
        <tr>
            <td style="text-align: center;" colspan="6">
                <asp:Label ID="lbl1" runat="server" Text="Add PO (Program Officer) List Details"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="text-align: center;">
                &nbsp;
                <asp:Label ID="lblerror" runat="server" ForeColor="Red" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="text-align: center;">
                <asp:Button ID="btnDownLoad" runat="server" CssClass="button" Text="DownLoad PO List File Format"
                    Width="193px" OnClick="btnDownLoad_Click" Height="21px" />
            </td>
        </tr>
        <tr>
            <td colspan="6" style="text-align: center;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <asp:Label ID="lblFile" runat="server" Text="Select File"></asp:Label>
            </td>
            <td style="text-align: left; width: 243px;">
                <asp:FileUpload ID="CSVUpload" runat="server" />
            </td>
            <td style="text-align: left;">
                <asp:Button ID="btnUpload" runat="server" CssClass="button" OnClick="btnUpload_Click"
                    Text="Upload" />
            </td>
            <td style="text-align: left;">
            </td>
            <td style="text-align: left;">
            </td>
            <td style="text-align: left;">
            </td>
        </tr>
        <tr>
            <td colspan="6" style="text-align: left;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 21px; text-align: center;">
                <asp:GridView ID="gvView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    Visible="false" CellPadding="5" CssClass="mGrid" DataKeyNames="friendid" EmptyDataText="Result is not available."
                    GridLines="None" PageSize="5" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="friendid" HeaderText="ID" Visible="false">
                            <HeaderStyle HorizontalAlign="Left" Width="30%" />
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Fullname" HeaderText="Name">
                            <HeaderStyle HorizontalAlign="Left" Width="30%" />
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="usrMobileNo" HeaderText="Mobile No.">
                            <HeaderStyle HorizontalAlign="Left" Width="30%" />
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RoleName" HeaderText="Role">
                            <HeaderStyle HorizontalAlign="left" Width="30%" />
                            <ItemStyle HorizontalAlign="left" Width="30%" />
                        </asp:BoundField>
                    </Columns>
                    <RowStyle CssClass="row" HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <PagerStyle CssClass="pager-row" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="height: 21px; text-align: center;" colspan="6">
                &nbsp;
                <asp:Button ID="Button4" runat="server" CssClass="button" Text="Back" />
                &nbsp;<asp:Label ID="Label10" runat="server" Visible="false"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
