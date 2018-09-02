<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true" CodeFile="SpacialSMS.aspx.cs" Inherits="Html_SpacialSMS" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
 <table width ="100%">
 
<tr>
<td colspan ="2" align ="center" >
    <asp:Label ID="Label1" runat="server" Font-Bold ="True" ForeColor ="#3333FF"  
        Text="Spacial SMS Service." Font-Size="Large"></asp:Label>
</td>
</tr>
<tr >
<td colspan ="2">
&nbsp;
</td>
</tr>
<tr>
<td style ="width :50%">
    <asp:Label ID="Label2" runat="server" Font-Bold ="True" 
        Text="Your Paid Balance: " ForeColor="Blue"></asp:Label>
</td>
<td style ="width :50%">
    <asp:Label ID="lblPaidBal" runat="server" Font-Bold ="True" Text="lll" 
        ForeColor="Blue"></asp:Label>
</td>
</tr>
<tr>
<td colspan ="2">
&nbsp;
</td>
</tr>
<tr>
<td>
    <asp:Label ID="Label3" runat="server" Text="Service For: " Font-Bold="True" 
        ForeColor="Blue"></asp:Label>
</td>
<td>
 <table width ="100%">
 <tr>
 <td style ="width :50%" align ="center" >
 <asp:Button ID="btnStudent" runat="server" Text="Student" Width="70px" 
         BackColor="#669999" Font-Bold="True" ForeColor="#0000CC" 
         onclick="btnStudent_Click" />
 </td>
 <td style ="width :50%" align ="center" >
 <asp:Button ID="btmCust" runat="server" Text="Customer" Width="70px" 
         BackColor="#669999" Font-Bold="True" ForeColor="#0000CC" />
 </td>
 </tr>
 </table>
    
    
</td>
</tr>
</table>
    <asp:ModalPopupExtender ID="MPUP_Student" TargetControlID ="btnStudent" CancelControlID="btnClose" PopupControlID ="SS_Student" runat="server">
    </asp:ModalPopupExtender>
    <asp:Panel ID="SS_Student" runat ="server" BackColor ="Aqua" BorderColor ="Red" 
        Width="60%">
    <table width ="100%">
    <tr>
    <td align ="center" colspan="2">
        <asp:Label ID="Label4" runat="server" Text="Spacial Service For Student SMS" 
            Font-Bold="True" Font-Size ="Large" ForeColor="#FF0066"></asp:Label>
    </td>
    </tr>
    <tr>
    <td style ="width :50%">
        <asp:Label ID="Label5" runat="server" Text="Select Your Group" Font-Bold="True" 
            ForeColor="Blue"></asp:Label>
    </td>
    <td  style ="width :50%">
        <asp:DropDownList ID="ddlUserGr" Width ="170px" runat="server" AutoPostBack ="true" 
            onselectedindexchanged="ddlUserGr_SelectedIndexChanged">
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td colspan ="2">
    
     <asp:UpdatePanel ID ="upStuGridView" runat ="server" >
     <ContentTemplate >     
     <asp:GridView ID="gvStuGr" runat="server" AutoGenerateColumns="False" Width ="100%">
        <Columns >
        <asp:BoundField HeaderText ="Sr.No." DataField ="a" />
        <asp:BoundField HeaderText ="Parent Name" DataField ="b" />
        <asp:BoundField HeaderText ="Mobile" DataField ="c" />
        <asp:BoundField HeaderText ="Roll No" DataField ="d" />
        <asp:BoundField HeaderText ="Stu Name" DataField ="e" />
       
        <asp:TemplateField HeaderText="Write SMS">
        <ItemTemplate >
         <asp:TextBox ID ="txtSms" runat ="server" ToolTip ="Enter Your SMS Here" Width ="250px"></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText ="SEND SMS">
        <ItemTemplate >
        <asp:Button ID ="btnSendSms" Width ="50px" runat ="server" Text ="SEND" OnClick ="btnSendSms_Click" />
        </ItemTemplate>
        </asp:TemplateField>
        
        </Columns>
        </asp:GridView>
        
     </ContentTemplate>
     <Triggers >
      <asp:AsyncPostBackTrigger ControlID ="ddlUserGr" EventName ="SelectedIndexChanged" />
     </Triggers>
     </asp:UpdatePanel> 
        
    </td>
    </tr>
    
    
    
    <tr>
    <td align ="center" colspan ="2">
        <asp:Button ID="btnClose" Width="70px" 
         BackColor="#669999" Font-Bold="True" ForeColor="#0000CC" runat="server" Text="CLOSE" />
    </td>
    </tr>
    </table>
    </asp:Panel>


</asp:Content>
