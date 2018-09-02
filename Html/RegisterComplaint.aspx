<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="RegisterComplaint.aspx.cs" Inherits="html_RegisterComplaint" Title="Untitled Page"
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
            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
            <%--<ContentTemplate>--%>
            <div class="MainDiv">
                <div class="InnerDiv">
                    <table class="tblSubFull2">
                        <tr style="background-color: #C3FEFE;">
                            <td align="center" colspan="2">
                                <img src="../KResource/Images/Cake-icon.png" width="40px" height="30px" />
                                <span class="spanTitle">Complaint</span>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp; &nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr>
                            <td align="right">
                                Complaint Type
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLCType" runat="server" AutoPostBack="true" CssClass="cssddlwidth" Width="165px"
                                    Height="25px" OnSelectedIndexChanged="DDLCType_SelectedIndexChanged">
                                    <asp:ListItem>select</asp:ListItem>
                                    <asp:ListItem>Local Complaint</asp:ListItem>
                                    <asp:ListItem>Personal Complaint</asp:ListItem>
                                    <asp:ListItem>Public Complaint</asp:ListItem>
                                    <asp:ListItem>General</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="txtCType" runat="server" AutoPostBack="true" Visible="false" CssClass="ccstxt"
                                    OnTextChanged="txtCType_TextChanged"></asp:TextBox>
                            </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr>
                            <td align="right">
                                Date
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtdate" runat="server" height="20px"></asp:TextBox>
                                <asp:Image ID="Image2" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                                    runat="server" />
                                <asp:CalendarExtender ID="CEBD" PopupButtonID="Image2" runat="server" Format="yyyy-MM-dd"
                                    TargetControlID="txtdate">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="txtdate"
                                    ValidationGroup="b" ErrorMessage="Please Enter BirthDate"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr>
                            <td align="right">
                                Complaint Subject
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCSub" runat="server" onkeyPress="return isCharKey(event,this);"
                                    height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr>
                            <td align="right">
                                Complaint Details
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCDetails" runat="server" TextMode="MultiLine" Height="40px" Width="150px" CssClass="ccstxt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr>
                            <td align="right">
                                Complaint for Department
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLCFDept" runat="server" AutoPostBack="true" CssClass="cssddlwidth" Width="165px"
                                    Height="25px" OnSelectedIndexChanged="DDLCFDept_SelectedIndexChanged">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Gram Panchayat</asp:ListItem>
                                    <asp:ListItem>Collector Office</asp:ListItem>
                                    <asp:ListItem>SDO Office</asp:ListItem>
                                    <asp:ListItem>MSCB</asp:ListItem>
                                    <asp:ListItem>B &amp; C</asp:ListItem>
                                    <asp:ListItem>HealthDepartment</asp:ListItem>
                                    <asp:ListItem>Talathi</asp:ListItem>
                                    <asp:ListItem>General</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="txtCFDept" runat="server" AutoPostBack="true" CssClass="ccstxt"
                                    Visible="false" OnTextChanged="txtCFDept_TextChanged"></asp:TextBox>
                            </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr>
                            <td align="right">
                                complainant Name
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCName" runat="server" onkeyPress="return isCharKey(event,this);"
                                    height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr>
                            <td align="right">
                                Mobile Number
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMoblieNo" runat="server" height="20px" onKeyPress="return numbersonly(this,event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr>
                            <td align="right">
                                Address
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAddress" runat="server" height="20px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr><td></td></tr>
                        <%--<tr>
                          
                            <td align="right">
                                <asp:FileUpload ID="Fileupload" runat="server" />
                            </td>
                            <td align="left">
                                <asp:Button ID="btnUpload" runat="server" Text="Upload File" 
                                    onclick="btnUpload_Click"/>
                            </td>
                        </tr>--%>
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
                       <tr><td></td></tr>
                       <tr>
                       <td>
                       <asp:LinkButton ID="lnkDownload" runat="server" Text="Download Excel File" 
                               onclick="lnkDownload_Click"></asp:LinkButton>
                       </td>
                       </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                                <br />
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="b" CssClass="cssbtn"
                                    OnClick="btnSubmit_Click1" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="cssbtn" />
                                <asp:Button ID="btnExportToExcel" runat="server" Font-Bold="true" ForeColor="Maroon"
                                    Text="Export to excel" Width="129px" OnClick="btnExportToExcel_Click" />
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
                        <tr><td></td></tr>
                         <tr>
                            <asp:GridView ID="gvFileUpload" runat="server" AutoGenerateColumns="false" DataKeyNames="Id">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" />
                                    <asp:BoundField DataField="FileName" HeaderText="File Name" />
                                    <asp:TemplateField HeaderText="FilePath">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkbtnDown" runat="server" Text="Download" OnClick="lnkbtnDown_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </tr>
                    </table>
                    
                    <table class="tblSubFull2">
                        <tr>
                            <td>
                                <div style="overflow: scroll; height: 200px; border: 1px solid #dddddd;">
                                    <asp:GridView ID="gvItem" runat="server" Visible="true" AutoGenerateColumns="false"
                                        CssClass="gridview" Width="100%" OnRowDataBound="gvItem_RowDataBound" 
                                        onrowcommand="gvItem_RowCommand" onrowdeleting="gvItem_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Event No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CID" HeaderText="CID" />
                                            <asp:BoundField DataField="CompType" HeaderText="CompType" />
                                            <asp:BoundField DataField="Date" HeaderText="Date" />
                                            <asp:BoundField DataField="CompSub" HeaderText="CompSub" />
                                            <asp:BoundField DataField="CompName" HeaderText="CompName" />
                                            <asp:BoundField DataField="CompDetails" HeaderText="CompDetails" />
                                            <asp:BoundField DataField="CompFDept" HeaderText="CompFDept" />
                                            <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                                            <asp:BoundField DataField="Address" HeaderText="Address" />
                                            <asp:TemplateField HeaderText="FollowUp">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnlikFollowUp" runat="server" PostBackUrl="~/Html/ComplaintFollowUp.aspx">FollowUp</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Modify">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnModify" runat="server" Text="Modify" CommandName="Modify" CommandArgument='<%#Bind("CID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%#Eval("CID") %>' />
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
            <%--</ContentTemplate>--%>
            <%-- </asp:UpdatePanel>--%>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <%--<asp:GridView ID="gvItem1" runat="server" AutoGenerateColumns="false" CssClass="gridview"
                Width="100%" onrowdatabound="gvItem1_RowDataBound">--%>
            <asp:GridView ID="gvItem1" runat="server" AutoGenerateColumns="false" CssClass="gridview"
                Width="100%">
                <Columns>
                    <%--<asp:TemplateField HeaderText="Event No">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:BoundField DataField="CID" HeaderText="CID" />
                    <asp:BoundField DataField="CompType" HeaderText="CompType" />
                    <asp:BoundField DataField="Date" HeaderText="Date" />
                    <asp:BoundField DataField="CompSub" HeaderText="CompSub" />
                    <asp:BoundField DataField="CompName" HeaderText="CompName" />
                    <asp:BoundField DataField="CompDetails" HeaderText="CompDetails" />
                    <asp:BoundField DataField="CompFDept" HeaderText="CompFDept" />
                    <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <%--<asp:TemplateField HeaderText="FollowUp">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnlikFollowUp" runat="server" PostBackUrl="~/Html/ComplaintFollowUp.aspx">FollowUp</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
            <asp:LinkButton ID="lkbtnBack" runat="server" Text="Back" OnClick="lkbtnBack_Click"></asp:LinkButton>
        </asp:View>
    </asp:MultiView>
</asp:Content>
