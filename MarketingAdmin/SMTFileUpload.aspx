<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="SMTFileUpload.aspx.cs" Inherits="SMTFileUpload"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%" border="1">
                <tr>
                    <td align="center">
                        <div style="width: 70%">
                            <table cellpadding="0" cellspacing="0" border="0" class="tables" style="width: 98%;
                                height: 332px">
                                <tr>
                                    <td style="height: 20px;">
                                        <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;">
                                        <table style="width: 97%; height: 148px;" class="tblAdminSubFull1" cellspacing="0px">
                                            <tr>
                                                <td colspan="4" style="height: 20px">
                                                    <asp:Label ID="lblHeader" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Upload File"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left;" colspan="4">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: left;">
                                                    <asp:Label ID="lblurl" runat="server" Text="URL Name"></asp:Label>
                                                </td>
                                                <td colspan="2" style="text-align: left;">
                                                    <asp:TextBox ID="txturlName" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="Label3" runat="server" Text="Select file to upload: "></asp:Label>
                                                </td>
                                                <td style="text-align: left;" colspan="2">
                                                    <asp:FileUpload ID="myFile" runat="server" />
                                                </td>
                                                <td style="text-align: left;">
                                                    <asp:Label ID="lblError" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3">
                                                    <asp:Button ID="btnUpload" runat="server" CssClass="button" OnClick="btnUpload_Click"
                                                        Text="Upload File" />
                                                    &nbsp;<asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
                                                        Text="Cancel" />
                                                    &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="button" 
                                                        OnClick="btnBack_Click" Text="Back" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: left;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                     <asp:GridView ID="gvUser" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                        CellPadding="5" CellSpacing="0" CssClass="mGrid" EmptyDataText="Not Uploaded any File"
                                                        GridLines="None" Width="100%">
                                                        <Columns>
                                                         <asp:BoundField DataField="Id" HeaderText="Id">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%" />
                                                                <ItemStyle HorizontalAlign="left" Width="30%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="username" HeaderText="Name">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%" />
                                                                <ItemStyle HorizontalAlign="left" Width="30%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="usrMobileNo" HeaderText="ContactNo">
                                                                <HeaderStyle HorizontalAlign="left" Width="15%" />
                                                                <ItemStyle HorizontalAlign="left" Width="15%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FileName" HeaderText="File Name">
                                                                <HeaderStyle HorizontalAlign="left" Width="20%" />
                                                                <ItemStyle HorizontalAlign="left" Width="20%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Committee_url" HeaderText="URL">
                                                                <HeaderStyle HorizontalAlign="left" Width="50%" />
                                                                <ItemStyle HorizontalAlign="left" Width="50%" />
                                                            </asp:BoundField>
                                                           <%--  <asp:TemplateField HeaderText="Modify">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%#Bind("Id")%>'
                                                                        CommandName="Modify" ImageUrl="../resources1/images/ico_yes1.gif" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>--%>
                                                        </Columns>
                                                        <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <PagerStyle CssClass="pager-row" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                         
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                                
                             
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                               
                            </table>
                       
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
            <%--   <asp:AsyncPostBackTrigger ControlID="GridUpload" EventName="">--%>
           
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>