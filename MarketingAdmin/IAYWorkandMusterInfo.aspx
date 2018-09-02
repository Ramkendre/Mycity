<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="IAYWorkandMusterInfo.aspx.cs" Inherits="MarketingAdmin_IAYWorkandMusterInfo"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="outsidediv">
        <div class="headingdiv">
            <h2>IAY Work and Muster Information</h2>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                <asp:Label ID="lblResult" runat="server"></asp:Label>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Select Beneficiaries :
            </div>
            <div class="subtddiv">
                <asp:DropDownList ID="ddlBeneficiary" runat="server" CssClass="ddlcss" AutoPostBack="true">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">Santosh Gurude</asp:ListItem>
                    <asp:ListItem Value="2">Jitendra Patil</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Date of work start :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtDoWorkStart" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="save"
                    ControlToValidate="txtDoWorkStart" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDoWorkStart" Format="dd-MM-yyyy">
                </asp:CalendarExtender>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Upload First Photo :
            </div>
            <div class="subtddiv">
                <asp:FileUpload ID="UploadFirstPhoto" runat="server" />
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                First Muster Date :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtFirstMusterDt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="save"
                    ControlToValidate="txtFirstMusterDt" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtFirstMusterDt">
                </asp:CalendarExtender>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                First Muster No. :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtFirstMusterNo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="save"
                    ControlToValidate="txtFirstMusterNo" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Second Muster Date :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtSecondMusterDt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="save"
                    ControlToValidate="txtSecondMusterDt" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtSecondMusterDt">
                </asp:CalendarExtender>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Second Muster No. :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtSecondMusterNo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="save"
                    ControlToValidate="txtSecondMusterNo" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Lental work Completion date :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtLwrkCompleteDt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="save"
                    ControlToValidate="txtLwrkCompleteDt" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtLwrkCompleteDt">
                </asp:CalendarExtender>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Upload Second Photo :
            </div>
            <div class="subtddiv">
                <asp:FileUpload ID="UploadSecondPhoto" runat="server" />
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Third Muster Date :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtThirdMusterDt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="save"
                    ControlToValidate="txtThirdMusterDt" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtThirdMusterDt">
                </asp:CalendarExtender>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Third Muster No. :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtThirdMusterNo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="save"
                    ControlToValidate="txtThirdMusterNo" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Fourth Muster Date :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtFourthMusterDt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="save"
                    ControlToValidate="txtThirdMusterDt" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtFourthMusterDt">
                </asp:CalendarExtender>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Fourth Muster No. :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtFourthMusterNo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="save"
                    ControlToValidate="txtFourthMusterNo" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Work Completion Date :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtWorkCompleteDt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ValidationGroup="save"
                    ControlToValidate="txtWorkCompleteDt" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtWorkCompleteDt">
                </asp:CalendarExtender>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Upload Third Photo :
            </div>
            <div class="subtddiv">
                <asp:FileUpload ID="UploadThirdPhoto" runat="server" />
            </div>
        </div>
        <div class="tdcssdiv">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn"
                ValidationGroup="save" OnClick="btnSubmit_Click" />
        </div>
        <div>
            <asp:GridView ID="gvMusterDetails" runat="server" CssClass="gridview">
              
            </asp:GridView>
        </div>
    </div>
</asp:Content>
