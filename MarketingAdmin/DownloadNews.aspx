<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="DownloadNews.aspx.cs" Inherits="MarketingAdmin_DownloadNews" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:GridView ID="gvDispNews" runat="server" CssClass="gridview" AutoGenerateColumns="false"
            EmptyDataText="No Records">
            <Columns>
                <asp:BoundField DataField="NID" HeaderText="ID">
                    <HeaderStyle HorizontalAlign="Center" Width="2%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="NHeading" HeaderText="Heading">
                    <HeaderStyle HorizontalAlign="Center" Width="30%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="DONR" HeaderText="Received Date">
                    <HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="LDOA" HeaderText="Last Date">
                    <HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="NInDetail" HeaderText="Detail News">
                    <HeaderStyle HorizontalAlign="Center" Width="40%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" Width="40%"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkNews" runat="server" AutoPostBack="true"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div>
        <asp:Button ID="downloadnews" runat="server" Text="Download Selected News" CssClass="btn"
            OnClick="downloadnews_Click" />
    </div>
</asp:Content>
