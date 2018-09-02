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

    $('#addPerson').click(function() {
        addNewPerson();
    });

    $('#editPerson').click(function() {
        alert('Edit me');
    });

    $('#deletePerson').click(function() {
        alert('Delete me.');
    });

    function addNewPerson() {
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