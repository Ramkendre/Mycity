<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="LongCodeRegistration.aspx.cs" Inherits="MarketingAdmin_LongCodeRegistration"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
--%><asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
        <!--
        // 
        // 
        function numbersonly(myfield, e, dec) {
            var key;
            var keychar;

            if (window.event)
                key = window.event.keyCode;
            else if (e)
                key = e.which;
            else
                return true;
            keychar = String.fromCharCode(key);

            // control keys
            if ((key == null) || (key == 0) || (key == 8) ||
            (key == 9) || (key == 13) || (key == 27))
                return true;

            // numbers with prcision..
            else if ((("0123456789.").indexOf(keychar) > -1))
                return true;

            //        // decimal point jump
            //        else if (dec && (keychar == "."))
            //           {
            //           myfield.form.elements[dec].focus();
            //           return false;
            //           }
            else
                return false;
        }



        // numbers without prcision..

        function numbersonlywithoutdecimal(myfield, e, dec) {
            var key;
            var keychar;

            if (window.event)
                key = window.event.keyCode;
            else if (e)
                key = e.which;
            else
                return true;
            keychar = String.fromCharCode(key);

            // control keys
            if ((key == null) || (key == 0) || (key == 8) ||
            (key == 9) || (key == 13) || (key == 27))
                return true;

            // numbers
            else if ((("0123456789").indexOf(keychar) > -1))
                return true;

            //        // decimal point jump
            //        else if (dec && (keychar == "."))
            //           {
            //           myfield.form.elements[dec].focus();
            //           return false;
            //           }
            else
                return false;
        }


        function DateCheck(myfield, e, dec) {
            var key;
            var keychar;

            if (window.event)
                key = window.event.keyCode;
            else if (e)
                key = e.which;
            else
                return true;
            keychar = String.fromCharCode(key);

            // control keys
            if ((key == null) || (key == 0) || (key == 8) ||
                (key == 9) || (key == 13) || (key == 27))
                return true;

            // numbers
            else if ((("0123456789/").indexOf(keychar) > -1))
                return true;


            else
                return false;
        }
        //-->
        //-->

     
  
    </script>

    <table cellpadding="0" cellspacing="0" width="100%" border="1">
        <tr>
            <td align="center">
                <div style="width: 82%">
                    <table cellpadding="0" cellspacing="0" border="0" class="tables" style="width: 98%;
                        height: 332px">
                        <tr>
                            <td style="height: 20px;">
                                <center>
                                    <span class="warning1" style="color: Red;">Fields marked with * are mandatory.</span></center>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 20px;">
                                <table style="width: 97%; height: 294px;" class="tblAdminSubFull1" cellspacing="0px">
                                    <tr>
                                        <td colspan="2">
                                            <br />
                                            <center>
                                                <asp:Label ID="lblKeywordDefinition" runat="server" Text="LongCode Miscal Registration"
                                                    Font-Bold="True" Font-Size="Large"></asp:Label></center>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 21px; text-align: right;">
                                            IMINO :
                                        </td>
                                        <td style="height: 21px; text-align: left;">
                                            <asp:TextBox ID="txtIMINo" runat="server" CssClass="tdText"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 21px; text-align: right;">
                                            SIM No :
                                        </td>
                                        <td style="height: 21px; text-align: left;">
                                            <asp:TextBox ID="txtsimno" runat="server" CssClass="tdText"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 21px; text-align: right;">
                                            Mobile No :
                                        </td>
                                        <td style="height: 21px; text-align: left;">
                                            <asp:TextBox ID="txtmobileno" runat="server" CssClass="tdText" MaxLength="10" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 21px; text-align: right;">
                                            Name of firm :
                                        </td>
                                        <td style="height: 21px; text-align: left;">
                                            <asp:TextBox ID="txtCustomerName" runat="server" CssClass="tdText"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 21px; text-align: right;">
                                            Address :
                                        </td>
                                        <td style="height: 21px; text-align: left;">
                                            <asp:TextBox ID="txtCustomeraddress" runat="server" CssClass="tdText"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 21px; text-align: right;">
                                            Contact No1 :
                                        </td>
                                        <td style="height: 21px; text-align: left;">
                                            <asp:TextBox ID="txtContactNo" runat="server" CssClass="tdText" MaxLength="10" onkeypress="return numbersonly(this,event)"
                                                BorderColor="Red" BorderWidth="1">
                                            </asp:TextBox><span style="color: red">Register Mobile No</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 21px; text-align: right;">
                                            Contact No2 :
                                        </td>
                                        <td style="height: 21px; text-align: left;">
                                            <asp:TextBox ID="txtContactNo2" runat="server" CssClass="tdText" MaxLength="10" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 21px; text-align: right;">
                                            Contact No3 :
                                        </td>
                                        <td style="height: 21px; text-align: left;">
                                            <asp:TextBox ID="txtContactNo3" runat="server" CssClass="tdText" MaxLength="10" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 21px; text-align: right;">
                                            Contact No4 :
                                        </td>
                                        <td style="height: 21px; text-align: left;">
                                            <asp:TextBox ID="txtContactNo4" runat="server" CssClass="tdText" MaxLength="10" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 21px; text-align: right;">
                                            Contact No5 :
                                        </td>
                                        <td style="height: 21px; text-align: left;">
                                            <asp:TextBox ID="txtContactNo5" runat="server" CssClass="tdText" MaxLength="10" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 21px; text-align: right;">
                                            No. Use for :
                                        </td>
                                        <td style="height: 21px; text-align: left;">
                                            <asp:RadioButtonList ID="rdbUserfor" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1">Miscal</asp:ListItem>
                                                <asp:ListItem Value="2">LongCode</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="3">Both</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 21px; text-align: right;">
                                            Send Data To :
                                        </td>
                                        <td style="height: 21px; text-align: left;">
                                            <asp:DropDownList ID="ddlsenddata" runat="server" AutoPostBack="True" Width="140px"
                                                OnSelectedIndexChanged="ddlsenddata_SelectedIndexChanged">
                                                <asp:ListItem Value="1">Myctin</asp:ListItem>
                                                <asp:ListItem Value="2">School</asp:ListItem>
                                                <asp:ListItem Value="3">Emergency</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 21px; text-align: right;">
                                            <asp:Label ID="lblconnectschool" runat="server" Text="Connect To School:" Visible="false"></asp:Label>
                                        </td>
                                        <td style="height: 21px; text-align: left;">
                                            <asp:DropDownList ID="ddlschoollist" runat="server" Visible="false" Width="140px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 21px; text-align: right;">
                                            Miss Call Type :
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rblText" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1">Single</asp:ListItem>
                                                <asp:ListItem Value="2">Multiple</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:Label ID="lblmisscalltype" runat="server" Text="*" Visible="false" ForeColor="red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 21px; text-align: left;">
                                            &nbsp;
                                        </td>
                                        <td style="height: 21px; text-align: left;">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="button" OnClick="btnSubmit_Click"
                                                Text="Submit" />
                                            &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="button" OnClick="btnCancel_Click"
                                                Text="Cancel" />
                                            &nbsp;<asp:Button ID="btnBack" runat="server" CssClass="button" Text="Back" OnClick="btnBack_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 21px; text-align: left;" colspan="2">
                                            <asp:GridView ID="gvLongCodeshow" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                CellPadding="5" CellSpacing="0" CssClass="mGrid" EmptyDataText="" GridLines="Both"
                                                PageSize="5" Width="100%" OnPageIndexChanging="gvLongCodeshow_PageIndexChanging"
                                                OnRowCommand="gvLongCodeshow_RowCommand" OnRowDeleting="gvLongCodeshow_RowDeleting"
                                                OnRowDataBound="gvLongCodeshow_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Id" DataField="reg_id">
                                                        <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Name" DataField="customer_name">
                                                        <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Mobile No" DataField="mobileno">
                                                        <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="SIM Number" DataField="Sim_no">
                                                        <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="IMEI Number" DataField="IMEINO">
                                                        <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Miss Call Type" DataField="MissCallType">
                                                        <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Register Date" DataField="reg_date">
                                                        <HeaderStyle HorizontalAlign="left" Width="30%"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="left" Width="30%"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                                                Text="Delete" CommandArgument='<%#Bind("reg_id")%>'>
                                                            </asp:LinkButton>
                                                            <asp:ConfirmButtonExtender ID="cbeConfirmDelete" runat="server" ConfirmText="Are you sure you want to delete record"
                                                                TargetControlID="lnkDelete">
                                                            </asp:ConfirmButtonExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkModify" runat="server" CausesValidation="False" CommandName="Modify"
                                                                Text="Modify" CommandArgument='<%#Bind("reg_id")%>'>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <PagerStyle CssClass="pager-row" />
                                            </asp:GridView>
                                            <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
