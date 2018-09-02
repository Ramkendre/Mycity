<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="IAYPersonalDetails.aspx.cs" Inherits="MarketingAdmin_IAYPersonalDetails"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <body onload="PopulateStateMaster();">
        <div class="outsidediv">
            <div class="headingdiv">
                <h2>IAY Pesonal Data</h2>
            </div>
            <div class="tdcssdiv">
                <div class="tdlbl">
                    <asp:Label ID="lblResult" runat="server"></asp:Label>
                </div>
            </div>
            <div class="tdcssdiv">
                <div class="tdlbl">
                    Beneficiaries MobileNo :
                </div>
                <div class="subtddiv">
                    <asp:TextBox ID="txtBMobileNo" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="save"
                        ControlToValidate="txtBMobileNo" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="tdcssdiv">
                <div class="tdlbl">
                    Beneficiary First Name :
                </div>
                <div class="subtddiv">
                    <asp:TextBox ID="txtBFName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="save"
                        ControlToValidate="txtBFName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="tdcssdiv">
                <div class="tdlbl">
                    Beneficiary Last Name :
                </div>
                <div class="subtddiv">
                    <asp:TextBox ID="txtBLName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="save"
                        ControlToValidate="txtBLName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="tdcssdiv">
                <div class="tdlbl">
                    Beneficiaries Adhar No. :
                </div>
                <div class="subtddiv">
                    <asp:TextBox ID="txtAdharNo" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="save"
                        ControlToValidate="txtAdharNo" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="tdcssdiv">
                <div class="tdlbl">
                    Beneficiaries Bank A/C No. :
                </div>
                <div class="subtddiv">
                    <asp:TextBox ID="txtBankAcno" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="save"
                        ControlToValidate="txtBankAcno" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="tdcssdiv">
                <div class="tdlbl">
                    Beneficiaries Bank Name :
                </div>
                <div class="subtddiv">
                    <asp:TextBox ID="txtBankName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="save"
                        ControlToValidate="txtBankName" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="tdcssdiv">
                <div class="tdlbl">
                    Beneficiaries IFSC Code :
                </div>
                <div class="subtddiv">
                    <asp:TextBox ID="txtIFSCCode" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="save"
                        ControlToValidate="txtIFSCCode" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="tdcssdiv">
                <div class="tdlbl">
                    Select State :
                </div>
                <div class="subtddiv">
                    <%--  <asp:DropDownList ID="ddlState" runat="server" CssClass="ddlcss" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                </asp:DropDownList>--%>

                    <asp:DropDownList ID="ddlState" runat="server" CssClass="ddlcss">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="tdcssdiv">
                <div class="tdlbl">
                    Select District :
                </div>
                <div class="subtddiv">
                    <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="ddlcss" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="tdcssdiv">
                <div class="tdlbl">
                    Select Block :
                </div>
                <div class="subtddiv">
                    <asp:DropDownList ID="ddlBlock" runat="server" CssClass="ddlcss">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="tdcssdiv">
                <div class="tdlbl">
                    Select Gram Panchayat :
                </div>
                <div class="subtddiv">
                    <asp:DropDownList ID="ddlGramPanchayat" runat="server" CssClass="ddlcss" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="tdcssdiv">
                <div class="tdlbl">
                    Select Village :
                </div>
                <div class="subtddiv">
                    <asp:DropDownList ID="ddlVillage" runat="server" CssClass="ddlcss" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="tdcssdiv">
                <div class="tdlbl">
                    Enter Approval Date Of IAY :
                </div>
                <div class="subtddiv">
                    <asp:TextBox ID="txtApprovalDate" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="save"
                        ControlToValidate="txtApprovalDate" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtApprovalDate">
                    </asp:CalendarExtender>
                </div>
            </div>
            <div class="tdcssdiv">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn"
                    ValidationGroup="save1" OnClientClick="PopulateDropDownList" />
                <%--OnClick="btnSubmit_Click"--%>
            </div>
            <div>
                <asp:GridView ID="gvPersonalDetails" runat="server" CssClass="gridview">
                    <Columns>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </body>
    <script type="text/javascript">
        function PopulateStateMaster() {
            //  debugger;
            //Build an array containing Customer records.
            var customers = [
                 { StateId: 0, StateName: "SELECT" },
                { StateId: 1, StateName: "JAMMU & KASHMIR" },
                { StateId: 2, StateName: "HIMACHAL PRADESH" },
                { StateId: 3, StateName: "PUNJAB" },
                { StateId: 4, StateName: "CHANDIGARH" },
                { StateId: 5, StateName: "UTTARAKHAND" },
                { StateId: 6, StateName: "HARYANA" },
                { StateId: 7, StateName: "DELHI" },
                { StateId: 8, StateName: "RAJASTHAN" },
                { StateId: 9, StateName: "UTTAR PRADESH" },
                { StateId: 10, StateName: "BIHAR" },
                { StateId: 11, StateName: "SIKKIM" },
                { StateId: 12, StateName: "ARUNACHAL PRADESH" },
                { StateId: 13, StateName: "NAGALAND" },
                { StateId: 14, StateName: "MANIPUR" },
                { StateId: 15, StateName: "MIZORAM" },
                { StateId: 16, StateName: "TRIPURA" },
                { StateId: 17, StateName: "MEGHALAYA" },
                { StateId: 18, StateName: "ASSAM" },
                { StateId: 19, StateName: "WEST BENGAL" },
                { StateId: 20, StateName: "JHARKHAND" },
                { StateId: 21, StateName: "ORISSA" },
                { StateId: 22, StateName: "CHHATISGARH" },
                { StateId: 23, StateName: "MADHYA PRADESH" },
                { StateId: 24, StateName: "GUJARAT" },
                { StateId: 25, StateName: "DAMAN & DIU" },
                { StateId: 26, StateName: "DAMAN & DIU" },
                { StateId: 27, StateName: "MAHARASHTRA" },
                { StateId: 28, StateName: "ANDHRA PRADESH" },
                { StateId: 29, StateName: "KARNATAKA" },
                { StateId: 30, StateName: "GOA" },
                { StateId: 31, StateName: "LAKSHADWEEP" },
                { StateId: 32, StateName: "KERALA" },
                { StateId: 33, StateName: "TAMIL NADU" },
                { StateId: 34, StateName: "PUDUCHERRY" },
                { StateId: 35, StateName: "A & N ISLANDS" },
                { StateId: 36, StateName: "TELENGANA" }
            ];

            var ddlCustomers = document.getElementById('<%=ddlState.ClientID%>');

            //Add the Options to the DropDownList.
            for (var i = 0; i < customers.length; i++) {

                var item = new Option(customers[i].StateName, customers[i].StateId);
                document.forms[0]['<%=ddlState.ClientID%>'].options.add(item);
            }

            var districts = [
                 { DistrictId: 0, DistrictName: "SELECT", StateId: 1 },
                { DistrictId: 1, DistrictName: "NANDURBAR", StateId: 1 },
                { DistrictId: 2, DistrictName: "DHULE", StateId: 1 },
                { DistrictId: 3, DistrictName: "JALGAON", StateId: 1 },
                { DistrictId: 4, DistrictName: "BULDANA", StateId: 1 },
                { DistrictId: 5, DistrictName: "AKOLA", StateId: 1 },
                { DistrictId: 6, DistrictName: "WASHIM", StateId: 1 },
                { DistrictId: 7, DistrictName: "AMRAVATI", StateId: 1 }
            ];

        }
    </script>

</asp:Content>
