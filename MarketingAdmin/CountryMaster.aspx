<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="CountryMaster.aspx.cs" Inherits="MarketingAdmin_CountryMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table class="innerTable" cellspacing="7px">
        <tr>
            <td align="center" colspan="3">
                <h3>
                    Country Master</h3>
            </td>
        </tr>
        <tr>
            <td class="lbl" align="right">
                <asp:Label ID="Label1" runat="server"  CssClass="lbl" Text="Country Name :"></asp:Label>
                <label class="lblStar">*</label>
            </td>
            <td class="cityInfoText" >
                <asp:TextBox ID="txtCountryName" runat="server" CssClass="text-medium" ></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="fteCountryName" runat="server" TargetControlID="txtCountryName" FilterType="Custom,LowercaseLetters,UppercaseLetters" ValidChars="&,()/. ">
                </asp:FilteredTextBoxExtender>
            </td>
            <td class="Error">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCountryName"
                   SetFocusOnError="true"  ErrorMessage="* Country Name Must" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td colspan="3"  align="center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button"
                    OnClick="btnSubmit_Click"  UseSubmitBehavior="false" />
            </td>
        </tr>

    </table>
    <br />
    <hr style="width: 1px; color: Black; width: 100%;" />
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
    <asp:GridView ID="gvCountry" runat="server" GridLines="None" CssClass="GridViewStyle"
        Width="100%" AutoGenerateColumns="false" 
        onselectedindexchanged="gvCountry_SelectedIndexChanged">
        <HeaderStyle CssClass="HeaderStyle" />
        <PagerStyle CssClass="PagerStyle" />
        <RowStyle CssClass="RowStyle" />
        <EditRowStyle CssClass="EditRowStyle" />
        <Columns>
            <asp:BoundField DataField="countryId" HeaderText="Id">
                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="countryName" HeaderText="Country Name" />
            <asp:CommandField ShowSelectButton="true" SelectText="Modify" />
        </Columns>
    </asp:GridView>
   </div></td></tr></table>
   
</asp:Content>

