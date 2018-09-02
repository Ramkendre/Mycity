<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true" CodeFile="JPostRequirment.aspx.cs" Inherits="Html_JPostRequirment" Title="Untitled Page" %>

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
                        <span class="spanTitle">Post Requirement</span>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                <td align="right">
                    Company Name
                </td>
                <td>
                    <asp:DropDownList ID="ddlCName" runat="server"></asp:DropDownList>
                </td>
                </tr>
                <tr>
                    <td align="right" style="width: 300px;">
                        Select Industry Sector
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlSISector" runat="server" AutoPostBack="true" 
                            CssClass="cssddlwidth" 
                            onselectedindexchanged="ddlSISector_SelectedIndexChanged">
                            <%--    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem>10th</asp:ListItem>
                                    <asp:ListItem>Graduate</asp:ListItem>--%>
                        </asp:DropDownList>
                        <%--<asp:TextBox ID="txtQualificationV1" runat="server" Visible="false" OnTextChanged="txtQualificationV1_OnTextChanged"></asp:TextBox>--%>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 300px;">
                        Job Role                     </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlJRole" runat="server" AutoPostBack="true" CssClass="cssddlwidth">
                            <%--    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem>10th</asp:ListItem>
                                    <asp:ListItem>Graduate</asp:ListItem>--%>
                        </asp:DropDownList>
                        <%--<asp:TextBox ID="txtQualificationV1" runat="server" Visible="false" OnTextChanged="txtQualificationV1_OnTextChanged"></asp:TextBox>--%>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 300px;">
                       Qualification
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtQuli" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right" style="width: 300px;">
                       Skill
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtSkill" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right" style="width: 300px;">
                        Requirement
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtreq" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right" style="width: 300px;">
                        Vaccancy Till                   </td>
                    <td align="left">
                        <asp:TextBox ID="txtvacancy" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right" style="width: 300px;">
                        Salary Offered
                                            </td>
                    <td align="left">
                        <asp:TextBox ID="txtSal" runat="server"></asp:TextBox>
                    <%--</td>
                    <td align="left">--%>
                       TO <asp:TextBox ID="txtSalTo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right" style="width: 300px;">
                        Fresher/Experience
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtFreshExp" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right" style="width: 300px;">
                        Training Offered
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rbtTrainO" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                
               
               
            </table>
            <div>
             <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                        onclick="btnSubmit_Click" />
            </div>
        </div>
    </div>
</asp:Content>


