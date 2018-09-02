<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="CityInfoPage.aspx.cs" Inherits="Html_CityInfoPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="MainDiv">
        <div class="InnerDiv">
            <table class="tblSubFull2">
                <tr>
                    <td>
                        <center>
                            <span class="spanTitle">City Information</span>
                            <br />
                            <br />
                        </center>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvCityInfo" runat="server" Width="100%" AutoGenerateColumns="false"
                            ShowHeader="false">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table width="100%" style="vertical-align: top">
                                            <tr>
                                                <td>
                                                    City:
                                                    <asp:Label ID="myCityName" runat="server" Text='<%#Eval("cityName") %>' Font-Bold="true"
                                                        Font-Size="14px" ForeColor="Maroon"></asp:Label>
                                                </td>
                                            </tr>
                                            <%if (ctAbout != "")
                                              { %>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="Label1" runat="server" Text="About City:"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("cityAbout") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <%}%>
                                            <% if (ctLatitude != "")
                                               { %>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="Label4" runat="server" Text="Latitude:"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("cityLatitude") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <%}%>
                                            <% if (ctLongtitude != "")
                                               { %>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="Label6" runat="server" Text="Longtitude:"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("cityLongtitude") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <%}%>
                                            <% if (ctArea != "")
                                               {                                        
                                            %>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="Label8" runat="server" Text="Area:"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("cityArea") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <%}%>
                                            <% if (ctHeightFromSea != "")
                                               {                                        
                                            %>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="Label10" runat="server" Text="City Height From Sea:"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("cityHeightFromSea") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <%}%>
                                            <% if (ctLanguage != "")
                                               {                                        
                                            %>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="Label12" runat="server" Text="Language Spoken:"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <asp:Label ID="Label13" runat="server" Text='<%#Eval("cityLanguage") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <%}%>
                                            <% if (ctLiteracy != "")
                                               {                                        
                                            %>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="Label14" runat="server" Text="Literacy:"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <asp:Label ID="Label15" runat="server" Text='<%#Eval("cityLiteracy") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <%}%>
                                            <% if (ctPopulation != "")
                                               {                                        
                                            %>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="Label16" runat="server" Text="Population:"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <asp:Label ID="Label17" runat="server" Text='<%#Eval("cityPopulation") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <%}%>
                                            <% if (ctHI != "")
                                               {                                        
                                            %>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="Label18" runat="server" Text="Historical Importance:"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <asp:Label ID="Label19" runat="server" Text='<%#Eval("cityHistoricalImp") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <%}%>
                                            <% if (ctGI != "")
                                               {                                        
                                            %>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="Label20" runat="server" Text="Geogrphical Importance:"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <asp:Label ID="Label21" runat="server" Text='<%#Eval("cityGeographicalImp") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <%}%>
                                            <% if (ctSI != "")
                                               {                                        
                                            %>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="Label22" runat="server" Text="Social Importance:"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <asp:Label ID="Label23" runat="server" Text='<%#Eval("citySocialImp") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <%}%>
                                            <% if (ctRI != "")
                                               {                                        
                                            %>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="Label24" runat="server" Text="Regional Importance:"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <asp:Label ID="Label25" runat="server" Text='<%#Eval("cityRegionalImp") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <%}%>
                                            <% if (ctPI != "")
                                               {                                        
                                            %>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="Label26" runat="server" Text="Political Importance:"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <asp:Label ID="Label27" runat="server" Text='<%#Eval("cityPoliticalImp") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <%}%>
                                            <% if (ctByRail != "")
                                               {                                        
                                            %>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="Label28" runat="server" Text="Approach By Rail:"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <asp:Label ID="Label29" runat="server" Text='<%#Eval("cityByAirApro") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <%}%>
                                            <% if (ctByAir != "")
                                               {                                        
                                            %>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="Label30" runat="server" Text="Approach By Air:"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <asp:Label ID="Label31" runat="server" Text='<%#Eval("cityByAirApro") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <%}%>
                                            <% if (ctByBus != "")
                                               {                                        
                                            %>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="Label32" runat="server" Text="Approach By Bus:"></asp:Label>
                                                </td>
                                                <td valign="top">
                                                    <asp:Label ID="Label33" runat="server" Text='<%#Eval("cityByBusApro") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <%} %>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
