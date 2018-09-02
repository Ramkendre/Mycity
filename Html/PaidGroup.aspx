<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true" CodeFile="PaidGroup.aspx.cs" Inherits="Html_PaidGroup" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width ="800px">
<tr>
<td colspan ="3" align ="center" >
    <asp:Label ID="Label1" runat="server" Text="Paid Group SMS Service."></asp:Label>
</td>
</tr>
<tr>
<td align ="center" >
    <asp:Button ID="btnUpdateGr" runat="server" Text="Update Group" />
</td>
<td align ="center" >
    <asp:Button ID="btnAddMember" runat="server" Text="Add Menber" />
</td>
<td align ="center" >
    <asp:Button ID="btnSendSms" runat="server" Text="Send SMS" />
</td>
</tr>
<tr>
<td align ="center" colspan ="3">
    <asp:ModalPopupExtender ID="ModalPopupExtender1" CancelControlID ="btnClosePanel1" TargetControlID ="btnUpdateGr" PopupControlID ="UpdateGrPanel" runat="server">
    </asp:ModalPopupExtender>
<asp:Panel ID ="UpdateGrPanel" runat ="server" >
<table width="400px" align="center" bgcolor="#669999">
<tr>
<td align ="center" colspan ="2">
    <asp:Label ID="Label2" runat="server" Text="Update Paid SMS Group Names." 
        Font-Bold="True" ForeColor="#FF0066"></asp:Label>
</td>
</tr>
<tr>
<td colspan="2">
&nbsp;
</td>
</tr>

<tr>
<td align ="left" >
    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="First Group Name"></asp:Label>
</td>
<td align ="center">
    <asp:TextBox ID="txtGrFirst" runat="server"></asp:TextBox>
</td>
</tr>

<tr>
<td align ="left">
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Second Group Name"></asp:Label>
</td>
<td align ="center">
    <asp:TextBox ID="txtGrSecond" runat="server"></asp:TextBox>
</td>
</tr>

<tr>
<td align ="left">
    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Third Group Name"></asp:Label>
</td>
<td align ="center">
    <asp:TextBox ID="txtGrThird" runat="server"></asp:TextBox>
</td>
</tr>

<tr>
<td align ="left">
    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Fourth Group Name"></asp:Label>
</td>
<td align ="center">
    <asp:TextBox ID="txtGrFourth" runat="server"></asp:TextBox>
</td>
</tr>

<tr>
<td align ="left">
    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Fifth Group Name"></asp:Label>
</td>
<td align ="center">
    <asp:TextBox ID="txtGrFive" runat="server"></asp:TextBox>
</td>
</tr>

<tr>
<td colspan="2">
&nbsp;
</td>
</tr>

<tr>
<td align ="center" >
    <asp:Button ID="Button1" runat="server" Text="UPDATE" Font-Bold="True" 
        onclick="Button1_Click" />
</td>
<td align ="center" >
    <asp:Button ID="btnClosePanel1" runat="server" Text="CLOSE" Font-Bold="True" />
</td>
</tr>
</table>
</asp:Panel>

</td>
</tr>

<tr>
<td align ="center" colspan ="3">
    <asp:ModalPopupExtender ID="ModalPopupExtender2" CancelControlID ="btnClosePanel2" TargetControlID ="btnAddMember" PopupControlID ="pnlAddMen" runat="server">
    </asp:ModalPopupExtender>
<asp:Panel ID ="pnlAddMen" runat ="server" >
<table width="400px" align="center" bgcolor="#669999">
<tr>
<td colspan ="2" align ="center" >
    <asp:Label ID="Label8" runat="server" Text="Paid Group SMS Member Insert Form" 
        Font-Bold="True" ForeColor="#FF0066"></asp:Label>
</td>
</tr>
<tr>
<td colspan ="2">
&nbsp;
</td>
</tr>
<tr>
<td align ="left" >
    <asp:Label ID="Label9" runat="server" Text="Select PAID SMS Group:" 
        Font-Bold="True"></asp:Label>
</td>
<td>
    <asp:DropDownList ID="ddlGIgroupName" runat="server" Width="130px" 
        onselectedindexchanged="ddlGIgroupName_SelectedIndexChanged" 
        AutoPostBack="True">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td align ="left">
    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Enter Mobile Number:"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtGImobileNo" runat="server" Width="130px"></asp:TextBox>
</td>
</tr>

<tr>
<td align ="left">
    <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Enter First Name:"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtGIfirstName" runat="server" Width="130px"></asp:TextBox>
</td>
</tr>

<tr>
<td align ="left">
    <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Enter Last Name:"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtGIlastName" runat="server" Width="130px"></asp:TextBox>
</td>
</tr>
<tr>
<td colspan ="2">
&nbsp;
</td>
</tr>

<tr>
<td align="center">
    <asp:Button ID="btnInsertPan2" runat="server" Text="INSERT" Font-Bold="True" 
        onclick="btnInsertPan2_Click" />
</td>
<td>
    <asp:Button ID="btnClosePanel2" runat="server" Text="CLOSE" Font-Bold="True" />
</td>
</tr>
<tr>
<td colspan ="2">
&nbsp;
</td>
</tr>

<tr>
<td colspan ="2" align ="center" >
<asp:UpdatePanel ID ="upGI" runat ="server" >
<ContentTemplate >
    <asp:GridView ID="gvInsertMem" runat="server" AutoGenerateColumns="False" 
        BackColor="#66FFFF" BorderColor="#FF0066" Caption="PAID SMS Group Members" 
        CaptionAlign="Top">
    <Columns >
    <asp:BoundField HeaderText ="Sr.Id" DataField ="id" />
    <asp:BoundField HeaderText ="Mobile No" DataField ="mno" />
    <asp:BoundField HeaderText ="First Name" DataField ="fnm" />
    <asp:BoundField HeaderText ="Last Name" DataField ="lnm" />
    </Columns>
        <EditRowStyle Font-Bold="True" ForeColor="#CC3300" />
    </asp:GridView>
</ContentTemplate>
<Triggers >
<asp:AsyncPostBackTrigger ControlID ="ddlGIgroupName" EventName ="SelectedIndexChanged" />
</Triggers>
</asp:UpdatePanel>
</td>
</tr>
<tr>
<td colspan ="2">
&nbsp;
</td>
</tr>

</table>
</asp:Panel>
</td>
</tr>

<tr>
<td align ="center" colspan ="3">
    <asp:ModalPopupExtender ID="ModalPopupExtender3" CancelControlID ="btnClosePanel3" TargetControlID ="btnSendSms" PopupControlID ="pnlSendSms" runat="server">
    </asp:ModalPopupExtender>
<asp:Panel ID ="pnlSendSms" runat ="server" >
<table width="400px" align="center" bgcolor="#669999">
<tr>
<td colspan ="2" align ="center" >
    <asp:Label ID="Label13" runat="server" Text="Paid Group SMS Service." 
        Font-Bold="True" ForeColor="#FF0066"></asp:Label>
</td>
</tr>
<tr>
<td colspan ="2">
&nbsp;
</td>
</tr>

<tr>
<td>
    <asp:Label ID="Label15" runat="server" Text="Your Paid Balance:" 
        Font-Bold="True" ForeColor="Red"></asp:Label>
</td>
<td>
    <asp:Label ID="lblPaidRemBal" runat="server" Text="Label" Font-Bold="True" 
        Font-Underline="True" ForeColor="Red"></asp:Label>
</td>
</tr>

<tr>
<td colspan ="2">
&nbsp;
</td>
</tr>
<tr>
<td>
<asp:Label runat ="server" ID ="lblGr" Text ="Select Paid SMS Group" 
        Font-Bold="True"></asp:Label>
</td>
<td>
<asp:DropDownList ID ="ddlPaidGroup" runat="server" Width="200px" ></asp:DropDownList>
</td>
</tr>
<tr>
<td colspan ="2">
&nbsp;
</td>
</tr>
<tr>
<td>
<asp:Label ID ="lblSmsText" runat ="server" Text ="Enter SMS:" Font-Bold="True"></asp:Label>
</td>
<td>
<asp:TextBox ID ="txtSmsText" runat ="server" TextMode ="MultiLine" Height="130px" 
        Width="200px" ></asp:TextBox>
</td>
</tr>
<tr>
<td colspan ="2">
&nbsp;
</td>
</tr>
<tr>
<td align ="center" >
<asp:Button ID ="btnSendPaidSMS" runat ="server" Text ="SEND" Font-Bold="True" 
        onclick="btnSendPaidSMS_Click" Width="100px" />
</td>
<td align ="center" >
    <asp:Button ID="btnClosePanel3" runat="server" Text="CLOSE" Font-Bold="True" 
        Width="100px" />
</td>
</tr>
<tr>
<td colspan ="2">
&nbsp;
</td>
</tr>
</table>
</asp:Panel>
</td>
</tr>
</table>
</asp:Content>

