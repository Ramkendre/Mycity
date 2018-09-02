<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="PWPAddData.aspx.cs" Inherits="MarketingAdmin_PWPAddData" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="outsidediv">
        <div class="headingdiv">
            <h2>
                Add Play with Passion Data</h2>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                ID :
            </div>
            <div class="subtddiv">
                <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Select Type :
            </div>
            <div class="subtddiv">
                <asp:DropDownList ID="ddltype" runat="server" CssClass="ddlcss">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">Sports News</asp:ListItem>
                    <asp:ListItem Value="2">Game Info</asp:ListItem>
                    <asp:ListItem Value="3">Events</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="save"
                    ControlToValidate="ddltype" InitialValue="0" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Enter Heading :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtHeading" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="save"
                    ControlToValidate="txtHeading" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="tdcssdiv tdcssdiv1">
            <div class="tdlbl">
                Enter IN Detail :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtDetails" runat="server" TextMode="MultiLine" Height="80px" Width="300px"></asp:TextBox>
            </div>
        </div>
        <div class="tdcssdiv">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" ValidationGroup="save"
                OnClick="btnSubmit_Click" />
        </div>
        <div>
            <asp:GridView ID="gvDisp1" runat="server" CssClass="gridview" AllowPaging="true"
                PageSize="10" AutoGenerateColumns="false" 
                onpageindexchanging="gvDisp1_PageIndexChanging" 
                onrowcommand="gvDisp1_RowCommand">
                <Columns>
                    <asp:BoundField DataField="PWP_NID" HeaderText="ID">
                        <HeaderStyle HorizontalAlign="Center" Width="3%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="PWP_NHeading" HeaderText="Sports news heading">
                        <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="PWP_NDetails" HeaderText="Sports news in detail">
                        <HeaderStyle HorizontalAlign="Center" Width="70%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="70%"></ItemStyle>
                    </asp:BoundField>                    
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnModify" runat="server" Text="Modify" CssClass="btn" CommandArgument='<%#Bind("PWP_NID")%>' CommandName="Modify" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <asp:GridView ID="gvDisp2" runat="server" CssClass="gridview" AllowPaging="true"
                PageSize="10" AutoGenerateColumns="false" 
                onpageindexchanging="gvDisp2_PageIndexChanging" 
                onrowcommand="gvDisp2_RowCommand" >
                <Columns>
                    <asp:BoundField DataField="PWP_GID" HeaderText="ID">
                        <HeaderStyle HorizontalAlign="Center" Width="3%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="PWP_GHeading" HeaderText="Game heading">
                        <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="PWP_GDetails" HeaderText="Game info in detail">
                        <HeaderStyle HorizontalAlign="Center" Width="70%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="70%"></ItemStyle>
                    </asp:BoundField>                    
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnModify" runat="server" Text="Modify" CssClass="btn" CommandArgument='<%#Bind("PWP_GID")%>' CommandName="Modify" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <asp:GridView ID="gvDisp3" runat="server" CssClass="gridview" AllowPaging="true"
                PageSize="10" AutoGenerateColumns="false" 
                onpageindexchanging="gvDisp3_PageIndexChanging" 
                onrowcommand="gvDisp3_RowCommand" >
                <Columns>
                    <asp:BoundField DataField="PWP_EID" HeaderText="ID">
                        <HeaderStyle HorizontalAlign="Center" Width="3%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="PWP_EHeading" HeaderText="Event heading">
                        <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="PWP_EDetails" HeaderText="Event details">
                        <HeaderStyle HorizontalAlign="Center" Width="70%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="70%"></ItemStyle>
                    </asp:BoundField>                    
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnModify" runat="server" Text="Modify" CssClass="btn" CommandArgument='<%#Bind("PWP_EID")%>' CommandName="Modify" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
