<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="AddJuniors.aspx.cs" Inherits="MarketingAdmin_AddJuniors" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%" border="1" align="center">
        <tr>
            <td style="text-align: center">
                <div id="selectlevel" runat="server">
                    <table cellpadding="0" cellspacing="0" width="70%" align="center" style="height: 41px">
                        <tr>
                            <td style="text-align: center" colspan="2">
                                <asp:Label ID="lbl1" runat="server" Text="Add Juniors"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left" colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left" class="Error" colspan="2">
                                <asp:Label ID="lblerror" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                                <asp:RadioButton ID="rdb1" runat="server" Text="Sub Level" GroupName="Set" OnCheckedChanged="rdb1_CheckedChanged"
                                    AutoPostBack="True" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                                <asp:RadioButton ID="rdb2" runat="server" Text="Same / Subordinate Level" GroupName="Set"
                                    OnCheckedChanged="rdb2_CheckedChanged" AutoPostBack="True" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblfname" runat="server" Text="Select Your Main Role"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlrole" CssClass="ddlcss" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlrole_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left" colspan="2">
                                <div id="getmobile" runat="server" visible="false">
                                    <center>
                                        <table>
                                            <tr>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lbllocation" Text="Enter Your Area/Place/Location" runat="server"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtplace" CssClass="txtcss" MaxLength="10" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="lblmobileno" runat="server" Text="MobileNo"></asp:Label>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtmobileno" runat="server" CssClass="txtcss" MaxLength="10" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                                    &nbsp;<asp:Button ID="btnSearch" runat="server" CssClass="button" OnClick="btnSearch_Click"
                                                        Text="Search" />
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="height: 24px" colspan="2">
                                <asp:Panel ID="pnl_grade" runat="server" BackColor="White" Visible="false">
                                    <table cellspacing="0px" class="tables" style="width: 100%" align="center">
                                        <tr>
                                            <td style="text-align: left; width: 248px">
                                                <asp:Label ID="lblName1" runat="server" CssClass="tdLabelInner" Text="Name"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblName" runat="server" CssClass="tdLabelInner" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; width: 248px">
                                                <asp:Label ID="lblCelNumber1" runat="server" Text="Mobile No" CssClass="tdLabelInner"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblCelNumber" runat="server" Text="" CssClass="tdLabelInner"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; width: 248px">
                                                <asp:Label ID="lblCity1" runat="server" Text="City" CssClass="tdLabelInner"></asp:Label>
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblCity" runat="server" Text="" CssClass="tdLabelInner"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; width: 248px">
                                                &nbsp;
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Button ID="btnSubmit" runat="server" CssClass="button" OnClick="btnSubmit_Click"
                                                    Text="Submit" />
                                                &nbsp;
                                                <asp:Button ID="btncancel" runat="server" CssClass="button" OnClick="btncancel_Click"
                                                    Text="Cancel" />
                                                &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="button" OnClick="btnBack_Click"
                                                    Text="Back" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="height: 44px" colspan="2">
                                                <asp:GridView ID="gvdisplay" runat="server" Width="100%" CssClass="mGrid" CellPadding="5"
                                                    Visible="false" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                                    EmptyDataText="Result is not available." PageSize="5" DataKeyNames="friendid"
                                                    OnPageIndexChanging="gvdisplay_PageIndexChanging" Height="126px" OnRowCommand="gvdisplay_RowCommand">
                                                    <Columns>
                                                        <asp:BoundField DataField="friendid" HeaderText="ID" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Left" Width="30%" />
                                                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Fullname" HeaderText="Name">
                                                            <HeaderStyle HorizontalAlign="Left" Width="30%" />
                                                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="usrMobileNo" HeaderText="Mobile No.">
                                                            <HeaderStyle HorizontalAlign="Left" Width="30%" />
                                                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="RoleName" HeaderText="Role">
                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Location" HeaderText="Location">
                                                            <HeaderStyle HorizontalAlign="center" Width="30%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="center" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Active" HeaderText="Status">
                                                            <HeaderStyle HorizontalAlign="center" Width="30%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="center" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MainRole" HeaderText="MainRole">
                                                            <HeaderStyle HorizontalAlign="center" Width="30%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="center" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Active">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("Id")%>' runat="server"
                                                                    ImageUrl="~/resources1/images/ico_yes1.gif" CommandName="Active"></asp:ImageButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Deactive">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton5" CommandArgument='<%#Bind("Id")%>' runat="server"
                                                                    ImageUrl="~/resources1/images/ico_yes1.gif" CommandName="Deactive"></asp:ImageButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Modify">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("Id")%>' runat="server"
                                                                    ImageUrl="~/resources1/images/ico_yes1.gif" CommandName="Modify"></asp:ImageButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <PagerStyle CssClass="pager-row" />
                                                </asp:GridView>
                                                <asp:GridView ID="gvsubordinat" runat="server" Width="100%" CssClass="mGrid" CellPadding="5"
                                                    Visible="false" GridLines="None" AutoGenerateColumns="False" AllowPaging="True"
                                                    EmptyDataText="Result is not available." PageSize="5" DataKeyNames="friendid"
                                                    OnPageIndexChanging="gvsubordinat_PageIndexChanging" OnRowCommand="gvsubordinat_RowCommand">
                                                    <Columns>
                                                        <asp:BoundField DataField="friendid" HeaderText="ID" Visible="false">
                                                            <HeaderStyle HorizontalAlign="Left" Width="30%" />
                                                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Fullname" HeaderText="Name">
                                                            <HeaderStyle HorizontalAlign="Left" Width="30%" />
                                                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="usrMobileNo" HeaderText="Mobile No.">
                                                            <HeaderStyle HorizontalAlign="Left" Width="30%" />
                                                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="RoleName" HeaderText="Role">
                                                            <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Location" HeaderText="Location">
                                                            <HeaderStyle HorizontalAlign="center" Width="30%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="center" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Active" HeaderText="Status">
                                                            <HeaderStyle HorizontalAlign="center" Width="30%"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="center" Width="30%"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Active">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("Id")%>' runat="server"
                                                                    ImageUrl="~/resources1/images/ico_yes1.gif" CommandName="Active"></asp:ImageButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Deactive">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton3" CommandArgument='<%#Bind("Id")%>' runat="server"
                                                                    ImageUrl="~/resources1/images/ico_yes1.gif" CommandName="Deactive"></asp:ImageButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Modify">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("Id")%>' runat="server"
                                                                    ImageUrl="~/resources1/images/ico_yes1.gif" CommandName="Modify"></asp:ImageButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <PagerStyle CssClass="pager-row" />
                                                </asp:GridView>
                                                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                                &nbsp;
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
</asp:Content>
