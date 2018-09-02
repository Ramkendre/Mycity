<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="BIssueLoan.aspx.cs" Inherits="Html_BIssueLoan" Title="Untitled Page" %>

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
        <div align="center"  class="style1" style="background-color: #87CEFA;">
            <img src="../KResource/Images/Loan.jpg" width="40px" height="30px" />
                 <span id="Span2" class="spanTitle" runat="server">Issue Loan</span>
            </div>
            <hr />
            <table class="tblSubFull2">
           <%-- <tr>
                    <td align="center" colspan="2" class="style1">
                        <span id="Span1" class="spanTitle" runat="server">Issue Loan</span>
                    </td>
                </tr>--%>
                <tr>
                    <td align="right">
                        Select Member
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlSMember" runat="server" Width="165px" Height="25px">
                        <asp:ListItem>aaa</asp:ListItem>
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
                        <asp:Label ID="lblOpBal" runat="server" Font-Underline="true" BackColor="#AFEEEE">Previous Balance</asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        Loan Amount
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtLAmount" runat="server"
                            Height="20px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLAmount"
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
                        Date Of Issue
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
                        Monthly Instalment
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtMInst" runat="server"
                            Height="20px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMInst"
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
                        Due Date 
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDueDate" runat="server" Height="20px"></asp:TextBox>
                        <asp:Image ID="Image1" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                            runat="server" />
                        <asp:CalendarExtender ID="CalendarExtender1" PopupButtonID="Image2" runat="server" Format="yyyy-MM-dd"
                            TargetControlID="txtdate">
                        </asp:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDueDate"
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
                    <td>
                    </td>
                </tr><tr>
                    <td>
                    </td>
                </tr>
                 <tr>
                <td>
                </td>
                <td align="left"><asp:Button ID="btnSumbit" runat="server" Text="Submit" 
                        onclick="btnSumbit_Click" /></td>               
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr><tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
            </table>
            <hr />
            <table class="tblSubFull2">
                        <tr>
                            <td>
                                <div style="overflow: scroll; height: 200px; border: 1px solid #dddddd;">
                                    <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" DataKeyNames="ID"
                                        CssClass="gridview" onrowcommand="gvItem_RowCommand" 
                                        onrowdeleting="gvItem_RowDeleting" >
                                        <Columns>
                                            <asp:TemplateField HeaderText="Event No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                           <asp:BoundField DataField="FName" HeaderText="First Name" />
                                           
                                           <asp:BoundField DataField="LoanAmt" HeaderText="LoanAmt" />
                                           <asp:BoundField DataField="DateOfIssue" HeaderText="DateOfIssue" />
                                           <asp:BoundField DataField="MInstalment" HeaderText="MInstalment" />
                                           <asp:BoundField DataField="DueDate" HeaderText="DueDate" />
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
