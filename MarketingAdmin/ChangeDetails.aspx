<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="ChangeDetails.aspx.cs" Inherits="Admin_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

    <table cellpadding="0" cellspacing="0" border="0" width="80%" class="tables">
        <tr>
            <td colspan="2">
                <div class="row">
                    <asp:Label ID="ErrorMsg" runat="server" Width="599px" CssClass="error"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 150px; height: 25px;" align="center">
                Login Id
            </td>
            <td style="width: 250px; height: 25px;">
                <asp:TextBox ID="txtLoginId"  MaxLength="30" ReadOnly="true"  runat="server" AutoPostBack="false" 
                    TabIndex="1" Width="240px" ></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td style="height: 25px;" align="center">
                User Name
            </td>
            <td style="height: 25px;">
                <asp:TextBox ID="txtUserName" ValidationGroup="user" runat="server" MaxLength="100"  
                    TabIndex="1" Width="240px"></asp:TextBox>
                <span>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserName"
                         ErrorMessage=" User Name is Missing.." ValidationGroup="user">&nbsp;</asp:RequiredFieldValidator></span>
            </td>
        </tr>
        <tr>
            <td style="height: 25px;" align="center">
                Password
            </td>
            <td style="height: 25px;">
                <asp:TextBox ID="txtPassword" runat="server" ValidationGroup="user" MaxLength="20" AutoPostBack="false"
                    TabIndex="1" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="user" runat="server" ControlToValidate="txtPassword"
                      ErrorMessage=" Password is Missing.."></asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr>
            <td style="height: 25px;" align="center">
                Re-Password
            </td>
            <td style="height: 25px;">
                <asp:TextBox ID="txtRePassword" ValidationGroup="user" runat="server" AutoPostBack="false"
                    TabIndex="1" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="comValid" ValidationGroup="user" runat="server" ControlToValidate="txtRePassword" 
                ControlToCompare="txtPassword" ErrorMessage="Re-Password should be same as password" 
                 Type="String" ></asp:CompareValidator>  
                 
            </td>
        </tr>
        
        
        <tr>
            <td style="height: 25px;" align="center">
                Contact No
            </td>
            <td style="height: 25px;">
                <asp:TextBox ID="txtContactNo" ValidationGroup="user" runat="server" MaxLength="20"  
                    TabIndex="1" Width="240px"></asp:TextBox>
                <span>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContactNo"
                        ValidationGroup="user" ErrorMessage="Contact no is Missing..">&nbsp;</asp:RequiredFieldValidator></span>
            </td>
        </tr>
        <tr>
            <td style="height: 25px;" align="center">
                Address
            </td>
            <td style="height: 25px;">
                <asp:TextBox ID="txtAddress" runat="server" MaxLength="100"  
                    TabIndex="1" Width="240px"></asp:TextBox>
                
            </td>
        </tr>
        
        <tr>
            <td style=" height: 25px;" colspan="1"></td>
            <td style=" height: 25px;" colspan="1">
                <asp:Button ID="btnUpdate" ValidationGroup="user" runat="server" Text="Update" TabIndex="2" 
                    CssClass="button" onclick="btnUpdate_Click" />
                &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="button" 
                    OnClick="btnBack_Click" Text="Back" />
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>


