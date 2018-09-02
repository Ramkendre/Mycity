<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="HirachyReport.aspx.cs" Inherits="MarketingAdmin_HirachyReport" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin-top: 20px;">
        <center>
            <span style="font-size: 20px; font-weight: bold; ">Hierarchy Report</span>
        </center>
    </div>
    <div style="margin-top: 20px; margin-right: 40px">
        <asp:GridView ID="gvItem" runat="server" CssClass="mGrid" AllowPaging="true" EmptyDataText="Role List is not available."
            PageSize="20" AutoGenerateColumns="false" OnPageIndexChanging="gvItem_PageIndexChanging">
           <%-- <PagerSettings Mode="NextPrevious" PageButtonCount="4" PreviousPageText="Previous"
                NextPageText="Next" />--%>
            <Columns>
                <asp:TemplateField HeaderText="Sr. No" ItemStyle-Width="30px">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="usrFirstName" HeaderText="First Name" />
                <asp:BoundField DataField="usrLastName" HeaderText="Last Name" />
                <asp:BoundField DataField="usrMobileNo" HeaderText="Mobile No" />
                <asp:BoundField DataField="rolename" HeaderText="Role" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
