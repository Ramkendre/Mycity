<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="AboutUs.aspx.cs" Inherits="UI_AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .tit-sty
        {
            font-family: Trebuchet MS, Arial, Helvetica, sans-serif;
            font-size: 18px;
            color: Navy;
        }
        .faq
        {
            font: bold 11px Verdana, Arial, Helvetica, sans-serif;
            color: Navy;
        }
        .para
        {
            font-family: Trebuchet MS, Arial, Helvetica, sans-serif;
            color: Black;
            list-style: square inside;
            font-size: 13px;
            text-align: justify;
        }
    </style>
    <div class="MainDiv">
        <div class="InnerDiv">
            <table  align="center" cellpadding="0" cellspacing="0" style="background-color: White;">
                <tr>
                    <td width="100%" align="left" class="tit-sty" style="border-bottom-color: #3b5998;
                        border-bottom-style: solid; border-bottom-width: 1px;">
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <img src="../images/about_US.gif" alt="About Us">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table>
                            <tr>
                                <td>
                                    <span >We are the first to offer FREE sms as well as Social Networking
                                        together at one portal.</span><br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>com offers its users a platform to send FREE sms to only those friends
                                        & Relatives who are registered with Come2myCity across India.</span><br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span>Mobile users can register at absolutely no cost with com, and start
                                        sending out text messages to their friends and relatives ones across the country.
                                        Receivers of the messages need to be registered Come2MyCity users. </span>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="tit-sty">The com website is operated by:</span>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="para">
                               EzeeSoftIndia, Abhinav IT Solution Pvt Ltd ,Pune
                                 
                            </tr>
                            <tr>
                                <td align="left" class="para1">
                                    Anand Nagar, Paud Road, Pune - 38 ne - 38
                                    <br />
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="tit-sty" style="border-bottom-color: #53a21e;
                                    border-bottom-style: solid; border-bottom-width: 1px;">
                                    <%--<a href= "http://www.ezeesoftindia.com/htmlsite/About.aspx" > About EzeeSoftIndia </a>--%>
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">About EzeeSoftIndia</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
