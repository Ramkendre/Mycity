<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="MarketingAdmin_News" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center" >
<table width ="600px">
<tr>
<td align ="center" colspan ="2">
    <asp:Label ID="Label1" runat="server" Text="News Updates" Font-Bold ="true" ForeColor ="Blue" Font-Size ="Large"  ></asp:Label>
</td>
</tr>

<tr>
<td style ="width :300px">
    <asp:Label ID="Label2" runat="server" Text="Select News Paper Name" ForeColor ="Blue"  Font-Bold ="true" ></asp:Label>
</td>
<td style ="width :300px">
    <asp:DropDownList ID="ddlNewsName" runat="server" Width="250px">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td colspan ="2">
    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
</td>
</tr>

<%--<tr>
<td style ="width :300px">
    <asp:Label ID="Label5" runat="server" Text="Select District Name" ForeColor ="BlueViolet" Font-Bold ="true" ></asp:Label>
</td>
<td style ="width :300px">
    <asp:DropDownList ID="ddlDist" runat="server" Width="250px">
    </asp:DropDownList>
</td>
</tr>--%>
<tr>
<td style ="width :300px">
    <asp:Label ID="Label7" runat="server" Text="Select State Name" ForeColor ="Blue"  Font-Bold ="true" ></asp:Label>
</td>
<td style ="width :300px">
    <asp:DropDownList ID="ddlState" runat="server" Width="250px" AutoPostBack="true" 
        onselectedindexchanged="ddlState_SelectedIndexChanged">
    </asp:DropDownList>
</td>
</tr>

<tr>
<td colspan ="2">
    <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
</td>
</tr>



<tr>
<td style ="width :300px">
    <asp:Label ID="Label8" runat="server" Text="Select District Name" ForeColor ="Blue"  Font-Bold ="true" ></asp:Label>
</td>
<td style ="width :300px">
    <asp:DropDownList ID="ddlDistrict" runat="server" Width="250px">
    </asp:DropDownList>
</td>
</tr>





<tr>
<td colspan ="2" align ="center" >
    <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" 
        onclick="btnSubmit_Click" />
</td>
</tr>

<tr>
<td colspan ="2">
    <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
</td>
</tr>

<tr>
<td colspan ="2">
    <asp:GridView ID="gvNews" runat="server" AutoGenerateColumns="False" 
        Width="500px">
    <Columns>
    <asp:BoundField HeaderText ="ID" DataField ="ID"/>
    <asp:BoundField HeaderText ="News From" DataField ="NewsFrom"/>
    <asp:BoundField HeaderText ="News" DataField ="News"/>
    <asp:BoundField HeaderText ="Date" DataField ="Date"/>  
    
    </Columns>
    </asp:GridView>
</td>
</tr>

</table>
</div>
</asp:Content>

