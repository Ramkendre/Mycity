<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IAYExcelUpload.aspx.cs" MasterPageFile="~/Master/MarketingMaster.master" Inherits="MarketingAdmin_IAYExcelUpload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="outsidediv">
        <div class="headingdiv">
            <h2>IAY Beneficiaries Data Upload</h2>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                <asp:Label ID="lblResult" runat="server"></asp:Label>
            </div>
        </div>
       
        <div class="tdcssdiv">
            <div class="tdlbl">
                Select State :
            </div>
            <div class="subtddiv">
                <asp:DropDownList ID="ddlState" runat="server" CssClass="ddlcss" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Select District :
            </div>
            <div class="subtddiv">
                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="ddlcss" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Select Block :
            </div>
            <div class="subtddiv">
                <asp:DropDownList ID="ddlBlock" runat="server" CssClass="ddlcss" AutoPostBack="true" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Select Circle :
            </div>
            <div class="subtddiv">
                <asp:DropDownList ID="ddlGramPanchayat" runat="server" CssClass="ddlcss">
            
                </asp:DropDownList>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Select Village :
            </div>
            <div class="subtddiv">
                <asp:DropDownList ID="ddlVillage" runat="server" CssClass="ddlcss" AutoPostBack="true">
     
                </asp:DropDownList>
            </div>
        </div>

        <div class="tdcssdiv">
            <div class="tdlbl">
                Select Excel File :
            </div>
            <div class="subtddiv">
                <asp:FileUpload ID="excelFileUpload" runat="server" />
            </div>
        </div>


      <%--  <div class="tdcssdiv">
            <div class="tdlbl">
                Enter Approval Date Of IAY :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtApprovalDate" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="save"
                    ControlToValidate="txtApprovalDate" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtApprovalDate">
                </asp:CalendarExtender>
            </div>
        </div>--%>
        <div class="tdcssdiv">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn"
                ValidationGroup="save" OnClick="btnSubmit_Click" />
            <div class="tdcssdiv">
                <asp:Button ID="btnDownloadExcelSheet" runat="server" Text="DownloadExcelSheetFormat"  CssClass="btn" OnClick="btnDownloadExcelSheet_Click" />
            </div>
        </div>
        
        <div>
            <asp:GridView ID="gvPersonalDetails" runat="server" CssClass="gridview" AllowPaging="true" OnPageIndexChanging="gvPersonalDetails_PageIndexChanging">
                <Columns>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
