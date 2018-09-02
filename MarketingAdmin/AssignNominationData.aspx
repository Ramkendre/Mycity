<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="AssignNominationData.aspx.cs" Inherits="MarketingAdmin_AssignNominationData" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                                                <table style="width: 81%; margin-left: 148px;" class="tables" cellspacing="2" cellpadding="2">
                                                    <tr>
                                                        <td colspan="2" align="center" style="text-align: center; font-size: x-large; font-family: 'Times New Roman', Times, serif;">
                                                            <h3 style="color: Green; margin-left: 200px;">Assign Nomination</h3>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td colspan="3">
                                                            <span class="warning1" style="color: red; ">Fields marked with * are mandatory.</span>
                                                        </td>
                                                    </tr>
                                                     <tr align="center">
                                                        <td colspan="3" align="center">
                                                            <asp:Label ID="lblError" runat="server" Visible="false" style="color: red; font-size:21px"></asp:Label>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td style="text-align: Center; width: 210px;" class="auto-style1">
                                                            <asp:Label ID="lblSelectDistrict" runat="server" Font-Bold="true" Font-Names="Arial"
                                                                Font-Size="11pt" Text="Select District"></asp:Label>
                                                            <span class="warning1" style="color: Red;">*&nbsp;</span>
                                                        </td>
                                                        <td style="width: 628px; text-align: left">
                                                            <asp:DropDownList ID="ddldistrict" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <caption>
                                                        <br />
                                                        <tr>
                                                            <td class="auto-style1" style="width: 210px"></td>
                                                            <td align="left" style="width: 37%; text-align: center"></td>
                                                            <td></td>
                                                        </tr>
                                                        <div class="Space">
                                                        </div>
                                                        <tr>
                                                            <%-- <td style="width:5%; text-align:right">
                                                                <asp:Label ID="lblshwField" runat="server" Text="Show Field" Font-Bold="true" Font-Names="Arial" Font-Size="11pt">
                                                                </asp:Label>
                                                            </td>--%>
                                                            <td class="auto-style1" style="text-align: center; width: 210px;">
                                                                <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="11pt" Text="Select Junior Name"></asp:Label>
                                                            </td>
                                                            <td style="width: 10%; text-align: left">
                                                                <asp:DropDownList ID="ddlRepresentative" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRepresentative_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbljrName" runat="server" Text="" Visible="false"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlRepresentative" ErrorMessage="Please Select junior Name." ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <%-- <td style="width:5%; text-align:right">
                                                                <asp:Label ID="lblshwField" runat="server" Text="Show Field" Font-Bold="true" Font-Names="Arial" Font-Size="11pt">
                                                                </asp:Label>
                                                            </td>--%>
                                                            <td class="auto-style1" style="text-align: center; width: 210px;">
                                                                <asp:Label ID="lblbPincode" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="11pt" Text="Select Pin Code"></asp:Label>
                                                            </td>
                                                            <td style="width: 10%; text-align: left">
                                                                <asp:DropDownList ID="ddlpincode" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlpincode_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlpincode" ErrorMessage="Please Select Pin Code" ValidationGroup="B">*</asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                    </caption>
                                                </table>
                                                <br />
                                                <div class="SpcBwnBtnAndGv" align="center">
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn" OnClick="btnSubmit_Click" ValidationGroup="B" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnExportToExcel" runat="server" Text="ExportToExcel" CssClass="btn" OnClick="btnExportToExcel_Click" />
                                                </div>
                                                <div class="SpcBwnBtnAndGv" align="center">
                                                    <asp:Label ID="lbltotalCount" runat="server" Visible="false" Text="Total Records :" Font-Bold="True"></asp:Label><asp:Label ID="lblCount" runat="server" Visible="false" Font-Bold="true" Font-Size="14pt"></asp:Label>
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    <asp:Label ID="lblTotalUpdated" Visible="false" runat="server" Font-Bold="true" Font-Size="14pt" BorderColor="Red"></asp:Label>
                                                </div>
                                                
                                                <div align="center">
                                                    <asp:GridView ID="AssignNominationGv" runat="server" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="AssignNominationGv_PageIndexChanging" CssClass="mGrid" EmptyDataText="Not Found Record." CellPadding="5"
                                                         DataKeyNames="RegMobileNo">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Assign">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="ChkAssignNomination" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Id" HeaderText="ID">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                              <asp:BoundField DataField="FirstName" HeaderText="First Name">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                              <asp:BoundField DataField="MiddleName" HeaderText="Middle Name">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="LastName" HeaderText="Last Name">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="RegMobileNo" HeaderText="Mobile No">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="DistrictName" HeaderText="District Name">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="DistrictId" HeaderText="District Id">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>   
                                                            </asp:BoundField>
                                                              <asp:BoundField DataField="LocalBodyName" HeaderText="LocalBody Name">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="pin" HeaderText="Pin Code">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="formtype" HeaderText="formtype">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="electrolDivision" HeaderText="Electrol Division">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Address" HeaderText="Address">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="Assign_Represenatative" HeaderText="Junior MobNo">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                             
                                                        </Columns>
                                                    </asp:GridView>
                                                    <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                                </div>


                                                 <div align="center">
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="mGrid" EmptyDataText="Not Found Record." CellPadding="5"
                                                         DataKeyNames="RegMobileNo">
                                                       <Columns>
                                                            <asp:TemplateField HeaderText="Assign">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="ChkAssignNomination" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Id" HeaderText="ID">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                              <asp:BoundField DataField="FirstName" HeaderText="First Name">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                              <asp:BoundField DataField="MiddleName" HeaderText="Middle Name">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="LastName" HeaderText="Last Name">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="RegMobileNo" HeaderText="Mobile No">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="DistrictName" HeaderText="District Name">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                           <asp:BoundField DataField="DistrictId" HeaderText="District Id">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>   
                                                            </asp:BoundField>
                                                              <asp:BoundField DataField="LocalBodyName" HeaderText="LocalBody Name">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="pin" HeaderText="Pin Code">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="formtype" HeaderText="formtype">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="electrolDivision" HeaderText="Electrol Division">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Address" HeaderText="Address">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="Assign_Represenatative" HeaderText="Junior MobNo">
                                                                <asp:HeaderStyle HorizontalAlign="Center" Width=""></asp:HeaderStyle>
                                                                <asp:ItemStyle HorizontalAlign="Center" Width=""></asp:ItemStyle>
                                                            </asp:BoundField>
                                                             
                                                        </Columns>
                                                    </asp:GridView>
                                                    <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
                                                </div>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                    </td>
                </tr>
            </table>
      </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportToExcel" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

