<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="FamilyReport.aspx.cs" Inherits="MarketingAdmin_FamilyReport" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .Accordion
        {
            width: 100%;
            background-color: #fcfcfc;
            margin: 5px 0 10px 0;
            border-collapse: collapse;
            font-family: 'Calibri' , sans-serif;
        }
        .AccordionHeader
        {
            color: #fff;
            padding: 4px 2px;
            background: #0d7074;
            font-size: 16px;
            height: 30px;
            font-weight: bold;
            border: solid 1px #dddddd;
            border-radius: 15px;
            box-shadow: 1px 2px 7px #888888;
        }
        .AccordionHeaderby
        {
            color: #fff;
            padding: 4px 2px;
            background: #0d7074;
            font-size: 16px;
            height: 30px;
            font-weight: bold;
            border: solid 1px #dddddd;
            border-radius: 15px;
        }
        .AccordionContent
        {
        }
    </style>
    <asp:UpdatePanel ID="Updatepanel" runat="Server">
        <ContentTemplate>
            <div style="min-height: 500px">
                <asp:Accordion ID="acdLogin" runat="server" TransitionDuration="800" FramesPerSecond="40"
                    SuppressHeaderPostbacks="true" defaultfocus="pnlExistUser" FadeTransitions="true"
                    CssClass="Accordion" RequireOpenedPane="false" HeaderCssClass="AccordionHeaderby"
                    ContentCssClass="AccordionContent" HeaderSelectedCssClass="AccordionHeader">
                    <Panes>
                        <asp:AccordionPane ID="pnlExistUser" runat="server">
                            <Header>
                                <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />
                                Device Details
                            </Header>
                            <Content>
                                <center>
                                    <table class="tables">
                                        <tr>
                                            <td colspan="2">
                                                <center>
                                                    <h3>
                                                        Device Details
                                                    </h3>
                                                </center>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="gvItem" runat="server" CssClass="mGrid">
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane ID="AccordionPane1" runat="server">
                            <Header>
                                <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />
                                Word No Wise Details
                            </Header>
                            <Content>
                                <center>
                                    <table class="tables" width="80%">
                                        <tr>
                                            <td colspan="2">
                                                <center>
                                                    <h3>
                                                        Word No Wise Details</h3>
                                                </center>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Enter the word No :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtWordNo" runat="server" CssClass="txtcss" MaxLength="3"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Custom, Numbers"
                                                    TargetControlID="txtWordNo">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btnShowReport" runat="server" Text="Show" CssClass="btn" OnClick="btnShowReport_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <center>
                                                    <br />
                                                    <center>
                                                        Head Information
                                                    </center>
                                                    <br />
                                                    <asp:GridView ID="gvWordNoHead" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                                                        PageSize="10" AllowPaging="true" OnRowCommand="gvWordNoHead_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"></asp:BoundField>
                                                            <asp:BoundField DataField="FullName" HeaderText="FullName"></asp:BoundField>
                                                            <asp:BoundField DataField="p4" HeaderText="Mobile No"></asp:BoundField>
                                                            <asp:BoundField DataField="p9" HeaderText="Word No"></asp:BoundField>
                                                            <asp:TemplateField HeaderText="Show Member">
                                                                <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("Id") %>' runat="server"
                                                                        ImageUrl="~/Resources/resources1/images/ico_yes1.gif" CommandName="Push" OnClientClick="stopPostBack()">
                                                                    </asp:ImageButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <br />
                                                    <center>
                                                        Member Information
                                                    </center>
                                                    <br />
                                                    <asp:GridView ID="gvWordNoMem" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                                                        PageSize="10" AllowPaging="true" EmptyDataText="Member Not Found">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"></asp:BoundField>
                                                            <asp:BoundField DataField="FullName" HeaderText="FullName"></asp:BoundField>
                                                            <asp:BoundField DataField="p6" HeaderText="Mobile No"></asp:BoundField>
                                                            <asp:BoundField DataField="p11" HeaderText="Word No"></asp:BoundField>
                                                            <asp:BoundField DataField="p4" HeaderText="Head Mobile No"></asp:BoundField>
                                                            <asp:BoundField DataField="p5" HeaderText="Relation Of Head"></asp:BoundField>
                                                            <%-- <asp:BoundField DataField="Present_G" HeaderText="Present_G"></asp:BoundField>--%>
                                                        </Columns>
                                                    </asp:GridView>
                                                </center>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane ID="AccordionPane2" runat="server">
                            <Header>
                                <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />
                                Religion Information
                            </Header>
                            <Content>
                                <center>
                                    <table class="tables" width="80%">
                                        <tr>
                                            <td colspan="2">
                                                <center>
                                                    <h3>
                                                        Religion Information</h3>
                                                </center>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Select Religion
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlReligion" runat="server" CssClass="ddlcss">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Hindu</asp:ListItem>
                                                    <asp:ListItem Value="2">Muslim</asp:ListItem>
                                                    <asp:ListItem Value="3">Sikh</asp:ListItem>
                                                    <asp:ListItem Value="4">Jain</asp:ListItem>
                                                    <asp:ListItem Value="5">Christian</asp:ListItem>
                                                    <asp:ListItem Value="6">Buddh</asp:ListItem>
                                                    <asp:ListItem Value="7">Sindhi</asp:ListItem>
                                                    <asp:ListItem Value="8">Parsi</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btnReligion" runat="server" Text="Show" CssClass="btn" OnClick="btnReligion_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <center>
                                                    <br />
                                                    <center>
                                                        Head Information
                                                    </center>
                                                    <br />
                                                    <asp:GridView ID="gvReligionHead" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                                                        PageSize="10" AllowPaging="true" OnRowCommand="gvReligionHead_RowCommand" EmptyDataText="Data not Found">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"></asp:BoundField>
                                                            <asp:BoundField DataField="FullName" HeaderText="FullName"></asp:BoundField>
                                                            <asp:BoundField DataField="p4" HeaderText="Mobile No"></asp:BoundField>
                                                            <asp:BoundField DataField="p18" HeaderText="Religion"></asp:BoundField>
                                                            <asp:TemplateField HeaderText="Show Member">
                                                                <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("Id") %>' runat="server"
                                                                        ImageUrl="~/Resources/resources1/images/ico_yes1.gif" CommandName="Push" OnClientClick="stopPostBack()">
                                                                    </asp:ImageButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <br />
                                                    <center>
                                                        Member Information
                                                    </center>
                                                    <br />
                                                    <asp:GridView ID="GvMemReligion1" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                                                        PageSize="10" AllowPaging="true" EmptyDataText="Member Not Found">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"></asp:BoundField>
                                                            <asp:BoundField DataField="FullName" HeaderText="FullName"></asp:BoundField>
                                                            <asp:BoundField DataField="p6" HeaderText="Mobile No"></asp:BoundField>
                                                            <asp:BoundField DataField="p4" HeaderText="Head Mobile No"></asp:BoundField>
                                                            <asp:BoundField DataField="p5" HeaderText="Relation Of Head"></asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </center>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane ID="AccordionPane3" runat="server">
                            <Header>
                                <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />
                                Voter Id
                            </Header>
                            <Content>
                                <center>
                                    <table class="tables" width="80%">
                                        <tr>
                                            <td colspan="2">
                                                <center>
                                                    <h3>
                                                        Voter List
                                                    </h3>
                                                </center>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Enter The Voting No
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtVoting" runat="server" MaxLength="6" CssClass="txtcss"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterType="Custom, Numbers"
                                                    TargetControlID="txtVoting">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnDisplay" runat="server" Text="Show" CssClass="btn" OnClick="btnDisplay_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <center>
                                                    <asp:GridView ID="gvVoter" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                                                        PageSize="10" AllowPaging="true" EmptyDataText="Data not Found">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"></asp:BoundField>
                                                            <asp:BoundField DataField="FullName" HeaderText="FullName"></asp:BoundField>
                                                            <asp:BoundField DataField="p4" HeaderText="Mobile No"></asp:BoundField>
                                                            <asp:BoundField DataField="p24" HeaderText="Voting No"></asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </center>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane ID="AccordionPane6" runat="server">
                            <Header>
                                <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />
                                Age Wise Report
                            </Header>
                            <Content>
                                <center>
                                    <table class="tables" width="80%">
                                        <tr>
                                            <td colspan="2">
                                                <center>
                                                    <h3>
                                                        Age Wise Report
                                                    </h3>
                                                </center>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                From :
                                                <asp:TextBox ID="txtAge1" CssClass="txtcss" runat="server" Text="" MaxLength="3" />
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom, Numbers"
                                                    TargetControlID="txtAge1">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td align="left">
                                                To :
                                                <asp:TextBox ID="txtAge2" CssClass="txtcss" runat="server" Text="" MaxLength="3" />
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Custom, Numbers"
                                                    TargetControlID="txtAge2">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                <asp:Button ID="btnShow" runat="server" CssClass="btn" Text="Show Report" OnClick="btnShow_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="gvAgeHead" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                                                    PageSize="10" AllowPaging="true" OnRowCommand="gvAgeHead_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"></asp:BoundField>
                                                        <asp:BoundField DataField="FullName" HeaderText="FullName"></asp:BoundField>
                                                        <asp:BoundField DataField="p4" HeaderText="Mobile No"></asp:BoundField>
                                                        <asp:BoundField DataField="p12" HeaderText="Age"></asp:BoundField>
                                                        <asp:TemplateField HeaderText="Show Member">
                                                            <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("Id") %>' runat="server"
                                                                    ImageUrl="~/Resources/resources1/images/ico_yes1.gif" CommandName="Push" OnClientClick="stopPostBack()">
                                                                </asp:ImageButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="gvAgeMember" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                                                    PageSize="10" AllowPaging="true" EmptyDataText="Member Not Found">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="100px">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"></asp:BoundField>
                                                        <asp:BoundField DataField="FullName" HeaderText="FullName"></asp:BoundField>
                                                        <asp:BoundField DataField="p6" HeaderText="Mobile No"></asp:BoundField>
                                                        <asp:BoundField DataField="p14" HeaderText="Age"></asp:BoundField>
                                                        <%-- <asp:BoundField DataField="RegGirls" HeaderText="RegGirls"></asp:BoundField>
                                            <asp:BoundField DataField="Present_B" HeaderText="Present_B"></asp:BoundField>
                                            <asp:BoundField DataField="Present_G" HeaderText="Present_G"></asp:BoundField>--%>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane ID="AccordionPane7" runat="server">
                            <Header>
                                <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />
                                Pincode Wise Report
                            </Header>
                            <Content>
                                <center>
                                    <table class="tables" width="80%">
                                        <tr>
                                            <td colspan="2">
                                                <center>
                                                    <h3>
                                                        Pincode Wise Report
                                                    </h3>
                                                </center>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Enter The Pincode
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtPincode" CssClass="txtcss" runat="server" Text="" MaxLength="6" />
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Custom, Numbers"
                                                    TargetControlID="txtPincode">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btnPinCode" CssClass="btn" runat="server" Text="Show Report" OnClick="btnPincode_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <center>
                                                    <asp:GridView ID="gvPincodeHead" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                                                        PageSize="10" AllowPaging="true" OnRowCommand="gvPincodeHead_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"></asp:BoundField>
                                                            <asp:BoundField DataField="FullName" HeaderText="FullName"></asp:BoundField>
                                                            <asp:BoundField DataField="p4" HeaderText="Mobile No"></asp:BoundField>
                                                            <asp:BoundField DataField="p10" HeaderText="Pincode"></asp:BoundField>
                                                            <asp:TemplateField HeaderText="Show Member">
                                                                <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("Id") %>' runat="server"
                                                                        ImageUrl="~/Resources/resources1/images/ico_yes1.gif" CommandName="Push" OnClientClick="stopPostBack()">
                                                                    </asp:ImageButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </center>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <center>
                                                    <asp:GridView ID="gvPincodeMember" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                                                        PageSize="10" AllowPaging="true" EmptyDataText="Member Not Found">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"></asp:BoundField>
                                                            <asp:BoundField DataField="FullName" HeaderText="FullName"></asp:BoundField>
                                                            <asp:BoundField DataField="p6" HeaderText="Mobile No"></asp:BoundField>
                                                            <asp:BoundField DataField="p12" HeaderText="p10"></asp:BoundField>
                                                            <%-- <asp:BoundField DataField="RegGirls" HeaderText="RegGirls"></asp:BoundField>
                                            <asp:BoundField DataField="Present_B" HeaderText="Present_B"></asp:BoundField>
                                            <asp:BoundField DataField="Present_G" HeaderText="Present_G"></asp:BoundField>--%>
                                                        </Columns>
                                                    </asp:GridView>
                                                </center>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane ID="AccordionPane8" runat="server">
                            <Header>
                                <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />
                                Education Wise Report
                            </Header>
                            <Content>
                                <center>
                                    <table class="tables" width="80%">
                                        <tr>
                                            <td colspan="2">
                                                <center>
                                                    <h3>
                                                        Education Wise Report
                                                    </h3>
                                                </center>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Enter Education :
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEdu" CssClass="txtcss" runat="server" Text="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btnEdu" CssClass="btn" runat="server" Text="Show Report" OnClick="btnEdu_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <center>
                                                    <asp:GridView ID="gvEduHead" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                                                        PageSize="10" AllowPaging="true" OnRowCommand="gvEduHead_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"></asp:BoundField>
                                                            <asp:BoundField DataField="FullName" HeaderText="FullName"></asp:BoundField>
                                                            <asp:BoundField DataField="p4" HeaderText="Mobile No"></asp:BoundField>
                                                            <asp:BoundField DataField="p14" HeaderText="Education"></asp:BoundField>
                                                            <asp:TemplateField HeaderText="Show Member">
                                                                <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("Id") %>' runat="server"
                                                                        ImageUrl="~/Resources/resources1/images/ico_yes1.gif" CommandName="Push" OnClientClick="stopPostBack()">
                                                                    </asp:ImageButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </center>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <center>
                                                    <asp:GridView ID="gvEduMember" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                                                        PageSize="10" AllowPaging="true" EmptyDataText="Member Not Found">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"></asp:BoundField>
                                                            <asp:BoundField DataField="FullName" HeaderText="FullName"></asp:BoundField>
                                                            <asp:BoundField DataField="p6" HeaderText="Mobile No"></asp:BoundField>
                                                            <asp:BoundField DataField="p16" HeaderText="Education"></asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </center>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </Content>
                        </asp:AccordionPane>
                    </Panes>
                </asp:Accordion>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
