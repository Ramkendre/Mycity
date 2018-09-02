<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mahesh.aspx.cs" Inherits="Mahesh" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID ="smt" runat ="server" >
    </asp:ScriptManager>
    <div>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label1" runat="server" Text="Mahesh Enter Your Security Password"></asp:Label>
        &nbsp;<br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Continew" />
    
    </div>
    <div>
    <asp:UpdatePanel ID ="up1" runat ="server" >
    <ContentTemplate >
    <table width ="400px">
    <tr>
    <td>
    Current Time:
    </td>
    <td >
    <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
    </td>
    </tr>
    <tr >
    <td>
    Last Flag Set Time:
    </td>
    <td>
     <asp:Label ID="lblLastUpdate" runat="server" Text="Label"></asp:Label>
    </td>
    </tr>
    </table>
         
       
    </ContentTemplate>
    <Triggers >
     <asp:AsyncPostBackTrigger ControlID ="t1" EventName ="Tick" />
    </Triggers>
    
    </asp:UpdatePanel>
    <asp:Timer ID ="t1" runat ="server" Interval="1000" ontick="t1_Tick" ></asp:Timer>
    
    </div>
    <%--<iframe src="http://free.timeanddate.com/clock/i21nw669/n771/tlin/fs12/fcfff/tct/pct/tt0/tm1/td2/th2" frameborder="0" height="20"></iframe>--%>
    </form>
</body>
</html>
