<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="School.aspx.cs" Inherits="MarketingAdmin_School" Title="Untitled Page" EnableEventValidation ="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width ="100%">
<tr>
<td align ="center" colspan="2" style ="width :100%">
    <asp:Label ID="Label1" runat="server" Font-Bold ="True" 
        Text="School-Student Entry Section" Font-Size="Large" ForeColor="#FF0066"></asp:Label>
</td>
</tr>
<tr >
<td colspan="2">
&nbsp;
</td>
</tr>
<tr>
<td align ="center" style ="width :50%">
    <asp:Button ID="Button1" runat="server" Text="Add School" Font-Bold="True" 
        ForeColor="Blue" onclick="Button1_Click" />
</td>
<td align ="center" >
    <asp:Button ID="Button2" runat="server" Text="Add Student" Font-Bold="True" 
        ForeColor="Blue" onclick="Button2_Click" />
</td>
</tr>
<tr >
<td colspan="2">
&nbsp;
</td>
</tr>
<tr >
<td colspan="2">
<asp:Panel runat="server" ID ="SchoolPanel">
<table width ="100%">
<tr>
<td align ="center" colspan="2">
<asp:Label ID="Label2" runat="server" Text="School Entry Form" Font-Bold="True" 
        Font-Size="Large" ForeColor="#009900"></asp:Label>
</td>
</tr>
<tr>
<td colspan ="2">
&nbsp;
</td>
</tr>
<tr>
<td style ="width :50%">
    <asp:Label ID="Label4" runat="server" Text="School Name:" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#33CC33"></asp:Label>
</td>
<td style ="width :50%">
    <asp:TextBox ID="txtSchoolName" runat="server" Width="200px"></asp:TextBox>
</td>
</tr>

<tr>
<td style ="width :50%">
    <asp:Label ID="Label5" runat="server" Text="Address:" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#33CC33"></asp:Label>
</td>
<td style ="width :50%">
    <asp:TextBox ID="txtSchoolAdd" runat="server" Width="200px"></asp:TextBox>
</td>
</tr>


<tr>
<td style ="width :50%">
    <asp:Label ID="Label6" runat="server" Text="Contact Person" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#33CC33"></asp:Label>
</td>
<td style ="width :50%">
    <asp:TextBox ID="txtContPerson" runat="server" Width="200px"></asp:TextBox>
</td>
</tr>

<tr>
<td style ="width :50%">
    <asp:Label ID="Label7" runat="server" Text="Contact Number" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#33CC33"></asp:Label>
</td>
<td style ="width :50%">
    <asp:TextBox ID="txtConNumber" runat="server" Width="200px"></asp:TextBox>
</td>
</tr>


<%--<tr>

<td colspan ="2" style ="width :100%">
  <asp:UpdatePanel ID ="ClassList" runat ="server" >
   <ContentTemplate >
   <table width ="100%">--%>
   <tr>
    <td style ="width :50%">
    <asp:Label ID="Label8" runat="server" Text="Add Class (If not in select class list)" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#33CC33"></asp:Label>
    </td>
    <td style ="width :50%">
    <asp:TextBox ID="txtClassAdd" runat="server" Width="160px"></asp:TextBox>
     <asp:Button ID="Button3" runat="server" Text="ADD" Font-Bold="True" 
        ForeColor="#3333CC" Width="40px" onclick="Button3_Click"/>
       <%-- <asp:CheckBox ID="CheckBox1" runat="server" Text ="ADD" 
            oncheckedchanged="CheckBox1_CheckedChanged" AutoPostBack="True"/>--%>
    </td>
    </tr>
    <tr>
    <td style ="width :50%">
    <asp:Label ID="Label9" runat="server" Text="Select Class" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#33CC33"></asp:Label>
    </td>
    <td style ="width :50%">
    <asp:ListBox ID="lstClass" runat="server" Width="200px" 
           SelectionMode="Multiple"></asp:ListBox>
    </td>
    </tr>
 <%--  </table>
    
   </ContentTemplate>
   <Triggers >
   <asp:AsyncPostBackTrigger ControlID ="Button3" EventName ="Click"/>
   </Triggers>
   </asp:UpdatePanel>
   
</td>
</tr>--%>
<tr>
<td colspan ="2">
&nbsp;
</td>
</tr>
<tr>
<td colspan ="2" align ="center" >
    <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" Font-Bold="True" 
        Font-Italic="False" ForeColor="Blue" onclick="btnSubmit_Click" />
</td>
</tr>
<tr>
<td colspan ="2">
    &nbsp;
</td>
</tr>

    <tr>
        <td colspan="2" align ="center" >
            <asp:GridView ID="gvSchoolClasses" runat="server" AutoGenerateColumns="False">
            <Columns >
            <asp:BoundField HeaderText ="School Name" DataField ="SchoolName" />
            <asp:BoundField HeaderText ="Address" DataField ="SchoolAdd" />
            <asp:BoundField HeaderText ="Contact Person" DataField ="ContactPerson" />
            <asp:BoundField HeaderText ="Contact Number" DataField ="ContactNo" />
            
            </Columns>
            </asp:GridView>
        </td>
    </tr>

</table>    
</asp:Panel>
</td>
</tr>


<tr >
<td colspan="2">
<asp:Panel runat="server" ID ="StuPanel">
   <table width ="100%">
   <tr>
   <td colspan ="2" align ="center" >    
    <asp:Label ID="Label3" runat="server" Text="Student Entry Form" Font-Bold="True" 
        Font-Size="Large" ForeColor="#009900"></asp:Label>
   </td>
   </tr>
   
   <tr>
   <td>
       <asp:Label ID="Label11" runat="server" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#33CC33" Text="Enter Teacher Mobile No:"></asp:Label>
   </td>
   <td>
       <asp:TextBox ID="txtTecMoNo" runat="server" Width="120px"></asp:TextBox>
       <asp:Button ID="btnTecMoNoSearch"
           runat="server" Text="SEARCH" onclick="btnTecMoNoSearch_Click" Width="80px"/>
   </td>
   </tr>
   
   <tr>
   <td>
       <asp:Label ID="Label10" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#33CC33" runat="server" Text="Teacher Name:"></asp:Label>
   </td>
   <td>
       <asp:Label ID="lblTeacherName" runat="server" Text="Teacher Name" Width="200px"></asp:Label>
   </td>
   </tr>  
   
   <tr>
   <td>
       <asp:Label ID="Label12" runat="server" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#33CC33" Text="Select Group"></asp:Label>
   </td>
   <td>
       <asp:DropDownList ID="ddlTecGroup" runat="server" Width="200px">
       </asp:DropDownList>
   </td>
   </tr>
   <tr>
   <td>
       <asp:Label ID="Label13" runat="server" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#33CC33" Text="Select School"></asp:Label>
   </td>
   <td>
       <asp:DropDownList ID="ddlSchoolList" AutoPostBack ="true"  runat="server" Width="200px" 
           onselectedindexchanged="ddlSchoolList_SelectedIndexChanged">
       </asp:DropDownList>
   </td>
   </tr>
   
    <tr>
   <td>
       <asp:Label ID="Label14" runat="server" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#33CC33" Text="Select Class"></asp:Label>
   </td>
   <td>
   <asp:UpdatePanel ID ="updateClass" runat ="server" >
   <ContentTemplate >
   <asp:DropDownList ID="ddlClassList" runat="server" Width="200px" AutoPostBack="true" 
           onselectedindexchanged="ddlClassList_SelectedIndexChanged">
       </asp:DropDownList>
   </ContentTemplate>
   <Triggers >
   <asp:AsyncPostBackTrigger ControlID ="ddlSchoolList" EventName ="SelectedIndexChanged" />
   </Triggers>
   </asp:UpdatePanel>
       
   </td>
   </tr>
   
    <tr>
   <td align ="center">  
       <asp:Button ID="btnAddStudent" Font-Bold="True" 
        Font-Italic="False" ForeColor="Blue" runat="server" Text="Add Student" 
           onclick="btnAddStudent_Click" />   
   </td>
   <td align ="center" >
       <asp:Button ID="Button4" runat="server" Text="Send SMS" Font-Bold="True" 
        Font-Italic="False" ForeColor="Blue" onclick="Button4_Click"/>
    <asp:ModalPopupExtender ID="SendSMSmp" DropShadow ="true"  runat="server" TargetControlID ="Button4" PopupControlID ="sendSmsPanel" CancelControlID ="btnCancelSms">
    </asp:ModalPopupExtender>
   </td>
   </tr>
   
    <tr>
   <td align ="center" colspan="2">   
   <asp:UpdatePanel ID ="StuUpdatePanel" runat ="server" >
   <ContentTemplate >
   <asp:GridView ID="gvStudentList" runat="server" AutoGenerateColumns="False">
   <Columns >
   <asp:BoundField HeaderText ="Roll No" DataField ="rno" />
   <asp:BoundField HeaderText ="First Name" DataField ="fn" />
   <asp:BoundField HeaderText ="Mid Name" DataField ="mn" />
   <asp:BoundField HeaderText ="Last Name" DataField ="ln" />
   <asp:BoundField HeaderText ="Gender" DataField ="g" />
   <asp:BoundField HeaderText ="Father Mo No" DataField ="mno" />
   </Columns>
       </asp:GridView>   
   </ContentTemplate>
   <Triggers >
   <asp:AsyncPostBackTrigger ControlID ="ddlClassList" EventName ="SelectedIndexChanged" />
   </Triggers>
   </asp:UpdatePanel>       
   </td>
   </tr>
   
   </table>
    
</asp:Panel>
</td>
</tr>
<tr>
<td colspan ="2" align ="center" >
    <asp:ModalPopupExtender ID="ModalPopupExtender1" DropShadow ="true"  runat="server" TargetControlID ="btnAddStudent" PopupControlID ="AddStudentPanel" CancelControlID ="btnCancel">
    </asp:ModalPopupExtender>
    <asp:Panel ID="AddStudentPanel" BackColor ="Aqua"  runat="server" Width ="400px" Height ="370px">
    <table width ="100%">
    <tr>
    <td align ="center" colspan ="2" style ="width :400px">
        <asp:Label ID="Label15" runat="server" Text="New Student Entry Form." Font-Bold="True" 
        Font-Size="Larger" ForeColor="#FF0066"></asp:Label>
    </td>    
    </tr>
    <tr>
    <td colspan ="2"> &nbsp; </td>
    </tr>
    <tr>
    <td style ="width :200px">
        <asp:Label ID="Label17" runat="server" Text="Student's Father First Name:" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#FF0066"></asp:Label>
    </td>
    <td style ="width :200px">
        <asp:TextBox ID="txtSFfname" runat="server" Width="200px"></asp:TextBox>  
    </td>
    </tr>
    
    <tr>
    <td style ="width :200px">
        <asp:Label ID="Label18" runat="server" Text="Student's Father Last Name:" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#FF0066"></asp:Label>
    </td>
    <td style ="width :200px">
        <asp:TextBox ID="txtSFlname" runat="server" Width="200px" ></asp:TextBox>
    </td>
    </tr>
    
    <tr>
    <td style ="width :200px">
     <asp:Label ID="Label16" runat="server" Text="Father Mobile No:" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#FF0066"></asp:Label>
    </td>
    <td style ="width :200px">
        <asp:TextBox ID="txtSFmono" runat="server" Width="200px" BackColor="White"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td style ="width :200px">
    <asp:Label ID="Label23" runat="server" Text="PIN Code:" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#FF0066"></asp:Label>
    </td>
    <td style ="width :200px">
      <asp:TextBox ID="txtSFpin" runat="server" Width="200px" BackColor="White"></asp:TextBox>
    </td>
    </tr>
    
    
        <tr>
    <td style ="width :200px">
        <asp:Label ID="Label19" runat="server" Text="Son/Doughter First Name:" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#FF0066"></asp:Label>
    </td>
    <td style ="width :200px">
        <asp:TextBox ID="txtSFfsonName" runat="server" Width="200px"></asp:TextBox>
    </td>
    </tr>
    
        <tr>
    <td style ="width :200px">
        <asp:Label ID="Label20" runat="server" Text="Select Gender:" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#FF0066"></asp:Label>
    </td>
    <td style ="width :200px">
        <asp:DropDownList ID="ddlSFgenger" runat="server" Width="200px">
        <asp:ListItem Text ="Male" Value ="1" Selected ="True" ></asp:ListItem>
        <asp:ListItem Text ="Femail" Value ="2"></asp:ListItem>
        </asp:DropDownList>
    </td>
    </tr>
    
        <tr>
    <td style ="width :200px">
        <asp:Label ID="Label21" runat="server" Text="Son Number:" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#FF0066"></asp:Label>
    </td>
    <td style ="width :200px">
        <asp:DropDownList ID="ddlSFsonNo" runat="server" Width="200px">
        <asp:ListItem Text="First" Value ="1" Selected ="True" ></asp:ListItem>
        <asp:ListItem Text ="Second" Value ="2" ></asp:ListItem>
        <asp:ListItem Text ="Third" Value ="3"></asp:ListItem>
        </asp:DropDownList>
    </td>
    </tr>
    
        <tr>
    <td style ="width :200px">
        <asp:Label ID="Label22" runat="server" Text="Roll Number:" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#FF0066"></asp:Label>
    </td>
    <td style ="width :200px">
        <asp:TextBox ID="txtSFrollNo" runat="server" Width="200px"></asp:TextBox>
    </td>
    </tr>
        <tr>
    <td colspan ="2"> &nbsp; </td>
    </tr>
    <tr>
    <td style ="width :200px" align ="center" >
        <asp:Button ID="Button5" runat="server" Text="SAVE" BackColor="#009900" 
            Font-Bold="True" ForeColor="Blue" Width="80px" onclick="Button5_Click" />
    </td>
    <td style ="width :200px" align ="center" >
        <asp:Button ID="btnCancel" runat="server" Text="CANCEL" BackColor="#009900" 
            Font-Bold="True" ForeColor="Blue" Width="80px" />
    </td>
    </tr>
    </table>
    </asp:Panel>
</td>
</tr>
<tr>
<td colspan ="2" align ="center" >
    
    <asp:Panel ID="sendSmsPanel" BackColor ="Aqua"  runat="server" Width ="400px" Height ="370px">
    <table width ="100%">
    <tr>
    <td align ="center" colspan ="2">
        <asp:Label ID="Label24" runat="server" 
            Text="SMS Service for Father of Student." Font-Bold="True" 
        Font-Size="Large" ForeColor="#CC0066"></asp:Label>
    </td>
    </tr>
    <tr>
    <td colspan ="2">
    &nbsp;
    </td>
    </tr>
    <tr>
    <td style="width :50%">
        <asp:Label ID="Label25" runat="server" Text="Message Type:" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#CC0066"></asp:Label>
    </td>
    <td align ="center" style="width :50%">
    <%--<asp:UpdatePanel ID="smsUp" runat ="server" >
    <ContentTemplate >--%>
    <asp:DropDownList ID ="ddlSMStype" runat ="server" Width="150px" 
             AutoPostBack ="false" >
    <asp:ListItem Text ="Present" Value ="pr" Selected ="True" ></asp:ListItem>
    <asp:ListItem Text ="Absent" Value ="ab"  ></asp:ListItem>
    <asp:ListItem Text ="Text SMS" Value ="tsms" ></asp:ListItem>
    </asp:DropDownList>    
    <%-- </ContentTemplate>
     <Triggers >
     <asp:AsyncPostBackTrigger ControlID ="ddlSMStype" EventName ="SelectedIndexChanged" />
     </Triggers>
    </asp:UpdatePanel>--%>
    </td>
    </tr>
    <tr>
    <td style="width :50%">
    <asp:Label ID="Label26" runat="server" Text="Note:" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#CC0066"></asp:Label>
    </td> 
    <td style="width :50%">
        For Present/Absent SMS Enter Roll Numbers in comma seprated. Eg:1001,1002,...<br/>
        And For Simpal Text SMS enter text. Eg: Tommarow holiday....
    </td>
    </tr>
    
    <tr>
    <td style="width :50%">
        <asp:Label ID="lblEntRollNo" runat="server" Text="Enter SMS (Please read note.)" Font-Bold="True" 
        Font-Size="Medium" ForeColor="#CC0066"></asp:Label>
    </td>
    <td style="width :50%">
        
        <asp:TextBox ID="txtPrAbSMS" runat="server" Height="100px" TextMode="MultiLine" 
            Width="250px"></asp:TextBox>
    </td>
    </tr>
   <%-- <tr>
        <td>
            <asp:Label ID="lblCommonSms" runat="server" Font-Bold="True" Font-Size="Medium" 
                ForeColor="#CC0066" Text="Enter Common Class Text SMS"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtCommonSms" runat="server" Height="100px" TextMode="MultiLine" 
            Width="250px"></asp:TextBox>
        </td>
    </tr>--%>
    <tr>
    <td colspan ="2">
    &nbsp;
    </td>
    </tr>
        <tr>
            <td align ="center" style="width :50%">
                <asp:Button ID="btnSendSms" runat="server" Text="SEND SMS" 
                    onclick="btnSendSms_Click" />
            </td>
            <td align ="center" style="width :50%">
                <asp:Button ID="btnCancelSms" runat="server" Text="CANCEL" />
            </td>
        </tr>
    
    </table>
    </asp:Panel>
</td>
</tr>
</table>
</asp:Content>

