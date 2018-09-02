<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MethodInvokeWithJQuery.aspx.cs"
    Inherits="MethodInvokeWithJQuery" %>

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
        <table id="myTable">
            <tr>
                <td>
                    <div class="cardContainer">
                        <div class="cardHeader">
                            <input type="button" class="IconPlusButton" id="addPerson" />
                            <div class="allButtons">
                                <input type="button" class="EditButton" id="editPerson" />
                                <input type="button" class="IconMinusButton" id="deletePerson" />
                            </div>
                        </div>
                        <div class="personPhoto">
                            <img id="personImg" class="imageClass" src="" />
                        </div>
                        <div class="personInfo">
                            <span id="firstName">FirstName</span><br />
                            <span id="lastName">LastName</span><br />
                            <span id="mobileNo">MobileNo</span>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
            </tr>
        </table>
    </div>
    <div id="addPersonModelId" class="addPersonModel">
        <table class="addPersonModelTable">
            <tr>
                <td>
                    First Name:
                </td>
                <td>
                    <input type="text" id="txtFirstName" />
                </td>
            </tr>
            <tr>
                <td>
                    Last Name:
                </td>
                <td>
                    <input type="text" id="txtLastName" />
                </td>
            </tr>
            <tr>
                <td>
                    Mobile No:
                </td>
                <td>
                    <input type="text" id="txtMobileNo" />
                </td>
            </tr>
            <tr>
                <td>
                    Relation:
                </td>
                <td>
                    <select id="relation" style="width: 155px;">
                        <option value="">--Select--</option>
                        <option value="Mother">Mother</option>
                        <option value="Father">Father</option>
                        <option value="Son">Son</option>
                        <option value="Daughter">Daughter</option>
                        <option value="Grand Father">Grand Father</option>
                        <option value="Grand Mother">Grand Mother</option>
                        <option value="FFF">FF</option>
                        <option value="FFM">FF</option>
                        <option value="FFS">FF</option>
                        <option value="FFD">FF</option>
                        <option value="FF">FF</option>
                        <option value="FF">FF</option>
                        <option value="FF">FF</option>
                        <option value="FF">FF</option>
                        <option value="FF">FF</option>
                        <option value="FF">FF</option>
                        <option value="FF">FF</option>
                        <option value="FF">FF</option>
                        <option value="FF">FF</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    Photo:
                </td>
                <td>
                    <input type="file" id="inputPhoto" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <input type="button" id="addNewPerson" class="submitButton" value="Add" />
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
                    <select id="txtEditPersonRelation" style="width: 155px;">
                        <option value="">--Select--</option>
                        <option value="Mother">Mother</option>
                        <option value="Father">Father</option>
                        <option value="Son">Son</option>
                        <option value="Daughter">Daughter</option>
                        <option value="Grand Father">Grand Father</option>
                        <option value="Grand Mother">Grand Mother</option>
                        <option value="FFF">FF</option>
                        <option value="FFM">FF</option>
                        <option value="FFS">FF</option>
                        <option value="FFD">FF</option>
                        <option value="FF">FF</option>
                        <option value="FF">FF</option>
                        <option value="FF">FF</option>
                        <option value="FF">FF</option>
                        <option value="FF">FF</option>
                        <option value="FF">FF</option>
                        <option value="FF">FF</option>
                        <option value="FF">FF</option>
                        <option value="FF">FF</option>
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
