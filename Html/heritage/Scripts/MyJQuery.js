// JScript File

var Person =  function(fName, lName, technology, age) 
                {
                    this.FirstName = fName;
                    this.LastName = lName;
                    this.Technology = technology;
                    this.Age = age;
                }
$(document).ready   (
                        function () 
                        {
                            try
                            {
                                $('#btnTest').click
                                (
                                    function () 
                                    {
                                        $.ajax  (
                                                    {
                                                        type: "POST",
                                                        url: "MethodInvokeWithJQuery.aspx/MethodWithNoParameter",
                                                        data: "{}",
                                                        contentType: "application/json; charset=utf-8",
                                                        dataType: "json",
                                                        async: true,
                                                        cache: false,
                                                        success: function (msg) 
                                                        {
                                                            $('#myDiv').text(msg.d); 
                                                        },
                                                        error: function (x, e)
                                                        {
                                                            alert("The call to the server side failed. " + x.responseText);
                                                        }
                                                    }
                                                );
                                        return false;
                                    }
                                );
                                
                                $('#btnTest2').click
                                (
                                    function () 
                                    {
                                        $.ajax  (
                                                    {
                                                        type: "POST",
                                                        url: "MethodInvokeWithJQuery.aspx/MethodWithNumericParameter",
                                                        data: "{'strParam' : 2}",
                                                        contentType: "application/json; charset=utf-8",
                                                        dataType: "json",
                                                        async: true,
                                                        cache: false,
                                                        success: function (msg) 
                                                        {
                                                            $('#myDiv2').text(msg.d); 
                                                        },
                                                        error: function (x, e)
                                                        {
                                                            alert("The call to the server side failed. " + x.responseText);
                                                        }
                                                    }
                                                );
                                        return false;
                                    }
                                );
                                
                                $('#btnTest3').click
                                (
                                    function () 
                                    {
                                        var jsEmp = new Person("Praveen", "Meghwal", "Microsoft Dotnet", 31);
                                        var jsonText = $.toJSON(jsEmp);
                                        $.ajax  (
                                                    {
                                                        type: "POST",
                                                        url: "MethodInvokeWithJQuery.aspx/MethodWithComplexParameter",
                                                        data: "{'jsonParam' : " + jsonText + "}",
                                                        contentType: "application/json; charset=utf-8",
                                                        dataType: "json",
                                                        async: true,
                                                        cache: false,
                                                        success: function (msg) 
                                                        {
                                                            $('#myDiv3').html(msg.d); 
                                                        },
                                                        error: function (x, e)
                                                        {
                                                            alert("The call to the server side failed. " + x.responseText);
                                                        }
                                                    }
                                                );
                                        return false;
                                    }
                                );
                            }
                            catch(err)
                            {
                                alert(err);
                            }
                        }
                    );

