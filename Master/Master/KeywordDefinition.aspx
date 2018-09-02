<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="KeywordDefinition.aspx.cs" Inherits="MarketingAdmin_KeywordDefinition" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
    function validateKeywordName() {
        if (document.getElementById('<%=txtKeywordName.ClientID %>').value == "") {
            alert("Please Enter Keyword Name");
            return false;
        }
        else {
            return true;
        }
    }
    function ShowDate(sender,args) {
        if (sender._textbox.get_element().value == "") {
            var todayDate = new Date();
            sender._selectedDate = todayDate;
           
           
        }
    }
</script>
<asp:UpdatePanel ID="uptPnlKeyword" runat="server">
<ContentTemplate>
<table>
<tr>
<td colspan="2">
    <asp:Label ID="lblKeywordDefinition" runat="server" Text="Define Keywords"></asp:Label></td>
</tr>
<tr>
<td>
    <asp:Label ID="lblKeywordName" runat="server" Text="Keyword Name"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtKeywordName" runat="server"></asp:TextBox>
    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Keyword Name" ControlToValidate="txtKeywordName"></asp:RequiredFieldValidator>--%>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="lblKeywordDescription" runat="server" Text="Keyword Description"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtKeywordDescription" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="lblResponseMsg" runat="server" Text="Response Message"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtResponseMessage" runat="server" TextMode="MultiLine" Height="100px" Width="150px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:Label ID="lblKeywordCreationDate" runat="server" Text="Creation Date"></asp:Label>
</td>
<td>
    
<asp:TextBox ID="txtKeywordCreationDate" runat="server"></asp:TextBox>
<asp:CalendarExtender ID="CalendarExtender1" runat="server" 
        TargetControlID="txtKeywordCreationDate" Format="MMMM d, yyyy" 
        PopupPosition="Right" OnClientShowing="ShowDate" >
    </asp:CalendarExtender>
    
</td>

<%--<td>
   
    <asp:Label ID="lblValidity" runat="server" Text="Keyword Validity"></asp:Label>
</td>
<td>
    
    <asp:TextBox ID="txtKeywordValidity" runat="server"></asp:TextBox>
    <asp:FilteredTextBoxExtender ID="txtKeywordValidity_FilteredTextBoxExtender" 
        runat="server" TargetControlID="txtKeywordValidity" FilterMode="ValidChars" FilterType="Numbers">
    </asp:FilteredTextBoxExtender>
</td>--%>
</tr>
<tr>
<td>
    <asp:Label ID="lblvalidUpto" runat="server" Text="Valid Upto"></asp:Label>
</td>
<td>
    
<asp:TextBox ID="txtValidUpto" runat="server"></asp:TextBox>
<asp:CalendarExtender ID="CalendarExtender2" runat="server" 
        TargetControlID="txtValidUpto" Format="MMMM d, yyyy"  
        PopupPosition="Right" OnClientShowing="ShowDate">
    </asp:CalendarExtender>
</td>
</tr>
 <tr>
  <td>
    <asp:Label ID="lblSelectGroup" runat="server" Text="Select Group"></asp:Label>
  </td>
  <td>
      <asp:DropDownList ID="ddlGroupName" runat="server" AutoPostBack="true"
          onselectedindexchanged="ddlGroupName_SelectedIndexChanged">
      </asp:DropDownList>
  </td>
 </tr>
  <tr>
  <td>
    <asp:Label ID="lblSelectSubGruop" runat="server" Text="Select SubGroup"></asp:Label>
  </td>
  <td>
      <asp:DropDownList ID="ddlSubGroupName" runat="server" AutoPostBack="true">
      </asp:DropDownList>
  </td>
 </tr>
    <tr>
    <td>
    <asp:Label ID="lblActive" runat="server" Text="Status"></asp:Label>
    </td>
    <td>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="118px" >
        <asp:ListItem Text="Active" Selected="True" Value="1"></asp:ListItem><asp:ListItem Text="InActive" Value="0"></asp:ListItem>
        </asp:RadioButtonList>
    </td>
    </tr>
<tr>
<td align="center" colspan="2">
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
        onclick="btnSubmit_Click" OnClientClick="return validateKeywordName();"/>
    <asp:Button ID="btnModify" runat="server" Text="Modify" Visible="false" 
        onclick="btnModify_Click" />
</td>
</tr>
<tr>
<td colspan="2">

    <asp:GridView ID="gvKeywordDefinition" runat="server" 
        AutoGenerateColumns="false" AllowPaging="true" 
        onselectedindexchanged="gvKeywordDefinition_SelectedIndexChanged" 
        onpageindexchanging="gvKeywordDefinition_PageIndexChanging">
     <HeaderStyle CssClass="HeaderStyle" />
     <PagerStyle CssClass="PagerStyle" />
     <RowStyle CssClass="RowStyle" />
     <EditRowStyle CssClass="EditRowStyle" />
    <Columns>
    <asp:BoundField DataField="keywordName" HeaderText="KeywordName" ControlStyle-Width="" />
    <asp:BoundField DataField="keywordDescription" HeaderText="Description" ControlStyle-Width="" />
    <asp:BoundField DataField="responseMsg" HeaderText="ResponseMessage" ControlStyle-Width="" />
    <asp:BoundField DataField="keywordCreationDate" HeaderText="CreatedOn" ControlStyle-Width="" />
    <asp:BoundField DataField="validUpto" HeaderText="ValidUpto" ControlStyle-Width="" />
    <asp:BoundField DataField="GroupName" HeaderText="GroupName" ControlStyle-Width="" />
    <asp:BoundField DataField="SubGroupName" HeaderText="SubGroupName" ControlStyle-Width="" />
    <asp:BoundField DataField="Active" HeaderText="Status" ControlStyle-Width="" />
    <asp:CommandField ShowSelectButton="true" SelectText="Modify" /> 
    </Columns>
    </asp:GridView>
</td>
</tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

