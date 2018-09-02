<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="CityInformationReg.aspx.cs" Inherits="MarketingAdmin_CityInformationReg" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <table class="innerTable">
        <tr>
            <td class="tdLabel" colspan="3" align="center">
                <asp:Label ID="lblHeader" runat="server" Text="City Information" Font-Bold="true"
                    ForeColor="Black" Font-Size="Larger"></asp:Label>
            </td>
        </tr>
    </table>
    <fieldset>
        <legend>General Information</legend>
        <table class="innerTable">
            <tr>
                <td class="tdLabel">
                    <asp:Label ID="Label19" runat="server" CssClass="lbl" Text="City Id: "></asp:Label>
                </td>
                <td class="tdText">
                    <asp:Label ID="myCityId" runat="server" Text="" Font-Bold="true"></asp:Label>
                </td>
                <td class="tdError">
                </td>
            </tr>
            <tr>
                <td class="tdLabel">
                    <asp:Label ID="Label18" runat="server" CssClass="lbl" Text="City Name: "></asp:Label>
                </td>
                <td class="tdText">
                    <asp:Label ID="myCityName" runat="server" Text="" Font-Bold="true"></asp:Label>
                </td>
                <td class="tdError">
                </td>
            </tr>
            <tr>
                <td class="tdLabel">
                    <asp:Label ID="lblAboutCity" runat="server"  CssClass="lbl"   Text="About City: "></asp:Label>
                </td>
                <td class="tdText">
                    <asp:TextBox ID="txtCityAbout" runat="server" TextMode="MultiLine" Width="160px" Height="60px"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="fteAboutPune" runat="server" TargetControlID="txtCityAbout"
                        FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers" ValidChars="&,()/. ">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td class="tdError">
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ControlToValidate="txtCityAbout" 
         ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="tdLabel">
                    <asp:Label ID="lblLatitude" runat="server" CssClass="lbl" Text="Latitude: "></asp:Label>
                </td>
                <td class="tdText">
                    <asp:TextBox ID="txtLatitude" runat="server" Width="160px"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="fteLatitude" runat="server" TargetControlID="txtLatitude"
                        FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers" ValidChars="&,()'/. ">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td class="tdError">
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLocation" 
         ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="tdLabel" style="height: 24px">
                    <asp:Label ID="lblLongtitude" runat="server" CssClass="lbl" Text="Longtitude: "></asp:Label>
                </td>
                <td class="tdText" style="height: 24px">
                    <asp:TextBox ID="txtLongtitude" runat="server" Width="160px"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="fteLongtitude" runat="server" TargetControlID="txtLongtitude"
                        FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers" ValidChars="&,()'/. ">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td class="tdError" style="height: 24px">
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtArea" 
         ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="tdLabel">
                    <asp:Label ID="Label2" runat="server" CssClass="lbl" Text="Area OF City: "></asp:Label>
                </td>
                <td class="tdText">
                    <asp:TextBox ID="txtArea" runat="server" Width="160px"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="fteCarpetArea" runat="server" TargetControlID="txtArea"
                        FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers" ValidChars="&,()/. ">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td class="tdError">
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCarpetArea" 
         ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="tdLabel">
                    <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Height From Sea Level: "></asp:Label>
                </td>
                <td class="tdText">
                    <asp:TextBox ID="txtHeightFromSea" runat="server" Width="160px"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="fteHeightFromSeaLevel" runat="server" TargetControlID="txtHeightFromSea"
                        FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers" ValidChars="&,()/. ">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td class="tdError">
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtHeightFromSea" 
         ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="tdLabel">
                    <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Language Spoken: "></asp:Label>
                </td>
                <td class="tdText">
                    <asp:TextBox ID="txtLanguage" runat="server" Width="160px"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="fteLanguage" runat="server" TargetControlID="txtLanguage"
                        FilterType="Custom,LowercaseLetters,UppercaseLetters" ValidChars="&,()/. ">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td class="tdError">
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtLanguage" 
         ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="tdLabel">
                    <asp:Label ID="Label4" runat="server" CssClass="lbl" Text="Literacy: "></asp:Label>
                </td>
                <td class="tdText">
                    <asp:TextBox ID="txtLiteracy" runat="server" Width="160px"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="fteLiteracy" runat="server" TargetControlID="txtLiteracy"
                        FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers" ValidChars="&,()/.% ">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td class="tdError">
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtLiteracy" 
         ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="tdLabel">
                    <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Population Of City: "></asp:Label>
                </td>
                <td class="tdText">
                    <asp:TextBox ID="txtPopulation" runat="server" Width="160px"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="ftePopulation" runat="server" TargetControlID="txtPopulation"
                        FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers" ValidChars="&,()/. ">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td class="tdError">
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPopulation" 
         ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>City Importance </legend>
        <table class="innerTable">
            <tr>
                <td class="tdLabel">
                    <asp:Label ID="Label6" runat="server" CssClass="lbl" Text="Historical Importance: "></asp:Label>
                </td>
                <td class="tdText">
                    <asp:TextBox ID="txtHistoricalImp" runat="server" Width="160px" TextMode="MultiLine"
                        Height="60px"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="fteHistoricalImp" runat="server" TargetControlID="txtHistoricalImp"
                        FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers" ValidChars="&,()/. ">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td class="tdError">
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtHistoricalImp" 
         ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="tdLabel">
                    <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Geographical Importance: "></asp:Label>
                </td>
                <td class="tdText">
                    <asp:TextBox ID="txtGeographicalImp" runat="server" Height="60px" Width="160px" TextMode="MultiLine"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="fteGeographicalImp" runat="server" TargetControlID="txtGeographicalImp"
                        FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers" ValidChars="&,()/. ">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td class="tdError">
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtGeographicalImp" 
         ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="tdLabel">
                    <asp:Label ID="Label8" runat="server"  CssClass="lbl" Text="Social Importance: "></asp:Label>
                </td>
                <td class="tdText">
                    <asp:TextBox ID="txtSocialImp" runat="server" Height="60px" Width="160px" TextMode="MultiLine"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="fteSocialImp" runat="server" TargetControlID="txtSocialImp"
                        FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers" ValidChars="&,()/. ">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td class="tdError">
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtSocialImp" 
         ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="tdLabel">
                    <asp:Label ID="Label9" runat="server"  CssClass="lbl" Text="Regional Importance: "></asp:Label>
                </td>
                <td class="tdText">
                    <asp:TextBox ID="txtRegionalImp" runat="server" Height="60px" Width="160px" TextMode="MultiLine"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="fteRegionalImp" runat="server" TargetControlID="txtRegionalImp"
                        FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers" ValidChars="&,()/. ">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td class="tdError">
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtRegionalImp" 
         ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="tdLabel">
                    <asp:Label ID="Label10" runat="server"  CssClass="lbl" Text="Political Importance: "></asp:Label>
                </td>
                <td class="tdText">
                    <asp:TextBox ID="txtPoliticalImp" runat="server" Height="60px" Width="160px" TextMode="MultiLine"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="ftePoliticalImp" runat="server" TargetControlID="txtPoliticalImp"
                        FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers" ValidChars="&,()/. ">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td class="tdError">
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtPoliticalImp" 
         ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Reach Pune</legend>
        <table class="innerTable">
            <tr>
                <td class="tdLabel">
                    <asp:Label ID="Label15" runat="server" CssClass="lbl"  Text="By Rail "></asp:Label>
                </td>
                <td class="tdText">
                    <asp:TextBox ID="txtByRail" runat="server" TextMode="MultiLine" Height="40px" Width="160px"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="fteByRail" runat="server" TargetControlID="txtByRail"
                        FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers" ValidChars="&,()/. ">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td class="tdError">
                    <%--        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtByRail"
         ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="tdLabel">
                    <asp:Label ID="Label16" runat="server"  CssClass="lbl" Text="By Air: "></asp:Label>
                </td>
                <td class="tdText">
                    <asp:TextBox ID="txtByAir" runat="server" TextMode="MultiLine" Height="40px" Width="160px"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="fteByAir" runat="server" TargetControlID="txtByAir"
                        FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers" ValidChars="&,()/. ">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td class="tdError">
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtByAir" 
         ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="tdLabel">
                    <asp:Label ID="Label17" runat="server"  CssClass="lbl" Text="By Bus: "></asp:Label>
                </td>
                <td class="tdText">
                    <asp:TextBox ID="txtByBus" runat="server" TextMode="MultiLine" Height="40px" Width="160px"></asp:TextBox>
                </td>
                <td class="tdError">
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtByBus" 
         ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
        </table>
    </fieldset>
    <table class="innerTable">
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button"
                    OnClick="btnUpdate_Click" UseSubmitBehavior="false" />
            </td>
        </tr>
    </table>
  
</asp:Content>


