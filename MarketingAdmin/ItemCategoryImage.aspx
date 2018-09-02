<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MarketingMaster.master" AutoEventWireup="true" CodeFile="ItemCategoryImage.aspx.cs" Inherits="MarketingAdmin_ItemCategoryImage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function ClientValidate(source, arguments) {
            var File_Name = arguments.Value;
            var index = File_Name.indexOf(".");
            var str = File_Name.substring(index + 1);

            if (index != "-1") {
                if (str == "jpg" || str == "JPG" || str == "GIF" || str == "gif" || str == "BMP" || str == "bmp" || str == "PNG" || str == "png" || str == "jpeg" || str == "JPEG") {
                    arguments.IsValid = true;
                }
                else {
                    arguments.IsValid = false;
                }
            }
            else {
                arguments.IsValid = false;
            }
        }
    </script>

    <table class="innerTable" cellspacing="10px">
        <tr>
            <td colspan="3" align="center">
                <h3>
                    <asp:Label ID="lblheader" runat="server" Text="Item Category Image"></asp:Label></h3>
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Label ID="lblSelectItem" runat="server" CssClass="lbl" Text=" Select Item"></asp:Label>
                <label class="lblStar">*</label>
            </td>
            <td class="tdText">
                <asp:DropDownList ID="ddlSelectItem" runat="server" Width="160px" OnSelectedIndexChanged="ddlSelectItem_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true"
                    ControlToValidate="ddlSelectItem" InitialValue="" ErrorMessage="* Select  Item"
                    Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Label ID="lblSelectCategory" runat="server"  CssClass="lbl" Text="Select Category:"></asp:Label>
                 <label class="lblStar">*</label>
            </td>
            <td class="tdText">
                <asp:DropDownList ID="ddlSelectCategory" runat="server" Width="160px" OnSelectedIndexChanged="ddlSelectCategory_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSelectCategory"
                    InitialValue="" SetFocusOnError="true" ErrorMessage="* Select catgory" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Label ID="lblSelectImageSet" runat="server" CssClass="lbl"  Text="Select ImageType:"></asp:Label>
                 <label class="lblStar">*</label>
            </td>
            <td class="tdText">
                <asp:DropDownList ID="ddlImageType" runat="server" AutoPostBack="true" 
                    OnSelectedIndexChanged="ddlImageType_SelectedIndexChanged" Height="22px" 
                    style="height: 22px">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Value="0">Image Type 1</asp:ListItem>
                    <asp:ListItem Value="1">Image Type 2</asp:ListItem>
                    <asp:ListItem Value="2">Image Type 3</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="tdError">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlImageType"
                    InitialValue="" SetFocusOnError="true" ErrorMessage="* Select Image Set" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender19" runat="server" TargetControlID="RequiredFieldValidator9">
                </asp:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Button ID="btnSubmitImageSet" runat="server" Text="Set Image" ValidationGroup="other"
                    OnClick="btnSubmitImageSet_Click" CssClass="button" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table>
        <tr>
            <td >
                <asp:LinkButton ID="lnkView1" runat="server" Text="Image Set 1" ValidationGroup="other"
                    OnClick="lnkView1_Click"></asp:LinkButton> 
                    <label> || </label>
                <asp:LinkButton ID="lnkView2" runat="server" Text="Image Set 2" ValidationGroup="other"
                    OnClick="lnkView2_Click"></asp:LinkButton>
                    <label> || </label>
                <asp:LinkButton ID="lnkView3" runat="server" Text="Image Set 3" ValidationGroup="other"
                    OnClick="lnkView3_Click"></asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:MultiView ID="mvwMain" runat="server" ActiveViewIndex="0">
        <asp:View ID="vwImageSet1" runat="server">
            <label class="lblHeader">Image Set 1</label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Panel ID="pnlShowImage" runat="server" Width="100%">
                <asp:GridView ID="gvShowImage" runat="server" AutoGenerateColumns="False" BorderColor="AliceBlue"
                    BorderStyle="Inset" BorderWidth="2px" EmptyDataText="No Image Uploaded...Provide some Image"
                    OnRowCommand="gvShowImage_RowCommand" Width="75%">
                    <Columns>
                        <asp:ImageField DataImageUrlField="itemDtlImage1" HeaderText="Image">
                            <ControlStyle Height="100px" Width="100px" />
                        </asp:ImageField>
                        <asp:ImageField DataImageUrlField="itemDtlImage2" HeaderText="Image">
                            <ControlStyle Height="100px" Width="100px" />
                        </asp:ImageField>
                        <asp:ImageField DataImageUrlField="itemDtlImage3" HeaderText="Image">
                            <ControlStyle Height="100px" Width="100px" />
                        </asp:ImageField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnEditImage" runat="server" CommandArgument='<%#Eval("imageId")+","+Eval("imageName1")+","+Eval("imageDescription1")+","+Eval("itemDtlImage1")+","+Eval("itemDtlImage2")+","+Eval("itemDtlImage3") %>'
                                    CommandName="EditImage" Text="Edit" ValidationGroup="other" CssClass="button" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="pnlAddItemImage1" runat="server">
                <br />
                <br />
                <table class="innerTable">
                    <tr>
                        <td>
                            <asp:Label ID="lblImageName" runat="server" CssClass="lbl" Text="Image Name: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtImageName" runat="server" ValidationGroup="imageupload" Width="180px" MaxLength="80"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="fteImageName" runat="server" FilterType="Custom,LowercaseLetters,UppercaseLetters"
                                TargetControlID="txtImageName" ValidChars="&amp;,()/. ">
                            </asp:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rqdValidatortxtImageName" runat="server" ControlToValidate="txtImageName"
                                Display="None" ErrorMessage="* Enter Image Name"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="vcetxtImageName" runat="server" Enabled="True"
                                TargetControlID="rqdValidatortxtImageName">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align:top;">
                            <asp:Label ID="lblImageDesc" runat="server" CssClass="lbl" Text="Image Description: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtImageDesc" runat="server" Height="80px" TextMode="MultiLine" MaxLength="250"
                                ValidationGroup="imageupload" Width="180px"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="fteImageDescription" runat="server" FilterType="Custom,LowercaseLetters,UppercaseLetters"
                                TargetControlID="txtImageDesc" ValidChars="&amp;,()/. ">
                            </asp:FilteredTextBoxExtender>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblImage1"  runat="server" CssClass="lbl" Text="Image 1: "></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="uplImage1" runat="server" onkeydown="return false;" onkeypress="return false;" />
                            <asp:Label ID="lblImage1Info" runat="server" ForeColor="Red" Text="Upload Image Of Type1 (400x100)"></asp:Label>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="reqFileUpload1" runat="server" ControlToValidate="uplImage1"
                                Display="None" ErrorMessage="* Please select an image to upload." ValidationGroup="imageupload"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ClientValidate"
                                ControlToValidate="uplImage1" Display="None" ErrorMessage="* Please  Select [ GIF , JPEG , BMP, PNG ] Images Only"
                                ValidationGroup="imageupload"></asp:CustomValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True"
                                TargetControlID="reqFileUpload1">
                            </asp:ValidatorCalloutExtender>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True"
                                TargetControlID="CustomValidator1">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblImage2" runat="server" CssClass="lbl" Text="Image 2: "></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="uplImage2" runat="server" onkeydown="return false;" onkeypress="return false;" />
                            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Upload Image Of Type2 (200x100)"></asp:Label>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="reqFileUpload2" runat="server" ControlToValidate="uplImage2"
                                Display="None" ErrorMessage="* Please select an image to upload." ValidationGroup="imageupload"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="CustomValidator2" runat="server" ClientValidationFunction="ClientValidate"
                                ControlToValidate="uplImage2" Display="None" ErrorMessage="* Please  Select [ GIF , JPEG , BMP, PNG ] Images Only"
                                ValidationGroup="imageupload"></asp:CustomValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True"
                                TargetControlID="reqFileUpload2">
                            </asp:ValidatorCalloutExtender>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True"
                                TargetControlID="CustomValidator2">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblImage3" runat="server" CssClass="lbl" onkeydown="return false;" onkeypress="return false;"
                                Text="Image 3: "></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="uplImage3" runat="server" />
                            <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="Upload Image Of Type3 (200x100)"></asp:Label>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="reqFileUpload3" runat="server" ControlToValidate="uplImage3"
                                Display="None" ErrorMessage="* Please select an image to upload." ValidationGroup="imageupload"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="CustomValidator3" runat="server" ClientValidationFunction="ClientValidate"
                                ControlToValidate="uplImage3" Display="None" ErrorMessage="* Please  Select [ GIF , JPEG , BMP, PNG ] Images Only"
                                ValidationGroup="imageupload"></asp:CustomValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True"
                                TargetControlID="reqFileUpload3">
                            </asp:ValidatorCalloutExtender>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True"
                                TargetControlID="CustomValidator3">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
                                ValidationGroup="imageupload" CssClass="button" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:View>
        <asp:View ID="vwImageSet2" runat="server">
            <label class="lblHeader">Image Set 2</label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <br />
            <asp:Panel ID="Panel1" runat="server" Width="100%">
                <asp:GridView ID="gvShowImageSet2" runat="server" Width="75%" AutoGenerateColumns="False"
                    EmptyDataText="No Image Uploaded...Provide your Image" BorderColor="AliceBlue"
                    BorderWidth="2px" BorderStyle="Inset" OnRowCommand="gvShowImageSet2_RowCommand">
                    <Columns>
                        <asp:ImageField HeaderText="Image" DataImageUrlField="itemDtlImage4">
                            <ControlStyle Height="100px" Width="100px"></ControlStyle>
                        </asp:ImageField>
                        <asp:ImageField HeaderText="Image" DataImageUrlField="itemDtlImage5">
                            <ControlStyle Height="100px" Width="100px"></ControlStyle>
                        </asp:ImageField>
                        <asp:ImageField HeaderText="Image" DataImageUrlField="itemDtlImage6">
                            <ControlStyle Height="100px" Width="100px"></ControlStyle>
                        </asp:ImageField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnEditImage" runat="server" Text="Edit" CommandName="EditImage"
                                    ValidationGroup="other" CommandArgument='<%#Eval("imageId")+","+Eval("imageName2")+","+Eval("imageDescription2")+","+Eval("itemDtlImage4")+","+Eval("itemDtlImage5")+","+Eval("itemDtlImage6") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="pnlAddItemImage2" runat="server">
                <br />
                <br />
                <table class="innerTable">
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server"  CssClass="lbl" Text="Image Name: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtImageName2" runat="server" Width="180px" ValidationGroup="imageupload2" MaxLength="80"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="fteImageName2" runat="server" TargetControlID="txImageDescription2"
                                FilterType="Custom,LowercaseLetters,UppercaseLetters" ValidChars="&,()/. ">
                            </asp:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Enter Image Name"
                                Display="None" ControlToValidate="txtImageName2"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" TargetControlID="RequiredFieldValidator3"
                                Enabled="True">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align:top;">
                            <asp:Label ID="Label4" runat="server" CssClass="lbl"  Text="Image Description: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txImageDescription2" runat="server" Width="180px" Height="80px" MaxLength="250"
                                ValidationGroup="imageupload2" TextMode="MultiLine"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="fteImageDesription2" runat="server" TargetControlID="txImageDescription2"
                                FilterType="Custom,LowercaseLetters,UppercaseLetters" ValidChars="&,()/. ">
                            </asp:FilteredTextBoxExtender>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server"  CssClass="lbl" Text="Image 1: "></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="uplImage4" runat="server" onkeypress="return false;" onkeydown="return false;" />
                            <asp:Label ID="Label6" runat="server" Text="Upload Image Of Type1 (400x100)" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* Please select an image to upload."
                                Display="None" ControlToValidate="uplImage4" ValidationGroup="imageupload2"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="CustomValidator4" runat="server" ClientValidationFunction="ClientValidate"
                                ValidationGroup="imageupload2" ControlToValidate="uplImage4" Display="None" ErrorMessage="* Please  Select [ GIF , JPEG , BMP, PNG ] Images Only"></asp:CustomValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" TargetControlID="RequiredFieldValidator4"
                                Enabled="True">
                            </asp:ValidatorCalloutExtender>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" TargetControlID="CustomValidator4"
                                Enabled="True">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" CssClass="lbl"  Text="Image 2: "></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="uplImage5" runat="server" onkeypress="return false;" onkeydown="return false;" /><asp:Label
                                ID="Label8" runat="server" Text="Upload Image Of Type2 (200x100)" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="* Please select an image to upload."
                                Display="None" ControlToValidate="uplImage5" ValidationGroup="imageupload2"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="CustomValidator5" runat="server" ClientValidationFunction="ClientValidate"
                                ValidationGroup="imageupload2" ControlToValidate="uplImage5" Display="None" ErrorMessage="* Please  Select [ GIF , JPEG , BMP, PNG ] Images Only"></asp:CustomValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" TargetControlID="RequiredFieldValidator5"
                                Enabled="True">
                            </asp:ValidatorCalloutExtender>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server" TargetControlID="CustomValidator5"
                                Enabled="True">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" CssClass="lbl" Text="Image 3: "></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="uplImage6" runat="server" onkeypress="return false;" onkeydown="return false;" /><asp:Label
                                ID="Label10" runat="server" Text="Upload Image Of Type3 (200x100)" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="* Please select an image to upload."
                                Display="None" ControlToValidate="uplImage6" ValidationGroup="imageupload2"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="CustomValidator6" runat="server" ClientValidationFunction="ClientValidate"
                                ValidationGroup="imageupload2" ControlToValidate="uplImage6" Display="None" ErrorMessage="* Please  Select [ GIF , JPEG , BMP, PNG ] Images Only"></asp:CustomValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" runat="server" TargetControlID="RequiredFieldValidator6"
                                Enabled="True">
                            </asp:ValidatorCalloutExtender>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server" TargetControlID="CustomValidator6"
                                Enabled="True">
                            </asp:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnSubmitImageSet2" runat="server" Text="Submit" ValidationGroup="imageupload2"
                                OnClick="btnSubmitImageSet2_Click" CssClass="button" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:View>
        <asp:View ID="vwImageSet3" runat="server">
            <label class="lblHeader">Image Set 3</label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <br />
            <asp:Panel ID="Panel2" runat="server" Width="100%">
                <asp:GridView ID="gvShowImageSet3" runat="server" Width="75%" AutoGenerateColumns="False"
                    EmptyDataText="No Image Uploaded...Provide some Image" BorderColor="AliceBlue"
                    BorderWidth="2px" BorderStyle="Inset" OnRowCommand="gvShowImageSet3_RowCommand">
                    <Columns>
                        <asp:ImageField HeaderText="Image" DataImageUrlField="itemDtlImage7">
                            <ControlStyle Height="100px" Width="100px"></ControlStyle>
                        </asp:ImageField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnEditImage" runat="server" Text="Edit" CommandName="EditImage"
                                    ValidationGroup="other" CommandArgument='<%#Eval("imageId")+","+Eval("imageName3")+","+Eval("imageDescription3")+","+Eval("itemDtlImage7") %>' CssClass="button" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label11" runat="server"  CssClass="lbl" Text="Image Name: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtImageName3" runat="server" Width="180px" ValidationGroup="imageupload" MaxLength="80"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="fteImageName3" runat="server" TargetControlID="txtImageName3"
                            FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="&,()/. "
                            Enabled="True">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="* Enter Image Name"
                            Display="None" ControlToValidate="txtImageName3"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" runat="server" TargetControlID="RequiredFieldValidator7"
                            Enabled="True">
                        </asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align:top;">
                        <asp:Label ID="Label12" runat="server" CssClass="lbl"  Text="Image Description: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtImageDescription3" runat="server" Width="180px" Height="80px" MaxLength="250"
                            ValidationGroup="imageupload" TextMode="MultiLine"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="fteImageDescription4" runat="server" TargetControlID="txtImageDescription3"
                            FilterType="Custom, UppercaseLetters, LowercaseLetters" ValidChars="&,()/. "
                            Enabled="True">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label13" runat="server" CssClass="lbl"  Text="Image 1: "></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="uplImage7" runat="server" onkeypress="return false;" onkeydown="return false;" />
                        <asp:Label ID="Label14" runat="server" Text="Upload Image Of Type1 (400x100)" ForeColor="Red"></asp:Label>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="* Please select an image to upload."
                            Display="None" ControlToValidate="uplImage7" ValidationGroup="imageupload3"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator7" runat="server" ClientValidationFunction="ClientValidate"
                            ValidationGroup="imageupload3" ControlToValidate="uplImage7" Display="None" ErrorMessage="* Please  Select [ GIF , JPEG , BMP, PNG ] Images Only"></asp:CustomValidator>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender17" runat="server" TargetControlID="RequiredFieldValidator8"
                            Enabled="True">
                        </asp:ValidatorCalloutExtender>
                        <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender18" runat="server" TargetControlID="CustomValidator7"
                            Enabled="True">
                        </asp:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnSubmitImageSet3" runat="server" Text="Submit" ValidationGroup="imageupload3"
                            OnClick="btnSubmitImageSet3_Click" CssClass="button" />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
    
</asp:Content>


