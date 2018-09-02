<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataList.aspx.cs" Inherits="DataList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DataList ID="DataList1" runat="server" DataKeyField="Eid" 
            DataSourceID="SqlDataSource1" RepeatColumns="3"
              RepeatDirection="Horizontal">
            <ItemTemplate>
                Eid:
                <asp:Label ID="EidLabel" runat="server" Text='<%# Eval("Eid") %>' />
                <br />
                Ename:
                <asp:Label ID="EnameLabel" runat="server" Text='<%# Eval("Ename") %>' />
                <br />
                Esal:
                <asp:Label ID="EsalLabel" runat="server" Text='<%# Eval("Esal") %>' />
                <br />
                <br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DB_PracticeConnectionString %>" 
            SelectCommand="SELECT * FROM [Emp]"></asp:SqlDataSource>
    </div>
    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
    <HeaderTemplate >
     <table>
     <tr>
    </HeaderTemplate>
     
     <ItemTemplate >
      <td> <%#Eval("Eid") %>>
      <br/>
      <td> <%#Eval("Ename") %>>
      <br/>
      <td> <%#Eval("Esal") %>>
      <br/>
     </ItemTemplate>  
    <FooterTemplate >
     </tr>
     </table>
    </FooterTemplate>
    </asp:Repeater>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DB_PracticeConnectionString %>" 
            SelectCommand="SELECT * FROM [Emp]"></asp:SqlDataSource>
    
    </form>
</body>
</html>
