<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DefaultOld.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link rel="SHORTCUT ICON" href="favicon.ico" />
  
   
<meta name="Description" content="Come2MyCity, Welcome to All India Mobile Directory Users Association, 
Make your friend groups and send free SMS, Free membership." />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

<meta name="keywords" content="Send free SMS, Free membership, unlimited free sms, Share your profile with your friends and relatives, 
Mobile Directory, social networking sites, Best social networking sites, Good social networking sites, social networking sites,
social networking websites, best social networking websites, easy update profile, mobile dictionary for india, Bulk SMS, Unlimited SMS, 
send free messages, send free messages from your mobile, send unlimited free messages, send messages, Make frineds, send free message without registration,
social networking site, Best social networking site, Good social networking site, social networking site, free social networking site,
Offline free SMS, offline free message, offline social networking, offline social networking registration, use 09243100142,09243100142, use 9243100142, 9243100142,
Find friends, First Mobile Directory of India, bhushan wagh, free for all indians, social networking company, social network, social networking pune, come2mycity,
social networking company pune, pune social networking, mumbai social networking, social networking mumbai, my city, come to my city,
let's SMS, let's Message, अखिल भारतीय मोबाईल डिरेक्टरी, मित्रांना आपल्या समूहात जोडा, नातेवाईकाला तुमच्या यादीत जोडा,  नातेवाईकाला आपल्या समूहात जोडा, मित्रांना तुमच्या यादीत जोडा, 
समूहात नोंदणी करण्यासाठी, फ्री SMS ची सुविधा, पुणे सोसीअल नेटवर्क, मुंबई सोसीअल नेटवर्क, संदेश पाठवा , अमर्याद संदेश पाठवा, अमर्याद SMS  पाठवा, कम २ माय सिटी, माय ct , 
मोफत संदेश पाठवा, समूहाला SMS  पाठवण्यासाठी, इलेक्ट्रिक बिल दर महिन्याला तुमच्या मोबाईल वर मिळवा, इलेक्ट्रिक बिल आता तुमच्या मोबाईल वर. " />
<meta name="Author" content="EzeesoftIndia pune India" />

   
   
    <link href="CSS/Maincss.css" rel="stylesheet" type="text/css" />
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
    <title>::MyCT.In : Home Page::</title>
       
    <style type="text/css">
        .style1
        {
            width: 329px;
        }
      
    </style>
       
</head>
<body style="padding-left: 10px; padding-right: 10px;background-color:#3b5998 " >
    <form id="form2" runat="server" defaultbutton="Login">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td style="width: 100%; padding: 5px; background-color:#3b5998;">
              <table cellpadding="0" cellspacing="0" border="0" width="100%" >
                    <tr>
                        <td style="height:100px; padding: 0px;" >
                        <%--Heading start here--%>
                        
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="background-color:#3b5998";>
  <tr>
    <td><img src="images/Come2myCity.gif" width="239" height="65" alt="" /></td>
    <td></td>
  </tr>
</table>
                </td></tr>
           
             <%--blanck start here--%>
            
                  <%--Menu start here--%>  
                    <tr>
                        <td style="height:40px; text-align:right; vertical-align:middle;
                            background-image: url(images/menuBg.png); background-repeat: repeat-x;
                             ">
                       
                        <table cellpadding="0" cellspacing="0" border="0" >
                        <tr>
                        <td class="menu" style="font-size:17px" >Welcome to All India Mobile Directory Users 
                            Association</td>
                        </tr>
                        </table>
                       
                        </td>
                    </tr>
                    
                     <tr>
                        <td  style="width:100%; background-color:#3b5998;" >
                        <table cellpadding="0" cellspacing="0" border="0" width="100%" style="background-image: url(images/myct.png);
                         background-repeat:repeat-x; background-color:#fafbfd">
                        <tr>
                        <%--Left Menu--%>
                       
                        <td style="vertical-align:top;padding:10px;" class="style1">
                            
                            
                            
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table border="0" style="border-width: thin;background-repeat:no-repeat;
                                        display: block; height: 149px;" cellpadding="2" 
                                        cellspacing="2" class="style1">
                                        <tr>
                                            <td colspan="2" class="lblLogin">
                                                Select your City
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; padding-left: 20px; width: 30%;" class="lbl">
                                                State
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="ddlState" runat="server" Width="140px" ValidationGroup="city"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="city" runat="server"
                                                    ErrorMessage="Select State" Display="None" ControlToValidate="ddlState" InitialValue=""></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; padding-left: 20px;" class="lbl">
                                                District
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="ddlDistrict" runat="server" ValidationGroup="city" Width="140px"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="city" runat="server"
                                                    ErrorMessage="Select District" Display="None" ControlToValidate="ddlDistrict"
                                                    InitialValue=""></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; padding-left: 20px;" class="lbl">
                                                City
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:DropDownList ID="ddlCity" runat="server" ValidationGroup="city" Width="140px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="city" runat="server"
                                                    ErrorMessage="Select City" Display="None" ControlToValidate="ddlCity" InitialValue=""></asp:RequiredFieldValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lbl">
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Button ID="btnSearch" Text="Search" ValidationGroup="city" CssClass="button"
                                                    runat="server" OnClick="btnSearch_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            
                            
                            <hr style="width: 325px" />
                            
                            
                            
                            <table border="0" style="border-width: thin; display: block;" cellpadding="2" cellspacing="2" class="style1">
                                <tr>
                                    <td colspan="2" class="lblLogin">
                                        Login Here                                     </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="lblLogin">
                                                                            <asp:Label ID="lblMsg" runat="server" CssClass="Error"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="lbl">
                                        Mobile Number
                                      
                                        
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox runat="server"  CssClass="text" ValidationGroup="login"  ID="txtUserId"
                                         ></asp:TextBox>
                                          
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="login"
                                            runat="server" ErrorMessage="Enter Mobile No" Display="None" ControlToValidate="txtUserId"
                                            InitialValue="">
                                        </asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RequiredFieldValidator4">
                                        </asp:ValidatorCalloutExtender>
                                         <asp:FilteredTextBoxExtender ID="fteFirstNameDisplay" runat="server" TargetControlID="txtUserId" ValidChars=" " FilterType="Numbers">
                                         </asp:FilteredTextBoxExtender>
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl">
                                        Password        </td>
                                    <td style="text-align: left;">
                                        <asp:TextBox CssClass="text" ValidationGroup="login" ID="txtPassword"
                                            TextMode="Password" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="login"
                                            runat="server" ErrorMessage="Enter Password" Display="None" ControlToValidate="txtPassword"
                                            InitialValue=""></asp:RequiredFieldValidator>
                                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator5">
                                        </asp:ValidatorCalloutExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl">
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:Button ID="Login" ValidationGroup="login" Text="Login" CssClass="button" runat="server"
                                            onclick="Login_Click" /> &nbsp;
                                             <asp:Button ID="Register" Text="Register Here" 
                                            CssClass="button" runat="server"
                                             onclick="Register_Click" />
                                        
                                            
                                    </td>
                                </tr>
                                <tr>
                                    <td class="lbl" align="left">
                                        <asp:CheckBox ID="CheckBox1" runat="server" TextAlign="Left" />
                                    </td>
                                    <td style="text-align: left;" class="lbl">
                                        Stay signed in&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <a href="Html/PasswordRecover.aspx">Forget password ?</a>
                                    </td>
                                </tr>
                            </table>
                            
                            
                            
                                                        
                            
                            <hr style="width: 325px" />
                            
                            
                            
                            
                            <table border="0" style="border-width: thin; width: 112%;
                                display: block;" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="center">
                                      

                                      
                                      
                                     <%-- <script type="text/javascript">
AC_FL_RunContent( 'codebase','http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0','width','300','height','75','src','images/numbers','quality','high','pluginspage','http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash','movie','images/numbers' ); //end AC code
</script>--%>

<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0" width="300" height="75">
  <param name="movie" value="images/numbers.swf" />
  <param name="quality" value="high" />
  <embed src="images/numbers.swf" quality="high" pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash" type="application/x-shockwave-flash" width="300" height="75"></embed>
</object>

                                      

                                      </td>
<td> 
<a href="Logcode.aspx">
<img src="images/lt_new.gif" alt=""/>
</a> 
</td>
                                </tr>
                               
                                
                              
                                
                            </table>
                            
                            
                            
                            
                            </td>
                        <td style="width:70%; vertical-align:top;padding:10px;">
                  
               <h2>
                    <span style="text-align: center; padding-left: 50px;" class="alwaysfree">
                       Always Free for All Indian
                    </span>
                </h2>
                <span class="para2">
                <ul>
                    <li>Self updated Mobile and Phones directory of the people by the people for the 
                        people.</li>
                    <li>Directory of all cities of India</li>
                    <li>Free membership</li>
                    <li>Now use &quot;www.myct.in&quot; website facilities from mobile just by sending 
simple SMS to <img src="images/right_arr.gif" alt="" />
<a href="Logcode.aspx">09243100142 </a>
<img src="images/Left_arr.gif" alt="" /></li>
                    <li>Provision of limited free sms.</li>
                    <li>Provision of printing up-to date labels of friends and relatives for any 
                        invitation</li>
                    <li>Share your profile with your friends and relatives.</li>
                    <li>Register your friends and relatives and invite them to join all India Mobile 
                        Directory.</li>
                    <li>Self change of your address gives automatic update to all your friends and 
                        relatives and to all Indian also.</li>
                    <li>Define your groups of friends</li>
                    
                    <li>Add your any friend in one or more group.</li>
                    <li>Easily change the city to see all details of any city and Mobile Directory of 
                        that city. </li>
                </ul>
                        </span>
                        </td>
                        </tr>
                        </table>
                        
                        </td>
                    </tr>
                    <tr>
    <td style="height:20px; background-image: url(images/menuBg.png);
    background-repeat:repeat-x;" class="footer">

  
   <div style="width:200px; float:right; text-align:right;" class="agency">
   <a href="MarketingAdmin/Login.aspx" class="agency">Agency Login</a> </div>
   <div style="width:500px;color:White;font-family: Cambria ;" >
   Copyright &copy;2010 . All rights are reserved Developed by eZee Soft India
                               
                                </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
           
           
        
    </form>
</body>
</html>














