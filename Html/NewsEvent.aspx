<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="NewsEvent.aspx.cs" Inherits="html_NewsEvent" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

 <%--<script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to send passcode by sms?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>--%>
    
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="MainDiv">
                <div class="InnerDiv">
                    <table class="tblSubFull2">
                        <tr style="background-color: #C3FEFE;">
                            <td align="center" colspan="2">
                                <img src="../KResource/Images/Cake-icon.png" width="40px" height="30px" />
                                <span class="spanTitle">News</span>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                        <td>&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                News HeadLine
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNewsHead" runat="server" height="20px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNHead" runat="server" ControlToValidate="txtNewsHead"
                                    ErrorMessage="Please Enter News HeadLine" ValidationGroup="b"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr>
                            <td align="right">
                                News Details
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNDetails" runat="server" height="20px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvND" runat="server" ControlToValidate="txtNDetails"
                                    ErrorMessage="Please Enter News Details" ValidationGroup="b"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                            </td>
                        </tr>
                         <tr><td></td></tr>
                        <tr>
                            <td align="right">
                                Select News Paper
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLNPaper" runat="server" CssClass="cssddlwidth" Width="165px"
                                    Height="25px" AutoPostBack="true" OnSelectedIndexChanged="DDLNPaper_SelectedIndexChanged">
                                    <%-- <asp:ListItem Value="4">Select News Paper</asp:ListItem>
                       <asp:ListItem Value="0">Sakal</asp:ListItem>
                       <asp:ListItem Value="1">Lokmat</asp:ListItem>
                       <asp:ListItem Value="2">Pudhari</asp:ListItem>--%>
                                </asp:DropDownList>
                                <asp:TextBox ID="txtNPaper" runat="server" Visible="False"  AutoPostBack="True"
                                    OnTextChanged="txtNPaper_TextChanged"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DDLNPaper"
                                    ErrorMessage="Please Enter News paper" ValidationGroup="b"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            </td>
                        </tr>
                         <tr><td></td></tr>
                        <tr>
                            <td align="right">
                                Select Role
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtRole" runat="server" height="20px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRole"
                                    ErrorMessage="Please Enter Role" ValidationGroup="b"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                            </td>
                        </tr>
                         <tr><td></td></tr>
                        <tr>
                            <td align="right">
                                Date
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDate" runat="server"  onfocus="blur()" height="20px"></asp:TextBox>
                                <asp:Image ID="Image2" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose
                        Date" runat="server" />
                                <asp:CalendarExtender ID="calEDate" runat="server" Format="yyyy-MM-dd" PopupButtonID="Image2"
                                    TargetControlID="txtDate">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRole"
                                    ErrorMessage="Please Enter Role" ValidationGroup="b"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            </td>
                        </tr>
                         <tr><td></td></tr>
                        <tr>
                            <td align="right">
                                Time
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtTime" runat="server" height="20px"></asp:TextBox>
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
                                <asp:RequiredFieldValidator ID="rfvtxtTime" runat="server" ValidationGroup="b" ErrorMessage="Please Enter Time"
                                    ControlToValidate="txtTime"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            </td>
                        </tr>
                         <tr><td></td></tr>
                        <tr>
                            <td align="right">
                                Type Of News
                            </td>
                            <td align="left">
                                <asp:RadioButtonList ID="rbtnTONews" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>Positive</asp:ListItem>
                                    <asp:ListItem>Negative</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="rfvrbtnNews" runat="server" ValidationGroup="b" ErrorMessage="Please Enter Type Of News"
                                    ControlToValidate="rbtnTONews"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            </td>
                            
                        </tr>
                         <tr><td></td></tr>
                        <tr>
                            <td align="right">
                                Location
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtLocation" runat="server" height="20px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvLocation" runat="server" ControlToValidate="txtLocation"
                                    ErrorMessage="Please Enter Location" ValidationGroup="b"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            </td>
                        </tr>
                         <tr><td></td></tr>
                        <tr>
                            <td align="right">
                                Your Feedback
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFeedback" runat="server" TextMode="MultiLine" Height="50px" Width="157px"
                                    ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvFee" runat="server" ControlToValidate="txtFeedback"
                                    ErrorMessage="Please Enter Your Feedback" ValidationGroup="b"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                        
                            <td>
                            
                            
                                <asp:FileUpload ID="excelFileUpload" runat="server" Font-Bold="true" Visible="true" />
                           
                            </td>
                            <td>
                                <asp:Button ID="btnUploadFile" runat="server" Font-Bold="true" Text="Upload File"
                                    Visible="true" OnClick="btnUploadFile_Click" />
                                 </td>    
                          
                        </tr>
                        <tr><td></td>
                            <td>
                                <asp:LinkButton ID="lnkdownload" runat="server" Text="Download Excel Format" OnClick="lnkdownload_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                                <br />
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="b" CssClass="cssbtn"
                                    OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="cssbtn" />
                                <%--<asp:Button ID="btnExportToExcel" runat="server" Font-Bold="true" ForeColor="Maroon"
                                    Text="Export to excel" Width="129px" OnClick="btnExportToExcel_Click" />--%>
                                <br />
                                <%--<asp:Button ID="btnShowView2" runat="server" Text="Shhow!1" OnClick="lkbtnShowChlid_Click" />--%>
                                <asp:LinkButton ID="lkbtnShowChlid" runat="server" OnClick="lkbtnShowChlid_Click">Show 
                                Child Record</asp:LinkButton>
                            </td>
                            <td>
                                <%--<asp:Button ID="btnExportToExcel" runat="server" Font-Bold="true" ForeColor="Maroon" Text="Export to excel" Width="129px" />--%>
                                <%--<asp:Button ID="btnExportToExcel" runat="server" Font-Bold="True" ForeColor="Maroon"
                            
                             Text="Export To Excel" Width="129px" onclick="btnExportToExcel_Click" />--%>
                            </td>
                            <%--<td>
                                       <asp:Button ID="btnExportToExcel" runat="server" Font-Bold="true" ForeColor="Maroon" Text="Export to excel" Width="129px" />
                                    </td>--%>
                        </tr>
                    </table>
                    <table class="tblSubFull2">
                        <tr>
                            <td>
                                <div style="overflow: scroll; height: 200px; border: 1px solid #dddddd;">
                                    <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" CssClass="gridview"
                                        OnRowDataBound="gvItem_RowDataBound" 
                                        OnSelectedIndexChanged="gvItem_SelectedIndexChanged" 
                                        onrowcommand="gvItem_RowCommand" onrowdeleting="gvItem_RowDeleting"
                                        >
                                        <Columns>
                                            <asp:TemplateField HeaderText="Event No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="NID" HeaderText="NID" Visible="false" />
                                            <asp:BoundField DataField="NewsHead" HeaderText="News Head" />
                                            <asp:BoundField DataField="NewsDetails" HeaderText="NewsDetails" />
                                            <asp:BoundField DataField="NPaper" HeaderText="NPaper" />
                                            <asp:BoundField DataField="Role" HeaderText="Role" />
                                            <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
                                            <asp:BoundField DataField="Time" HeaderText="Time" />
                                            <asp:BoundField DataField="TypeOfNews" HeaderText="TypeOfNews" />
                                            <asp:BoundField DataField="Location" HeaderText="Location" />
                                            <asp:BoundField DataField="Feedback" HeaderText="Feedback" />
                                            <%--<asp:BoundField DataField="" HeaderText="" />--%>
                                            <asp:TemplateField HeaderText="Modify">
                                            <ItemTemplate>
                                                <asp:Button ID="btnModify" runat="server" Text="Modify" CommandName="Modify" CommandArgument='<%#Bind("NID") %>' />
                                            </ItemTemplate>
                                            
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("NID") %>' />
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
            <asp:GridView ID="gvItem1" runat="server" AutoGenerateColumns="false" CssClass="gridview"
                OnSelectedIndexChanged="gvItem1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="NID" HeaderText="NID" Visible="false" />
                    <asp:BoundField DataField="NewsHead" HeaderText="News Head" />
                    <asp:BoundField DataField="NewsDetails" HeaderText="NewsDetails" />
                    <asp:BoundField DataField="NPaper" HeaderText="NPaper" />
                    <asp:BoundField DataField="Role" HeaderText="Role" />
                    <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
                    <asp:BoundField DataField="Time" HeaderText="Time" />
                    <asp:BoundField DataField="TypeOfNews" HeaderText="TypeOfNews" />
                    <asp:BoundField DataField="Location" HeaderText="Location" />
                    <asp:BoundField DataField="Feedback" HeaderText="Feedback" />
                </Columns>
            </asp:GridView>
        </asp:View>
    </asp:MultiView>
   
</asp:Content>
