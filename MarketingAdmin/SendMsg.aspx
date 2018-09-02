<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="SendMsg.aspx.cs" Inherits="MarketingAdmin_SendMsg" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <!--===================================================================================================
        ==================================== UPDATE PROGRESS ==============================================
        ================================================================================================-->
    <div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="false" DisplayAfter="0">
            <ProgressTemplate>
                <div style=" position: absolute; top: 150px; z-index: 100;background-color:#23a9ec; color: White; font-weight: bold;
                    font-family: Tahoma; font-size: 10pt; border: solid 1px #00496e; width: 170px;
                    padding: 2px; display: block;">
                    &nbsp;&nbsp; Processing, wait
                   
                    &nbsp;
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    <asp:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Top"
        HorizontalOffset="0" VerticalOffset="0">
    </asp:AlwaysVisibleControlExtender>
    <%--<asp:UpdateProgress runat="server" ID="UpdateProgress1">
        <ProgressTemplate>
            <div style="left: 40%; visibility: visible; background-color: /* #0081c2; */#23a9ec; color: White; font-weight: bold; ">
                &nbsp;&nbsp; Processing, wait
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
    <!-- ==================================================================================================
         ================================= UPDATE PROGRESS ENDS ===========================================
         ================================================================================================-->
         <asp:UpdatePanel ID="up" runat="server">
         <ContentTemplate>
         <table cellpadding="0" cellpadding="0" border="0">
         <tr><td><h3> Message Sending </h3></td></tr>
         <tr><td><asp:Button ID="Send" runat="server" Text="SendMsg" CssClass="button" 
                 onclick="Send_Click" /></td></tr>
         <tr><td><asp:Label ID="lblMessage" runat="server"></asp:Label></td></tr>
         </table>
         </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>

