<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="ItemCategory.aspx.cs" Inherits="MarketingAdmin_ItemCategory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:UpdatePanel ID="updatepanel1" runat="server"><ContentTemplate>

    <table class="innerTable" cellspacing="10px">
        <tr>
            <td colspan="3" align="center">
                <h3>
                    <asp:Label ID="lblheader" runat="server" Text="Item Category Master"></asp:Label></h3>
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Label ID="lblSelectItem" runat="server" CssClass="lbl" Text=" Select Item"></asp:Label>
                <label class="lblStar">
                    *</label>
            </td>
            <td class="tdText">
                <asp:DropDownList ID="ddlSelectItem" runat="server" Width="160px" OnSelectedIndexChanged="ddlSelectItem_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true"
                    ControlToValidate="ddlSelectItem" InitialValue="" ErrorMessage="* Select  Item"
                    Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Label ID="lblSelectCategory" runat="server" CssClass="lbl" Text="Select Category:"></asp:Label>
                <label class="lblStar">
                    *</label>
            </td>
            <td class="tdText">
                <asp:DropDownList ID="ddlSelectCategory" runat="server" Width="160px" OnSelectedIndexChanged="ddlSelectCategory_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSelectCategory"
                    InitialValue="" SetFocusOnError="true" ErrorMessage="* Select catgory" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td colspan="3">
            </td>
        </tr>
    </table>
    <br />
    <asp:Panel ID="updateItemCategoryAttribute" runat="server" BorderColor="Black" BorderWidth="1px"
        BorderStyle="Groove">
        <%--    <asp:Label ID="lblUpdateHeader" runat="server" Text="Update the Data" CssClass="lblHeader"></asp:Label>--%>
        <br />
        <br />
        <table style="width: 100%" class="innerTable" cellspacing="7px">
        <tr>
        <td class="grid" style="width: 50%">
         <div class="rounded">
                    <div class="top-outer">
                        <div class="top-inner">
                            <div class="top">
                                &nbsp;
                            </div>
                        </div>
                    </div>
      <asp:DataList ID="dtlUpdateData" runat="server" Width="100%" 
            onselectedindexchanged="dtlUpdateData_SelectedIndexChanged"  >
            <ItemTemplate>
                
                    <table width="100%">
                        <tr style="width: 100%;">
                            <td style="width: 10%;line-height:350px;">
                                <asp:Label ID="lblattributeId" runat="server" CssClass="lbl"  Text='<%#Eval("attributeId")%>' Visible="false"></asp:Label>
                                <asp:Label ID="lblIcaId" runat="server" Text='<%#Eval("icaId")%>' Visible="false"></asp:Label>
                            </td>
                            <td style="width: 30%;line-height:35px;" align="left">
                                <asp:Label ID="lblFieldName" runat="server" CssClass="lbl"  Text='<%#Eval("attributeName")%>'></asp:Label>
                                <label>
                                    :</label>
                            </td>
                            <td style="width: 60%; line-height:35px;" align="left">
                                <asp:TextBox ID="txtFieldValue" runat="server" Width="140px" Text='<%#Eval("attributeValue") %>'></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                
            </ItemTemplate>
            <FooterTemplate>
              <br />
                <asp:Button ID="btnApply" runat="server" OnClick="btnApply_Click" Text="Update" CssClass="button" />
            </FooterTemplate>
            <ItemStyle HorizontalAlign="Center" />
            <FooterStyle HorizontalAlign="Center" />
        </asp:DataList>
 </div>
 </td>
 </tr>
 </table>
    </asp:Panel>
    </ContentTemplate></asp:UpdatePanel>
</asp:Content>
