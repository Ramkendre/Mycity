<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="PromotionalReport.aspx.cs" Inherits="html_PromotionalReport"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function openPopup(strOpen) {
            open(strOpen, "Message",
         "status=1, width=600, height=400, top=100, left=300");
        }
      
    </script>

    <div class="MainDiv">
        <div class="InnerDiv">
            <table class="tblSubFull2">
                <tr>
                    <td colspan="2" align="center">
                        <center>
                            <img src="../KResource/Images/QuickSmsImg.png" width="30px" height="20px" alt="" /><span
                                class="spanTitle">Promotional Balance Report</span>
                        </center>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Select Month :
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="cssddlwidth">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">Jan</asp:ListItem>
                            <asp:ListItem Value="2">Feb</asp:ListItem>
                            <asp:ListItem Value="3">Mar</asp:ListItem>
                            <asp:ListItem Value="4">April</asp:ListItem>
                            <asp:ListItem Value="5">May</asp:ListItem>
                            <asp:ListItem Value="6">Jun</asp:ListItem>
                            <asp:ListItem Value="7">July</asp:ListItem>
                            <asp:ListItem Value="8">Aug</asp:ListItem>
                            <asp:ListItem Value="9">Sept</asp:ListItem>
                            <asp:ListItem Value="10">Oct</asp:ListItem>
                            <asp:ListItem Value="11">Nov</asp:ListItem>
                            <asp:ListItem Value="12">Dec</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Select Year :
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="cssddlwidth">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">2013</asp:ListItem>
                            <asp:ListItem Value="2">2014</asp:ListItem>
                            <asp:ListItem Value="3">2015</asp:ListItem>
                            <asp:ListItem Value="4">2016</asp:ListItem>
                            <asp:ListItem Value="5">2017</asp:ListItem>
                            <asp:ListItem Value="6">2018</asp:ListItem>
                            <asp:ListItem Value="7">2019</asp:ListItem>
                            <asp:ListItem Value="8">2020</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="cssbtn" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="cssbtn" OnClick="btnCancel_Click" />
                        <asp:Button ID="btnDwn" runat="server" Text="Download" CssClass="cssbtn" OnClick="btnDwn_Click"
                            ForeColor="#005E5E" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GvBalence" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            CssClass="gridview" PageSize="10" EmptyDataText="No Report" OnPageIndexChanging="GvBalence_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id"></asp:BoundField>
                                <asp:BoundField DataField="SendFrom" HeaderText="Mobile No"></asp:BoundField>
                                <asp:BoundField DataField="SendTo" HeaderText="Send To"></asp:BoundField>
                                <asp:BoundField DataField="sentMessage" HeaderText="Message"></asp:BoundField>
                                <asp:BoundField DataField="TotalSent" HeaderText="Total SMS Sent"></asp:BoundField>
                                <asp:BoundField DataField="Totallength" HeaderText="SMS Length"></asp:BoundField>
                                <asp:BoundField DataField="TotalSms" HeaderText="SMS Count"></asp:BoundField>
                                <asp:BoundField DataField="balance" HeaderText="Balance"></asp:BoundField>
                                <asp:BoundField DataField="EntryDate" HeaderText="Date"></asp:BoundField>
                                <asp:TemplateField HeaderText="Details">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <%-- <asp:ImageButton ID="ImageButton1" CommandArgument='<%#Bind("usrMobileno") %>' runat="server"
                                                    ImageUrl="~/Resources/Images/ico_yes1.gif" CommandName="Push"></asp:ImageButton>--%>
                                        <a href="javascript:openPopup('../PopUpFile/PromotionalDetails.aspx?Id=<%# Eval("Id") %>')">
                                            Show</a>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
