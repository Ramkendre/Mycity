<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ALL_Report.aspx.cs" MasterPageFile="~/Master/MainMaster.master" Inherits="MarketingAdmin_ALL_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h3 style="color: Green; margin-left: 200px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Work Report</h3>
    <table align="center">
        <tr>
            <td></td>
            <td>
                <asp:Label ID="lblMsg" Visible="false" runat="server" />
            </td>
        </tr>
          <tr style="height:10px">
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" Text="Employee Name :" runat="server" />
            </td>
            <td>
                <asp:DropDownList ID="drpName" runat="server" Height="25px" Width="200px" AutoPostBack="true">
                    <%--<asp:ListItem Value="0">--Select--</asp:ListItem>--%>
                    <%-- <asp:ListItem Text="rajkumar palve" Value="1" />--%>
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height:10px">
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Project Wise:" ID="lblProjectwise" runat="server" />
            </td>
            <td>
                <asp:DropDownList ID="ddprojectWise" runat="server" Height="25px" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddprojectWise_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr style="height:10px">
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Date Wise:" ID="lblDatewise" runat="server" />
            </td>
            <td>
                <asp:TextBox ID="txtDate" runat="server" Width="200px" Height="25px" placeholder="Select Date"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" Format="yyyy-MM-dd">
                </asp:CalendarExtender>
           </td>
           
        </tr>
         <tr style="height:10px">
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Work Type Wise:" ID="lblWprktypewise" runat="server" />
            </td>
            <td>
                <asp:DropDownList ID="ddlWorktypewise" runat="server" Height="25px" Width="200px" AutoPostBack="true"></asp:DropDownList>
            </td>
        </tr>

         <tr style="height:10px">
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label Text="Status Wise:" ID="lblStatuswise" runat="server" />
            </td>
            <td>
                <asp:DropDownList ID="ddlStatuswise" runat="server" Height="25px" Width="200px" AutoPostBack="true">
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
        </tr>

         <tr style="height:10px">
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button Text="Submit" ID="btnSubmit" runat="server" Width="79px" OnClick="btnSubmit_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button Text="Send Mail" ID="btnSendMail" runat="server" Visible="false"  Width="79px" />
            </td>
        </tr>
    </table>
        <br />
        <br />
    </div>
    <div align="center" style="height: 100%; width: 900px; overflow: auto;">
            <asp:GridView runat="server"  ID="gvReport" CssClass="mGrid" Width="100%"  Font-Size="Medium" AutoGenerateSelectButton="false" OnSelectedIndexChanged="gvReport_SelectedIndexChanged" >
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
        </div>
    </asp:Content>
