<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="demofileupload.aspx.cs" Inherits="html_demofileupload" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:FileUpload ID="myFile" runat="server" />
                    </td>
                </tr>
               <%-- <tr>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </tr>--%>
                <tr>
                    <td>
                        <asp:Button ID="btnUpload" runat="server" Text="Upload File" OnClick="btnUpload_Click" />
                    </td>
                    <td>
                        <asp:Label ID="lblError" runat="server"></asp:Label>
                        <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
