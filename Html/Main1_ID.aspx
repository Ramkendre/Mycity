<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="Main1_ID.aspx.cs" Inherits="Html_Main1_ID" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />--%>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="MainDiv">
        <div class="InnerDiv">
            <table class="tblSubFull2">
                <tr>
                    <td align="right">
                        ID
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtID" runat="server" CssClass="ccstxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Sub_ID
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtSub_ID" runat="server" CssClass="ccstxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Name
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtName" runat="server" CssClass="ccstxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Description
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDesc" runat="server" CssClass="ccstxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        User
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtUser" runat="server" CssClass="ccstxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                <td></td>
                <td><asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                        onclick="btnSubmit_Click"/></td>
                </tr>
            </table>
            <table class="tblSubFull2">
            <div>
            <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false">
            
            </asp:GridView>
            <asp:Label ID="lblId" runat="server"></asp:Label>
            </div>
            </table>
        </div>
    </div>
</asp:Content>
