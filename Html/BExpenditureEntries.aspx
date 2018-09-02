<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="BExpenditureEntries.aspx.cs" Inherits="Html_BExpenditureEntries" Title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

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
            <%--<img src="../KResource/Images/Loan.jpg" width="40px" height="30px" />--%>
                 <span id="Span2" class="spanTitle" runat="server">Expenditure Entries</span>
            </div>
            <hr />
            <table class="tblSubFull2">
               <%--<tr>
                    <td align="center" colspan="2" class="style1">
                        <span id="Span1" class="spanTitle" runat="server">Expenditure Entries</span>
                    </td>
                </tr>--%>
                <tr>
                    <td align="right">
                        Date
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
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Voucher No.
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtVoucherNo" runat="server" CssClass="ccstxt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVoucherNo"
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
                        Type Of Expenditure
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlTOExp" runat="server">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem>Office</asp:ListItem>
                        <asp:ListItem>Travelling</asp:ListItem>
                        <asp:ListItem>Stationary</asp:ListItem>
                        <asp:ListItem>Member Expenditure</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                        
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
                        Amount
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtAmount" runat="server" CssClass="ccstxt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAmount"
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
                        Description
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="ccstxt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDescription"
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
                        Mode
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rbtnMode" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>By Cash</asp:ListItem>
                            <asp:ListItem>By Cheque</asp:ListItem>
                        </asp:RadioButtonList>
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
                    <td align="left">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
                            onclick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>
            <hr />
            <table class="tblSubFull2">
                        <tr>
                            <td>
                                <div style="overflow: scroll; height: 200px; border: 1px solid #dddddd;">
                                    <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" 
                                        DataKeyNames="ID" onrowdatabound="gvItem_RowDataBound"
                                        CssClass="gridview" onrowcommand="gvItem_RowCommand" 
                                        onrowdeleting="gvItem_RowDeleting" >
                                        <Columns>
                                            <asp:TemplateField HeaderText="Event No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                           <asp:BoundField DataField="Date" HeaderText="Date" />
                                           <asp:BoundField DataField="VoucharNo" HeaderText="VoucharNo" />
                                           <asp:BoundField DataField="TypeOfExp" HeaderText="TypeOfExp" />
                                           <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                           <asp:BoundField DataField="Description" HeaderText="Description" />
                                           <asp:BoundField DataField="Mode" HeaderText="Mode" />
                                           
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
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
    
</asp:Content>
