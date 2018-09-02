<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="UploadMLAFile.aspx.cs" Inherits="MarketingAdmin_UploadMLAFile" Title="Untitled Page" %>

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
                                        Upload Committee Files </h3>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Select File Upload Commitee
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUploadCenter" runat="server"  CssClass="ddlcss" OnSelectedIndexChanged="ddlUploadCenter_SelectedIndexChanged">
                                  
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Enter The month and Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtSubject" runat="server" CssClass="txtcss"></asp:TextBox>e.g Sept13, Oct13,...
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
                                        <asp:Button ID="btnUploadFile" runat="server" Text="Upload" CssClass="btn" OnClick="btnUploadFile_Click" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" OnClick="btnCancel_Click" />
                                    </fieldset>
                                    <br />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <center>
                                    <div style="margin-bottom: 20px; margin-top: 20px; border: 1px solid #2F4F4F; height: auto;
                                        width: 502px;">
                                        <asp:GridView ID="gvToday" runat="server" AutoGenerateColumns="False" BackColor="White"
                                            BorderColor="#DEDFDE" BorderWidth="1px" DataKeyNames="Id" ForeColor="Black" GridLines="Vertical"
                                            Width="500px" EmptyDataText="No Data Found" ToolTip="Details of Items">
                                            <RowStyle BackColor="#F7F7DE" Height="40px" />
                                            <Columns>
                                                <asp:BoundField DataField="Id" HeaderText="Id">
                                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Committee_name" HeaderText="Committee Name">
                                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Committee_url" HeaderText="Committee_url">
                                                    <HeaderStyle HorizontalAlign="Center" Width="250px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="250px" Font-Bold="true" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FileName" HeaderText="File Name" >
                                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="200px" Font-Bold="true" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle BackColor="#CCCC99" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#009999" Font-Bold="True" Font-Size="14px" ForeColor="White"
                                                Height="30px" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </div>
                                </center>
                            </td>
                        </tr>
                    </table>
                </center>
            </td>
        </tr>
    </table>
</asp:Content>
