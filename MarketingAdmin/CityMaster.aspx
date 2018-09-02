<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="CityMaster.aspx.cs" Inherits="MarketingAdmin_CityMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table style="width: 100%" class="innerTable" cellspacing="7px">
        <tr>
            <td colspan="3" align="center">
                <h3>
                    <asp:Label ID="lblHeader" runat="server" Text="City Master" 
                        meta:resourcekey="lblHeaderResource1"></asp:Label></h3>
            </td>
        </tr>
     
         <tr>
            <td class="tdLabel">
                <asp:Label ID="lblSelectState" runat="server"  CssClass="lbl" Text=" Select State Name: "></asp:Label>
                <label class="lblStar">*</label>
            </td>
            <td class="tdText">
                <asp:DropDownList ID="ddlState" runat="server" CssClass="ddlStyle" Width="140px"
                    OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="True" 
                    meta:resourcekey="ddlStateResource1">
                </asp:DropDownList>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlState"
                  SetFocusOnError="True" ErrorMessage="* Select State Name" Display="None" 
                    meta:resourcekey="RequiredFieldValidator3Resource1"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" 
                    TargetControlID="RequiredFieldValidator3" Enabled="True">
                </asp:ValidatorCalloutExtender>
                  
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Label ID="lblSelectDistrict" runat="server"  CssClass="lbl"   Text="Select District Name :" 
                    meta:resourcekey="lblSelectDistrictResource1"></asp:Label>
                    <label class="lblStar">*</label>
            </td>
            <td class="tdText">
                <asp:DropDownList ID="ddlDistrict" AutoPostBack="true" runat="server" Width="140px" 
                    CssClass="ddlStyle" meta:resourcekey="ddlDistrictResource1" 
                    onselectedindexchanged="ddlDistrict_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="lblCount" runat="server" Text="0"></asp:Label>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDistrict"
                  SetFocusOnError="True" ErrorMessage="* Select District Name" Display="None" 
                    meta:resourcekey="RequiredFieldValidator2Resource1"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" 
                    TargetControlID="RequiredFieldValidator2" Enabled="True" >
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        
           <tr>
            <td class="tdLabel" style="height: 31px">
                <asp:Label ID="lblCityName" runat="server" CssClass="lbl"   Text="City Name :"></asp:Label>
                <label class="lblStar">*</label>
            </td>
            <td class="tdText" style="height: 31px">
                <asp:TextBox ID="txtCityName" runat="server" CssClass="text-medium" ></asp:TextBox>
                   <asp:FilteredTextBoxExtender ID="fteCityName" runat="server" 
                   TargetControlID="txtCityName" FilterType="Custom,LowercaseLetters,UppercaseLetters" ValidChars="&,()/. ">
                </asp:FilteredTextBoxExtender>
            </td>
            <td class="tdError" style="height: 31px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="True"
                    ControlToValidate="txtCityName" ErrorMessage="* Specify City Name" 
                    Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" 
                    TargetControlID="RequiredFieldValidator1" Enabled="True">
                </asp:ValidatorCalloutExtender>
                &nbsp;
            </td>
        </tr>
       
        <tr>
            <td colspan="3" align="center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button"
                    OnClick="btnSubmit_Click" UseSubmitBehavior="False" 
                    meta:resourcekey="btnSubmitResource1"/>
            </td>
        </tr>
    </table>
    <br />
    <hr style="width: 1px; color: Black; width: 100%;" />
    <asp:Label ID="lblSearch" runat="server" Text="Search"></asp:Label> 
    <asp:TextBox ID="txtSearchCity" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearchCity" runat="server" Text="Search"  ValidationGroup="Other"
        onclick="btnSearchCity_Click" CssClass="button" />
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
    <asp:GridView ID="gvCity" runat="server" GridLines="None" 
    CssClass="GridViewStyle" AllowPaging="True" Width="100%"
        AutoGenerateColumns="False" onpageindexchanging="gvCity_PageIndexChanging" 
        onselectedindexchanged="gvCity_SelectedIndexChanged" PageSize="50"
        meta:resourcekey="gvCityResource1">
        <HeaderStyle CssClass="HeaderStyle" />
        <PagerStyle CssClass="PagerStyle" />
        <RowStyle CssClass="RowStyle" />
        <EditRowStyle CssClass="EditRowStyle" />
        <Columns>
            <asp:BoundField DataField="cityId" HeaderText="Id" 
                meta:resourcekey="BoundFieldResource1">
                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="cityName" HeaderText="City Name" 
                meta:resourcekey="BoundFieldResource2" />
            <asp:BoundField DataField="distName" HeaderText="District Name" 
                meta:resourcekey="BoundFieldResource3">
                <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="distId" 
                meta:resourcekey="BoundFieldResource4" />
            <asp:BoundField DataField="stateId" 
                meta:resourcekey="BoundFieldResource5" />
            <asp:HyperLinkField Text="View Info"
                DataNavigateUrlFields="cityId" DataNavigateUrlFormatString="CityInformationDisplay.aspx?Id={0}"
                HeaderText="City Info" meta:resourcekey="HyperLinkFieldResource1">
                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
            </asp:HyperLinkField>
          <asp:CommandField ShowSelectButton="true" SelectText="Modify" 
                meta:resourcekey="CommandFieldResource1" HeaderText="Modify" />
        </Columns>
    </asp:GridView>
   </div>
   </td>
   </tr>
   </table>
  
</asp:Content>


