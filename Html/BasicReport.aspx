<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="BasicReport.aspx.cs" Inherits="Html_BasicReport" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="MainDiv">
        <div class="innerdiv">
            <div align="center" class="style1" style="background-color: #87CEFA;">
                <span id="Span2" class="spanTitle" runat="server">Basic Report</span>
            </div>
            <hr />
            <div style="width: 95%; margin-left: 5%;">
                <div style="width: 19.7%; text-align: center; float: left; background-color: #BFF7EE;
                    border: 2px outset;">
                    <asp:LinkButton ID="lnkMemList" runat="server" OnClick="lnkMemList_Click">Member 
                    List</asp:LinkButton>
                </div>
                <div style="width: 19.7%; text-align: center; float: left; background-color: #BFF7EE;
                    border: 2px outset;">
                    <asp:LinkButton ID="lnkLoanIssued" runat="server" OnClick="lnkLoanIssued_Click">Loan 
                    Issued</asp:LinkButton>
                </div>
                <div style="width: 19.7%; text-align: center; float: left; background-color: #BFF7EE;
                    border: 2px outset;">
                    <asp:LinkButton ID="lnkInstal" runat="server" OnClick="lnkInstal_Click">Installment</asp:LinkButton>
                </div>
                <div style="width: 19.7%; text-align: center; float: left; background-color: #BFF7EE;
                    border: 2px outset;">
                    <asp:LinkButton ID="lnkDeposite" runat="server" OnClick="lnkDeposite_Click">Deposite</asp:LinkButton>
                </div>
                <div style="width: 19.7%; text-align: center; float: right; background-color: #BFF7EE;
                    border: 2px outset;">
                    <asp:LinkButton ID="lnkExp" runat="server" OnClick="lnkExp_Click">Expenditure</asp:LinkButton>
                </div>
            </div>    
            <hr />
            <br />
            <br />        
            <asp:MultiView ID="MultiView1" runat="server" OnActiveViewChanged="MultiView1_ActiveViewChanged">
                <asp:View ID="View1" runat="server">
                    <div class="tblSubFull2">                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
                        Select date :
                        <asp:TextBox ID="txtdate" runat="server" Width="100px" AutoPostBack="true"></asp:TextBox>
                        <asp:Image ID="Image2" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                            runat="server" />
                        <asp:CalendarExtender ID="CEBD" PopupButtonID="Image2" runat="server" Format="yyyy-MM-dd"
                            TargetControlID="txtdate" Enabled="True"></asp:CalendarExtender>
                    </div>
                    <br />
                    <div class="tblSubFull2">
                    <div style="background-color:#BFF7EE">
                        <b>Member List</b>
                    </div>
                    <br />
                        <div style="height: 200px; border: 1px solid #dddddd; padding-left:15%;">
                        <br />
                            <asp:GridView ID="gvItem" runat="server" AutoGenerateColumns="False" 
                                BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                                CellPadding="3" CellSpacing="2" AllowPaging="true" 
                                onpageindexchanging="gvItem_PageIndexChanging" PageSize="1">
                                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                <Columns>
                                 <asp:TemplateField HeaderText="Sr.No">
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
                                </Columns>
                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                            </asp:GridView>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server" OnActivate="View2_Activate">
                <%--<br />--%>
                    <div class="tblSubFull2">
                    <div style="background-color:#BFF7EE">
                        <b>Issued Loan</b>
                    </div>
                    <table class="tblSubFull2">
                        <tr>
                            <td>
                                <div style="overflow: scroll; height: 200px; border: 1px solid #dddddd;padding-left:15%;"">
                                 <br />
                                    <asp:GridView ID="gvItemLoan" runat="server" AutoGenerateColumns="False" AllowPaging="True" 
                                        DataKeyNames="ID" onpageindexchanging="gvItemLoan_PageIndexChanging" 
                                        BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="3" CellSpacing="2">
                                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                        <Columns>
                                         <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                 <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                          
                                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                            <asp:BoundField DataField="MID" HeaderText="MID" />
                                            <asp:BoundField DataField="LoanAmt" HeaderText="LoanAmt" />
                                            <asp:BoundField DataField="DateOfIssue" HeaderText="DateOfIssue" />
                                            <asp:BoundField DataField="MInstalment" HeaderText="MInstalment" />
                                            <asp:BoundField DataField="DueDate" HeaderText="DueDate" />
                                        </Columns>
                                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
                                </div>
                                <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <table class="tblSubFull2">
                        <tr>
                            <td>
                                <div style="height: 200px; border: 1px solid #dddddd;">
                                 <br />
                                    <asp:GridView ID="gvItemInst" runat="server" AutoGenerateColumns="False" 
                                        DataKeyNames="ID" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" 
                                        BorderWidth="1px" CellPadding="3" CellSpacing="2" AllowPaging="true" PageSize="5" 
                                        onpageindexchanging="gvItemInst_PageIndexChanging">
                                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                        <Columns>
                                         <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                 <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                            <asp:BoundField DataField="MID" HeaderText="MID" />
                                            <asp:BoundField DataField="SubAmt" HeaderText="SubAmt" />
                                            <asp:BoundField DataField="LInstalment" HeaderText="LInstalment" DataFormatString="{0:MM/dd/yyyy}" />
                                            <asp:BoundField DataField="LIMonth" HeaderText="LIMonth" />
                                            <asp:BoundField DataField="Date" HeaderText="Date" />
                                        </Columns>
                                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
                                </div>
                                <asp:Label ID="lblId" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View4" runat="server">
                    <table class="tblSubFull2">
                        <tr>
                            <td>
                                <div style="overflow: scroll; height: 200px; border: 1px solid #dddddd;">
                                    <asp:GridView ID="gvItemDeposite" runat="server" AutoGenerateColumns="False" 
                                        DataKeyNames="ID" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" AllowPaging="true" PageSize="5" 
                                        BorderWidth="1px" CellPadding="3" CellSpacing="2" onpageindexchanging="gvItemDeposite_PageIndexChanging"
                                        >
                                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                        <Columns>
                                         <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                 <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                            <asp:BoundField DataField="MID" HeaderText="MID" />
                                            <asp:BoundField DataField="DepositPeriod" HeaderText="DepositPeriod" />
                                            <asp:BoundField DataField="DepositeAmt" HeaderText="DepositeAmt" />
                                            <asp:BoundField DataField="PaymentType" HeaderText="PaymentType" />
                                            <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}" />
                                        </Columns>
                                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
                                </div>
                                <asp:Label ID="Label2" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="View5" runat="server">
                    <table class="tblSubFull2">
                        <tr>
                            <td>
                                <div style=" height: 200px; border: 1px solid #dddddd;">
                                    <asp:GridView ID="gvItemExp" runat="server" AutoGenerateColumns="False" 
                                        DataKeyNames="ID" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" 
                                        BorderWidth="1px" CellPadding="3" CellSpacing="2" onpageindexchanging="gvItemExp_PageIndexChanging"
                                        >
                                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr.No">
                                                <ItemTemplate>
                                                 <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                                            <asp:BoundField DataField="Date" HeaderText="Date" />
                                            <asp:BoundField DataField="VoucharNo" HeaderText="VoucharNo" />
                                            <asp:BoundField DataField="TypeOfExp" HeaderText="TypeOfExp" />
                                            <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                            <asp:BoundField DataField="Description" HeaderText="Description" />
                                            <asp:BoundField DataField="Mode" HeaderText="Mode" />
                                        </Columns>
                                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
                                </div>
                                <asp:Label ID="Label3" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>
