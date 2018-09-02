<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="VidhanMandalDetails.aspx.cs" Inherits="MarketingAdmin_VidhanMandalDetails"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>

    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>

    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        $("[id*=hlCount]").live("click", function() {


            $("#dialog").dialog({
                title: "Vidhan Mandal Application registation",
                //        maxWidth: 600,
                //        maxHeight: 500,
                width: 1000,
                height: 500,
                modal: true,
                buttons: {
                    Close: function() {
                        $(this).dialog('close');
                    }
                }
            });
            return false;
        });
    </script>

    <div id="dialog" style="display: none;">
        <asp:Panel ID="Panel1" runat="server" Style="height: 100%; width: 100%">
            <asp:GridView ID="gridview1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="EzeeDrugAppId">
                        <ItemTemplate>
                            <asp:Label ID="lblid1" runat="server" Font-Size="Small" Text='<%# Bind("EzeeDrugAppId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="keyword">
                        <ItemTemplate>
                            <asp:Label ID="lblid5" runat="server" Font-Size="Small" Text='<%# Bind("keyword") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="strSimSerialNo">
                        <ItemTemplate>
                            <asp:Label ID="lblid2" runat="server" Font-Size="Small" Text='<%# Bind("strSimSerialNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="firstName">
                        <ItemTemplate>
                            <asp:Label ID="lblid3" runat="server" Font-Size="Small" Text='<%# Bind("firstName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="lastName">
                        <ItemTemplate>
                            <asp:Label ID="lblid3" runat="server" Font-Size="Small" Text='<%# Bind("lastName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="firmName">
                        <ItemTemplate>
                            <asp:Label ID="lblid3" runat="server" Font-Size="Small" Text='<%# Bind("firmName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="mobileNo">
                        <ItemTemplate>
                            <asp:Label ID="lblid3" runat="server" Font-Size="Small" Text='<%# Bind("mobileNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="address">
                        <ItemTemplate>
                            <asp:Label ID="lblid3" runat="server" Font-Size="Small" Text='<%# Bind("address") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>
    <table style="width: 100%; height: 20px; margin-right: 642px;">
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="width: 208px">
                &nbsp;
            </td>
            <td align="right">
                Total Download App :
                <asp:HyperLink ID="hlCount" runat="server" NavigateUrl="Home.aspx"></asp:HyperLink>
            </td>
        </tr>
        <asp:Panel ID="pnlId" runat="server" Visible="false">
            <tr>
                <td>
                </td>
                <td style="width: 208px" align="right">
                    ID :
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </asp:Panel>
        <tr>
            <td>
            </td>
            <td style="width: 208px" align="right">
                Select Date
            </td>
            <td>
                <asp:DropDownList ID="ddldd" runat="server">
                    <asp:ListItem Value="1">०१</asp:ListItem>
                    <asp:ListItem Value="2">०२</asp:ListItem>
                    <asp:ListItem Value="3">०३</asp:ListItem>
                    <asp:ListItem Value="4">०४</asp:ListItem>
                    <asp:ListItem Value="5">०५ </asp:ListItem>
                    <asp:ListItem Value="6">०६</asp:ListItem>
                    <asp:ListItem Value="7">०७</asp:ListItem>
                    <asp:ListItem Value="8">०८</asp:ListItem>
                    <asp:ListItem Value="9">०९</asp:ListItem>
                    <asp:ListItem Value="10">१०</asp:ListItem>
                    <asp:ListItem Value="11">११</asp:ListItem>
                    <asp:ListItem Value="12">१२</asp:ListItem>
                    <asp:ListItem Value="13">१३</asp:ListItem>
                    <asp:ListItem Value="14">१४</asp:ListItem>
                    <asp:ListItem Value="15">१५</asp:ListItem>
                    <asp:ListItem Value="16">१६</asp:ListItem>
                    <asp:ListItem Value="17">१७</asp:ListItem>
                    <asp:ListItem Value="18">१८</asp:ListItem>
                    <asp:ListItem Value="19">१९</asp:ListItem>
                    <asp:ListItem Value="20">२०</asp:ListItem>
                    <asp:ListItem Value="21">२१</asp:ListItem>
                    <asp:ListItem Value="22">२२</asp:ListItem>
                    <asp:ListItem Value="23">२३</asp:ListItem>
                    <asp:ListItem Value="24">२४</asp:ListItem>
                    <asp:ListItem Value="25">२५</asp:ListItem>
                    <asp:ListItem Value="26">२६</asp:ListItem>
                    <asp:ListItem Value="27">२७</asp:ListItem>
                    <asp:ListItem Value="28">२८</asp:ListItem>
                    <asp:ListItem Value="29">२९ </asp:ListItem>
                    <asp:ListItem Value="30">३०</asp:ListItem>
                    <asp:ListItem Value="31">३१</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlmm" runat="server">
                    <asp:ListItem Value="1">०१</asp:ListItem>
                    <asp:ListItem Value="2">०२</asp:ListItem>
                    <asp:ListItem Value="3">०३</asp:ListItem>
                    <asp:ListItem Value="4">०४</asp:ListItem>
                    <asp:ListItem Value="5">०५</asp:ListItem>
                    <asp:ListItem Value="6">०६</asp:ListItem>
                    <asp:ListItem Value="7">०७</asp:ListItem>
                    <asp:ListItem Value="8">०८</asp:ListItem>
                    <asp:ListItem Value="9">०९</asp:ListItem>
                    <asp:ListItem Value="10">१०</asp:ListItem>
                    <asp:ListItem Value="11">११</asp:ListItem>
                    <asp:ListItem Value="12">१२</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlyyyy" runat="server">
                    <asp:ListItem Value="1">२०१४</asp:ListItem>
                    <asp:ListItem Value="2">२०१५</asp:ListItem>
                    <asp:ListItem Value="3">२०१६</asp:ListItem>
                </asp:DropDownList>
                <%--<asp:TextBox ID="txtDate" runat="server" Height="22px" Width="145px"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate">
                </asp:CalendarExtender>--%>
            </td>
        </tr>
        <tr>
            <td style="height: 34px">
            </td>
            <td style="width: 208px; height: 34px;" align="right">
                Type
            </td>
            <td style="height: 34px">
                <asp:DropDownList ID="ddlMandal" runat="server" Height="21px" Width="149px">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">Vidhan Parishad </asp:ListItem>
                    <asp:ListItem Value="2">Vidhan Sabha</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlMandal"
                    ValidationGroup="save" ErrorMessage="*" Font-Size="Small"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="width: 208px" align="right">
            </td>
            <td>
                <asp:Label ID="lblText" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="width: 208px" align="right">
                &nbsp;Description
            </td>
            <td>
                <asp:TextBox ID="txtDesc" runat="server" Height="80px" TextMode="MultiLine" Width="194px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td style="width: 208px" align="right">
                <asp:Button ID="btnSub" runat="server" OnClick="btnSub_Click" Text="Submit" Width="99px"
                    ValidationGroup="save" BackColor="" />
            </td>
            <td>
                <asp:Button ID="Btnclr" runat="server" Text="Clear" Width="101px" Style="height: 26px"
                    OnClick="Btnclr_Click1" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <div style="text-align: center;">
        <asp:GridView ID="GvVMshow" runat="server" Width="532px" AutoGenerateColumns="False"
            OnRowCommand="GvVMshow_RowCommand" OnRowDeleting="GVMshow_Rowdeleting" PageSize="5"
            OnPageIndexChanging="GvVMshow_PageIndexChanging" AllowPaging="true" OnPageIndexChanged="GvVMshow_PageIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lblid1" runat="server" Font-Size="Small" Text='<%# Bind("Vid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Created Date">
                    <ItemTemplate>
                        <asp:Label ID="lblid5" runat="server" Font-Size="Small" Text='<%# Bind("VidhanDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Vidhan mandal">
                    <ItemTemplate>
                        <asp:Label ID="lblid2" runat="server" Font-Size="Small" Text='<%# Bind("Vidhanmandal") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Discription">
                    <ItemTemplate>
                        <asp:Label ID="lblid3" runat="server" Font-Size="Small" Text='<%# Bind("VidhanDescr") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LastModifieddate">
                    <ItemTemplate>
                        <asp:Label ID="lblid4" runat="server" Font-Size="Small" Text='<%# Bind("LastModifieddate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="button1" Text="Modify" runat="server" CommandName="Modify" CommandArgument='<%#Eval("Vid") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="button2" Text="Delete" runat="server" CommandName="Delete" CommandArgument='<%#Eval("Vid") %>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
    </div>
</asp:Content>
