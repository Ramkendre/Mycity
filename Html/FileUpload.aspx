<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="FileUpload.aspx.cs" Inherits="html_FileUpload" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="MainDiv">
                <div class="InnerDiv">
                    <center>
                        <table class="tblSubFull2">
                            <tr>
                                <td>
                                <center>
                                    <img src="../KResource/Images/FileImg.png" width="40px" height="20px"/> <span class="spanTitle">  File Upload </span>
                                </center>
                                   
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="height: 25px; width: 744px;">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div align="center" style="width: 100%">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Select File to upload:" CssClass="lbl"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:FileUpload ID="myFile" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnUpload" runat="server" Text="Upload File" OnClick="btnUpload_Click"
                                                        CssClass="cssbtn" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblError" runat="server"></asp:Label>
                                                    <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="GridUpload" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                        CellPadding="5" CellSpacing="0" EmptyDataText="Not uploaded any file" GridLines="Both" CssClass="gridview"
                                                        PageSize="5" Width="100%" OnRowCommand="GridUpload_RowCommand" DataKeyNames="actual_filename"
                                                        OnPageIndexChanging="GridUpload_PageIndexChanging" OnRowDeleting="GridUpload_RowDeleting">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Id" DataField="id" Visible="false">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="Date" DataField="upload_date">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="FileName" DataField="actual_filename">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="Link" DataField="url_link">
                                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btndwnfrnd" runat="server" Text="Select group to send link" CommandName="Download"
                                                                        CssClass="cssbtn" CommandArgument='<%#Bind("id") %>' />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton4" runat="server" CommandArgument='<%#Bind("id") %>'
                                                                        CommandName="Delete" ImageUrl="~/resources1/images/close.gif" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <PagerStyle CssClass="pager-row" />
                                                    </asp:GridView>
                                                    <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div id="Groupname" runat="server" visible="false" align="center" style="width: 100%">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblfilename" runat="server" Text="" Visible="false" CssClass="lbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbldownloadfrnd" runat="server" CssClass="lbl"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblgrpname" runat="server" Text="Select Group Name" CssClass="lbl"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="drpdownfrnd" runat="server">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1">FR1</asp:ListItem>
                                                        <asp:ListItem Value="2">FR2</asp:ListItem>
                                                        <asp:ListItem Value="3">FR3</asp:ListItem>
                                                        <asp:ListItem Value="4">FR4</asp:ListItem>
                                                        <asp:ListItem Value="5">FR5</asp:ListItem>
                                                        <asp:ListItem Value="6">FR6</asp:ListItem>
                                                        <asp:ListItem Value="7">FR7</asp:ListItem>
                                                        <asp:ListItem Value="8">FR8</asp:ListItem>
                                                        <asp:ListItem Value="9">FR9</asp:ListItem>
                                                        <asp:ListItem Value="10">FR10</asp:ListItem>
                                                        <asp:ListItem Value="11">FR11</asp:ListItem>
                                                        <asp:ListItem Value="12">FR12</asp:ListItem>
                                                        <asp:ListItem Value="13">FR13</asp:ListItem>
                                                        <asp:ListItem Value="14">FR14</asp:ListItem>
                                                        <asp:ListItem Value="15">FR15</asp:ListItem>
                                                        <asp:ListItem Value="16">FR16</asp:ListItem>
                                                        <asp:ListItem Value="17">FR17</asp:ListItem>
                                                        <asp:ListItem Value="18">FR18</asp:ListItem>
                                                        <asp:ListItem Value="19">FR19</asp:ListItem>
                                                        <asp:ListItem Value="20">FR20</asp:ListItem>
                                                        <asp:ListItem Value="21">FR21</asp:ListItem>
                                                        <asp:ListItem Value="22">FR22</asp:ListItem>
                                                        <asp:ListItem Value="23">FR23</asp:ListItem>
                                                        <asp:ListItem Value="24">FR24</asp:ListItem>
                                                        <asp:ListItem Value="25">FR25</asp:ListItem>
                                                        <asp:ListItem Value="26">FR26</asp:ListItem>
                                                        <asp:ListItem Value="27">FR27</asp:ListItem>
                                                        <asp:ListItem Value="28">FR28</asp:ListItem>
                                                        <asp:ListItem Value="29">FR29</asp:ListItem>
                                                        <asp:ListItem Value="30">FR30</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btndownload" runat="server" Text="Send link to download" OnClick="btndownload_Click"
                                                        Style="height: 26px" CssClass="cssbtn" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="cssbtn" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </center>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
            <asp:PostBackTrigger ControlID="GridUpload" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
