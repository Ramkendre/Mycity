<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AppRegForm.aspx.cs" Inherits="html_AppRegForm"
    EnableEventValidation="true" %>




<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../KResource/CSS/ControllerCSS.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    &nbsp&nbsp&nbsp&nbsp
    <div>
       <%-- <asp:scriptmanager ID="Scriptmanager1" runat="server"></asp:scriptmanager>--%>
         <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"/>
        Enter mobile number To search :
        <asp:TextBox ID="txtsearch" runat="server" Width="156px" Height = "25px" ></asp:TextBox>
            <ajax:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtsearch" 
MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" CompletionInterval="100" ServiceMethod="GetCountries" >
</ajax:AutoCompleteExtender> 
       <%-- <asp:Button ID="btnSearch" runat="server" Text="Search" Width="80px" 
            onclick="btnSearch_Click" />--%>
        <asp:ImageButton ID="btnSearch" runat="server" Height = "25px" Width="79px" 
            ImageUrl ="~/images/Searchimg.png" onclick="btnSearch_Click"   />
        <%--<asp:Button ID="btnsearchBymaxId" runat="server" Text="Search By Max Id" 
            onclick="btnsearchBymaxId_Click" />--%>
        <asp:ImageButton ID="btnsearchBymaxId" runat="server" Height = "25px" Width="79px" 
            ImageUrl ="~/images/img.png" onclick="btnsearchBymaxId_Click"   />
    </div>
     <br />
    <div>
    Project wise Search:&nbsp&nbsp&nbsp;
        <asp:DropDownList ID="ddlProjectList" runat="server" CssClass="cssddlwidth" 
            AutoPostBack="true" 
            onselectedindexchanged="ddlProjectList_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
   
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="true" PageSize="100" CssClass="gridview"
            AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
            OnSelectedIndexChanging="GridView1_SelectedIndexChanging" 
            onpageindexchanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:BoundField DataField="EzeeDrugAppId" HeaderText="EzeeDrugAppId"></asp:BoundField>
                <asp:BoundField DataField="keyword" HeaderText="keyword"></asp:BoundField>
                <asp:BoundField DataField="strDevId" HeaderText="strDevId"></asp:BoundField>
                <asp:BoundField DataField="strSimSerialNo" HeaderText="strSimSerialNo"></asp:BoundField>
                <asp:BoundField DataField="firstName" HeaderText="firstName"></asp:BoundField>
                <asp:BoundField DataField="lastName" HeaderText="lastName"></asp:BoundField>
                <asp:BoundField DataField="firmName" HeaderText="firmName"></asp:BoundField>
                <asp:BoundField DataField="mobileNo" HeaderText="mobileNo"></asp:BoundField>
                <asp:BoundField DataField="address" HeaderText="address"></asp:BoundField>
                <asp:BoundField DataField="eMailId" HeaderText="eMailId"></asp:BoundField>
                <asp:BoundField DataField="typeOfUse_Id" HeaderText="typeOfUse_Id"></asp:BoundField>
                <asp:BoundField DataField="pincode" HeaderText="pincode"></asp:BoundField>
                <asp:BoundField DataField="EntryDate" HeaderText="EntryDate"></asp:BoundField>
                <asp:BoundField DataField="RefMobileNo" HeaderText="RefMobileNo"></asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
