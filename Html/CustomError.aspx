<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomError.aspx.cs" Inherits="UI_CustomError" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/Maincss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <br />
    <div class="searchResultHeader" align="center">
        <asp:Label ID="lblError" runat="server" Text="Come2MyCity Session Expiry"></asp:Label>
    </div>
    <br />
    <br />
    <br />
    <div align="center">
        <label style="font-size: larger; color: Red; font-weight: bold;">
            Your Session has Expired.</label>
        <br />
        <%--<label style="font-size: 10px;">
            Unfortunately the page you looking for is not found.</label>--%>
    </div>
   

    <div>
        <label style="font-size: 14px; font-weight: bold">
            This error has occured for one of the following reasons :</label>
        <br />
        <br />
        <ul>
            <li>
                <label style="padding-left: 20px; line-height: 30px;">
                    You have kept the browser window idle for a long time
                </label>
            </li>
            <li>
                <label style="padding-left: 20px; line-height: 30px;">
                    Please Click  <a href="http://www.come2mycity.com">Here</a> to go to Login Page
                </label>
            </li>
            <li>
                <label style="padding-left: 20px; line-height: 30px;">
                    If you still encounter the problem.Please inform Us.
                </label>
            </li>
        </ul>
        <br />
    </div>
    </form>
</body>
</html>
