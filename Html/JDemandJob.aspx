<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="JDemandJob.aspx.cs" Inherits="Html_JDemandJob" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
        function isCharKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if ((charCode < 64 && charCode > 0) || (charCode < 96 && charCode > 91) || (charCode < 127 && charCode > 123))
                return false;

            return true;
        }
    </script>

    <div class="MainDiv">
        <div class="InnerDiv">
            <table class="tblSubFull2">
            <tr style="background-color: #C3FEFE;">
                    <td colspan="2">
                        <span class="spanTitle">Demand Job</span>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Sector
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlSector" runat="server" AutoPostBack="true" 
                            onselectedindexchanged="ddlSector_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Job Role
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlJRole" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Experience
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rbtnExp" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Fresher</asp:ListItem>
                            <asp:ListItem>Experience</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                 <tr>
                <td align="right">
                    Salary
                </td>
                <td align="left">
                <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
                </td>
                </tr>
                 <tr>
                <td align="right">
                    State
                </td>
                <td align="left">
                <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td align="right">
                    District
                </td>
                <td align="left">
                <asp:TextBox ID="txtDistrict" runat="server"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td align="right">
                    Taluka
                </td>
                <td align="left">
                <asp:TextBox ID="txtTaluka" runat="server"></asp:TextBox>
                </td>
                </tr>
                <tr>
                    <td align="right">
                        Expected Upto
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtdate" runat="server" Height="20px"></asp:TextBox>
                        <asp:Image ID="Image2" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                            runat="server" />
                        <asp:CalendarExtender ID="CEBD" PopupButtonID="Image2" runat="server" Format="yyyy-MM-dd"
                            TargetControlID="txtdate">
                        </asp:CalendarExtender>
                        <asp:RequiredFieldValidator ID="rfvBirthDate" runat="server" ControlToValidate="txtdate"
                            ValidationGroup="b" ErrorMessage="Please Enter Date"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    Intrested For
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtIntrest" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                <td align="right">
                </td>
                <td align="left">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                        onclick="btnSubmit_Click" />
                </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
