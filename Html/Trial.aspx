<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Trial.aspx.cs" Inherits="Html_Trial" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="sm1" runat ="server" ></asp:ScriptManager>
    <div>
    <table width ="800px">
    <tr>
    <td style ="width :400px" align ="center" >
    <table width ="400px">
    <tr>
    <td align ="center" style ="width :200px">
        <asp:Label ID="Label2" runat="server" Text="Select State"></asp:Label>
    </td>   
    <td align ="center" style ="width :200px">
        <asp:DropDownList ID="DropDownList1" Width ="150px" AutoPostBack ="true"  runat="server" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
    </td> 
    </tr>
    <tr>
    <td colspan ="2" style ="width :400px">
      <asp:UpdatePanel ID ="UPdist" runat ="server" >
       <ContentTemplate >
        <table width ="400px">
        <tr>
        <td align ="center" style ="width :200px">
            <asp:Label ID="Label3" runat="server" Text="Select District"></asp:Label>
        </td>
        <td align ="center" style ="width :200px">
            <asp:DropDownList ID="DropDownList2" Width ="150px" runat="server" AutoPostBack="true" 
                onselectedindexchanged="DropDownList2_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
        </tr>
        </table>
       </ContentTemplate>
       <Triggers >
       <asp:AsyncPostBackTrigger ControlID ="DropDownList1" EventName ="SelectedIndexChanged" />
       </Triggers>
      </asp:UpdatePanel>    
    </td>   
    </tr>
    
    <tr>
    <td colspan ="2" style ="width :400px">
      <asp:UpdatePanel ID ="UPcity" runat ="server" >
       <ContentTemplate >
       <table width ="400px">
        <tr>
        <td align ="center" style ="width :200px">
            <asp:Label ID="Label4" runat="server" Text="Select City"></asp:Label>
        </td>
        <td align ="center" style ="width :200px">
            <asp:DropDownList ID="DropDownList3" Width="150px" runat="server" AutoPostBack="true" 
                onselectedindexchanged="DropDownList3_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
        </tr>
        </table>
       </ContentTemplate>
       <Triggers >
       <asp:AsyncPostBackTrigger ControlID ="DropDownList2" EventName ="SelectedIndexChanged" />
       </Triggers>
      </asp:UpdatePanel>    
    </td>   
    </tr>
    
    </table>
    </td>
    </tr>
    </table>
    </div>
    
    </form>
</body>
</html>
