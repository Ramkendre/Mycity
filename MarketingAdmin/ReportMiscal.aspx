<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="ReportMiscal.aspx.cs" Inherits="MarketingAdmin_ReportMiscal" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function AllowOnlyNumeric3() {
            // Get the ASCII value of the key that the user entered
            var key = window.event.keyCode;
            if ((key >= 65 && key <= 90) || (key >= 97 && key <= 122) || (key >= 46 && key <= 57) || key == 46 || key == 13 || key == 32) {
                var a = document.getElementById("<%=txtMessage.ClientID%>").value.length;

                document.getElementById("<%=txtCharCount2.ClientID%>").value = a + 1;
                if (a + 1 == 160) {
                    alert('Message length >= 160, So SMS Count = 2. Are you aggri?');

                } else if (a + 1 == 306) {
                    alert('Message length >= 306, So SMS Count = 3. Are you aggri?');
                } else if (a + 1 == 459) {
                    alert('Message length >= 459, So SMS Count = 4. Are you aggri?');
                } else if (a + 1 == 612) {
                    alert('Message length >= 612, So SMS Count = 5. Are you aggri?');
                } else if (a + 1 == 765) {
                    alert('Message length >= 765, So SMS Count = 6. Are you aggri?');
                } else if (a + 1 == 918) {
                    alert('Message length >= 480, So SMS Count = 7. Are you aggri?');
                } else if (a + 1 == 1071) {
                    alert('Message length >= 1071, So SMS Count = 8. Are you aggri?');
                } else if (a + 1 == 1224) {
                    alert('Message length >= 1224, So SMS Count = 9. Are you aggri?');
                } else if (a + 1 == 1377) {
                    alert('Message length >= 1377, So SMS Count = 10. Are you aggri?');
                } else if (a + 1 == 1530) {
                    alert('Message length >= 1530, So SMS Count = 11. Are you aggri?');
                }

                return;
            }
            else {

                window.event.returnValue = null;
            }
        }
    </script>

    <script type="text/javascript">
        function AllowOnlyNumeric4() {
            // Get the ASCII value of the key that the user entered
            var key = window.event.keyCode;
            if ((key >= 65 && key <= 90) || (key >= 97 && key <= 122) || (key >= 46 && key <= 57) || key == 46 || key == 13 || key == 32) {
                var a = document.getElementById("<%=txtMultiText.ClientID%>").value.length;

                document.getElementById("<%=txtCharCountMulti.ClientID%>").value = a + 1;
                if (a + 1 == 160) {
                    alert('Message length >= 160, So SMS Count = 2. Are you aggri?');

                } else if (a + 1 == 306) {
                    alert('Message length >= 306, So SMS Count = 3. Are you aggri?');
                } else if (a + 1 == 459) {
                    alert('Message length >= 459, So SMS Count = 4. Are you aggri?');
                } else if (a + 1 == 612) {
                    alert('Message length >= 612, So SMS Count = 5. Are you aggri?');
                } else if (a + 1 == 765) {
                    alert('Message length >= 765, So SMS Count = 6. Are you aggri?');
                } else if (a + 1 == 918) {
                    alert('Message length >= 480, So SMS Count = 7. Are you aggri?');
                } else if (a + 1 == 1071) {
                    alert('Message length >= 1071, So SMS Count = 8. Are you aggri?');
                } else if (a + 1 == 1224) {
                    alert('Message length >= 1224, So SMS Count = 9. Are you aggri?');
                } else if (a + 1 == 1377) {
                    alert('Message length >= 1377, So SMS Count = 10. Are you aggri?');
                } else if (a + 1 == 1530) {
                    alert('Message length >= 1530, So SMS Count = 11. Are you aggri?');
                }

                return;
            }
            else {

                window.event.returnValue = null;
            }
        }
    </script>

    <script type="text/javascript">
        function AllowOnlyNumeric5() {
            // Get the ASCII value of the key that the user entered
            var key = window.event.keyCode;
            if ((key >= 65 && key <= 90) || (key >= 97 && key <= 122) || (key >= 46 && key <= 57) || key == 46 || key == 13 || key == 32) {
                var a = document.getElementById("<%=txtmgsEm.ClientID%>").value.length;

                document.getElementById("<%=txtCountEm.ClientID%>").value = a + 1;
                if (a + 1 == 160) {
                    alert('Message length >= 160, So SMS Count = 2. Are you aggri?');

                } else if (a + 1 == 306) {
                    alert('Message length >= 306, So SMS Count = 3. Are you aggri?');
                } else if (a + 1 == 459) {
                    alert('Message length >= 459, So SMS Count = 4. Are you aggri?');
                } else if (a + 1 == 612) {
                    alert('Message length >= 612, So SMS Count = 5. Are you aggri?');
                } else if (a + 1 == 765) {
                    alert('Message length >= 765, So SMS Count = 6. Are you aggri?');
                } else if (a + 1 == 918) {
                    alert('Message length >= 480, So SMS Count = 7. Are you aggri?');
                } else if (a + 1 == 1071) {
                    alert('Message length >= 1071, So SMS Count = 8. Are you aggri?');
                } else if (a + 1 == 1224) {
                    alert('Message length >= 1224, So SMS Count = 9. Are you aggri?');
                } else if (a + 1 == 1377) {
                    alert('Message length >= 1377, So SMS Count = 10. Are you aggri?');
                } else if (a + 1 == 1530) {
                    alert('Message length >= 1530, So SMS Count = 11. Are you aggri?');
                }

                return;
            }
            else {

                window.event.returnValue = null;
            }
        }
    </script>

    <script type="text/javascript">
        function AllowOnlyNumeric6() {
            // Get the ASCII value of the key that the user entered
            var key = window.event.keyCode;
            if ((key >= 65 && key <= 90) || (key >= 97 && key <= 122) || (key >= 46 && key <= 57) || key == 46 || key == 13 || key == 32) {
                var a = document.getElementById("<%=txtMgsMultiEm.ClientID%>").value.length;

                document.getElementById("<%=txtCountMultiEm.ClientID%>").value = a + 1;
                if (a + 1 == 160) {
                    alert('Message length >= 160, So SMS Count = 2. Are you aggri?');

                } else if (a + 1 == 306) {
                    alert('Message length >= 306, So SMS Count = 3. Are you aggri?');
                } else if (a + 1 == 459) {
                    alert('Message length >= 459, So SMS Count = 4. Are you aggri?');
                } else if (a + 1 == 612) {
                    alert('Message length >= 612, So SMS Count = 5. Are you aggri?');
                } else if (a + 1 == 765) {
                    alert('Message length >= 765, So SMS Count = 6. Are you aggri?');
                } else if (a + 1 == 918) {
                    alert('Message length >= 480, So SMS Count = 7. Are you aggri?');
                } else if (a + 1 == 1071) {
                    alert('Message length >= 1071, So SMS Count = 8. Are you aggri?');
                } else if (a + 1 == 1224) {
                    alert('Message length >= 1224, So SMS Count = 9. Are you aggri?');
                } else if (a + 1 == 1377) {
                    alert('Message length >= 1377, So SMS Count = 10. Are you aggri?');
                } else if (a + 1 == 1530) {
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
    <%--
    <asp:UpdatePanel ID="updtPnlSendSMS" runat="server" UpdateMode="Conditional">
        <ContentTemplate>--%>
    <div style="min-height: 500px; margin-top: 30px">
        <asp:Accordion ID="acdLogin" runat="server" TransitionDuration="800" FramesPerSecond="40"
            SuppressHeaderPostbacks="true" defaultfocus="pnlExistUser" FadeTransitions="true"
            CssClass="Accordion" RequireOpenedPane="false" HeaderCssClass="AccordionHeaderby"
            ContentCssClass="AccordionContent" HeaderSelectedCssClass="AccordionHeader" OnDataBinding="acdLogin_DataBinding">
            <Panes>
                <asp:AccordionPane ID="pnlExistUser" runat="server" Visible="false">
                    <Header>
                        <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />
                        Assign Message
                    </Header>
                    <Content>
                        <div>
                            <span>
                                <div align="center" style="width: 100%">
                                    <table>
                                        <tr>
                                            <td align="center" valign="middle">
                                                <asp:Label ID="Label3" runat="server" Text="MissCall Message" Font-Bold="True" Font-Italic="False"
                                                    Font-Size="Large" ForeColor="#006699"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </span>
                            <div align="center" style="width: 100%">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMessage" runat="server" Text="Current Response Message" CssClass="tdLabel"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" TextMode="MultiLine" Height="100px" Width="200px" ID="txtMessage"
                                                onkeypress="AllowOnlyNumeric3()"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center" style="text-align: right">
                                            &nbsp;<asp:Label runat="server" Text="Character Count" Font-Bold="True" Font-Size="Small"
                                                ID="lblCharcount" CssClass="tdLabel"></asp:Label><asp:TextBox runat="server" Height="25px"
                                                    Width="50px" ID="txtCharCount2"></asp:TextBox>&nbsp;<asp:Label ID="lblCountMessage"
                                                        runat="server" ForeColor="Red" CssClass="lbl"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; width: 204px">
                                            <asp:Label ID="lblgroup" runat="server" CssClass="tdLabel" Text="Select Group"></asp:Label><br />
                                            <asp:Label ID="lbl1" runat="server" CssClass="tdLabel" Text="(Select 0 Group for Common)"></asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:DropDownList ID="ddlGroup" runat="server" CssClass="dropdownlist">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left">
                                            <asp:Label ID="lblprefix" runat="server" Text="Select Prefix:" CssClass="tdLabel"></asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:DropDownList ID="ddlPrefix" runat="server" CssClass="dropdownlist">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Dear</asp:ListItem>
                                                <asp:ListItem Value="2">Shri</asp:ListItem>
                                                <asp:ListItem Value="3">Smt</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="message" runat="server" visible="False" align="center">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMessage1" runat="server" Text="Message Status" CssClass="tdLabel"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlstatus" runat="server" CssClass="dropdownlist">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                                <asp:ListItem>Active</asp:ListItem>
                                                <asp:ListItem>Deactive</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div align="center">
                                <table>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" OnClick="btnSubmit_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCancel" runat="server" CssClass="btn" Text="Cancel" OnClick="btnCancel_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnEmgsingle" runat="server" Text="Emergency Set Message" CssClass="btn"
                                                Visible="false" OnClick="btnEmgsingle_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <asp:Panel ID="panelmiscall" runat="server" Visible="false">
                                <center>
                                    <div style="border: 1px Solid black">
                                        <table>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="Label13" runat="server" Text="Set Emergency Message" Font-Bold="True"
                                                        Font-Italic="False" Font-Size="Large" ForeColor="#006699"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Enter Emergency Message :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtmgsEm" runat="server" TextMode="MultiLine" Height="100px" Width="200px"
                                                        onkeypress="AllowOnlyNumeric5()" MaxLength="160"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Count :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCountEm" runat="server" Width="40px" Enabled="false"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnSubmitEm" runat="server" Text="Submit" OnClick="btnSubmitEm_Click"
                                                        CssClass="btn" />
                                                    <asp:Button ID="btnDeleteEm" runat="server" Text="Delete Emergency Messge" OnClick="btnDeleteEm_Click"
                                                        CssClass="btn" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </center>
                            </asp:Panel>
                            <div class="grid" style="width: 100%">
                                <asp:GridView ID="gvMessageShow" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    CellPadding="5" CssClass="mGrid" PageSize="5" Width="100%" OnRowCommand="gvMessageShow_RowCommand"
                                    OnRowEditing="gvMessageShow_RowEditing" OnPageIndexChanging="gvMessageShow_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField HeaderText="Id" DataField="id">
                                            <HeaderStyle HorizontalAlign="Left" Width="30%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Message" DataField="ResponseMsg">
                                            <HeaderStyle HorizontalAlign="Left" Width="30%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Group" DataField="GroupNo">
                                            <HeaderStyle HorizontalAlign="Left" Width="10%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="MsgCount" DataField="msgcount">
                                            <HeaderStyle HorizontalAlign="Left" Width="10%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Date" DataField="MsgDate">
                                            <HeaderStyle HorizontalAlign="Left" Width="30%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Status" DataField="Msg_Status">
                                            <HeaderStyle HorizontalAlign="Left" Width="30%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton4" runat="server" CommandArgument='<%#Bind("id") %>'
                                                    CommandName="Edit" ImageUrl="~/resources1/images/ico_yes1.gif" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="row" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <PagerStyle CssClass="pager-row" />
                                </asp:GridView>
                                <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
                            </div>
                        </div>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane1" runat="server">
                    <Header>
                        <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />
                        Multi-Miss Call
                    </Header>
                    <Content>
                        <span>
                            <div align="center" style="width: 100%">
                                <table>
                                    <tr>
                                        <td align="center" valign="middle">
                                            <asp:Label ID="Label1" runat="server" Text="Multi-Miss Call Message" Font-Bold="True"
                                                Font-Italic="False" Font-Size="Large" ForeColor="#006699"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </span>
                        <div align="center" style="width: 100%">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="Current Response Message" CssClass="tdLabel"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" TextMode="MultiLine" Height="100px" Width="200px" ID="txtMultiText"
                                            onkeypress="AllowOnlyNumeric4()"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center" style="text-align: right">
                                        &nbsp;<asp:Label runat="server" Text="Character Count" Font-Bold="True" Font-Size="Small"
                                            ID="Label6" CssClass="tdLabel"></asp:Label><asp:TextBox runat="server" Height="25px"
                                                Width="50px" ID="txtCharCountMulti"></asp:TextBox>&nbsp;<asp:Label ID="Label9" runat="server"
                                                    ForeColor="Red" CssClass="lbl"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left; width: 204px">
                                        <asp:Label ID="Label10" runat="server" CssClass="tdLabel" Text="Message No"></asp:Label><br />
                                        <asp:Label ID="Label11" runat="server" CssClass="tdLabel" Text="(Select 0 Group for Common)"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:DropDownList ID="ddlmultiGroup" runat="server" CssClass="dropdownlist">
                                            <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="6">6</asp:ListItem>
                                            <asp:ListItem Value="7">7</asp:ListItem>
                                            <asp:ListItem Value="8">8</asp:ListItem>
                                            <asp:ListItem Value="9">9</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="Label12" runat="server" Text="Message Status" CssClass="tdLabel"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:DropDownList ID="ddlMgsStatus" runat="server" CssClass="dropdownlist">
                                            <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                            <asp:ListItem Value="0">Active</asp:ListItem>
                                            <asp:ListItem Value="1">Deactive</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="Div1" runat="server" visible="False" align="center">
                        </div>
                        <div align="center">
                            <table>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnSubmitMulti" runat="server" Text="Submit" CssClass="btn" OnClick="btnSubmitMulti_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCancelMulti" runat="server" CssClass="btn" Text="Cancel" OnClick="btnCancelMulti_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnEmg" runat="server" Text="Emergency Set Message" CssClass="btn"
                                            Visible="true" OnClick="btnEmg_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:Panel ID="panel1" runat="server" Visible="false">
                            <center>
                                <div style="border: 1px Solid black">
                                    <table>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="Label14" runat="server" Text="Set Emergency Message" Font-Bold="True"
                                                    Font-Italic="False" Font-Size="Large" ForeColor="#006699"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Enter Emergency Message :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMgsMultiEm" runat="server" TextMode="MultiLine" Height="100px"
                                                    Width="200px" onkeypress="AllowOnlyNumeric6()" MaxLength="160"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Count :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCountMultiEm" runat="server" Width="40px" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSubmitMultiEm" runat="server" Text="Submit" OnClick="btnSubmitMultiEm_Click"
                                                    CssClass="btn" />
                                                <asp:Button ID="btnDeleteMultiEm" runat="server" Text="Delete Emergency Messge" OnClick="btnDeleteMultiEm_Click"
                                                    CssClass="btn" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </center>
                        </asp:Panel>
                        <div class="grid" style="width: 100%">
                            <asp:GridView ID="gvItemMulti" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                CellPadding="5" CssClass="mGrid" Width="100%" OnRowCommand="gvItemMulti_RowCommand"
                                OnRowEditing="gvItemMulti_RowEditing">
                                <Columns>
                                    <asp:BoundField HeaderText="Id" DataField="id">
                                        <HeaderStyle HorizontalAlign="Left" Width="30%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Message" DataField="ResponseMsg">
                                        <HeaderStyle HorizontalAlign="Left" Width="30%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Group" DataField="GroupNo">
                                        <HeaderStyle HorizontalAlign="Left" Width="10%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="MsgCount" DataField="msgcount">
                                        <HeaderStyle HorizontalAlign="Left" Width="10%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Date" DataField="MsgDate">
                                        <HeaderStyle HorizontalAlign="Left" Width="30%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Status" DataField="Msg_Status">
                                        <HeaderStyle HorizontalAlign="Left" Width="30%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton4" runat="server" CommandArgument='<%#Bind("id") %>'
                                                CommandName="Edit" ImageUrl="~/resources1/images/ico_yes1.gif" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DeActive">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton5" runat="server" CommandArgument='<%#Bind("id") %>'
                                                CommandName="Deactive" ImageUrl="~/resources1/images/ico_yes1.gif" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="row" HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <PagerStyle CssClass="pager-row" />
                            </asp:GridView>
                            <asp:Label ID="lblIdMulti" runat="server" Visible="False"></asp:Label>
                        </div>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane2" runat="server">
                    <Header>
                        <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />
                        Add Group Members
                    </Header>
                    <Content>
                        <div>
                            <table class="tblAdminSubFull1">
                                <tr class="searchResultHeader">
                                    <td colspan="2" align="left" style="border-bottom-color: Black;">
                                        <asp:Label ID="lblFriRelSearch" runat="server" Text="Add Friends Groupwise" CssClass="lblHeader"></asp:Label>
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 35%">
                                        <asp:Label ID="lblSearchFriRel" runat="server" Text=" Search Friend & Relative (By Registered Mobile No):"
                                            Font-Size="Small" Font-Bold="True" CssClass="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblExtnd" runat="server" Text="+91-" Font-Bold="True" Font-Size="Small"></asp:Label>
                                        <asp:TextBox ID="txtSearchFriRel" runat="server" MaxLength="10" onfocus="ChangeCSS(this, event)"
                                            ToolTip="Enter MobileNo" onblur="ChangeCSS(this, event)" ValidationGroup="vgpSrchFrRl"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="fbeSearchFriRel" runat="server" TargetControlID="txtSearchFriRel"
                                            FilterType="Numbers" Enabled="True">
                                        </asp:FilteredTextBoxExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="vgpSrchFrRl"
                                            Display="None" ControlToValidate="txtSearchFriRel" ErrorMessage="*Please enter mobile no"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="^[0-9]{10,10}$"
                                            ValidationGroup="vgpSrchFrRl" runat="server" ControlToValidate="txtSearchFriRel"
                                            ErrorMessage="Minimum 10 Digits Required." Display="None"></asp:RegularExpressionValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator5"
                                            Enabled="True">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RegularExpressionValidator1"
                                            Enabled="True">
                                        </asp:ValidatorCalloutExtender>
                                        <asp:Button ID="btnSearchFriRel" runat="server" Text="Search" ValidationGroup="vgpSrchFrRl"
                                            AccessKey="S" CssClass="button" OnClick="btnSearchFriRel_Click" />
                                        <asp:GridView ID="gvFriendRelativeSearch" runat="server" AutoGenerateColumns="False"
                                            EmptyDataText="No records matching found" Width="100%" OnRowCommand="gvFriendRelativeSearch_RowCommand">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <table class="tblSubFull">
                                                            <tr>
                                                                <%-- <td style="width: 15%;">
                                                                        <label class="frndSearchLabelHeader">
                                                                        Pic</label>
                                                                    </td>--%>
                                                                <td style="width: 35%;">
                                                                    <label class="frndSearchLabelHeader">
                                                                        Name</label>
                                                                </td>
                                                                <td style="width: 20%;">
                                                                    <label class="frndSearchLabelHeader">
                                                                        City</label>
                                                                </td>
                                                                <td style="width: 15%;">
                                                                    <label class="frndSearchLabelHeader">
                                                                        Group</label>
                                                                </td>
                                                                <td style="width: 50%;">
                                                                    <label>
                                                                    </label>
                                                                </td>
                                                                <td style="width: 50%;">
                                                                    <label>
                                                                    </label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <table border="" style="width: 100%;">
                                                            <tr>
                                                                <%-- <td style="width: 15%;">
                                                                                                <asp:Image ID="frirelSearchProfileImage" runat="server" AlternateText="ProImage"
                                                                                                    Height="70px" ImageUrl='<%#Eval("usrProfilePhoto")%>' Width="70px" />
                                                                                            </td>--%>
                                                                <td style="width: 35%;">
                                                                    <asp:Label ID="lblSearchFriRelName" runat="server" Text='<%#Eval("usrFullName") %>'></asp:Label>
                                                                </td>
                                                                <td style="width: 20%;">
                                                                    <asp:Label ID="lblSearchFriRelCity" runat="server" Text='<%#Eval("usrCity") %>'></asp:Label>
                                                                </td>
                                                                <td style="width: 15%;">
                                                                    <asp:DropDownList ID="cmbGroupType" runat="server" DataTextField="GroupName" DataValueField="GroupId"
                                                                        Width="85px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="width: 20%;">
                                                                    <asp:Button ID="btnAddSearchFriRel" runat="server" CommandArgument='<%#Eval("usrUserId")+","+Eval("usrFullName")%>'
                                                                        CommandName="AddFriRel" CssClass="button" onmouseout="this.style.background='#4190f1'"
                                                                        onmouseover="this.style.background='#1360be'" Text="Add As Friend" Width="90px" />
                                                                </td>
                                                                <td style="width: 20%;">
                                                                    <asp:Button ID="Button2" runat="server" CommandArgument='<%#Eval("usrUserId")+","+Eval("usrFullName")%>'
                                                                        CommandName="AddFriRel" CssClass="button" Text="Cancel" Width="90px" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:Label ID="lblMesg" runat="server" ForeColor="#CC0000" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr style="width: 100%;">
                                    <td style="width: 95px">
                                        <label style="font-size: large; font-style: normal; font-weight: bold;" class="lbl">
                                            *</label>
                                        <asp:Label ID="lblAddFriRel" runat="server" Text="Add Not Registered Friend & Relative:"
                                            Font-Bold="True" Font-Size="Small" CssClass="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkAddFriRel"
                                            runat="server" Text="Add New Friend" Height="20px" Width="100px" CssClass="button"
                                            OnClick="lnkAddFriRel_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table width="100%" class="tblAdminSubFull1">
                                <tr class="searchResultHeader">
                                    <td colspan="2">
                                        <asp:Label ID="lblAddFriendList" runat="server" Font-Bold="True" Text="Upload Friend List"></asp:Label>
                                    </td>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="btnDowmLoad" runat="server" Text="DownLoad Friend List Format" CssClass="button"
                                            OnClick="btnDowmLoad_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 40%">
                                        &nbsp;
                                        <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Size="Small" Text="Upload Friends:"
                                            CssClass="lbl"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="upfile" runat="server">
                                            <ContentTemplate>
                                                <asp:FileUpload ID="CSVUpload" runat="server" />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnUpload" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Label ID="lblResult" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 75%">
                                    </td>
                                    <td colspan="2">
                                        <asp:Button ID="btnUpload" runat="server" CssClass="button" Text="Upload Friends"
                                            OnClick="btnUpload_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane3" runat="server">
                    <Header>
                        <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />
                        View Group Members
                    </Header>
                    <Content>
                        <table class="tblSubFull1">
                            <tr>
                                <td align="center">
                                    <table>
                                        <tr>
                                            <td align="center" style="height: 30px">
                                                <label class="lbl">
                                                    Select Group:
                                                </label>
                                                <asp:DropDownList ID="ddlViewGroup" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="center" style="height: 30px">
                                                <asp:Button ID="btnViewSendGroupSMS" runat="server" CssClass="button" Text="View"
                                                    OnClick="btnViewSendGroupSMS_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lbltotal" runat="server" Text="Total Group Members:" Visible="False"
                                                    ForeColor="Red"></asp:Label>
                                                <asp:Label ID="lblGroupCount" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="height: 30px" colspan="2">
                                                <asp:GridView ID="gvViewGroup" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    CssClass="mGrid" Width="100%" EmptyDataText="No any friends in this group" OnPageIndexChanging="gvViewGroup_PageIndexChanging">
                                                    <Columns>
                                                        <asp:BoundField DataField="usrMobileNo" HeaderText="Mobile Number">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FriendName" HeaderText="Name">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane4" runat="server">
                    <Header>
                        <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />
                        MissCall Report
                    </Header>
                    <Content>
                        <div align="center" style="width: 100%">
                            <table>
                                <tr>
                                    <td colspan="5">
                                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="Large"
                                            ForeColor="#006699" Text="MissCall Report"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:Label ID="lblCalc" runat="server" CssClass="tdLabel" Font-Bold="True" Font-Size="Large"
                                            ForeColor="#CC3300" Text="Total MissCall:" Visible="False"></asp:Label>
                                        &nbsp;<asp:Label ID="lblCalulate" runat="server" CssClass="tdLabel" Font-Bold="True"
                                            ForeColor="#CC3300"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:GridView ID="gvLongCodeshow" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            CellPadding="5" CssClass="mGrid" Width="100%" OnPageIndexChanging="gvLongCodeshow_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField HeaderText="Id" DataField="cid">
                                                    <HeaderStyle HorizontalAlign="Left" Width="10%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="MobileNo" DataField="mobileNumber">
                                                    <HeaderStyle HorizontalAlign="Left" Width="50%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Date & time" DataField="recordDate">
                                                    <HeaderStyle HorizontalAlign="Left" Width="50%"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                                </asp:BoundField>
                                            </Columns>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <PagerStyle CssClass="pager-row" />
                                            <RowStyle CssClass="row" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnGridtoexcel" runat="server" Text="Download To Excel" OnClick="btnGridtoexcel_Click"
                                            CssClass="button" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane5" runat="server">
                    <Header>
                        <img src="../KResource/Images/DownImg.png" width="40px" height="25px" alt="" />
                        Message Report
                    </Header>
                    <Content>
                        <div align="center" style="width: 100%">
                            <table>
                                <tr>
                                    <td colspan="5">
                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="Large"
                                            ForeColor="#006699" Text="Message Report"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" CssClass="tdLabel" Font-Bold="True" Font-Size="Large"
                                            ForeColor="#CC3300" Text="Total Message Delivered to:" Visible="False"></asp:Label>
                                        &nbsp;<asp:Label ID="Label8" runat="server" CssClass="tdLabel" Font-Bold="True" ForeColor="#CC3300"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMessageCount" runat="server" CssClass="tdLabel" Font-Bold="True"
                                            Font-Size="Large" ForeColor="#CC3300" Text="Message Count:" Visible="False"></asp:Label>
                                        &nbsp;<asp:Label ID="lblCount" runat="server" CssClass="tdLabel" Font-Bold="True"
                                            ForeColor="#CC3300"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            CellPadding="5" CssClass="mGrid" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging"
                                            Width="100%">
                                            <Columns>
                                                <asp:BoundField HeaderText="Id" DataField="id">
                                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="MobileNumber" HeaderText="MobileNumber">
                                                    <HeaderStyle HorizontalAlign="Left" Width="50%" />
                                                    <ItemStyle HorizontalAlign="Left" Width="50%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ResponseMsg" HeaderText="ResponseMsg">
                                                    <HeaderStyle HorizontalAlign="Left" Width="30%" />
                                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="date" HeaderText="Date &amp; time">
                                                    <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                </asp:BoundField>
                                            </Columns>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <PagerStyle CssClass="pager-row" />
                                            <RowStyle CssClass="row" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnGridtoexcel1" runat="server" Text="Download To Excel" OnClick="btnGridtoexcel1_Click"
                                            CssClass="button" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </Content>
                </asp:AccordionPane>
            </Panes>
        </asp:Accordion>
    </div>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
