<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.master" AutoEventWireup="true"
    CodeFile="changeMobileno.aspx.cs" Inherits="html_changeMobileno" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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

    <div class="MainDiv">
        <div class="InnerDiv">
            <table class="tblSubFull2">
                <tr>
                    <td colspan="2">
                        <center>
                            <br />
                            <img src="../KResource/Images/MobileImg.png" width="30px" height="30px" alt="" />
                            <span class="spanTitle">Change Mobile No</span>
                            <br />
                            <br />
                        </center>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Registered Mobile No. :
                    </td>
                    <td align="left">
                        <asp:Label ID="lblRegisteredMobileNo" ForeColor="red" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <label for="txtNewMobileNo">
                            Enter the New Mobile No. :</label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtNewMobileNoN" runat="server" ValidationGroup="vgpChangeMobileNo"
                            CssClass="ccstxt" MaxLength="10"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="ftbMobileNoExtenderN" runat="server" TargetControlID="txtNewMobileNoN"
                            FilterType="Numbers" Enabled="True">
                        </asp:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Re-Enter the New Mobile No. :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtNewMobileNo" runat="server" ValidationGroup="vgpChangeMobileNo"
                            CssClass="ccstxt" MaxLength="10"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="ftbMobileNoExtender" runat="server" TargetControlID="txtNewMobileNo"
                            FilterType="Numbers" Enabled="True">
                        </asp:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        <asp:Button ID="btnNewMobileNoRegister" runat="server" Text="Submit" ValidationGroup="vgpChangeMobileNo"
                            OnClientClick="return validateChangeMobile(); " OnClick="btnNewMobileNoRegister_Click"
                            CssClass="cssbtn" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
