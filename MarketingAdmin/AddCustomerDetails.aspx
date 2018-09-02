<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true" CodeFile="AddCustomerDetails.aspx.cs" Inherits="MarketingAdmin_AddCustomerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%" border="1">
        <tr>
            <td align="center" style="height: 28px">
                <asp:Label ID="lblHeader" runat="server" Text="Add Customer details" Font-Bold="True"
                    Font-Size="X-Large"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width: 97%; height: 100px;" class="tblAdminSubFull1">
          <tr>
            <td style="width: 348px" align="center">
                <asp:Label ID="lblError" runat="server" Text="" Visible="false" ForeColor="#009900" Font-Size="Larger"></asp:Label>
            </td>
            <td style="width: 348px">
              
            </td>
        </tr>
        <tr>
            <td style="width: 348px" align="right">
                Select Excel File:
            </td>
            <td style="width: 348px">
                <asp:FileUpload ID="MarketnigAddCustm" runat="server" />
            </td>
        </tr>
        <tr>

             <td style="width: 348px" align="right">
               <asp:Button ID="btnExcelDwnloadfrmt" runat="server" Text="Download Excel Format" CssClass="button" OnClick="btnExcelDwnloadfrmt_Click" />
            </td>
            <td style="width: 348px">
               <asp:Button ID="btnExcelUpload" runat="server" Text="Submit" CssClass="button" OnClick="btnExcelUpload_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

