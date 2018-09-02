<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="EzeeMarketing.aspx.cs" Inherits="MarketingAdmin_EzeeMarketing" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 
    <p></p>
    <p></p>
    
    <p></p>
    <p></p>
    <p  align ="center"  style = "font-Size:25px; font-style :italic">
        Ezee Marketing 
    </p>

    <p align ="center" > Select User Type : 
    &nbsp&nbsp&nbsp
    <asp:DropDownList ID= "ddlusr" runat ="server" Height="30px" Width="88px">
        <asp:ListItem Text = "User"></asp:ListItem>
        <asp:ListItem Text = "Admin"></asp:ListItem>
        <asp:ListItem Text = "Selected" Selected ="True" ></asp:ListItem>
    </asp:DropDownList> 
    </p>
    <p align ="center" > Enter User Mobile no :  
    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
    <asp:TextBox ID = "txtusrMobileNo" runat = "server" Height="29px" Width="138px" 
            MaxLength="10" ValidationGroup="save"></asp:TextBox>
        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
            runat="server" ControlToValidate="txtusrMobileNo" Display="Dynamic" 
            ErrorMessage="Enter 10 Digit number" ValidationExpression="[0-9]{10}" 
            ValidationGroup="save"></asp:RegularExpressionValidator></p>
    <p align ="center"> 
    <asp:Button ID = "btnsearch" runat ="server" 
            Text = "..Search.." onclick="btnsearch_Click" CssClass = "button" /> 
    &nbsp; &nbsp; &nbsp; 
    <asp:Button ID = "btnFeedback" runat ="server" 
            Text = "..Feedback.." onclick="btnFeedback_Click" CssClass = "button"/> 
            
      &nbsp; &nbsp; &nbsp;       
    <asp:Button ID = "btnOrder" runat ="server" 
    Text = "..Order Details.." onclick="btnOrder_Click" CssClass = "button" /> 


    
    </p>
    <p align ="center" >
        <asp:GridView ID = "gvUse" runat = "server" 
            EmptyDataText = "No Record available" align ="center" CellPadding="4" 
            ForeColor="#333333" Height="133px" GridLines="None">
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </p>
</asp:Content>

