<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" 
CodeFile="Item.aspx.cs" Inherits="MarketingAdmin_Item" Culture="auto" meta:resourcekey="PageResource1"
    UICulture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <br />
    <asp:Label ID="lblMessage" runat="server" meta:resourcekey="lblMessageResource1"></asp:Label>
    <table class="innerTable" cellspacing="7px">
        <tr>
            <td align="center" colspan="3">
                <h3>
                    <asp:Label ID="lblHeader" runat="server" Text="Item Master" meta:resourcekey="lblHeaderResource1"></asp:Label></h3>
                </label>
            </td>
        </tr>
        <tr>
            <td class="tdLabel" valign="top">
                <asp:Label ID="lblItem" runat="server" CssClass="lbl"  Text="Item Name:"></asp:Label>
                <label class="lblStar">
                    *</label>
            </td>
            <td class="tdText">
                <asp:TextBox ID="txtItemName" runat="server" CssClass="text-medium" ToolTip="* Specify Item Name"
                    meta:resourcekey="txtItemNameResource1"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="fteItemName" runat="server" TargetControlID="txtItemName"
                    FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers" ValidChars=".*_-,() ">
                </asp:FilteredTextBoxExtender>
                <asp:TextBoxWatermarkExtender ID="txtwater" runat="server" TargetControlID="txtItemName" WatermarkText="Item Name"></asp:TextBoxWatermarkExtender>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtItemName"
                    ValidationGroup="vgrpItemSave" SetFocusOnError="True" ErrorMessage="* Specify Item Name"
                    Display="None" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1"
                    Enabled="True">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td class="tdLabel" valign="top">
                <asp:Label ID="lblItemDescription" runat="server" CssClass="lbl"  Text="Item Description:  " meta:resourcekey="lblItemDescriptionResource1"></asp:Label>
                <label class="lblStar">
                    *</label>
            </td>
            <td class="tdText">
                <asp:TextBox ID="txtItemDescription" runat="server" CssClass="text-medium" TextMode="MultiLine"
                    Height="100px" Width="130px" ToolTip="* Specify Item Description"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="fteItemDescription" runat="server" TargetControlID="txtItemDescription"
                    FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers" ValidChars=".*_-,() ">
                </asp:FilteredTextBoxExtender>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtItemDescription"
                    ValidationGroup="vgrpItemSave" SetFocusOnError="True" ErrorMessage="* Specify Item Description"
                    Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2"
                    Enabled="True">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
      
        <tr>
            <td class="tdLabel" valign="top">
                <asp:Label ID="Label3" runat="server" CssClass="lbl"  Text="State Name:"></asp:Label>
                <label class="lblStar">
                    *</label>
            </td>
            <td class="tdText">
                <asp:DropDownList ID="cmbState" runat="server" Width="140px" AutoPostBack="true"
                    OnSelectedIndexChanged="cmbState_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select Your State"
                    Display="None" ControlToValidate="cmbState" InitialValue=""></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RequiredFieldValidator4">
                </asp:ValidatorCalloutExtender>
            </td>
            <td class="tdError">
            </td>
        </tr>
        <tr>
            <td class="tdLabel" valign="top">
                <asp:Label ID="Label4" runat="server"  CssClass="lbl" Text="District Name:"></asp:Label>
                <label class="lblStar">
                    *</label>
            </td>
            <td class="tdText">
                <asp:DropDownList ID="cmbDistrict" runat="server" Width="140px" AutoPostBack="true"
                    OnSelectedIndexChanged="cmbDistrict_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select Your District"
                    Display="None" ControlToValidate="cmbDistrict" InitialValue=""></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator5">
                </asp:ValidatorCalloutExtender>
            </td>
            <td class="tdError">
            </td>
        </tr>
        <tr>
            <td class="tdLabel" valign="top">
                <asp:Label ID="lblCityName" runat="server"  CssClass="lbl" Text="City Name:"></asp:Label>
                <label class="lblStar">
                    *</label>
            </td>
            <td class="tdText">
                <asp:DropDownList ID="cmbCity" runat="server" Width="140px" 
                    onselectedindexchanged="cmbCity_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Select your City"
                    Display="None" ControlToValidate="cmbCity" InitialValue=""></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="vceCity" runat="server" TargetControlID="RequiredFieldValidator6">
                </asp:ValidatorCalloutExtender>
            </td>
            <td class="tdError">
            </td>
        </tr>
          <tr>
            <td class="tdLabel" valign="top">
                <asp:Label ID="lblItemImage" runat="server"  CssClass="lbl" Text="Item Image:   " meta:resourcekey="lblItemImageResource1"></asp:Label>
                <label class="lblStar">
                    *</label>
            </td>
            <td class="tdText">
                <asp:FileUpload ID="uplSelectImage" runat="server" onkeypress="return false;" onkeydown="return false;" />
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="uplSelectImage"
                    ValidationGroup="vgrpItemSave" SetFocusOnError="True" ErrorMessage="* Specify Item Image"
                    Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3"
                    Enabled="True">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr valign="top">
            <td class="tdLabel" valign="top">
                <asp:Label ID="lblSelectCategory" runat="server" CssClass="lbl"  Text="Select Category"></asp:Label>
                <label class="lblStar">
                    *</label>
            </td>
            <td class="tdText">
                <asp:Panel ID="pnlLstCategory" runat="server" ScrollBars="Vertical" Height="250px"
                    Width="300px">
                    <asp:CheckBoxList ID="chkLstCategory" runat="server" Height="150px" Width="250px">
                    </asp:CheckBoxList>
                </asp:Panel>
            </td>
            <td class="tdError">
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Button ID="btnSaveItem" runat="server" Text="Submit" CssClass="button"
                    ValidationGroup="vgrpItemSave" OnClick="btnSaveItem_Click" />
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
    <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" AllowPaging="True"
        PageSize="7" Width="100%" CssClass="GridViewStyle" GridLines="None" OnPageIndexChanging="gvItem_PageIndexChanging"
        meta:resourcekey="gvItemResource1" OnSelectedIndexChanged="gvItem_SelectedIndexChanged">
        <HeaderStyle CssClass="HeaderStyle" />
        <PagerStyle CssClass="PagerStyle" />
        <RowStyle CssClass="RowStyle" />
        <EditRowStyle CssClass="EditRowStyle" />
        <Columns>
            
            <asp:BoundField DataField="itemId" />
            <asp:BoundField DataField="rowNumber" HeaderText="Item Id" />
            <asp:BoundField DataField="itemName" HeaderText="Name" />
            <asp:BoundField DataField="itemDescription" HeaderText="Item Desc" />
            <asp:TemplateField>
            <HeaderTemplate >Item Image</HeaderTemplate>
                <ItemTemplate>
                    <asp:Image ID="imgItemImage" runat="server" ImageUrl='<%# Eval("itemImage") %>' Width="70px"
                        Height="70px" meta:resourcekey="imgItemImageResource1" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="cityName" HeaderText="City" />
            <asp:CommandField ShowSelectButton="true" SelectText="Modify" HeaderText="Modify" />
        </Columns>
    </asp:GridView>
    </div>
    </td>
    </tr>
    </table>
    
</asp:Content>


