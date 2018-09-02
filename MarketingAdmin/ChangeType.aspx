<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="ChangeType.aspx.cs" Inherits="MarketingAdmin_ChangeType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table border="0" cellpadding="0" cellspacing="0" width="100%">
 <tr><td>Search By Mobile No</td>
   <td><asp:TextBox ID="txtMobileNo" runat="server"></asp:TextBox> </td></tr>
 <tr><td></td>
  <td><asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Search" 
          onclick="btnSearch_Click" />
     </td></tr>
     
  <tr><td></td>
  <td><asp:Label ID="lblError" runat="server" CssClass="Error" Visible="false"></asp:Label>
     </td></tr>   
     
 <tr><td style="height: 24px">Make it</td><td style="height: 24px"><asp:Button ID="btnUser" runat="server" Text="User" 
         CssClass="button" onclick="btnUser_Click"/>
 &nbsp;<asp:Button ID="btnMarketing" runat="server" Text="MarketingPerson" 
         CssClass="button" onclick="btnMarketing_Click"/> </td></tr>


<tr><td colspan="2" >

 <legend class="sub-heading">:: Contact Address ::</legend>
    <asp:GridView ID="gvContactDisplay" AutoGenerateColumns="false" runat="server" Width="100%"
        ShowHeader="false">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table class="grdTable">
                        <tr class="grdTr">
                            <td class="grdTdLabel">
                                <asp:Label ID="lblName" runat="server" Text="Name :"></asp:Label>
                            </td>
                            <td class="grdTdValue">
                                <asp:Label ID="Label18" runat="server" Text='<%#Eval("usrFullName") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr class="grdTr">
                            <td class="grdTdLabel">
                                <asp:Label ID="lblAddress" runat="server" Text="Address :"></asp:Label>
                            </td>
                            <td class="grdTdValue">
                                <asp:Label ID="myAddress" runat="server" Text='<%#Eval("usrAddress") %>'></asp:Label>
                            </td>
                        </tr>
                                 <tr class="grdTr">
                            <td class="grdTdLabel">
                                <asp:Label ID="Label13" runat="server" Text="Area/Village :"></asp:Label>
                            </td>
                            <td class="grdTdValue">
                                <asp:Label ID="Label14" runat="server" Text='<%#Eval("usrArea") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr class="grdTr">
                            <td class="grdTdLabel">
                                <asp:Label ID="Label5" runat="server" Text="City :"></asp:Label>
                            </td>
                            <td class="grdTdValue">
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("usrCity") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr class="grdTr">
                            <td class="grdTdLabel">
                                <asp:Label ID="Label3" runat="server" Text="District :"></asp:Label>
                            </td>
                            <td class="grdTdValue">
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("usrDistrict") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr class="grdTr">
                            <td class="grdTdLabel">
                                <asp:Label ID="Label1" runat="server" Text="State :"></asp:Label>
                            </td>
                            <td class="grdTdValue">
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("usrState") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr class="grdTr">
                            <td class="grdTdLabel">
                                <asp:Label ID="Label7" runat="server" Text="PIN :"></asp:Label>
                            </td>
                            <td class="grdTdValue">
                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("usrPIN") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr class="grdTr">
                            <td class="grdTdLabel">
                                <asp:Label ID="Label9" runat="server" Text="Phone Number :"></asp:Label>
                            </td>
                            <td class="grdTdValue">
                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("usrPhoneNo") %>'></asp:Label>
                            </td>
                        </tr>
                      
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</td></tr>
</table>
</asp:Content>

