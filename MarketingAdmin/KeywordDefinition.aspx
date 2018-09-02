<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="KeywordDefinition.aspx.cs" Inherits="MarketingAdmin_KeywordDefinition" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
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
<asp:UpdatePanel runat="server" ID="update"><ContentTemplate>
<div>
 <table width ="100%">
 <tr>
  <td style ="width :20%">
  </td>
  <td style ="width :60%" align ="center" >
<table width ="400">
<tr>
<td colspan="2">
    <asp:Label ID="lblKeywordDefinition" runat="server" Text="Define Keywords" Font-Bold ="true" Font-Size ="X-Large" ></asp:Label></td>
</tr>
<tr>
<td style="height: 34px" align="left">
    <asp:Label ID="lblKeywordName" runat="server" Text="Keyword Name" Font-Size ="Large" Font-Bold ="true" ></asp:Label>
</td>
<td style="height: 34px" align="left" >
    <asp:TextBox ID="txtKeywordName" runat="server" Width="250px" ></asp:TextBox>
    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Keyword Name" ControlToValidate="txtKeywordName"></asp:RequiredFieldValidator>--%>
</td>
</tr>
<tr>
<td style="height: 29px" align="left">
    <asp:Label ID="lblKeywordDescription" runat="server" Text="Keyword Description" Font-Size ="Large" Font-Bold ="true"></asp:Label>
</td>
<td style="height: 29px" align="left">
    <asp:TextBox ID="txtKeywordDescription" runat="server" Width="250px"></asp:TextBox>
</td>
</tr>
<tr>
<td align="left">
    <asp:Label ID="lblResponseMsg" runat="server" Text="Response Message" Font-Size ="Large" Font-Bold ="true"></asp:Label>
</td>
<td align="left">
    <asp:TextBox ID="txtResponseMessage" runat="server" TextMode="MultiLine" 
        Height="100px" Width="250px"></asp:TextBox>
</td>
</tr>
    <tr>
        <td align="left">
            <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="Large" 
                Text="Enter E-mail Address"></asp:Label>
        </td>
        <td align="left">
            <asp:TextBox ID="txtEmail" runat="server" Width="450px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ErrorMessage="*" ControlToValidate="txtEmail" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
    <td align="left">
    <asp:Label ID="lblEmailSub" runat ="server" Text ="Enter Email Subject" 
            Font-Bold="True" Font-Size="Large"></asp:Label>
    </td>
    <td align="left">
    <asp:TextBox ID ="txtEmailSub" runat ="server" ></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td align="left">
    <asp:Label ID ="lblEmailBody" runat ="server" Text="Enter Email Body:" 
            Font-Bold="True" Font-Size="Large"></asp:Label>
    </td>
    <td align="left">
    
      <cc1:Editor ID="FCKeditor1" runat="server" width="300px" height="300px"/>
    </td>
    </tr>
    
    
    <tr>
        <td align="left">
            <asp:Label ID="lblKeywordCreationDate" runat="server" Font-Bold="true" 
                Font-Size="Large" Text="Valid From Date"></asp:Label>
        </td>
        <td align="left">
            <asp:TextBox ID="txtKeywordCreationDate" runat="server" Width="250px"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                Format="MMMM d, yyyy" OnClientShowing="ShowDate" PopupPosition="Right" 
                TargetControlID="txtKeywordCreationDate">
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
        <td align="left">
            <asp:Label ID="lblvalidUpto" runat="server" Font-Bold="true" Font-Size="Large" 
                Text="Valid Upto Date"></asp:Label>
        </td>
        <td align="left">
            <asp:TextBox ID="txtValidUpto" runat="server" Width="250px"></asp:TextBox>
            <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                Format="MMMM d, yyyy" OnClientShowing="ShowDate" PopupPosition="Right" 
                TargetControlID="txtValidUpto">
            </asp:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:Label ID="lblSelectGroup" runat="server" Font-Bold="true" 
                Font-Size="Large" Text="Select Group"></asp:Label>
        </td>
        <td align="left">
            <asp:DropDownList ID="ddlGroupName" runat="server" AutoPostBack="true" 
                onselectedindexchanged="ddlGroupName_SelectedIndexChanged" Width="250px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:Label ID="lblSelectSubGruop" runat="server" Font-Bold="true" 
                Font-Size="Large" Text="Select SubGroup"></asp:Label>
        </td>
        <td align="left">
            <asp:DropDownList ID="ddlSubGroupName" runat="server" AutoPostBack="true" 
                Width="250px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:Label ID="lblActive" runat="server" Font-Bold="true" Font-Size="Large" 
                Text="Status"></asp:Label>
        </td>
        <td align="left">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="118px">
                <asp:ListItem Selected="True" Text="Active" Value="1"></asp:ListItem>
                <asp:ListItem Text="InActive" Value="0"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                OnClientClick="return validateKeywordName();" Text="Submit" />
            <asp:Button ID="btnModify" runat="server" onclick="btnModify_Click" 
                Text="Modify" Visible="false" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:GridView ID="gvKeywordDefinition" runat="server" AllowPaging="true" 
                AutoGenerateColumns="false" 
                onpageindexchanging="gvKeywordDefinition_PageIndexChanging" 
                onselectedindexchanged="gvKeywordDefinition_SelectedIndexChanged">
                <HeaderStyle CssClass="HeaderStyle" />
                <PagerStyle CssClass="PagerStyle" />
                <RowStyle CssClass="RowStyle" />
                <EditRowStyle CssClass="EditRowStyle" />
                <Columns>
                    <asp:BoundField ControlStyle-Width="" DataField="keywordName" 
                        HeaderText="KeywordName" />
                    <asp:BoundField ControlStyle-Width="" DataField="keywordDescription" 
                        HeaderText="Description" />
                    <asp:BoundField ControlStyle-Width="" DataField="responseMsg" 
                        HeaderText="ResponseMessage" />
                    <asp:BoundField ControlStyle-Width="" DataField="keywordCreationDate" 
                        HeaderText="CreatedOn" />
                    <asp:BoundField ControlStyle-Width="" DataField="validUpto" 
                        HeaderText="ValidUpto" />
                    <asp:BoundField ControlStyle-Width="" DataField="GroupName" 
                        HeaderText="GroupName" />
                    <asp:BoundField ControlStyle-Width="" DataField="SubGroupName" 
                        HeaderText="SubGroupName" />
                    <asp:BoundField ControlStyle-Width="" DataField="Email" 
                        HeaderText="E-mail Address" />
                        <asp:BoundField HeaderText ="Email Subject" DataField ="EmailSub"  />
                        <asp:BoundField HeaderText ="Email Body" DataField ="EmailBody" />
                    <asp:BoundField ControlStyle-Width="" DataField="Active" HeaderText="Status" />
                    <asp:CommandField SelectText="Modify" ShowSelectButton="true" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
     <tr>
         <td style="width :20%">
         </td>
    </tr>
</tr>



</table>

</div></ContentTemplate></asp:UpdatePanel>
</asp:Content>

