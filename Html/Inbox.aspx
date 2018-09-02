<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true" CodeFile="Inbox.aspx.cs" Inherits="Html_Inboxaspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table class="tblSubFull1">
     <tr class="searchResultHeader">
                                <td colspan="2" align="center" style="border-bottom-color: Black;">
                                   <asp:Label ID="lblHeader" runat="server" Text="Inbox"></asp:Label>
                                    <hr />
                                </td>
                            </tr>
   <%-- <tr><td align="center">
        <h3>
                            <asp:Label ID="lblHeader" runat="server" Text="Inbox"></asp:Label></h3>
    </td></tr>--%>
    
    
    <tr>
    <td align="center">
    <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" AllowPaging="True"
        PageSize="20" Width="100%" CssClass="mGrid" GridLines="None" OnPageIndexChanging="gvItem_PageIndexChanging"
        meta:resourcekey="gvItemResource1" >
        <HeaderStyle CssClass="HeaderStyle" />
        <PagerStyle CssClass="PagerStyle" />
        <RowStyle CssClass="RowStyle" />
        <EditRowStyle CssClass="EditRowStyle" />
        <Columns>
            
            
            <asp:BoundField DataField="FullName" HeaderText="Sender" />
            <asp:BoundField DataField="Msg" HeaderText="Message" />
           <%-- <asp:BoundField DataField ="sendDateTime" HeaderText ="Date"/>--%>
            <asp:BoundField DataField="Date" HeaderText="Date" />
        </Columns>
    </asp:GridView>
    </td>
    </tr>
    <tr><td align="left">
       <asp:Button ID="btn" runat="server" Text="Back" 
            CssClass="button" onclick="btn_Click"/>
    </td></tr>
    </table>
</asp:Content>

