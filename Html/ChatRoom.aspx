<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true" CodeFile="ChatRoom.aspx.cs" Inherits="html_ChatRoom" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
<tr>
<td>
    <asp:GridView ID="gvUseronline" runat="server" AutoGenerateColumns="false">
    <Columns>
    <asp:TemplateField HeaderText="Online" HeaderStyle-ForeColor="#009900">
    <ItemTemplate>
    <table>
    <tr>
    <td>
     <img alt="" src="../images/Status-user-online-icon.png" width="7px" height="7px" />
    </td>
    <td>
     <asp:Label ID="lblName" runat="server" Text='<%#Eval("Fullname") %>'></asp:Label>
    </td>
    </tr>
    </table>
   
    </ItemTemplate>
   
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
</td>
</tr>
</table>
</asp:Content>

