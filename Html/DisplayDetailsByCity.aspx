<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="DisplayDetailsByCity.aspx.cs" Inherits="UI_DisplayDetailsByCity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <div>
        <asp:Panel runat="server" ID="pnlItemDescription">
            <table width="100%">
                <tr class="borderstyle">
                    <td align="center" style="color: Maroon">
                        <h3>
                            <asp:Label ID="lblItemName" runat="server" Text=""></asp:Label></h3>
                    </td>
                </tr>
                <tr class="itemHeaderBackground">
                    <td align="left">
                        <asp:Label ID="lblItemDescription" runat="server" Text="" CssClass="text2"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gvItemDisplay" runat="server" AutoGenerateColumns="false" EmptyDataText="No Matching Record Found"
                AllowPaging="true" GridLines="None" Width="99%" align="center" 
                AlternatingRowStyle-CssClass="alt" 
                onpageindexchanging="gvItemDisplay_PageIndexChanging">
                <Columns>
                    <asp:TemplateField ItemStyle-Height="30px">
                        <ItemTemplate>
                            <span style="margin-left: 05px;" class="tdLabelInner">
                                <asp:Label ID="attributeName" runat="server" Text='<%#Eval("attributeName")%>'>
                                </asp:Label>
                            </span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Height="30px">
                        <ItemTemplate>
                            <span style="color: Black; margin-left: 75px; font-weight: bold;">
                                <asp:Label ID="dot" runat="server" Text=":"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Height="30px">
                        <ItemTemplate>
                            <span class="grdTdValue">
                                <asp:Label runat="server" ID="attributeValue" Text='<%#Eval("attributeValue") %>'></asp:Label></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <%if (imageSet == 0)
              {
            %>
            <asp:GridView ID="gvImageSet1" runat="server" BorderColor="Black" Width="98%" ShowHeader="true"
                EmptyDataText="No Image For the Item" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblImageHeader" runat="server" Text="::Image Gallery::"></asp:Label>
                            <table width="100%">
                                <tr>
                                    <td colspan="2">
                                        <asp:Image ID="image1" runat="server" AlternateText="Image1" ImageUrl='<%#Eval("itemDtlImage1") %>'
                                            Width="100%" Height="75px" />
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="width: 50%">
                                        <asp:Image ID="image2" runat="server" AlternateText="Image1" ImageUrl='<%#Eval("itemDtlImage2") %>'
                                            Width="100%" Height="100px" />
                                    </td>
                                    <td style="width: 50%">
                                        <asp:Image ID="image3" runat="server" AlternateText="Image1" ImageUrl='<%#Eval("itemDtlImage3") %>'
                                            Width="100%" Height="100px" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <%}
              else if (imageSet == 1)
              {
            %>
            <asp:GridView ID="gvImageSet2" runat="server" BorderColor="Black" Width="98%" ShowHeader="true"
                EmptyDataText="No Image For the Item" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblImageHeader" runat="server" Text="::Image Gallery::"></asp:Label>
                            <table width="100%;">
                                <tr style="width: 100%; height: 150px;">
                                    <td style="width: 100%;">
                                        <asp:Image ID="image1" runat="server" AlternateText="Image1" ImageUrl='<%#Eval("itemDtlImage4") %>'
                                            Width="100%" Height="200px" />
                                    </td>
                                </tr>
                                <tr style="width: 100%; height: 150px;">
                                    <td style="width: 100%">
                                        <asp:Image ID="image2" runat="server" AlternateText="Image1" ImageUrl='<%#Eval("itemDtlImage5") %>'
                                            Width="100%" Height="200px" />
                                    </td>
                                </tr>
                                <tr style="width: 100%; height: 150px;">
                                    <td style="width: 100%">
                                        <asp:Image ID="image3" runat="server" AlternateText="Image1" ImageUrl='<%#Eval("itemDtlImage6") %>'
                                            Width="100%" Height="200px" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <%
                }
              else if (imageSet == 2)
              {
            %>
            <asp:GridView ID="gvImageSet3" runat="server" BorderColor="Black" Width="98%" ShowHeader="true"
                EmptyDataText="No Image For the Item" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblImageHeader" runat="server" Text="::Image Gallery::"></asp:Label>
                            <table width="100%">
                                <tr style="width:100%;">
                                    <td colspan="2">
                                        <asp:Image ID="image1" runat="server" AlternateText="Image1" ImageUrl='<%#Eval("itemDtlImage7") %>'
                                            Width="100%" Height="350px" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <%
                }
              else
              {
            %>
            No Image
            <%} %>
        </asp:Panel>
    </div>
</asp:Content>
