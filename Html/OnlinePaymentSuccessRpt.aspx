<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OnlinePaymentSuccessRpt.aspx.cs"
    Inherits="Html_OnlinePaymentSuccessRpt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../KResource/CSS/ControllerCSS.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center; padding:5px;">
        <div>
        Enter Mobile No:
            <asp:TextBox ID="txtSearch" runat="server" CssClass="ccstxt"></asp:TextBox>
            <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="cssbtn" OnClick="btnsearch_Click" />
            &nbsp;&nbsp;
            <asp:DropDownList ID="ddlsort" runat="server" CssClass="cssddlwidth" 
                AutoPostBack="true" onselectedindexchanged="ddlsort_SelectedIndexChanged">
                <asp:ListItem Value="0">--Select--</asp:ListItem>
                <asp:ListItem Value="1">SUCCESS</asp:ListItem>
                <asp:ListItem Value="2">CANCELED</asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />
        <div>
            <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="false" CssClass="gridview">
                <Columns>
                    <asp:TemplateField HeaderText="Sr.No">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="FirstName" DataField="FirstName" />
                    <asp:BoundField HeaderText="LastName" DataField="LastName" />
                    <asp:BoundField HeaderText="MobileNumber" DataField="MobileNumber" />
                    <asp:BoundField HeaderText="EmailId" DataField="EmailId" />
                    <asp:BoundField HeaderText="ProductName" DataField="ProductName" />
                    <asp:BoundField HeaderText="Amount" DataField="Amount" />
                    <asp:BoundField HeaderText="TransactionDate" DataField="TransactionDate" />
                    <asp:BoundField HeaderText="TransactionStatus" DataField="TransactionStatus" />
                    <asp:BoundField HeaderText="ScrachCode" DataField="ScrachCode" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
