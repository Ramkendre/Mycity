<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="ExcelFileUpload.aspx.cs" Inherits="MarketingAdmin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <%--<script language="javascript" type="text/javascript">
        function Clientvalidate1(source, arguments) {
            var file_name = arguments.value;
            var index = file_name.indexOf(".");
            var str = file_name.substring(index + 1);
            if (index != "-1") {
                if (str == ".xls" || str == ".xlsx") {
                    arguments.IsValid = true;
                }
                else {
                    arguments.IsValid = false;
                }
            }
            else {
                arguments.IsValid = false;
            }
     }
</script>--%>
    <table>
    
   <tr>
   <td colspan="3">
       <asp:Label ID="lblDwnld" runat="server" >Click  <a href="ExcelDownload.aspx">Here </a>To Download ExcelSheet Format.</asp:Label>
   <br />
   <br />
   </td>
   </tr>
<tr>
<td>
    <asp:Label ID="lblFileUpload" runat="server" Text="FileUpload"></asp:Label></td>
    <td>
        <asp:FileUpload ID="fileExcel" runat="server" onkeypress="return false;" 
            onkeydown="return false;"/>
        <asp:RequiredFieldValidator ID="rfvFileExcel" runat="server" ErrorMessage="* Please select an Excel File to upload." 
        Display="Dynamic" ControlToValidate="fileExcel" ValidationGroup="fileUpload"></asp:RequiredFieldValidator>
       
        </td>
        <td >
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnFileUpload" runat="server" Text="Save" ValidationGroup="fileUpload"
        onclick="btnFileUpload_Click" CssClass="button" />
</td>
</tr>
<tr><td colspan="3"><br /></td></tr>
<tr><td colspan="3"></td></tr>
<tr>

<td >
    <asp:Button ID="btnFileRead" runat="server" Text="RegisterUser" 
        onclick="btnFileRead_Click" CssClass="button"
        />
</td>
</tr>
<tr align="justify">
<td colspan ="3">
    <asp:GridView ID="gvUserRegistered" runat="server" AutoGenerateColumns="false" EmptyDataText="NO User Registered">
    <Columns>
    <asp:TemplateField>
    <HeaderTemplate>
    <table><tr><td colspan="4">
        <asp:Label ID="Label1" runat="server" Text="Registered Successfully"></asp:Label>
    </td></tr></table>
    </HeaderTemplate>
    <%--<HeaderTemplate>
    <table style="width: 100%;" border="1">
    <tr>
    <td style ="width:30%">
        <asp:Label ID="Label2" runat="server" >FirstName</asp:Label></td>
    <td style ="width:30%">
        <asp:Label ID="Label3" runat="server" >LastName</asp:Label></td>
    <td style ="width:30%">
        <asp:Label ID="Label4" runat="server" >Mobile</asp:Label></td>
    <td style ="width:30%">
        <asp:Label ID="Label5" runat="server" >PinCode</asp:Label></td>
    </tr>
    
    </table>
    </HeaderTemplate>--%>
    <ItemTemplate>
    <table style="width: 100%;" border="1">
    <tr>
    <td style ="width:30%"><asp:Label ID="lblFirstName" Text='<%#Eval("fName")%>' runat ="server"></asp:Label></td>
    <td style ="width:30%"><asp:Label ID="lblLastName" Text='<%#Eval("lName")%>' runat ="server"></asp:Label></td>
    <td style ="width:30%"><asp:Label ID="lblMobileNo" Text='<%#Eval("mobileNo")%>' runat ="server"></asp:Label></td>
    <td style ="width:30%"><asp:Label ID="lblPin" Text='<%#Eval("pinNo")%>' runat ="server"></asp:Label></td>
    </tr>
    </table>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
</td>
</tr>
<tr><td colspan ="4"><br />
<br /></td></tr>
<tr align="justify">
<td colspan ="2">
    <asp:GridView ID="gvUserAlreadyRegistered" runat="server" AutoGenerateColumns="false" EmptyDataText="NO Already Registered Users">
    <Columns>
    <asp:TemplateField>
    <HeaderTemplate>
    <table><tr><td colspan="4">
        <asp:Label ID="Label1" runat="server" Text="Already Registered Users"></asp:Label>
    </td></tr></table>
    </HeaderTemplate>
    <%--<HeaderTemplate>
    <table style="width: 100%;" border="1">
    <tr>
    <td style ="width:30%">
        <asp:Label ID="Label2" runat="server" >FirstName</asp:Label></td>
    <td style ="width:30%">
        <asp:Label ID="Label3" runat="server" >LastName</asp:Label></td>
    <td style ="width:30%">
        <asp:Label ID="Label4" runat="server" >Mobile</asp:Label></td>
    <td style ="width:30%">
        <asp:Label ID="Label5" runat="server" >PinCode</asp:Label></td>
    </tr>
    
    </table>
    </HeaderTemplate>--%>
    <ItemTemplate>
    <table border="1">
    <tr>
    <td style ="width:30%"><asp:Label ID="lblFirstName1" Text='<%#Eval("fName")%>' runat ="server"></asp:Label></td>
    <td style ="width:30%"><asp:Label ID="lblLastName1" Text='<%#Eval("lName")%>' runat ="server"></asp:Label></td>
    <td style ="width:30%"><asp:Label ID="lblMobileNo1" Text='<%#Eval("mobileNo")%>' runat ="server"></asp:Label></td>
    <td style ="width:30%"><asp:Label ID="lblPin1" Text='<%#Eval("pinNo")%>' runat ="server"></asp:Label></td>
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

