    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="UdiscceAdharExcelUpload.aspx.cs"
        Inherits="Student_UdiscceAdharExcelUpload" MasterPageFile="~/Master/MarketingMaster.master" %>

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="ContentPlaceHolder1">
        <style type="text/css">
            .UploadBackground
            {
                background: #e4b2b0;
                text-align: center;
                color: Black;
            }
        </style>
        <table style="width: 90%" cellspacing="1" cellpadding="1" class="icon-file">
            <tr class="UploadBackground">
                <td align="left">
                    <asp:Label ID="lblup2" runat="server" Text="Upload Database File : " class="label1"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="U2" runat="server">
                        <ContentTemplate>
                            <asp:FileUpload ID="databasefile" runat="server" Width="212px"  />
                            <%-- <div>
                                                                                                 <asp:Image ID="img1" runat="server" src="../resources/Images/image1.jpg" Visible="false" />
                                                                                                 </div>--%>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnUpload" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload File"
                        CssClass="btn" Width="130px" />
                </td>
                 <td>
                    <asp:Button ID="btnAddNew" runat="server" Text="Add New Records" CssClass="btn" 
                        onclick="btnAddNew_Click" Width="130px" />
                </td>
            </tr>
            
            <tr class="UploadBackground">
                <td align="left">
                    <asp:Label ID="lblReplace" runat="server" Text="Replace Selected : " class="label1"></asp:Label>
                </td>
                <td>
                 <asp:DropDownList ID="ddlAdmission" runat="server" CssClass="ddlcsswidth" Width="200px" 
                        style="margin-left: 0px" />
                </td>
                <td>
                                     
                    <asp:Button ID="btnReplace" runat="server" Text="Replace Selected" CssClass="btn" Width="130px" />
                </td>
                 <td>
                    <asp:Button ID="btnReplaceAll" runat="server" Text="Replace All Records" 
                        CssClass="btn" onclick="btnReplaceAll_Click" Width="130px" />
                </td>
            </tr>
        </table>
    </asp:Content>
