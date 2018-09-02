<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="CheckDetailsPerson.aspx.cs" Inherits="MarketingAdmin_CheckDetailsPerson"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%" border="1" align="center">
        <tr>
            <td style="text-align: center">
                <div id="selectlevel" runat="server">
                    <table cellpadding="0" cellspacing="0" width="100%" align="center" style="height: 41px"
                        class="tables">
                        <tr>
                            <td>
                                <center>
                                    <table class='tables'>
                                        <tr>
                                            <td colspan="3">
                                                <center>
                                                    <h3>
                                                        Check Details</h3>
                                                    <br />
                                                    <asp:Label ID="lblError" runat="server" Text="" ForeColor="red"></asp:Label>
                                                </center>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            Enter Mobile No
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtMobileNo" runat="server" CssClass="txtcss"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnCheck" runat="server" Text="Check Details" CssClass="btn" OnClick="btnCheck_Click" />
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            Enter SchoolCode
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSchoolCode" runat="server" CssClass="txtcss"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnSchoolDetails" runat="server" Text="School Details" CssClass="btn"
                                                                OnClick="btnSchoolDetails_Click" />
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Panel ID="Panel2" runat="server" Visible="false">
                                        <table>
                                            <tr>
                                                <td colspan="3">
                                                    <center>
                                                        <h4>
                                                            School Details</h4>
                                                    </center>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    School Code
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSchoolCode" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    School Name
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSchoolName" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                                        <table>
                                            <tr>
                                                <td valign="top">
                                                    <table class="tables">
                                                        <tr>
                                                            <td colspan="3">
                                                                <center>
                                                                    <h4>
                                                                        Check Role Details</h4>
                                                                </center>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Full Name
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="LblFullName" runat="server" Text="Label"></asp:Label>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Role Name
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblRoleName" runat="server" Text="Label"></asp:Label>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Password
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblPassword" runat="server" Text="Label"></asp:Label>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Teachar
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblTeachMaster" runat="server" Text="Label"></asp:Label>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <table class="tables">
                                                        <tr>
                                                            <td colspan="2">
                                                                <center>
                                                                    <h4>
                                                                        Check Hirarchy</h4>
                                                                </center>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Secretary
                                                            </td>
                                                            <td>
                                                                <span style="color: Green">
                                                                    <asp:Label ID="lblSecretary" runat="server" Text=""></asp:Label></span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Depty Secretary
                                                            </td>
                                                            <td>
                                                                <span style="color: Green">
                                                                    <asp:Label ID="lblDeptySec" runat="server" Text=""></asp:Label></span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Director of Education
                                                            </td>
                                                            <td>
                                                                <span style="color: Green">
                                                                    <asp:Label ID="lblDirectorEdu" runat="server" Text=""></asp:Label></span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Deputy Director
                                                            </td>
                                                            <td>
                                                                <span style="color: Green">
                                                                    <asp:Label ID="lblDeputyDir" runat="server" Text=""></asp:Label></span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Education Officer
                                                            </td>
                                                            <td>
                                                                <span style="color: Green">
                                                                    <asp:Label ID="lblEducationOff" runat="server" Text=""></asp:Label></span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Deputy Education Officer
                                                            </td>
                                                            <td>
                                                                <span style="color: Green">
                                                                    <asp:Label ID="lblDeputyOff" runat="server" Text=""></asp:Label></span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Block Education Officer
                                                            </td>
                                                            <td>
                                                                <span style="color: Green">
                                                                    <asp:Label ID="lblBlockOff" runat="server" Text=""></asp:Label></span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Extention Officer
                                                            </td>
                                                            <td>
                                                                <span style="color: Green">
                                                                    <asp:Label ID="lblExtentionOff" runat="server" Text=""></asp:Label></span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Cluster Head
                                                            </td>
                                                            <td>
                                                                <span style="color: Green">
                                                                    <asp:Label ID="lblClusterHea" runat="server" Text=""></asp:Label></span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Head Master
                                                            </td>
                                                            <td>
                                                                <span style="color: Green">
                                                                    <asp:Label ID="lblHeadMas" runat="server" Text=""></asp:Label></span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </center>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
