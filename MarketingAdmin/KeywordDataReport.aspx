<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="KeywordDataReport.aspx.cs" Inherits="MarketingAdmin_KeywordDataReport"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
//        function validate() {
//            if (document.getElementById("<%=txtKeyword.ClientID%>").value == "") {
//                alert("Enter the Keyword Name....!");
//                document.getElementById("<%=txtKeyword.ClientID%>").focus();
//                return false;
//            }
//            else if (document.getElementById("<%=txtSyntax.ClientID%>").value == "") {
//                alert("Enter the Keyword Syntax....!");
//                document.getElementById("<%=txtSyntax.ClientID%>").focus();
//                return false;
//            }
//            else if (document.getElementById("<%=txtPurpose.ClientID%>").value == "") {
//                alert("Enter the purpose...!");
//                document.getElementById("<%=txtPurpose.ClientID%>").focus();
//                return false;
//            }
//            else if (document.getElementById("<%=txtDiscrip.ClientID%>").value == "") {
//                alert("Enter The Discription...!");
//                document.getElementById("<%=txtDiscrip.ClientID%>").focus();
//                return false;
//            }
//            else if (document.getElementById("<%=ddlWebSite.ClientID%>").value == "") {
//                alert("Select Website or Group...!");
//                document.getElementById("<%=ddlWebSite.ClientID%>").focus();
//                return false;
//            }
//            return true;
        }

        //        function clearBox2() {
        //            document.getElementById("<%=txtKeyword.ClientID%>").value = '';
        //            document.getElementById("<%=txtSyntax.ClientID%>").value = '';
        //            document.getElementById("<%=txtPurpose.ClientID%>").value = '';
        //            document.getElementById("<%=txtDiscrip.ClientID%>").value = '';
        //            document.getElementById("<%=ddlWebSite.ClientID%>").value = '';
        //            document.getElementById("<%=btnSubmit.ClientID%>").value = 'Submit';
        //            document.getElementById("<%=lblId.ClientID%>").value = '';
        //        }
    </script>

    <script language="javascript" type="text/javascript">
        function openPopup(strOpen) {
            open(strOpen, "Message",
         "status=1, width=600, height=400, top=100, left=300");
        }
    </script>

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
    <div style="min-height: 500px">
        <asp:Accordion ID="acdLogin" runat="server" TransitionDuration="800" FramesPerSecond="40"
            SuppressHeaderPostbacks="true" defaultfocus="pnlExistUser" FadeTransitions="true"
            CssClass="Accordion" RequireOpenedPane="false" HeaderCssClass="AccordionHeaderby"
            ContentCssClass="AccordionContent" HeaderSelectedCssClass="AccordionHeader">
            <Panes>
                <asp:AccordionPane ID="pnlExistUser" runat="server">
                    <Header>
                        <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />
                        Define Keyword Data
                    </Header>
                    <Content>
                        <div style="background: #f6fbfc; border: 1px solid #dddddd">
                            <center>
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            <center>
                                                <h3>
                                                    Entry Keyword Data</h3>
                                            </center>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Keyword Name :*
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Keyword Syntax :*
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSyntax" runat="server" TextMode="MultiLine" Height="40px" Width="400px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Purpose :*
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPurpose" runat="server" TextMode="MultiLine" Height="100px" Width="400px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Discription :*
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDiscrip" runat="server" TextMode="MultiLine" Height="100px" Width="400px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Website / Group :*
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlWebSite" runat="server" CssClass="ddlcss">
                                                <asp:ListItem Value="">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Myct</asp:ListItem>
                                                <asp:ListItem Value="2">Udisecce</asp:ListItem>
                                                <asp:ListItem Value="3">School</asp:ListItem>
                                                <asp:ListItem Value="4">Android Mobile Apps</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" OnClick="btnSubmit_Click" />
                                            <%-- OnClientClick=" return validate()" />--%>
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" OnClick="btnCancel_Click" /><%--OnClientClick="clearBox2()"--%>
                                            <asp:Button ID="btnDownload" runat="server" Text="Download" CssClass="btn" OnClick="btnDownload_Click" />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <center>
                                    <%--OnPageIndexChanging="gvItem_PageIndexChanging"--%>
                                    <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" EmptyDataText="No Data Found"
                                        ToolTip="Details of Items" AllowPaging="true" Width="800px" PageSize="10" OnRowCommand="gvItem_RowCommand"
                                        OnPageIndexChanging="gvItem_PageIndexChanging">
                                        <RowStyle BackColor="#F7F7DE" Height="30px" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="50px">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="KeyId" HeaderText="KeyId" />
                                            <asp:BoundField DataField="KeywordName" HeaderText="Keyword" />
                                            <asp:BoundField DataField="KeywordSyntax" HeaderText="Syntax" />
                                            <asp:BoundField DataField="KeywordPurpose" HeaderText="Purpose" Visible="false" />
                                            <asp:BoundField DataField="KeyDiscip" HeaderText="Description" Visible="false" />
                                            <asp:BoundField DataField="WebsiteGroup" HeaderText="Website/Group" Visible="false" />
                                            <asp:BoundField DataField="EntryDate" HeaderText="Entry Date" />
                                            <asp:TemplateField HeaderText="Modify">
                                                <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("KeyId") %>' runat="server"
                                                        ImageUrl="~/Resources/resources1/images/ico_yes1.gif" CommandName="Modify" OnClientClick="stopPostBack()">
                                                    </asp:ImageButton>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Show Details">
                                                <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                                                <ItemTemplate>
                                                    <a href="javascript:openPopup('../PopUpFile/KeyDetails.aspx?Key=<%# Eval("KeyId") %>')">
                                                        Show</a>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCC99" />
                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#009999" Font-Bold="True" Font-Size="1.1em" ForeColor="White"
                                            Height="30px" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                    <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                    <%--  DownLoad--%>
                                    <asp:Panel ID="Panel" runat="server" Visible="false">
                                        <asp:GridView ID="GridView1" runat="server">
                                        </asp:GridView>
                                    </asp:Panel>
                                </center>
                            </center>
                            <br />
                        </div>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane1" runat="server">
                    <Header>
                        <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />
                        Search Keyword on Website and group
                    </Header>
                    <Content>
                        <div style="background: #f6fbfc; border: 1px solid #dddddd">
                            <center>
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            <center>
                                                <h3>
                                                    Search keyword On Website</h3>
                                            </center>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Website / Group :*
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlWebsiteSearch" runat="server" CssClass="ddlcss">
                                                <asp:ListItem Value="">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Myct</asp:ListItem>
                                                <asp:ListItem Value="2">Udisecce</asp:ListItem>
                                                <asp:ListItem Value="3">School</asp:ListItem>
                                                <asp:ListItem Value="4">Android Mobile Apps</asp:ListItem>
                                            </asp:DropDownList>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn" OnClick="btnSearch_Click" />
                                            <asp:Button ID="btnDwn" runat="server" Text="Download" CssClass="btn" OnClick="btnDwn_Click" />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <div>
                                    <asp:GridView ID="gvSearch" runat="server" AutoGenerateColumns="False" EmptyDataText="No Data Found"
                                        ToolTip="Details of Items" Width="800px">
                                        <RowStyle BackColor="#F7F7DE" Height="30px" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No" ItemStyle-Width="50px">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="KeyId" HeaderText="KeyId" />
                                            <asp:BoundField DataField="KeywordName" HeaderText="Keyword" />
                                            <asp:BoundField DataField="KeywordSyntax" HeaderText="Syntax" />
                                            <asp:BoundField DataField="KeywordPurpose" HeaderText="Purpose" Visible="false" />
                                            <asp:BoundField DataField="KeyDiscip" HeaderText="Description" Visible="false" />
                                            <asp:BoundField DataField="WebsiteGroup" HeaderText="Website/Group" Visible="false" />
                                            <asp:BoundField DataField="EntryDate" HeaderText="Entry Date" />
                                            <asp:TemplateField HeaderText="Show Details">
                                                <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                                                <ItemTemplate>
                                                    <a href="javascript:openPopup('../PopUpFile/KeyDetails.aspx?Key=<%# Eval("KeyId") %>')">
                                                        Show</a>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCC99" />
                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#009999" Font-Bold="True" Font-Size="1.1em" ForeColor="White"
                                            Height="30px" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </div>
                                <asp:Panel ID="Panel2" runat="server" Visible="false">
                                    <asp:GridView ID="GridView2" runat="server">
                                    </asp:GridView>
                                </asp:Panel>
                            </center>
                            <br />
                        </div>
                    </Content>
                </asp:AccordionPane>
            </Panes>
        </asp:Accordion>
    </div>
</asp:Content>
