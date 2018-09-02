<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="CSVUpload.aspx.cs" Inherits="MarketingAdmin_CSVUpload" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width ="500px">
<tr>
<td colspan ="2" align ="center" >
<asp:Label ID ="load" Text ="CSV Upload" runat ="server" Font-Bold="True" ></asp:Label>
</td>
</tr>
<tr>
<td colspan ="2">
&nbsp;
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblMoNo" runat ="server" Text ="User Mobile No:"></asp:Label>
</td>
<td>
    <asp:TextBox ID="textBox2" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td colspan ="2">
&nbsp;
</td>
</tr>
<tr>
<td>
    <asp:FileUpload ID="csvUpload" runat="server" />
</td>
<td>

    <asp:Button ID="Button1" runat="server" Text="UPLOAD" onclick="Button1_Click" />
</td>
</tr>
<tr>
<td colspan ="2">
&nbsp;
</td>
</tr>
<tr>
<td colspan ="2" align ="center" >
<a id="A1" href ="../MarketingAdmin/File_Upload/CSV Format.csv" runat ="server" >
            
    <asp:Button ID="Label1" runat="server" Text="Download CSV FILE FORMAT"></asp:Button>
    </a>
</td>
</tr>

<tr>
<td colspan ="2">
&nbsp;
</td>
</tr>



<tr>
<td colspan ="2">
    <table border="0" cellpadding="0" cellspacing="0" 
        style="border-collapse: collapse; width: 370pt">
        <colgroup>
            <col span="1" />
            <col span="1" />
            <col span="1" />
            <col span="1" />
            <col span="1" />
            <col span="1" style="width: 48pt" width="64" />
        </colgroup>
        <tr height="20">
            <td height="20" style="width: 120px">
                Mobile No</td>
            <td style="width: 93px">
                First Name</td>
            <td style="width: 91px">
                Last Name</td>
            <td style="width: 90px">
                PIN Code</td>
            <td style="width: 106px">
                Group No</td>
            <td style="width: 155px">
                City</td>
        </tr>
        <tr height="20">
            <td height="20" style="width: 120px">
                9881****66</td>
            <td style="width: 93px">
                test</td>
            <td style="width: 91px">
                test</td>
            <td  style="width: 90px">
                411001</td>
            <td  style="width: 106px">
                1</td>
            <td style="width: 155px">
                Pune</td>
        </tr>
        <tr height="20">
            <td height="20" style="width: 120px">
                9881*****66</td>
            <td style="width: 93px">
                test</td>
            <td style="width: 91px">
                test</td>
            <td style="width: 90px">
                411001</td>
            <td style="width: 106px">
                5&3&amp;7</td>
            <td style="width: 155px">
                Satara</td>
        </tr>
        <tr height="20">
            <td height="20" style="width: 120px">
                9881*****66</td>
            <td style="width: 93px">
                test</td>
            <td style="width: 91px">
                test</td>
            <td style="width: 90px">
                411001</td>
            <td style="width: 106px">
                1&amp;9</td>
            <td style="width: 155px">
                Pune</td>
        </tr>
        <tr height="20">
            <td height="20" style="width: 120px">
            </td>
            <td style="width: 93px">
            </td>
            <td style="width: 91px">
            </td>
            <td style="width: 90px">
            </td>
            <td style="width: 106px">
            </td>
            <td style="width: 155px">
            </td>
        </tr>
        
    </table>
</td>
</tr>
</table>

</asp:Content>

