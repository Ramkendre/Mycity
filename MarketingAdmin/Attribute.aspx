<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="Attribute.aspx.cs" Inherits="MarketingAdmin_Attribute" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
            <table class="innerTable" cellspacing="7px">
                <tr>
                    <td align="center" colspan="3">
                        <h3>
                            <asp:Label ID="lblHeader" runat="server" Text="Attribute Master"></asp:Label></h3>
                    </td>
                </tr>
                <tr>
                    <td class="tdLabel">
                        <asp:Label ID="lblAttribute" runat="server" CssClass="lbl" Text="Attribute Name:  "></asp:Label>
                        <label class="lblStar">
                            *</label>
                    </td>
                    <td class="tdText">
                        <asp:TextBox ID="txtAttributeName" runat="server" CssClass="text-medium" MaxLength="50"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="fteAttributeName" runat="server" TargetControlID="txtAttributeName"
                            FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers" ValidChars="&,'-()/. ">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td class="tdError">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Specify Attribute Name"
                            ValidationGroup="vgrpAttributeSave" SetFocusOnError="true" ControlToValidate="txtAttributeName"
                            Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                        </asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td class="tdLabel">
                        <asp:Label ID="lblAttributeValue" runat="server" CssClass="lbl" Text="Attribute Value:  "></asp:Label>
                    </td>
                    <td class="tdText">
                        <asp:TextBox ID="txtAttributeValue" runat="server" CssClass="text-medium" Text=""></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="fteAttributeValue" runat="server" TargetControlID="txtAttributeValue"
                            FilterType="Custom,LowercaseLetters,UppercaseLetters" ValidChars="&,()/. ">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td class="tdError">
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true" ValidationGroup="vgrpAttributeSave"
                    ControlToValidate="txtAttributeValue" ErrorMessage="* Specify Attribute Value" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2" >
                </asp:ValidatorCalloutExtender>--%>
                    </td>
                </tr>
                <tr>
                    <td class="tdLabel" style="height: 31px">
                        <asp:Label ID="lblAttributeType" runat="server" CssClass="lbl" Text="Attribute Type:  "></asp:Label>
                        <label class="lblStar">
                            *</label>
                    </td>
                    <td class="tdText" style="height: 31px">
                        <asp:DropDownList ID="ddlAttributeType" runat="server" Width="140px" CssClass="ddlStyle">
                            <asp:ListItem Value="">Select Type</asp:ListItem>
                            <asp:ListItem Value="S">Single</asp:ListItem>
                            <asp:ListItem Value="M">Multiple</asp:ListItem>
                            <asp:ListItem Value="MS">MultiSelect</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="tdError" style="height: 31px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" SetFocusOnError="true"
                            ValidationGroup="vgrpAttributeSave" ControlToValidate="ddlAttributeType" InitialValue=""
                            ErrorMessage="* Select Attribute Type" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3">
                        </asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td class="tdLabel">
                        <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Select Category:"></asp:Label>
                        <label class="lblStar">
                            *</label>
                    </td>
                    <td class="tdText">
                        <asp:DropDownList ID="ddlSelectCategory" runat="server" Width="140px" CssClass="ddlStyle">
                        </asp:DropDownList>
                    </td>
                    <td class="tdError">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="true"
                            ValidationGroup="vgrpAttributeSave" ControlToValidate="ddlSelectCategory" InitialValue=""
                            ErrorMessage="* Select Category" Display="None"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RequiredFieldValidator4">
                        </asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="btnSaveAttribute" runat="server" Text="Submit" CssClass="button"
                            ValidationGroup="vgrpAttributeSave" OnClick="btnSaveAttribute_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                    </td>
                </tr>
            </table>
            <br />
            <hr style="width: 1px; color: Black; width: 100%;" />
            <br />
            <div>
               <asp:Label ID="lblSelectCategory" runat="server" Text="Select category: "></asp:Label>
                <asp:DropDownList ID="cmbCategory" runat="server" Width="140px"  AutoPostBack="true"
                    onselectedindexchanged="cmbCategory_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <br /><table style="width: 100%" class="innerTable" cellspacing="7px">
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
            <asp:GridView ID="gvAttribute" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                Width="100%" PageSize="20" GridLines="None" CssClass="GridViewStyle" OnPageIndexChanging="gvAttribute_PageIndexChanging"
                OnSelectedIndexChanged="gvAttribute_SelectedIndexChanged">
                <HeaderStyle CssClass="HeaderStyle" />
                <PagerStyle CssClass="PagerStyle" />
                <RowStyle CssClass="RowStyle" />
                <EditRowStyle CssClass="EditRowStyle" />
                <Columns>
                    <asp:BoundField DataField="attributeId" HeaderText="ID" />
                    <asp:BoundField DataField="attributeName" HeaderText="Attribute Name" />
                    <asp:BoundField DataField="attributeValue" HeaderText="Default Value" />
                    <asp:BoundField DataField="attributeType" HeaderText="Attribute Type" />
                    
                    <asp:BoundField DataField="categoryId" HeaderText="CategoryId" />
                    <asp:CommandField ShowSelectButton="true" SelectImageUrl="~/Resources/AdminImage/Modify.png"
                        HeaderText="Modify" SelectText="Modify"  />
                </Columns>
            </asp:GridView>
            </div></td></tr></table>
        
</asp:Content>
