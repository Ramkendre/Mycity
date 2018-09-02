<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="ComplaintFollowUp.aspx.cs" Inherits="Html_ComplaintFollowUp" Title="Untitled Page" %>

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
            <div class="MainDiv">
                <div class="InnerDiv">
                    <table class="tblSubFull2">
                       <tr style="background-color: #C3FEFE;">
                            <td align="center" colspan="2">
                                <img src="../KResource/Images/Cake-icon.png" width="40px" height="30px" />
                                <span class="spanTitle">Complaint Followup</span>
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
                                CID
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCID" height="20px" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCID" runat="server" ControlToValidate="txtCID"
                                    ValidationGroup="b" ErrorMessage="Please Enter CID"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr>
                            <td align="right">
                                Date
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDate" runat="server" height="20px" MaxLength="10"></asp:TextBox>
                                <%--<asp:TextBoxWatermarkExtender ID="TjhkextBoxWatermarkhlkExtender1" runat="server"
                                        TargetControlID="txtDateOfMgs" WatermarkCssClass="watermark" WatermarkText="Select Date">
                                    </asp:TextBoxWatermarkExtender>--%>
                                <asp:Image ID="Image1" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                                    runat="server" />
                                <asp:CalendarExtender ID="CalendarExtender1" PopupButtonID="Image1" runat="server"
                                    Format="yyyy-MM-dd" TargetControlID="txtDate">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="b"
                                    ErrorMessage="Please Select Date" ControlToValidate="txtDate"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr>
                            <td align="right">
                                Remark
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtRemark" runat="server" height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr>
                            <td align="right">
                                Status
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLStatus" runat="server" AutoPostBack="true" CssClass="cssddlwidth" Width="165px"
                                    Height="25px" onselectedindexchanged="DDLStatus_SelectedIndexChanged">
                                    <asp:ListItem>...Select..</asp:ListItem>
                                    <asp:ListItem>Continued</asp:ListItem>
                                    <asp:ListItem>Completed</asp:ListItem>
                                    <asp:ListItem>Forwarded</asp:ListItem>
                                    <asp:ListItem>Finished</asp:ListItem>
                                    <asp:ListItem>Dismissed</asp:ListItem>
                                    <asp:ListItem>Rejected</asp:ListItem>
                                    <asp:ListItem>Pending</asp:ListItem>
                                    <asp:ListItem>Fail</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="txtStatus" runat="server" AutoPostBack="true" Visible="false" 
                                    CssClass="ccstxt" ontextchanged="txtStatus_TextChanged"></asp:TextBox>
                            </td>
                        </tr>
                        <tr><td></td></tr><tr><td></td></tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                                <asp:Button ID="btnSubmit" Text="Submit" runat="server" CssClass="cssbtn" OnClick="btnSubmit_Click" />
                                 <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="cssbtn" />
                            </td>
                        </tr>
                    </table>
                    <table class="tblSubFull2">
                        <tr>
                            <td>
                                <div style="overflow: scroll; height: 200px; border: 1px solid #dddddd;">
                                    <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false" CssClass="gridview" DataKeyNames="CFID"
                                        Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Event No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CFID" HeaderText="CFID" Visible="false"/>
                                            <asp:BoundField DataField="CID" HeaderText="CID" />
                                            <asp:BoundField DataField="Date" HeaderText="Date" />
                                            <asp:BoundField DataField="Remark" HeaderText="Remark"/>
                                            <%--<asp:BoundField DataField="Status" HeaderText="Status" />--%>
                                            <asp:BoundField DataField="Name" HeaderText="Status" />
                                             <%--<asp:TemplateField HeaderText="Modify">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnModify" runat="server" Text="Modify" CommandName="Modify" CommandArgument='<%#Eval("CFID") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("CFID") %>' />
                                            </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>
                            </td>
                        </tr>
                        <asp:Label ID="lblid" runat="server"></asp:Label>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
