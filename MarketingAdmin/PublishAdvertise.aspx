<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="PublishAdvertise.aspx.cs" Inherits="MarketingAdmin_PublishAdvertise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%" class="innerTable" cellspacing="7px">
        <tr>
            <td colspan="3" align="center">
                <h3>
                    <asp:Label ID="lblHeader" runat="server" Text="Publish Advertise"></asp:Label></h3>
            </td>
        </tr>
     
         <tr>
            <td class="tdLabel">
                <asp:Label ID="lblSelectAdvId" runat="server" Text="Select advertise Id :"></asp:Label>
            </td>
            <td class="tdText">
                <asp:DropDownList ID="ddlAdvId" runat="server" CssClass="ddlStyle" Width="90px">
                </asp:DropDownList>
                <asp:LinkButton ID="lbAddAdvertise" runat="server" BorderStyle="Groove" 
                    Font-Bold="False" Font-Size="Small" Font-Underline="False" 
                    PostBackUrl="~/MarketingAdmin/Advertise.aspx" ValidationGroup="other" Width="88px">Add Advertise</asp:LinkButton>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlState"
                  SetFocusOnError="true"   InitialValue="" ErrorMessage="* Select Advertise Id" 
                    Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="RequiredFieldValidator5_ValidatorCalloutExtender" 
                    runat="server" TargetControlID="RequiredFieldValidator5">
                </asp:ValidatorCalloutExtender>
                  
            </td>
        </tr>
        
         <tr>
            <td class="tdLabel">
                <asp:Label ID="lblSelectState" runat="server" Text=" Select State : "></asp:Label>
            </td>
            <td class="tdText">
                <asp:DropDownList ID="ddlState" runat="server" CssClass="ddlStyle" Width="140px"
                     >
                </asp:DropDownList>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlState"
                  SetFocusOnError="true"   InitialValue="" ErrorMessage="* Select State Name" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator3">
                </asp:ValidatorCalloutExtender>
                  
            </td>
        </tr>
        
           <tr>
            <td class="tdLabel">
                <asp:Label ID="lblCityName" runat="server" Text="Select City  :"></asp:Label>
            </td>
            <td class="tdText">
                <asp:DropDownList ID="ddlCity" runat="server" Width="140px" CssClass="ddlStyle">
                </asp:DropDownList>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true"
                    ControlToValidate="ddlCity" ErrorMessage="*Select City Name" 
                    Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator1">
                </asp:ValidatorCalloutExtender>
                &nbsp;
            </td>
        </tr>
       
           <tr>
            <td class="tdLabel">
                <asp:Label ID="lblCategory" runat="server" Text="Select Category"></asp:Label>
            </td>
            <td class="tdText">
                <asp:DropDownList ID="ddlSelectCategory" runat="server" Width="140px" 
                    CssClass="ddlStyle">
                </asp:DropDownList>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="true"
                    ControlToValidate="ddlSelectCategory" ErrorMessage="* Select Category" 
                    Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="RequiredFieldValidator4_ValidatorCalloutExtender" 
                    runat="server" TargetControlID="RequiredFieldValidator4">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
       
           <tr>
            <td class="tdLabel">
                <asp:Label ID="lblType" runat="server" Text="Select Location :"></asp:Label>
            </td>
            <td class="tdText">
                <asp:DropDownList ID="ddlLocation" runat="server" Width="140px" 
                    CssClass="ddlStyle">
                </asp:DropDownList>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" SetFocusOnError="true"
                    ControlToValidate="ddlLocation" ErrorMessage="* Select Type" 
                    Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="RequiredFieldValidator6_ValidatorCalloutExtender" 
                    runat="server" TargetControlID="RequiredFieldValidator6">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
       
           <tr>
            <td class="tdLabel">
                <asp:Label ID="lblValidFrom" runat="server" Text="Valid From :"></asp:Label>
            </td>
            <td class="tdText">
                <asp:TextBox ID="txtValidFrom" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="txtValidFrom_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtValidFrom">
                </asp:CalendarExtender>
                <br />
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" SetFocusOnError="true"
                    ControlToValidate="txtValidFrom" ErrorMessage="* Specify Valid From Date" 
                    Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender" 
                    runat="server" TargetControlID="RequiredFieldValidator7">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
       
           <tr>
            <td class="tdLabel">
                <asp:Label ID="lblValidTo" runat="server" Text="Valid Upto:"></asp:Label>
            </td>
            <td class="tdText">
                <asp:TextBox ID="txtValidTo" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="txtValidTo_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtValidTo">
                </asp:CalendarExtender>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" SetFocusOnError="true"
                    ControlToValidate="txtValidTo" ErrorMessage="* Specify Valid Upto Date" 
                    Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="RequiredFieldValidator8_ValidatorCalloutExtender" 
                    runat="server" TargetControlID="RequiredFieldValidator8">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
       
           <tr>
            <td class="tdLabel">
                <asp:Label ID="lblStatus" runat="server" Text="Status :"></asp:Label>
            </td>
            <td class="tdText">
                <asp:DropDownList ID="ddlIsActive" runat="server" 
                    CssClass="ddlStyle" Width="58px">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Active</asp:ListItem>
                    <asp:ListItem>InActive</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="Error">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" SetFocusOnError="true"
                    ControlToValidate="ddlIsActive" ErrorMessage="* Not Selected" 
                    Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="RequiredFieldValidator9_ValidatorCalloutExtender" 
                    runat="server" TargetControlID="RequiredFieldValidator9">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
       
        <tr>
            <td colspan="3" align="center">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button-submit"
                    OnClientClick="this.disabled = true;this.value='Saving...';__doPostBack('btnSubmit','')" 
                    UseSubmitBehavior="false" onclick="btnSubmit_Click"/>
            </td>
        </tr>
       
        <tr>
            <td colspan="3" align="center">
                
            </td>
        </tr>
    </table>
</asp:Content>

