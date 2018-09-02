<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="EmployeeStatus.aspx.cs" Inherits="MarketingAdmin_EmployeeStatus" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="outsidediv">
        <div class="headingdiv"  style="background-color: #336699;">
            <h2>
                Status Report
            </h2>
        </div>
        <div class="tdcssdiv" style="background-color: #e6e6e6;">
            <div class="tdlbl">
                Name Of Project :
            </div>
            <div class="subtddiv">
                <asp:DropDownList ID="ddlNameofProject" runat="server" CssClass="cssddlwidth" 
                    AutoPostBack="true" >
                    
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlNameofProject"
                    ErrorMessage="*" InitialValue="0" ValidationGroup="Sub"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="tdcssdiv" style="background-color: #e6e6e6;">
            <div class="tdlbl">
                Entry Type :
            </div>
            <div class="subtddiv">
                <asp:DropDownList ID="ddlEntrytype" runat="server" CssClass="cssddlwidth">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">Requirement</asp:ListItem>
                    <asp:ListItem Value="2">Work done</asp:ListItem>
                    <asp:ListItem Value="3">Feedback</asp:ListItem>
                    <asp:ListItem Value="4">Testing</asp:ListItem>
                    <asp:ListItem Value="5">Suggestion</asp:ListItem>
                    <asp:ListItem Value="6">General</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="tdcssdiv" style="background-color: #e6e6e6;">
            <div class="tdlbl">
                Subject :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtSubject" runat="server" CssClass="ccstxt"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSubject" 
                    ErrorMessage="*" ValidationGroup="Sub"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="tdcssdiv" style="background-color: #e6e6e6;">
            <div class="tdlbl">
                Contents :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" CssClass="ccsmultilinetxt"></asp:TextBox>
            </div>
        </div>
        <div class="tdcssdiv" style="background-color: #e6e6e6;">
            <div class="tdlbl">
                Time Required :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txttime" runat="server" CssClass="ccstxt"></asp:TextBox>
                <asp:MaskedEditExtender ID="MEEE" TargetControlID="txttime" Mask="99:99" runat="server"
                    MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                    MaskType="Time">
                </asp:MaskedEditExtender>
                <em style="font-style: italic; color: rgb(102, 102, 102); font-family: Tahoma, Arial, sans-serif;
                    font-size: 12px; font-variant: normal; font-weight: normal; letter-spacing: normal;
                    line-height: 18px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none;
                    white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto;
                    -webkit-text-stroke-width: 0px;"></em>
            </div>
        </div>
        <div class="tdcssdiv" style="background-color: #e6e6e6;">
            <div class="tdlbl">
                Date :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtDate" runat="server" CssClass="ccstxt"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate">
                </asp:CalendarExtender>
                <asp:DropDownList ID="ddlworkdate" runat="server" CssClass="cssddlwidth">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">of Work done</asp:ListItem>
                    <asp:ListItem Value="2">Proposed date</asp:ListItem>
                    <asp:ListItem Value="3">Proposed for Completion</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="tdcssdiv" style="background-color: #e6e6e6;">
            <div class="tdlbl">
                Attachment :
            </div>
            <div class="subtddiv">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </div>
        </div>
        <div class="tdcssdiv" style="background-color: #e6e6e6;">
            <div class="tdlbl">
                Work Status :
            </div>
            <div class="subtddiv">
                <asp:DropDownList ID="ddlworkstatus" runat="server" CssClass="cssddlwidth">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">Pending</asp:ListItem>
                    <asp:ListItem Value="2">Continued</asp:ListItem>
                    <asp:ListItem Value="3">Partial</asp:ListItem>
                    <asp:ListItem Value="4">Complete</asp:ListItem>
                    <asp:ListItem Value="5">Proposed</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlworkstatus" 
                    ErrorMessage="*" InitialValue="0" ValidationGroup="Sub"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="tdcssdiv" style="background-color: #e6e6e6;">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" ValidationGroup="Sub" OnClick="btnSubmit_Click" />
        </div>
    </div>
</asp:Content>
