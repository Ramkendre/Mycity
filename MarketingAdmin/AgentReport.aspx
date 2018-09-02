<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="AgentReport.aspx.cs" Inherits="MarketingAdmin_AgentReport" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" width="100%" border="1">
        <tr>
            <td align="center">
                <div>
                    <table class="tblAdminSubFull1">
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Label ID="lblHeader" runat="server" Text="Agent Report" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="text-align: left; width: 150px;">
                                <asp:Label ID="lblselectagent" runat="server" Text="Select Agent:"></asp:Label>
                            </td>
                            <td align="center" style="text-align: left; width: 190px">
                                <asp:DropDownList ID="ddlselectAgent" runat="server" Width="150px">  
                                   
                                    
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: left" colspan="2">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                        
                        <tr>
                            <td align="center" style="text-align: left; width: 150px;">
                                &nbsp;</td>
                            <td align="center" style="text-align: left; width: 190px">
                                &nbsp;</td>
                            <td style="text-align: left" colspan="2">
                                &nbsp;</td>
                        </tr>
                        
                        <tr>
                            <td align="center" style="text-align: left; width: 150px;">
                                <asp:Label ID="lblName" runat="server" ForeColor="#006666"></asp:Label>
                            </td>
                            <td align="center" style="text-align: left; width: 190px">
                                <asp:Label ID="lblContactNo" runat="server" ForeColor="#006666"></asp:Label>
                            </td>
                            <td style="text-align: left" colspan="2">
                                <asp:Label ID="lblMiscalNo" runat="server" ForeColor="#006666"></asp:Label>
                            </td>
                        </tr>
                        
                        <tr>
                            <td align="center" style="text-align: left; width: 150px;">
                                &nbsp;</td>
                            <td align="center" style="text-align: left; width: 190px">
                                &nbsp;</td>
                            <td style="text-align: left" colspan="2">
                                &nbsp;</td>
                        </tr>
                        
                        <tr align="center">
                            <td colspan="4">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                    EmptyDataText="No Report" CssClass="mGrid" Width="100%" AllowPaging="true" 
                                    PageSize="5" onpageindexchanging="GridView1_PageIndexChanging" 
                                    onrowcommand="GridView1_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="Id">
                                            <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ResponseMsg" HeaderText="Message">
                                            <HeaderStyle HorizontalAlign="Center" Width="70%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="70%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MsgDate" HeaderText="Message Created">
                                            <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Report">
                                        <ItemTemplate>
                                            <asp:Button ID="btnCalculate" runat="server" Text="Calculate" CommandArgument='<%#Eval("Id") %>' CommandName="Calculate" CssClass="button" />
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:Label ID="lblId" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="4" style="height: 23px">
                                <%--<asp:Button ID="btnBack" runat="server" CssClass="button" Text="Back" OnClick="btnBack_Click" />--%>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="width: 150px; text-align: left; height: 23px">
                                <asp:Label ID="lblCount" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="text-align: left; height: 23px">
                                <asp:Label ID="lblMsgttlcount" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="text-align: left; width: 150px; height: 23px">
                                &nbsp;</td>
                            <td style="text-align: left; height: 23px">
                                &nbsp;</td>
                        </tr>
                        <tr align="center">
                            <td style="width: 150px; text-align: left; height: 23px">
                                <asp:Label ID="lblusercount" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="text-align: left; height: 23px">
                                <asp:Label ID="lblCalculation" runat="server" ForeColor="Red" 
                                    style="text-align: center"></asp:Label>
                            </td>
                            <td style="text-align: left; width: 150px; height: 23px">
                                &nbsp;</td>
                            <td style="text-align: left; height: 23px">
                                &nbsp;</td>
                        </tr>
                        <tr align="center">
                            <td colspan="4" style="text-align: center; height: 23px">
                                &nbsp;</td>
                        </tr>
                        <tr align="center">
                            <td colspan="4" style="height: 23px">
                                &nbsp;</td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
