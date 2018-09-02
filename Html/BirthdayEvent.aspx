<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="BirthdayEvent.aspx.cs" Inherits="html_BirthdayEvent" Title="Untitled Page"
    EnableEventValidation="false" %>
    


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

    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="MainDiv">
                <div class="InnerDiv">
                    <table class="tblSubFull2">
                        <tr style="background-color: #C3FEFE;">
                            <td align="center" colspan="2">
                                <img src="../KResource/Images/Cake-icon.png" width="40px" height="30px" />
                                <span class="spanTitle">BirthDay</span>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp; &nbsp;&nbsp;
                            </td>
                        </tr>
                        <%-- <tr>
                            <td align="center" colspan="3" class="style1">
                                <center>
                                    <img src="../KResource/Images/Cake-icon.png" width="40px" height="30px" />
                                    <span class="spanTitle">BirthDay Event</span>
                                </center>
                                <br />
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="right"  style="width:40%">
                                Name Of Person
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNameOfPerson" runat="server" onkeyPress="return isCharKey(this,event)"
                                    Height="20px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtName" runat="server" ControlToValidate="txtNameOfPerson"
                                    ValidationGroup="b" ErrorMessage="Please Enter Name Of Person"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Mobile No
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMobileNo" runat="server" Height="20px" onKeyPress="return numbersonly(this,event)"
                                    MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtMobileNo" runat="server" ControlToValidate="txtMobileNo"
                                    ValidationGroup="b" ErrorMessage="Please Enter Mobile No"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                BirthDate
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtBirthdate" runat="server" Height="20px"></asp:TextBox>
                                <asp:Image ID="Image2" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                                    runat="server" />
                                <asp:CalendarExtender ID="CEBD" PopupButtonID="Image2" runat="server" Format="yyyy-MM-dd"
                                    TargetControlID="txtBirthdate">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvBirthDate" runat="server" ControlToValidate="txtBirthdate"
                                    ValidationGroup="b" ErrorMessage="Please Enter BirthDate"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Gender
                            </td>
                            <td align="left">
                                <asp:RadioButtonList ID="rbtnGender" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="rbtnGender"
                                    ValidationGroup="b" ErrorMessage="Please Select Gender"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <%--<tr><td></td></tr>--%>
                        <tr>
                            <td align="right">
                                Send Message
                            </td>
                            <td align="left">
                                <asp:RadioButtonList ID="rbtnSMsg" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:RadioButtonList>
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
                                <asp:TextBox ID="txtDescp" runat="server" TextMode="MultiLine" Height="30px" Width="157px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Remainder Date
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtRemDate" runat="server" Height="20px"></asp:TextBox>
                                <asp:Image ID="Image1" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                                    runat="server" />
                                <asp:CalendarExtender ID="CBRD" PopupButtonID="Image1" runat="server" Format="yyyy-MM-dd"
                                    TargetControlID="txtRemDate">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Time
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtTime" runat="server" Height="20px"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MEEE" TargetControlID="txtTime" Mask="99:99:99" runat="server"
                                    MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                    AcceptAMPM="true" MaskType="Time">
                                </asp:MaskedEditExtender>
                                <em style="font-style: italic; color: rgb(102, 102, 102); font-family: Tahoma, Arial, sans-serif;
                                    font-size: 12px; font-variant: normal; font-weight: normal; letter-spacing: normal;
                                    line-height: 18px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none;
                                    white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto;
                                    -webkit-text-stroke-width: 0px;"><span style="font-size: 8pt;">Tip: Type &#39;A&#39; 
                                or &#39;P&#39; to switch AM/PM</span></em>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                            </td>
                            <td align="left">
                                <asp:Button ID="btnCtreate" runat="server" Text="Create" OnClick="btnCtreate_Click"
                                    ValidationGroup="b" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                                <asp:Button ID="btnExportToExcel" runat="server" Font-Bold="true" ForeColor="Maroon"
                                    Text="Export to excel" Width="129px" OnClick="btnExportToExcel_Click" />
                                <asp:LinkButton ID="lnkexcel" runat="server" OnClick="lnkexcel_Click">Show Child 
                                Record</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp; &nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                    <table class="tblSubFull2">
                        <tr>
                            <td>
                          <%--  overflow: scroll;--%>
                                <div style=" height: 200px; border: 1px solid #dddddd;">
                                    <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" DataKeyNames="BID"
                                        CssClass="gridview" OnRowCommand="gvItem_RowCommand" 
                                        onrowdeleting="gvItem_RowDeleting" AllowPaging="true" PageSize="8" 
                                        >
                                        <Columns>
                                            <asp:TemplateField HeaderText="Event No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="BID" HeaderText="BID" Visible="false" />
                                            <asp:BoundField DataField="NameOfPerson" HeaderText="Name Of Person" />
                                            <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                                            <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" DataFormatString="{0:MM/dd/yyyy}" />
                                            <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                            <asp:BoundField DataField="SMsg" HeaderText="SMsg" />
                                            <asp:BoundField DataField="MDescp" HeaderText="MDescp" />
                                            <asp:BoundField DataField="RemDate" HeaderText="Remainder Date" DataFormatString="{0:MM/dd/yyyy}" />
                                            <asp:BoundField DataField="Time" HeaderText="Time" />
                                            <asp:TemplateField HeaderText="Modify">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnModify" runat="server" Text="Modify" CommandName="Modify" CommandArgument='<%#Bind("BID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("BID") %>' />
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
                                <asp:Label ID="lblName" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lblUserId" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div style="overflow: scroll; height: 200px; border: 1px solid #dddddd;">
                <asp:GridView ID="gvItemChild" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="BID" HeaderText="BID" Visible="false" />
                        <asp:BoundField DataField="NameOfPerson" HeaderText="Name Of Person" />
                        <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                        <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" DataFormatString="{0:MM/dd/yyyy}" />
                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                        <asp:BoundField DataField="SMsg" HeaderText="SMsg" />
                        <asp:BoundField DataField="MDescp" HeaderText="MDescp" />
                        <asp:BoundField DataField="RemDate" HeaderText="Remainder Date" DataFormatString="{0:MM/dd/yyyy}" />
                        <asp:BoundField DataField="Time" HeaderText="Time" />
                    </Columns>
                </asp:GridView>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>
