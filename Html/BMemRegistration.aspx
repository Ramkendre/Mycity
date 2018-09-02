<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="BMemRegistration.aspx.cs" Inherits="Html_BMemRegistration" Title="Untitled Page" %>

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
        <div class="InnerDiv">
            <div align="center"  class="style1" style="background-color: #87CEFA;">
            <img src="../KResource/Images/GroupsImg.png" width="40px" height="30px" />
                 <span id="Span1" class="spanTitle" runat="server">Member Registration</span>
            </div>
            <hr />
            <table class="tblSubFull2">
              <%--  <tr>
                    <td align="center" colspan="2" class="style1">
                        <span class="spanTitle" runat="server">Member Registration</span>
                    </td>
                </tr>
                --%>
                <tr>
                    <td>
                        &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width:40%">
                        SSG Name
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlGID" runat="server" Width="165px" Height="25px">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        First Name
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtFName" runat="server" onkeyPress="return isCharKey(this,event)"
                            Height="20px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtFName" runat="server" ControlToValidate="txtFName"
                            ValidationGroup="b" ErrorMessage="Please Enter Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Last Name
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtLName" runat="server" onkeyPress="return isCharKey(this,event)"
                            Height="20px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtLName" runat="server" ControlToValidate="txtLName"
                            ValidationGroup="b" ErrorMessage="Please Enter Name "></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        MobileNo
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtMobileNo" runat="server" Height="20px" 
                            ontextchanged="txtMobileNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMobileNo"
                            ValidationGroup="b" ErrorMessage="Please Enter Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Post                     </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlPost" runat="server" Width="165px" Height="25px">
                            <asp:ListItem>--Select--</asp:ListItem>
                            <asp:ListItem>Chairman</asp:ListItem>
                            <asp:ListItem>Vice Chairman</asp:ListItem>
                            <asp:ListItem>Secretary</asp:ListItem>
                            <asp:ListItem>Member</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Date Of Joining
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtdate" runat="server" Height="20px"></asp:TextBox>
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
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblOpBal" runat="server" Font-Underline="true" BackColor="#AFEEEE">Opening Balance</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Subscription
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtSub" runat="server" Height="20px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Deposit
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDeposit" runat="server" Height="20px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Loan
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtLoan" runat="server" Height="20px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="left">
                        <asp:Button ID="btnSumbit" runat="server" Text="Submit" OnClick="btnSumbit_Click" />
                    </td>
                </tr>
            </table>
            <hr />
            <table class="tblSubFull2">
                <tr>
                    <td>
                        <div style="overflow: scroll; height: 200px; border: 1px solid #dddddd;">
                            <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" DataKeyNames="MID"
                                OnRowDataBound="gvItem_RowDataBound" CssClass="gridview" OnRowCommand="gvItem_RowCommand"
                                OnRowDeleting="gvItem_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Event No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="MID" HeaderText="MID" Visible="false" />
                                    <asp:BoundField DataField="GID" HeaderText="GID" />
                                    <asp:BoundField DataField="FName" HeaderText="FName" />
                                    <asp:BoundField DataField="LName" HeaderText="LName" />
                                    <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                                    <asp:BoundField DataField="Post" HeaderText="Post" />
                                    <asp:BoundField DataField="DOJ" HeaderText="DOJ" />
                                    <asp:BoundField DataField="Subscription" HeaderText="Subscription" />
                                    <asp:BoundField DataField="Deposite" HeaderText="Deposite" />
                                    <asp:BoundField DataField="Loan" HeaderText="Loan" />
                                    <asp:TemplateField HeaderText="Modify">
                                        <ItemTemplate>
                                            <asp:Button ID="btnModify" runat="server" Text="Modify" CommandName="Modify" CommandArgument='<%#Bind("MID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Bind("MID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
