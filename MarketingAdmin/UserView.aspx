<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="UserView.aspx.cs" Inherits="Admin_UserView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<table cellpadding="0" cellspacing="0" width="70%" border="1" ><tr><td align="center" >
            <div style="width: 95%">
                <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                    <tr>
                        <td colspan="2"  style="height: 20px;">
                            <span class="warning1" style="color: Red;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 20px;">
       <table style="width: 100%" class="tables" cellspacing="2" cellpadding="2">
        <tr>
             <td ></td>
            <td colspan="3" align="center">
                <h3>
                    <asp:Label ID="lblHeader" runat="server" Text="User Details "></asp:Label></h3>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" >
                &nbsp;&nbsp;<asp:Label ID="lblError" Visible="false" runat="server" CssClass="error" Text="Label"></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td align="left" style="width:20%;"  >
                Login Id
            </td>
            <td align="left" style="width:30%;"  >
                <asp:Label ID="lblId" runat="server" Text="0"></asp:Label>
            </td>
            <td align="left" style="width:20%;"  >
                Password
            </td>
            <td align="left" style="width:30%;"  >
                <asp:Label ID="lblPassword" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        
        <tr>
            <td align="left" style="width:20%;"  >
                User Name 
            </td>
            <td align="left" style="width:30%;"  >
                
                <asp:Label ID="lblUserName" runat="server"></asp:Label>
            </td>
            <td align="left" style="width:20%;"  >
                Contact No 
            </td>
            <td align="left" style="width:30%;"  >
                <asp:Label ID="lblContactNo" runat="server"></asp:Label>
            </td>
        </tr>
        
        
        <tr>
            <td align="left" style="width:20%;"  >
                Address
            </td>
            <td align="left" style="width:30%;"  >
                <asp:Label ID="lblAddress" runat="server"></asp:Label>
            </td>
            <td align="left" style="width:20%;"  >
                DOJ
            </td>
            <td align="left" style="width:30%;"  >
            <asp:Label ID="lblDOJ" runat="server"></asp:Label>
            </td>
        </tr>
          
        <tr>
            <td align="left" style="width:20%;"  >
                Role Name 
            </td>
            <td align="left" style="width:30%;"  >
                <asp:Label ID="lblRole" runat="server"></asp:Label>
            </td>
            <td align="left" style="width:20%;"  >
                Area
            </td>
            <td align="left" style="width:30%;"  >
                <asp:Label ID="lblCompany" runat="server"></asp:Label>
            </td>
        </tr>
        
        <tr>
          <td></td>
            <td colspan="2"  align="right" style="padding-right:20px;">
                <asp:Button ID="btnSubmit" runat="server" Text="Back" CssClass="button"  
                    OnClick="btnSubmit_Click" Width="80px"  />
                &nbsp;
                
            </td>
            <td>
                
            </td>
        </tr>
    </table>
    <br />
    </td></tr></table></div>
    
     </td></tr></table>
            </ContentTemplate></asp:UpdatePanel>
</asp:Content>







