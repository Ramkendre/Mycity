<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true" CodeFile="JCompanyRegistration.aspx.cs" Inherits="Html_JCompanyRegistration" Title="Untitled Page" %>

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
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
        rel="stylesheet" type="text/css" />
    <script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
        type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=lbSector]').multiselect({
                includeSelectAllOption: true
            });
        });
    </script>

    <div class="MainDiv">
        <div class="InnerDiv">
            <table class="tblSubFull2">
                <tr style="background-color: #C3FEFE;">
                    <td colspan="2">
                        <span class="spanTitle">Company Registration</span>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 300px;">
                        Name Of Company
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 300px;">
                        Type Of Unit
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlUnit" runat="server" AutoPostBack="true"  CssClass="cssddlwidth">
                                
                        </asp:DropDownList>
                        <%--<asp:TextBox ID="txtQualificationV1" runat="server" Visible="false" OnTextChanged="txtQualificationV1_OnTextChanged"></asp:TextBox>--%>
                    </td>
                </tr>
                 <tr>
                    <td align="right" style="width: 300px;">
                        Director Name
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right" style="width: 300px;">
                        Mobile No                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtMobileNo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right" style="width: 300px;">
                        Email
                                            </td>
                    <td align="left">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right" style="width: 300px;">
                        Firm Address
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtFAdd" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right" style="width: 300px;">
                        State
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true"  CssClass="cssddlwidth">
                                
                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td align="right" style="width: 300px;">
                        District
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true"  CssClass="cssddlwidth">
                                
                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td align="right" style="width: 300px;">
                        Taluka
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtTaluka" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right" style="width: 300px;">
                        City
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 300px;">
                        Sectors
                    </td>
                    <td align="left">
                       <asp:ListBox ID="lbSector" runat="server" SelectionMode="Multiple">
                      <%-- <asp:ListItem>ss</asp:ListItem>
                       <asp:ListItem>aa</asp:ListItem>--%>
                       </asp:ListBox>
                       <asp:Button ID="btnOk" runat="server" Text="Submit" onclick="btnOk_Click" /> 
                    </td>
                </tr>
                <tr>
                <td>
                
                </td>
                <td><asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                        onclick="btnSubmit_Click" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

