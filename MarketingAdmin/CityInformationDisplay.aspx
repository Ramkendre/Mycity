<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="CityInformationDisplay.aspx.cs" Inherits="MarketingAdmin_CityInformationDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="innerTable">
    </table>
    <table style="width: 100%" class="innerTable" cellspacing="7px">
        <tr>
        <td class="grid" style="width: 50%">
         <div class="rounded">
                    <div class="top-outer">
                        <div class="top-inner">
                            <div class="top">
                                &nbsp;
                            </div>
                        </div>
                    </div>
    <asp:GridView ID="gvCityInfoDisplay" runat="server" AutoGenerateColumns="false" 
        Width="100%" onselectedindexchanged="gvCityInfoDisplay_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <fieldset>
                        <legend class="legendHeaderStyle">City General Information</legend>
                        <table class="innerTable">
                            <tr>
                                <td align="right" colspan="3">
                                    <asp:LinkButton ID="btnUpdateCity" runat="server" Text="Update City" PostBackUrl="~/MarketingAdmin/CityInformationReg.aspx">Update City</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel">
                                    <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="City Name:"></asp:Label>
                                </td>
                                <td class="tdTextD">
                                    <asp:Label ID="myName" runat="server" Text='<%#Eval("cityName") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel">
                                    <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="About City:"></asp:Label>
                                </td>
                                <td class="tdTextD">
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("cityAbout") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel">
                                    <asp:Label ID="Label4" runat="server" CssClass="lbl"  Text="Area:"></asp:Label>
                                </td>
                                <td class="tdTextD">
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("cityArea") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel">
                                    <asp:Label ID="Label10" runat="server"  CssClass="lbl" Text="City Latitude:"></asp:Label>
                                </td>
                                <td class="tdTextD">
                                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("cityLatitude") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel">
                                    <asp:Label ID="Label8" runat="server" CssClass="lbl"  Text="City Longtitude:"></asp:Label>
                                </td>
                                <td class="tdTextD">
                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("cityLongtitude") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel">
                                    <asp:Label ID="Label14" runat="server" CssClass="lbl"  Text="Language:"></asp:Label>
                                </td>
                                <td class="tdTextD">
                                    <asp:Label ID="Label15" runat="server" Text='<%#Eval("cityLanguage") %>'></asp:Label>
                                </td>
                            </tr>
                            <%--   <tr>
                            <td class="tdLabel">
                                <asp:Label ID="Label16" runat="server" Text="Carpet Area:"></asp:Label>
                            </td>
                            <td class="tdTextD">
                                <asp:Label ID="Label17" runat="server" Text='<%#Eval("cityArea") %>'></asp:Label>
                            </td>
                        </tr>--%>
                            <tr>
                                <td class="tdLabel"> 
                                    <asp:Label ID="Label18" runat="server"  CssClass="lbl" Text="Height From Sea:"></asp:Label>
                                </td>
                                <td class="tdTextD">
                                    <asp:Label ID="Label19" runat="server" Text='<%#Eval("cityHeightFromSea") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel">
                                    <asp:Label ID="Label20" runat="server" CssClass="lbl"  Text="Literacy:"></asp:Label>
                                </td>
                                <td class="tdTextD">
                                    <asp:Label ID="Label21" runat="server" Text='<%#Eval("cityLiteracy") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel">
                                    <asp:Label ID="Label6" runat="server" CssClass="lbl"  Text="Population:"></asp:Label>
                                </td>
                                <td class="tdTextD">
                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("cityPopulation") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <fieldset>
                        <legend class="legendHeaderStyle">Importance</legend>
                        <table class="innerTable">
                            <tr>
                                <td class="tdLabel">
                                    <asp:Label ID="Label22" runat="server" CssClass="lbl"  Text="Historical Importance:"></asp:Label>
                                </td>
                                <td class="tdTextD">
                                    <asp:Label ID="Label23" runat="server" Text='<%#Eval("cityHistoricalImp") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel">
                                    <asp:Label ID="Label24" runat="server" CssClass="lbl"  Text="Geographical Importance:"></asp:Label>
                                </td>
                                <td class="tdTextD">
                                    <asp:Label ID="Label25" runat="server" Text='<%#Eval("cityGeographicalImp") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel">
                                    <asp:Label ID="Label26" runat="server" CssClass="lbl"  Text="Social Importance:"></asp:Label>
                                </td>
                                <td class="tdTextD">
                                    <asp:Label ID="Label27" runat="server" Text='<%#Eval("citySocialImp") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel">
                                    <asp:Label ID="Label28" runat="server" CssClass="lbl"  Text="Regional Importance:"></asp:Label>
                                </td>
                                <td class="tdTextD">
                                    <asp:Label ID="Label29" runat="server" Text='<%#Eval("cityRegionalImp") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel">
                                    <asp:Label ID="Label30" runat="server"  CssClass="lbl" Text="Political Importance:"></asp:Label>
                                </td>
                                <td class="tdTextD">
                                    <asp:Label ID="Label31" runat="server" Text='<%#Eval("cityPoliticalImp") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <fieldset>
                        <legend class="legendHeaderStyle">Approach City</legend>
                        <table class="innerTable">
                            <tr>
                                <td class="tdLabel">
                                    <asp:Label ID="Label40" runat="server" CssClass="lbl"  Text="Reach By Air:"></asp:Label>
                                </td>
                                <td class="tdTextD">
                                    <asp:Label ID="Label41" runat="server" Text='<%#Eval("cityByAirApro") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel">
                                    <asp:Label ID="Label42" runat="server" CssClass="lbl"  Text="Reach By Bus:"></asp:Label>
                                </td>
                                <td class="tdTextD">
                                    <asp:Label ID="Label43" runat="server"  Text='<%#Eval("cityByBusApro") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel">
                                    <asp:Label ID="Label44" runat="server" CssClass="lbl"  Text="Reach By Rail:"></asp:Label>
                                </td>
                                <td class="tdTextD">
                                    <asp:Label ID="Label45" runat="server" Text='<%#Eval("cityByRailApro") %>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </div>
    </td></tr>
    </table>
     
</asp:Content>


