<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="ProfileSettings.aspx.cs" EnableSessionState="True"  Inherits="Html_ProfileSettings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">

        function confirmDelete() {

            var agree = confirm("Do you really want to Delete?");

            if (agree)

                return true;

            else

                return false;

        }

    </script>

    <script language="javascript" type="text/javascript">
        function validateChangeMobile() {
            if (document.getElementById('<%=txtNewMobileNo.ClientID%>').value != document.getElementById('<%=txtNewMobileNoN.ClientID %>').value) {
                alert("Mobile No Is Not Matching");
                return false;
            }
            else {
                var agr = confirm("Do You Really Want To Change Your Mobile No ? Paaword will be send to New Number.");
                if (agr)
                    return true;
                else
                    return false;
            }
            if (document.getElementById('<%=txtNewMobileNo.ClientID%>').value == "") {
                alert("Provide the New Mobile No");
                return false;
            }
            else if (document.getElementById('<%=txtNewMobileNo.ClientID%>').value.length < 10) {
                alert("New Mobile No Should be 10 Numbers");
                return false;
            }
            else {
                this.disabled = true;
                this.value = 'Changing Mobile...';
                __doPostBack('btnChangePassword', '');
            }
        }
    </script>

    <script language="javascript" type="text/javascript">
        function validateChangePassword() {

            if (document.getElementById('<%=txtOldPasswod.ClientID%>').value == "") {
                alert("Provide the Old Password");
                return false;
            }
            else if (document.getElementById('<%=txtOldPasswod.ClientID%>').value.length < 5) {
                alert("Old Password Should be atleast 5 Character");
                return false;
            }
            else if (document.getElementById('<%=txtNewPassword.ClientID%>').value == "") {
                alert("Provide the New Password");
                return false;
            }
            else if (document.getElementById('<%=txtNewPassword.ClientID%>').value.length < 5) {
                alert("New Password Should be atleast 5 Character");
                return false;
            }
            else if (document.getElementById('<%=txtOldPasswod.ClientID%>').value == "") {
                alert("Provide the Old Password");
                return false;
            }
            else if (document.getElementById('<%=txtOldPasswod.ClientID%>').value.length < 5) {
                alert("Reentered-Password Should be atleast 5  Character");
                return false;
            }
            else {
                this.disabled = true;
                this.value = 'Changing Password...';
                __doPostBack('btnChangePassword', '');
            }
        }
    </script>

    <asp:UpdatePanel ID="updtPnlSendSMS" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table border="1" height="500px" width="100%">
                <tr>
                    <td valign="top">
                        <asp:TabContainer ID="tabProfileSetting" runat="server" ActiveTabIndex="2" AutoPostBack="true"
                            Width="100%">
                            <asp:TabPanel ID="tabChangePassword" runat="server" HeaderText="Password Change">
                                <HeaderTemplate>
                                    <label for="">
                                        Change Password</label>
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <div class="searchResultHeader">
                                        <label>
                                            Change Password</label>
                                    </div>
                                    <table class="tblSubFull">
                                        <tr>
                                            <td class="tdLabelInner">
                                                <asp:Label ID="lblOldPassword" runat="server" Text="Old Passowrd"></asp:Label>
                                            </td>
                                            <td class="tdTextInner">
                                                <asp:TextBox ID="txtOldPasswod" runat="server" Width="140px" TextMode="Password"
                                                    MaxLength="15" ToolTip="Enter the Old Password" onfocus="ChangeCSS(this, event)"
                                                    onblur="ChangeCSS(this, event)"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtOldPasswod"
                                                    FilterType="Custom" FilterMode="InvalidChars" InvalidChars=" ">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td class="tdErrorInner">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdLabelInner">
                                                <asp:Label ID="lblNewPassword" runat="server" Text="New Passowrd"></asp:Label>
                                            </td>
                                            <td class="tdTextInner">
                                                <asp:TextBox ID="txtNewPassword" runat="server" Width="140px" TextMode="Password"
                                                    ValidationGroup="vgpChangePassword" MaxLength="15" ToolTip="Enter the Password"
                                                    onfocus="ChangeCSS(this, event)" onblur="ChangeCSS(this, event)"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtNewPassword"
                                                    FilterType="Custom" FilterMode="InvalidChars" InvalidChars=" ">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td class="tdErrorInner">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tdLabelInner">
                                                <asp:Label ID="lblConfirmNewPassword" runat="server" Text="Confirm Passowrd"></asp:Label>
                                            </td>
                                            <td class="tdTextInner">
                                                <asp:TextBox ID="txtConfirmNewPassword" runat="server" Width="140px" TextMode="Password"
                                                    ValidationGroup="vgpChangePassword" MaxLength="15" ToolTip="Re-Enter the Password"
                                                    onfocus="ChangeCSS(this, event)" onblur="ChangeCSS(this, event)"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="fteConfPassword" runat="server" TargetControlID="txtConfirmNewPassword"
                                                    FilterType="Custom" FilterMode="InvalidChars" InvalidChars=" ">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                            <td class="tdErrorInner">
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*Password Not Matching"
                                                    ValidationGroup="vgpChangePassword" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmNewPassword"
                                                    Display="None"></asp:CompareValidator>
                                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="CompareValidator1">
                                                </asp:ValidatorCalloutExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click"
                                                  ValidationGroup="vgpChangePassword"
                                                    CssClass="button" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                            
                            <asp:TabPanel ID="tabChangeMobile" runat="server" HeaderText="Mobile No. Change"
                                DefaultButton="btnNewMobileNoRegister" defaultfocus="txtNewMobileNo">
                                <HeaderTemplate>
                                    <label for="">
                                        Change Mobile No</label>
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <div class="searchResultHeader">
                                        <asp:Label ID="Label1" runat="server" Text="Change Mobile No"></asp:Label>
                                    </div>
                                    <table class="tblSubFull">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblRegMobileNo" runat="server" Text="Registered  Mobile No:"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRegisteredMobileNo" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label for="txtNewMobileNo">
                                                    Enter the New Mobile No.:</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNewMobileNoN" runat="server" ValidationGroup="vgpChangeMobileNo"
                                                    MaxLength="10" onfocus="ChangeCSS(this, event)" 
                                                    onblur="ChangeCSS(this, event)"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="ftbMobileNoExtenderN" runat="server" TargetControlID="txtNewMobileNoN"
                                                    FilterType="Numbers" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <label for="txtNewMobileNo">
                                                    Re-Enter the New Mobile No.:</label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNewMobileNo" runat="server" ValidationGroup="vgpChangeMobileNo"
                                                    MaxLength="10" onfocus="ChangeCSS(this, event)" onblur="ChangeCSS(this, event)"></asp:TextBox>
                                                <asp:FilteredTextBoxExtender ID="ftbMobileNoExtender" runat="server" TargetControlID="txtNewMobileNo"
                                                    FilterType="Numbers" Enabled="True">
                                                </asp:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btnNewMobileNoRegister" runat="server" Text="Submit" ValidationGroup="vgpChangeMobileNo" OnClientClick="return validateChangeMobile(); "
                                                    OnClick="btnNewMobileNoRegister_Click" CssClass="button" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:TabPanel>
                            
                            
                            <asp:TabPanel ID="tabGroup" runat="server" HeaderText="Groups">
                            <HeaderTemplate>
                            <label for="">
                                        Define Group</label>
                            </HeaderTemplate>
                            <ContentTemplate>
                             <div class="searchResultHeader">
                                        <asp:Label ID="Label3" runat="server" Text="Define Group"></asp:Label>
                                    </div>
                                    
                                    <table class="tblSubFull">
                                        <tr>
                                            <td class="tdLabelInner">
                                               
                                            </td>
                                            <td class="tdTextInner">
                                               
                                            </td>
                                            <td class="tdErrorInner">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  colspan="3" class="tdLabelInner" align="center">
                                                
                                                
                                                
                                         <asp:GridView ID="gvGroup" runat="server" AutoGenerateColumns="False" 
                                          Width="100%" GridLines="Horizontal" HorizontalAlign="Center" >
                                        <RowStyle BackColor="White" BorderColor="Black" ForeColor="#333333" BorderStyle="Solid" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>Group Id</HeaderTemplate>
                                                <ItemTemplate >
                                                    <asp:Label ID="lblGroupId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="30%" VerticalAlign ="Middle" Font-Bold ="True" />
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField>
                                              <HeaderTemplate>Group Name</HeaderTemplate>
                                                <ItemTemplate>
                                                    
                                                    <asp:TextBox ID="txtGroupName" MaxLength="20" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="40%"/>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField>
                                                <HeaderTemplate>Group Member Count</HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMemCount"  Enabled="false" runat="server" Text='<%#Eval("countsub") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="30%" Font-Bold ="True" VerticalAlign ="Middle"/>
                                            </asp:TemplateField>
                                            
                                        </Columns>
                                    </asp:GridView> 
                                                
                                                
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  colspan="3" align="right" valign="middle">
                                                
                                                
                                                
                                                <asp:Label ID="lbltotal" runat="server"  Visible="false" Text="Total All Members"></asp:Label>
                                                
                                                
                                                     &nbsp;:
                                                
                                                
                                                     <asp:TextBox ID="txttotal" MaxLength="20"  Visible="false" runat="server" ></asp:TextBox>
                                              
                                                </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <asp:Button ID="btnDefineGroup" runat="server" Text="Update Group" 
                                                 
                                                    CssClass="button" onclick="btnDefineGroup_Click" />
                                                    
                                            </td>
                                        </tr>
                                    </table>
                            </ContentTemplate>
                            </asp:TabPanel>
                            
                            
                            <asp:TabPanel ID="tabRemoveFriend" runat="server">
                                <HeaderTemplate>
                                    Friend/Relative Setting
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <div class="searchResultHeader">
                                        <asp:Label ID="Label2" runat="server" Text="Update Friends Group"></asp:Label>
                                    </div>
                                    <div>
                                      <table >
                                      <tr>
                                      <td>
                                          <asp:Label ID="Label4" runat="server" Text="First Name"></asp:Label>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
                                      </td>
                                      <td>
                                          <asp:Label ID="Label5" runat="server" Text="Last Name"></asp:Label>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
                                      </td>
                                      </tr>
                                      <tr>
                                      <td>
                                          <asp:Label ID="Label6" runat="server" Text="Mobile Number"></asp:Label>
                                      </td>
                                      <td>
                                          <asp:TextBox ID="txtMobileNo" runat="server"></asp:TextBox>
                                      </td>
                                      <td colspan ="2" align ="center" >
                                          <asp:Button ID="btnSearchRel" runat="server" onclick="btnSearchRel_Click" Text="SEARCH" />
                                      </td>
                                      
                                      </tr>
                                      </table>
                                    </div>
                                    <asp:GridView ID="gvRemoveFriend" runat="server" AutoGenerateColumns="False" EmptyDataText="No Friends Added In your Profile"
                                        DataKeyNames="usrUserId" OnRowEditing="gvRemoveFriend_RowEditing" OnRowUpdating="gvRemoveFriend_RowUpdating"
                                        OnRowCancelingEdit="gvRemoveFriend_RowCancelingEdit" Width="100%" AllowPaging="True"
                                        AllowSorting="True" GridLines="Horizontal" OnRowCommand="gvRemoveFriend_RowCommand"
                                        OnPageIndexChanging="gvRemoveFriend_PageIndexChanging">
                                        <RowStyle BackColor="White" BorderColor="Black" ForeColor="#333333" BorderStyle="Solid" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <%--<ItemTemplate>
                                                    <asp:Label ID="lblNo" runat="server" Text='<%#Eval("rowNumber") %>'></asp:Label>
                                                </ItemTemplate>--%>
                                                <ItemStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFullName" runat="server" Text='<%#Eval("usrFullName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="25%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMob" runat="server" Text='<%#Eval("usrMobileNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="15%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <%--<ItemTemplate>
                                                    <asp:Label ID="lblFriendGroup" runat="server" Text='<%#Eval("FriRel") %>'></asp:Label>
                                                </ItemTemplate>--%>
                                               <%-- <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlModifyFriendGroup" runat="server" Width="100px">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <ItemStyle Width="25%" />--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRelation" runat="server" Text='<%#Eval("Relation") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtRelation" runat="server" Text='<%#Eval("Relation") %>' Width="40px"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                            <ItemTemplate>
                                            
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="btnEditFriend" runat="server" Text="Modify" CssClass="button" CommandArgument=''
                                                        CommandName="Edit" />
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="btnDeleteFriend" runat="server" Text="Remove" CssClass="button" CommandArgument='<%#Eval("usrUserId") %>'
                                                        CommandName="Remove" OnClientClick="return confirmDelete()" />
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:TabPanel>
                            
                            
                            
                            
                            
                        </asp:TabContainer>
                    </td>
                </tr>
            </table>
            <%--Popup for editing--%>
            <asp:HiddenField ID="tmp" runat="server" />
            <asp:ModalPopupExtender ID="mdlEditGroup" runat="server" TargetControlID="tmp" PopupControlID="pnlEditGroup"
                BackgroundCssClass="modalBackground" CancelControlID="btnClose" PopupDragHandleControlID="pnlEditGroup">
            </asp:ModalPopupExtender>
            <asp:Panel ID="pnlEditGroup" runat="server" Width="400px" CssClass="ModalWindow">
                <table border="0" style="border-width: thin; width: 100%; background-color: #E0C9D8;
                    display: block;" cellpadding="2" cellspacing="2">
                    <tr>
                        <td colspan="2" class="lblLogin" style="color: Green;">
                            Group Information Update
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="tdLabelInner">
                            <asp:Label ID="lblError" runat="server" CssClass="Error" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr class="trInnerTable">
                        <td class="tdLabelInner" valign="top" style="width: 50%">
                            <asp:Label ID="Label21" runat="server" Text="Friend Name :"></asp:Label>
                        </td>
                        <td class="" align="left" valign="top">
                      <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                           <%-- <asp:TextBox ID="txtName" runat="server" Text='<%#Eval("usrFullName")%>'></asp:TextBox>--%>
                        </td>
                    </tr>
                    <tr class="trInnerTable">
                        <td class="tdLabelInner" valign="top">
                            <asp:Label ID="lblRelation" runat="server" Text="Relation :"></asp:Label>
                        </td>
                        <td class="tdTextInner" align="left" valign="top">
                            <asp:TextBox ID="txtRelation" Text='<%#Eval("Relation")%>' runat="server" Width="140px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr class="trInnerTable">
                        <td class="tdLabelInner" valign="top">
                            <asp:Label ID="Label22" runat="server" Text="Select Group:"></asp:Label>
                        </td>
                        <td class="tdTextInner" valign="top" align="left">
                            <asp:ListBox ID="chkGroup" Height="300px" SelectionMode="Multiple" runat="server">
                            </asp:ListBox>
                            <%-- <asp:CheckBoxList ID="chkGroup" RepeatDirection="Vertical"  Height="200px" BorderColor="Black" BorderStyle="Solid" runat="server">
                                        </asp:CheckBoxList>--%>
                        </td>
                    </tr>
                     <tr class="trInnerTable">
                        <td class="tdLabelInner">
                            <asp:Label ID="lblprefix" runat="server" Text="Select Prefix while sending Msg:"></asp:Label>
                    
                        </td>
                    <td class="tdTextInner" valign="top" align="left">
                        <asp:DropDownList ID="ddlprefix" runat="server">
                        
                        <asp:ListItem >Dear</asp:ListItem>
                        <asp:ListItem >Shri</asp:ListItem>
                        <asp:ListItem>Smt</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    </tr>
                    <tr class="trInnerTable">
                    <td class="tdLabelInner">
                        <asp:Label ID="lblinfixname" runat="server" Text="Select Infix while sending Msg"></asp:Label>
                    </td>
                    <td class="tdTextInner" valign="top" align="left">
                        <asp:DropDownList ID="ddlinfix" runat="server">
                      <%--<asp:ListItem >--Select--</asp:ListItem>
                        <asp:ListItem>FirstName</asp:ListItem>
                        <asp:ListItem>LastName</asp:ListItem>--%>
                        <%--<asp:ListItem>Session["UserFirstNameN"]</asp:ListItem>
                        <asp:ListItem>session["UserLastNameN"]</asp:ListItem>--%>
                        </asp:DropDownList>
                    </td>
                    </tr>
                   <tr class="trInnerTable">
                    <td class="tdLabelInner">
                        <asp:Label ID="lblpostfixname" runat="server" Text="Select Postfix while sending Msg"></asp:Label>
                    </td>
                    <td class="tdTextInner" valign="top" align="left">
                       
                        <asp:DropDownList ID="ddlpostfix" runat="server">
                        <asp:ListItem > </asp:ListItem>
                        <asp:ListItem >Ji</asp:ListItem>
                        <asp:ListItem>Saheb</asp:ListItem>
                        <asp:ListItem>Sir</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    </tr>
                    <tr>
                        <td class="lbl">
                        </td>
                        <td style="text-align: left;">
                            <asp:Button ID="btnUpdateGroup" Text="Update" CssClass="button" runat="server" BorderColor="Maroon"
                                OnClientClick="return ClientValidate()" OnClick="btnUpdateContact_Click" />
                            &nbsp;
                            <asp:Button ID="btnClose" Text="Cancel" CssClass="button" runat="server" BorderColor="Maroon" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <%--Popup end here--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
