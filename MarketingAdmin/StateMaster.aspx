<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="StateMaster.aspx.cs" Inherits="MarketingAdmin_StateMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table style="width: 100%" class="innerTable" cellspacing="7px">
        <tr>
            <td colspan="3" align="center">
                <h3>
                    <asp:Label ID="lblHeader" runat="server" Text="State Master"></asp:Label></h3>
            </td>
        </tr>
        <tr>
            <td class="lbl">
                <asp:Label ID="lblSelectCountry" runat="server" Text=" Select Country Name :"></asp:Label>
                <label >*</label>
            </td>
            <td >
                <asp:DropDownList ID="ddlCountry" AutoPostBack="true" runat="server" 
                    Width="140px" onselectedindexchanged="ddlCountry_SelectedIndexChanged" >
                </asp:DropDownList>
                <asp:Label ID="lblCount" runat="server" Text=""></asp:Label>
            </td>
            <td class="Error">
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  SetFocusOnError="true" Display="None" ValidationGroup="vgpStateSubmit"
                    ErrorMessage="* Select Country"  ControlToValidate="ddlCountry" InitialValue=""></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator2">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td class="lbl">
                <asp:Label ID="lblStateName" runat="server" Text="State Name :"></asp:Label>
                <label >*</label>
            </td>
            <td >
                <asp:TextBox ID="txtStateName" runat="server" CssClass="cityInfoText"></asp:TextBox>
                 <asp:FilteredTextBoxExtender ID="fteStateName" runat="server" TargetControlID="txtStateName" FilterType="Custom,LowercaseLetters,UppercaseLetters" ValidChars="&,()/.">
                </asp:FilteredTextBoxExtender>
            </td>
            <td class="Error">
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  Display="None" ValidationGroup="vgpStateSubmit"
                 SetFocusOnError="true"    ControlToValidate="txtStateName" ErrorMessage="* State Name is Must"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator1">
                </asp:ValidatorCalloutExtender>
                 
            </td>
        </tr>
        
        <tr>
            <td colspan="3" align="center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" ValidationGroup="vgpStateSubmit"
                    OnClick="btnSubmit_Click" UseSubmitBehavior="false" />
            </td>
        </tr>
    </table>
    <br />
    <hr style="width:1px; color:Black; width:100%;" />
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
    <asp:GridView ID="gvState" runat="server" GridLines="None"  Width="100%" 
        AllowPaging="true" PageSize="10"
    CssClass="GridViewStyle" AutoGenerateColumns="false" 
        onpageindexchanging="gvState_PageIndexChanging" 
        onselectedindexchanged="gvState_SelectedIndexChanged">
            <HeaderStyle CssClass="HeaderStyle" />
        <PagerStyle CssClass="PagerStyle" />
        <RowStyle CssClass="RowStyle" />
        <EditRowStyle CssClass="EditRowStyle" />
        <Columns>
            <asp:BoundField DataField="stateId" HeaderText="Id">
                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="stateName" HeaderText="State Name">
                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
            </asp:BoundField>
           
            <asp:BoundField DataField="countryName" HeaderText="Country">
                <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
            </asp:BoundField>
             <asp:BoundField DataField="countryId" HeaderText="Country Id"  />
           <asp:CommandField ShowSelectButton="true" SelectText="Modify"  HeaderText="Modify"/>
        </Columns>
    </asp:GridView>
    </div>
    </td></tr></table>
    
</asp:Content>

