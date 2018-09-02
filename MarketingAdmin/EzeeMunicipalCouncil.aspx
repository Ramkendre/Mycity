<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="EzeeMunicipalCouncil.aspx.cs" Inherits="MarketingAdmin_EzeeMunicipalCouncil"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tblSubFull2">
        <tr style="background-color: #C3FEFE;">
            <td align="center" colspan="2">
                <img src="../KResource/Images/Cake-icon.png" width="40px" height="30px" />
                <span class="spanTitle">Municipal Council</span>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                Select State
            </td>
            <td align="left">
                <asp:DropDownList ID="DDLState" runat="server" CssClass="cssddlwidth" Width="165px"
                    Height="25px">
                    <asp:ListItem>Select</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                Select District
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="cssddlwidth" Width="165px"
                    Height="25px">
                    <asp:ListItem>Select</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 40%">
                Enter Council
            </td>
            <td align="left">
                <asp:TextBox ID="txtNameOfPerson" runat="server" onkeyPress="return isCharKey(this,event)"
                    Height="20px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxtName" runat="server" ControlToValidate="txtNameOfPerson"
                    ValidationGroup="b" ErrorMessage="Please Enter Name Of Council"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="submit" OnClick="btnSubmit_Click1" />
            </td>
        </tr>
</asp:Content>
