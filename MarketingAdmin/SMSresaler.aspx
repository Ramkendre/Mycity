<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="SMSresaler.aspx.cs" Inherits="MarketingAdmin_SMSresaler" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
        function validateSignIn() {
            if (document.getElementById('<%=txtname.ClientID%>').value == "") {
                alert("Please enter Customer Name");
                return false;
            }
            else if (document.getElementById('<%=txtmobileno.ClientID%>').value == "") {
                alert("Please enter Mobile No.");
                return false;
            }
            else if (document.getElementById('<%=txtmobileno.ClientID%>').value.length < 10) {
                alert("Mobile No. Length Should be 10 Numbers");
                return false;
            }
            else if (document.getElementById('<%=txtPromotional.ClientID%>').value == "") {
                alert("Plz enter Promotional amount if no atleast enter 0");
                return false;
            }
            else if (document.getElementById('<%=txttransaction.ClientID%>').value == "") {
                alert("Plz enter Teansactional amount if no atleast enter 0");
                return false;
            }
            else if (document.getElementById('<%=txtvalidfrom.ClientID%>').value == "") {
                alert("Please enter Valid From");
                return false;
            }
            else if (document.getElementById('<%=txtvalidfrom.ClientID%>').value.length < 10) {
                alert("Please enter Valid from eg: 08/10/2012");
                return false;
            }
            else if (document.getElementById('<%=txtvalidupto.ClientID%>').value == "") {
                alert("Please enter Valid Upto");
                return false;
            }
            else if (document.getElementById('<%=txtvalidupto.ClientID%>').value.length < 10) {
                alert("Please enter Valid from eg: 08/10/2012");
                return false;
            }
            else {

            }
        }
    </script>

    <script type="text/javascript">
        function iszerotonine(keyCode) {


            return ((keyCode >= 96 && keyCode <= 105) || keyCode == 8 || keyCode == 9)



        }
        //        function isatoz(keycode)
        //        {
        //        return (keycode>=z)

        function ValidateAlpha() {
            var keyCode = window.event.keyCode;
            if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32) {
                window.event.returnValue = false;
                //alert("Enter only letters");
            }
        }
        
        
    </script>

    <script type="text/javascript" language="javascript">
   
        <!--
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



        // numbers without prcision..

        function numbersonlywithoutdecimal(myfield, e, dec) {
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

            // numbers
            else if ((("0123456789").indexOf(keychar) > -1))
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


        function DateCheck(myfield, e, dec) {
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

            // numbers
            else if ((("0123456789/").indexOf(keychar) > -1))
                return true;


            else
                return false;
        }
        //-->
         //-->
            
    </script>

    <table cellpadding="0" cellspacing="0" width="100%" border="1">
        <tr>
            <td align="center">
                <div style="width: 70%">
                    <table cellpadding="0" cellspacing="0" border="0" class="tables" style="width: 98%;
                        height: 332px">
                        <tr>
                            <td style="height: 20px;">
                                <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px;">
                                <table style="width: 97%; height: 290px;" class="tblAdminSubFull1" cellspacing="0px">
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Label ID="lblHeader" runat="server" Text="Transfer Balance" Font-Bold="True"
                                                Font-Size="X-Large"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel" style="width: 137px">
                                            <asp:Label ID="lblmobileno" runat="server" Text=" Mobile No."></asp:Label>
                                        </td>
                                        <td class="tdText" style="text-align: left; width: 200px;">
                                            <%--onkeydown="return iszerotonine(event.keyCode);"--%>
                                            <asp:TextBox ID="txtmobileno" runat="server" onpaste="return true;" MaxLength="10"
                                                onkeypress="return numbersonly(this,event)"></asp:TextBox><br />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtmobileno"
                                                ErrorMessage="Enter Proper 10 Digit mobile No." ValidationExpression="^\d{10,}$"
                                                ValidationGroup="b"></asp:RegularExpressionValidator>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                                                CssClass="button" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel" style="width: 137px">
                                            <asp:Label ID="lblname" runat="server" Text="Name"></asp:Label>
                                        </td>
                                        <td class="tdText" style="width: 134px">
                                            <asp:TextBox ID="txtname" runat="server" Enabled="false"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel" style="width: 137px">
                                            <asp:Label ID="lbltransaction" runat="server" Text="Transactional Amount"></asp:Label>
                                        </td>
                                        <td class="tdText" style="width: 134px">
                                            <asp:TextBox ID="txttransaction" runat="server" Enabled="false" onpaste="return true;"
                                                onkeypress="return numbersonly(this,event)"></asp:TextBox><br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel" style="width: 137px">
                                            <asp:Label ID="lblPromotional" runat="server" Text="Promotional Amount"></asp:Label>
                                        </td>
                                        <td class="tdText" style="width: 134px">
                                            <asp:TextBox ID="txtPromotional" runat="server" Enabled="false" onpaste="return true;"
                                                onkeypress="return numbersonly(this,event)"></asp:TextBox><br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel" style="width: 137px">
                                            <asp:Label ID="lblvalidfrom" runat="server" Text="Valid From"></asp:Label>
                                        </td>
                                        <td class="tdText" style="width: 134px">
                                            <asp:TextBox ID="txtvalidfrom" runat="server" Enabled="false" MaxLength="10"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtvalidfrom"
                                                Format="dd/MM/yyyy">
                                            </asp:CalendarExtender>
                                        </td>
                                        <td>
                                            (DD/MM/YYYY)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel" style="width: 137px">
                                            <asp:Label ID="lblvalidupto" runat="server" Text="Valid Upto"></asp:Label>
                                        </td>
                                        <td class="tdText" style="width: 134px">
                                            <asp:TextBox ID="txtvalidupto" runat="server" Enabled="false" MaxLength="10"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtvalidupto"
                                                Format="dd/MM/yyyy">
                                            </asp:CalendarExtender>
                                        </td>
                                        <td>
                                            (DD/MM/YYYY)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel" style="width: 137px">
                                        </td>
                                        <td class="tdText">
                                            <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click"
                                                ValidationGroup="b" Enabled="false" OnClientClick=" return validateSignIn()"
                                                CssClass="button" />&nbsp;
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel_Click" />&nbsp;
                                            <asp:Button ID="Button1" runat="server" Text="Back" CssClass="button" OnClick="Button1_Click" />
                                        </td>
                                        <td class="tdText" style="width: 134px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:GridView ID="gvBalance" runat="server" Width="100%" CssClass="mGrid" CellPadding="5"
                                    CellSpacing="0" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No Balance Transfer"
                                    OnPageIndexChanging="gvBalance_PageIndexChanging" PageSize="5">
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="Id">
                                            <HeaderStyle HorizontalAlign="left" Width="10%" />
                                            <ItemStyle HorizontalAlign="left" Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FromMobileno" HeaderText="Transfer From">
                                            <HeaderStyle HorizontalAlign="left" Width="30%" />
                                            <ItemStyle HorizontalAlign="left" Width="30%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="mobileno" HeaderText="Transfer To">
                                            <HeaderStyle HorizontalAlign="left" Width="30%" />
                                            <ItemStyle HorizontalAlign="left" Width="30%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="transferdate" HeaderText="Date of transfer">
                                            <HeaderStyle HorizontalAlign="left" Width="30%" />
                                            <ItemStyle HorizontalAlign="left" Width="30%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="transbal" HeaderText="Transactional Balance">
                                            <HeaderStyle HorizontalAlign="left" Width="30%" />
                                            <ItemStyle HorizontalAlign="left" Width="30%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="prombal" HeaderText="Promotional Balance">
                                            <HeaderStyle HorizontalAlign="left" Width="30%" />
                                            <ItemStyle HorizontalAlign="left" Width="30%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="validfrom" HeaderText="Valid From">
                                            <HeaderStyle HorizontalAlign="left" Width="30%" />
                                            <ItemStyle HorizontalAlign="left" Width="30%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="validupto" HeaderText="Valid To">
                                            <HeaderStyle HorizontalAlign="left" Width="30%" />
                                            <ItemStyle HorizontalAlign="left" Width="30%" />
                                        </asp:BoundField>
                                    </Columns>
                                    <RowStyle CssClass="row" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <PagerStyle CssClass="pager-row" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
