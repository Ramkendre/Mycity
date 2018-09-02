<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="UDISE_SetHirarchyChain.aspx.cs" Inherits="MarketingAdmin_UDISE_SetHirarchyChain"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <script type="text/javascript">
        function ConfirmationBox(username) {

            var result = confirm('Are you sure you want to delete ' + username + ' Details?');
            if (result) {

                return true;
            }
            else {
                return false;
            }
        }
    </script>

    <table cellpadding="0" cellspacing="0" width="100%" border="1">
        <tr>
            <td align="center">
                <div style="width: 100%">
                    <table cellpadding="0" cellspacing="0"  border="0" width="100%" class="tables">
                        <tr>
                            <td style="height: 20px;">
                                <span class="warning1" style="color: Red;"></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                                    <tr>
                                        <td colspan="6">
                                            <h3 style="text-align: center">
                                                <asp:Label ID="lblHeader" runat="server" Text="UDISE Shift Hirarchy Chain"></asp:Label>
                                            </h3>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="6">
                                            &nbsp;&nbsp;<asp:Label ID="lblError" Visible="False" runat="server" CssClass="error"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td valign="bottom">
                                            <asp:Label ID="Lblrole" CssClass="lbl" runat="server" Text="Select Under Role "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList CssClass="ddlcss" ID="ddlRoleName" runat="server" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlRoleName_SelectedIndexChanged">
                                                <%-- <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="14">Secretary</asp:ListItem>
                                                <asp:ListItem Value="15">Depty Secretary</asp:ListItem>
                                                <asp:ListItem Value="16">Director Of Education</asp:ListItem>
                                                <asp:ListItem Value="17">Deputy Director</asp:ListItem>
                                                <asp:ListItem Value="18">Education Officer</asp:ListItem>
                                                <asp:ListItem Value="19">Deputy Education Officer</asp:ListItem>
                                                <asp:ListItem Value="20">Block Education Officer</asp:ListItem>
                                                <asp:ListItem Value="21">Extenion Officer</asp:ListItem>
                                                <asp:ListItem Value="75">Cluster Head</asp:ListItem>
                                                <asp:ListItem Value="76">Head Master</asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList CssClass="ddlcss" ID="ddlmain" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlmain_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ControlToValidate="ddlmain" ID="RequiredFieldValidator7"
                                                ValidationGroup="g1" ErrorMessage="*" InitialValue="0" runat="server" Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" CssClass="lbl" runat="server" Text="Role "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList CssClass="ddlcss" ID="ddlOldLeaderRole" runat="server" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlOldLeaderRole_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ControlToValidate="ddlOldLeaderRole" ID="RequiredFieldValidator2"
                                                ValidationGroup="g1" ErrorMessage="*" InitialValue="0" runat="server" Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" CssClass="lbl" runat="server" Text="Role "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList CssClass="ddlcss" ID="ddlJoinUserRole" runat="server" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlJoinUserRole_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ControlToValidate="ddlJoinUserRole" ID="RequiredFieldValidator1"
                                                ValidationGroup="g1" ErrorMessage="*" InitialValue="0" runat="server" Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" CssClass="lbl" runat="server" Text="Role "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList CssClass="ddlcss" ID="ddlNewLeaderRole" runat="server" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlNewLeaderRole_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ControlToValidate="ddlNewLeaderRole" ID="RequiredFieldValidator3"
                                                ValidationGroup="g1" ErrorMessage="*" InitialValue="0" runat="server" Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" CssClass="lbl" runat="server" Text="to shift from"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList CssClass="ddlcss" ID="ddlOldLeader" runat="server" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlOldLeader_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ControlToValidate="ddlOldLeader" ID="RequiredFieldValidator5"
                                                ValidationGroup="g1" ErrorMessage="*" InitialValue="0" runat="server" Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" CssClass="lbl" runat="server" Text="a Person"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList CssClass="ddlcss" ID="ddlJoinUserRoleName" runat="server" OnSelectedIndexChanged="ddlJoinUserRoleName_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            &nbsp;<asp:RequiredFieldValidator ControlToValidate="ddlJoinUserRoleName" ID="RequiredFieldValidator4"
                                                ValidationGroup="g1" ErrorMessage="*" InitialValue="0" runat="server" Display="Dynamic">
                                            </asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:Label ID="Label5" CssClass="lbl" runat="server" Text="Under"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList CssClass="ddlcss" ID="ddlNewLeader" runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ControlToValidate="ddlNewLeader" ID="RequiredFieldValidator6"
                                                ValidationGroup="g1" ErrorMessage="*" InitialValue="0" runat="server" Display="Dynamic">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="bottom">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td colspan="3">
                                            <asp:Button ID="btnsave" runat="server" CssClass="btn" Text="Shift" OnClick="btnsave_Click"
                                                ValidationGroup="g1" />
                                            &nbsp;
                                            <asp:Button ID="btncancle" runat="server" CssClass="btn" Text="Cancel" OnClick="btncancle_Click" />
                                            &nbsp;
                                            <asp:Button ID="btnback" runat="server" CssClass="btn" Text="Back" PostBackUrl="~/MarketingAdmin/MenuMaster1.aspx?pageid=2" />
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <div   class="grid" style="width: 90%">
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
                                                        <asp:GridView ID="gvlist"  runat="server" Width="100%" CssClass="datatable" CellPadding="5"
                                                            CellSpacing="0" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                                            EmptyDataText="Record not available." PageSize="10" OnPageIndexChanging="gvlist_PageIndexChanging"
                                                            OnRowCommand="gvlist_RowCommand" OnRowDataBound="gvlist_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="60px" >
                                                                    <ItemTemplate  >
                                                                        <%# Container.DataItemIndex + 1 %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:BoundField DataField="TreeID" HeaderText="Id" Visible="false">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="id" HeaderText="Id" Visible="false">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="usrmobileno" HeaderText="MobileNo">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="usrFirstName" HeaderText="First Name">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="usrLastName" HeaderText="Last Name">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="rolename" HeaderText="Role  Name">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="40%" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="40%" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Remove">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%#Bind("TreeID")%>'
                                                                            CommandName="Modify" ImageUrl="../resources1/images/ico_yes1.gif" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <PagerStyle CssClass="pager-row" />
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
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Panel ID="pnlhide" runat="server">
                                    <table>
                                        <tr>
                                            <td align="center">
                                                <asp:TreeView ID="TreeView1" runat="server" ExpandDepth="0" OnTreeNodePopulate="TreeView1_TreeNodePopulate"
                                                    PopulateNodesFromClient="true" ShowExpandCollapse="true" ShowLines="true" >
                                                    <ParentNodeStyle ChildNodesPadding="2px" Font-Bold="True" Font-Size="Medium" 
                                                        Font-Underline="True" ForeColor="#FF0066" />
                                                    <HoverNodeStyle BorderStyle="Solid" />
                                                    <SelectedNodeStyle Font-Bold="True" ForeColor="#FF66CC" />
                                                    <RootNodeStyle Font-Bold="True" Font-Size="Medium" Font-Underline="True" 
                                                        ForeColor="Red" />
                                                    <NodeStyle ChildNodesPadding="2px" Font-Bold="True" Font-Size="Small" 
                                                        ForeColor="#4A6F00" />
                                                    <LeafNodeStyle Font-Bold="True" Font-Underline="True" />
                                                </asp:TreeView>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
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
