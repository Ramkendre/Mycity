<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master"
    AutoEventWireup="true" CodeFile="AddGroup.aspx.cs" Inherits="MarketingAdmin_AddGroup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
                                        <table style="width: 97%; height: 290px;" class="tblAdminSubFull1" cellspacing="0px">
                                            <tr>
                                                <td align="center" colspan="3">
                                                    <asp:Label ID="lblHeader" runat="server" Text="Add New Group Item" Font-Bold="True"
                                                        Font-Size="X-Large"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    &nbsp;&nbsp;<asp:Label ID="lblError" runat="server" CssClass="error" Text="Label"
                                                        Visible="false"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left">
                                                    <asp:Label ID="Label8" runat="server" CssClass="lbl" Text="Main Group. :"></asp:Label>
                                                    <asp:Label ID="Label9" runat="server" Text="*" Width="2" CssClass="lblStar"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:DropDownList ID="ddlGroup" runat="server" Width="150px" AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                               <%-- <td style="text-align: left">
                                                    <asp:TextBox ID="txtId" runat="server" onblur="ChangeCSS(this, event)" onfocus="ChangeCSS(this, event)"
                                                        Visible="False" Width="140px"></asp:TextBox>
                                                </td>--%>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left">
                                                    <asp:Label ID="lblGroupItem" runat="server" CssClass="lbl" Text="Item Name :"></asp:Label>
                                                    <asp:Label ID="Label14" runat="server" Text="*" Width="2" CssClass="lblStar"></asp:Label>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="txtGroupValue" runat="server" Height="18px" Width="100px" onfocus="ChangeCSS(this, event)"
                                                        onblur="ChangeCSS(this, event)"></asp:TextBox>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtGroupValue"
                                                        ValidationGroup="vgNewFriRelReg" runat="server" ErrorMessage="* First Name Required"
                                                        Display="None"></asp:RequiredFieldValidator>
                                                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator2">
                                                    </asp:ValidatorCalloutExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: left; margin-left: 40px;">
                                                    <asp:Button ID="btnSubmit" runat="server" CssClass="button" OnClick="btnSubmit_Click"
                                                        Text="Submit" Width="86px" />
                                                    &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" 
                                                        onclick="btnCancel_Click" />
                                                        &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="button" Text="Back" 
                                                            onclick="btnBack_Click" />
                                                </td>
                                                <td style="text-align: left">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <div class="grid" style="width: 70%">
                                            <div class="rounded">
                                                <div class="top-outer">
                                                    <div class="top-inner">
                                                        <div class="top">
                                                            &nbsp;
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="mid-outer">
                                                    <div class="mid-inner">
                                                        <div class="mid">
                                                            <div class="pager">
                                                                <asp:GridView ID="gvData" runat="server" Width="100%" AutoGenerateColumns="False"
                                                                    OnRowCommand="gvData_RowCommand" CssClass="mGrid" AllowPaging="true" 
                                                                    PageSize="10" onrowdatabound="gvData_RowDataBound" 
                                                                    onrowediting="gvData_RowEditing">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="No" HeaderText="Sr No" SortExpression="No">
                                                                            <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="GroupValueName" HeaderText="Group Name" SortExpression="GroupValue">
                                                                            <HeaderStyle HorizontalAlign="Left" Width="70%"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left" Width="70%"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="Modify" ItemStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <%--<asp:Button ID="btn" Text="Modify" CssClass="button" CommandName="Modify" CommandArgument='<%#Eval("GroupValueId") %>'
                                                                    runat="server" />--%>
                                                                                
                                                                                    <asp:ImageButton ID="btn" CommandArgument='<%#Eval("GroupValueId") %>' runat="server"
                                                                    ImageUrl="../resources1/images/ico_yes1.gif" CommandName="Modify"></asp:ImageButton>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Width="5%" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="bottom-outer">
                                                    <div class="bottom-inner">
                                                        <div class="bottom">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
