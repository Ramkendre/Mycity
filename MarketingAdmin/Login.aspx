<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingLogin.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="MarketingAdmin_Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <asp:UpdatePanel ID="updatepanel1" runat="server" ><ContentTemplate>
            
         <div class="loginPannelMain"> 
         
         <div class="loginImageMain">
       
        <div class="loginLable"><asp:Label ID="lblMsg" runat="server" CssClass="Error"></asp:Label></div>
  
        <div class="loginTextBoxUses">  <asp:TextBox class="textboxLoginPannel" ValidationGroup="login" 
              ID="txtUserId" runat="server" BackColor="#033A8D" BorderStyle="None" 
                BorderWidth="0px" ForeColor="White"></asp:TextBox>
               
                          
                              <asp:TextBoxWatermarkExtender ID="mobile" runat ="server"  WatermarkText="Enter User Name" TargetControlID ="txtUserId" WatermarkCssClass ="watermarked"></asp:TextBoxWatermarkExtender>
                          </div>
        <div class="loginTextBoxPassword"><asp:TextBox class="textboxLoginPannel" ValidationGroup="login"  ID="txtPassword"
               TextMode="Password" runat="server"></asp:TextBox></div>
               
         <div class="loginpannelLoginButton">              
          
                                            
                   <asp:ImageButton ID="Login" ValidationGroup="login" runat="server" 
                       ImageUrl="~/images/loginButton.jpg" onclick="Login_Click1" />&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:ImageButton id="btnReset" runat="server" 
                       ImageUrl="~/images/Reset.jpg" onclick="btnReset_Click" />
                   </div>
         </div>
         
         <div class="loginvalidation">      
         
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="login"
                                            runat="server" ErrorMessage="Enter User Name" Display="None" ControlToValidate="txtUserId"
                                            InitialValue=""></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2">
                                        </asp:ValidatorCalloutExtender>
        
         <br /><br /><br />
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="login"
                                            runat="server" ErrorMessage="Enter Password" Display="None" ControlToValidate="txtPassword"
                                            InitialValue=""></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator1">
                                        </asp:ValidatorCalloutExtender>
         
         
         
         
         
         </div>
         </div>
               
            
           

    </ContentTemplate></asp:UpdatePanel>   
            
</asp:Content>

