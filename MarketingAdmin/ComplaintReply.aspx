<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="ComplaintReply.aspx.cs" Inherits="MarketingAdmin_ComplaintReply" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="Label1" runat="server" Text="Complaint Monitoring." Font-Bold="True"
                    ForeColor="Blue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnComplaintAssignEmailPerson" runat="server" 
                    Text="Assign Email & Person" Font-Bold="True" ForeColor="#FF0066" 
                    onclick="btnComplaintAssignEmailPerson_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSelectGroup" runat="server" Font-Bold="true" Font-Size="Large"
                    Text="Select Group"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="mainGroup" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlGroupName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGroupName_SelectedIndexChanged"
                            Width="250px">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlGroupName" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSubGroupName" />
                        <asp:AsyncPostBackTrigger ControlID="ddlGroupName" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblSelectSubGruop" runat="server" Font-Bold="true" Font-Size="Large"
                    Text="Select SubGroup"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="subGroup" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSubGroupName" runat="server" AutoPostBack="true" Width="250px"
                            OnSelectedIndexChanged="ddlSubGroupName_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSubGroupName" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSubGroupName" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:UpdatePanel ID="grid" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="true"
                            PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                            OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                            <Columns>
                                <asp:TemplateField HeaderText="Mobile No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMobileNo" runat="server" Text='<%# Eval("mobile") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Complaint/Reply">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMsg" runat="server" Text='<%# Eval("Message") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtReply" Height="30px" Width="200px" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Reply">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lbkUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                            Text="REPLY"></asp:LinkButton>
                                        <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                            Text="CANCEL"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                            Text="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSubGroupName" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowUpdating" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowEditing" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="PageIndexChanging" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCancelingEdit" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
