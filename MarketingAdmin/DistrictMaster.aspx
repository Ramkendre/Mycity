<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="DistrictMaster.aspx.cs" Inherits="MarketingAdmin_DistrictMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table style="width: 100%" class="innerTable" cellspacing="7px">
        <tr>
            <td colspan="3" align="center">
                <h3>
                    <asp:Label ID="lblHeader" runat="server" Text="District Master"></asp:Label></h3>
            </td>
        </tr>
        
        <tr>
            <td class="tdLabel">
                <asp:Label ID="lblSelectState" runat="server" CssClass="lbl"  Text="Select State Name :"></asp:Label>
                <label class="lblStar">*</label>
            </td>
            <td class="tdText">
                <asp:DropDownList ID="ddlState"  AutoPostBack="true" runat="server" 
                    Width="140px" CssClass="ddlStyle" 
                    onselectedindexchanged="ddlState_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="lblCount" runat="server" Text="0"></asp:Label>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlState"
                    InitialValue="" ErrorMessage="* Select State" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator2">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Label ID="lblDistrictName" runat="server"  CssClass="lbl" Text="District Name :"></asp:Label>
                <label class="lblStar">*</label>
            </td>
            <td class="tdText">
                <asp:TextBox ID="txtDistrictName" runat="server" CssClass="text-medium"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="fteDistrictName" runat="server" TargetControlID="txtDistrictName" FilterType="Custom,LowercaseLetters,UppercaseLetters" ValidChars="&,()/. ">
                </asp:FilteredTextBoxExtender>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="true" runat="server"
                    ErrorMessage="District Name is Must" ControlToValidate="txtDistrictName"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator1">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button"
                    OnClick="btnSubmit_Click"   UseSubmitBehavior="false"/>
            </td>
        </tr>
    </table>
    <br />
    <hr style="color: Black; width: 1px; width: 100%" />
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
    <asp:GridView ID="gvDistrict" runat="server" GridLines="None" CssClass="GridViewStyle"
        Width="100%" AutoGenerateColumns="false" AllowPaging="True" PageSize="50" 
        OnPageIndexChanging="gvDistrict_PageIndexChanging" 
        onselectedindexchanged="gvDistrict_SelectedIndexChanged">
        <HeaderStyle CssClass="HeaderStyle" />
        <PagerStyle CssClass="PagerStyle" />
        <RowStyle CssClass="RowStyle" />
        <EditRowStyle CssClass="EditRowStyle" />
        <Columns>
            <asp:BoundField DataField="distId" HeaderText="Id">
                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
            </asp:BoundField>
           <asp:BoundField DataField ="distName" HeaderText="District Name" />
            <asp:BoundField DataField="stateName" HeaderText="State Name">
                <HeaderStyle HorizontalAlign="Left" Width="30%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="stateId" HeaderText="StateId"  />
            <asp:CommandField ShowSelectButton="true" SelectText="Modify" />
        </Columns>
    </asp:GridView>
       
        </div>
         </td>
        </tr>
 </table>
   
               
   
</asp:Content>

