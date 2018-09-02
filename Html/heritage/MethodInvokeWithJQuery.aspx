<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MethodInvokeWithJQuery.aspx.cs"
    Inherits="MethodInvokeWithJQuery" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>JQuery Server Side Method Call Demo</title>

    <script type="text/javascript" language="javascript" src="Scripts/jquery-1.6.2.min.js"></script>

    <script type="text/javascript" language="javascript" src="Scripts/jquery.json-2.2.min.js"></script>

    <script src="Scripts/jquery-ui-1.8.20.custom.min.js" type="text/javascript"></script>

    <script src="Scripts/heritage.js" type="text/javascript"></script>

    <link href="css/jquery-ui-1.8.20.custom.css" rel="stylesheet" type="text/css" />
    <link href="css/heritage.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: .93em;
            background-color: rgb(237, 237, 237);
        }
        #tblAjaxDemo p
        {
            border: 1px solid #EEE;
            background-color: #F0F0F0;
            padding: 3px;
        }
        #tblAjaxDemo p span
        {
            color: #00F;
            display: block;
            font: bold 21px Arial;
            float: left;
            margin-right: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mainContainer">
        <asp:Label ID="maleFemaleVisitor" Text="" runat="server"></asp:Label>
        <table width="700px">
            <tr>
                <td class="male-visitor-show">
                    <div id="personFather" class="cardContainer">
                        <div class="cardHeader">
                            <input type="button" class="IconPlusButton" id="addpersonFather" />
                            <asp:Label ID="personFatherId" Text="" runat="server" CssClass="display-none"></asp:Label>
                            <div class="allButtons">
                                <input type="button" class="EditButton" id="editpersonFather" />
                                <input type="button" class="IconMinusButton" id="deletepersonFather" />
                            </div>
                        </div>
                        <div class="personPhoto">
                            <asp:Image ID="personFatherImg" CssClass="imageClass" runat="server" Height="70px"
                                Width="60px" ImageUrl="MyImg.aspx?width=80&Hight=80" />
                        </div>
                        <div class="personInfo">
                            <span>
                                <asp:Label ID="personFatherFirstName" Text="FirstName" runat="server"></asp:Label>
                            </span>
                            <br />
                            <span>
                                <asp:Label ID="personFatherLastName" Text="LastName" runat="server"></asp:Label></span><br />
                            <span>
                                <asp:Label ID="personFatherMobileNo" Text="MobileNo" runat="server"></asp:Label></span>
                        </div>
                    </div>
                </td>
                <td class="male-visitor-show">
                    <div class="cardNullContainer">
                        <span></span>
                    </div>
                </td>
                <td>
                    <div id="personMotherFather" class="cardContainer">
                        <div class="cardHeader">
                            <input type="button" class="IconPlusButton" id="addpersonMotherFather" />
                            <asp:Label ID="personMotherFatherId" Text="" runat="server" CssClass="display-none"></asp:Label>
                            <div class="allButtons">
                                <input type="button" class="EditButton" id="editpersonMotherFather" />
                                <input type="button" class="IconMinusButton" id="deletepersonMotherFather" />
                            </div>
                        </div>
                        <div class="personPhoto">
                            <asp:Image ID="personMotherFatherImg" CssClass="imageClass" runat="server" Height="70px"
                                Width="60px" ImageUrl="MyImg.aspx?width=80&Hight=80" />
                        </div>
                        <div class="personInfo">
                            <span>
                                <asp:Label ID="personMotherFatherFirstName" Text="FirstName" runat="server"></asp:Label>
                            </span>
                            <br />
                            <span>
                                <asp:Label ID="personMotherFatherLastName" Text="LastName" runat="server"></asp:Label></span><br />
                            <span>
                                <asp:Label ID="personMotherFatherMobileNo" Text="MobileNo" runat="server"></asp:Label></span>
                        </div>
                    </div>
                </td>
                <td class="female-visitor-show">
                    <div class="cardNullContainer">
                    </div>
                </td>
                <td class="female-visitor-show">
                    <div id="personMother" class="cardContainer">
                        <div class="cardHeader">
                            <input type="button" class="IconPlusButton" id="addpersonMother" />
                            <asp:Label ID="personMotherId" Text="" runat="server" CssClass="display-none"></asp:Label>
                            <div class="allButtons">
                                <input type="button" class="EditButton" id="editpersonMother" />
                                <input type="button" class="IconMinusButton" id="deletepersonMother" />
                            </div>
                        </div>
                        <div class="personPhoto">
                            <asp:Image ID="personMotherImg" CssClass="imageClass" runat="server" Height="70px"
                                Width="60px" ImageUrl="MyImg.aspx?width=80&Hight=80" />
                        </div>
                        <div class="personInfo">
                            <span>
                                <asp:Label ID="personMotherFirstName" Text="FirstName" runat="server"></asp:Label>
                            </span>
                            <br />
                            <span>
                                <asp:Label ID="personMotherLastName" Text="LastName" runat="server"></asp:Label></span><br />
                            <span>
                                <asp:Label ID="personMotherMobileNo" Text="MobileNo" runat="server"></asp:Label></span>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="">
                    </div>
                </td>
                <td class="male-visitor-show">
                    <div class="cardTopLineNullContainer">
                    </div>
                </td>
                <td>
                    <div class="">
                    </div>
                </td>
                <td class="female-visitor-show">
                    <div class="cardTopLineNullContainer">
                    </div>
                </td>
                <td>
                    <div class="">
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="">
                    </div>
                </td>
                <td>
                    <div id="malePerson" class="cardContainer">
                        <div class="cardHeader">
                            <input type="button" class="IconPlusButton" id="addmalePerson" />
                            <asp:Label ID="malePersonId" Text="" runat="server" CssClass="display-none"></asp:Label>
                            <div class="allButtons">
                                <input type="button" class="EditButton" id="editmalePerson" />
                                <input type="button" class="IconMinusButton" id="deletemalePerson" />
                            </div>
                        </div>
                        <div class="personPhoto">
                            <asp:Image ID="malePersonImg" CssClass="imageClass" runat="server" Height="70px"
                                Width="60px" ImageUrl="MyImg.aspx?width=80&Hight=80" />
                        </div>
                        <div class="personInfo">
                            <span>
                                <asp:Label ID="malepersonFirstName" Text="FirstName" runat="server"></asp:Label>
                            </span>
                            <br />
                            <span>
                                <asp:Label ID="malepersonLastName" Text="LastName" runat="server"></asp:Label></span><br />
                            <span>
                                <asp:Label ID="malepersonMobileNo" Text="MobileNo" runat="server"></asp:Label></span>
                        </div>
                    </div>
                </td>
                <td>
                    <div id="maleFemaleConnect" class="cardNullContainer">
                    </div>
                </td>
                <td>
                    <div id="femalePerson" class="cardContainer">
                        <div class="cardHeader">
                            <input type="button" class="IconPlusButton" id="addfemalePerson" />
                            <asp:Label ID="femalePersonId" Text="" runat="server" CssClass="display-none"></asp:Label>
                            <div class="allButtons">
                                <input type="button" class="EditButton" id="editfemalePerson" />
                                <input type="button" class="IconMinusButton" id="deletefemalePerson" />
                            </div>
                        </div>
                        <div class="personPhoto">
                            <asp:Image ID="femalePersonImg" CssClass="imageClass" runat="server" Height="70px"
                                Width="60px" ImageUrl="MyImg.aspx?width=80&Hight=80" />
                        </div>
                        <div class="personInfo">
                            <span>
                                <asp:Label ID="femalePersonFirstName" Text="FirstName" runat="server"></asp:Label>
                            </span>
                            <br />
                            <span>
                                <asp:Label ID="femalePersonLastName" Text="LastName" runat="server"></asp:Label></span><br />
                            <span>
                                <asp:Label ID="femalePersonMobileNo" Text="MobileNo" runat="server"></asp:Label></span>
                        </div>
                    </div>
                </td>
                <td>
                    <div class="">
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="secondSonConnectA" class="cardNullContainer1">
                    </div>
                </td>
                <td>
                    <div id="secondSonConnectB" class="cardNullContainer3">
                    </div>
                </td>
                <td>
                    <div id="firstSonConnect" class="cardNullContainer4">
                    </div>
                </td>
                <td>
                    <div id="ThirdSonConnectA" class="cardNullContainer3">
                    </div>
                </td>
                <td>
                    <div id="ThirdSonConnectB" class="cardNullContainer2">
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="sonfirst" class="cardContainer">
                        <div class="cardHeader">
                            <input type="button" class="IconPlusButton" id="addsonfirst" />
                            <asp:Label ID="sonfirstId" Text="" runat="server" CssClass="display-none"></asp:Label>
                            <div class="allButtons">
                                <input type="button" class="EditButton" id="editsonfirst" />
                                <input type="button" class="IconMinusButton" id="deletesonfirst" />
                            </div>
                        </div>
                        <div class="personPhoto">
                            <asp:Image ID="son1Img" CssClass="imageClass" runat="server" Height="70px" Width="60px"
                                ImageUrl="MyImg.aspx?width=80&Hight=80" />
                        </div>
                        <div class="personInfo">
                            <span>
                                <asp:Label ID="son1FirstName" Text="FirstName" runat="server"></asp:Label>
                            </span>
                            <br />
                            <span>
                                <asp:Label ID="son1LastName" Text="LastName" runat="server"></asp:Label></span><br />
                            <span>
                                <asp:Label ID="son1MobileNo" Text="MobileNo" runat="server"></asp:Label></span>
                        </div>
                    </div>
                </td>
                <td>
                    <div class="">
                    </div>
                </td>
                <td>
                    <div id="sonsecond" class="cardContainer">
                        <div class="cardHeader">
                            <input type="button" class="IconPlusButton" id="addsonsecond" />
                            <asp:Label ID="sonsecondId" Text="" runat="server" CssClass="display-none"></asp:Label>
                            <div class="allButtons">
                                <input type="button" class="EditButton" id="editsonsecond" />
                                <input type="button" class="IconMinusButton" id="deletesonsecond" />
                            </div>
                        </div>
                        <div class="personPhoto">
                            <asp:Image ID="son2Img" CssClass="imageClass" runat="server" Height="70px" Width="60px"
                                ImageUrl="MyImg.aspx?width=80&Hight=80" />
                        </div>
                        <div class="personInfo">
                            <span>
                                <asp:Label ID="son2FirstName" Text="FirstName" runat="server"></asp:Label>
                            </span>
                            <br />
                            <span>
                                <asp:Label ID="son2LastName" Text="LastName" runat="server"></asp:Label></span><br />
                            <span>
                                <asp:Label ID="son2MobileNo" Text="MobileNo" runat="server"></asp:Label></span>
                        </div>
                    </div>
                </td>
                <td>
                    <div class="">
                    </div>
                </td>
                <td>
                    <div id="sonthird" class="cardContainer">
                        <div class="cardHeader">
                            <input type="button" class="IconPlusButton" id="addsonthird" />
                            <asp:Label ID="sonthirdId" Text="" runat="server" CssClass="display-none"></asp:Label>
                            <div class="allButtons">
                                <input type="button" class="EditButton" id="editsonthird" />
                                <input type="button" class="IconMinusButton" id="deletesonthird" />
                            </div>
                        </div>
                        <div class="personPhoto">
                            <asp:Image ID="son3Img" CssClass="imageClass" runat="server" Height="70px" Width="60px"
                                ImageUrl="MyImg.aspx?width=80&Hight=80" />
                        </div>
                        <div class="personInfo">
                            <span>
                                <asp:Label ID="son3FirstName" Text="FirstName" runat="server"></asp:Label>
                            </span>
                            <br />
                            <span>
                                <asp:Label ID="son3LastName" Text="LastName" runat="server"></asp:Label></span><br />
                            <span>
                                <asp:Label ID="son3MobileNo" Text="MobileNo" runat="server"></asp:Label></span>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="addPersonModelId" class="addPersonModel">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">
        </asp:ToolkitScriptManager>
        <table class="addPersonModelTable">
            <tr>
                <td>
                    First Name:
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    <%--<input type="text" id="txtFirstName" />--%>
                </td>
            </tr>
            <tr>
                <td>
                    Last Name:
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    <%-- <input type="text" id="txtLastName" />--%>
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
                    <%--<select id="ddlGender" style="width: 183px;">
                        <option value="">--Select--</option>
                        <option value="Male">Male</option>
                        <option value="Female">Female</option>
                    </select>--%>
                </td>
            </tr>
            <tr>
                <td>
                    Mobile No:
                </td>
                <td>
                    <asp:TextBox ID="txtMobileNo" runat="server"></asp:TextBox>
                    <%--<input type="text" id="txtMobileNo" />--%>
                </td>
            </tr>
            <tr>
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
                    <%--  <select id="relation" style="width: 183px;">
                        <option value="">--Select--</option>
                        <option value="Life_Partner">Life Partner</option>
                        <option value="Mother">Mother</option>
                        <option value="Father">Father</option>
                        <option value="First_Son">First Son</option>
                        <option value="Second_Son">Second Son</option>
                        <option value="Third_Son">Third Son</option>
                    </select>--%>
                </td>
            </tr>
            <tr>
                <td>
                    Photo:
                </td>
                <td>
                    <%--<input type="file" id="inputPhoto" />--%>
                    <asp:AsyncFileUpload ID="AsyncFileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <%--<input type="button" id="addNewPerson" class="submitButton" value="Add" />--%>
                    <%--<asp:Button ID="addNewPersonNew" runat="server" CssClass="submitButton" OnClick="addNewPersonNew_Click"
                        Text="Button" />--%>
                    <asp:Button ID="btnYesClick" runat="server" Text="Submit" CssClass="submitButton"
                        UseSubmitBehavior="false" OnClick="btnYesClick_Click" />
                    <input type="button" id="cancelButton" class="submitButton" value="Cancel" />
                </td>
            </tr>
        </table>
    </div>
    <div id="editPersonModel" class="addPersonModel">
        <table class="addPersonModelTable">
            <tr>
                <td>
                    First Name:
                </td>
                <td>
                    <input type="text" id="txtEditFirstName" />
                </td>
            </tr>
            <tr>
                <td>
                    Last Name:
                </td>
                <td>
                    <input type="text" id="txtEditLastName" />
                </td>
            </tr>
            <tr>
                <td>
                    Gender:
                </td>
                <td>
                    <select id="ddlEditGender" style="width: 183px;">
                        <option value="">--Select--</option>
                        <option value="Male">Male</option>
                        <option value="Female">Female</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    Mobile No:
                </td>
                <td>
                    <input type="text" id="txtEditMobileNo" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <td>
                    Relation:
                </td>
                <td>
                    <select id="txtEditPersonRelation" style="width: 183px;">
                        <option value="">--Select--</option>
                        <option value="Life_Partner">Life Partner</option>
                        <option value="Mother">Mother</option>
                        <option value="Father">Father</option>
                        <option value="First_Son">First Son</option>
                        <option value="Second_Son">Second Son</option>
                        <option value="Third_Son">Third Son</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    Photo:
                </td>
                <td>
                    <input type="file" id="txtEditPhoto" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <input type="button" id="btnUpdateEdit" class="submitButton" value="update" />
                    <input type="button" id="btnCancelEdit" class="submitButton" value="Cancel" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
