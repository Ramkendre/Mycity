<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="Replcae Juniors.aspx.cs" Inherits="MarketingAdmin_Replcae_Juniors"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
            <table cellpadding="0" cellspacing="0" width="100%" border="1">
                <tr>
                    <td align="center">
                        <div style="width: 90%">
                            <table cellpadding="0" cellspacing="0" border="0" width="95%" class="tables">
                                <tr>
                                    <td colspan="2" style="height: 20px;">
                                        <span class="warning1" style="color: Red;"></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <h3 style="text-align: center">
                                            <asp:Label ID="lblHeader" runat="server" Text="Replace Juniours"></asp:Label>
                                        </h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        &nbsp;&nbsp;<asp:Label ID="lblError" Visible="False" runat="server" CssClass="error"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="center">
                                       <b>Existing officer Details</b> 
                                    </td>
                                    <td align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        Mobile No.
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtmobileno" runat="server" CssClass="txtcss" MaxLength="10" 
                                            onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                        &nbsp;<asp:Button ID="btnSearch" runat="server" CssClass="button" OnClick="btnSearch_Click"
                                            Text="Search" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lo_fname" runat="server" Text="Existing officer Name"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lo_fname1" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="center">
                                        <asp:Label ID="lo_Rolename" runat="server" Text="Role Name"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lo_Rolename1" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lo_lname" runat="server" Text="Officer Leader  Name"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lo_lname1" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblo_lrolename" runat="server" Text="Leader Role Name"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblo_lrolename1" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                
                                <tr><td></td></tr>
                                <tr>
                                    <td colspan="2">Replace By
                                    </td>  
                                    <tr>
                                        <td align="center">
                                          <b>New officer Details</b>  
                                        </td>
                                        <td align="center">
                                            &nbsp;
                                        </td>
                                    </tr>
                                     <tr>
                                    <td align="center">
                                        Mobile No.
                                    </td>
                                    <td align="center">
                                        <asp:TextBox ID="txtnewmobileno" runat="server" CssClass="txtcss" MaxLength="10" 
                                            onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                        &nbsp;<asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
                                            Text="Search" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblnew_Oname" runat="server" Text="New officer Name"></asp:Label>
                                    </td>
                                    <td align="center">
                                     <%--   <asp:Label ID="lblnew_Oname1" runat="server" Text=""></asp:Label>
                                  --%>      <asp:TextBox ID="lblnew_Oname1" runat="server" Text="" Enabled="false"></asp:TextBox>
                                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="lblnew_Oname1"
                            WatermarkText="First Name" WatermarkCssClass="watermark">
                        </asp:TextBoxWatermarkExtender> <br />
                                            <asp:TextBox ID="txtlname" runat="server" Text="" Visible="false"></asp:TextBox>
                                              <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtlname"
                            WatermarkText="Last name" WatermarkCssClass="watermark">
                        </asp:TextBoxWatermarkExtender>
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="center">
                                        <asp:Label ID="lblnew_ORolename" runat="server" Text="Role Name"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblnew_ORolename1" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblnew_OLeaderNAme" runat="server" Text="Previous Officer Name"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblnew_OLeaderNAme1" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblnew_OLRolename" runat="server" Text="Previous Officer Role Name"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblnew_OLRolename1" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                    <tr>
                                        <td align="center">
                                            &nbsp;</td>
                                        <td align="center">
                                           <asp:Button ID="btnreplace" runat="server" CssClass="button" 
                                            Text="Replace" onclick="btnreplace_Click" /> 
                                             &nbsp;<asp:Button ID="btncacle" runat="server" CssClass="button" 
                                            Text="Cancle" onclick="btncacle_Click" /></td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            &nbsp;</td>
                                        <td align="center">
                                              &nbsp;</td>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <div class="grid" style="width: 100%">
                                                    <div class="rounded">
                                                        <div class="top-outer">
                                                            <div class="top-inner">
                                                                <div class="top">
                                                                    &nbsp;
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="mid-outer">
                                                            <div class="mid-inner">
                                                                <div class="mid">
                                                                    <div class="pager">
                                                                        <asp:GridView ID="gvschoolcode" runat="server" AllowPaging="True" 
                                                                            AutoGenerateColumns="False" CellPadding="5" CellSpacing="0" 
                                                                            CssClass="datatable" EmptyDataText="Data Not Available" GridLines="None" 
                                                                          
                                                                       
                                                                             PageSize="15" 
                                                                            Width="100%">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="friendid" HeaderText="ID" Visible="false">
                                                                                    <HeaderStyle HorizontalAlign="Left" Width="30%" />
                                                                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Fullname" HeaderText="Name">
                                                                                    <HeaderStyle HorizontalAlign="Left" Width="30%" />
                                                                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="usrMobileNo" HeaderText="Mobile No.">
                                                                                    <HeaderStyle HorizontalAlign="Left" Width="30%" />
                                                                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="RoleName" HeaderText="Role">
                                                                                    <HeaderStyle HorizontalAlign="left" Width="30%" />
                                                                                    <ItemStyle HorizontalAlign="left" Width="30%" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="RoleName" HeaderText="Active">
                                                                                    <HeaderStyle HorizontalAlign="left" Width="30%" />
                                                                                    <ItemStyle HorizontalAlign="left" Width="30%" />
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                            <RowStyle CssClass="row" HorizontalAlign="Center" />
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <PagerStyle CssClass="pager-row" />
                                                                        </asp:GridView>
                                                                        <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                                                    </div>
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
                                            </td>
                                        </tr>
                                    </tr>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
       
</asp:Content>
