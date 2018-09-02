<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="BSSGRulesSetting.aspx.cs" Inherits="Html_BSSGRulesSetting" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="asp" %>
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

            if ((key == null) || (key == 0) || (key == 8) ||
            (key == 9) || (key == 13) || (key == 27))
                return true;

            else if ((("0123456789.").indexOf(keychar) > -1))
                return true;

            else
                return false;
        }

    </script>

    <script type="text/javascript" language="javascript">
        function isCharKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if ((charCode < 64 && charCode > 0) || (charCode < 96 && charCode > 91) || (charCode < 127 && charCode > 123))
                return false;

            return true;
        }
    </script>

    <div class="MainDiv">
        <div class="innerdiv">
            <div align="center" class="style1" style="background-color: #87CEFA;">
                <%--<img src="../KResource/Images/Loan.jpg" width="40px" height="30px" />--%>
                <span id="Span2" class="spanTitle" runat="server">SSGRules Setting</span>
            </div>
            <hr />
            <table class="tblSubFull2">
                <%-- <tr>
                    <td align="center" colspan="2" class="style1">
                        <span id="Span1" class="spanTitle" runat="server">SSGRules Setting</span>
                    </td>
                </tr>--%>
                <tr>
                    <td align="right">
                        Membership Fees
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtMemFees" runat="server" CssClass="ccstxt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtFName" runat="server" ControlToValidate="txtMemFees"
                            ValidationGroup="b" ErrorMessage="Please Enter Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Due Date of Subscription Payment
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtdate" runat="server" CssClass="ccstxt"></asp:TextBox>
                        <asp:Image ID="Image2" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                            runat="server" />
                        <asp:CalendarExtender ID="CEBD" PopupButtonID="Image2" runat="server" Format="yyyy-MM-dd"
                            TargetControlID="txtdate">
                        </asp:CalendarExtender>
                        <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="txtdate"
                            ValidationGroup="b" ErrorMessage="Please Enter Date"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Additional Penalty Amount
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtPAmount" runat="server" CssClass="ccstxt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMemFees"
                            ValidationGroup="b" ErrorMessage="Please Enter Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Penalty Amount
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rbtnPAount" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Active</asp:ListItem>
                            <asp:ListItem>Dective</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Loan Limit
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtLLimit" runat="server" CssClass="ccstxt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLLimit"
                            ValidationGroup="b" ErrorMessage="Please Enter Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Interest On Loan/Month
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtIOLoan" runat="server" CssClass="ccstxt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtIOLoan"
                            ValidationGroup="b" ErrorMessage="Please Enter Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Intrest On Deposit/Year
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtIODeposit" runat="server" CssClass="ccstxt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtIODeposit"
                            ValidationGroup="b" ErrorMessage="Please Enter Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Due Days Within Which Intrest is to be Paid
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDueDays" runat="server" CssClass="ccstxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Penalty Interest Rate to be Charged
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtPenaltyIntrest" runat="server" CssClass="ccstxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        SSG Bank A/C N.
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtBAcNo" runat="server" CssClass="ccstxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Bank Name
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtBankName" runat="server" CssClass="ccstxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Type Of Expenditure
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlTExp" runat="server" CssClass="ddlcss">
                            <asp:ListItem>aa</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Financial Year
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtdateFr" runat="server" CssClass="ccstxt"></asp:TextBox>
                        <asp:Image ID="Image1" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                            runat="server" />
                        <asp:CalendarExtender ID="CalendarExtender1" PopupButtonID="Image2" runat="server"
                            Format="yyyy-MM-dd" TargetControlID="txtdateFr">
                        </asp:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtdateFr"
                            ValidationGroup="b" ErrorMessage="Please Enter Date"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtdateM" runat="server" CssClass="ccstxt"></asp:TextBox>
                        <asp:Image ID="Image3" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                            runat="server" />
                        <asp:CalendarExtender ID="CalendarExtender2" PopupButtonID="Image2" runat="server"
                            Format="yyyy-MM-dd" TargetControlID="txtdateM">
                        </asp:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtdateM"
                            ValidationGroup="b" ErrorMessage="Please Enter Date"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        <asp:Button ID="btnSumbit" runat="server" Text="Submit" OnClick="btnSumbit_Click" />
                    </td>
                </tr>
            </table>
            <hr />
            <table class="tblSubFull2">
                <tr>
                    <td>
                        <div style="overflow-x: scroll; height: 200px; border: 1px solid #dddddd; width:72%;">
                            <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" DataKeyNames="ID"
                                CssClass="gridview" OnRowCommand="gvItem_RowCommand" OnRowDeleting="gvItem_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Event No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                    <asp:BoundField DataField="MemberShipFee" HeaderText="MemberShipFee" />
                                    <asp:BoundField DataField="DueDateSP" HeaderText="DueDateSP" />
                                    <asp:BoundField DataField="PAmount" HeaderText="PAmount" DataFormatString="{0:MM/dd/yyyy}" />
                                    <asp:BoundField DataField="AdditionalAmt" HeaderText="AdditionalAmt" />
                                    <asp:BoundField DataField="LoanLimit" HeaderText="LoanLimit" />
                                    <asp:BoundField DataField="IntOnLoan" HeaderText="IntOnLoan" />
                                    <asp:BoundField DataField="IntOnDeposit" HeaderText="IntOnDeposit" />
                                    <asp:BoundField DataField="DueDays" HeaderText="DueDays" />
                                    <asp:BoundField DataField="PIntRate" HeaderText="PIntRate" />
                                    <asp:BoundField DataField="BankANo" HeaderText="BankANo" />
                                    <asp:BoundField DataField="BankName" HeaderText="BankName" />
                                    <asp:BoundField DataField="TypeOfExp" HeaderText="TypeOfExp" />
                                    <asp:BoundField DataField="FYrOfExpYrFr" HeaderText="FYrOfExpYrFr" />
                                    <asp:BoundField DataField="FYrOfExpYrFrM" HeaderText="FYrOfExpYrFrM" />
                                    <asp:TemplateField HeaderText="Modify">
                                        <ItemTemplate>
                                            <asp:Button ID="btnModify" runat="server" Text="Modify" CommandName="Modify" CommandArgument='<%#Bind("ID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Bind("ID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Modify">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="IbtnModify" CommandArgument='<%#Bind("BID") %>' runat="server"
                                                ImageUrl="~/resources1/images/ico_yes1.gif" CommandName="Modify" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <asp:Label ID="lblId" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
