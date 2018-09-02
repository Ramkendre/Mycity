<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="CreateEventD.aspx.cs" Inherits="html_CreateEventD" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="MainDiv">
        <div class="InnerDiv">
            <table class="tblSubFull2">
                <tr>
                    <td colspan="2" align="center">
                        <span class="spanTitle">Create Event</span>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Name Of Event
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtNameOfEvent" runat="server" CssClass="ccstxt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            ControlToValidate="txtNameOfEvent" ValidationGroup="b"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Date
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDateOfMgs" runat="server" CssClass="ccstxt" MaxLength="10"></asp:TextBox>
                        <asp:Image ID="Image2" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                            runat="server" />
                        <asp:CalendarExtender ID="CalendarExtender2" PopupButtonID="Image2" runat="server"
                            Format="yyyy-MM-dd" TargetControlID="txtDateOfMgs">
                        </asp:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="b"
                            ErrorMessage="*" ControlToValidate="txtDateOfMgs"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Time
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtTime" runat="server" CssClass="ccstxt"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender1" TargetControlID="txtTime" Mask="99:99:99"
                            MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                            AcceptAMPM="true" MaskType="Time" runat="server">
                        </asp:MaskedEditExtender>
                        <em style="font-style: italic; color: rgb(102, 102, 102); font-family: Tahoma, Arial, sans-serif;
                            font-size: 12px; font-variant: normal; font-weight: normal; letter-spacing: normal;
                            line-height: 18px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none;
                            white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto;
                            -webkit-text-stroke-width: 0px;"><span style="font-size: 8pt;">Tip: Type &#39;A&#39;
                                or &#39;P&#39; to switch AM/PM</span></em><asp:RequiredFieldValidator ControlToValidate="txtTime"
                                    ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ValidationGroup="b"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Location
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtLocation" runat="server" CssClass="ccstxt"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtLocation"
                            ValidationGroup="b"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Social Discription
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtSocialDisp" runat="server" CssClass="ccstxt" TextMode="MultiLine"
                            Height="50px" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Relative
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtRalative" runat="server" CssClass="ccstxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Relation With person(Party)
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtRelation" runat="server" CssClass="ccstxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Need To visit
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rdbVisit" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Yes</asp:ListItem>
                            <asp:ListItem Value="2">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Send Message
                    </td>
                    <td align="left">
                        <asp:RadioButtonList ID="rdbSendmgs" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Yes</asp:ListItem>
                            <asp:ListItem Value="2">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="cssbtn" ValidationGroup="b"
                            OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="cssbtn" OnClick="btnCancel_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:GridView ID="gvItem" runat="server" CssClass="gridview" AutoGenerateColumns="false"
                            PageSize="15" AllowPaging="true" EmptyDataText="No Data Found" OnPageIndexChanging="gvItem_PageIndexChanging"
                            OnRowCommand="gvItem_RowCommand" DataKeyNames="EventId">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr No">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="EventId" HeaderText="EventId" Visible="false"></asp:BoundField>
                                <asp:BoundField DataField="EventName" HeaderText="EventName"></asp:BoundField>
                                <asp:BoundField DataField="DateMessage" HeaderText="Date Message"></asp:BoundField>
                                <asp:BoundField DataField="time1" HeaderText="Time"></asp:BoundField>
                                <asp:BoundField DataField="Location" HeaderText="Location"></asp:BoundField>
                                <asp:BoundField DataField="CreateDate" HeaderText="Create Date"></asp:BoundField>
                                <asp:TemplateField HeaderText="Modify">
                                    <ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("EventId") %>' runat="server"
                                            ImageUrl="~/Resources/resources1/images/ico_yes1.gif" CommandName="Modify" OnClientClick="stopPostBack()">
                                        </asp:ImageButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblId" runat="server" Visible="false" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
