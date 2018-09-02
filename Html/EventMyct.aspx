<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="EventMyct.aspx.cs" Inherits="html_EventMyct" Title="Untitled Page" %>

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

    <%--Enter Only Character.--%>

    <script type="text/javascript" language="javascript">
        function isCharKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if ((charCode < 64 && charCode > 0) || (charCode < 96 && charCode > 91) || (charCode < 127 && charCode > 123))
                return false;

            return true;
        }
    </script>

    <style>
        .watermark
        {
            font-family: Cambria;
            font-style: italic;
            color: Gray;
        }
        .style122
        {
            height: 57px;
        }
    </style>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <div class="MainDiv">
                        <div class="InnerDiv">
                            <center>
                                <table class="tblSubFull2">
                                    <tr style="background-color: #C3FEFE;">
                                        <td align="center" colspan="2">
                                            <img src="../KResource/Images/Cake-icon.png" width="40px" height="30px" />
                                            <span class="spanTitle">Marriage</span>
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
                                        <td align="right">
                                            Name Of Bride
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtBrideName" runat="server" Height="20px"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="b"
                                        ControlToValidate="txtBrideName" ErrorMessage="Please Enter the bride name"></asp:RequiredFieldValidator>--%>
                                            <%--<asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtBrideName"
                                        WatermarkCssClass="watermark" WatermarkText="Enter the Bride Name " />--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBrideName" ErrorMessage="Name Is Req"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Name Of Groom
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtGroom" runat="server" Height="20px"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="b"
                                        ErrorMessage="Please Enter the groom name" ControlToValidate="txtGroom"></asp:RequiredFieldValidator>--%>
                                            <%-- <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtGroom"
                                        WatermarkCssClass="watermark" WatermarkText="Enter the Groom Name " />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Invitation From
                                        </td>
                                        <td align="left">
                                            <asp:RadioButtonList ID="rdbInvite" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem>Bride</asp:ListItem>
                                                <asp:ListItem>Groom</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="b"
                                        ErrorMessage="Please Enter invitation from" ControlToValidate="rdbInvite"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Date Of Marriage
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDateOfMgs" runat="server" Height="20px" MaxLength="10"></asp:TextBox>
                                            <%--<asp:TextBoxWatermarkExtender ID="TjhkextBoxWatermarkhlkExtender1" runat="server"
                                        TargetControlID="txtDateOfMgs" WatermarkCssClass="watermark" WatermarkText="Select Date">
                                    </asp:TextBoxWatermarkExtender>--%>
                                            <asp:Image ID="Image2" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                                                runat="server" />
                                            <asp:CalendarExtender ID="CalendarExtender2" PopupButtonID="Image2" runat="server"
                                                Format="yyyy-MM-dd" TargetControlID="txtDateOfMgs">
                                            </asp:CalendarExtender>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="b"
                                        ErrorMessage="Please Select Date" ControlToValidate="txtDateOfMgs"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Time Of Marriage
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtTime" runat="server" Height="20px"></asp:TextBox>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" TargetControlID="txtTime" Mask="99:99:99"
                                                MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                AcceptAMPM="true" MaskType="Time" runat="server">
                                            </asp:MaskedEditExtender>
                                            <%-- <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender10" runat="server" TargetControlID="txtTime"
                                        WatermarkCssClass="watermark" WatermarkText="Enter the Time" />--%>
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
                                            Marriage Location
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtLocation" runat="server" Height="20px"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ValidationGroup="b"
                                        ErrorMessage="Please Enter the location" ControlToValidate="txtLocation"></asp:RequiredFieldValidator>--%>
                                            <%--      <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server" TargetControlID="txtLocation"
                                        WatermarkCssClass="watermark" WatermarkText="Enter the Location" />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Invitee Person Name
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPersonName" runat="server" Height="20px"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="rfvPN" runat="server" ValidationGroup="b" ControlToValidate="txtPersonName"
                                                ErrorMessage="Please Enter Invitee Person Name"></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Invitee Mobile No
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtMobileNo" runat="server" Height="20px" onKeyPress="return numbersonly(this,event) "></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="rfvMN" runat="server" ValidationGroup="b" ControlToValidate="txtMobileNo"
                                        ErrorMessage="Please Enter  Mobile Number "></asp:RequiredFieldValidator>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Personal Visit
                                        </td>
                                        <td align="left">
                                            <asp:RadioButtonList ID="rbtnPvisit" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem>No</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="rbtnPvisit"
                                        ErrorMessage="Please Enter LOcation" ValidationGroup="b"></asp:RequiredFieldValidator>--%>
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
                                            <asp:TextBox ID="txtTextMgs" runat="server" TextMode="MultiLine" Height="40px" Width="157px"></asp:TextBox>
                                            <%--<asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="txtTextMgs"
                                        WatermarkCssClass="watermark" WatermarkText="Enter the Text Message" />--%>
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
                                            <%--<asp:TextBoxWatermarkExtender ID="TjhkextBoxWatermarkhlkExtender1" runat="server"
                                        TargetControlID="txtDateOfMgs" WatermarkCssClass="watermark" WatermarkText="Select Date">
                                    </asp:TextBoxWatermarkExtender>--%>
                                            <asp:Image ID="Image1" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                                                runat="server" />
                                            <asp:CalendarExtender ID="CalendarExtender1" PopupButtonID="Image1" runat="server"
                                                Format="yyyy-MM-dd" TargetControlID="txtRemDate">
                                            </asp:CalendarExtender>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="b"
                                        ErrorMessage="Please Select Date" ControlToValidate="txtRemDate"></asp:RequiredFieldValidator>--%>
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
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" TargetControlID="txtRemTime" Mask="99:99:99"
                                                MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                AcceptAMPM="true" MaskType="Time" runat="server">
                                            </asp:MaskedEditExtender>
                                            <%-- <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender10" runat="server" TargetControlID="txtTime"
                                        WatermarkCssClass="watermark" WatermarkText="Enter the Time" />--%>
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
                                    </tr>
                                    <tr>
                                    </tr>
                                    <tr>
                                    </tr>
                                    <tr>
                                    </tr>
                                    </tr><tr>
                                    </tr>
                                    <tr>
                                    </tr>
                                    <tr>
                                        <asp:Label ID="lblSelectFiletoUpload" runat="server" Font-Bold="true" Text="Select Excel File to Upload :"
                                            Visible="false"></asp:Label>
                                        <td align="right">
                                            <asp:FileUpload ID="excelFileUpload" runat="server" Font-Bold="true" Visible="true" />
                                            <%-- <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="excelFileUpload"
                                                ErrorMessage="*" SetFocusOnError="True" Width="225px" ValidationGroup="other"
                                                Font-Size="Small"></asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnUploadFile" runat="server" Font-Bold="true" OnClick="btnUploadFile_Click"
                                                Text="Upload File" Visible="true" />
                                        </td>
                                    </tr>
                                    </tr><tr>
                                    </tr>
                                    <tr>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lnkdownload" runat="server" OnClick="lnkdownload_Click" Text="Download Excel Format"></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="left">
                                            <br />
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="cssbtn" OnClick="btnSubmit_Click"
                                                Text="Submit" />
                                            <asp:Button ID="btnCancel" runat="server" CssClass="cssbtn" OnClick="btnCancel_Click"
                                                Text="Cancel" />
                                            <asp:LinkButton ID="lnkshowchild" runat="server" OnClick="lnkshowchild_Click">Show 
                                            Child Record
                                            </asp:LinkButton>
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                            <table class="tblSubFull2">
                                <tr>
                                    <%--BrideName,GroomName,InvitionFrom,DateOfMgs,TimeOfMgs,Location,SpecialDescription,FristName,LastName,MobileNo,Address,Priority,MyCt_UserId--%>
                                    <td>
                                        <div style="overflow: scroll; height: 200px; border: 1px solid #dddddd; width: 650px;">
                                            <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                                                CssClass="gridview" Width="50%" OnRowCommand="gvItem_RowCommand1">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Event No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"></asp:BoundField>
                                                    <asp:BoundField DataField="BrideName" HeaderText="Bride"></asp:BoundField>
                                                    <asp:BoundField DataField="GroomName" HeaderText="Groom"></asp:BoundField>
                                                    <asp:BoundField DataField="InvitionFrom" HeaderText="Invition From"></asp:BoundField>
                                                    <asp:BoundField DataField="Date" HeaderText="Date Of Marriage" DataFormatString="{0:MM/dd/yyyy}">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Time" HeaderText="Time Of Marriage"></asp:BoundField>
                                                    <asp:BoundField DataField="Location" HeaderText="Location" Visible="false"></asp:BoundField>
                                                    <asp:BoundField DataField="PersonName" HeaderText="Person Name"></asp:BoundField>
                                                    <asp:BoundField DataField="MobileNumber" HeaderText="Mobile No"></asp:BoundField>
                                                    <asp:BoundField DataField="PVisit" HeaderText="PVisit"></asp:BoundField>
                                                    <asp:BoundField DataField="MDescp" HeaderText="MDescp"></asp:BoundField>
                                                    <asp:BoundField DataField="RemDate" HeaderText="Remainder Date" />
                                                    <asp:BoundField DataField="RemTime" HeaderText="Remainder Time" />
                                                    <%--<asp:TemplateField HeaderText="Modify">
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("Id") %>' runat="server"
                                                        ImageUrl="~/resources1/images/ico_yes1.gif" CommandName="Modify"></asp:ImageButton>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </asp:TemplateField> --%>
                                                    <asp:TemplateField HeaderText="Modify">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnModify" runat="server" Text="Modify" CommandName="Modify" CommandArgument='<%#Eval("Id") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("Id") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Print">
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Button ID="btnPrint" runat="server" Text="Print" CommandName="Print" CssClass="cssbtn"
                                                        CommandArgument='<%#Bind("Id") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                            </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <asp:Label ID="lblId" runat="server" Text="" Visible="false"></asp:Label>
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
                            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="BrideName" HeaderText="Bride"></asp:BoundField>
                            <asp:BoundField DataField="GroomName" HeaderText="Groom"></asp:BoundField>
                            <asp:BoundField DataField="InvitionFrom" HeaderText="Invition From"></asp:BoundField>
                            <asp:BoundField DataField="Date" HeaderText="Date Of Marriage" DataFormatString="{0:MM/dd/yyyy}">
                            </asp:BoundField>
                            <asp:BoundField DataField="Time" HeaderText="Time Of Marriage"></asp:BoundField>
                            <asp:BoundField DataField="Location" HeaderText="Location" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="PersonName" HeaderText="Person Name"></asp:BoundField>
                            <asp:BoundField DataField="MobileNumber" HeaderText="Mobile No"></asp:BoundField>
                            <asp:BoundField DataField="PVisit" HeaderText="PVisit"></asp:BoundField>
                            <asp:BoundField DataField="MDescp" HeaderText="MDescp"></asp:BoundField>
                            <asp:BoundField DataField="RemDate" HeaderText="Remainder Date" />
                            <asp:BoundField DataField="RemTime" HeaderText="Remainder Time" />
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
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUploadFile" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
