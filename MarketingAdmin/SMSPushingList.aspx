<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="SMSPushingList.aspx.cs" Inherits="MarketingAdmin_SMSPushingList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<br />
    <br />
    <table cellpadding="2" cellspacing="2" border="0" width="100%">
    <tr><td align="center">
        <h3>
                            <asp:Label ID="lblHeader" runat="server" Text="SMS Pushing"></asp:Label></h3>
    </td></tr>
    
    <tr><td align="left">
       <asp:Button ID="btnAddNew" runat="server" Text="Add New" 
            CssClass="button-submit" onclick="btnAddNew_Click"/>
    </td></tr>
    <tr>
    <td align="center">
    <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" AllowPaging="True"
        PageSize="20" Width="100%" CssClass="GridViewStyle" GridLines="None" OnPageIndexChanging="gvItem_PageIndexChanging"
        meta:resourcekey="gvItemResource1" >
        <HeaderStyle CssClass="HeaderStyle" />
        <PagerStyle CssClass="PagerStyle" />
        <RowStyle CssClass="RowStyle" />
        <EditRowStyle CssClass="EditRowStyle" />
        <Columns>
            
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="Name" HeaderText="Sender" />
            <asp:BoundField DataField="Msg" HeaderText="Message" />
            <asp:BoundField DataField="TotalMsg" HeaderText="TotalMsg" />
            <asp:BoundField DataField="Sent" HeaderText="Sent" />
           <asp:HyperLinkField Text="Modify"
                DataNavigateUrlFields="Id" DataNavigateUrlFormatString="SMSPushingEdit.aspx?Id={0}"
                HeaderText="Modify" meta:resourcekey="HyperLinkFieldResource1">
                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
            </asp:HyperLinkField>
        </Columns>
    </asp:GridView>
    </td>
    </tr>
    
    </table>
</asp:Content>

