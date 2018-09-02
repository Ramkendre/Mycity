<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="JobSeeker.aspx.cs" Inherits="html_JobSeeker" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <meta http-equiv="refresh" content="15">--%>

  <%--<script type="text/JavaScript">
         <!--
            function AutoRefresh( t ) {
               setTimeout("location.reload(true);", t);
            }
         //-->
    </script>--%>

    <style type="text/css">
        /* Style Sheet Attributes */.ajax__tab_lightblue-theme .ajax__tab_header
        {
            font-family: 'Calibri' , sans-serif;
            font-weight: 500;
            font-size: 16px;
        }
        .ajax__tab_lightblue-theme .ajax__tab_header .ajax__tab_outer
        {
            background-color: #A4DED5;
            margin: 0px 0.16em 0px 0px;
            padding: 1px 0px 1px 0px;
            vertical-align: bottom;
            border-radius: 5px 5px 0px 0px;
        }
        .ajax__tab_lightblue-theme .ajax__tab_header .ajax__tab_tab
        {
            color: #000;
            padding: 0.35em 0.75em;
            margin-right: 0.01em;
        }
        .ajax__tab_lightblue-theme .ajax__tab_hover .ajax__tab_outer
        {
            background-color: #8FBEB7;
        }
        .ajax__tab_lightblue-theme .ajax__tab_active .ajax__tab_tab
        {
            color: #000;
        }
        .ajax__tab_lightblue-theme .ajax__tab_active .ajax__tab_outer
        {
            background-image: #ffffff;
        }
        .ajax__tab_lightblue-theme .ajax__tab_body
        {
            font-family: verdana,tahoma,helvetica;
            font-size: 10pt;
            padding: 0.25em 0.5em;
            background-color: #ffffff;
            border-top-width: 0px;
        }
        .linkPage
        {
            font-family: 'Calibri' , sans-serif;
            font-weight: bold;
            height: 30px;
            font-size: 15px;
            color: #164854;
        }
    </style>
    <div class="MainDiv">
        <div class="InnerDiv">
            <center>
                <br />
                <span class="spanTitle">Job Portal</span>
                <br />
                <hr />
            </center>
            
            <asp:Label ID="MyLabel" runat="server"></asp:Label><br />
            <br />
            
            <table class="tblSubFull2">
                <tr>
                    <td align="left"><%--
                    <asp:ScriptManager ID="ScriptManager1" runat="server" />--%>
          <%--  <div>
                <asp:Timer ID="Timer1"  runat="server" Interval="30000" ontick="Timer1_Tick">
                </asp:Timer>
            </div>
                   --%>     <asp:UpdatePanel ID="UpdatePanel" UpdateMode="Conditional" runat="server">
                           <%-- <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                            </Triggers>--%>
                            <ContentTemplate>
                                <asp:TabContainer runat="server" ID="JobRecruitment" Width="100%" ActiveTabIndex="0"
                                    AutoPostBack="true" CssClass="ajax__tab_lightblue-theme">
                                    <asp:TabPanel runat="server" ID="tabCandidatedetails" Width="100%">
                                        <HeaderTemplate>
                                            Candidate Details
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <hr />
                                            <div>
                                                <table class="tblSubFull2">
                                                    <tr>
                                                        <td align="center" width="100%" colspan="2">
                                                            <h3>
                                                                <center>
                                                                    <span class="spanTitle">Welcome :
                                                                        <asp:Label ID="lblName" runat="server"></asp:Label>
                                                            </h3>
                                                            </span></center>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <%-- <td style="width: 20%;" align="left">
                                                            <div style="width: 120px; height: 120px; border: 1px solid #888888; background: #fff;
                                                                border-radius: 5px">
                                                                <div style="margin-bottom: 10px; margin-left: 10px; margin-right: 10px; margin-top: 10px;">
                                                                    <asp:Image ID="profileImage" runat="server" Height="100px" Width="100px" />
                                                                </div>
                                                            </div>
                                                        </td>--%>
                                                        <td>
                                                            <div>
                                                                MobileNo:
                                                                <asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                                                            </div>
                                                            <div>
                                                                EmailId:
                                                                <asp:Label ID="lblEmailId" runat="server"></asp:Label></div>
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td align="center">
                                                            <asp:LinkButton ID="lnkChangePhoto" runat="server" Text="Change Photo" class="Pagelink">
                                                            </asp:LinkButton><img src="../KResource/Images/camera-icon.png" width="30px" height="20px"
                                                                alt="" />
                                                        </td>
                                                    </tr>--%>
                                                </table>
                                            </div>
                                            <hr />
                                            <span style="padding-top: 20px;">
                                                <div>
                                                    <table class="tblSubFull2">
                                                        <tr>
                                                            <td align="center">
                                                                <span class="spanTitle">Education Details</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <span class="spanTitle">School Details</span>
                                                            </td>
                                                            <td align="right">
                                                                <asp:LinkButton ID="lnkEducation" runat="server" CssClass="LinkCss">Edit <img src="../KResource/Images/EditImg.png" alt="" width="20px" height="20px"/></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <asp:GridView ID="gvEducation" runat="server" AutoGenerateColumns="False" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <table class="tblSubFull2">
                                                                    <tr>
                                                                        <td align="left">
                                                                            Qualification
                                                                        </td>
                                                                        <td width="50%" align="left">
                                                                            <asp:Label ID="lblQualification" runat="server" Text='<%#Eval("Qualification") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            Specialization
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblSpecialization" runat="server" Text='<%#Eval("Specialization") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            CollegeName
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblCollegeName" runat="server" Text='<%#Eval("CollegeName") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            YearPassout
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblYearPassout" runat="server" Text='<%#Eval("YearPassout") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            University
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblUniversity" runat="server" Text='<%#Eval("University") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            Marks
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblMarks" runat="server" Text='<%#Eval("Marks") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <%--  <tr class="grdTr">
                                                                <td class="grdTdLabel">
                                                                    <asp:Label ID="Label13" runat="server" Text="Post Graduate Course:"></asp:Label>
                                                                </td>
                                                                <td class="grdTdValue">
                                                                    <asp:Label ID="lblPostGraduate" runat="server" Text='<%#Eval("postgraduation") %>' CssClass="tdLabelInner"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr class="grdTr">
                                                                <td class="grdTdLabel">
                                                                    <asp:Label ID="Label15" runat="server" Text="Specialized"></asp:Label>
                                                                </td>
                                                                <td class="grdTdValue">
                                                                    <asp:Label ID="lblPGSpecialized" runat="server" Text='<%#Eval("pg_specialized") %>' CssClass="tdLabelInner"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr class="grdTr">
                                                                <td class="grdTdLabel">
                                                                    <asp:Label ID="Label20" runat="server" Text="Passout In"></asp:Label>
                                                                </td>
                                                                <td class="grdTdValue">
                                                                    <asp:Label ID="lblPGPassout" runat="server" Text='<%#Eval("pg_passout") %>' CssClass="tdLabelInner"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr class="grdTr">
                                                                <td class="grdTdLabel">
                                                                    <asp:Label ID="Label24" runat="server" Text="University"></asp:Label>
                                                                </td>
                                                                <td class="grdTdValue">
                                                                    <asp:Label ID="lblPGUniversity" runat="server" Text='<%#Eval("pg_university") %>' CssClass="tdLabelInner"></asp:Label>
                                                                </td>
                                                            </tr>--%>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </span>
                                            <asp:ModalPopupExtender ID="mdEducation" runat="server" TargetControlID="lnkEducation"
                                                PopupControlID="pnlEditEducation" BackgroundCssClass="modalBackground" CancelControlID="btnCloseEducation"
                                                DynamicServicePath="" Enabled="True">
                                            </asp:ModalPopupExtender>
                                            <asp:Panel ID="pnlEditEducation" runat="server" class="ModalPop">
                                                <div class="csspop">
                                                    <center>
                                                        <table>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <center>
                                                                        <span class="spanHeader">Education Update</span></center>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" style="width: 300px;">
                                                                    Qualification
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="DDDLQualification" runat="server" CssClass="cssddlwidth">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    Specialization
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtSpecialization" runat="server"></asp:TextBox>
                                                                    <asp:FilteredTextBoxExtender ID="fteName" runat="server" TargetControlID="txtSpecialization"
                                                                        FilterType="UppercaseLetters,LowercaseLetters,Custom" ValidChars=" ">
                                                                    </asp:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    School/College Name
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtCollegeName" runat="server" CssClass="ccstxt"></asp:TextBox>
                                                                    <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCollegeName"
                                                                        ErrorMessage="Please Enter Location" ValidationGroup="b"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    University
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlUniversity" runat="server" CssClass="cssddlwidth">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                        <asp:ListItem>Pune</asp:ListItem>
                                                                        <asp:ListItem>Mumbai</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    Year Of Passout
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtYrPassout" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    Marks
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtMarks" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td style="text-align: left;">
                                                                    <asp:Button ID="btnUpdateEducation" runat="server" CssClass="cssbtn" OnClick="btnUpdateEducation_click"
                                                                        Text="Update" />
                                                                    &nbsp;
                                                                    <asp:Button ID="btnCloseEducation" runat="server" CssClass="cssbtn" Text="Cancel" />
                                                                    <br />
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </center>
                                                </div>
                                            </asp:Panel>
                                            <span style="padding-top: 20px;">
                                                <div>
                                                    <table class="tblSubFull2">
                                                        <tr>
                                                            <td align="left">
                                                                <span class="spanTitle">10+2 Details</span>
                                                            </td>
                                                            <td align="right">
                                                                <asp:LinkButton ID="lnkbtn12" runat="server" CssClass="LinkCss">Edit <img src="../KResource/Images/EditImg.png" alt="" width="20px" height="20px"/></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <asp:GridView ID="gvEducation12th" runat="server" AutoGenerateColumns="False" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <table class="tblSubFull2">
                                                                    <tr>
                                                                        <td align="left">
                                                                            Qualification
                                                                        </td>
                                                                        <td width="50%" align="left">
                                                                            <asp:Label ID="lblQualification1" runat="server" Text='<%#Eval("Qualification") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            Specialization
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblSpecialization1" runat="server" Text='<%#Eval("Specialization") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            CollegeName
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblCollegeName1" runat="server" Text='<%#Eval("CollegeName") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            YearPassout
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblYearPassout1" runat="server" Text='<%#Eval("YearPassout") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            University
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblUniversity1" runat="server" Text='<%#Eval("University") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            Marks
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblMarks1" runat="server" Text='<%#Eval("Marks") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </span>
                                            <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="lnkbtn12"
                                                PopupControlID="pnlEditEducation" BackgroundCssClass="modalBackground" CancelControlID="btnCloseEducation"
                                                DynamicServicePath="" Enabled="True">
                                            </asp:ModalPopupExtender>
                                            <asp:Panel ID="Panel2" runat="server" class="ModalPop">
                                                <div class="csspop">
                                                    <center>
                                                        <table>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <center>
                                                                        <span class="spanHeader">Education Update</span></center>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" style="width: 300px;">
                                                                    Qualification
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlQualification1" runat="server" CssClass="cssddlwidth">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    Specialization
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtSpecialization1" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    School/College Name
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtCollegeName1" runat="server" CssClass="ccstxt"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtInstName"
                                                                        ErrorMessage="Please Enter Location" ValidationGroup="b"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    University
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlUniversity1" runat="server" CssClass="cssddlwidth">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                        <asp:ListItem>Pune</asp:ListItem>
                                                                        <asp:ListItem>Mumbai</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    Year Of Passout
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtYrPassout1" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    Marks
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtMarks1" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td style="text-align: left;">
                                                                    <asp:Button ID="btnUpdateEducation1" runat="server" CssClass="cssbtn" OnClick="btnUpdateEducation1_click"
                                                                        Text="Update" />
                                                                    &nbsp;
                                                                    <asp:Button ID="btnCancelEducation1" runat="server" CssClass="cssbtn" Text="Cancel" />
                                                                    <br />
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </center>
                                                </div>
                                            </asp:Panel>
                                            <span style="padding-top: 20px;">
                                                <div>
                                                    <table class="tblSubFull2">
                                                        <tr>
                                                            <td align="left">
                                                                <span class="spanTitle">Graduate Details</span>
                                                            </td>
                                                            <td align="right">
                                                                <asp:LinkButton ID="lnkbtnGrad" runat="server" CssClass="LinkCss">Edit <img src="../KResource/Images/EditImg.png" alt="" width="20px" height="20px"/></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <asp:GridView ID="gvEducationGrad" runat="server" AutoGenerateColumns="False" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <table class="tblSubFull2">
                                                                    <tr>
                                                                        <td align="left">
                                                                            Qualification
                                                                        </td>
                                                                        <td width="50%" align="left">
                                                                            <asp:Label ID="lblQualificationG" runat="server" Text='<%#Eval("Qualification") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            Specialization
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblSpecializationG" runat="server" Text='<%#Eval("Specialization") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            CollegeName
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblCollegeNameG" runat="server" Text='<%#Eval("CollegeName") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            YearPassout
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblYearPassoutG" runat="server" Text='<%#Eval("YearPassout") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            University
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblUniversityG" runat="server" Text='<%#Eval("University") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            Marks
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblMarksG" runat="server" Text='<%#Eval("Marks") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </span>
                                            <asp:ModalPopupExtender ID="ModalPopupExtender3" runat="server" TargetControlID="lnkbtnGrad"
                                                PopupControlID="pnlEditEducation" BackgroundCssClass="modalBackground" CancelControlID="btnCloseEducation"
                                                DynamicServicePath="" Enabled="True">
                                            </asp:ModalPopupExtender>
                                            <asp:Panel ID="Panel3" runat="server" class="ModalPop">
                                                <div class="csspop">
                                                    <center>
                                                        <table>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <center>
                                                                        <span class="spanHeader">Graduate Details</span></center>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" style="width: 300px;">
                                                                    Qualification
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlQualificationG" runat="server" CssClass="cssddlwidth">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    Specialization
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtSpecializationG" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    School/College Name
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtCollegeNameG" runat="server" CssClass="ccstxt"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtInstName"
                                                                        ErrorMessage="Please Enter Location" ValidationGroup="b"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    University
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlUniversityG" runat="server" CssClass="cssddlwidth">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                        <asp:ListItem>Pune</asp:ListItem>
                                                                        <asp:ListItem>Mumbai</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    Year Of Passout
                                                                </td>
                                                                <asp:TextBox ID="txtYrPassoutG" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    Marks
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtMarksG" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td style="text-align: left;">
                                                                    <asp:Button ID="Button3" runat="server" CssClass="cssbtn" OnClick="btnUpdateEducation_click"
                                                                        Text="Update" />
                                                                    &nbsp;
                                                                    <asp:Button ID="Button4" runat="server" CssClass="cssbtn" Text="Cancel" />
                                                                    <br />
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </center>
                                                </div>
                                            </asp:Panel>
                                            <span style="padding-top: 20px;">
                                                <div>
                                                    <table class="tblSubFull2">
                                                        <tr>
                                                            <td align="left">
                                                                <span class="spanTitle">Post Graduate Details</span>
                                                            </td>
                                                            <td align="right">
                                                                <asp:LinkButton ID="lnkbtnPG" runat="server" CssClass="LinkCss">Edit <img src="../KResource/Images/EditImg.png" alt="" width="20px" height="20px"/></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <asp:GridView ID="gvEducationPGrad" runat="server" AutoGenerateColumns="False" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <table class="tblSubFull2">
                                                                    <tr>
                                                                        <td align="left">
                                                                            Qualification
                                                                        </td>
                                                                        <td width="50%" align="left">
                                                                            <asp:Label ID="lblQualificationPG" runat="server" Text='<%#Eval("Qualification") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            Specialization
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblSpecializationPG" runat="server" Text='<%#Eval("Specialization") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            CollegeName
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblCollegeNamePG" runat="server" Text='<%#Eval("CollegeName") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            YearPassout
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblYearPassoutPG" runat="server" Text='<%#Eval("YearPassout") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            University
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblUniversityPG" runat="server" Text='<%#Eval("University") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            Marks
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblMarksPG" runat="server" Text='<%#Eval("Marks") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </span>
                                            <asp:ModalPopupExtender ID="ModalPopupExtender4" runat="server" TargetControlID="lnkbtnPG"
                                                PopupControlID="pnlEditEducation" BackgroundCssClass="modalBackground" CancelControlID="btnCloseEducation"
                                                DynamicServicePath="" Enabled="True">
                                            </asp:ModalPopupExtender>
                                            <asp:Panel ID="Panel4" runat="server" class="ModalPop">
                                                <div class="csspop">
                                                    <center>
                                                        <table>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <center>
                                                                        <span class="spanHeader">Education Update</span></center>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" style="width: 300px;">
                                                                    Qualification
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlQualificationPG" runat="server" CssClass="cssddlwidth">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    Specialization
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtSpecializationPG" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    School/College Name
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtCollegeNamePG" runat="server" CssClass="ccstxt"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtInstName"
                                                                        ErrorMessage="Please Enter Location" ValidationGroup="b"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    University
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlUniversityPG" runat="server" CssClass="cssddlwidth">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                        <asp:ListItem>Pune</asp:ListItem>
                                                                        <asp:ListItem>Mumbai</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    Year Of Passout
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtYrPassoutPG" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    Marks
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtMarksPG" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td style="text-align: left;">
                                                                    <asp:Button ID="Button5" runat="server" CssClass="cssbtn" OnClick="btnUpdateEducation_click"
                                                                        Text="Update" />
                                                                    &nbsp;
                                                                    <asp:Button ID="Button6" runat="server" CssClass="cssbtn" Text="Cancel" />
                                                                    <br />
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </center>
                                                </div>
                                            </asp:Panel>
                                            <hr />
                                            <span style="padding-top: 20px;">
                                                <div>
                                                    <table class="tblSubFull2">
                                                        <tr>
                                                            <td align="left">
                                                                <span class="spanTitle">Work History</span>
                                                            </td>
                                                            <td align="right" width="50%">
                                                                <asp:LinkButton ID="lnkEditWorkHistory" runat="server" CssClass="LinkCss">Edit <img src="../KResource/Images/EditImg.png" alt="" width="20px" height="20px"/></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <asp:GridView ID="gvWorkHistory" AutoGenerateColumns="False" runat="server" ShowHeader="False"
                                                    Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <table class="tblSubFull2">
                                                                    <tr>
                                                                        <td align="left">
                                                                            From Date
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblFrmDate" runat="server" Text='<%#Eval("FrmDate") %>'></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            To Date
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("ToDate") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            Total Experience :
                                                                        </td>
                                                                        <td width="50%" align="left">
                                                                            <asp:Label ID="lblWorkExpY" runat="server" Text='<%#Eval("TotalExpYr") %>'></asp:Label>
                                                                        </td>
                                                                        <%--<td width="50%" align="left">
                                                                            <asp:Label ID="lblWorkExpM" runat="server" Text='<%#Eval("TotalExpM") %>'></asp:Label>
                                                                        </td>--%>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            Job Title :
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblJTitle" runat="server" Text='<%#Eval("JTitle") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            Company Name :
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblCompName" runat="server" Text='<%#Eval("CompName") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            Annual Salary:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblannualsalary" runat="server" Text='<%#Eval("Salary") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            Functional Area:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblFArea" runat="server" Text='<%#Eval("FArea") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </span>
                                            <asp:ModalPopupExtender ID="mdlWorkHistory" runat="server" TargetControlID="lnkEditWorkHistory"
                                                PopupControlID="pnlEditWorkHistory" BackgroundCssClass="modalBackground" CancelControlID="btnCloseWorkHistory"
                                                DynamicServicePath="" Enabled="True">
                                            </asp:ModalPopupExtender>
                                            <asp:Panel ID="pnlEditWorkHistory" runat="server" class="ModalPop">
                                                <div class="csspop">
                                                    <center>
                                                        <table>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <center>
                                                                        <span class="spanHeader">Work History Update</span></center>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    From Date
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtFrmdate" runat="server" Width="80px"></asp:TextBox>
                                                                    <asp:Image ID="Image2" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                                                                        runat="server" />
                                                                    <asp:CalendarExtender ID="CEBD" PopupButtonID="Image2" runat="server" Format="yyyy-MM-dd"
                                                                        TargetControlID="txtFrmdate" Enabled="True">
                                                                    </asp:CalendarExtender>
                                                                    To
                                                                    <asp:TextBox ID="txtTodate" runat="server" Width="80px"></asp:TextBox>
                                                                    <asp:Image ID="Image1" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                                                                        runat="server" />
                                                                    <asp:CalendarExtender ID="CalendarExtender1" PopupButtonID="Image2" runat="server"
                                                                        Format="yyyy-MM-dd" TargetControlID="txtTodate" Enabled="True">
                                                                    </asp:CalendarExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Total Experience:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtTExpYr" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Job Title :
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtJobT" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Company Name :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtCompName" runat="server" CssClass="ccstxt"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Annual Salary:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtannualsalary" runat="server" CssClass="ccstxt"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    Functional Area
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtFArea" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Button ID="btnUpdateWorkHistory" Text="Update" CssClass="cssbtn" runat="server"
                                                                        OnClick="btnUpdateWorkHistory_click" />
                                                                    &nbsp;
                                                                    <asp:Button ID="btnCloseWorkHistory" Text="Cancel" CssClass="cssbtn" runat="server" />
                                                                    <br />
                                                                    <br>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </center>
                                                </div>
                                            </asp:Panel>
                                            <hr />
                                            <hr />
                                            <span style="padding-top: 20px;">
                                                <div>
                                                    <table class="tblSubFull2">
                                                        <tr>
                                                            <td align="left">
                                                                <span class="spanTitle">KeySkills</span>
                                                            </td>
                                                            <td align="right" width="50%">
                                                                <asp:LinkButton ID="lnkKeySkills" runat="server" CssClass="LinkCss">Edit <img src="../KResource/Images/EditImg.png" alt="" width="20px" height="20px"/></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <asp:GridView ID="gvKeySkill" AutoGenerateColumns="False" runat="server" Width="100%"
                                                    ShowHeader="False">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <table class="tblSubFull2">
                                                                    <tr>
                                                                        <td align="left">
                                                                            My KeySkills:
                                                                        </td>
                                                                        <td align="left" width="50%">
                                                                            <asp:Label ID="lblKeySkill" runat="server" Text='<%#Eval("Skill") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </span>
                                            <hr />
                                            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lnkKeySkills"
                                                PopupControlID="pnlKeySkills" BackgroundCssClass="modalBackground" CancelControlID="btnClose"
                                                DynamicServicePath="" Enabled="True">
                                            </asp:ModalPopupExtender>
                                            <asp:Panel ID="pnlKeySkills" runat="server" class="ModalPop">
                                                <div class="csspop">
                                                    <center>
                                                        <table>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <center>
                                                                        <span class="spanHeader">Key Skills</span></center>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Skills:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtKeySkill" runat="server" CssClass="ccstxt"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="Add" runat="server">Add<img src="../KResource/Images/EditImg.png" alt="" width="20px" height="20px"/></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </center>
                                                </div>
                                            </asp:Panel>
                                            <span style="padding-top: 20px;">
                                                <div>
                                                    <table class="tblSubFull2">
                                                        <tr>
                                                            <td align="left">
                                                                <span class="spanTitle">Resume Headline</span>
                                                            </td>
                                                            <td align="right" width="50%">
                                                                <asp:LinkButton ID="lnkEditResume" runat="server" OnClick="lnkEditResume_Click" CssClass="LinkCss">Edit <img src="../KResource/Images/Add.jpg" alt="" width="20px" height="20px"/></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <asp:GridView ID="gvResumeDetails" AutoGenerateColumns="False" runat="server" Width="100%"
                                                    ShowHeader="False">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <table class="tblSubFull2">
                                                                    <tr>
                                                                        <td align="left">
                                                                            My Resume Title:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label19" runat="server" Text='<%#Eval("RTitle") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            Upload Resume :
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lnkEditResume" runat="server" Text='<%#Eval("ResumeName") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </span>
                                            <hr />
                                            <asp:ModalPopupExtender ID="mdlResumeTitle" runat="server" TargetControlID="lnkEditResume"
                                                PopupControlID="pnlEditResume" BackgroundCssClass="modalBackground" CancelControlID="btnClose"
                                                DynamicServicePath="" Enabled="True">
                                            </asp:ModalPopupExtender>
                                            <asp:Panel ID="pnlEditResume" runat="server" class="ModalPop">
                                                <div class="csspop">
                                                    <center>
                                                        <table>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <center>
                                                                        <span class="spanHeader">Resume Update</span></center>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    My Resume Title:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtresumetitle" runat="server" CssClass="ccstxt"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Upload Resume:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:FileUpload ID="uploadresume" runat="server" AutoPostBack="true" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnInsert" runat="server" Text="Insert" CssClass="cssbtn" OnClick="btnInsert_click"
                                                                        Visible="False" />
                                                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="cssbtn" OnClick="btnUpdate_click"
                                                                        Visible="False" />
                                                                    &nbsp;
                                                                    <asp:Button ID="btnClose" runat="server" Text="Cancel" CssClass="cssbtn" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </center>
                                                </div>
                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <%-- <asp:TabPanel ID="tabLatestJobs" runat="server">
                                        <HeaderTemplate>
                                            Latest Jobs
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <asp:GridView ID="gvLatestJobs" AutoGenerateColumns="False" runat="server" Width="100%"
                                                ShowHeader="False" EmptyDataText="No latest jobs" OnRowCommand="gvLatestJobs_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <table class="tblSubFull2">
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <center>
                                                                            <span class="spanTitle">Company Job Details</span></center>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Company Name :
                                                                    </td>
                                                                    <td align="left" width="50%">
                                                                        <asp:Label ID="myAddress" runat="server" Text='<%#Eval("companyname") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Job Type:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label19" runat="server" Text='<%#Eval("job_type") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Designation:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("job_designation") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Required Qualification:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("req_qualification") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        No. of Employee Required:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("no_of_employee") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Salary:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("salary") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Experience:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label12" runat="server" Text='<%#Eval("req_exp") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Applied Date:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label30" runat="server" Text='<%#Eval("register_date") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Address:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("address") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Location:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label26" runat="server" Text='<%#Eval("cityName") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Contact Person:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label28" runat="server" Text='<%#Eval("contactperson") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Contact Number:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label32" runat="server" Text='<%#Eval("contactno") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Button ID="btnApply" runat="server" Text="Apply" CssClass="cssbtn" CommandName="Apply"
                                                                            CommandArgument='<%#Bind("id") %>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
                                        </ContentTemplate>
                                    </asp:TabPanel>--%>
                                    <asp:TabPanel ID="tabLatestJobs" runat="server">
                                        <HeaderTemplate>
                                            Latest Jobs
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <asp:GridView ID="gvLatestJobs" AutoGenerateColumns="False" runat="server" Width="100%"
                                                ShowHeader="False" EmptyDataText="No latest jobs" OnRowCommand="gvLatestJobs_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <table class="tblSubFull2">
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <center>
                                                                            <span class="spanTitle">Company Latest Job Details</span></center>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Company Name :
                                                                    </td>
                                                                    <td align="left" width="50%">
                                                                        <asp:Label ID="myAddress" runat="server" Text='<%#Eval("NameOfComp") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Job Type:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label19" runat="server" Text='<%#Eval("InSector") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Designation:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("JRole") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Required Qualification:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label4" runat="server" Text='<%#Eval("JRequirment") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        No. of Employee Required:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("VaccancyTill") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Salary:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("SalaryOffered") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Experience:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label12" runat="server" Text='<%#Eval("FreExp") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Applied Date:
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label30" runat="server" Text='<%#Eval("TrainingOffered") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Button ID="btnApply" runat="server" Text="Apply" CssClass="cssbtn" CommandName="Apply"
                                                                            CommandArgument='<%#Bind("PID") %>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel ID="tabSearch" runat="server" HeaderText="TabPanel1">
                                        <HeaderTemplate>
                                            Search
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <table class="tblSubFull2">
                                                <tr>
                                                    <td>
                                                        <div>
                                                            <center>
                                                                <br />
                                                                <span class="spanTitle">Search Company</span>
                                                                <br />
                                                                <hr />
                                                            </center>
                                                        </div>
                                                        <div id="searchtype" runat="server">
                                                            <table class="tblSubFull2">
                                                                <tr>
                                                                    <td>
                                                                        <asp:LinkButton ID="lnkSearchByCompany" runat="server" Text="Search By Company" CssClass="linkPage"
                                                                            OnClick="lnkSearchByCompany_Click"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:LinkButton ID="lnkSearchByLocation" runat="server" Text="Search By Location"
                                                                            CssClass="linkPage" OnClick="lnkSearchByLocation_Click"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:LinkButton ID="lnkSearchBySkills" runat="server" Text="Search By Skills" CssClass="linkPage"
                                                                            OnClick="lnkSearchBySkills_Click"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:LinkButton ID="lnkAdvanceSearch" runat="server" Text="Advance Search" CssClass="linkPage"
                                                                            OnClick="lnkAdvanceSearch_Click"></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div id="divSearchByCompany" runat="server" visible="False">
                                                <table class="tblSubFull2">
                                                    <tr>
                                                        <td align="left">
                                                            Select Company
                                                        </td>
                                                        <td align="left" width="50%">
                                                            <asp:DropDownList ID="ddlCompanyName" runat="server" CssClass="cssddlwidth">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Button ID="btnSearchByCompany" runat="server" Text="Search" CssClass="cssbtn"
                                                                OnClick="btnSearchByCompany_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div id="GridSearchByCompany" runat="server" visible="False">
                                                    <asp:GridView ID="gvSearchByCompany" AutoGenerateColumns="False" runat="server" Width="100%"
                                                        ShowHeader="False" EmptyDataText="No Company's as per you select Company" OnRowCommand="gvSearchByCompany_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <table class="tblSubFull2">
                                                                        <tr>
                                                                            <td align="left">
                                                                                Company Name :
                                                                            </td>
                                                                            <td align="left" width="50%">
                                                                                <asp:Label ID="myAddress" runat="server" Text='<%#Eval("NameOfComp") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                JRole:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label19" runat="server" Text='<%#Eval("JRole") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                Qualification:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("Qualification") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                JRequirment:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("JRequirment") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                SalaryOffered:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("SalaryOffered") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <%--<tr>
                                                                            <td align="left">
                                                                                Salary:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("salary") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>--%>
                                                                        <tr>
                                                                            <td align="left">
                                                                                MobileNo:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label12" runat="server" Text='<%#Eval("MobileNo") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                FreExp:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("FreExp") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                City:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label26" runat="server" Text='<%#Eval("City") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                VaccancyTill:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label28" runat="server" Text='<%#Eval("VaccancyTill") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <%--<tr>
                                                                            <td align="left">
                                                                                Contact Number:
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label32" runat="server" Text='<%#Eval("contactno") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>--%>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Button ID="btnApplySearchbyCompany" runat="server" Text="Apply" CssClass="cssbtn"
                                                                                    CommandName="Apply" CommandArgument='<%#Bind("CID") %>' />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                            <div id="divSearchByLocation" runat="server" visible="False">
                                                <table class="tblSubFull2">
                                                    <tr>
                                                        <td align="left">
                                                            Select Location
                                                        </td>
                                                        <td align="left" width="50%">
                                                            <asp:DropDownList ID="ddlLocaton" runat="server" CssClass="cssddlwidth">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnSearchLocation" runat="server" Text="Search" OnClick="btnSearchLocation_Click"
                                                                CssClass="cssbtn" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <div id="GridSearchLocation" runat="server">
                                                                <asp:GridView ID="gvSearchByLocation" AutoGenerateColumns="False" runat="server"
                                                                    Width="100%" ShowHeader="False" EmptyDataText="No Company's as per you select location"
                                                                    OnRowCommand="gvSearchByLocation_RowCommand">
                                                                    <Columns>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <table class="tblSubFull2">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Company Name :
                                                                                        </td>
                                                                                        <td align="left" width="50%">
                                                                                            <asp:Label ID="myAddress" runat="server" Text='<%#Eval("NameOfComp") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Job Type:&quot;
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label19" runat="server" Text='<%#Eval("JRole") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <%-- <tr>
                                                                                        <td align="left">
                                                                                            Designation:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("job_designation") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>--%>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Required Qualification:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("Qualification") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            No. of Employee Required:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("JRequirment") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Salary:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label8" runat="server" Text='<%#Eval("SalaryOffered") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Experience:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label12" runat="server" Text='<%#Eval("FreExp") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <%--<asp:Label ID="Label30" runat="server" Text='<%#Eval("CID") %>' Visible="false"></asp:Label>--%>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Taluka:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label10" runat="server" Text='<%#Eval("Taluka") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            City:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label26" runat="server" Text='<%#Eval("City") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <%--  <tr>
                                                                                        <td align="left">
                                                                                            Contact Person:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label28" runat="server" Text='<%#Eval("contactperson") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>--%>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Contact Number:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label32" runat="server" Text='<%#Eval("MobileNo") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                        </td>
                                                                                        <td align="right">
                                                                                            <%-- <asp:Button ID="btnApplySearchbyCompany" runat="server" Text="Apply" CssClass="button" CommandName="Apply" CommandArgument='<%#Bind("company_id") %>' />--%>
                                                                                            <asp:Button ID="btnApplySearchbyLocation" runat="server" Text="Apply" CssClass="cssbtn"
                                                                                                CommandName="Apply" CommandArgument='<%#Bind("CID") %>' />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="divSearchBySkills" runat="server" visible="False">
                                                <table class="tblSubFull2">
                                                    <tr>
                                                        <td align="left">
                                                            Enter Skills
                                                        </td>
                                                        <td align="left" width="50%">
                                                            <asp:TextBox ID="txtSkills" runat="server" CssClass="ccstxt"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnSkills" runat="server" Text="Search" OnClick="btnSkills_Click"
                                                                CssClass="cssbtn" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <div id="gridSearchbyskills" runat="server" visible="False">
                                                                <asp:GridView ID="gvSearchBySkills" AutoGenerateColumns="False" runat="server" Width="100%"
                                                                    ShowHeader="False" EmptyDataText="No Company's as per you entered the skills"
                                                                    OnRowCommand="gvSearchBySkills_RowCommand">
                                                                    <Columns>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <table class="tblSubFull2">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Company Name :
                                                                                        </td>
                                                                                        <td align="left" width="50%">
                                                                                            <asp:Label ID="myAddress" runat="server" Text='<%#Eval("companyname") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Job Type:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label19" runat="server" Text='<%#Eval("job_type") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Designation:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("job_designation") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Required Qualification:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("req_qualification") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            No. of Employee Required:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("no_of_employee") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Salary:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label8" runat="server" Text='<%#Eval("salary") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Experience:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label12" runat="server" Text='<%#Eval("req_exp") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Address:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label10" runat="server" Text='<%#Eval("address") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label26" runat="server" Text='<%#Eval("cityname") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Contact Person:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label28" runat="server" Text='<%#Eval("contactperson") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Contact Number:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label32" runat="server" Text='<%#Eval("contactno") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Button ID="btnApplySearchbySkills" runat="server" Text="Apply" CssClass="cssbtn"
                                                                                                CommandName="Apply" CommandArgument='<%#Bind("company_id") %>' />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <asp:Label ID="Label30" runat="server" Text='<%#Eval("company_id") %>' Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="divAdvanceSearch" runat="server" visible="False">
                                                <table class="tblSubFull2">
                                                    <tr>
                                                        <td align="left">
                                                            Enter Skills
                                                        </td>
                                                        <td align="left" width="50%">
                                                            <asp:TextBox ID="txtSkills1" runat="server" CssClass="ccstxt"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Experience
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlexperience" runat="server" CssClass="cssddlwidth">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            Expected Salary
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="ddlExpectedSalary" runat="server" CssClass="cssddlwidth">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Button ID="btnAdvanceSearch" runat="server" Text="Search" OnClick="btnAdvanceSearch_Click"
                                                                CssClass="cssbtn" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <div id="gridAdvanceSearch" runat="server" visible="False">
                                                                <asp:GridView ID="gvAdvanceSearch" AutoGenerateColumns="False" runat="server" Width="100%"
                                                                    ShowHeader="False" EmptyDataText="No Company's" OnRowCommand="gvAdvanceSearch_RowCommand">
                                                                    <Columns>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <table class="grdTable">
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Company Name :
                                                                                        </td>
                                                                                        <td align="left" width="50%">
                                                                                            <asp:Label ID="myAddress" runat="server" Text='<%#Eval("companyname") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Job Type:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label19" runat="server" Text='<%#Eval("job_type") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Designation:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("job_designation") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Required Qualification:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("req_qualification") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            No. of Employee Required:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("no_of_employee") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Salary:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label8" runat="server" Text='<%#Eval("salary") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Experience:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label12" runat="server" Text='<%#Eval("req_exp") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <asp:Label ID="Label30" runat="server" Text='<%#Eval("company_id") %>' Visible="false"></asp:Label>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Address:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label10" runat="server" Text='<%#Eval("address") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Location:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label26" runat="server" Text='<%#Eval("cityname") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Contact Person:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label28" runat="server" Text='<%#Eval("contactperson") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            Contact Number:
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label32" runat="server" Text='<%#Eval("contactno") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td align="left">
                                                                                            <asp:Button ID="btnApplySearchbySkills" runat="server" Text="Apply" CssClass="cssbtn"
                                                                                                CommandName="Apply" CommandArgument='<%#Bind("company_id") %>' />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="commondiv" runat="server" visible="False">
                                                <table>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Button ID="btnback" runat="server" Text="Back" OnClick="btnback_Click" CssClass="cssbtn" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                    <asp:TabPanel ID="tabViewApplied" runat="server">
                                        <HeaderTemplate>
                                            View Applied Jobs
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <div>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <center>
                                                                <br />
                                                                <span class="spanTitle">Applied Jobs</span>
                                                                <br />
                                                                <hr />
                                                            </center>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <%--<asp:Label ID="Label3" runat="server" Text="This is The Time when Only Data Grid will Referesh :"
                                                    Font-Bold="true"></asp:Label>&nbsp;
                                                <asp:Label ID="Label1" runat="server" Text="Grid not refreshed yet."></asp:Label><br />
                                                <asp:Label ID="Label4" runat="server" Text="(Grid Will Referesh after Every 30 Sec)"
                                                    Font-Bold="true"></asp:Label>&nbsp;--%>
                                                    <table>
                                                    <%--<tr><td><asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click"/></td></tr>--%>
                                                    </table>
                                                <br />
                                                <br />
                                                <asp:GridView ID="gvUserAppliedJob" AutoGenerateColumns="False" runat="server" Width="100%"
                                                    ShowHeader="False" EmptyDataText="No any Company Applied">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <table class="tblSubFull2">
                                                                    <tr>
                                                                        <td align="left">
                                                                            Company Name :
                                                                        </td>
                                                                        <td align="left" width="50%">
                                                                            <asp:Label ID="myAddress" runat="server" Text='<%#Eval("CName") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <%--<tr>
                                                                        <td align="left">
                                                                            Job Type:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label19" runat="server" Text='<%#Eval("NameOfQP") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>--%>
                                                                    <tr>
                                                                        <td align="left">
                                                                            InSector:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("InSector") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            JRole:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label10" runat="server" Text='<%#Eval("NameOfQP") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left">
                                                                            JRequirment:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label26" runat="server" Text='<%#Eval("JRequirment") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                     <tr>
                                                                        <td align="left">
                                                                            VaccancyTill:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("VaccancyTill") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                     <tr>
                                                                        <td align="left">
                                                                            SalaryOffered:
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("SalaryOffered") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                </asp:TabContainer>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
