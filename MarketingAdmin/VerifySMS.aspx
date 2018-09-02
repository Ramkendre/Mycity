<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="VerifySMS.aspx.cs" Inherits="MarketingAdmin_VerifySMS" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width ="1000px">
<tr>
 <td style ="width :500px">
     <asp:Label ID="Label1" runat="server" Text="Long Code SMS Receved from www.smscountry.com" Font-Bold ="true" ForeColor ="Red" Font-Size ="Medium"  ></asp:Label>
 </td>
  <td style ="width :500px">
     <asp:Label ID="Label2" runat="server" Text="SMS Send to www.smscountry.com" Font-Bold ="true" ForeColor ="Red" Font-Size ="Medium"></asp:Label>
 </td>
</tr>
<tr>
  
<td>
 <table width ="500px">
    <tr>
     <td>
         <asp:GridView ID="gvLongCodeSMSReceve" runat="server" 
             AutoGenerateColumns="False" PageIndex="10">
         <Columns >
         <asp:BoundField HeaderText ="ID" DataField ="pk" />
         <asp:BoundField HeaderText ="Mobile No" DataField ="mobileNo" />
         <asp:BoundField HeaderText ="Message" DataField ="message" />
         <asp:BoundField HeaderText ="Date" DataField ="date" />
         <asp:BoundField HeaderText ="Flag Status" DataField ="flag" />
         </Columns>
         </asp:GridView>
     </td>
    </tr>
   </table>

</td>

<td>
 <table width ="500px">
    <tr>
     <td>
         <asp:GridView ID="gvSMSsend" runat="server" AutoGenerateColumns="False">
         <Columns>
         <asp:BoundField HeaderText ="ID" DataField ="ID" />
         <asp:BoundField HeaderText ="Send From" DataField ="SendFrom" />
         <asp:BoundField HeaderText ="Send To" DataField ="SendTo" />
         <asp:BoundField HeaderText="Message" DataField ="SendSMS" />
         <asp:BoundField HeaderText ="Status" DataField ="FlagCode" />
        </Columns>
         </asp:GridView>
     </td>
    </tr>
   </table>
</td>

</tr>

</table>


</asp:Content>

