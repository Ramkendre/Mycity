<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login1.aspx.cs" Inherits="MarketingAdmin_Login1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<script type="text/css" language="javascript">
        // Fork for IE 5.5
        if (window.navigator.appVersion.indexOf("IE 5.5") != -1) {
            document.write("Internet Explorer 5.5")
        }
        // Fork for IE 6.0
        if (window.navigator.appVersion.indexOf("IE 6.0") != -1) {
            document.write("Internet Explorer 6.0")
        }
   </script>
   <script type="text/css" language="javascript">

       // Returns the browser application name 
       // for example, "Microsoft Internet Explorer" or "Netscape"
       document.write(window.navigator.appName);

       // Returns the internal code name of the browser
       // for example, "Mozilla"
       document.write(window.navigator.appCodeName);

       // Returns the version of the browser as a string
       document.write(window.navigator.appVersion);

       // Returns the user agent string for the browser
       document.write(window.navigator.userAgent);

   </script>
<head id="Head1" runat="server">
    <link href="../CSS/broC.css" rel="stylesheet" type="text/css" />
    <title></title>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/Maincss.css" rel="stylesheet" type="text/css" />

    <script src="../Resources/JScript/inputbox.js" type="text/javascript"></script>
  <link href="../resources1/stylesheet/css.css" rel="stylesheet" type="text/css" />
   
</head>
<body style="padding-left: 10px; padding-right: 10px; background-color:#009999">
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td bgcolor="#009999" style="width: 100%; padding: 10px;">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td bgcolor="White" style="height: 100px; padding: 10px;">
                            <%--Heading start here--%>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td class="MainHeading1">
                                        <img src="../HomeImages/myct.png" width="239" height="65" alt=""/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%--blanck start here--%>
                    <tr>
                        <td style="height: 10px;">
                        </td>
     
                    </tr>
                    <%--Menu start here--%>
                    <tr>
                        <td bgcolor="#009999" style="height: 10px; text-align: right; vertical-align: middle;">
                           
                            <asp:Panel ID="pnlUser" runat="server"
                                Height="31px">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                   
                                    <td>
                                   <table>
                                      
                                   
                                       <tr>
                                           <td style="height:33px;">
                                               <a class="menu_M" href="../Default.aspx">My CT</a></td>
                                           <td style="height:33px;">
                                               <a class="menu_M" href="../Html/AboutUs.aspx">About Us</a></td>
                                           <td style="height:33px;">
                                               <a class="menu_M" href= "../Html/ContactUs.aspx">Contact 
                                               Us</a></td>
                                       </tr>
                                   </table>
                                     
                                    
                                    
                                    </td>
                                </tr>
                            </table>
                            </asp:Panel>
                            
                        </td>
                    </tr>
                    <tr>
                        <td style="background-repeat:repeat-x; background-color:#fafbfd; width:100%">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                   
                                    <td style="width: 20%; vertical-align: top; padding: 10px;" colspan="3">
                                     
                                     <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                        </asp:ToolkitScriptManager>
                                         <div class="loginPannelMain" align="center"> 
         
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
                                    
                                    </td>
                                    
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;" class="footer">
                            Copyright @2010 eZeesoftindia. All rights are reserved
                        </td>
                    </tr>
                </table>
        </td></tr>
        </table>
    </form>
</body>
</html>
