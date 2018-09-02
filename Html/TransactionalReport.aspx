<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="TransactionalReport.aspx.cs" Inherits="html_TransactionalReport" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="MainDiv">
        <div class="InnerDiv">
            <table class="tblSubFull2">
                <tr>
                    <td colspan="2" align="center">
                        <center>
                            <img src="../KResource/Images/QuickSmsImg.png" width="30px" height="20px" alt="" /><span
                                class="spanTitle">Transactional Balance Report</span>
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
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="cssbtn" OnClick="btnShow_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="cssbtn" OnClick="btnExit_Click" />
                        <asp:Button ID="btnDwn" runat="server" Text="Download" CssClass="cssbtn" OnClick="btnDwn_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GvBalence" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="10"
                            OnPageIndexChanging="GvBalence_PageIndexChanging" CssClass="gridview" EmptyDataText="No Report">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id"></asp:BoundField>
                                <asp:BoundField DataField="MobileNo" HeaderText="MobileNo"></asp:BoundField>
                                <asp:BoundField DataField="Message" HeaderText="Message"></asp:BoundField>
                                <asp:BoundField DataField="SendDate" HeaderText="Date"></asp:BoundField>
                                <asp:BoundField DataField="No_smssent" HeaderText="Total no.of sms sent"></asp:BoundField>
                                <asp:BoundField DataField="SMSLength" HeaderText="SMS Length"></asp:BoundField>
                                <asp:BoundField DataField="SMSCount" HeaderText="SMS Count"></asp:BoundField>
                                <asp:BoundField DataField="Pre_SMSbal" HeaderText="Previous Balance"></asp:BoundField>
                                <asp:BoundField DataField="New_SMSbal" HeaderText="Current Balance"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
