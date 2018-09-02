<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="UDISEGetTotalReportByRoleId.aspx.cs" Inherits="MarketingAdmin_UDISEGetTotalReportByRoleId"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div style="margin-top: 30px">
            <center>
                <table cellpadding="0" cellspacing="0" width="100%" border="1" class="tables">
                    <tr>
                        <td align="center">
                            <%--distinct(MobileNo),UserMaster.usrFirstName,UserMaster.usrLastName,AdminSubMarketingSubUser.rolename,TotalRegBoys,TotalRegGirls,TotalPresent_B,TotlalPresent_G--%>
                            <center>
                                <div>
                                    <div style="margin-top: 30px">
                                        <span style="font-size: 15px; font-weight: bold">UDISE Get Total Report</span><br />
                                    </div>
                                    <div style="font-family: Calibri; margin-top: 30px; margin-bottom: 30px">
                                        <table cellpadding="0" cellspacing="0" width="80%" class="tables">
                                            <tr>
                                                <td>
                                                    Select Under Role
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlRoleName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRoleName_SelectedIndexChanged">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="14">Secretary</asp:ListItem>
                                                        <asp:ListItem Value="15">Depty Secretary</asp:ListItem>
                                                        <asp:ListItem Value="16">Director Of Education</asp:ListItem>
                                                        <asp:ListItem Value="17">Deputy Director</asp:ListItem>
                                                        <asp:ListItem Value="18">Education Officer</asp:ListItem>
                                                        <asp:ListItem Value="19">Deputy Education Officer</asp:ListItem>
                                                        <asp:ListItem Value="20">Block Education Officer</asp:ListItem>
                                                        <asp:ListItem Value="21">Extenion Officer</asp:ListItem>
                                                        <asp:ListItem Value="75">Cluster Head</asp:ListItem>
                                                        <asp:ListItem Value="76">Head Master</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <%-- <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="button" OnClick="btnSearch_Click" />--%>
                                                    <asp:Button ID="btnExcel" runat="server" Text="Download To Excel" CssClass="button"
                                                        OnClick="btnExcel_Click" />
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="margin-left:30px">
                                        <table>
                                            <tr>
                                                <td>
                                                    Secretary
                                                </td>
                                                <td>
                                                    <span style="color: Green">
                                                        <asp:Label ID="lblSecretary" runat="server" Text=""></asp:Label></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Depty Secretary
                                                </td>
                                                <td>
                                                    <span style="color: Green">
                                                        <asp:Label ID="lblDeptySec" runat="server" Text=""></asp:Label></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Director of Education
                                                </td>
                                                <td>
                                                    <span style="color: Green">
                                                        <asp:Label ID="lblDirectorEdu" runat="server" Text=""></asp:Label></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Deputy Director
                                                </td>
                                                <td>
                                                    <span style="color: Green">
                                                        <asp:Label ID="lblDeputyDir" runat="server" Text=""></asp:Label></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Education Officer
                                                </td>
                                                <td>
                                                    <span style="color: Green">
                                                        <asp:Label ID="lblEducationOff" runat="server" Text=""></asp:Label></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Deputy Education Officer
                                                </td>
                                                <td>
                                                    <span style="color: Green">
                                                        <asp:Label ID="lblDeputyOff" runat="server" Text=""></asp:Label></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Block Education Officer
                                                </td>
                                                <td>
                                                    <span style="color: Green">
                                                        <asp:Label ID="lblBlockOff" runat="server" Text=""></asp:Label></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Extention Officer
                                                </td>
                                                <td>
                                                    <span style="color: Green">
                                                        <asp:Label ID="lblExtentionOff" runat="server" Text=""></asp:Label></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Cluster Head
                                                </td>
                                                <td>
                                                    <span style="color: Green">
                                                        <asp:Label ID="lblClusterHea" runat="server" Text=""></asp:Label></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Head Master
                                                </td>
                                                <td>
                                                    <span style="color: Green">
                                                        <asp:Label ID="lblHeadMas" runat="server" Text=""></asp:Label></span>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="margin-top: 20px;">
                                        <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" PageSize="10"
                                            AllowPaging="true" OnPageIndexChanging="gvItem_PageIndexChanging" OnRowCommand="gvItem_RowCommand">
                                            <RowStyle BackColor="#F7F7DE" Height="30px" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="60px">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="MobileNo" HeaderText="MobileNo"></asp:BoundField>
                                                <asp:BoundField DataField="usrAutoId" HeaderText="MobileNo" Visible="false"></asp:BoundField>
                                                <asp:BoundField DataField="usrFirstName" HeaderText="First Name"></asp:BoundField>
                                                <asp:BoundField DataField="usrLastName" HeaderText="Last Name"></asp:BoundField>
                                                <asp:BoundField DataField="rolename" HeaderText="Role  Name"></asp:BoundField>
                                                <asp:BoundField DataField="TotalReporty" HeaderText="School"></asp:BoundField>
                                                <asp:BoundField DataField="TotalRegBoys" HeaderText="Total Boys"></asp:BoundField>
                                                <asp:BoundField DataField="TotalRegGirls" HeaderText="Total Girls"></asp:BoundField>
                                                <asp:BoundField DataField="TotalPresent_B" HeaderText="Present Boys"></asp:BoundField>
                                                <asp:BoundField DataField="TotlalPresent_G" HeaderText="Present Girls"></asp:BoundField>
                                                <asp:TemplateField HeaderText="Boys %">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPerBoy" runat="server" Text=""></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Girls %">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPerGirls" runat="server" Text=""></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ALL %">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAllStud" runat="server" Text=""></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Show">
                                                    <ItemStyle HorizontalAlign="left"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnExcel" runat="server" CommandArgument='<%#Bind("usrAutoId")%>'
                                                            CommandName="Show" Text="Show" CssClass="button" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#CCCC99" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#3d8c8f" Font-Bold="True" Font-Size="1.1em" ForeColor="White"
                                                Height="30px" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                        <asp:Panel ID="Panel1" runat="server" Visible="false">
                                            <asp:GridView ID="GridExcel" runat="server" AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="60px">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" ItemStyle-Width="100px">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="usrAutoId" HeaderText="MobileNo" ItemStyle-Width="100px"
                                                        Visible="false"></asp:BoundField>
                                                    <asp:BoundField DataField="usrFirstName" HeaderText="First Name" ItemStyle-Width="100px">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="usrLastName" HeaderText="Last Name" ItemStyle-Width="100px">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="rolename" HeaderText="Role  Name" ItemStyle-Width="100px">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TotalReporty" HeaderText="School" ItemStyle-Width="100px">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TotalRegBoys" HeaderText="Total Boys" ItemStyle-Width="100px">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TotalRegGirls" HeaderText="Total Girls" ItemStyle-Width="100px">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TotalPresent_B" HeaderText="Present Boys" ItemStyle-Width="100px">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TotlalPresent_G" HeaderText="Present Girls" ItemStyle-Width="100px">
                                                    </asp:BoundField>
                                                     <asp:TemplateField HeaderText="Boys %">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPerBoy1" runat="server" Text="0"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Girls %">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPerGirls1" runat="server" Text="0"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="All %">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAllStud1" runat="server" Text="0"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </center>
                        </td>
                    </tr>
                </table>
            </center>
        </div>
    </div>
</asp:Content>
