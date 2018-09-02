<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="VidhanMeetingSchedule.aspx.cs" Inherits="MarketingAdmin_VidhanMeetingSchedule"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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

            // control keys
            if ((key == null) || (key == 0) || (key == 8) ||
            (key == 9) || (key == 13) || (key == 27))
                return true;

            // numbers with prcision..
            else if ((("0123456789.").indexOf(keychar) > -1))
                return true;

            else
                return false;
        }
    </script>

    <div>
        <center>
            <div style="border: 1px solid #888888;">
                <div>
                    <table class="tables" width="80%">
                        <tr>
                            <td colspan="2">
                                <h3 style="text-align: center">
                                    Meeting schedule
                                </h3>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <center>
                                    <table>
                                        <tr>
                                            <td>
                                                Select Date
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDate" runat="server" CssClass="txtcss"  MaxLength="10" ></asp:TextBox>
                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="yyyy-MM-dd" TargetControlID="txtDate"
                                                    PopupButtonID="Image1">
                                                </asp:CalendarExtender>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/resources1/images/calendarclick.gif"
                                                    Height="20px" Width="20px" />
                                            </td>
                                        </tr>
                                    </table>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <center>
                                    <div style="margin-bottom: 20px; margin-top: 20px; border: 1px solid #2F4F4F; height: auto;
                                        width: 502px;">
                                        <asp:GridView ID="gvToday" runat="server" AutoGenerateColumns="False" BackColor="White"
                                            BorderColor="#DEDFDE" BorderWidth="1px" DataKeyNames="Id" ForeColor="Black" GridLines="Vertical"
                                            Width="500px" EmptyDataText="No Data Found" ToolTip="Details of Items">
                                            <RowStyle BackColor="#F7F7DE" Height="30px" />
                                            <Columns>
                                                <asp:BoundField DataField="Id" HeaderText="Id">
                                                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Committee_name" HeaderText="Committee Name" HeaderStyle-Width="500px">
                                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Room No" ItemStyle-Width="50px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtRoomNo" runat="server" Width="50px" MaxLength="3" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Time" ItemStyle-Width="100px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtTime" runat="server" Width="90px" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtTime"
                                                            Mask="99:99:99" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                            OnInvalidCssClass="MaskedEditError" AcceptAMPM="true" MaskType="Time" runat="server">
                                                        </asp:MaskedEditExtender>
                                                        <%-- <em style="font-style: italic; color: rgb(102, 102, 102); font-family: Tahoma, Arial, sans-serif;
                                                        font-size: 12px; font-variant: normal; font-weight: normal; letter-spacing: normal;
                                                        line-height: 18px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none;
                                                        white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto;
                                                        -webkit-text-stroke-width: 0px;"><span style="font-size: 8pt;">Tip: Type &#39;A&#39;
                                                            or &#39;P&#39; to switch AM/PM</span></em>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#CCCC99" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#009999" Font-Bold="True" Font-Size="1.1em" ForeColor="White"
                                                Height="30px" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </div>
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <center>
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit schedule" CssClass="btn" OnClick="btnSubmit_Click" />
                                     <asp:Button ID="btnCancel" runat="server" Text="Clear Schedule" CssClass="btn" 
                                        onclick="btnCancel_Click"  OnClientClick=" return confirm('Do you want Clear schedule ?');" />
                                </center>
                            </td>
                        </tr>
                    </table>
                </div>
        </center>
    </div>
</asp:Content>
