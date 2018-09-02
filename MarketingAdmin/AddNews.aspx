<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="AddNews.aspx.cs" Inherits="MarketingAdmin_AddNews" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="outsidediv">
        <div class="headingdiv">
            <h2>
                News Info</h2>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                ID :
            </div>
            <div class="subtddiv">
                <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                News Heading :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtNewsHeading" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="save"
                    ControlToValidate="txtNewsHeading" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Topic :
            </div>
            <div class="subtddiv">
                <asp:DropDownList ID="ddlTopic" runat="server" AutoPostBack="true" 
                    CssClass="ddlcss" onselectedindexchanged="ddlTopic_SelectedIndexChanged">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">Exam</asp:ListItem>
                    <asp:ListItem Value="2">Job</asp:ListItem>
                    <asp:ListItem Value="3">Syllabus</asp:ListItem>
                    <asp:ListItem Value="4">Eligibility</asp:ListItem>
                    <asp:ListItem Value="5">FrontPageAd</asp:ListItem>
                    <asp:ListItem Value="6">Help</asp:ListItem>                    
                </asp:DropDownList>
                 <asp:DropDownList ID="ddlexamIdName" runat="server" CssClass="ddlcss" Visible="false">
                </asp:DropDownList>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                News Paper :
            </div>
            <div class="subtddiv">
                <asp:DropDownList ID="ddlNewsPaper" runat="server" CssClass="ddlcss" AutoPostBack="true">                    
                </asp:DropDownList>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Select Project :
            </div>
            <div class="subtddiv">
                <asp:DropDownList ID="ddlprject" runat="server" CssClass="ddlcss" AutoPostBack="true">                                       
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="save"
                    ControlToValidate="ddlprject" InitialValue="0" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Date of News Rececived :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtdtnewsRece" runat="server" CssClass="txtcss"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdtnewsRece">
                </asp:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="save"
                    ControlToValidate="txtdtnewsRece" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                last Date of Application :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtDtApplication" runat="server" CssClass="txtcss"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDtApplication">
                </asp:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="save"
                    ControlToValidate="txtDtApplication" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Any fees of Application :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtfees" runat="server" CssClass="txtcss"></asp:TextBox>
            </div>
        </div>
        <div class="tdcssdiv tdcssdiv1">
            <div class="tdlbl">
                News in Detail :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtNewsDetail" runat="server" TextMode="MultiLine" Height="80px"
                    Width="300px"></asp:TextBox>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Attachment :
            </div>
            <div class="subtddiv">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </div>
        </div>
        <div class="tdcssdiv tdcsswidth">
            <div class="tdlbl">
                Applicable for :
            </div>
            <div class="subtddiv">
                <asp:RadioButtonList ID="rdoApplicablefor" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdoApplicablefor_SelectedIndexChanged">
                    <asp:ListItem Value="1">Whole State</asp:ListItem>
                    <asp:ListItem Value="2">Only Selected District</asp:ListItem>
                    <asp:ListItem Value="3">Only Selected Taluka</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <asp:Panel ID="statepnl" Visible="false" runat="server">
            <div class="tdcssdiv">
                <div class="tdlbl">
                    Select State :
                </div>
                <div class="subtddiv">
                    <asp:DropDownList ID="ddlstate" runat="server" CssClass="ddlcss" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="districtpnl" Visible="false" runat="server">
            <div class="tdcssdiv">
                <div class="tdlbl">
                    Select District :
                </div>
                <div class="subtddiv">
                    <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="ddlcss" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="citypnl" Visible="false" runat="server">
            <div class="tdcssdiv">
                <div class="tdlbl">
                    Select City :
                </div>
                <div class="subtddiv">
                    <asp:DropDownList ID="ddlcity" runat="server" CssClass="ddlcss">
                    </asp:DropDownList>
                </div>
            </div>
        </asp:Panel>
        <div class="tdcssdiv">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" ValidationGroup="save"
                OnClick="btnSubmit_Click" />
        </div>
        <div>
            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="ddlcss" AutoPostBack="true"
                onselectedindexchanged="ddlCategory_SelectedIndexChanged">
                <asp:ListItem Value="0">--Select--</asp:ListItem>
                <asp:ListItem Value="1">Exam</asp:ListItem>
                <asp:ListItem Value="2">Job</asp:ListItem>
                <asp:ListItem Value="3">Syllabus</asp:ListItem>
                <asp:ListItem Value="4">Eligibility</asp:ListItem>
                <asp:ListItem Value="5">eZeeHealth</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div>
            <asp:GridView ID="gvDispNews" runat="server" CssClass="gridview" AllowPaging="true"
                PageSize="10" AutoGenerateColumns="false" OnPageIndexChanged="gvDispNews_PageIndexChanged"
                OnPageIndexChanging="gvDispNews_PageIndexChanging" OnRowCommand="gvDispNews_RowCommand">
                <Columns>
                    <asp:BoundField DataField="NID" HeaderText="ID">
                        <HeaderStyle HorizontalAlign="Center" Width="2%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="NHeading" HeaderText="Heading">
                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="NTopic" HeaderText="Topic">
                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="NPaper" HeaderText="Paper">
                        <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="DONR" HeaderText="Received Date">
                        <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="LDOA" HeaderText="Last Date">
                        <HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="NFeesApp" HeaderText="Fees">
                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="NInDetail" HeaderText="Detail News">
                        <HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="NApplicablefor" HeaderText="Applicable only">
                        <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                    </asp:BoundField>
                    <%--<asp:BoundField DataField="usrWorkStatus" HeaderText="Status">
                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                    </asp:BoundField>--%>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnModify" runat="server" Text="Modify" CssClass="btn" CommandArgument='<%#Bind("NID")%>'
                                CommandName="Modify" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
