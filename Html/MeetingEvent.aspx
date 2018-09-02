<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="MeetingEvent.aspx.cs" Inherits="html_MeetingEvent" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
                                <span class="spanTitle">Meeting</span>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp; &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width:40%">
                                Event Title
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtETitle" runat="server" Height="20px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvETitle" runat="server" ControlToValidate="txtETitle"
                                    ErrorMessage="Please Enter Event Title" ValidationGroup="b"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Meeting Type
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLMeetingType" runat="server" CssClass="cssddlwidth" Width="165px"
                                    Height="25px" AutoPostBack="true"
                                    OnSelectedIndexChanged="DDLMeetingType_SelectedIndexChanged">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                    <asp:ListItem>Personal</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="txtMeetingType" runat="server" Visible="false" AutoPostBack="true"
                                    OnTextChanged="txtMeetingType_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvMType" runat="server" ControlToValidate="DDLMeetingType"
                                    ErrorMessage="Please Enter Meeting Type" ValidationGroup="b"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Location
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtLocation" runat="server" Height="20px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvLoc" runat="server" ControlToValidate="txtLocation"
                                    ErrorMessage="Please Enter Location" ValidationGroup="b"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                From Date
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFDate" runat="server" Height="20px"></asp:TextBox>
                                <asp:Image ID="Image2" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                                    runat="server" />
                                <asp:CalendarExtender ID="CEBD" PopupButtonID="Image2" runat="server" Format="yyyy-MM-dd"
                                    TargetControlID="txtFDate">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvBirthDate" runat="server" ControlToValidate="txtFDate"
                                    ValidationGroup="b" ErrorMessage="Please Enter Date"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                from Time
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFTime" runat="server" Height="20px"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" TargetControlID="txtFTime" Mask="99:99:99"
                                    MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                    AcceptAMPM="true" MaskType="Time" runat="server">
                                </asp:MaskedEditExtender>
                                <em style="font-style: italic; color: rgb(102, 102, 102); font-family: Tahoma, Arial, sans-serif;
                                    font-size: 12px; font-variant: normal; font-weight: normal; letter-spacing: normal;
                                    line-height: 18px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none;
                                    white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto;
                                    -webkit-text-stroke-width: 0px;"><span style="font-size: 8pt;">Tip: Type &#39;A&#39; 
                                or &#39;P&#39; to switch AM/PM</span></em>
                                <asp:RequiredFieldValidator ID="rfvtxtFTime" runat="server" ValidationGroup="b" ControlToValidate="txtFTime"
                                    ErrorMessage="Please Enter from Time"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Upto Date
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtUDate" runat="server" Height="20px"></asp:TextBox>
                                <asp:Image ID="Image4" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                                    runat="server" />
                                <asp:CalendarExtender ID="CalendarExtender1" PopupButtonID="Image4" runat="server"
                                    Format="yyyy-MM-dd" TargetControlID="txtUDate">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUDate"
                                    ValidationGroup="b" ErrorMessage="Please Enter BirthDate"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Upto Time
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtUTime" runat="server" Height="20px"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MEEUTime" Mask="99:99:99" MaskType="Time" MessageValidatorTip="true"
                                    OnFocusCssClass="MaskedEditFocus" OnFocusCssNegative="MasedEditError" TargetControlID="txtUTime"
                                    AcceptAMPM="true" runat="server">
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
                                Description
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDescp" runat="server" Height="20px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDescp" runat="server" ControlToValidate="txtDescp"
                                    ErrorMessage="Please Enter Description" ValidationGroup="b"></asp:RequiredFieldValidator>
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
                                <asp:Image ID="Image3" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                                    runat="server" />
                                <asp:CalendarExtender ID="CalRDate" Format="yyyy-MM-dd" PopupButtonID="Image3" TargetControlID="txtRemDate"
                                    runat="server">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvtxtRemDate" runat="server" ControlToValidate="txtRemDate"
                                    ErrorMessage="Please Enter Remainder Date" ValidationGroup="b"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Remainder Time
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtRemTime" runat="server" Height="20px"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender2" Mask="99:99:99" MaskType="Time"
                                    MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnFocusCssNegative="MasedEditError"
                                    TargetControlID="txtRemTime" AcceptAMPM="true" runat="server">
                                </asp:MaskedEditExtender>
                                <em style="font-style: italic; color: rgb(102, 102, 102); font-family: Tahoma, Arial, sans-serif;
                                    font-size: 12px; font-variant: normal; font-weight: normal; letter-spacing: normal;
                                    line-height: 18px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none;
                                    white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto;
                                    -webkit-text-stroke-width: 0px;"><span style="font-size: 8pt;">Tip: Type &#39;A&#39; 
                                or &#39;P&#39; to switch AM/PM</span></em>
                                <asp:RequiredFieldValidator ID="rfvtxtTime" runat="server" ValidationGroup="b" ControlToValidate="txtRemTime"
                                    ErrorMessage="Please Enter Remainder Time"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Repetation Remainder
                            </td>
                            <td align="left">
                                <asp:RadioButtonList ID="rbtnRRemainder" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>Yes</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="rfvrbtnRR" runat="server" ValidationGroup="b" ControlToValidate="rbtnRRemainder"
                                    ErrorMessage="Please Enter Repetation"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <asp:Label ID="SelectExcelFileTo" runat="server" Font-Bold="true" Text="Select Excel File To Upload"
                                Visible="false"></asp:Label>
                            <td align="right">
                                <asp:FileUpload ID="excelFileUpload" runat="server" Visible="true" Font-Bold="true" />
                            </td>
                            <td align="left">
                                <asp:Button ID="btnUploadFile" runat="server" Text="Upload File" Visible="true" OnClick="btnUploadFile_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkDownloadE" runat="server" Text="Download Excel Format" OnClick="lnkDownloadE_Click"></asp:LinkButton>
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
                                <br />
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                    CssClass="cssbtn" ValidationGroup="b" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="cssbtn" />
                                <asp:LinkButton ID="lnkshowchild" runat="server" OnClick="lnkshowchild_Click">Show 
                                Child Record </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <table class="tblSubFull2">
                        <tr>
                            <td>
                                <div style="overflow: scroll; height: 200px; border: 1px solid #dddddd;">
                                    <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvItem_RowDataBound"
                                         CssClass="gridview" OnRowCommand="gvItem_RowCommand" 
                                        onrowdeleting="gvItem_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ID" Visible="false" />
                                            <asp:BoundField DataField="ETitle" HeaderText="Event Title" />
                                            <asp:BoundField DataField="MeetingType" HeaderText="Meeting Type" />
                                            <asp:BoundField DataField="Location" HeaderText="Location" />
                                            <asp:BoundField DataField="FrmDate" HeaderText="FrmDate" />
                                            <asp:BoundField DataField="UptoDate" HeaderText="UptoDate" />
                                            <asp:BoundField DataField="FrmTime" HeaderText="FrmTime" />
                                            <asp:BoundField DataField="UptoTime" HeaderText="UptoTime" />
                                            <asp:BoundField DataField="Descp" HeaderText="Descp" />
                                            <asp:BoundField DataField="RemDate" HeaderText="RemDate" />
                                            <asp:BoundField DataField="RemTime" HeaderText="RemTime" />
                                            <asp:BoundField DataField="RepRemainder" HeaderText="RepRemainder" />
                                            <%--<asp:TemplateField HeaderText="Modify">
                       <ItemTemplate>
                           <asp:ImageButton ID="IbtnSubmit" runat="server" CommandArgument='<%#Bind("ID") %>' CommandName="Modify" ImageUrl="~/resources1/images/ico_yes1.gif"/>
                       </ItemTemplate>
                       </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Modify">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnModify" runat="server" Text="Modify" CommandName="Modify" CommandArgument='<%#Bind("ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("ID")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <asp:Label ID="lblId" runat="server"></asp:Label>
                                <asp:Label ID="lblStatus" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lblMessage" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <asp:GridView ID="gvItem1" runat="server" AutoGenerateColumns="false" CssClass="gridview">
                <Columns>
                    <asp:TemplateField HeaderText="EventNo">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID" Visible="false" />
                    <asp:BoundField DataField="ETitle" HeaderText="Event Title" />
                    <asp:BoundField DataField="MeetingType" HeaderText="Meeting Type" />
                    <asp:BoundField DataField="Location" HeaderText="Location" />
                    <asp:BoundField DataField="FrmDate" HeaderText="FrmDate" />
                    <asp:BoundField DataField="UptoDate" HeaderText="UptoDate" />
                    <asp:BoundField DataField="FrmTime" HeaderText="FrmTime" />
                    <asp:BoundField DataField="UptoTime" HeaderText="UptoTime" />
                    <asp:BoundField DataField="Descp" HeaderText="Descp" />
                    <asp:BoundField DataField="RemDate" HeaderText="RemDate" />
                    <asp:BoundField DataField="RemTime" HeaderText="RemTime" />
                    <asp:BoundField DataField="RepRemainder" HeaderText="RepRemainder" />
                    <%--<asp:TemplateField HeaderText="Modify">
                       <ItemTemplate>
                           <asp:ImageButton ID="IbtnSubmit" runat="server" CommandArgument='<%#Bind("ID") %>' CommandName="Modify" ImageUrl="~/resources1/images/ico_yes1.gif"/>
                       </ItemTemplate>
                       </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Modify">
                        <ItemTemplate>
                            <asp:Button ID="btnModify" runat="server" Text="Modify" CommandName="Modify" CommandArgument='<%#Bind("ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:View>
    </asp:MultiView>
</asp:Content>
