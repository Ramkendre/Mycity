<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editUpdate.aspx.cs" Inherits="editUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="css/heritage.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/jquery-1.8.3.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        //        function Redirection() {
        //            debugger;
        //            opener.location.relod(); //.href = opener.location.href;
        //            alert(opener.location.href);
        //        }

        $(document).ready(function() {
            if ($('.HideMe').length === 1) {
                $('.hideRelationColumnInRecordEditMode').hide();
            }

            window.onunload = refreshParent;
            function refreshParent() {
                window.opener.location.reload();
            }

        });
        
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">
        </asp:ToolkitScriptManager>
        <asp:Label ID="updatePersonId" Text="" runat="server" CssClass="display-none"></asp:Label>
        <asp:Label ID="addPersonParentId" Text="" runat="server" CssClass="display-none"></asp:Label>
        <table class="addPersonModelTable">
            <tr>
                <td>
                    First Name:
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Last Name:
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Gender:
                </td>
                <td>
                    <asp:DropDownList ID="ddlGender" runat="server" Style="width: 183px;">
                        <asp:ListItem Value="" Selected="True" Text="--Select--"></asp:ListItem>
                        <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                        <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Mobile No:
                </td>
                <td>
                    <asp:TextBox ID="txtMobileNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="hideRelationColumnInRecordEditMode">
                <td>
                    Relation:
                </td>
                <td>
                    <asp:DropDownList ID="ddlRelation" runat="server" Style="width: 183px;">
                        <asp:ListItem Value="" Selected="True" Text="--Select--"></asp:ListItem>
                        <asp:ListItem Value="Life_Partner" Text="Life Partner"></asp:ListItem>
                        <asp:ListItem Value="Mother" Text="Mother"></asp:ListItem>
                        <asp:ListItem Value="Father" Text="Father"></asp:ListItem>
                        <asp:ListItem Value="First_Son" Text="First Son"></asp:ListItem>
                        <asp:ListItem Value="Second_Son" Text="Second Son"></asp:ListItem>
                        <asp:ListItem Value="Third_Son" Text="Third Son"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Photo:
                </td>
                <td>
                    <asp:AsyncFileUpload ID="AsyncFileUpload1" runat="server" Width="200px" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnYesClick" runat="server" Text="Submit" CssClass="submitButton"
                        UseSubmitBehavior="false" OnClick="btnYesClick_Click" />
                    <input type="button" id="cancelButton" class="submitButton" value="Cancel" onclick="javascript:window.close()" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
