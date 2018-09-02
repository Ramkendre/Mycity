<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MobileTrackerReport.aspx.cs" Inherits="html_MobileTrackerReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="gvItem" runat="server" 
            onpageindexchanging="gvItem_PageIndexChanging" AllowPaging="true" PageSize="20">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
