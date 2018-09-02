<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="Definegroup.aspx.cs" Inherits="html_Definegroup" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="MainDiv">
        <div class="InnerDiv">
            <table class="tblSubFull2">
                <tr>
                    <td>
                        <center>
                            <br />
                            <img src="../KResource/Images/GroupsImg.png" width="30px" height="30px" alt="" /> <span class="spanTitle">Define Group</span>
                            <br />
                        </center>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="gvgroup" runat="server" AutoGenerateColumns="False" OnRowCommand="gvgroup_RowCommand"
                            BackColor="White">
                            <Columns>
                                <asp:TemplateField HeaderText="Group">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGroupId" runat="server" Text='<%#Eval("Groupid") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Group Name">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGroupName" MaxLength="20" CssClass="ccstxt" runat="server" Text='<%#Eval("GroupName") %>'></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Button ID="btn_save" runat="server" Text="Update" OnClick="btn_save_Click" CssClass="cssbtn" />
                        <br />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
