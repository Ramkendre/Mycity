<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="FriendRelativeupdate.aspx.cs" Inherits="html_FriendRelativeupdate"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="MainDiv">
                <div class="InnerDiv">
                    <center>
                        <table class="tblSubFull2">
                            <tr>
                                <td colspan="2">
                                    <center>
                                        <img src="../KResource/Images/FileImg.png" width="40px" height="20px" />
                                        <span class="spanTitle">Group Information Update</span></center>
                                        <hr />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblError" runat="server" CssClass="Error" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Friend Name :
                                </td>
                                <td align="left">
                                    <%--<asp:Label ID="lblName" runat="server" Text=""></asp:Label>--%>
                                    <asp:TextBox ID="txtName" runat="server" Text='<%#Eval("name")%>' Enabled="false"
                                        CssClass="ccstxt"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Relation :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtRelation" Text='<%#Eval("Relation")%>' runat="server" CssClass="ccstxt"></asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="ftbMobileNoExtenderN" runat="server" TargetControlID="txtRelation"
                                        FilterType="LowercaseLetters,UppercaseLetters" Enabled="True">
                                    </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Select Group:
                                </td>
                                <td align="left">
                                    <asp:CheckBoxList ID="chkGroup1" RepeatDirection="Vertical" BorderColor="Black" CssClass="cssddlwidth"
                                        runat="server">
                                        <asp:ListItem Value="1" Selected="True" Enabled="False">FR1</asp:ListItem>
                                        <asp:ListItem Value="2">FR2</asp:ListItem>
                                        <asp:ListItem Value="3">FR3</asp:ListItem>
                                        <asp:ListItem Value="4">FR4</asp:ListItem>
                                        <asp:ListItem Value="5">FR5</asp:ListItem>
                                        <asp:ListItem Value="6">FR6</asp:ListItem>
                                        <asp:ListItem Value="7">FR7</asp:ListItem>
                                        <asp:ListItem Value="8">FR8</asp:ListItem>
                                        <asp:ListItem Value="9">FR9</asp:ListItem>
                                        <asp:ListItem Value="10">FR10</asp:ListItem>
                                        <asp:ListItem Value="11">FR11</asp:ListItem>
                                        <asp:ListItem Value="12">FR12</asp:ListItem>
                                        <asp:ListItem Value="13">FR13</asp:ListItem>
                                        <asp:ListItem Value="14">FR14</asp:ListItem>
                                        <asp:ListItem Value="15">FR15</asp:ListItem>
                                        <asp:ListItem Value="16">FR16</asp:ListItem>
                                        <asp:ListItem Value="17">FR17</asp:ListItem>
                                        <asp:ListItem Value="18">FR18</asp:ListItem>
                                        <asp:ListItem Value="19">FR19</asp:ListItem>
                                        <asp:ListItem Value="20">FR20</asp:ListItem>
                                        <asp:ListItem Value="21">FR21</asp:ListItem>
                                        <asp:ListItem Value="22">FR22</asp:ListItem>
                                        <asp:ListItem Value="23">FR23</asp:ListItem>
                                        <asp:ListItem Value="24">FR24</asp:ListItem>
                                        <asp:ListItem Value="25">FR25</asp:ListItem>
                                        <asp:ListItem Value="26">FR26</asp:ListItem>
                                        <asp:ListItem Value="27">FR27</asp:ListItem>
                                        <asp:ListItem Value="28">FR28</asp:ListItem>
                                        <asp:ListItem Value="29">FR29</asp:ListItem>
                                        <asp:ListItem Value="30">FR30</asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Select Prefix while sending Msg:
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlprefix" runat="server" CssClass="cssddlwidth">
                                        <asp:ListItem>Dear</asp:ListItem>
                                        <asp:ListItem>Shri</asp:ListItem>
                                        <asp:ListItem>Smt</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Select Infix while sending Msg :
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlinfix" runat="server" CssClass="cssddlwidth">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Select Postfix while sending Msg :
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlpostfix" runat="server" CssClass="cssddlwidth">
                                        <asp:ListItem> </asp:ListItem>
                                        <asp:ListItem>Ji</asp:ListItem>
                                        <asp:ListItem>Saheb</asp:ListItem>
                                        <asp:ListItem>Sir</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                                <td align="left">
                                    <asp:Button ID="btnUpdateGroup" runat="server" CssClass="cssbtn" OnClick="btnUpdateGroup_Click"
                                        Text="Update" />
                                    &nbsp;
                                    <asp:Button ID="btnClose" runat="server" CssClass="cssbtn" PostBackUrl="~/html/Friendsetting.aspx"
                                        Text="Cancel" />
                                </td>
                            </tr>
                        </table>
                    </center>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
