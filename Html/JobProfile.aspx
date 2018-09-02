<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="JobProfile.aspx.cs" Inherits="Html_JobProfile" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
        function isCharKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if ((charCode < 64 && charCode > 0) || (charCode < 96 && charCode > 91) || (charCode < 127 && charCode > 123))
                return false;

            return true;
        }
    </script>

    <div class="MainDiv">
        <div class="InnerDiv">
            <table class="tblSubFull2">
                <tr>
                    <td align="center" colspan="2">
                        <span class="spanTitle">Create New Profile</span>
                    </td>
                </tr>
                <tr style="background-color: #C3FEFE;">
                    <td colspan="2">
                        <span class="spanTitle">Education Details</span>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <%--<td>
                        School
                    </td>--%>
                    
                        <%--<asp:RadioButtonList ID="rbtnEducation" runat="server">
                            <asp:ListItem> School</asp:ListItem>
                            <asp:ListItem>College</asp:ListItem>
                            <asp:ListItem>Graduate</asp:ListItem>
                            <asp:ListItem>Post Graduate</asp:ListItem>
                        </asp:RadioButtonList>--%>
                        <td align="right">
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server"                                 
                                RepeatDirection="Horizontal" 
                                onselectedindexchanged="CheckBoxList1_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="1">School</asp:ListItem>
                            <asp:ListItem Value="2">12th/Diploma</asp:ListItem>
                            <asp:ListItem Value="3">Graduate</asp:ListItem>
                            <asp:ListItem Value="4">PostGraduate</asp:ListItem>
                        </asp:CheckBoxList></td>
                       <%-- <td align="right"> <asp:RadioButton ID="rbtnSchool" runat="server" 
                                oncheckedchanged="rbtnSchool_CheckedChanged" AutoPostBack="true" />School 
                        <asp:RadioButton ID="rbtnCollege" runat="server" 
                                oncheckedchanged="rbtnCollege_CheckedChanged" AutoPostBack="true" />12th/Diploma</td>
                        <td><asp:RadioButton ID="rbtnGraduate" runat="server" 
                                oncheckedchanged="rbtnGraduate_CheckedChanged" AutoPostBack="true" />Graduate
                        <asp:RadioButton ID="rbtnPostGraduate" runat="server" 
                                oncheckedchanged="rbtnPostGraduate_CheckedChanged" AutoPostBack="true" />PostGraduate</td>--%>
                   
                    
                </tr>
                
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td align="left">
                                <b>School Details</b>
                            </td>
                            <td>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 300px;">
                                Qualification
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDDLQualificationV1" runat="server" AutoPostBack="true" CssClass="cssddlwidth" OnSelectedIndexChanged="DDDLQualificationV1_SelectedIndexChanged">
                                <%--    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem>10th</asp:ListItem>
                                    <asp:ListItem>Graduate</asp:ListItem>--%>
                                </asp:DropDownList>
                                <asp:TextBox ID="txtQualificationV1" runat="server" Visible="false" OnTextChanged="txtQualificationV1_OnTextChanged"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Specialization
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLSpecializationV1" runat="server" CssClass="cssddlwidth">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem>Software Developer</asp:ListItem>
                                    <asp:ListItem>Personal Manager</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                School Name
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtInstNameV1" runat="server" CssClass="ccstxt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                University
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlUniversityV1" runat="server" CssClass="cssddlwidth">
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
                                <asp:TextBox ID="txtYrPassoutV1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Percentage
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMarksV1" runat="server" CssClass="ccstxt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                        <td align="right">
                         <asp:LinkButton ID="lnkBAddV1" runat="server" Text="Submit" OnClick="lnkBAddV1_Click"></asp:LinkButton>
                         
                        </td>
           
                            <td align="center">
                               <asp:LinkButton ID="lnkBSubmitV1" runat="server" Text="Add More SchoolDetails" OnClick="lnkBSubmitV1_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                       
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                   </asp:View>
                    <asp:View ID="View2" runat="server">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td align="left">
                                <b>12th/Diploma Details</b>
                            </td>
                            <td>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 300px;">
                                Qualification
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDDLQualificationV2" runat="server" CssClass="cssddlwidth" AutoPostBack="true">
                                    <%--<asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem>10th</asp:ListItem>
                                    <asp:ListItem>Graduate</asp:ListItem>--%>
                                </asp:DropDownList>
                                <asp:TextBox ID="txtQualificationV2" runat="server" Visible="false" AutoPostBack="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Specialization
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLSpecializationV2" runat="server" CssClass="cssddlwidth">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem>Software Developer</asp:ListItem>
                                    <asp:ListItem>Personal Manager</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                College Name
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtInstNameV2" runat="server" CssClass="ccstxt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                University
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlUniversityV2" runat="server" CssClass="cssddlwidth">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem>Software Developer</asp:ListItem>
                                    <asp:ListItem>Personal Manager</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Year Of Passout
                            </td>
                            
                               <td align="left">
                                <asp:TextBox ID="txtYrPassoutV2" runat="server"></asp:TextBox>
                          
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Percentage
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMarksV2" runat="server" CssClass="ccstxt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:LinkButton ID="lnkAddV2" runat="server" Text="Add" OnClick="lnkAddV2_Click"></asp:LinkButton>
                            </td>
                            <td align="center">
                               <asp:LinkButton ID="lnkBSubmitV2" runat="server" Text="Add More 12th Details" OnClick="lnkBSubmitV2_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                   </asp:View>
                    <asp:View ID="View3" runat="server">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td align="left">
                                <b>Graduate Details</b>
                            </td>
                            <td>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 300px;">
                                Qualification
                            </td>
                            <td align="left">
                               <asp:TextBox ID="txtQulif" runat="server"></asp:TextBox>
                                <%--<asp:TextBox ID="txtQualificationV3" runat="server" Visible="false" AutoPostBack="true"></asp:TextBox>--%>
                                
                            </td>
                        </tr>
                        <tr>
                        <td align="right" style="width:300px;">
                            Degree Name
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDName" runat="server"></asp:TextBox>
                        </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Specialization
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLSpecializationV3" runat="server" CssClass="cssddlwidth">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem>Software Developer</asp:ListItem>
                                    <asp:ListItem>Personal Manager</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                College Name
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtInstNameV3" runat="server" CssClass="ccstxt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                University
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlUniversityV3" runat="server" CssClass="cssddlwidth">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem>Software Developer</asp:ListItem>
                                    <asp:ListItem>Personal Manager</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                       <tr>
                            <td align="right">
                                Year Of Passout
                            </td>
                            
                               <td align="left">
                                <asp:TextBox ID="txtYrPassoutV3" runat="server"></asp:TextBox>
                          
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Percentage
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMarksV3" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:LinkButton ID="lnkAddV3" runat="server" Text="Submit" OnClick="lnkAddV3_Click"></asp:LinkButton>
                            </td>
                            <td align="center">
                               <asp:LinkButton ID="lnkBSubmitV3" runat="server" Text="Add More Graduate Details" OnClick="lnkBSubmitV3_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                   </asp:View>
                    <asp:View ID="View4" runat="server">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td align="left">
                                <b>Post-Graduate Details</b>
                            </td>
                            <td>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 300px;">
                                Qualification
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDDLQualification" runat="server" AutoPostBack="true" CssClass="cssddlwidth" OnSelectedIndexChanged="DDDLQualification_SelectedIndexChanged">
                                  <%--  <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem>10th</asp:ListItem>
                                    <asp:ListItem>Graduate</asp:ListItem>--%>
                                    
                                </asp:DropDownList>
                                <asp:TextBox ID="txtQualification" runat="server" Visible="false" AutoPostBack="true" OnTextChanged="txtQualification_TextChanged"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Specialization
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DDLSpecialization" runat="server" CssClass="cssddlwidth">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem>Software Developer</asp:ListItem>
                                    <asp:ListItem>Personal Manager</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                College Name
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtInstName" runat="server" CssClass="ccstxt"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtInstName"
                                    ErrorMessage="Please Enter Location" ValidationGroup="b"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                University
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlUniversity" runat="server" CssClass="cssddlwidth">
                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                    <asp:ListItem>Software Developer</asp:ListItem>
                                    <asp:ListItem>Personal Manager</asp:ListItem>
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
                                Percentage
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMarks" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td align="right">
                                <asp:LinkButton ID="lnkAddV4" runat="server" Text="Submit" OnClick="lnkAddV4_Click"></asp:LinkButton>
                            </td>
                            <td align="center">
                               <asp:LinkButton ID="lnkBSubmit" runat="server" Text="Add More PG Details" OnClick="lnkBSubmit_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                   </asp:View>
                </asp:MultiView>
                 <tr style="background-color: #C3FEFE;">
                    <td colspan="2">
                        <span class="spanTitle">Certification Courses</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Course
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCourse1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Course
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCourse2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Course
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCourse3" runat="server"></asp:TextBox>
                    </td>
                    <td align="center">
                    <asp:LinkButton ID="lnkbtnCourse" runat="server">Add</asp:LinkButton>
                    </td>
                </tr>
                <tr style="background-color: #C3FEFE;">
                    <td colspan="2">
                        <span class="spanTitle">Work Experience</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
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
                            TargetControlID="txtFrmdate">
                        </asp:CalendarExtender>
                        To
                        <asp:TextBox ID="txtTodate" runat="server" Width="80px"></asp:TextBox>
                        <asp:Image ID="Image1" ImageUrl="~/images/calendarclick.gif" AlternateText="Choose Date"
                            runat="server" />
                        <asp:CalendarExtender ID="CalendarExtender1" PopupButtonID="Image2" runat="server"
                            Format="yyyy-MM-dd" TargetControlID="txtTodate">
                        </asp:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total Experience
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtTExpYr" runat="server"></asp:TextBox>
                        <em style="font-style: italic; color: rgb(102, 102, 102); font-family: Tahoma, Arial, sans-serif;
                            font-size: 12px; font-variant: normal; font-weight: normal; letter-spacing: normal;
                            line-height: 18px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none;
                            white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto;
                            -webkit-text-stroke-width: 0px;"><span style="font-size: 8pt;">Year </span></em>
                        <asp:TextBox ID="txtWExpM" runat="server"></asp:TextBox>
                        <em style="font-style: italic; color: rgb(102, 102, 102); font-family: Tahoma, Arial, sans-serif;
                            font-size: 12px; font-variant: normal; font-weight: normal; letter-spacing: normal;
                            line-height: 18px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none;
                            white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto;
                            -webkit-text-stroke-width: 0px;"><span style="font-size: 8pt;">Month </span>
                        </em>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <br />
                        &nbsp;&nbsp;&nbsp; Job Title
                    </td>
                    <td>
                        <asp:TextBox ID="txtJobT" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtJobT"
                            ErrorMessage="Please Enter Location" ValidationGroup="b"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Organization Name
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCompName" runat="server" CssClass="ccstxt"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtCompName"
                            ErrorMessage="Please Enter Location" ValidationGroup="b"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Salary
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtSalary" runat="server" placeholder="Salary Drawn"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Functional Area
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtFArea" runat="server" placeholder="Enter Type Of Work"></asp:TextBox>
                    </td>
                </tr>
                <%-- <tr style="background-color: #C3FEFE;">
                    <td colspan="2">
                        <span class="spanTitle">Location</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
               <tr>
                    <td align="right">
                        Current Location
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCLocation" runat="server" CssClass="ccstxt"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Preferred Location
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtPLocation" runat="server" CssClass="ccstxt"></asp:TextBox>                    </td>
                </tr>--%>
                <tr style="background-color: #C3FEFE;">
                    <td colspan="2">
                        <span class="spanTitle">Key Skills</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Key Skills
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtKeySkill" runat="server" placeholder="Enter KeySkill"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Key Skills
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtKeySkil2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Key Skills
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtKeySkil3" runat="server"></asp:TextBox>
                    </td>
                    <td align="center">
                    <asp:LinkButton ID="lnkAddS" runat="server" OnClick="lnkAddS_Click">Add</asp:LinkButton>
                    </td>
                </tr>
                <tr style="background-color: #C3FEFE;">
                    <td colspan="2">
                        <span class="spanTitle">Resume</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Resume Title
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtRTitle" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Upload Resume:
                    </td>
                    <td align="left">
                        <asp:FileUpload ID="uploadresume" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
