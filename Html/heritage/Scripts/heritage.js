var Person = function(fName, lName, mobileNo, relation, photoPath) {
    this.FirstName = fName;
    this.LastName = lName;
    this.Relation = relation;
    this.MobileNo = mobileNo;
    this.PhotoPath = photoPath;
}

var addPersonFlag = true, editPersonFlag = true;

$(document).ready(function() {
    $('#addPersonModelId').hide();
    $('#addPersonModelId').dialog('close');
    $('#editPersonModel').hide();
    $('#editPersonModel').dialog('close');

    if ($("#maleFemaleVisitor").hasClass("show-males") == true) {
        $('div', $('.male-visitor-show')).show();
        $('div', $('.female-visitor-show')).hide();
    } else if ($("#maleFemaleVisitor").hasClass("show-females") == true) {
        $('div', $('.female-visitor-show')).show();
        $('div', $('.male-visitor-show')).hide();
    } else {

    }



    //    $('#personFather').hide();
    //    $('#personMotherFather').hide();
    //    $('#personMother').hide();
    //    $('#malePerson').hide();
    //    $('#femalePerson').hide();
    //    $('#sonfirst').hide();
    //    $('#sonsecond').hide();
    //    $('#sonthird').hide();

    //    $('#firstSonConnect').hide();
    //    $('#maleFemaleConnect').hide();

    //    $('#secondSonConnectA').hide();
    //    $('#secondSonConnectB').hide();

    //    $('#ThirdSonConnectA').hide();
    //    $('#ThirdSonConnectB').hide();

    //    $('#firstSonConnect').hide();
    //    $('#firstSonConnect').hide();
    //    $('#firstSonConnect').hide();
    //    $('#firstSonConnect').hide();
    //    $('#firstSonConnect').hide();

    // Add Methods.

    $('#addpersonFather').click(function() {
        var id = $('#personFatherId').text();
        addNewPerson(id);
    });

    $('#personFather').bind('dblclick', function() {
        var id = $('#personFatherId').text();
        redirectToMiddalPerson(id);
    });

    $('#addpersonMotherFather').click(function() {
        var id = $('#personMotherFatherId').text();
        addNewPerson(id);
    });

    $('#personMotherFather').bind('dblclick', function() {
        var id = $('#personMotherFatherId').text();
        redirectToMiddalPerson(id);
    });

    $('#addpersonMother').click(function() {
        var id = $('#personMotherId').text();
        addNewPerson(id);
    });

    $('#personMother').bind('dblclick', function() {
        var id = $('#personMotherId').text();
        redirectToMiddalPerson(id);
    });

    $('#addmalePerson').click(function() {
        var id = $('#malePersonId').text();
        addNewPerson(id);
    });

    $('#malePerson').bind('dblclick', function() {
        var id = $('#malePersonId').text();
        redirectToMiddalPerson(id);
    });

    $('#addfemalePerson').click(function() {
        var id = $('#femalePersonId').text();
        addNewPerson(id);
    });

    $('#femalePerson').bind('dblclick', function() {
        var id = $('#femalePersonId').text();
        redirectToMiddalPerson(id);
    });

    $('#addsonsecond').click(function() {
        var id = $('#sonsecondId').text();
        addNewPerson(id);
    });

    $('#sonsecond').bind('dblclick', function() {
        var id = $('#sonsecondId').text();
        redirectToMiddalPerson(id);
    });

    $('#addsonfirst').click(function() {
        var id = $('#sonfirstId').text();
        addNewPerson(id);
    });

    $('#sonfirst').bind('dblclick', function() {
        var id = $('#sonfirstId').text();
        redirectToMiddalPerson(id);
    });

    $('#addsonthird').click(function() {
        var id = $('#sonthirdId').text();
        addNewPerson(id);
    });

    $('#sonthird').bind('dblclick', function() {
        var id = $('#sonthirdId').text();
        redirectToMiddalPerson(id);
    });

    // Doubble click event handaling.
    function redirectToMiddalPerson(id, gender) {
        if (window.location.href.split('id').length > 1)
            window.location.href = window.location.href.split('id')[0] + "id=" + id;
        else
            window.location.href = window.location.href + "?id=" + id;

        window.parentWindow = function(id) {
            alert(id);
        }
    }

    // Edit methods.

    $('#editpersonFather').click(function() {
        var id = $('#personFatherId').text();
        editSelectedPerson(id);
    });

    $('#editpersonMotherFather').click(function() {
        var id = $('#personMotherFatherId').text();
        editSelectedPerson(id);
    });

    $('#editpersonMother').click(function() {
        var id = $('#personMotherId').text();
        editSelectedPerson(id);
    });

    $('#editmalePerson').click(function() {
        var id = $('#malePersonId').text();
        editSelectedPerson(id);
    });

    $('#editfemalePerson').click(function() {
        var id = $('#femalePersonId').text();
        editSelectedPerson(id);
    });

    $('#editsonsecond').click(function() {
        var id = $('#sonsecondId').text();
        editSelectedPerson(id);
    });

    $('#editsonfirst').click(function() {
        var id = $('#sonfirstId').text();
        editSelectedPerson(id);
    });

    $('#editsonthird').click(function() {
        var id = $('#sonthirdId').text();
        editSelectedPerson(id);
    });

    // Delete methods.

    $('#deletepersonFather').click(function() {
        alert('Delete me.');
    });

    function addNewPerson(id) {
        var width = 350; // 300;
        var height = 200;  //320;
        var left = parseInt((screen.availWidth / 2) - (width / 2));
        var top = parseInt((screen.availHeight / 2) - (height / 2));
        var windowFeatures = "width=" + width + ",height=" + height + ",status,resizable,left=" + left + ",top=" + top + "screenX=" + left + ",screenY=" + top;
        if (id != null)
            window.open("editUpdate.aspx?addId=" + id, 'Add New Person', windowFeatures);
        else
            window.open("editUpdate.aspx", 'Edit Person', windowFeatures);
    }

    function editSelectedPerson(id) {
        var width = 350; // 300;
        var height = 200;  //320;
        var left = parseInt((screen.availWidth / 2) - (width / 2));
        var top = parseInt((screen.availHeight / 2) - (height / 2));
        var windowFeatures = "width=" + width + ",height=" + height + ",status,resizable,left=" + left + ",top=" + top + "screenX=" + left + ",screenY=" + top;
        if (id != null)
            window.open("editUpdate.aspx?id=" + id, 'Edit Person', windowFeatures);
        else
            window.open("editUpdate.aspx", 'Edit Person', windowFeatures);
    }

    function addNewPerson_old() {
        $('#addPersonModelId').dialog({
            modal: true
        });
        addPersonFlag = true;
        $('#addPersonModelId').dialog("option", "minWidth", 420);
        $('#addPersonModelId').dialog("option", "resizable", false);
        $('#addPersonModelId').dialog("option", "position", "center");
        $('#cancelButton').bind('click', function() {
            $('#addPersonModelId').dialog('close');
        });
        $('#addNewPerson').bind('click', function() {
            if (addPersonFlag == true) {
                var jsEmp = new Person($('#txtFirstName').val(), $('#txtLastName').val(), $('#txtMobileNo').val(), $('#relation').val(), $('#inputPhoto').val());
                var jsonText = $.toJSON(jsEmp);
                $.ajax(
                          {
                              type: "POST",
                              url: "MethodInvokeWithJQuery.aspx/addPerson",
                              data: "{'jsonParam' : " + jsonText + "}",
                              contentType: "application/json; charset=utf-8",
                              dataType: "json",
                              async: false,
                              cache: false,
                              success: function(msg) {
                                  addPersonFlag = false;
                                  if (msg.d != 'Error in storing record.') {
                                      alert('New relative inserted.');
                                      addPerson($('#txtFirstName').val(), $('#txtLastName').val(), $('#txtMobileNo').val(), $('#relation').val(), $('#inputPhoto').val());
                                      $('#txtFirstName').val(''); $('#txtLastName').val(''); $('#txtMobileNo').val(''); $('#relation').val(''); $('#inputPhoto').val('');
                                  } else {
                                      alert('Mobile number already exist. Proceed logically.' + msg.d);
                                  }
                                  $('#addPersonModelId').dialog('close');
                              },
                              error: function(x, e) {
                                  addPersonFlag = false;
                                  alert("The call to the server side failed. " + x.responseText);
                                  $('#addPersonModelId').dialog('close');
                              }
                          }
                    );
            }
        });
    }

    function editPerson(fname, lname, mobile, relation) {
        $('#editPersonModel').dialog({
            modal: true
        });
        editPersonFlag = true;
        $('#editPersonModel').dialog("option", "minWidth", 420);
        $('#editPersonModel').dialog("option", "resizable", false);
        $('#editPersonModel').dialog("option", "position", "center");
        $('#txtEditFirstName').val(fname);
        $('#txtEditLastName').val(lname);
        $('#txtEditMobileNo').val(mobile);
        $('#txtEditPersonRelation').val(relation);
        $('#btnCancelEdit').bind('click', function() {
            $('#editPersonModel').dialog('close');
        });
        $('#btnUpdateEdit').bind('click', function() {
            if (editPersonFlag == true) {
                var jsEmp = new Person($('#txtEditFirstName').val(), $('#txtEditLastName').val(), $('#txtEditMobileNo').val(), $('#txtEditPersonRelation').val(), $('#txtEditPhoto').val());
                var jsonText = $.toJSON(jsEmp);
                $.ajax(
                          {
                              type: "POST",
                              url: "MethodInvokeWithJQuery.aspx/updatePerson",
                              data: "{'jsonParam' : " + jsonText + "}",
                              contentType: "application/json; charset=utf-8",
                              dataType: "json",
                              async: false,
                              cache: false,
                              success: function(msg) {
                                  editPersonFlag = false;
                                  if (msg.d != 'Error in storing record.') {
                                      alert('Relative Updated.');
                                      updateThisPerson($('#txtEditFirstName').val(), $('#txtEditLastName').val(), $('#txtEditMobileNo').val(), $('#txtEditPersonRelation').val(), $('#txtEditPhoto').val());
                                      $('#txtEditFirstName').val(''); $('#txtEditLastName').val(''); $('#txtEditMobileNo').val(''); $('#txtEditPersonRelation').val(''); $('#txtEditPhoto').val('');
                                  } else {
                                      alert('Proceed logically.' + msg.d);
                                  }
                                  $('#editPersonModel').dialog('close');
                              },
                              error: function(x, e) {
                                  addPersonFlag = false;
                                  alert("The call to the server side failed. " + x.responseText);
                                  $('#editPersonModel').dialog('close');
                              }
                          }
                    );
            }
        });
    }
    function updateThisPerson(fname, lname, mobile, relation, photo) {
        $('#firstName' + mobile).text(fname);
        $('#lastName' + mobile).text(lname);
        $('#relation' + mobile).text(relation);
    }
    function addPerson(fname, lname, mobile, relation, photo) {
        var addRow = '<tr><td><div class="cardContainer" id="cardContainer' + mobile + '"><div class="cardHeader">' +
                              '<input type="button" class="IconPlusButton" id="addPerson' + mobile + '" />' +
                              '<div class="allButtons">' +
                             '<input type="button" class="EditButton" id="editPerson' + mobile + '" />' +
                                '<input type="button" class="IconMinusButton" id="deletePerson' + mobile + '" />' +
                            '</div>' +
                        '</div>' +
                     '<div class="personPhoto">' +
                           '<img id="personImg" class="imageClass" src="' + photo + '" />' +
                         '</div>' +
                        '<div class="personInfo">' +
                               '<span id="firstName' + mobile + '">' + fname + '</span> <br/><span id="lastName' + mobile + '">' + lname + '</span><br/> <span id="mobileNo' + mobile + '">' +
                                   '' + mobile + '</span><span id="relation' + mobile + '" style="display:none;">' + relation + '</span>' +
                            '</div>' +
                        '</div></td></tr>';
        $('#myTable tr:last').after(addRow);
        $('#addPerson' + mobile + '').bind('click', function() {
            addNewPerson();
        });
        $('#editPerson' + mobile + '').bind('click', function() {
            editPerson($('#firstName' + mobile).text(), $('#lastName' + mobile).text(), mobile, $('#relation' + mobile).text()); //$('#editPerson' + mobile + '').selector.split('editPerson')[1]
        });

        $('#deletePerson' + mobile + '').bind('click', function() {
            $('#cardContainer' + mobile + '').hide();
            $.ajax(
                    {
                        type: "POST",
                        url: "MethodInvokeWithJQuery.aspx/deletePerson",
                        data: "{'strParam' : '" + mobile + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: true,
                        cache: false,
                        success: function() {
                            alert('Deleted.');
                        },
                        error: function(x, e) {
                            alert("The call to the server side failed. " + x.responseText);
                        }
                    }
                 );

        });
    }
});