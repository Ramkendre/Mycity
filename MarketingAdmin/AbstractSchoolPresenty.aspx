<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="AbstractSchoolPresenty.aspx.cs" Inherits="MarketingAdmin_AbstractSchoolPresenty"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div style="margin-top: 30px">
            <center>
                <span style="font-size: 15px; font-weight: bold">Abstract School Presenty Report</span><br />
                <div style="margin-top: 20px">
                    <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                        PageSize="10" AllowPaging="true" OnPageIndexChanging="gvItem_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SchoolCode" HeaderText="SchoolCode"></asp:BoundField>
                            <asp:BoundField DataField="EntryDate" HeaderText="Date"></asp:BoundField>
                            <asp:BoundField DataField="RegBoys" HeaderText="RegBoys"></asp:BoundField>
                            <asp:BoundField DataField="RegGirls" HeaderText="RegGirls"></asp:BoundField>
                            <asp:BoundField DataField="Present_B" HeaderText="Present_B"></asp:BoundField>
                            <asp:BoundField DataField="Present_G" HeaderText="Present_G"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="btnAbstract" runat="server" Text="Abstract School Presenty" CssClass="button"
                        OnClick="btnAbstract_Click" Width="195px" />
                    <asp:Button ID="GetTotal" runat="server" Text="Get Reference" CssClass="button" OnClick="GetTotal_Click" />
                    <%--<asp:Button ID="btnZeroTotal" runat="server" Text="Zero Attendence Total" CssClass="button"
                        OnClick="btnZeroTotal_Click" Visible="false"/>--%>
                    <asp:Button ID="btnSendMgs" runat="server" Text="Sent to HM" CssClass="button" OnClick="btnSendMgs_Click" />
                    <asp:Button ID="btnSentAll" runat="server" Text="Sent to ALL" CssClass="button" OnClick="btnSentAll_Click1" />
                    <asp:Button ID="btnTransferArchive" runat="server" Text="Transfer To Archive" CssClass="button"
                        OnClick="btnTransferArchive_Click" />
                </div>
            </center>
        </div>
    </div>
</asp:Content>
