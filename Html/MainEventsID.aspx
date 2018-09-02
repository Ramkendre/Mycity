<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true" CodeFile="MainEventsID.aspx.cs" Inherits="Html_MainEventsID" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />--%>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="MainDiv">
        <div class="InnerDiv">
           
           
            <table class="tblSubFull2">
            <%-- <tr>
                    <td align="right">
                        ID
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtSubID" runat="server" CssClass="ccstxt"></asp:TextBox>
                    </td>
                </tr>--%>
                <tr>
                    <td align="right">
                        Name
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TxtSubName" runat="server" CssClass="ccstxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                <td align="right">
                    Description
                </td>
                <td align="left">
                <asp:TextBox ID="txtSubDesc" runat="server" CssClass="ccstxt"></asp:TextBox>
                </td>
                </tr>
             <tr>
                <td>
                
                </td>
                <td>
                    <asp:Button ID="btnSubSubmit" runat="server" Text="Submit" onclick="btnSubSubmit_Click" 
                         />
                </td>
                </tr>
            </table>
            <table class="tblSubFull2">
            <div style="overflow: scroll; height: 200px; width:650px; border: 1px solid #dddddd;">
            <asp:GridView ID="gvItem" runat="server">
            
            </asp:GridView>
            <asp:Label ID="lblId" runat="server"></asp:Label>
            </div>
            </table>
        </div>
    </div>

</asp:Content>

