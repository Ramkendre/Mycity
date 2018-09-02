<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="Blogs.aspx.cs" Inherits="Html_Blogs" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="MainDiv">
                <div class="InnerDiv">
                    <table class="tblSubFull2">
                        <tr>
                            <td colspan="2" align="center">
                                <span class="spanTitle">MYCT.IN BLOGS </span>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Select your group :
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlGroupNm" runat="server" AutoPostBack="true" CssClass="cssddlwidth"
                                    OnSelectedIndexChanged="ddlGroupNm_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvBlogData" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                            AutoGenerateColumns="False" CssClass="gridview" OnRowUpdated="gvBlogData_RowUpdated"
                                            PageSize="7">
                                            <Columns>
                                                <asp:BoundField DataField="bgId" HeaderText="Blog No" Visible="false">
                                                    <HeaderStyle Width="15px" />
                                                    <ItemStyle Width="15px" />
                                                </asp:BoundField>
                                                <asp:ImageField HeaderText="Image" DataImageUrlField="photo">
                                                    <ControlStyle Height="80px" Width="70px" />
                                                </asp:ImageField>
                                                <asp:BoundField DataField="BgWriter" HeaderText="Blog Writer">
                                                    <HeaderStyle Width="20px" />
                                                    <ItemStyle Width="20px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="BgDate" HeaderText="Date">
                                                    <HeaderStyle Width="20px" />
                                                    <ItemStyle Width="20px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Bg" HeaderText="Blog" />
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text="Like"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkAggri" runat="server" Text='<%# Bind("aggri") %>' AutoPostBack="true"
                                                            OnCheckedChanged="chkAggri_OnCheckedChanged" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="15px" />
                                                    <ItemStyle Width="15px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text="DisLike"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkNotAggri" runat="server" Text='<%# Bind("notAggri") %>' AutoPostBack="true"
                                                            OnCheckedChanged="chkNotAggri_OnCheckedChanged" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="15px" />
                                                    <ItemStyle Width="15px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlGroupNm" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
