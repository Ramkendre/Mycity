<%@ Page Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true"
    CodeFile="PWPProfileInfo.aspx.cs" Inherits="MarketingAdmin_PWPProfileInfo" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="outsidediv">
        <div class="headingdiv">
            Profiles Details
        </div>
        <hr />
        <div style="width: 95%; margin-left: 5%;">
            <div style="width: 19.7%; text-align: center; float: left; background-color: #BFF7EE;
                border: 2px outset;">
                <asp:LinkButton ID="lnkPlayer" runat="server" OnClick="lnkPlayert_Click">Player</asp:LinkButton>
            </div>
            <div style="width: 19.7%; text-align: center; float: left; background-color: #BFF7EE;
                border: 2px outset;">
                <asp:LinkButton ID="lnkClub" runat="server" OnClick="lnkClub_Click">Club</asp:LinkButton>
            </div>
            <div style="width: 19.7%; text-align: center; float: left; background-color: #BFF7EE;
                border: 2px outset;">
                <asp:LinkButton ID="lnkCoach" runat="server" OnClick="lnkCoach_Click">Coach</asp:LinkButton>
            </div>
            <div style="width: 19.7%; text-align: center; float: left; background-color: #BFF7EE;
                border: 2px outset;">
                <asp:LinkButton ID="lnkInfrast" runat="server" OnClick="lnkInfrast_Click">Infrastructure</asp:LinkButton>
            </div>
            <div style="width: 19.7%; text-align: center; float: left; background-color: #BFF7EE;
                border: 2px outset;">
                <asp:LinkButton ID="lnkSpecialist" runat="server" OnClick="lnkSpecialist_Click">Specialist</asp:LinkButton>
            </div>
        </div>
        <br />
       <%-- <br />
        <br />--%>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <div style="height: 200px; border: 1px solid #dddddd;">
                    <asp:GridView ID="gvItem" runat="server" CssClass="gridview" AllowPaging="true" PageSize="6"
                        AutoGenerateColumns="false" OnPageIndexChanging="gvItem_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr.No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PID" HeaderText="PID" Visible="false" />
                            <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                            <asp:BoundField DataField="FName" HeaderText="First Name" />
                            <asp:BoundField DataField="EmailId" HeaderText="Email-Id" />
                            <%--<asp:BoundField DataField="Remark" HeaderText="Remark" />
                            <asp:BoundField DataField="Position" HeaderText="Position" />
                            <asp:BoundField DataField="Experience" HeaderText="Experience" />
                            <asp:BoundField DataField="TeamRep" HeaderText="TeamRep" />
                            <asp:BoundField DataField="Summary" HeaderText="Summary" />
                            <asp:BoundField DataField="Duration" HeaderText="Duration" />
                            <asp:BoundField DataField="LinkPages" HeaderText="LinkPages" />--%>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div style="height: 200px; border: 1px solid #dddddd;">
                    <asp:GridView ID="gvItemClub" runat="server" CssClass="gridview" AllowPaging="true"
                        PageSize="6" AutoGenerateColumns="false" 
                        onpageindexchanging="gvItemClub_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr.No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CLID" HeaderText="CLID" Visible="false" />
                            <asp:BoundField DataField="MobileNo" HeaderText="Mobile No" />
                            <asp:BoundField DataField="FName" HeaderText="First Name" />
                            <%--<asp:BoundField DataField="LName" HeaderText="Last Name" />--%>
                            <asp:BoundField DataField="TeamName" HeaderText="Club Name" />
                            <asp:BoundField DataField="TContactDetails" HeaderText="Email-ID" />
                          <%--  <asp:BoundField DataField="TSummary" HeaderText="Experience" />
                            <asp:BoundField DataField="League" HeaderText="TeamRep" />--%>
                            <%--<asp:BoundField DataField="Summary" HeaderText="Summary" />
                            <asp:BoundField DataField="Duration" HeaderText="Duration" />
                            <asp:BoundField DataField="LinkPages" HeaderText="LinkPages" />--%>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:View>
            <asp:View ID="View3" runat="server">
                 <div style="height: 200px; border: 1px solid #dddddd;">
                    <asp:GridView ID="gvItemCoach" runat="server" CssClass="gridview" AllowPaging="true"
                        PageSize="2" AutoGenerateColumns="false" 
                         onpageindexchanging="gvItemCoach_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr.No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CID" HeaderText="CID" Visible="false" />
                            <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                            <asp:BoundField DataField="FName" HeaderText="First Name" />
                            <asp:BoundField DataField="LName" HeaderText="Last Name" />
                            <asp:BoundField DataField="Experience" HeaderText="Experience" />
                            <asp:BoundField DataField="TeamRep" HeaderText="TeamRep" />
                            <asp:BoundField DataField="Remark" HeaderText="Remark" />
                            
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:View>
            <asp:View ID="View4" runat="server">
             <div style="height: 200px; border: 1px solid #dddddd;">
                    <asp:GridView ID="gvItemInfra" runat="server" CssClass="gridview" AllowPaging="true"
                        PageSize="2" AutoGenerateColumns="false" 
                        onpageindexchanging="gvItemInfra_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr.No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CID" HeaderText="CID" Visible="false" />
                            <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                            <asp:BoundField DataField="FName" HeaderText="First Name" />
                            <asp:BoundField DataField="LName" HeaderText="Last Name" />
                            <asp:BoundField DataField="GroundName" HeaderText="Experience" />
                            <asp:BoundField DataField="Location" HeaderText="TeamRep" />
                            <asp:BoundField DataField="Remark" HeaderText="Remark" />
                            
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:View>
            <asp:View ID="View5" runat="server">
            <div style="height: 200px; border: 1px solid #dddddd;">
                    <asp:GridView ID="gvItemSpec" runat="server" CssClass="gridview" AllowPaging="true"
                        PageSize="2" AutoGenerateColumns="false" 
                        onpageindexchanging="gvItemSpec_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Sr.No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CID" HeaderText="CID" Visible="false" />
                            <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                            <asp:BoundField DataField="FName" HeaderText="First Name" />
                            <asp:BoundField DataField="LName" HeaderText="Last Name" />
                            <asp:BoundField DataField="SExperience" HeaderText="Experience" />
                            <%--<asp:BoundField DataField="Location" HeaderText="TeamRep" />--%>
                            <asp:BoundField DataField="Remark" HeaderText="Remark" />
                            
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
