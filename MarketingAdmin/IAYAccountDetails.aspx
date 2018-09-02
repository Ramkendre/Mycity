<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="IAYAccountDetails.aspx.cs" Inherits="MarketingAdmin_IAYAccountDetails"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="outsidediv">
        <div class="headingdiv">
            <h2>IAY Account Details</h2>
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
                First Installment Rs. :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtFirstInstallment" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="save"
                    ControlToValidate="txtFirstInstallment" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                First Installment Date :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtFirstInstallmentDt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="save"
                    ControlToValidate="txtFirstInstallmentDt" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFirstInstallmentDt">
                </asp:CalendarExtender>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Second Installment Rs. :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtSecondInstallment" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="save"
                    ControlToValidate="txtSecondInstallment" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Second Installment Date :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtSecondInstallmentDt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="save"
                    ControlToValidate="txtSecondInstallmentDt" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtSecondInstallmentDt">
                </asp:CalendarExtender>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Third Installment Rs. :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtThirdInstallment" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="save"
                    ControlToValidate="txtThirdInstallment" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="tdcssdiv">
            <div class="tdlbl">
                Third Installment Date :
            </div>
            <div class="subtddiv">
                <asp:TextBox ID="txtThirdInstallmentDt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="save"
                    ControlToValidate="txtThirdInstallmentDt" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtThirdInstallmentDt">
                </asp:CalendarExtender>
            </div>
        </div>
        <div class="tdcssdiv">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn"
                ValidationGroup="save" OnClick="btnSubmit_Click" />
        </div>
        <div>
            <asp:GridView ID="gvDispAccDetails" runat="server" CssClass="gridview">
                <%--<Columns>
                    <asp:BoundField DataField="NID" HeaderText="ID">
                        
                    </asp:BoundField>
               
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnModify" runat="server" Text="Modify" CssClass="btn" CommandArgument='<%#Bind("NID")%>'
                                CommandName="Modify" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>--%>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
