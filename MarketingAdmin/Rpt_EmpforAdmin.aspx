<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="Rpt_EmpforAdmin.aspx.cs" Inherits="MarketingAdmin_Rpt_EmpforAdmin"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="outsidediv">
        <div class="headingdiv">
            <h2>
                Employee Reports
            </h2>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                &nbsp;Select Role :
            </div>
            <div class="subtddiv">
                <asp:DropDownList ID="ddlRoleList" runat="server" CssClass="cssddlwidth" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlRoleList_SelectedIndexChanged">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">System Admin</asp:ListItem>
                    <asp:ListItem Value="2">Project Admin</asp:ListItem>
                    <asp:ListItem Value="3">Marketting Admin</asp:ListItem>
                    <asp:ListItem Value="4">Data Admin</asp:ListItem>
                    <asp:ListItem Value="5">Programmer</asp:ListItem>
                    <asp:ListItem Value="6">Tester</asp:ListItem>
                    <asp:ListItem Value="7">Salesman</asp:ListItem>
                    <asp:ListItem Value="8">Support Member</asp:ListItem>
                    <asp:ListItem Value="9">Marketing Team lead / District lead</asp:ListItem>
                    <asp:ListItem Value="10">Data Entry operator</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlRoleList"
                    ErrorMessage="*" InitialValue="0" ValidationGroup="sub"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="tdcssdiv tdcssdiv1">
            <div class="tdlbl">
            Select :
            </div>
            <div class="subtddiv">
                <asp:RadioButtonList ID="rdo_sortbtn" runat="server" AutoPostBack="true" RepeatDirection="Vertical"
                    OnSelectedIndexChanged="rdo_sortbtn_SelectedIndexChanged">
                    <asp:ListItem Value="1">Date wise</asp:ListItem>
                    <asp:ListItem Value="2">Month Wise</asp:ListItem>
                    <asp:ListItem Value="3">Employee wise</asp:ListItem>
                    <asp:ListItem Value="4">Project wise</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <asp:Panel ID="pnlempwise" runat="server" Visible="false">
            <div class="tdcssdiv">
                <div class="tdlbl">
                    &nbsp;Select Employee :
                </div>
                <div class="subtddiv">
                    <asp:DropDownList ID="ddlEmpList" runat="server" CssClass="cssddlwidth">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="tdcssdiv">
                <div class="tdlbl">
                    &nbsp; Select Date:
                </div>
                <div class="subtddiv">
                    <asp:TextBox ID="txtempDate" runat="server" CssClass="ccstxt"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtempDate" Format="MM/dd/yyyy"></asp:CalendarExtender>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnldaywise" runat="server" Visible="false">
            <div class="tdcssdiv">
                <div class="tdlbl">
                    Select Date&nbsp;:
                </div>
                <div class="subtddiv">
                    <asp:TextBox ID="txtdayDate" runat="server" CssClass="ccstxt"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdayDate" Format="MM/dd/yyyy">
                    </asp:CalendarExtender>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlmonthwise" runat="server" Visible="false">
            <div class="tdcssdiv">
                <div class="tdlbl">
                    From Date&nbsp;:
                </div>
                <div class="subtddiv">
                    <asp:TextBox ID="txtmnthfromDate" runat="server" CssClass="ccstxt"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtmnthfromDate" Format="MM/dd/yyyy">
                    </asp:CalendarExtender>
                </div>
            </div>
            <div class="tdcssdiv">
                <div class="tdlbl">
                    To Date&nbsp;:
                </div>
                <div class="subtddiv">
                    <asp:TextBox ID="txtmnthtoDate" runat="server" CssClass="ccstxt"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtmnthtoDate" Format="MM/dd/yyyy">
                    </asp:CalendarExtender>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlprojectwise" runat="server" Visible="false">
            <div class="tdcssdiv">
                <div class="tdlbl">
                    Select Project&nbsp;:
                </div>
                <div class="subtddiv">
                    <asp:DropDownList ID="ddlprjwise" runat="server" CssClass="cssddlwidth">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="1">EzeeDrug</asp:ListItem>
                        <asp:ListItem Value="2">EzeeTest</asp:ListItem>
                        <asp:ListItem Value="3">EzeeSchool</asp:ListItem>
                        <asp:ListItem Value="4">Myct</asp:ListItem>
                        <asp:ListItem Value="5">EzeeMobile</asp:ListItem>
                        <asp:ListItem Value="6">EzeeMediretail</asp:ListItem>
                        <asp:ListItem Value="7">MilkDairy</asp:ListItem>
                        <asp:ListItem Value="8">Other</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </asp:Panel>
        <div class="tdcssdiv">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" ValidationGroup="sub" OnClick="btnSubmit_Click" />
        </div>
        <div class="tdcssdiv">
            <asp:GridView ID="gvEmpWorkStatus" runat="server" CssClass="gridview" AllowPaging="true"
                PageSize="10" AutoGenerateColumns="false" OnPageIndexChanged="gvEmpWorkStatus_PageIndexChanged"
                OnPageIndexChanging="gvEmpWorkStatus_PageIndexChanging">
                <Columns>
                <asp:TemplateField HeaderText="Sr.No">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:BoundField DataField="usrFName" HeaderText="First Name">
                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="usrLName" HeaderText="Last Name">
                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="usrPrjName" HeaderText="Project Name">
                        <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="usrEntryType" HeaderText="Type">
                        <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="usrContents" HeaderText="Contents">
                        <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="usrTimeReq" HeaderText="Required Time">
                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="usrEndDate" HeaderText="Completion Date">
                        <HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="usrAttachment" HeaderText="Attached Document">
                        <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="usrWorkStatus" HeaderText="Status">
                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Download">
                    <ItemTemplate>
                    <asp:LinkButton ID="lnkbtnDownload" runat="server" Text="Download" CommandArgument='<%#Eval("usrAttachment") %>' OnClick = "DownloadFile"></asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
