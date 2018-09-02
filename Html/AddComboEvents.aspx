<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="AddComboEvents.aspx.cs" Inherits="Html_AddComboEvents" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />--%>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:MultiView ID="MultiView1" runat="server">
<asp:View ID="View1" runat="server">
    <div class="MainDiv">
        <div class="InnerDiv">
            <table class="tblSubFull2">
                <tr>
                    <td>
                        <asp:Label ID="lblEvent" runat="server" Text="Select Events"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEvent" runat="server" AutoPostBack="true" 
                            onselectedindexchanged="ddlEvent_SelectedIndexChanged">
                            <asp:ListItem>select</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCombo" runat="server" Text="Add new Item"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCombo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                <td></td>
                <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" />
                </td>
                </tr>
            </table>
            <table class="tblSubFull2">
                        <tr>
                            <td>
                                <div style="overflow: scroll; height: 200px; border: 1px solid #dddddd;">
                                    <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" 
                                        DataKeyNames="ID" onrowcommand="gvItem_RowCommand" >
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:TemplateField HeaderText="Value" >
                        <ItemTemplate>
                        <asp:CheckBox ID="chk" runat="server" Text="Value" CommandName="Value" />
                        </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                                </div>
                                <asp:Label ID="lblalert" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
    </div>
          
            <%--<asp:View ID="View2" runat="server">--%>
           <%-- <table>
            
                <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:TemplateField HeaderText="value" >
                        <ItemTemplate>
                        <asp:CheckBox ID="chk" runat="server" />
                        </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Label ID="lblalert" runat="server"></asp:Label>
            </table>--%>
      </asp:View>
<%--    </asp:View>--%>
    </asp:MultiView>
</asp:Content>
