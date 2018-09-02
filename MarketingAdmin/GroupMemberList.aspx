<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="GroupMemberList.aspx.cs" Inherits="MarketingAdmin_GroupMemberList"
    EnableEventValidation="false" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">

        function numbersonly(myfield, e, dec) {
            var key;
            var keychar;

            if (window.event)
                key = window.event.keyCode;
            else if (e)
                key = e.which;
            else
                return true;
            keychar = String.fromCharCode(key);

            // control keys
            if ((key == null) || (key == 0) || (key == 8) ||
            (key == 9) || (key == 13) || (key == 27))
                return true;

            // numbers with prcision..
            else if ((("0123456789.").indexOf(keychar) > -1))
                return true;

            //        // decimal point jump
            //        else if (dec && (keychar == "."))
            //           {
            //           myfield.form.elements[dec].focus();
            //           return false;
            //           }
            else
                return false;
        }

    </script>

    <script language="javascript" type="text/javascript">
        function AllowOnlyNumeric3() {
            // Get the ASCII value of the key that the user entered
            var key = window.event.keyCode;
            if ((key >= 65 && key <= 90) || (key >= 97 && key <= 122) || (key >= 46 && key <= 57) || key == 46 || key == 13 || key == 32) {
                var a = document.getElementById("<%=txtGroupSMSMsg.ClientID%>").value.length;

                document.getElementById("<%=txtCharCount2.ClientID%>").value = a + 0;
                if (a + 0 == 160 || a + 0 >= 160) {
                    alert('Message length >= 160, So SMS Count = 2. Are you aggri?');

                } else if (a + 0 == 306) {
                    alert('Message length >= 306, So SMS Count = 3. Are you aggri?');
                } else if (a + 0 == 459) {
                    alert('Message length >= 459, So SMS Count = 4. Are you aggri?');
                } else if (a + 0 == 612) {
                    alert('Message length >= 612, So SMS Count = 5. Are you aggri?');
                } else if (a + 0 == 765) {
                    alert('Message length >= 765, So SMS Count = 6. Are you aggri?');
                } else if (a + 0 == 918) {
                    alert('Message length >= 480, So SMS Count = 7. Are you aggri?');
                } else if (a + 0 == 1071) {
                    alert('Message length >= 1071, So SMS Count = 8. Are you aggri?');
                } else if (a + 0 == 1224) {
                    alert('Message length >= 1224, So SMS Count = 9. Are you aggri?');
                } else if (a + 0 == 1377) {
                    alert('Message length >= 1377, So SMS Count = 10. Are you aggri?');
                } else if (a + 0 == 1530) {
                    alert('Message length >= 1530, So SMS Count = 11. Are you aggri?');
                }
                return;
            }
            else {

                window.event.returnValue = null;
            }
        }
    </script>

    <script language="javascript" type="text/javascript">
        function AllowOnlyNumeric2() {
            // Get the ASCII value of the key that the user entered
            var key = window.event.keyCode;
            if ((key >= 65 && key <= 90) || (key >= 97 && key <= 122) || (key >= 46 && key <= 57) || key == 46 || key == 13 || key == 32) {
                var a = document.getElementById("<%=txtBjsMgs.ClientID%>").value.length;

                document.getElementById("<%=txtmgslen.ClientID%>").value = a + 0;
                if (a + 0 == 160 || a + 0 >= 160) {
                    alert('Message length >= 160, So SMS Count = 2. Are you aggri?');

                } else if (a + 0 == 306) {
                    alert('Message length >= 306, So SMS Count = 3. Are you aggri?');
                } else if (a + 0 == 459) {
                    alert('Message length >= 459, So SMS Count = 4. Are you aggri?');
                } else if (a + 0 == 612) {
                    alert('Message length >= 612, So SMS Count = 5. Are you aggri?');
                } else if (a + 0 == 765) {
                    alert('Message length >= 765, So SMS Count = 6. Are you aggri?');
                } else if (a + 0 == 918) {
                    alert('Message length >= 480, So SMS Count = 7. Are you aggri?');
                } else if (a + 0 == 1071) {
                    alert('Message length >= 1071, So SMS Count = 8. Are you aggri?');
                } else if (a + 0 == 1224) {
                    alert('Message length >= 1224, So SMS Count = 9. Are you aggri?');
                } else if (a + 0 == 1377) {
                    alert('Message length >= 1377, So SMS Count = 10. Are you aggri?');
                } else if (a + 0 == 1530) {
                    alert('Message length >= 1530, So SMS Count = 11. Are you aggri?');
                }
                return;
            }
            else {

                window.event.returnValue = null;
            }
        }
    </script>

    <script language="javascript" type="text/javascript">
        function AllowOnlyNumeric2() {
            // Get the ASCII value of the key that the user entered
            var key = window.event.keyCode;
            if ((key >= 65 && key <= 90) || (key >= 97 && key <= 122) || (key >= 46 && key <= 57) || key == 46 || key == 13 || key == 32) {
                var a = document.getElementById("<%=txtMgsReplay.ClientID%>").value.length;

                document.getElementById("<%=txtMsglegReplay.ClientID%>").value = a + 0;
                if (a + 0 == 160 || a + 0 >= 160) {
                    alert('Message length >= 160, So SMS Count = 2. Are you aggri?');

                } else if (a + 0 == 306) {
                    alert('Message length >= 306, So SMS Count = 3. Are you aggri?');
                } else if (a + 0 == 459) {
                    alert('Message length >= 459, So SMS Count = 4. Are you aggri?');
                } else if (a + 0 == 612) {
                    alert('Message length >= 612, So SMS Count = 5. Are you aggri?');
                } else if (a + 0 == 765) {
                    alert('Message length >= 765, So SMS Count = 6. Are you aggri?');
                } else if (a + 0 == 918) {
                    alert('Message length >= 480, So SMS Count = 7. Are you aggri?');
                } else if (a + 0 == 1071) {
                    alert('Message length >= 1071, So SMS Count = 8. Are you aggri?');
                } else if (a + 0 == 1224) {
                    alert('Message length >= 1224, So SMS Count = 9. Are you aggri?');
                } else if (a + 0 == 1377) {
                    alert('Message length >= 1377, So SMS Count = 10. Are you aggri?');
                } else if (a + 0 == 1530) {
                    alert('Message length >= 1530, So SMS Count = 11. Are you aggri?');
                }
                return;
            }
            else {

                window.event.returnValue = null;
            }
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
    <table cellpadding="0" cellspacing="0" width="100%" border="1" class="tables">
        <tr>
            <td>
                <asp:Accordion ID="acdLogin" runat="server" TransitionDuration="800" FramesPerSecond="40"
                    SuppressHeaderPostbacks="true" defaultfocus="pnlExistUser" FadeTransitions="true"
                    CssClass="Accordion" RequireOpenedPane="false" HeaderCssClass="AccordionHeaderby"
                    ContentCssClass="AccordionContent" HeaderSelectedCssClass="AccordionHeader">
                    <Panes>
                        <asp:AccordionPane ID="pnlExistUser" runat="server">
                            <Header>
                                <div style="float: left">
                                    <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />
                                    Group Member --->
                                </div>
                            </Header>
                            <Content>
                                <center>
                                    <br />
                                    <br />
                                    <table style="width: 70%; height: 150px;" cellspacing="0px">
                                        <tr>
                                            <td align="left">
                                                From Date
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                                                    Format="yyyy-MM-dd" PopupButtonID="Image2">
                                                </asp:CalendarExtender>
                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/calendarclick.gif" Width="15px">
                                                </asp:Image>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                To Date
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtTodate" runat="server"></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTodate"
                                                    PopupButtonID="Image1" Format="yyyy-MM-dd">
                                                </asp:CalendarExtender>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/calendarclick.gif" Width="15px">
                                                </asp:Image>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                City
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtcity" runat="server" CssClass="txtcss1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Message Text
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtGroupSMSMsg" runat="server" CssClass="txtcss1" TextMode="MultiLine"
                                                    onkeyup="AllowOnlyNumeric3()" Width="200px" Height="50px"></asp:TextBox>
                                                <asp:TextBox ID="txtCharCount2" runat="server" Width="40px" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn" OnClick="btnsearch_Click" />
                                                <asp:Button ID="btnSendMessage" runat="server" Text="Send Message" CssClass="btn"
                                                    OnClick="btnSendMessage_Click" />
                                                <asp:Button ID="btnsendCancel" runat="server" Text="Cancel" CssClass="btn" Width="108px"
                                                    OnClick="btnsendCancel_Click" />
                                                <asp:Button ID="btnDownLoadFormat" runat="server" Text="Download Excel" CssClass="btn"
                                                    Width="108px" OnClick="btnDownLoadFormat_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                </center>
                                <asp:GridView ID="gvItem" runat="server" Width="100%" CssClass="datatable" CellPadding="5"
                                    BorderColor="#2F4F4F" CellSpacing="0" GridLines="None" AutoGenerateColumns="False"
                                    ToolTip="Details Of Student Attendence" AllowPaging="true" PageSize="15" OnPageIndexChanging="gvItem_PageIndexChanging">
                                    <RowStyle BackColor="#F7F7DE" Height="30px" />
                                    <%--AllowPaging="true" PageSize="3" OnPageIndexChanging="gvItem_PageIndexChanging"--%>
                                    <Columns>
                                        <asp:BoundField DataField="FullName" HeaderText="Name">
                                            <HeaderStyle HorizontalAlign="Left" Width="40%" />
                                            <ItemStyle HorizontalAlign="left" Width="40%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="usrMobileNo" HeaderText="Mobile No">
                                            <HeaderStyle HorizontalAlign="left" Width="10%" />
                                            <ItemStyle HorizontalAlign="left" Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="GroupValueName" HeaderText="Group Name">
                                            <HeaderStyle HorizontalAlign="left" Width="15%" />
                                            <ItemStyle HorizontalAlign="left" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="city" HeaderText="City">
                                            <HeaderStyle HorizontalAlign="left" Width="10%" />
                                            <ItemStyle HorizontalAlign="left" Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="joindate" HeaderText="Join Date">
                                            <HeaderStyle HorizontalAlign="left" Width="15%" />
                                            <ItemStyle HorizontalAlign="left" Width="15%" />
                                        </asp:BoundField>
                                        <%-- <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelectFriend" runat="server" Text="" Width="10%" /></ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCC99" />
                                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#3d8c8f" Font-Bold="True" Font-Size="1.1em" ForeColor="White"
                                        Height="30px" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane ID="AccordionPane1" runat="server">
                            <Header>
                                <div style="float: left">
                                    <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />
                                    SMS Report --->
                                </div>
                            </Header>
                            <Content>
                                <center>
                                    <br />
                                    <br />
                                    <table style="width: 70%; height: 150px;" cellspacing="0px">
                                        <tr>
                                            <td align="left">
                                                Cuurent Time
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                Message Text
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtMgs" runat="server" CssClass="txtcss1" TextMode="MultiLine" Width="200px"
                                                    Height="50px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <br />
                                                Message Id
                                            </td>
                                            <td align="left">
                                                <br />
                                                <asp:Label ID="lblId" runat="server" Text="" ForeColor="Red" Style="font-weight: 700"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <br />
                                                Mobile No
                                            </td>
                                            <td align="left">
                                                <br />
                                                <asp:Label ID="lblMobileNo" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <br />
                                                Date
                                            </td>
                                            <td align="left">
                                                <br />
                                                <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="left" style="height: 44px">
                                                <asp:Button ID="btnPushMgs" runat="server" Text="Push Message" CssClass="btn" OnClick="btnPushMgs_Click" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" Width="108px"
                                                    OnClick="btnCancel_Click" />
                                                <asp:Button ID="btndnload" runat="server" Text="Download Excel" CssClass="btn" Width="108px"
                                                    OnClick="btndnload_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td align="left">
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                                <asp:GridView ID="gvItemSms" runat="server" Width="100%" CssClass="datatable" CellPadding="5"
                                    BorderColor="#2F4F4F" CellSpacing="0" GridLines="None" AutoGenerateColumns="False"
                                    AllowPaging="true" PageSize="15" ToolTip="Details Of Student Attendence" OnRowCommand="gvItemSms_RowCommand"
                                    OnPageIndexChanging="gvLongCodeReport_PageIndexChanging">
                                    <RowStyle BackColor="#F7F7DE" Height="30px" />
                                    <Columns>
                                        <asp:BoundField DataField="PK" HeaderText="Id">
                                            <HeaderStyle HorizontalAlign="left" Width="10%" />
                                            <ItemStyle HorizontalAlign="left" Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="mobile" HeaderText="Mobile Number">
                                            <HeaderStyle HorizontalAlign="left" Width="15%" />
                                            <ItemStyle HorizontalAlign="left" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Message" HeaderText="Message">
                                            <HeaderStyle HorizontalAlign="left" Width="50%" />
                                            <ItemStyle HorizontalAlign="left" Width="50%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="shortcode" HeaderText="Date">
                                            <HeaderStyle HorizontalAlign="left" Width="15%" />
                                            <ItemStyle HorizontalAlign="left" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FlagStatus" HeaderText="Status">
                                            <HeaderStyle HorizontalAlign="left" Width="20%" />
                                            <ItemStyle HorizontalAlign="left" Width="20%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Push Message">
                                            <ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("PK") %>' runat="server"
                                                    ImageUrl="~/Resources/resources1/images/ico_yes1.gif" CommandName="Push" OnClientClick="stopPostBack()">
                                                </asp:ImageButton>
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
                            </Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane ID="AccordionPane2" runat="server">
                            <Header>
                                <div style="float: left">
                                    <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />
                                    Send SMS Id Base --->
                                </div>
                            </Header>
                            <Content>
                                <center>
                                    <br />
                                    <br />
                                    <table>
                                        <tr>
                                            <td>
                                                Enter Id To:-
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIdTo" runat="server" onkeypress="return numbersonly(this,event)"
                                                    MaxLength="7"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Enter Id Form:-
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtIdFrom" runat="server" onkeypress="return numbersonly(this,event)"
                                                    MaxLength="7"></asp:TextBox>
                                                <%--OnTextChanged="txtIdFrom_TextChanged"--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                SMS Text:-
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBjsMgs" runat="server" TextMode="MultiLine" onkeyup="AllowOnlyNumeric2()"
                                                    Height="60px" Width="250px"></asp:TextBox>
                                                <asp:TextBox ID="txtmgslen" runat="server" Width="50px" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSearchId" runat="server" Text="Search" CssClass="btn" OnClick="btnSearchId_Click" />
                                                <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="btn" OnClick="btnSend_Click" />
                                                <asp:Button ID="btnCancelmgs" runat="server" Text="Cancel" CssClass="btn" OnClick="btnCancelmgs_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <center>
                                                    <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="datatable" CellPadding="5"
                                                        BorderColor="#2F4F4F" CellSpacing="0" GridLines="None" AutoGenerateColumns="False"
                                                        ToolTip="Details Of BJS Report">
                                                        <RowStyle BackColor="#F7F7DE" Height="30px" />
                                                        <Columns>
                                                            <asp:BoundField DataField="PK" HeaderText="Id">
                                                                <HeaderStyle HorizontalAlign="left" Width="10%" />
                                                                <ItemStyle HorizontalAlign="left" Width="10%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="mobile" HeaderText="Mobile Number">
                                                                <HeaderStyle HorizontalAlign="left" Width="15%" />
                                                                <ItemStyle HorizontalAlign="left" Width="15%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Message" HeaderText="Message">
                                                                <HeaderStyle HorizontalAlign="left" Width="50%" />
                                                                <ItemStyle HorizontalAlign="left" Width="50%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="shortcode" HeaderText="Date">
                                                                <HeaderStyle HorizontalAlign="left" Width="15%" />
                                                                <ItemStyle HorizontalAlign="left" Width="15%" />
                                                            </asp:BoundField>
                                                            <%-- <asp:BoundField DataField="FlagStatus" HeaderText="Status">
                                                                <HeaderStyle HorizontalAlign="left" Width="20%" />
                                                                <ItemStyle HorizontalAlign="left" Width="20%" />
                                                            </asp:BoundField>--%>
                                                        </Columns>
                                                        <FooterStyle BackColor="#CCCC99" />
                                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#3d8c8f" Font-Bold="True" Font-Size="1.1em" ForeColor="White"
                                                            Height="30px" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </center>
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </Content>
                        </asp:AccordionPane>
                        <asp:AccordionPane ID="SentSmsReports" runat="server">
                            <Header>
                                <div style="float: left">
                                    <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />
                                    Set Auto Replay Message --->
                                </div>
                            </Header>
                            <Content>
                                <center>
                                    <br />
                                    <br />
                                    <table>
                                        <tr>
                                            <td align="right">
                                                Set Replay Message
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMgsReplay" runat="server" TextMode="MultiLine" onkeyup="AllowOnlyNumeric2()"
                                                    Height="60px" Width="250px"></asp:TextBox>
                                                <asp:TextBox ID="txtMsglegReplay" runat="server" Width="50px" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSubmitReplay" runat="server" Text="Set Message" CssClass="btn"
                                                    OnClick="btnSubmitReplay_Click" />
                                                <asp:Button ID="btnCancelReplay" runat="server" Text="Cancel" CssClass="btn" OnClick="btnCancelReplay_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <center>
                                                    <asp:GridView ID="gvReplay" runat="server" Width="80%" CssClass="datatable" CellPadding="5"
                                                        BorderColor="#2F4F4F" CellSpacing="0" GridLines="Vertical" AutoGenerateColumns="False"
                                                        ToolTip="Details Of BJS Report" AllowPaging="true" PageSize="15" OnPageIndexChanging="gvReplay_PageIndexChanging">
                                                        <RowStyle BackColor="#F7F7DE" Height="30px" />
                                                        <Columns>
                                                            <asp:BoundField DataField="setMessage" HeaderText="Massage">
                                                                <HeaderStyle HorizontalAlign="left" Width="50%" />
                                                                <ItemStyle HorizontalAlign="left" Width="50%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Totallen" HeaderText="Message Length">
                                                                <HeaderStyle HorizontalAlign="left" Width="15%" />
                                                                <ItemStyle HorizontalAlign="left" Width="15%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Count1" HeaderText="Count Message">
                                                                <HeaderStyle HorizontalAlign="left" Width="20%" />
                                                                <ItemStyle HorizontalAlign="left" Width="20%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="EntryDate" HeaderText="Date">
                                                                <HeaderStyle HorizontalAlign="left" Width="15%" />
                                                                <ItemStyle HorizontalAlign="left" Width="15%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Active" HeaderText="Active">
                                                                <HeaderStyle HorizontalAlign="left" Width="20%" />
                                                                <ItemStyle HorizontalAlign="left" Width="20%" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#CCCC99" />
                                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#3d8c8f" Font-Bold="True" Font-Size="1.1em" ForeColor="White"
                                                            Height="30px" />
                                                        <AlternatingRowStyle BackColor="White" />
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
                                <div style="float: left">
                                    <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />
                                    Auto Replay Message Report--->
                                </div>
                            </Header>
                            <Content>
                                <center>
                                    <br />
                                    <br />
                                    <table>
                                        <tr>
                                            <td colspan="2">
                                                <center><%--SELECT ID, SendFrom,SendTo,sentMessage,EntryDate,Count1 --%>
                                                    <asp:GridView ID="gvReportRelpay" runat="server" Width="80%" CssClass="datatable" CellPadding="5"
                                                        BorderColor="#2F4F4F" CellSpacing="0" GridLines="Vertical" AutoGenerateColumns="False"
                                                        ToolTip="Details Of BJS Report" AllowPaging="true" PageSize="15" OnPageIndexChanging="gvReportRelpay_PageIndexChanging">
                                                        <RowStyle BackColor="#F7F7DE" Height="30px" />
                                                        <Columns>
                                                         <asp:BoundField DataField="ID" HeaderText="Id" Visible="false">
                                                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SendFrom" HeaderText="Send From">
                                                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SendTo" HeaderText="Sent To">
                                                                <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="sentMessage" HeaderText="Message">
                                                                <HeaderStyle HorizontalAlign="Center" Width="50%" />
                                                                <ItemStyle HorizontalAlign="Center" Width="50%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="EntryDate" HeaderText="Date">
                                                                <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Count1" HeaderText="Count">
                                                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#CCCC99" />
                                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#3d8c8f" Font-Bold="True" Font-Size="1.1em" ForeColor="White"
                                                            Height="30px" />
                                                        <AlternatingRowStyle BackColor="White" />
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
            </td>
        </tr>
    </table>
</asp:Content>
