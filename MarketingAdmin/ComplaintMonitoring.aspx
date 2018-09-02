<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="ComplaintMonitoring.aspx.cs" Inherits="MarketingAdmin_ComplaintMonitoring"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Assign Email Id and Complaint Monitoring Person."
                    Font-Bold="True" ForeColor="Blue"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
                <asp:Label ID="Label2" runat="server" Text="Select Main Group"></asp:Label>
            </td>
            <td style="width: 50%">
                <asp:UpdatePanel ID="upMainGroup" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlMainGroup" AutoPostBack="true" runat="server" Width="200px"
                            OnSelectedIndexChanged="ddlMainGroup_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
                <asp:Label ID="Label3" runat="server" Text="Select Sub Group"></asp:Label>
            </td>
            <td style="width: 50%">
                <asp:UpdatePanel ID="upSubGroup" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSubGroup" AutoPostBack="true" runat="server" Width="200px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
                <asp:Label ID="Label4" runat="server" Text="Select Country"></asp:Label>
            </td>
            <td style="width: 50%">
                <asp:UpdatePanel ID="ipCountry" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCountry" AutoPostBack="true" runat="server" Width="200px"
                            OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
                <asp:Label ID="Label5" runat="server" Text="Select State"></asp:Label>
            </td>
            <td style="width: 50%">
                <asp:UpdatePanel ID="upState" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlState" AutoPostBack="true" runat="server" Width="200px"
                            OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
                <asp:Label ID="Label11" runat="server" Text="Select District"></asp:Label>
            </td>
            <td style="width: 50%">
                <asp:UpdatePanel ID="upDistrict" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlDist" AutoPostBack="true" runat="server" Width="200px" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
                <asp:Label ID="Label6" runat="server" Text="Select City"></asp:Label>
            </td>
            <td style="width: 50%">
                <asp:UpdatePanel ID="upCity" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCity" AutoPostBack="true" runat="server" Width="200px" 
                            onselectedindexchanged="ddlCity_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
                <asp:Label ID="Label7" runat="server" Text="Fill Email Id"></asp:Label>
            </td>
            <td style="width: 50%">
                <asp:UpdatePanel ID="upEmailId" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEmailId" runat="server" Width="200px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
                <asp:Label ID="Label8" runat="server" Text="Country Monitoring Person"></asp:Label>
            </td>
            <td style="width: 50%">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtFirstMP" runat="server" Width="200px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
                <asp:Label ID="Label9" runat="server" Text="State Monitoring Person"></asp:Label>
            </td>
            <td style="width: 50%">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSecondMP" runat="server" Width="200px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
                <asp:Label ID="Label10" runat="server" Text="District\City Monitoring Person"></asp:Label>
            </td>
            <td style="width: 50%">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtThirdMP" runat="server" Width="200px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 50%" align="center">
                <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" Font-Bold="True" OnClick="btnSubmit_Click" />
            </td>
            <td style="width: 50%" align="center">
                <asp:Button ID="btnClear" runat="server" Text="CLEAR" Font-Bold="True" OnClick="btnClear_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
