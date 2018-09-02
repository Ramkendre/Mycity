<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MainMaster.master"
    CodeFile="SearchByCity.aspx.cs" Inherits="UI_SearchByCity" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--    <script type="text/javascript" src="../Resources/JScript/DipakUpdateProgress.js"></script>

    <script type="text/javascript" language="javascript">
        var ModalProgress = '<%= ModalProgress.ClientID %>';         
    </script>--%>
    <div>
        <table width="100%">
            <tr class="searchResultHeader" style="width: 100%;">
                <td colspan="3" class="searchResultHeader" style="width: 100%;">
                    <asp:Panel ID="pnlSearchHeader" runat="server" class="searchResultHeader">
                        <asp:Label ID="Label2" runat="server" Text="Search Result"></asp:Label>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <asp:UpdatePanel ID="panelUpdateProgress3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="pnlResultSet" runat="server" BackColor="#E7E7E7">
                <asp:Panel ID="pnlCityShow" runat="server">
                    <asp:Label ID="lblCityText" Text="Location :" runat="server" CssClass="NoOfRecord"></asp:Label>
                    <asp:Label ID="lblCurrLocation" runat="server" Text="" CssClass="NoOfRecord"></asp:Label>
                </asp:Panel>
                <br />
                <asp:Panel ID="pnlResultNo" runat="server">
                    <asp:Label ID="lblNoOfRecord" runat="server" Text="" CssClass="NoOfRecord"></asp:Label>
                    <asp:Label ID="lblRecordFound" runat="server" Text=" results found for " CssClass="lblRecordFound"></asp:Label>
                    <asp:Label ID="lblMatchCategory" runat="server" Text="" CssClass="NoOfRecord"></asp:Label>
                </asp:Panel>
            </asp:Panel>
            <br />
        </ContentTemplate>
        <%--  <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
        </Triggers>--%>
    </asp:UpdatePanel>
    <br />
    <asp:GridView ID="gvDisplayItem" runat="server" AutoGenerateColumns="False" ShowHeader="false"
        Width="100%" OnItemCommand="gvDisplayItem_ItemCommand" 
        OnRowCommand="gvDisplayItem_RowCommand" 
        onselectedindexchanged="gvDisplayItem_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table width="590px">
                        <tr>
                            <td style="width: 75px; border-right: groove 0px black;">
                                <asp:ImageButton ID="categoryImage" ImageUrl='<%#Eval("itemImage")%>' runat="server"
                                    alt="Image" Height="70px" Width="70px" CommandArgument='<%#Eval("itemId")%>'
                                    CommandName="DisplayDetails" />
                            </td>
                            <td class="borderstyle">
                                <asp:LinkButton ID="itemName" runat="server" Text='<%#Eval("itemName") %>' 
                                                        CommandArgument='<%#Eval("itemId")%>'
                                    CommandName="DisplayDetails" CssClass="text1"></asp:LinkButton>
                                <br />
                                <asp:Label ID="myDes" runat="server" Text='<%#Eval("itemDescription") %>' 
                                    style="background-color: Transparent; font-size: 12px; font-weight: bold; color: #c1c1c1"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
