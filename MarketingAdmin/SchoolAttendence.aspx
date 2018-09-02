<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="SchoolAttendence.aspx.cs" Inherits="MarketingAdmin_SchoolAttendence"
    Title="Untitled Page" %>

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

    <script language="javascript" type="text/javascript">
        function openPopup(strOpen) {
            open(strOpen, "Message",
         "status=1, width=600, height=400, top=100, left=300");
        }
        //        function changeImage() {

        //            if (document.getElementById("changer").src == "imgs/left.gif") {
        //                document.getElementById("changer").src = "imgs/right.gif";
        //            }
        //            else {
        //                document.getElementById("changer").src = "imgs/left.gif";
        //            }
        //        }
    </script>

    <table cellpadding="0" cellspacing="0" width="100%" border="1" class="tables">
        <tr>
            <td align="center">
                <div style="margin-top: 20px; margin-bottom: 20px; min-height: 400px">
                    <center>
                        <asp:Label ID="lblSchoolCode" runat="server" Text="" ForeColor="red" Font-Bold="true"></asp:Label>
                        <br />
                        <br />
                        <span style="font-size: 1.5em; font-weight: bold">School Attendence Reporting</span>
                        <br />
                        <br />
                        <asp:Accordion ID="acdLogin" runat="server" TransitionDuration="800" FramesPerSecond="40"
                            SuppressHeaderPostbacks="true" defaultfocus="pnlExistUser" FadeTransitions="true"
                            CssClass="Accordion" RequireOpenedPane="false" HeaderCssClass="AccordionHeaderby"
                            ContentCssClass="AccordionContent" HeaderSelectedCssClass="AccordionHeader">
                            <Panes>
                                <asp:AccordionPane ID="pnlExistUser" runat="server">
                                    <Header>
                                        <div style="float: left">
                                            <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />Teachar
                                            Sent Presenty Report --->
                                        </div>
                                    </Header>
                                    <Content>
                                        <br />
                                        <br />
                                        <table>
                                            <tr>
                                                <td align="left">
                                                    <asp:CheckBox ID="ChkMonth" runat="server" Text=" Select Teacher sent Sms report on month wise"
                                                        AutoPostBack="true" OnCheckedChanged="ChkMonth_CheckedChanged" />
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlmonth" CssClass="ddlcss" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:CheckBox ID="ChkDate" runat="server" Text=" Select Date wise Sms Report" AutoPostBack="true"
                                                        OnCheckedChanged="ChkDate_CheckedChanged" />
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtDate" runat="server" CssClass="txtcss"></asp:TextBox>
                                                    <asp:Image ID="Image1" runat="server" Enabled="false" ImageUrl="~/images/calendarclick.gif" />
                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"
                                                        PopupButtonID="Image1">
                                                    </asp:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Current Date Send Sms Report
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                </td>
                                                <td align="left">
                                                    <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn" OnClick="btnShow_Click" />
                                                    <asp:Button ID="btnDownload" runat="server" Text="Download" CssClass="btn" OnClick="btnDownload_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                        <div style="height: 20px">
                                            <asp:Panel ID="Panel1" runat="server" Visible="false">
                                                <asp:GridView ID="GvTech" runat="server" CellPadding="5" CellSpacing="0">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Boys %">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPerBoy1" runat="server" Text="Label"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Girls %">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPerGirls1" runat="server" Text="Label"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Class %">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAllStud1" runat="server" Text="Label"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>
                                        <div style="height: 300px; overflow: scroll; border: 1px solid #0d7074; border-radius: 5px">
                                            <asp:GridView ID="gvItem" runat="server" Width="100%" CssClass="datatable" CellPadding="5"
                                                BorderColor="#2F4F4F" OnRowCommand="gvItem_RowCommand" CellSpacing="0" GridLines="None"
                                                AutoGenerateColumns="False" ToolTip="Details Of Student Attendence">
                                                <RowStyle BackColor="#F7F7DE" Height="30px" />
                                                <Columns>
                                                    <asp:BoundField DataField="usrMobileno" HeaderText="Mobile No">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Class" HeaderText="Standard">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Division" HeaderText="Division">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RegBoys" HeaderText="Reg Boys">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RegGirls" HeaderText="Reg Girls">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Present_B" HeaderText="Present Boys">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Present_G" HeaderText="Present Girls">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EntryDate" HeaderText="Date">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Boys %">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPerBoy" runat="server" Text="Label"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Girls %">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPerGirls" runat="server" Text="Label"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Class %">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAllStud" runat="server" Text="Label"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Teacher SMS">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <%-- <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("usrMobileno") %>' runat="server"
                                                    ImageUrl="~/Resources/Images/ico_yes1.gif" CommandName="Push"></asp:ImageButton>--%>
                                                            <a href="javascript:openPopup('../PopUpFile/TeacherMonthlyReport.aspx?Mobileno=<%# Eval("usrMobileno") %>')">
                                                                Msg</a>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#CCCC99" />
                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#3d8c8f" Font-Bold="True" Font-Size="1.1em" ForeColor="White"
                                                    Height="30px" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </div>
                                        <div style="height: 20px">
                                        </div>
                                    </Content>
                                </asp:AccordionPane>
                                <asp:AccordionPane ID="pnlNewUser" runat="server">
                                    <Header>
                                        <div style="float: left">
                                            <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />Head
                                            Master Sent Teacher Presenty Report --->
                                        </div>
                                    </Header>
                                    <Content>
                                        <br />
                                        <br />
                                        <table>
                                            <tr>
                                                <td align="left">
                                                    <asp:CheckBox ID="chkmonthtech" runat="server" Text=" Head Master sent Sms report on month wise"
                                                        AutoPostBack="true" OnCheckedChanged="chkmonthtech_CheckedChanged" />
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="ddlMonthteacher" CssClass="ddlcss" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:CheckBox ID="chkdatetech" runat="server" Text=" Select Date wise Sms Report"
                                                        AutoPostBack="true" OnCheckedChanged="chkdatetech_CheckedChanged" />
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtDateTeacher" runat="server" CssClass="txtcss"></asp:TextBox>
                                                    <asp:Image ID="Image2" runat="server" Enabled="false" ImageUrl="~/images/calendarclick.gif" />
                                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDateTeacher"
                                                        PopupButtonID="Image2">
                                                    </asp:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    Current Date Send Sms Report
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblDateTeacher" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                </td>
                                                <td align="left">
                                                    <asp:Button ID="btnShowteacher" runat="server" Text="Show" CssClass="btn" OnClick="btnShowTeacher_Click" />
                                                    <asp:Button ID="btnDownloadTech" runat="server" Text="Download" CssClass="btn" OnClick="btnDownloadTech_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                        <div style="height: 20px">
                                            <asp:Panel ID="Panel2" runat="server" Visible="false">
                                                <asp:GridView ID="GvHM" runat="server" CellPadding="5" CellSpacing="0">
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>
                                        <div style="height: 300px; overflow: scroll; border: 1px solid #0d7074; border-radius: 5px">
                                            <asp:GridView ID="gvTeacher" runat="server" Width="100%" CssClass="datatable" CellPadding="5"
                                                BorderColor="#2F4F4F" CellSpacing="0" GridLines="None" AutoGenerateColumns="False"
                                                ToolTip="Details Of Student Attendence">
                                                <RowStyle BackColor="#F7F7DE" Height="30px" />
                                                <Columns>
                                                    <asp:BoundField DataField="usrMobileno" HeaderText="Mobile No">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EntryDate" HeaderText="Date">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RegMale" HeaderText="RegMale">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RegFemale" HeaderText="RegFemale">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Present_M" HeaderText="Present_M">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Present_F" HeaderText="Present_F">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ModifyDate" HeaderText="ModifyDate">
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Principal SMS">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <%-- <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("usrMobileno") %>' runat="server"
                                                    ImageUrl="~/Resources/Images/ico_yes1.gif" CommandName="Push"></asp:ImageButton>--%>
                                                            <a href="javascript:openPopup('../PopUpFile/TeacherMonthlyReport.aspx?Mobileno=<%# Eval("usrMobileno") %>')">
                                                                Msg</a>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#CCCC99" />
                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#3d8c8f" Font-Bold="True" Font-Size="1.1em" ForeColor="White"
                                                    Height="30px" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </div>
                                        <div style="height: 20px">
                                        </div>
                                    </Content>
                                </asp:AccordionPane>
                            </Panes>
                        </asp:Accordion>
                    </center>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
