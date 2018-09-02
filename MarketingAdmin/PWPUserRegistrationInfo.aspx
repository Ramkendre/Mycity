<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="PWPUserRegistrationInfo.aspx.cs" Inherits="MarketingAdmin_PWPUserRegistrationInfo"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="outsidediv">
        <div class="headingdiv">
            <h2>
                PWP User Registration Info
            </h2>
        </div>
       
        
        <div style=" height: 350px; border: 1px solid #dddddd;">
            <asp:GridView ID="gvItem" runat="server" CssClass="gridview" AllowPaging="true" PageSize="13"
                AutoGenerateColumns="false" onpageindexchanging="gvItem_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Sr.No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="firstName" HeaderText="First Name" />
                    <asp:BoundField DataField="lastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="mobileNo" HeaderText="Mobile No." />
                    <asp:BoundField DataField="address" HeaderText="Address" />
                    <asp:BoundField DataField="eMailId" HeaderText="eMailId" />
                    <%--<asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnModify" runat="server" Text="Modify" CssClass="btn" CommandArgument='<%#Bind("PWP_NID")%>' CommandName="Modify" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
