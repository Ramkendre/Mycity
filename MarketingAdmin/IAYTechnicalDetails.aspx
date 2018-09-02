<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="IAYTechnicalDetails.aspx.cs" Inherits="MarketingAdmin_IAYTechnicalDetails"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="outsidediv">
        <div class="headingdiv">
            <h2>IAY Technical Details</h2>
        </div>
         <div class="tdcssdiv">
            <div class="tdlbl">
                <asp:Label ID="lblResult" runat="server"></asp:Label>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Select Beneficiaries :
            </div>
            <div class="subtddiv">
                <asp:DropDownList ID="ddlBeneficiary" runat="server" CssClass="ddlcss" AutoPostBack="true">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">Santosh Gurude</asp:ListItem>
                    <asp:ListItem Value="2">Jitendra Patil</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Layout by Assistant Eng.(name) :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtlayoutbyAsstEng" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="save"
                    ControlToValidate="txtlayoutbyAsstEng" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Layout Date :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtLayoutDt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="save"
                    ControlToValidate="txtLayoutDt" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtLayoutDt">
                </asp:CalendarExtender>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Upload First Photo :
            </div>
            <div class="subtddiv">
                <asp:FileUpload ID="UploadFirstPhoto" runat="server" />
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Date of Assistant Eng. Visit :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtAsstEngVisitDt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="save"
                    ControlToValidate="txtAsstEngVisitDt" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtAsstEngVisitDt">
                </asp:CalendarExtender>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Upload Second Photo :
            </div>
            <div class="subtddiv">
                <asp:FileUpload ID="UploadSecondPhoto" runat="server" />
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Completion Certificate date :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtCompletionCertDt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="save"
                    ControlToValidate="txtCompletionCertDt" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtCompletionCertDt">
                </asp:CalendarExtender>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Upload Third Photo :
            </div>
            <div class="subtddiv">
                <asp:FileUpload ID="UploadThirdPhoto" runat="server" />
            </div>
        </div>
        <div class="tdcssdiv">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn"
                ValidationGroup="save" OnClick="btnSubmit_Click" />
        </div>
        <div>
            <asp:GridView ID="gvTechnicalDetails" runat="server" CssClass="gridview">
                
            </asp:GridView>
        </div>
    </div>
</asp:Content>
