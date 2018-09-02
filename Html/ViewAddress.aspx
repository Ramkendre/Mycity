<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="ViewAddress.aspx.cs" Inherits="UI_ViewAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="MainDiv">
        <div class="InnerDiv">
            <table class="tblSubFull2">
                <tr>
                    <td align="center">
                        <center>
                            <br />
                            <span class="spanTitle">Contact Address</span>
                            <br />
                            <hr />
                        </center>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="tblSubFull2">
                            <tr>
                                <td>
                                    <asp:GridView ID="gvContactDisplay" AutoGenerateColumns="False" runat="server" Width="100%">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <br />
                                                    <table class="tblSubFull2">
                                                        <tr>
                                                            <td align="right">
                                                            </td>
                                                            <td align="left">
                                                                <asp:Image ID="myIniProfileImage" runat="server" AlternateText="ProImage" ImageUrl='<%# "~/ImageHandler.ashx?userId="+ Eval("usrUserId") %>'
                                                                    Height="130px" Width="130px" BorderColor="#164854" BorderWidth="1px" />
                                                                <br />
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                Name :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label18" runat="server" Text='<%#Eval("usrFullName") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                Address :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="myAddress" runat="server" Text='<%#Eval("usrAddress") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                Area/Village :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label14" runat="server" Text='<%#Eval("usrArea") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                City :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("usrCity") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                District :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("usrDistrict") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                State :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("usrState") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                PIN :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("usrPIN") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                Phone Number :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("usrPhoneNo") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <%
                                                            if (showMobile != "0")
                                                            { }
                                                        %>
                                                        <tr>
                                                            <td align="right">
                                                                Mobile No :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label12" runat="server" Text='<%#Eval("usrMobileNo") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lnbViewProfile" runat="server" Visible="false" OnClick="lnbViewProfile_Click">View Profile</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="cssbtn" OnClick="btnBack_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
