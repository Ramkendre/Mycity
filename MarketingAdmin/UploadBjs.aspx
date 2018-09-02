<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadBjs.aspx.cs" Inherits="UploadBjs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="CSS/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="header">
        <h1>
            Upload BJS Bulettin</h1>
    </div>
    <div class="section">
        <div id="messagediv" runat="server" class="validation-summary-valid">
            <asp:Label ID="messagelbl" runat="server"></asp:Label>
        </div>
        <div>
      
            <asp:Label ID="Label1" Text="Choose File" CssClass="editor-label" runat="server"></asp:Label>
        
        <asp:FileUpload ID="uploadfile" runat="server" />
        </div>
        <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
    </div>
    </form>
</body>
</html>
