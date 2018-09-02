<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="PrivateJobEmployer.aspx.cs" Inherits="MarketingAdmin_PrivateJobEmployer"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="JavaScript" type="text/JavaScript">
        function isNumber(field) {
            var re = /^[0-9]*$/;
            if (!re.test(field.value)) {
                alert('Value must be all numeric charcters only!');
                field.value = field.value.replace(/[^0-9]/g, "");
            }
        } 
    </script>

    <table width="100%">
        <tr>
            <td>
                <ajax:TabContainer ID="JobRecruitment" runat="server" Width="100%" ActiveTabIndex="1"
                    AutoPostBack="true">
                    <ajax:TabPanel runat="server" ID="postJ" Width="100%">
                        <HeaderTemplate>
                            &nbsp;Company Registration</HeaderTemplate>
                        <ContentTemplate>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td colspan="2" align="center">
                                        <br />
                                        <br />
                                    </td>
                                    <td align="center" style="width: 39%">
                                        &#160;&#160;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30%">
                                        &#160;&#160;
                                    </td>
                                    <td align="left" style="width: 32%">
                                        &#160;&#160;
                                    </td>
                                    <td align="left" style="width: 39%">
                                        &#160;&#160;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCompanyName" runat="server" Text="Company Name:" Width="142px"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 32%">
                                        <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 39%">
                                        &#160;&#160;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCompanyType" runat="server" Text="Company Type" Width="142px"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:RadioButtonList ID="rdbCompanyType" runat="server">
                                            <asp:ListItem Text="Private" Value="0"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 29px">
                                        <asp:Label ID="lblState" runat="server" Text="State:"></asp:Label>
                                    </td>
                                    <td align="left" style="height: 29px; width: 32%;">
                                        <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" style="height: 29px; width: 39%;">
                                        &#160;&#160;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDistrict" runat="server" Text="District:"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 32%">
                                        <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" style="width: 39%">
                                        &#160;&#160;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCity" runat="server" Text="City:"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 32%">
                                        <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" style="width: 39%">
                                        &#160;&#160;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 32%">
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="tdText" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 39%">
                                        &#160;&#160;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 32%">
                                        <asp:Label ID="lblContactPerson" runat="server" Text="Contact PersonName"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 32%">
                                        <asp:TextBox ID="txtContactPerson" runat="server" CssClass="tdText"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 32%">
                                        <asp:Label ID="lblContactNo" runat="server" Text="Contact Number"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 32%">
                                        <asp:TextBox ID="txtcontactnumber" runat="server" CssClass="tdText" onkeyup="isNumber(this)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 30px">
                                        <asp:Label runat="server" ID="lblIndustry" Text="Industry"></asp:Label>
                                    </td>
                                    <td style="width: 32%; height: 30px;">
                                        <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 39%; height: 30px;">
                                        &#160;&#160;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center" class="tdLabelInner">
                                        &nbsp;&nbsp;
                                        <asp:Button ID="btnPostJob" runat="server" CssClass="button" Text="Submit" OnClick="btnPostJob_Click" />
                                        &nbsp;&nbsp;
                                        <asp:Button ID="btnCancel" runat="server" CssClass="button" OnClick="btnCancel_Click"
                                            Text="Cancel" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="tdLabelInner" colspan="3">
                                        <asp:Label ID="lblIdcompany" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </ajax:TabPanel>
                    <ajax:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                        <HeaderTemplate>
                            Employee Demand</HeaderTemplate>
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" Text="Job Type :"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 32%">
                                        <asp:DropDownList ID="ddlJobType" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSkills" runat="server" Text="Skills:" Width="121px"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 32%">
                                        <asp:TextBox ID="txtSkills" runat="server" CssClass="tdText"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblusrDesignation" runat="server" Text="Job Designation:" Width="121px"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 32%">
                                        <asp:TextBox ID="txtJobDesignation" runat="server" CssClass="tdText"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblQualification" runat="server" Text="Required Qualification:"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 32%">
                                        <asp:ListBox ID="lstqualification" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblEmp" runat="server" Text="No.Of Employees Required:"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 32%">
                                        <asp:TextBox ID="txtNoOfEmpRequired" runat="server" CssClass="tdText" onkeyup="isNumber(this)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblRequiredExp" runat="server" Text="Required Experience:"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 32%">
                                        <asp:DropDownList ID="ddlExpYear" runat="server" AutoPostBack="True">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem> > 1</asp:ListItem>
                                            <asp:ListItem> > 2</asp:ListItem>
                                            <asp:ListItem> > 3</asp:ListItem>
                                            <asp:ListItem> > 4</asp:ListItem>
                                            <asp:ListItem> > 5</asp:ListItem>
                                            <asp:ListItem> > 10</asp:ListItem>
                                            <asp:ListItem> > 15</asp:ListItem>
                                            <asp:ListItem> > 20</asp:ListItem>
                                            <asp:ListItem> > 25</asp:ListItem>
                                            <asp:ListItem> > 30</asp:ListItem>
                                            <asp:ListItem> > 35</asp:ListItem>
                                            <asp:ListItem> > 40</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSalaryRange" runat="server" Text="Salary Range:" Width="89px"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 32%">
                                        <asp:DropDownList ID="ddlSalary" runat="server" AutoPostBack="True">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                            <asp:ListItem>1000-3000</asp:ListItem>
                                            <asp:ListItem>3000-5000</asp:ListItem>
                                            <asp:ListItem>5000-8000</asp:ListItem>
                                            <asp:ListItem>8000-10000</asp:ListItem>
                                            <asp:ListItem>10000-13000</asp:ListItem>
                                            <asp:ListItem>13000-15000</asp:ListItem>
                                            <asp:ListItem>15000-20000</asp:ListItem>
                                            <asp:ListItem>20000-25000</asp:ListItem>
                                            <asp:ListItem>25000-30000</asp:ListItem>
                                            <asp:ListItem>30000-35000</asp:ListItem>
                                            <asp:ListItem>35000-40000</asp:ListItem>
                                            <asp:ListItem>40000-45000</asp:ListItem>
                                            <asp:ListItem>45000-50000</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" style="width: 39%">
                                        &#160;&#160;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 39%">
                                        <asp:Label ID="Label13" runat="server" Text="Application Form"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 39%">
                                        <asp:FileUpload ID="AppFileupload" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Duration"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="Valid From"></asp:Label>
                                        <asp:TextBox ID="txtValidFrom" runat="server" CssClass="tdText"></asp:TextBox><ajax:CalendarExtender
                                            ID="CalendarExtender1" runat="server" TargetControlID="txtValidFrom" Enabled="True">
                                        </ajax:CalendarExtender>
                                        <br />
                                        <asp:Label ID="Label8" runat="server" Text="Valid To"></asp:Label>&nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtValidTo" runat="server" CssClass="tdText"></asp:TextBox><ajax:CalendarExtender
                                            ID="CalendarExtender2" runat="server" TargetControlID="txtValidTo" Enabled="True">
                                        </ajax:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 39%">
                                        <asp:Label ID="lblStatus" runat="server" Text="Status" Visible="False"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 39%">
                                        <asp:DropDownList ID="ddlstatus" runat="server" Visible="False">
                                            <asp:ListItem>--Select--</asp:ListItem>
                                            <asp:ListItem>Active</asp:ListItem>
                                            <asp:ListItem>Deactive</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="width: 39%" colspan="3">
                                        &nbsp;
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" OnClick="btnSubmit_Click" />
                                        &nbsp;
                                        <asp:Button ID="btnCancel1" runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel1_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center">
                                        <div id="gridshow" runat="server">
                                            <div class="grid" style="width: 100%">
                                                <div class="rounded">
                                                    <div class="top-outer">
                                                        <div class="top-inner">
                                                            <div class="top">
                                                                &#160;&#160;</div>
                                                        </div>
                                                    </div>
                                                    <div class="mid-outer">
                                                        <div class="mid-inner">
                                                            <div class="mid">
                                                                <div class="pager">
                                                                    <asp:GridView ID="gvJobdetails" runat="server" Width="100%" CssClass="mGrid" CellPadding="5"
                                                                        AutoGenerateColumns="False" EmptyDataText="Not uploaded any Job" OnRowCommand="gvJobdetails_RowCommand">
                                                                        <Columns>
                                                                            <asp:BoundField HeaderText="Id" DataField="id" Visible="False">
                                                                                <HeaderStyle HorizontalAlign="Left" Width="30%"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField HeaderText="JobType" DataField="job_type">
                                                                                <HeaderStyle HorizontalAlign="Left" Width="30%"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField HeaderText="Designation" DataField="job_designation">
                                                                                <HeaderStyle HorizontalAlign="Left" Width="30%"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField HeaderText="Required Qualification" DataField="req_qualification">
                                                                                <HeaderStyle HorizontalAlign="Left" Width="30%"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField HeaderText="No.of Employee Required" DataField="no_of_employee">
                                                                                <HeaderStyle HorizontalAlign="Left" Width="30%"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField HeaderText="Required Experience" DataField="req_exp">
                                                                                <HeaderStyle HorizontalAlign="Left" Width="30%"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField HeaderText="Form Name" DataField="form_name">
                                                                                <HeaderStyle HorizontalAlign="Left" Width="30%"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField HeaderText="Job Valid From" DataField="valid_from">
                                                                                <HeaderStyle HorizontalAlign="Left" Width="30%"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField HeaderText="Job Valid To" DataField="valid_to">
                                                                                <HeaderStyle HorizontalAlign="Left" Width="30%"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="job_status" HeaderText="Status">
                                                                                <HeaderStyle HorizontalAlign="Left" Width="30%"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="Modify">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%#Bind("id")%>'
                                                                                        CommandName="Modify" ImageUrl="../resources1/images/ico_yes1.gif" />
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <PagerStyle CssClass="pager-row" />
                                                                        <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                                    </asp:GridView>
                                                                    <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label></div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="bottom-outer">
                                                        <div class="bottom-inner">
                                                            <div class="bottom">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">
                                        <div id="statedropdownlist" runat="server" visible="False">
                                            <table>
                                                <tr>
                                                    <td style="height: 29px">
                                                        <asp:Label ID="Label1" runat="server" Text="State:"></asp:Label>
                                                    </td>
                                                    <td align="left" style="height: 29px; width: 32%;">
                                                        <asp:DropDownList ID="ddlstate1" runat="server" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left" style="height: 29px; width: 39%;">
                                                        &#160;&#160;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" Text="District:"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 32%">
                                                        <asp:DropDownList ID="ddlDistrict1" runat="server" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left" style="width: 39%">
                                                        &#160;&#160;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label3" runat="server" Text="City:"></asp:Label>
                                                    </td>
                                                    <td align="left" style="width: 32%">
                                                        <asp:DropDownList ID="ddlCity1" runat="server" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="left" style="width: 39%">
                                                        &#160;&#160;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" align="center" class="tdLabelInner">
                                                        <asp:Button ID="btnSendDownloadlink" runat="server" CssClass="button" Text="Send Download Link"
                                                            OnClick="btnSendDownloadlink_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </ajax:TabPanel>
                    <ajax:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel1">
                        <HeaderTemplate>
                            View Applied Candidate</HeaderTemplate>
                        <ContentTemplate>
                            <span style="padding-top: 20px;">
                                <asp:GridView ID="gvViewCandidate" AutoGenerateColumns="False" runat="server" Width="100%"
                                    ShowHeader="False" OnRowCommand="gvViewCandidate_RowCommand">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <table class="grdTable">
                                                    <tr class="grdTr">
                                                        <td class="grdTdLabel">
                                                            <asp:Label ID="lblCandidateContactNo" runat="server" Text="CandidateContactNo"></asp:Label>
                                                        </td>
                                                        <td class="grdTdValue">
                                                            <asp:Label ID="lblCanContactNo" runat="server" Text='<%#Eval("userMobileNo") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr class="grdTr">
                                                        <td class="grdTdLabel">
                                                            <asp:Label ID="Label18" runat="server" Text="Candidate Name:"></asp:Label>
                                                        </td>
                                                        <td class="grdTdValue">
                                                            <asp:Label ID="Label19" runat="server" Text='<%#Eval("userName") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr class="grdTr">
                                                        <td class="grdTdLabel">
                                                            <asp:Label ID="Label5" runat="server" Text="Qualification:"></asp:Label>
                                                        </td>
                                                        <td class="grdTdValue">
                                                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("graduate_course") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr class="grdTr">
                                                        <td class="grdTdLabel">
                                                            <asp:Label ID="Label16" runat="server" Text="Resume :"></asp:Label>
                                                        </td>
                                                        <td class="grdTdValue">
                                                            <asp:Label ID="Label17" runat="server" Text='<%#Eval("resume_title") %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btndwnfrnd" runat="server" Text="Download Resume" CommandName="Download"
                                                                CssClass="button" CommandArgument='<%#Bind("userid") %>' />
                                                        </td>
                                                    </tr>
                                                    <%-- <tr class="grdTr">
                                                        <td class="grdTdLabel">
                                                            <asp:Label ID="Label21" runat="server" Text="Applied Date:"></asp:Label>
                                                        </td>
                                                        <td class="grdTdValue">
                                                            <asp:Label ID="Label22" runat="server" Text='<%#Eval("") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr class="grdTr">
                                                        <td class="grdTdLabel">
                                                            <asp:Label ID="Label23" runat="server" Text="No. of times Applied:"></asp:Label>
                                                        </td>
                                                        <td class="grdTdValue">
                                                            <asp:Label ID="Label24" runat="server" Text='<%#Eval("") %>'></asp:Label>
                                                        </td>
                                                    </tr>--%></table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:Label ID="lblId1" runat="server" Visible="False"></asp:Label></span>
                        </ContentTemplate>
                    </ajax:TabPanel>
                </ajax:TabContainer>
            </td>
        </tr>
    </table>
</asp:Content>
