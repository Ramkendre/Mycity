<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="UdiseSchoolecodeSmsDetails.aspx.cs" Inherits="MarketingAdmin_UdiseSchoolecodeSmsDetails" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<style type="text/css">
.classname {
	-moz-box-shadow:inset 1px 0px 0px 1px #bbdaf7;
	-webkit-box-shadow:inset 1px 0px 0px 1px #bbdaf7;
	box-shadow:inset 1px 0px 0px 1px #bbdaf7;
	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #79bbff), color-stop(1, #378de5) );
	background:-moz-linear-gradient( center top, #79bbff 5%, #378de5 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#79bbff', endColorstr='#378de5');
	background-color:#79bbff;
	-webkit-border-top-left-radius:20px;
	-moz-border-radius-topleft:20px;
	border-top-left-radius:20px;
	-webkit-border-top-right-radius:20px;
	-moz-border-radius-topright:20px;
	border-top-right-radius:20px;
	-webkit-border-bottom-right-radius:20px;
	-moz-border-radius-bottomright:20px;
	border-bottom-right-radius:20px;
	-webkit-border-bottom-left-radius:20px;
	-moz-border-radius-bottomleft:20px;
	border-bottom-left-radius:20px;
	text-indent:0;
	display:inline-block;
	color:#ffffff;
	font-family:Arial;
	font-size:14px;
	font-weight:bold;
	font-style:normal;
	height:40px;
	line-height:40px;
	width:140px;
	text-decoration:none;
	text-align:center;
	text-shadow:2px 3px 0px #528ecc;
}
.classname:hover {
	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #378de5), color-stop(1, #79bbff) );
	background:-moz-linear-gradient( center top, #378de5 5%, #79bbff 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#378de5', endColorstr='#79bbff');
	background-color:#378de5;
}.classname:active {
	position:relative;
	top:1px;
}</style>
/* This button was generated using CSSButtonGenerator.com */ 


<p align = "center">
SMS Registation Details
</p>

 <p align = "center">
     <asp:DropDownList ID="ddlList" runat="server" align = "center" Height="22px" 
         Width="99px">
     <asp:ListItem>ADM</asp:ListItem>
     <asp:ListItem>MDM</asp:ListItem>
     </asp:DropDownList>
 
 </p>
 
<div align = "center"> 
<asp:TextBox ID="txtCountry" runat="server" align ="center" ToolTip = "Enter School Code here" placeholder = "Enter School Code here" ></asp:TextBox>

<ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtCountry" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="10" ServiceMethod="GetCountries" >
</ajax:AutoCompleteExtender> 
&nbsp;&nbsp;&nbsp;
</div>
<p align ="center"> 
        <asp:TextBox ID="txtdatefrom" runat="server" ToolTip = "Select Date From" placeholder = "Select Date From"></asp:TextBox> 
        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdatefrom" Format = 'yyyy.MM.dd'  >
                                                                    </asp:CalendarExtender>
        &nbsp&nbsp&nbsp To &nbsp&nbsp&nbsp
        <asp:TextBox ID="txtdateto" runat="server" ToolTip = "select Date To" placeholder = "select Date To"></asp:TextBox>
        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtdateto" Format = "yyyy-MM-dd">
                                                                    </asp:CalendarExtender> 
    </p>
<p align = "center">
    <asp:Button ID="tbnSearch" runat="server" onclick="tbnSearch_Click" CssClass = "classname"
        Text="Search" Width="70px" />
        &nbsp&nbsp&nbsp
    <asp:Button ID="Button1" runat ="server" onclick="Button1_Click" CssClass="classname"
        Text="DownloadToExcel"  />
        
        
</p>

<p align = "center">
    <asp:GridView ID="gvDataDisplay" runat="server" align = "center" EmptyDataText = "No record Available" 
        BackColor="White" BorderColor="#999999" BorderWidth="1px" 
        CellPadding="3" GridLines="Vertical" dataformatstring="{0:MM/dd/yyyy}" 
        BorderStyle="None">
        <RowStyle HorizontalAlign="Center" BackColor="#EEEEEE" ForeColor="Black"  />
        <AlternatingRowStyle HorizontalAlign="Center" BackColor="#DCDCDC" />
        
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <PagerStyle BackColor="#999999" ForeColor="Black" 
            HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#008A8C" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>

</p>

</asp:Content>

