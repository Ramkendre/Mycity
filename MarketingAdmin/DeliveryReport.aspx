<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="DeliveryReport.aspx.cs" Inherits="SendMsg" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--    <script language="JavaScript" type="text/javascript">
        //Code added by me starts
        //        window.onload = function() {
        //            chkbox();
        //            hideMob();
        //            var Dat = new Date();
        //            var today;
        //            today = (Dat.getMonth() + 1) + "/" + Dat.getDate() + "/" + Dat.getFullYear();
        //            document.getElementById("txtDate").value = today;
        //        }

        function hideMob() {
            if (document.getElementById("chkMobile").checked == true) {
                document.getElementById("DataRow3").style.display = "block";
            }
            else {
                document.getElementById("DataRow3").style.display = "none";
            }
        }
        function chkbox() {
            if (document.getElementById("ctl00_ContentPlaceHolder1_chkdate").checked == true) {
                document.getElementById("DateRow1").style.display = "block";
                document.getElementById("DateRow2").style.display = "block";
                var currmonth = now.getMonth() + 1
                var currday = now.getDate()
                var curryear = now.getFullYear()
                cal1.addDisabledDates(currmonth + "/" + currday + "/" + curryear, null);
                cal1.setTodayText("")
            }
            else {
                document.getElementById("DateRow1").style.display = "none";
                document.getElementById("DateRow2").style.display = "none";
            }
        }
    </script>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%" border="1">
                <tr>
                    <td align="center">
                        <div style="width: 100%">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="tables">
                                <tr>
                                    <td class="error">
                                        <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 20px;">
                                        <table style="width: 100%;" class="tables" cellspacing="7px">
                                            <tr>
                                                <td colspan="4" style="text-align: center">
                                                    <h3>
                                                        <asp:Label ID="lblHeader" runat="server" Text="Delivery Report"></asp:Label>
                                                    </h3>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="text-align: left">
                                                    <asp:Label ID="lblError" Visible="false" runat="server" CssClass="error" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <label for="Date" class="fontcss">
                                                        <b>Date</b></label>
                                                    <asp:TextBox id="txtDate" disabled="disabled" runat="server" class="txtcss" />
                                                </td>
                                                <td colspan="2">
                                                    <%--  <input id="ctl00_ContentPlaceHolder1_chkdate" type="checkbox" name="ctl00$ContentPlaceHolder1$chkdate"
                                                        onclick="chkbox();" class="fontcss" />--%>
                                                    <asp:CheckBox ID="chkdate" runat="server" CssClass="fontcss" OnCheckedChanged="chkdate_CheckedChanged"
                                                        AutoPostBack="True" />
                                                    <label for="chkdate" style="margin-right: 35px;" class="fontcss">
                                                        <b>Select Date</b></label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2">
                                                    <span id="DateRow1" runat="server">
                                                        <asp:Label ID="lblFormDate" runat="server" CssClass="fontcss" Text="Form Date" />
                                                        &nbsp;
                                                        <asp:TextBox ID="txt_FormDate" runat="server" CssClass="txtcss" />
                                                        <asp:CalendarExtender ID="txt_Formdate_CalendarExtender" runat="server" Enabled="True"
                                                            PopupButtonID="image1" TargetControlID="txt_FormDate">
                                                        </asp:CalendarExtender>
                                                        <asp:Image ID="image1" runat="server" ImageUrl="~/resources1/images/calendar_icon.gif" />
                                                    </span>
                                                </td>
                                                <td align="left" colspan="2">
                                                    <span id="DateRow2" runat="server">
                                                        <asp:Label ID="lblToDate" runat="server" class="fontcss" Text="To Date" />
                                                        &nbsp;
                                                        <asp:TextBox ID="txt_ToDate" runat="server" CssClass="txtcss" type="text" />
                                                        <asp:CalendarExtender ID="txt_Todate_CalendarExtender" runat="server" Enabled="True"
                                                            PopupButtonID="image2" TargetControlID="txt_ToDate">
                                                        </asp:CalendarExtender>
                                                        <asp:Image ID="image2" runat="server" ImageUrl="~/resources1/images/calendar_icon.gif" />
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label class="fontcss" for="Sender Used">
                                                        <b>Sender Used</b></label><br />
                                                    <asp:DropDownList ID="ddl_Sender" runat="server" CssClass="ddlcsswidth">
                                                        <asp:ListItem Value="0">ALL</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td colspan="2">
                                                    <label class="fontcss" for="Status">
                                                        <b>Status</b></label><br />
                                                    <asp:DropDownList ID="ddl_Status" runat="server" CssClass="ddlcsswidth">
                                                        <asp:ListItem Value="1">ALL</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 200px">
                                                    <span id="DataRow3" runat="server">
                                                        <label class="fontcss" for="Mobile Number">
                                                            <b>Mobile Number</b></label>
                                                        <asp:TextBox ID="txt_MobileNo" runat="server" CssClass="txtcss"></asp:TextBox>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td />
                                                <td colspan="2">
                                                    <asp:CheckBox ID="chkMobile" runat="server" CssClass="fontcss" OnCheckedChanged="chkMobile_CheckedChanged"
                                                        AutoPostBack="True" />
                                                    <%-- <input id="chkMobile" class="fontcss" name="SearchByMobile" onclick="hideMob();"
                                                        type="checkbox" />--%>
                                                    <label class="fontcss" for="Search By Mobile" style="margin-right: 35px;">
                                                        <b>Search By Mobile</b></label>
                                                    <%--<asp:LinkButton ID="linkhideMob" Text="Show Mobile Number" runat="server" class="fontcss"></asp:LinkButton>--%>
                                                </td>
                                                <td />
                                                <asp:Button ID="btnGet" runat="server" OnClick="btnGet_Click" Text="Get" />
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="left">
                                                    <b>
                                                        <asp:Label ID="lblMsgSent" CssClass="fontcss" runat="server" Style="margin-right: 35px;"
                                                            Text="Total Message Sent:">
                                                        </asp:Label>
                                                    </b>
                                                </td>
                                                <td colspan="2" align="left">
                                                    <b>
                                                        <asp:Label ID="lblTotalAmt" runat="server" Text="Total Amount:" CssClass="fontcss"></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:GridView ID="gridDelivery" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                                        CssClass="mGrid" PagerStyle-CssClass="pgr" PageSize="20" Width="700px"
                                                        OnPageIndexChanging="gridDelivery_PageIndexChanging">
                                                        <RowStyle BorderStyle="None" />
                                                        <Columns>
                                                            <asp:BoundField DataField="msgId" HeaderText="Id" />
                                                            <asp:BoundField DataField="mobileNo" HeaderText="Mobile Number" />
                                                            <asp:BoundField DataField="status" HeaderText="Status" />
                                                            <asp:BoundField DataField="recievedDate" HeaderText="Recieved Date Time" />
                                                            <asp:BoundField DataField="callRate" HeaderText="Call Rate" />
                                                            <asp:BoundField DataField="message" HeaderText="Message" />
                                                            <asp:BoundField DataField="SendDate" HeaderText="Send Date Time" />
                                                            <%--<asp:BoundField DataField="" HeaderText="Sender Code" />--%>
                                                            <%--<asp:BoundField DataField="" HeaderText="" />--%>
                                                        </Columns>
                                                        <FooterStyle Height="10px" />
                                                        <PagerStyle CssClass="pgr" />
                                                        <HeaderStyle Height="30px" />
                                                        <AlternatingRowStyle CssClass="alt" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <caption>
                                                <br />
                                            </caption>
                                </tr>
                            </table>
                    </td>
                </tr>
            </table>
            </div> </td> </tr> </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
