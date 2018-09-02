<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="SecReport.aspx.cs" Inherits="Html_SecReport" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="MainDiv">
        <div class="InnerDiv">
            <div align="center" class="style1" style="background-color: #87CEFA;">
                <%--<img src="../KResource/Images/Loan.jpg" width="40px" height="30px" />--%>
                <span id="Span2" class="spanTitle" runat="server">Secretary Report</span>
            </div>
            <hr />
            <table class="tblSubFull2">
                <tr>
                    <td align="right">
                        Select Member
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlSMember" runat="server" Width="165px" Height="25px" OnSelectedIndexChanged="ddlSMember_SelectedIndexChanged"
                            AutoPostBack="true">
                            <asp:ListItem>aaa</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCal" runat="server" Text="Simple Intrest"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <div style="height: 200px; border: 1px solid #dddddd;">
                            <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="Event No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="MID" HeaderText="MID" Visible="false" />
                                    <asp:BoundField DataField="GID" HeaderText="GID" />
                                    <asp:BoundField DataField="FName" HeaderText="First Name" />
                                    <asp:BoundField DataField="LName" HeaderText="Last Name" />
                                    <asp:BoundField DataField="MobileNo" HeaderText="Mobile No." />
                                    <asp:BoundField DataField="Post" HeaderText="Post" />
                                    <asp:BoundField DataField="DOJ" HeaderText="Date Of Joining" />
                                    <asp:BoundField DataField="Subscription" HeaderText="Subscription" />
                                    <asp:BoundField DataField="Deposite" HeaderText="Deposite" />
                                    <asp:BoundField DataField="Loan" HeaderText="Loan" />
                                    <asp:BoundField DataField="Cal" HeaderText="SI" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
            <table class="tblSubFull2">
                <tr>
                    <td>
                        <div style="height: 200px; border: 1px solid #dddddd;">
                            <asp:GridView ID="gvItemInst" runat="server" AutoGenerateColumns="False" DataKeyNames="ID">
                                <Columns>
                                    <asp:TemplateField HeaderText="Event No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                    <asp:BoundField DataField="MID" HeaderText="First Name" />
                                    <asp:BoundField DataField="SubAmt" HeaderText="SubAmt" />
                                    <asp:BoundField DataField="LInstalment" HeaderText="LInstalment" DataFormatString="{0:MM/dd/yyyy}" />
                                    <asp:BoundField DataField="LIMonth" HeaderText="LIMonth" />
                                    <asp:BoundField DataField="Date" HeaderText="Date" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <asp:Label ID="lblId" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <div style="height: 200px; border: 1px solid #dddddd;">
                            <asp:GridView ID="gvItemAll" runat="server" AutoGenerateColumns="false" FooterStyle-HorizontalAlign="Center"
                                ShowFooter="true" AllowPaging="true" PageSize="5" OnPageIndexChanging="gvItemAll_PageIndexChanging"
                                OnRowDataBound="gvItemAll_RowDataBound">
                                <Columns>
                                    <%--<asp:TemplateField HeaderText="Event No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FName">
                                        <ItemTemplate><%#Eval("FName")%></ItemTemplate>
                                         <FooterTemplate>
                                        <div><asp:Label  Text="Sum" runat="server"></asp:Label></div>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SubAmt">
                                        <ItemTemplate><%#Eval("SubAmt") %></ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("SubAmt") %>'></asp:Label>
                                            
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="LInstalment">
                                        <ItemTemplate><%#Eval("LInstalment")%></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="LIMonth">
                                        <ItemTemplate><%#Eval("LIMonth")%></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="LoanAmt">
                                        <ItemTemplate><%#Eval("LoanAmt")%></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MInstalment">
                                        <ItemTemplate><%#Eval("MInstalment")%></ItemTemplate>
                                       
                                        
                                    </asp:TemplateField>--%>
                                    <asp:BoundField DataField="FName" HeaderText="FName" />
                                    <%--<asp:BoundField DataField="SubAmt" HeaderText="" />--%>
                                    
                                    <asp:BoundField DataField="LInstalment" HeaderText="LInstalment" />
                                    <asp:BoundField DataField="LIMonth" HeaderText="LIMonth" />
                                    <asp:BoundField DataField="LoanAmt" HeaderText="LoanAmt" />
                                    <asp:BoundField DataField="MInstalment" HeaderText="MInstalment" />
                                    <asp:TemplateField HeaderText="SubAmt">
                                        <ItemTemplate>
                                            <div style="text-align: right;">
                                                <asp:Label ID="lblqty" runat="server" Text='<%#Eval("SubAmt") %>' />
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <div style="text-align: right;">
                                                <asp:Label ID="lblTotalqty" runat="server" />
                                            </div>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <%--
                                    <asp:TemplateField HeaderText="Sum">
                                    <ItemTemplate> <asp:Label ID="lblSum" runat="server" Text="Sum"></asp:Label></ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                                <FooterStyle BackColor="#cccccc" Font-Bold="True" ForeColor="Black" HorizontalAlign="Left" />
	
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
