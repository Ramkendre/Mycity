<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="AddProgrames.aspx.cs" Inherits="MarketingAdmin_AddProgrames" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>

    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>

    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />
        
    <div id="dialog" style="display: none;">
        <asp:Panel ID="Panel1" runat="server" Style="height: 100%; width: 100%">
            <asp:GridView ID="gridview1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="EzeeDrugAppId">
                        <ItemTemplate>
                            <asp:Label ID="lblid1" runat="server" Font-Size="Small" Text='<%# Bind("EzeeDrugAppId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="keyword">
                        <ItemTemplate>
                            <asp:Label ID="lblid5" runat="server" Font-Size="Small" Text='<%# Bind("keyword") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="strSimSerialNo">
                        <ItemTemplate>
                            <asp:Label ID="lblid2" runat="server" Font-Size="Small" Text='<%# Bind("strSimSerialNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="firstName">
                        <ItemTemplate>
                            <asp:Label ID="lblid3" runat="server" Font-Size="Small" Text='<%# Bind("firstName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="lastName">
                        <ItemTemplate>
                            <asp:Label ID="lblid3" runat="server" Font-Size="Small" Text='<%# Bind("lastName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="firmName">
                        <ItemTemplate>
                            <asp:Label ID="lblid3" runat="server" Font-Size="Small" Text='<%# Bind("firmName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="mobileNo">
                        <ItemTemplate>
                            <asp:Label ID="lblid3" runat="server" Font-Size="Small" Text='<%# Bind("mobileNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="address">
                        <ItemTemplate>
                            <asp:Label ID="lblid3" runat="server" Font-Size="Small" Text='<%# Bind("address") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>
    
    <div style="text-align: center;">
        <table>
            <tr>
                <td align="left">
                </td>
                <td align="right">
                    Total Download App :
                    <asp:HyperLink ID="hlCount" runat="server" NavigateUrl="Home.aspx"></asp:HyperLink>
                </td>
            </tr>
            <asp:Panel ID="pnlId" runat="server" Visible="false">
                <tr>
                    <td>
                    </td>
                    <td style="width: 208px" align="left">
                        ID :
                    </td>
                    <td align="left">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </asp:Panel>
            <tr>
                <td align="right">
                    Enter Programe Name:
                </td>
                <td align="left">
                    <asp:TextBox ID="txtProgName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Description:
                </td>
                <td align="left">
                    <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine" Height="80px"
                        Width="310px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="left">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:GridView ID="GvVMshow" runat="server" Width="532px" AutoGenerateColumns="False"
                        OnRowCommand="GvVMshow_RowCommand" OnRowDeleting="GVMshow_Rowdeleting" PageSize="5"                        
                        onpageindexchanged="GvVMshow_PageIndexChanged" AllowPaging="true"
                        onpageindexchanging="GvVMshow_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblid1" runat="server" Font-Size="Small" Text='<%# Bind("Progid") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Programe Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblid5" runat="server" Font-Size="Small" Text='<%# Bind("ProgName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                                    <asp:Label ID="lblid3" runat="server" Font-Size="Small" Text='<%# Bind("ProgDescription") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LastModifieddate">
                                <ItemTemplate>
                                    <asp:Label ID="lblid4" runat="server" Font-Size="Small" Text='<%# Bind("LastModifieddate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="button1" Text="Modify" runat="server" CommandName="Modify" CommandArgument='<%#Eval("Progid") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="button2" Text="Delete" runat="server" CommandName="Delete" CommandArgument='<%#Eval("Progid") %>'>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
