<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="MarketingAdmin_Category" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <br />
    <table class="innerTable" cellspacing="7px">
        <tr>
            <td align="center" colspan="3">
                <h3>
                    <asp:Label ID="lblHeader" runat="server" Text="Category Master"></asp:Label></h3>
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Label ID="lblCategoryName" runat="server" CssClass="lbl" Text="Category Name:  "></asp:Label>
                <label class="lblStar">
                    *</label>
            </td>
            <td class="tdText">
                <asp:TextBox ID="txtCategoryName" runat="server" CssClass="text-medium" MaxLength="130"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="fteCategotyName" runat="server" TargetControlID="txtCategoryName"
                    FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars="&-/_,.() ">
                </asp:FilteredTextBoxExtender>
                <asp:Label ID="lblHideId" runat="server" Text="" Visible="false"></asp:Label>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Category Name is Must"
                    ValidationGroup="vgrpCategorySave" SetFocusOnError="true" ControlToValidate="txtCategoryName"
                    Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Set the Parent"></asp:Label>
                <label class="lblStar">
                    *</label>
            </td>
            <td class="tdText">
                <asp:DropDownList ID="ddlSelectParent" runat="server" Width="140px"
                    CssClass="ddlStyle"
                    OnSelectedIndexChanged="ddlSelectParent_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true"
                    Display="None" ValidationGroup="vgrpCategorySave" ControlToValidate="ddlSelectParent"
                    InitialValue="" ErrorMessage="* Select the Parent Category"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Button ID="btnSaveCategory" runat="server" Text="Submit" CssClass="button"
                    ValidationGroup="vgrpCategorySave" OnClick="btnSaveCategory_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3"></td>
        </tr>
    </table>
    <br />
    <hr style="width: 1px; color: Black; width: 100%;" />
    <br />
    <div style="margin-left: 450px">
        <asp:Label ID="lblSelectCategoryPage" runat="server" Text="Select category: "></asp:Label>
        <asp:DropDownList ID="cmbCategory" runat="server" Width="140px" 
            OnSelectedIndexChanged="cmbCategory_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
    <br />
    <div style="margin-left: 450px">
        <asp:Label ID="Label1" runat="server" Text="Enter category name: "></asp:Label>
        <asp:TextBox ID="txtSearchCategoryName" runat="server"></asp:TextBox>
    </div>
    <br />
    <div style="margin-left: 550px">
       <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" Width="97px"/>
    </div>
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


                    <asp:GridView ID="gvCategory" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                        OnPageIndexChanging="gvCategory_PageIndexChanging" GridLines="None" CssClass="GridViewStyle"
                        PageSize="15" Width="100%" OnSelectedIndexChanged="gvCategory_SelectedIndexChanged">
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <RowStyle CssClass="RowStyle" />
                        <EditRowStyle CssClass="EditRowStyle" />
                        <Columns>
                            <asp:BoundField DataField="categoryId" HeaderText="CategoryId" ControlStyle-Width="15%" />
                            <asp:BoundField DataField="categoryName" HeaderText="Category Name" ControlStyle-Width="55%" />
                            <asp:BoundField DataField="parentCategoryId" HeaderText="Parent Category Id" ControlStyle-Width="10%" />
                            <asp:CommandField ShowSelectButton="true" SelectText="Modify" ControlStyle-Width="20%" HeaderText="Modify" />
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>

</asp:Content>


