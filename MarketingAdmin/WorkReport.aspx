<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkReport.aspx.cs" MasterPageFile="~/Master/MainMaster.master" Inherits="MarketingAdmin_WorkReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%" border="1" align="center">
                <tr>
                    <td align="center">
                        <div id="div" style="width: 100%; margin-right: 7px;">
                            <table cellpadding="0" cellspacing="0" border="0" width="70%" class="tables">
                                <div style="width: 96%">
                                    <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                                        <tr>
                                            <td style="height: 20px;">
                                                <table style="width: 81%; margin-left: 157px;" class="tables" cellspacing="2" cellpadding="2">
                                                    <tr>
                                                        <td colspan="2" align="center" style="text-align: left; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                            <h3 style="color: Green; margin-left: 200px;">Work Report</h3>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td colspan="3">
                                                            <span class="warning1" style="color: red;">Fields marked with * are mandatory.</span>
                                                        </td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td colspan="3" align="center">
                                                            <asp:Label ID="lblError" runat="server" Visible="false" Style="color: red; font-size: 21px"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <td>
                                                                <asp:Label ID="lblMsgHead" runat="server" Visible="true" Style="color: black; font-size: 21px"></asp:Label>
                                                            </td>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 10px">
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left; width: 168px;" class="auto-style1">
                                                            <asp:Label ID="lblNameOfWorkPrj" runat="server" Font-Bold="true" Font-Names="Arial"
                                                                Font-Size="11pt" Text="Select Name Of Work/Project"></asp:Label>
                                                            <span class="warning1" style="color: Red;">*&nbsp;</span>
                                                        </td>
                                                        <td style="width: 628px; text-align: left">
                                                            <asp:DropDownList ID="ddlNameOfworkPrj" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNameOfworkPrj_SelectedIndexChanged" Height="25px" Width="389px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <caption>
                                                        <br />
                                                        <tr>
                                                            <td class="auto-style1" style="width: 168px"></td>
                                                            <td align="left" style="width: 37%; text-align: center"></td>
                                                            <td></td>
                                                        </tr>
                                                        <div class="Space">
                                                        </div>
                                                        <tr>
                                                            <td class="auto-style1" style="text-align: left; width: 168px;">
                                                                <asp:Label ID="lblworkType" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="11pt" Text="Select Work Type"></asp:Label>
                                                            </td>
                                                            <td style="width: 10%; text-align: left">
                                                                <asp:DropDownList ID="ddlWorkType" runat="server" AutoPostBack="true" Height="25px" Width="389px">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlWorkType" ErrorMessage="Please Select Work Type." ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 10px">
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1" style="text-align: left; width: 168px;">
                                                                <asp:Label ID="lblSubject" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="11pt" Text="Subject"></asp:Label>
                                                            </td>
                                                            <td style="width: 10%; text-align: left">
                                                                <asp:TextBox ID="txtSubject" runat="server" Width="389px" Height="25px" placeholder="Enter Subject"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubject" ErrorMessage="Please Enter Subject" ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 10px">
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1" style="text-align: left; width: 168px;">
                                                                <asp:Label ID="lblContents" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="11pt" Text="Contents"></asp:Label>
                                                            </td>
                                                            <td style="width: 10%; text-align: left">
                                                                <asp:TextBox ID="txtContents" runat="server" Width="389px" TextMode="MultiLine" placeholder="Enter Contents" Height="121px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtContents" ErrorMessage="Please Enter Contents Name" ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 10px">
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1" style="text-align: left; width: 168px;">
                                                                <asp:Label ID="lblquantity" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="11pt" Text="No/Quantity"></asp:Label>
                                                            </td>
                                                            <td style="width: 10%; text-align: left">
                                                                <asp:TextBox ID="txtQuantity" runat="server" Width="389px" Height="25px" placeholder="Enter Quantity"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Please Enter Quantity" ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 10px">
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1" style="text-align: left; width: 168px;">
                                                                <asp:Label ID="lblTimeRequired" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="11pt" Text="Time Required"></asp:Label>
                                                            </td>
                                                            <td style="width: 10%; text-align: left">
                                                                <asp:TextBox ID="txtTimeRequired" runat="server" Width="389px" Height="25px" placeholder="Enter Time in Hour"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTimeRequired" ErrorMessage="Please Enter Time Required" ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 10px">
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1" style="text-align: left; width: 168px;">
                                                                <asp:Label ID="lblDate" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="11pt" Text="Select Date"></asp:Label>
                                                            </td>
                                                            <td style="width: 10%; text-align: left">
                                                                <asp:TextBox ID="txtDate" runat="server" Width="389px" Height="25px" placeholder="Select Date"></asp:TextBox>
                                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" Format="yyyy-MM-dd">
                                                                </asp:CalendarExtender>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDate" ErrorMessage="Please Select Date" ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 10px">
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1" style="text-align: left; width: 168px;">
                                                                <asp:Label ID="lblWorkAssignTo" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="11pt" Text="Select Work Assign To"></asp:Label>
                                                            </td>
                                                            <td style="width: 10%; text-align: left">
                                                                <asp:DropDownList ID="ddlWorkAssignTo" runat="server" AutoPostBack="true" Height="25px" Width="389px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlWorkAssignTo" ErrorMessage="Please Select Work Assign To" ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 10px">
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1" style="text-align: left; width: 168px;">
                                                                <asp:Label ID="lblWorkStatus" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="11pt" Text="Select Work Status"></asp:Label>
                                                            </td>
                                                            <td style="width: 10%; text-align: left">
                                                                <asp:DropDownList ID="ddlWorkStatus" runat="server" Height="25px" Width="389px">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">Pending</asp:ListItem>
                                                                    <asp:ListItem Value="2">Continued</asp:ListItem>
                                                                    <asp:ListItem Value="3">Partial</asp:ListItem>
                                                                    <asp:ListItem Value="4">complete</asp:ListItem>
                                                                    <asp:ListItem Value="5">Proposed</asp:ListItem>
                                                                    <asp:ListItem Value="6">Dismissed</asp:ListItem>
                                                                    <asp:ListItem Value="7">Cancled</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlWorkStatus" ErrorMessage="Please Select Work Status" ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 10px">
                                                            <td></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1" style="text-align: left; width: 168px;">
                                                                <asp:Label ID="lblCurrentStatus" runat="server" Font-Bold="true" ForeColor="Blue" Visible="false" Font-Names="Arial" Font-Size="11pt" Text="Select Current Status"></asp:Label>
                                                            </td>
                                                            <td>
                                                          <asp:DropDownList ID="ddlCurrentStatus" runat="server" Visible="false" Height="25px" Width="389px">
                                                                     <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1">Pending</asp:ListItem>
                                                                    <asp:ListItem Value="2">Continued</asp:ListItem>
                                                                    <asp:ListItem Value="3">Partial</asp:ListItem>
                                                                    <asp:ListItem Value="4">complete</asp:ListItem>
                                                                    <asp:ListItem Value="5">Proposed</asp:ListItem>
                                                                    <asp:ListItem Value="6">Dismissed</asp:ListItem>
                                                                    <asp:ListItem Value="7">Cancled</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td></tr>
                                                         <tr style="height: 10px">
                                                            <td></td>
                                                        </tr>                                                         
                                                        <tr>
                                                            <td class="auto-style1" style="text-align: left; width: 168px;">
                                                                <asp:Label ID="lblRemark" runat="server" Font-Bold="true" ForeColor="Blue" Visible="false" Font-Names="Arial" Font-Size="11pt" Text="Remark"></asp:Label>
                                                                 </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtRemark" Visible="false" TextMode="MultiLine" Height="50px" Width="389px"/>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>.</td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtParentId" Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </caption>
                                                </table>
                                                <br />
                                                <div style="margin-left: 317px; height: 17px;">
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn"  Visible="false" ValidationGroup="B" Height="28px" Width="80px" OnClick="btnSave_Click"/>
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" OnClick="btnSubmit_Click" ValidationGroup="B" Height="28px" Width="80px" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <%--<asp:Button ID="btnExportToExcel" runat="server" Text="ExportToExcel" CssClass="btn" OnClick="" />--%>
                                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn" Visible="false" ValidationGroup="B" Height="28px" Width="80px" OnClick="btnUpdate_Click" />
                                                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn" Visible="true" ValidationGroup="B" Height="28px" Width="80px" OnClick="btnClear_Click" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnReport" runat="server" Text="Report" CssClass="btn" Visible="true" ValidationGroup="B" Height="28px" Width="80px" OnClick="btnReport_Click" />
                                                </div>
                                                <br />
                                                <div class="SpcBwnBtnAndGv" align="center">
                                                    <asp:Label ID="lbltotalCount" runat="server" Visible="false" Text="Total Records :" Font-Bold="True"></asp:Label><asp:Label ID="lblCount" runat="server" Visible="false" Font-Bold="true" Font-Size="14pt"></asp:Label>
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    <asp:Label ID="lblTotalUpdated" Visible="false" runat="server" Font-Bold="true" Font-Size="14pt" BorderColor="Red"></asp:Label>
                                                </div>

                                                <div align="center">
                                                    <asp:GridView ID="WorkreportGv" runat="server" Width="800px" Font-Size="Large" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="WorkreportGv_PageIndexChanging" CssClass="mGrid" EmptyDataText="Not Found Record." CellPadding="5"
                                                        DataKeyNames="ReportId" DeleteConfirmationText="Are you sure you want to remove this item?" OnRowCancelingEdit="WorkreportGv_RowCancelingEdit" OnRowEditing="WorkreportGv_RowEditing" OnRowUpdating="WorkreportGv_RowUpdating" OnRowDeleting="WorkreportGv_RowDeleting" AutoGenerateSelectButton="false" OnSelectedIndexChanged="WorkreportGv_SelectedIndexChanged">
                                                        <Columns>
                                                             <asp:CommandField HeaderText="Trail" SelectText="Trail" ShowSelectButton="True" />
                                                            <asp:TemplateField HeaderText="Remark">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkRemark" runat="server" OnClick="LinkRemark_Click" CommandArgument='<%#Eval("ReportId") + "," + Eval("ParentId")%>'>Remark</asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:BoundField DataField="ReportId" HeaderText="ID">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="UserMobNo" HeaderText="Work Assign">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ProjectDetails" HeaderText="Subject">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ProjectContents" HeaderText="Contents">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ProjectTime" HeaderText="Time">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ProjectDate" HeaderText="Date">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ProjectQuantity" HeaderText="No of Quantity">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ProjectWork" HeaderText="Work Status">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ParentId" HeaderText="ParentId">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                           
                                                        </Columns>
                                                    </asp:GridView>
                                                    <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                                </div>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <%-- <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
        </Triggers>--%>
    </asp:UpdatePanel>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            $("#<%=txtDate.ClientID %>").datepicker({ dateFormat: 'yy-mm-dd' });
         });
    </script>

</asp:Content>
