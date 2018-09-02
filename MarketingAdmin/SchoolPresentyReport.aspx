<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="SchoolPresentyReport.aspx.cs" Inherits="MarketingAdmin_SchoolPresentyReport"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <center>
                    <div style="border: 1px solid black">
                        <table class="tables" width="80%">
                            <tr>
                                <td>
                                    <div>
                                        <h3 style="text-align: center">
                                            School Presenty Average Report
                                        </h3>
                                    </div>
                                    <div>
                                        <table width="100%">
                                            <tr>
                                                <td align="left">
                                                    Total School Register :<asp:Label ID="lblRegSchool" runat="server" Text="" ForeColor="red"></asp:Label></td>
                                                <td align="right">
                                                    Total School Presentry Sent :<asp:Label ID="lblReportSchool" runat="server" Text=""
                                                        ForeColor="red"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div>
                                        <center>
                                            <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                BorderColor="#DEDFDE" BorderWidth="1px" ForeColor="Black" GridLines="Vertical"
                                                EmptyDataText="No Data Found" ToolTip="Details of Items" PageSize="25" AllowPaging="true"
                                                onpageindexchanging="gvItem_PageIndexChanging">
                                                <RowStyle BackColor="#F7F7DE" Height="30px" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="SchoolCode" HeaderText="SchoolCode">
                                                        <HeaderStyle HorizontalAlign="Center" Width="110px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="usrMobileNo" HeaderText="MobileNo">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="usrFirstName" HeaderText="FirstName">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="usrLastName" HeaderText="LastName">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RegBoys" HeaderText="R_B">
                                                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="PresentBoys" HeaderText="P_B">
                                                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RegGirls" HeaderText="R_G">
                                                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="PresentGirls" HeaderText="P_G">
                                                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Boys %" ItemStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPerBoy" runat="server" Text=""></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Girls %" ItemStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPerGirls" runat="server" Text=""></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="School %" ItemStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAllStud" runat="server" Text=""></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#CCCC99" />
                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#009999" Font-Bold="True" Font-Size="1.1em" ForeColor="White"
                                                    Height="30px" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </center>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </center>
            </td>
        </tr>
    </table>
</asp:Content>
