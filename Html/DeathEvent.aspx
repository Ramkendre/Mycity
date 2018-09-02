<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="DeathEvent.aspx.cs" Inherits="html_DeathEvent" Title="Untitled Page" %>

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

    <style>
        .style122
        {
            height: 47px;
        }
    </style>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="MainDiv">
                <div class="InnerDiv">
                    <table class="tblSubFull2">
                        <tr style="background-color: #C3FEFE;">
                            <td align="center" colspan="2">
                                <img src="../KResource/Images/Cake-icon.png" width="40px" height="30px" />
                                <span class="spanTitle">Death</span>
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
                            <td align="right" style="width: 40%">
                                Name Of Accussed
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNameOfAcc" runat="server" onkeyPress="return isCharKey(this,event)"
                                    Height="20px"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="rfvtxtname" runat="server" ValidationGroup="b" ErrorMessage="plz" ControlToValidate="txtNameOfAcc"></asp:RequiredFieldValidator>--%>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNameOfAcc"
                                    ErrorMessage="Please Enter Name Of Accussed" ValidationGroup="b"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Date
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDate" runat="server" Height="20px"></asp:TextBox>
                                <asp:Image ID="Image2" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                                    runat="server" />
                                <asp:CalendarExtender ID="CEDate" PopupButtonID="Image2" TargetControlID="txtDate"
                                    runat="server" Format="yyyy-MM-dd">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvtxtDate" runat="server" ErrorMessage="Please Enter Date"
                                    ControlToValidate="txtDate" ValidationGroup="b"></asp:RequiredFieldValidator>
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
                                <asp:MaskedEditExtender ID="MEETime" TargetControlID="txtTime" Mask="99:99:99" runat="server"
                                    MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                    AcceptAMPM="true" MaskType="Time">
                                </asp:MaskedEditExtender>
                                <asp:RequiredFieldValidator ID="rfvTime" ControlToValidate="txtTime" runat="server"
                                    ErrorMessage="Please Enter Time" ValidationGroup="b"></asp:RequiredFieldValidator>
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
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLocation" runat="server"
                                    ErrorMessage="Please Enter LOcation" ValidationGroup="b"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Special Description
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDescp" runat="server" TextMode="MultiLine" Height="35px" Width="160px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescp"
                                    ErrorMessage="Please Enter LOcation" ValidationGroup="b"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Relative Of
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtRelative" runat="server" Height="20px" onkeyPress="return isCharKey(this,event)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRelative"
                                    ErrorMessage="Please Enter LOcation" ValidationGroup="b"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Relation with Accused
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtRAccused" runat="server" Height="20px" onkeypress="return isCharKey(this,event)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRelative"
                                    ErrorMessage="Please Enter LOcation" ValidationGroup="b"></asp:RequiredFieldValidator>
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRelative"
                                    ErrorMessage="Please Enter LOcation" ValidationGroup="b"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Message Or Description
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMDescp" runat="server" TextMode="MultiLine" Height="35px" Width="160px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtRelative"
                                    ErrorMessage="Please Enter LOcation" ValidationGroup="b"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
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
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkdownload" runat="server" Text="Download Excel Format" OnClick="lnkdownload_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                            </td>
                            <td align="left">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="b" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                                <asp:LinkButton ID="lnkshowchild" runat="server" OnClick="lnkshowchild_Click">Show 
                                Child Record </asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <div style="overflow: scroll; height: 200px; border: 1px solid #dddddd;">
                                    <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvItem_RowDataBound"
                                        CssClass="gridview" OnRowCommand="gvItem_RowCommand" 
                                        onrowdeleting="gvItem_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Event No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DID" HeaderText="DID" Visible="false" />
                                            <asp:BoundField DataField="NameOfAccused" HeaderText="Name Of Accused" />
                                            <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
                                            <asp:BoundField DataField="Time" HeaderText="Time" />
                                            <asp:BoundField DataField="Location" HeaderText="Location" />
                                            <asp:BoundField DataField="SDescp" HeaderText="SDescp" />
                                            <asp:BoundField DataField="Relative" HeaderText="Relative" />
                                            <asp:BoundField DataField="Relation" HeaderText="Relation" />
                                            <asp:BoundField DataField="PVisit" HeaderText="Personal Visit" />
                                            <asp:BoundField DataField="MDescp" HeaderText="MDescp" />
                                            <asp:TemplateField HeaderText="Modify">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnModify" runat="server" Text="Modify" CommandName="Modify" CommandArgument='<%#Bind("DID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("DID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <asp:Label ID="lblId" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lblStatus" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lblMessage" runat="server" Text="" Visible="false"></asp:Label>
                                <%--<asp:Label ID="lblId" runat="server"></asp:Label>--%>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div style="overflow: scroll; height: 200px; border: 1px solid #dddddd;">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvItem_RowDataBound"
                    CssClass="gridview" OnRowCommand="gvItem_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Event No">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DID" HeaderText="DID" Visible="false" />
                        <asp:BoundField DataField="NameOfAccused" HeaderText="Name Of Accused" />
                        <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
                        <asp:BoundField DataField="Time" HeaderText="Time" />
                        <asp:BoundField DataField="Location" HeaderText="Location" />
                        <asp:BoundField DataField="SDescp" HeaderText="SDescp" />
                        <asp:BoundField DataField="Relative" HeaderText="Relative" />
                        <asp:BoundField DataField="Relation" HeaderText="Relation" />
                        <asp:BoundField DataField="PVisit" HeaderText="Personal Visit" />
                        <asp:BoundField DataField="MDescp" HeaderText="MDescp" />
                        <asp:TemplateField HeaderText="Modify">
                            <ItemTemplate>
                                <asp:Button ID="btnModify" runat="server" Text="Modify" CommandName="Modify" CommandArgument='<%#Bind("DID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>
