<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SmsReportStatus.aspx.cs" Inherits="SmsReportStatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../KResource/CSS/ControllerCSS.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div>
        <asp:GridView ID="Gv_Smsstatus" runat="server" CssClass="gridview" AllowPaging="true" AlternatingRowStyle-BackColor="#ccccff"
            HeaderStyle-BackColor="#339966" CellSpacing="10" CellPadding="10" PageSize="30" OnPageIndexChanging="Gv_Smsstatus_PageIndexChanging">

        </asp:GridView>
    </div>
    </form>
</body>
</html>
