<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="CoupanAllottmentList.aspx.cs" Inherits="MarketingAdmin_CoupanAllottmentList"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .ddlclass
        {
            width: 120px;
        }

        .txtclass
        {
            width: 120px;
        }

        .linkbtncls
        {
            text-decoration: none;
            color: White;
            font-weight: bold;
            font-size: 15px;
            font-family: Calibri Sans-Serif;
        }

        .menucss
        {
            background-color: #25313c;
        }
    </style>

    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to send passcode by sms?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>

    <div style="width: 100%; padding: 2%;">
        <asp:Accordion ID="Accordion1" runat="server" FramesPerSecond="1000">
            <Panes>
                <asp:AccordionPane ID="AccordionPane1" runat="server">
                    <Header>
                        <div style="width: 90%; margin-left: 5%;">
                            <div class="menucss">
                                <a href="#" style="text-decoration: none; color: White;">Coupan Allottment</a>
                            </div>
                        </div>
                    </Header>
                    <Content>
                        <div style="width: 90%; text-align: center; margin-left: 5%; border: 2px solid black;">
                            <div style="background-color: White; margin: 5% 0 0 5%">
                                <table style="width: 100%; height: 200px;">
                                    <tr style="background-color: #3BD7D7;">
                                        <td colspan="2" style="color: White; font-size: 20px;">
                                            <b>Coupan Allottment</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="30%" style="color: #009999;">Select Role :
                                        </td>
                                        <td align="left" width="50%">
                                            <asp:DropDownList ID="ddlRoleList" runat="server" CssClass="ddlclass" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlRoleList_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="30%" style="color: #009999;">Select User :
                                        </td>
                                        <td align="left" width="50%">
                                            <asp:DropDownList ID="ddlUserList" runat="server" CssClass="ddlclass" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlUserList_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            &nbsp;&nbsp;<asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="30%" style="color: #009999;">Date of Allottment :
                                        </td>
                                        <td align="left" width="50%">
                                            <asp:TextBox ID="txtDateTime" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="30%" style="color: #009999;">Range of SrNo From :
                                        </td>
                                        <td align="left" width="50%">
                                            <asp:TextBox ID="txtSrnoFrom" runat="server" PlaceHolder="e.g: 1001"></asp:TextBox>
                                            To
                                            <asp:TextBox ID="txtSrnoTo" runat="server" PlaceHolder="e.g: 2000"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="30%" style="color: #009999;">Project Name :
                                        </td>
                                        <td align="left" width="50%">
                                            <asp:TextBox ID="txtProjectName" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="30%"></td>
                                        <td align="left" width="50%">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" ForeColor="White" Font-Bold="true"
                                                Width="80px" Height="35px" Font-Size="Large" Style="background-color: #3BD7D7;"
                                                OnClick="btnSubmit_Click" />&nbsp; &nbsp;
                                            <asp:Button ID="btnBack" runat="server" Text="Back" ForeColor="White" Font-Bold="true"
                                                Width="80px" Height="35px" Font-Size="Large" Style="background-color: #3BD7D7;"
                                                OnClick="btnBack_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <br />
                            <div style="background-color: White;">
                                <asp:GridView ID="gvcodelist" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#3BD7D7"
                                    Width="100%" AllowPaging="true" PageSize="20" OnPageIndexChanging="gvcodelist_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="SrNo" HeaderText="SrNo" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RoleId" HeaderText="RoleId" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UsrName" HeaderText="User Name" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DOA" HeaderText="Date of Allottment" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RangeFrom" HeaderText="RangeFrom" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RangeTo" HeaderText="Range To" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PName" HeaderText="Project Name" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane2" runat="server">
                    <Header>
                        <div style="width: 90%; margin-left: 5%;">
                            <div class="menucss">
                                <a href="#" style="text-decoration: none; color: White; text-align: center;">Generate Passode</a>
                            </div>
                        </div>
                    </Header>
                    <Content>
                        <div style="width: 90%; text-align: center; margin-left: 5%; background-color: White; border: 2px solid black;">
                            <div style="background-color: White;">
                                <table style="width: 100%; height: 200px;">
                                    <tr style="background-color: #3BD7D7;">
                                        <td colspan="2" style="color: White; font-size: 20px;">Generate Passcode
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="50%" style="color: #009999;">Enter Customer&#39;s Mobile No. :
                                        </td>
                                        <td align="left" width="50%">
                                            <asp:TextBox ID="txtmobileno" runat="server" CssClass="txtclass" onkeypress="return numbersonly(this,event)"
                                                OnTextChanged="txtmobileno_TextChanged" AutoPostBack="true" MaxLength="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="req" runat="server" ControlToValidate="txtmobileno"
                                                ValidationGroup="save" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtmobileno"
                                                ValidationExpression="[0-9]{10}" runat="server" ErrorMessage="Enter 10 digit Mobile No"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="50%" style="color: #009999;">&nbsp;Customer&#39;s Mobile IMEI No. :
                                        </td>
                                        <td align="left" width="50%">
                                            <asp:TextBox ID="txtimeino" runat="server" Visible="false" CssClass="txtclass"></asp:TextBox>
                                            <asp:Label ID="lblimeino" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="50%" style="color: #009999;">Select Project :
                                        </td>
                                        <td align="left" width="50%">
                                            <asp:DropDownList ID="ddlProject" runat="server" AutoPostBack="true" CssClass="ddlclass"
                                                OnSelectedIndexChanged="ddlProject_SelectedIndexChanged">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">eZeeDrug</asp:ListItem>
                                                <asp:ListItem Value="2">eZeeTest</asp:ListItem>
                                                <asp:ListItem Value="3">eZeeSchool</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="50%" style="color: #009999;">Select User Type :
                                        </td>
                                        <td align="left" width="50%">
                                            <asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="true" CssClass="ddlclass"
                                                OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Premium User</asp:ListItem>
                                                <asp:ListItem Value="2">Pro User</asp:ListItem>
                                                <asp:ListItem Value="3">Pro-plus User</asp:ListItem>
                                                <asp:ListItem Value="4">Master User</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <asp:Panel ID="pnltest" runat="server" Visible="false">
                                            <td align="right" width="50%" style="color: #009999;">Select Test:
                                            </td>
                                            <td align="left" width="50%">
                                                <asp:DropDownList ID="ddlTest" runat="server" AutoPostBack="true" CssClass="ddlclass"
                                                    OnSelectedIndexChanged="ddlTest_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">MahaTET I Marathi</asp:ListItem>
                                                    <asp:ListItem Value="2">MahaTET II Marathi</asp:ListItem>
                                                    <asp:ListItem Value="8">MahaTET I English</asp:ListItem>
                                                    <asp:ListItem Value="9">MahaTET II English</asp:ListItem>
                                                    <asp:ListItem Value="3">Competative Exam</asp:ListItem>
                                                    <asp:ListItem Value="4">Scholarship</asp:ListItem>
                                                    <asp:ListItem Value="5">Engineering Entrance</asp:ListItem>
                                                    <asp:ListItem Value="6">Medical Entrance</asp:ListItem>
                                                    <asp:ListItem Value="7">Computer Courses</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </asp:Panel>
                                    </tr>
                                    <tr>
                                        <asp:Panel ID="pnlcompexam" runat="server" Visible="false">
                                            <td align="right" width="50%" style="color: #009999;">Select CompetativeExam :
                                            </td>
                                            <td align="left" width="50%">
                                                <asp:DropDownList ID="ddlcompexam" runat="server" AutoPostBack="true" CssClass="ddlclass">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">MPSC</asp:ListItem>
                                                    <asp:ListItem Value="2">Postman Exam</asp:ListItem>
                                                    <asp:ListItem Value="3">Police Bharti</asp:ListItem>
                                                    <asp:ListItem Value="4">IBPS</asp:ListItem>
                                                    <asp:ListItem Value="6">IBPS English</asp:ListItem>
                                                    <asp:ListItem Value="5">Talathi Exam</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlscholarship" runat="server" Visible="false">
                                            <td align="right" width="50%" style="color: #009999;">Select Scholarship :
                                            </td>
                                            <td align="left" width="50%">
                                                <asp:DropDownList ID="ddlScholarship" runat="server" AutoPostBack="true" CssClass="ddlclass">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">4th Standard(Marathi)</asp:ListItem>
                                                    <asp:ListItem Value="2">4th Standard(English)</asp:ListItem>
                                                    <asp:ListItem Value="3">7th Standard(Marathi)</asp:ListItem>
                                                    <asp:ListItem Value="4">7th Standard(English)</asp:ListItem>
                                                    <asp:ListItem Value="5">Jawahar Navodaya</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlEnggEntrance" runat="server" Visible="false">
                                            <td align="right" width="50%" style="color: #009999">Select Engineering Entrance
                                            </td>
                                            <td align="left" width="50%">
                                                <asp:DropDownList ID="ddlEnggEntrance" runat="server" AutoPostBack="true" CssClass="ddlclass">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">JEE MAIN</asp:ListItem>
                                                    <asp:ListItem Value="2">PHYSICS </asp:ListItem>
                                                    <asp:ListItem Value="3">CHEMISTRY</asp:ListItem>
                                                    <asp:ListItem Value="4">MATHEMATICS</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlMedEntrance" runat="server" Visible="false">
                                            <td align="right" width="50%" style="color: #009999">Select Medical Entrance
                                            </td>
                                            <td align="left" width="50%">
                                                <asp:DropDownList ID="ddlMedEntrance" runat="server" AutoPostBack="true" CssClass="ddlclass">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">MH-CET</asp:ListItem>
                                                    <asp:ListItem Value="2">PHYSICS </asp:ListItem>
                                                    <asp:ListItem Value="3">CHEMISTRY</asp:ListItem>
                                                    <asp:ListItem Value="4">BIOLOGY</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlComputerCources" runat="server" Visible="false">
                                            <td align="right" width="50%" style="color: #009999;">Select Courses :
                                            </td>
                                            <td align="left" width="50%">
                                                <asp:DropDownList ID="ddlCompCourses" runat="server" AutoPostBack="true" CssClass="ddlclass">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Tally</asp:ListItem>
                                                    <asp:ListItem Value="2">DTP</asp:ListItem>
                                                    <asp:ListItem Value="3">CCC</asp:ListItem>
                                                    <asp:ListItem Value="4">MS-CIT</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </asp:Panel>
                                    </tr>
                                    <tr>
                                        <asp:Panel ID="pnlamtReceived" runat="server" Visible="false">
                                            <td align="right" width="50%" style="color: #009999;">Amount Received :
                                            </td>
                                            <td align="left" width="50%">
                                                <asp:TextBox ID="txtamtReceived" runat="server" CssClass="txtclass" onkeypress="return numbersonly(this,event)"
                                                    MaxLength="10"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtamtReceived"
                                                    ValidationGroup="save" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="revamtR" ControlToValidate="txtamtReceived" ValidationExpression="[0-5]{5}"
                                                    runat="server" ErrorMessage="Enter Amount"></asp:RegularExpressionValidator>
                                            </td>
                                        </asp:Panel>
                                    </tr>
                                    <tr>
                                        <asp:Panel ID="pnlRemark" runat="server" Visible="false">
                                            <td align="right" width="50%" style="color: #009999;">Remark
                                            </td>
                                            <td align="left" width="50%">
                                                <asp:TextBox ID="txtRemark" runat="server" CssClass="txtclass"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRemark"
                                                    ValidationGroup="save" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            </td>
                                        </asp:Panel>
                                    </tr>
                                    <tr>
                                        <td align="right" width="50%"></td>
                                        <td align="left" width="50%">
                                            <asp:Button ID="btnSubmitPasscode" runat="server" Text="Submit" ForeColor="White"
                                                Font-Bold="true" Width="80px" Height="35px" Font-Size="Large" Style="background-color: #3BD7D7;"
                                                ValidationGroup="save" OnClick="btnSubmitPasscode_Click" OnClientClick="Confirm()" />&nbsp;
                                            &nbsp;
                                            <asp:Button ID="btnBack2home" runat="server" Text="Back" ForeColor="White" Font-Bold="true"
                                                Width="80px" Height="35px" Font-Size="Large" Style="background-color: #3BD7D7;"
                                                OnClick="btnBack2home_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <asp:Panel ID="pnlpasscode" runat="server" Visible="false">
                                            <td align="right" width="50%" style="color: #009999;">Your valid Passcode is :
                                            </td>
                                            <td align="left" width="50%">
                                                <asp:Label ID="lblPasscode" runat="server" Text=""></asp:Label>
                                            </td>
                                        </asp:Panel>
                                    </tr>
                                </table>
                            </div>
                            <div style="background-color: White;">
                                <asp:GridView ID="gvpasscodelist" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#3BD7D7"
                                    Width="100%" AllowPaging="true" PageSize="20" OnPageIndexChanged="gvpasscodelist_PageIndexChanged"
                                    OnPageIndexChanging="gvpasscodelist_PageIndexChanging" DataKeyNames="SrNo">
                                    <Columns>
                                        <asp:BoundField DataField="SrNo" HeaderText="SrNo" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="mobileNo" HeaderText="Mobile No" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="imeiNo" HeaderText="IMEI No" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ProjectName" HeaderText="Project" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SubPrjName" HeaderText="Sub-Project" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SubPrjName1" HeaderText="Sub-Project1" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PasscodeValue" HeaderText="Passcode" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="amtReceived" HeaderText="Amount Received" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Remark" HeaderText="Remark" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UserType" HeaderText="User Type" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane3" runat="server">
                    <Header>
                        <div style="width: 90%; margin-left: 5%;">
                            <div class="menucss">
                                <a href="#" style="text-decoration: none; color: White;">View Districtwise Record</a>
                            </div>
                        </div>
                    </Header>
                    <Content>
                        <div style="width: 90%; text-align: center; margin-left: 5%; background-color: White; border: 2px solid black;">
                            <asp:GridView ID="gvViewRecord" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#3BD7D7"
                                Width="100%" AllowPaging="true" PageSize="20" OnPageIndexChanging="gvViewRecord_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="SrNo" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="mobileNo" HeaderText="Mobile No" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="strDevId" HeaderText="IMEI No" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="keyword" HeaderText="Project" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="firstName" HeaderText="First Name" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="lastName" HeaderText="Last Name" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="address" HeaderText="Address" HeaderStyle-ForeColor="White">
                                        <HeaderStyle HorizontalAlign="Center" Width="" />
                                        <ItemStyle HorizontalAlign="Center" Width="" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane4" runat="server">
                    <Header>
                        <div style="width: 90%; margin-left: 5%;">
                            <div class="menucss">
                                <a href="#" style="text-decoration: none; color: White;">Give Balance</a>
                            </div>
                        </div>
                    </Header>
                    <Content>
                        <div style="width: 90%; text-align: center; margin: 2% 0 0 5%; background-color: White; border: 2px solid black;">
                            <div style="background-color: White;">
                                <table style="width: 100%; height: 100px;">
                                    <tr style="background-color: #3BD7D7;">
                                        <td colspan="2" style="color: White; font-size: 20px;">&nbsp;Passcode Allottement
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="50%" style="color: #009999;">Enter Customer&#39;s Mobile No. :
                                        </td>
                                        <td align="left" width="50%">
                                            <asp:TextBox ID="txtmobNo" runat="server" CssClass="txtclass" onkeypress="return numbersonly(this,event)"
                                                MaxLength="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtmobNo"
                                                ValidationGroup="save" ErrorMessage="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtmobNo"
                                                ValidationExpression="[0-9]{10}" runat="server" ErrorMessage="Enter 10 digit Mobile No"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="50%" style="color: #009999;">Enter Passcode Balance Amount :
                                        </td>
                                        <td align="left" width="50%">
                                            <asp:TextBox ID="txtbalvalue" runat="server" CssClass="txtclass"></asp:TextBox>
                                            <asp:Label ID="lblbalCount" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="50%"></td>
                                        <td align="left" width="50%">
                                            <asp:Button ID="btnSubmitBalance" runat="server" Text="Submit" ForeColor="White"
                                                Font-Bold="true" Width="80px" Height="35px" Font-Size="Large" Style="background-color: #3BD7D7;"
                                                ValidationGroup="save" OnClick="btnSubmitBalance_Click" />&nbsp; &nbsp;
                                            <asp:Button ID="Button2" runat="server" Text="Back" ForeColor="White" Font-Bold="true"
                                                Width="80px" Height="35px" Font-Size="Large" Style="background-color: #3BD7D7;" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="background-color: White;">
                            </div>
                        </div>
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="AccordionPane5" runat="server">
                    <Header>
                        <div style="width: 90%; margin-left: 5%;">
                            <div class="menucss">
                                <a href="#" style="text-decoration: none; color: White;">Balance Report</a>
                            </div>
                        </div>
                    </Header>
                    <Content>
                        <div style="width: 90%; text-align: center; margin: 2% 0 0 5%; background-color: White; border: 2px solid black;">
                            <div style="background-color: White;">
                                <table style="width: 100%; height: 100px;">
                                    <tr style="background-color: #3BD7D7;">
                                        <td colspan="2" style="color: White; font-size: 20px;">&nbsp;Report
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="50%" style="color: #009999;">Name :
                                        </td>
                                        <td align="left" width="50%">&nbsp;
                                            <asp:Label ID="lblOwnerName" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="50%" style="color: #009999;">Current Balance :
                                        </td>
                                        <td align="left" width="50%">&nbsp;
                                            <asp:Label ID="lbltotalBal" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="50%"></td>
                                        <td align="left" width="50%">&nbsp; &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="background-color: White;">
                                <asp:GridView ID="gvbalancerpt" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#3BD7D7"
                                    Width="100%" AllowPaging="true" PageSize="20" OnPageIndexChanging="gvbalancerpt_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="bal_id" HeaderText="SrNo" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="bal_For_whom" HeaderText="For Whom" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="bal_credit" HeaderText="Credit" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="bal_debit" HeaderText="Debit" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="tot_balance" HeaderText="Total balance" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ProjectName" HeaderText="Project" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SubPrjName" HeaderText="Exam Group" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SubPrjName1" HeaderText="Exam Id" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UserType" HeaderText="User Type" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="amtReceived" HeaderText="Received Amount" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EntryDate" HeaderText="Date" HeaderStyle-ForeColor="White">
                                            <HeaderStyle HorizontalAlign="Center" Width="" />
                                            <ItemStyle HorizontalAlign="Center" Width="" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </Content>
                </asp:AccordionPane>
            </Panes>
        </asp:Accordion>
    </div>
</asp:Content>
