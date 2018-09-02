<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="Advertise.aspx.cs" Inherits="MarketingAdmin_Advertise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="innerTable" cellspacing="7px">
        <tr>
            <td colspan="3">
                <h3>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="lbBack" runat="server" Font-Size="8pt" PostBackUrl="~/MarketingAdmin/PublishAdvertise.aspx"
                        ValidationGroup="Other">Back To Publish</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblHeader" runat="server" Text="Add Advertise"></asp:Label></h3>
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Label ID="lblAddName" runat="server" CssClass="lbl" Text="Add Name :"></asp:Label>
            </td>
            <td class="tdText">
                <asp:TextBox ID="txtAddName" runat="server"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="fteAddName" runat="server" TargetControlID="txtAddName"
                    FilterType="Custom,LowercaseLetters,UppercaseLetters" ValidChars="&,()/. ">
                </asp:FilteredTextBoxExtender>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Category Name is Must"
                    SetFocusOnError="true" ControlToValidate="txtAddName" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Label ID="lblUploadImage" runat="server" CssClass="lbl" Text="Upload Image :"></asp:Label>
            </td>
            <td class="tdText">
                <asp:FileUpload ID="FileUpload" runat="server" />
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true"
                    Display="None" ControlToValidate="FileUpload" InitialValue="" ErrorMessage="* Select the Image to Upload"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Label ID="lblValidFrom" runat="server" CssClass="lbl" Text="Valid From :"></asp:Label>
            </td>
            <td class="tdText">
                <asp:TextBox ID="txtValidFrom" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="txtValidFrom_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtValidFrom">
                </asp:CalendarExtender>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" SetFocusOnError="true"
                    ControlToValidate="txtValidFrom" ErrorMessage="* Specify City Name" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender"
                    runat="server" TargetControlID="RequiredFieldValidator7">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Label ID="lblValidTo" runat="server" CssClass="lbl"  Text="Valid Upto:"></asp:Label>
            </td>
            <td class="tdText">
                <asp:TextBox ID="txtValidTo" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="txtValidTo_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtValidTo">
                </asp:CalendarExtender>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" SetFocusOnError="true"
                    ControlToValidate="txtValidTo" ErrorMessage="* Specify City Name" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="RequiredFieldValidator8_ValidatorCalloutExtender"
                    runat="server" TargetControlID="RequiredFieldValidator8">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Label ID="lblSelectType" runat="server" CssClass="lbl" Text="Select Type :"></asp:Label>
            </td>
            <td class="tdText">
                <asp:DropDownList ID="ddlType" runat="server" CssClass="ddlStyle" Width="78px">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Active</asp:ListItem>
                    <asp:ListItem>InActive</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" SetFocusOnError="true"
                    ControlToValidate="ddlType" ErrorMessage="* Select Type" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="RequiredFieldValidator10_ValidatorCalloutExtender"
                    runat="server" TargetControlID="RequiredFieldValidator10">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Label ID="lblStatus" runat="server" CssClass="lbl" Text="Status"></asp:Label>
            </td>
            <td class="tdText">
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="ddlStyle" Width="81px">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Active</asp:ListItem>
                    <asp:ListItem>InActive</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" SetFocusOnError="true"
                    ControlToValidate="ddlStatus" ErrorMessage="* Specify City Name" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="RequiredFieldValidator9_ValidatorCalloutExtender"
                    runat="server" TargetControlID="RequiredFieldValidator9">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <br />
                <asp:Button ID="btnSaveCategory" runat="server" Text="Submit" CssClass="button"
                    OnClientClick="this.disabled = true;this.value='Saving...';__doPostBack('btnSaveCategory','')"
                    UseSubmitBehavior="false" OnClick="btnSaveCategory_Click" />
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
            <table style="width: 100%" class="innerTable" cellspacing="7px">
        <tr>
        <td class="grid" style="width: 50%">
         <div class="rounded">
                    <div class="top-outer">
                        <div class="top-inner">
                            <div class="top">
                                &nbsp;
                            </div>
                        </div>
                    </div>
                <asp:GridView ID="gvAdvertise" runat="server" GridLines="None" Width="100%" AllowPaging="true"
                    PageSize="10" CssClass="GridViewStyle" AutoGenerateColumns="false" OnPageIndexChanging="gvAdvertise_PageIndexChanging"
                    OnSelectedIndexChanged="gvAdvertise_SelectedIndexChanged">
                    <HeaderStyle CssClass="HeaderStyle" />
                    <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="RowStyle" />
                    <EditRowStyle CssClass="EditRowStyle" />
                    <Columns>
                        <asp:BoundField DataField="maxId" HeaderText="Add Id">
                            <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Name" HeaderText="Advertise Name">
                            <HeaderStyle HorizontalAlign="left" Width="10%"></HeaderStyle>
                            <ItemStyle HorizontalAlign="left" Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField ItemStyle-VerticalAlign="Top">
                            <ItemTemplate>
                                <img src='<%#Eval("ImageURL") %>' alt="Advertise  Image" width="100px" height="100px" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="20%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="ValidFrom" Visible="false" />
                        <asp:BoundField DataField="ValidTo" Visible="false" />
                        <asp:CommandField ShowSelectButton="true" SelectText="Modify" />
                    </Columns>
                </asp:GridView>
                </div></td></tr></table>
            </td>
        </tr>
        <tr>
            <td colspan="3">
            </td>
        </tr>
    </table>
</asp:Content>
