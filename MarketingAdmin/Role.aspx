<%@ Page Title="::Lodgin : State Master ::" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" 
CodeFile="Role.aspx.cs" Inherits="Admin_Role" EnableViewState="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<table cellpadding="0" cellspacing="0" width="70%" border="1" ><tr><td align="center" >
            <div style="width: 80%">
                <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                    <tr>
                        <td  style="height: 20px;">
                            <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;">
       <table style="width: 100%" class="tables" cellspacing="7px">
        <tr>
             <td></td>
            <td colspan="2" align="center">
                <h3>
                    <asp:Label ID="lblHeader" runat="server" Text="Role Master"></asp:Label></h3>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" >
                &nbsp;&nbsp;<asp:Label ID="lblError" Visible="false" runat="server" CssClass="error" Text="Label"></asp:Label></td>
        </tr>
           
           
        <tr>
            <td style="height: 62px" >
                <asp:Label ID="lblRoleName" runat="server" Text="Role Name :"></asp:Label>
                <label >*</label>
            </td>
            <td style="height: 62px" >
                <asp:TextBox ID="txtRoleName" runat="server" Width="198px" ></asp:TextBox>
            </td>
            <td class="error" style="height: 62px" >
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"   ValidationGroup="vgpStateSubmit"
                 SetFocusOnError="true"    ControlToValidate="txtRoleName" ErrorMessage="* Role Name is Must"></asp:RequiredFieldValidator>
            
                 
            </td>
        </tr>
         <tr>
            <td style="height: 62px" >
                <asp:Label ID="lblRoleDescription" runat="server" Text="Role Description :"></asp:Label>
                <label >*</label>
            </td>
            <td style="height: 62px" >
                <asp:TextBox ID="txtRoleDescription" runat="server" Width="198px" ></asp:TextBox>
            </td>
            <td class="error" style="height: 62px" >
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"   ValidationGroup="vgpStateSubmit"
                 SetFocusOnError="true"    ControlToValidate="txtRoleDescription" ErrorMessage="* Role Description is Must"></asp:RequiredFieldValidator>
            
                 
            </td>
        </tr>
        <tr>
            <td style="height: 62px" >
                <asp:Label ID="lblUnderrole" runat="server" Text="Under Role :"></asp:Label>
                <label >*</label>
            </td>
            <td style="height: 62px" >
                <asp:DropDownList ID="ddlRole" runat="server">
                </asp:DropDownList>
            </td>
            <td class="error" style="height: 62px" >
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"   ValidationGroup="vgpStateSubmit"
                 SetFocusOnError="true"    ControlToValidate="ddlRole" ErrorMessage="* Under Role is Must"></asp:RequiredFieldValidator>
            
                 
            </td>
        </tr>
        
        <tr>
          <td></td>
            <td colspan="2" align="center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" ValidationGroup="vgpStateSubmit"
                    OnClick="btnSubmit_Click"  />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" CssClass="button" 
                    OnClick="btnCancel_Click" Text="Cancel" />
                &nbsp;
                <asp:Button ID="btnBack" runat="server" CssClass="button" OnClick="btnBack_Click" 
                    Text="Back" />
            </td>
        </tr>
    </table>
    <br />
    </td></tr></table></div>
    <div class="grid" style="width: 100%">
                <div class="rounded">
                    <div class="top-outer">
                        <div class="top-inner">
                            <div class="top">
                                &nbsp;
                            </div>
                        </div>
                    </div>
                    <div class="mid-outer">
                        
                        <div class="mid-inner">
                            <div class="mid">
                                <div class="pager">
                                   
                                     <asp:GridView ID="gvRole" runat="server" Width="100%" CssClass="datatable" OnRowCommand="gvRole_RowCommand"
                                        OnPageIndexChanging="gvRole_PageIndexChanging" CellPadding="5" CellSpacing="0"
                                        GridLines="None" AutoGenerateColumns="False" AllowPaging="True" 
                                        EmptyDataText="Role List is not available." PageSize="10" 
                                         onselectedindexchanged="gvRole_SelectedIndexChanged">   
                                       
                                        
                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false">
                                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Name" HeaderText="Role Name">
                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                            </asp:BoundField>
                                             <asp:BoundField DataField="RoleDescription" HeaderText="Role Description">
                                                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                            </asp:BoundField>
                                             <asp:BoundField DataField="UnderRole" HeaderText="Under Role">
                                                <HeaderStyle HorizontalAlign="left" Width="50%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="left" Width="50%"></ItemStyle>
                                            </asp:BoundField>
                                            
                                            
                                            <asp:TemplateField HeaderText="Modify">
                                                <itemstyle horizontalalign="Center"></itemstyle>
                                                <itemtemplate>
                                                    <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("Id")%>' runat="server"  ImageUrl="../resources1/images/ico_yes1.gif"
                                                        CommandName="Modify" >
                                                    </asp:ImageButton>
                                                </itemtemplate>
                                                <headerstyle horizontalalign="Center"></headerstyle>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Assign Menu">
                                                <itemstyle horizontalalign="Center"></itemstyle>
                                                <itemtemplate>
                                                    <asp:ImageButton ID="ImageButton2" CommandArgument='<%#Bind("Id")%>' runat="server"  ImageUrl="../resources1/images/ico_yes1.gif"
                                                        CommandName="Assign" >
                                                    </asp:ImageButton>
                                                </itemtemplate>
                                                <headerstyle horizontalalign="Center"></headerstyle>
                                            </asp:TemplateField>
                                        </Columns>
                                   
                                        <RowStyle CssClass="row" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <PagerStyle CssClass="pager-row" />
                                    </asp:GridView>
                                    
                                    <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="bottom-outer">
                        <div class="bottom-inner">
                            <div class="bottom">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
     </td></tr></table>
            </ContentTemplate></asp:UpdatePanel>
</asp:Content>

