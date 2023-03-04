$('#MainProductId').change(function () {
    debugger;

    var MainProductId = $("#MainProductId option:selected").val();
    if (MainProductId.length == 0) {
        var s = '<option value="">- Select Product -</option>'
        $('#ProductId').html(s);
    } else {
        var s = '<option value="">- Select Product -</option>'
        $('#ProductId').html(s);
        $.ajax({
            url: "/Product/GetProduct",
            type: "Get",
            dataType: "json",
            data: {
                MainProductId: MainProductId
            },
            success: function (result) {
                debugger
                var data = JSON.parse(result);
                for (var i = 0; i < data.length; i++) {
                    var opt = new Option(data[i].ProductName, data[i].ProdId);
                    $('#ProductId').append(opt);

                }
            }

        });
    }
});
$('#ProductId').change(function () {
    debugger;

    var MainProductId = $("#MainProductId option:selected").val();
    var ProductId = $("#ProductId option:selected").val();


    $.ajax({
        url: "/Product/GetSubProduct",
        type: "Get",

        dataType: "json",
        data: {
            MainProductId: MainProductId,
            ProductId: ProductId
        },
        success: function (result) {
            debugger
            var data = JSON.parse(result)[0].CustTypeRequried;
            document.getElementById("hdn_type").value = data;
            if (data == "c") {
                $("#co_applicant_div").show();
                $("#co_guranter_div").hide();

            } else if (data == "g") {
                $("#co_applicant_div").hide();
                $("#co_guranter_div").show();
                //    document.getElementById("ProductId").value = data;
            } else if (data == "b") {
                $("#co_applicant_div").show();
                $("#co_guranter_div").show();
                //    document.getElementById("ProductId").value = data;
            }
        }

    });

});
$('#customerpermanentstate').change(function () {
    debugger;

    var stateid = $("#customerpermanentstate option:selected").val();
    if (stateid.length == 0) {
        var s = '<option value="">- Select City -</option>'
        $('#customerpermanentcity').html(s);
    } else {
        var s = '<option value="">- Select City -</option>'
        $('#customerpermanentcity').html(s);
        $.ajax({
            url: "/City/GetCity",
            type: "Get",
            /* url: '@Url.Action("GetCity", "City")',*/
            dataType: "json",
            data: {
                StateId: stateid
            },
            success: function (result) {
                debugger
                var data = JSON.parse(result);
                for (var i = 0; i < data.length; i++) {
                    var opt = new Option(data[i].CityName, data[i].Cityid);
                    $('#customerpermanentcity').append(opt);

                }
            }
            
        });
    }
});
$('#customerpresentState').change(function () {
    debugger;

    var stateid = $("#customerpresentState option:selected").val();
    if (stateid.length == 0) {
        var s = '<option value="">- Select City -</option>'
        $('#customerpresentcity').html(s);
    } else {
        var s = '<option value="">- Select City -</option>'
        $('#customerpresentcity').html(s);
        $.ajax({
            url: "/City/GetCity",
            type: "Get",
            /* url: '@Url.Action("GetCity", "City")',*/
            dataType: "json",
            data: {
                StateId: stateid
            },
            success: function (result) {
                debugger
                var data = JSON.parse(result);
                for (var i = 0; i < data.length; i++) {
                    var opt = new Option(data[i].CityName, data[i].Cityid);
                    $('#customerpresentcity').append(opt);

                }
            }

        });
    }
});

$('#Co_State').change(function () {
    debugger;

    var stateid = $("#Co_State option:selected").val();
    if (stateid.length == 0) {
        var s = '<option value="">- Select City -</option>'
        $('#CO_City').html(s);
    } else {
        var s = '<option value="">- Select City -</option>'
        $('#CO_City').html(s);
        $.ajax({
            url: "/City/GetCity",
            type: "Get",
            /* url: '@Url.Action("GetCity", "City")',*/
            dataType: "json",
            data: {
                StateId: stateid
            },
            success: function (result) {
                debugger
                var data = JSON.parse(result);
                for (var i = 0; i < data.length; i++) {
                    var opt = new Option(data[i].CityName, data[i].Cityid);
                    $('#CO_City').append(opt);

                }
            }

        });
    }
});
$('#CO_permanentstate').change(function () {
    debugger;

    var stateid = $("#CO_permanentstate option:selected").val();
    if (stateid.length == 0) {
        var s = '<option value="">- Select City -</option>'
        $('#CO_permanentcity').html(s);
    } else {
        var s = '<option value="">- Select City -</option>'
        $('#CO_permanentcity').html(s);
        $.ajax({
            url: "/City/GetCity",
            type: "Get",
            /* url: '@Url.Action("GetCity", "City")',*/
            dataType: "json",
            data: {
                StateId: stateid
            },
            success: function (result) {
                debugger
                var data = JSON.parse(result);
                for (var i = 0; i < data.length; i++) {
                    var opt = new Option(data[i].CityName, data[i].Cityid);
                    $('#CO_permanentcity').append(opt);

                }
            }

        });
    }
});


$('#G_C_State').change(function () {
    debugger;

    var stateid = $("#G_C_State option:selected").val();
    if (stateid.length == 0) {
        var s = '<option value="">- Select City -</option>'
        $('#G_C_City').html(s);
    } else {
        var s = '<option value="">- Select City -</option>'
        $('#G_C_City').html(s);
        $.ajax({
            url: "/City/GetCity",
            type: "Get",
            /* url: '@Url.Action("GetCity", "City")',*/
            dataType: "json",
            data: {
                StateId: stateid
            },
            success: function (result) {
                debugger
                var data = JSON.parse(result);
                for (var i = 0; i < data.length; i++) {
                    var opt = new Option(data[i].CityName, data[i].Cityid);
                    $('#G_C_City').append(opt);

                }
            }


        });
    }
});



$('#G_P_State').change(function () {
    debugger;

    var stateid = $("#G_P_State option:selected").val();
    if (stateid.length == 0) {
        var s = '<option value="">- Select City -</option>'
        $('#G_P_City').html(s);
    } else {
        var s = '<option value="">- Select City -</option>'
        $('#G_P_City').html(s);
        $.ajax({
            url: "/City/GetCity",
            type: "Get",
            /* url: '@Url.Action("GetCity", "City")',*/
            dataType: "json",
            data: {
                StateId: stateid
            },
            success: function (result) {
                debugger
                var data = JSON.parse(result);
                for (var i = 0; i < data.length; i++) {
                    var opt = new Option(data[i].CityName, data[i].Cityid);
                    $('#G_P_City').append(opt);

                }
            }


        });
    }
});


function ValidationChk() {
    debugger
    var regex = /^[a-zA-Z]*$/;
    var PANregex = /[A-Z]{5}[0-9]{4}[A-Z]{1}$/;
    var ReqType = "Insert";
    var MainProductId = $("#MainProductId option:selected").val();
    var ProductId = $("#ProductId option:selected").val();
    var FName = $("#FName").val();
    var MName = $("#MName").val();
    var LName = $("#LName").val();
    var FatherName = $("#FatherName").val();
    var MotherName = $("#MotherName").val();
    var SpouseName = $("#SpouseName").val();
    var Dob = $("#Dob").val();
    var Gender = $("#Gender option:selected").val();

    var MartialStatus = $("#MartialStatus option:selected").val();
    var PresentAddress = $("#PresentAddress").val();
    var PresentPincode = $("#PresentPincode").val();
    var PresentStateId = $("#customerpresentState option:selected").val();
    var PresentCityId = $("#customerpresentcity option:selected").val();
    var PermanentAddress = $("#PermanentAddress").val();
    var PermanentPincode = $("#PermanentPincode").val();
    var PermanentStateId = $("#customerpermanentstate option:selected").val();
    var PermanentCityId = $("#customerpermanentcity option:selected").val();
    var CibilScore = $("#CibilScore").val();
    var MobileNumber1 = $("#MobileNumber1").val();
    /*var MobileNumber2 = $("#MobileNumber2").val();*/
    var FatherMobileNumber = $("#FatherMobileNumber").val();
    var MotherMobileNumber = $("#MotherMobileNumber").val();
    var SpouseMobileNumber = $("#SpouseMobileNumber").val();
    var SpouseMobileNumber = $("#SpouseMobileNumber").val();
    var EmailId = $("#EmailId").val();
    var CIFID = $("#CIFID").val();
    var AadharNo = $("#AadharNo").val();
    var hdn_customer_aadhar_verify = $("#hdn_customer_aadhar_verify").val();
    
    var PanNo = $("#PanNo").val();
    var hdn_type = $("#hdn_type").val();
    var CompanyID = 1;



    //CO_Applicant Info
    var CO_FName = $("#CO_FName").val();
    var CO_MName = $("#CO_MName").val();
    var CO_LName = $("#CO_LName").val();
    var CO_Gender = $("#CO_Gender option:selected").val();
    var CO_Dob = $("#CO_Dob").val();
    var CO_MartialStatus = $("#CO_MartialStatus option:selected").val();
    var CO_PresentAddress = $("#CO_PresentAddress").val();
    var CO_PresentPincode = $("#CO_PresentPincode").val();
    var CO_PresentStateId = $("#Co_State option:selected").val();
    var CO_City = $("#CO_City option:selected").val();
    var CO_PermanentAddress = $("#CO_PermanentAddress").val();
    var CO_PermanentPincode = $("#CO_PermanentPincode").val();
    var CO_permanentstate = $("#CO_permanentstate option:selected").val();
    var CO_permanentcity = $("#CO_permanentcity option:selected").val();
    var CO_MObileNO = $("#CO_MObileNO").val();
    var CO_EmailId = $("#CO_EmailId").val();
    var CO_PanNo = $("#CO_PanNo").val();
    var CO_AadharNo = $("#CO_AadharNo").val();
    var CO_CibilScore = $("#CO_CibilScore").val();

    //Additional Info
    var ReuestedLoanAmount = $("#ReuestedLoanAmount").val();
    var ReuestedLoanTenure = $("#ReuestedLoanTenure").val();
    var EstValueViechle = $("#EstValueViechle").val();
    var EstMonthIncome = $("#EstMonthIncome").val();
    var EstMonthExpense = $("#EstMonthExpense").val();
    var CurMonthObligation = $("#CurMonthObligation").val();
    var FORecomedAmt = $("#FORecomedAmt").val();
    var NoofDependent = $("#NoofDependent").val();
    var ViechleNo = $("#ViechleNo").val();
    var ViechleRegYear = $("#ViechleRegYear").val();
    var MFGYear = $("#MFGYear").val();
    var ViechleModel = $("#ViechleModel").val();
    var ViechleColor = $("#ViechleColor").val();
    var ViechleCompany = $("#ViechleCompany").val();
    var ViechleOwner = $("#ViechleOwner").val();
    var RefernceName = $("#RefernceName").val();
    var RefenceMobileNo = $("#RefenceMobileNo").val();
    var RefenceRelation = $("#RefenceRelation").val();
    var LoanPurpose = $("#LoanPurpose").val();
    var ColletralSecurityType = $("#ColletralSecurityType").val();

    var customers = new Array();
   

    var filedata = new FormData();
    debugger

    if (MainProductId.length == 0) {

        swal({
            title: "Error",
            text: "Please select main product",
            icon: "error",
            button: true,

        })
            .then((willConfirm) => {
                if (willConfirm) {

                }
            });

    }
    else if (ProductId.length == 0) {

        swal({
            title: "Error",
            text: "Please select product",
            icon: "error",
            button: true,

        })
            .then((willConfirm) => {
                if (willConfirm) {

                }
            });

    } else {
        if (hdn_type == "b") {
            $("#example10 TBODY TR").each(function () {
                var row = $(this);
                var customer = {};
                customer.G_FirstName = row.find("TD").eq(0).html();
                customer.G_MiddleName = row.find("TD").eq(1).html();
                customer.G_LastName = row.find("TD").eq(2).html();
                customer.G_Gender = row.find("TD").eq(3).html();
                customer.G_DOB = row.find("TD").eq(4).html();
                customer.G_Marital_Status = row.find("TD").eq(5).html();


                customer.G_PresentAddress = row.find("TD").eq(6).html();
                customer.G_PresentPinCode = row.find("TD").eq(7).html();
                customer.G_PresentStateId = row.find("TD").eq(8).html();
                customer.G_PresentCityId = row.find("TD").eq(9).html();




                customer.G_PermanentAddress = row.find("TD").eq(10).html();
                customer.G_PermanentPincode = row.find("TD").eq(11).html();
                customer.G_P_State = row.find("TD").eq(11).html(12);
                customer.G_P_City = row.find("TD").eq(12).html(13);

                customer.G_Mobile_No = row.find("TD").eq(14).html();
                customer.G_EmailId = row.find("TD").eq(15).html();
                customer.G_PanNo = row.find("TD").eq(16).html();
                customer.G_AadharNo = row.find("TD").eq(17).html();
                customer.G_CibilScore = row.find("TD").eq(18).html();
                
                customers.push(customer);
                
            });

            if (FName.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer first name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (LName.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer last name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (FatherName.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer father name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (MotherName.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer mother name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (MartialStatus == "Married" && SpouseName.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer spouse name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (Gender.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer gender",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (Dob.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer dob",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (underAgeValidate(Dob) < 18) {

                swal({
                    title: "Error",
                    text: "customer is not 18 years",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (MartialStatus.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer material status",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (AadharNo.length == 0) {
                swal({
                    title: "Error",
                    text: "Please enter customer aadhar no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (AadharNo.length != 12) {
                swal({
                    title: "Error",
                    text: "Customer invalid aadhar no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (PanNo.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer pan no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (PanNo.length != 10) {

                swal({
                    title: "Error",
                    text: "Customer invalid pan no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (PresentAddress.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer present address",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (PresentPincode.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer present pincode",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (PresentPincode.length != 6) {

                swal({
                    title: "Error",
                    text: "Customer invalid present pincode",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (PermanentAddress.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer permanent address",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (PermanentPincode.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer permanent pincode",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (PermanentPincode.length != 6) {

                swal({
                    title: "Error",
                    text: " Customer invalid permanent pincode",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (CibilScore.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter custome cibil score",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (CibilScore > 900) {

                swal({
                    title: "Error",
                    text: "Custome invalid cibil score",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (MobileNumber1.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer mobile number",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (FatherMobileNumber.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer father mobile number",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (MotherMobileNumber.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer mother mobile number",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (MartialStatus == "Married" && SpouseMobileNumber.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter spouse mobile number",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (EmailId.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer email id",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });





            }

            else if (CO_FName.length == 0) {
                swal({
                    title: "Error",
                    text: "Please enter co applicant first name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (CO_LName.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant last name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });





            }
            else if (CO_Gender.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant gender",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (CO_Dob.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant DOB",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (underAgeValidate(CO_Dob) < 18) {

                swal({
                    title: "Error",
                    text: "Co applicant  is not 18 years",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (CO_MartialStatus.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter gurantor matrial status",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (CO_PresentAddress.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant PresentAddress",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (CO_PresentPincode.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant PresentPincode",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (CO_PresentPincode.length != 6) {

                swal({
                    title: "Error",
                    text: "Invalid co applicant Present Pincode",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (CO_PresentStateId.length == 0) {


                swal({
                    title: "Error",
                    text: "Please enter co applicant state",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (CO_City.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant city",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (CO_PermanentAddress.length == 0) {
                swal({
                    title: "Error",
                    text: "Please enter co applicant PermanentAddress",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (CO_PermanentPincode.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant PermanentPincode",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (CO_PermanentPincode.length != 6) {

                swal({
                    title: "Error",
                    text: "Invalid co applicant Permanent Pincode",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (CO_permanentstate.length == 0) {



                swal({
                    title: "Error",
                    text: "Please enter co applicant  state",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });



            }
            else if (CO_permanentcity.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant city",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });



            }
            else if (CO_MObileNO.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant mobile no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });



            }
            else if (CO_EmailId.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant valid email id",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });





            }
            else if (CO_PanNo.length != 10) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant pan no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });





            }
            else if (CO_AadharNo.length != 12) {

                swal({
                    title: "Error",
                    text: "Please enter co aplicant Aadhar No",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });



            }
            else if (CO_CibilScore.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co aplicant CibilScore",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });



            }
            else if (CO_CibilScore > 900) {

                swal({
                    title: "Error",
                    text: "Invalid co aplicant cibil score",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (customers.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter gurantor details",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (ReuestedLoanAmount.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter ReuestedLoanAmount",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (ReuestedLoanTenure.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter ReuestedLoanTenure",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (ReuestedLoanTenure.length > 100) {

                swal({
                    title: "Error",
                    text: "Invalid ReuestedLoanTenure",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (LoanPurpose.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter purpose of loan",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (RefernceName.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter refrence person name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (RefenceRelation.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter refrence person with relationship",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (RefenceMobileNo.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter refrence person mobile no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (RefenceMobileNo.length != 10) {

                swal({
                    title: "Error",
                    text: "Invalid refrence person mobile no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (NoofDependent.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter no of dependent person",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (NoofDependent.length > 10) {

                swal({
                    title: "Error",
                    text: "Invalid no of dependent person",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (EstMonthIncome.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter est month income",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (EstMonthExpense.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter est month expense",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }



            else {
                
                AllDataArray = {
                    "ReqType": ReqType,
                    "MainProductId": MainProductId,
                    "ProductId": ProductId,
                    "FirstName": FName,
                    "MiddleName": MName,
                    "LastName": LName,
                    "FastherName": FatherName,
                    "MotherName": MotherName,
                    "SpouseName": SpouseName,
                    "Gender": Gender,
                    "DateofBirth": Dob,
                    "MartialStatus": MartialStatus,
                    "PresentAddress": PresentAddress,
                    "PresentPincode": PresentPincode,
                    "PresentStateId": PresentStateId,
                    "PresentCityId": PresentCityId,
                    "PermanentAddress": PermanentAddress,
                    "PermanentPincode": PermanentPincode,
                    "PermanentStateId": PermanentStateId,
                    "PermanentCityId": PermanentCityId,
                    "CibilScore": CibilScore,
                    "MobileNo1": MobileNumber1,

                    /*"MobileNo2": MobileNumber2,*/
                    "FatherMobileNo": FatherMobileNumber,
                    "MotherMobileNo": MotherMobileNumber,
                    "SpouseMobileNo": SpouseMobileNumber,
                    "AadharNo": AadharNo,
                    "PanNo": PanNo,
                    "CompanyId": CompanyID,
                    "Hdn_type": hdn_type,
                    "EmailId": EmailId,
                    "CIFID": CIFID,
                    "AAdharverfiy": hdn_customer_aadhar_verify,


                    "CO_FirstName": CO_FName,
                    "CO_MiddleName": CO_MName,
                    "CO_LastName": CO_LName,
                    "CO_DOB": CO_Dob,
                    "CO_Marital_Status": CO_MartialStatus,
                    "CO_Gender": CO_Gender,
                    "CO_PresentAddress": CO_PresentAddress,
                    "CO_PresentPinCode": CO_PresentPincode,
                    "CO_PresentStateId": CO_PresentStateId,
                    "CO_PresentCityId": CO_City,
                    "CO_PermanentAddress": CO_PermanentAddress,
                    "CO_PermanentPincode": CO_PermanentPincode,
                    "CO_PermanentStateId": CO_permanentstate,
                    "CO_PermanentCityId": CO_permanentcity,
                    "CO_Mobile_No": CO_MObileNO,
                    "CO_Email_Id": CO_EmailId,
                    "CO_PAN": CO_PanNo,
                    "CO_Adhaar": CO_AadharNo,
                    "CO_CIBIL": CO_CibilScore,



                    "ReuestedLoanAmount": ReuestedLoanAmount,
                    "ReuestedLoanTenure": ReuestedLoanTenure,
                    "EstValueViechle": EstValueViechle,
                    "EstMonthIncome": EstMonthIncome,
                    "EstMonthExpense": EstMonthExpense,
                    "CurMonthObligation": CurMonthObligation,
                    "FORecomedAmt": FORecomedAmt,
                    "NoofDependent": NoofDependent,
                    "ViechleNo": ViechleNo,
                    "ViechleRegYear": ViechleRegYear,
                    "MFGYear": MFGYear,
                    "ViechleModel": ViechleModel,
                    "ViechleColor": ViechleColor,
                    "ViechleCompany": ViechleCompany,
                    "ViechleOwner": ViechleOwner,
                    "RefernceName": RefernceName,
                    "RefenceMobileNo": RefenceMobileNo,
                    "RefenceRelation": RefenceRelation,
                    "LoanPurpose": LoanPurpose,
                    "ColletralSecurityType": ColletralSecurityType,


                }

                filedata.append('AllDataArray', JSON.stringify(AllDataArray));
                filedata.append('Gurantor_Details', JSON.stringify(customers));
                $.ajax({
                    url: "/LeadGeneration/AddRequestLeadGeneration",
                    type: "POST",
                    contentType: false,
                    processData: false,
                    data: filedata,

                    success: function (result) {
                        debugger

                        var message = JSON.parse(result)[0].ReturnMessage;

                        if (message == "Lead saved succussfully") {
                            swal({
                                title: "Success",
                                text: message + " Your Lead No: " + JSON.parse(result)[0].LeadNo,
                                icon: "success",
                                button: true,

                            })
                                .then((willConfirm) => {
                                    if (willConfirm) {
                                        window.location.pathname = 'Lead/LeadView';

                                    }
                                });




                        } else {
                            swal({
                                title: "Error",
                                text: "Login Error",
                                icon: "error",
                                button: true,

                            })
                                .then((willConfirm) => {
                                    if (willConfirm) {

                                    }
                                });

                        }



                    }



                })

            }


        }
        else if (hdn_type == "c") {

            if (FName.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer first name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (LName.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer last name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (FatherName.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer father name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (MotherName.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer mother name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (MartialStatus == "Married" && SpouseName.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer spouse name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (Gender.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer gender",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (Dob.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer dob",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (underAgeValidate(Dob) < 18) {

                swal({
                    title: "Error",
                    text: "customer is not 18 years",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (MartialStatus.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer material status",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (AadharNo.length == 0) {
                swal({
                    title: "Error",
                    text: "Please enter customer aadhar no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (AadharNo.length != 12) {
                swal({
                    title: "Error",
                    text: "Customer invalid aadhar no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (PanNo.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer pan no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (PanNo.length != 10) {

                swal({
                    title: "Error",
                    text: "Customer invalid pan no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (PresentAddress.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer present address",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (PresentPincode.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer present pincode",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (PresentPincode.length != 6) {

                swal({
                    title: "Error",
                    text: "Customer invalid present pincode",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (PermanentAddress.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer permanent address",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (PermanentPincode.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer permanent pincode",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (PermanentPincode.length != 6) {

                swal({
                    title: "Error",
                    text: " Customer invalid permanent pincode",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (CibilScore.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter custome cibil score",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (CibilScore > 900) {

                swal({
                    title: "Error",
                    text: "Custome invalid cibil score",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (MobileNumber1.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer mobile number",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (FatherMobileNumber.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer father mobile number",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (MotherMobileNumber.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer mother mobile number",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (MartialStatus == "Married" &&  SpouseMobileNumber.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter spouse mobile number",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (EmailId.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer email id",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });





            }


            else if (CO_FName.length == 0) {
                swal({
                    title: "Error",
                    text: "Please enter co applicant first name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
           
            else if (CO_LName.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant last name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });





            }
            else if (CO_Gender.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant gender",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (CO_Dob.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant DOB",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (underAgeValidate(CO_Dob) < 18) {

                swal({
                    title: "Error",
                    text: "Co applicant  is not 18 years",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (CO_MartialStatus.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter gurantor matrial status",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (CO_PresentAddress.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant PresentAddress",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (CO_PresentPincode.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant PresentPincode",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (CO_PresentStateId.length == 0) {


                swal({
                    title: "Error",
                    text: "Please enter co applicant state",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (CO_City.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant city",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (CO_PermanentAddress.length == 0) {
                swal({
                    title: "Error",
                    text: "Please enter co applicant PermanentAddress",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (CO_PermanentPincode.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant PermanentPincode",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (CO_permanentstate.length == 0) {



                swal({
                    title: "Error",
                    text: "Please enter co applicant  state",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });



            }
            else if (CO_permanentcity.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant city",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });



            }
            else if (CO_MObileNO.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant mobile no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });



            }
            else if (CO_EmailId.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant valid email id",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });





            }
            else if (CO_PanNo.length != 10) {

                swal({
                    title: "Error",
                    text: "Please enter co applicant pan no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });





            }
            else if (CO_AadharNo.length != 12) {

                swal({
                    title: "Error",
                    text: "Please enter co aplicant Aadhar No",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });



            }
            else if (CO_CibilScore.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter co aplicant CibilScore",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });



            }
            else if (CO_CibilScore > 900) {

                swal({
                    title: "Error",
                    text: "Invalid co aplicant cibil score",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (ReuestedLoanAmount.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter ReuestedLoanAmount",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (ReuestedLoanTenure.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter ReuestedLoanTenure",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (ReuestedLoanTenure.length > 100) {

                swal({
                    title: "Error",
                    text: "Invalid ReuestedLoanTenure",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (LoanPurpose.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter purpose of loan",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (RefernceName.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter refrence person name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (RefenceRelation.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter refrence person with relationship",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (RefenceMobileNo.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter refrence person mobile no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (RefenceMobileNo.length != 10) {

                swal({
                    title: "Error",
                    text: "Invalid refrence person mobile no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (NoofDependent.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter no of dependent person",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (NoofDependent.length > 10) {

                swal({
                    title: "Error",
                    text: "Invalid no of dependent person",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (EstMonthIncome.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter est month income",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (EstMonthExpense.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter est month expense",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }



            else {

                AllDataArray = {
                    "ReqType": ReqType,
                    "MainProductId": MainProductId,
                    "ProductId": ProductId,
                    "FirstName": FName,
                    "MiddleName": MName,
                    "LastName": LName,
                    "FastherName": FatherName,
                    "MotherName": MotherName,
                    "SpouseName": SpouseName,
                    "Gender": Gender,
                    "DateofBirth": Dob,
                    "MartialStatus": MartialStatus,
                    "PresentAddress": PresentAddress,
                    "PresentPincode": PresentPincode,
                    "PresentStateId": PresentStateId,
                    "PresentCityId": PresentCityId,
                    "PermanentAddress": PermanentAddress,
                    "PermanentPincode": PermanentPincode,
                    "PermanentStateId": PermanentStateId,
                    "PermanentCityId": PermanentCityId,
                    "CibilScore": CibilScore,
                    "MobileNo1": MobileNumber1,

                    /*"MobileNo2": MobileNumber2,*/
                    "FatherMobileNo": FatherMobileNumber,
                    "MotherMobileNo": MotherMobileNumber,
                    "SpouseMobileNo": SpouseMobileNumber,
                    "AadharNo": AadharNo,
                    "PanNo": PanNo,
                    "CompanyId": CompanyID,
                    "Hdn_type": hdn_type,
                    "EmailId": EmailId,
                    "CIFID": CIFID,
                    "AAdharverfiy": hdn_customer_aadhar_verify,




                    "CO_FirstName": CO_FName,
                    "CO_MiddleName": CO_MName,
                    "CO_LastName": CO_LName,
                    "CO_DOB": CO_Dob,
                    "CO_Marital_Status": CO_MartialStatus,
                    "CO_Gender": CO_Gender,
                    "CO_PresentAddress": CO_PresentAddress,
                    "CO_PresentPinCode": CO_PresentPincode,
                    "CO_PresentStateId": CO_PresentStateId,
                    "CO_PresentCityId": CO_City,
                    "CO_PermanentAddress": CO_PermanentAddress,
                    "CO_PermanentPincode": CO_PermanentPincode,
                    "CO_PermanentStateId": CO_permanentstate,
                    "CO_PermanentCityId": CO_permanentcity,
                    "CO_Mobile_No": CO_MObileNO,
                    "CO_Email_Id": CO_EmailId,
                    "CO_PAN": CO_PanNo,
                    "CO_Adhaar": CO_AadharNo,
                    "CO_CIBIL": CO_CibilScore,



                    "ReuestedLoanAmount": ReuestedLoanAmount,
                    "ReuestedLoanTenure": ReuestedLoanTenure,
                    "EstValueViechle": EstValueViechle,
                    "EstMonthIncome": EstMonthIncome,
                    "EstMonthExpense": EstMonthExpense,
                    "CurMonthObligation": CurMonthObligation,
                    "FORecomedAmt": FORecomedAmt,
                    "NoofDependent": NoofDependent,
                    "ViechleNo": ViechleNo,
                    "ViechleRegYear": ViechleRegYear,
                    "MFGYear": MFGYear,
                    "ViechleModel": ViechleModel,
                    "ViechleColor": ViechleColor,
                    "ViechleCompany": ViechleCompany,
                    "ViechleOwner": ViechleOwner,
                    "RefernceName": RefernceName,
                    "RefenceMobileNo": RefenceMobileNo,
                    "RefenceRelation": RefenceRelation,
                    "LoanPurpose": LoanPurpose,
                    "ColletralSecurityType": ColletralSecurityType,


                }

                filedata.append('AllDataArray', JSON.stringify(AllDataArray));
                filedata.append('Gurantor_Details', JSON.stringify(customers));
                $.ajax({
                    url: "/LeadGeneration/AddRequestLeadGeneration",
                    type: "POST",
                    contentType: false,
                    processData: false,
                    data: filedata,

                    success: function (result) {
                        debugger

                        var message = JSON.parse(result)[0].ReturnMessage;

                        if (message == "Lead saved succussfully") {
                            swal({
                                title: "Success",
                                text: message + " Your Lead No: " + JSON.parse(result)[0].LeadNo,
                                icon: "success",
                                button: true,

                            })
                                .then((willConfirm) => {
                                    if (willConfirm) {
                                        window.location.pathname = 'Lead/LeadView';

                                    }
                                });




                        } else {
                            swal({
                                title: "Error",
                                text: "Login Error",
                                icon: "error",
                                button: true,

                            })
                                .then((willConfirm) => {
                                    if (willConfirm) {

                                    }
                                });

                        }



                    }



                })

            }


        }
        else if (hdn_type == "g") {
            $("#example10 TBODY TR").each(function () {
                var row = $(this);
                var customer = {};
                customer.G_FirstName = row.find("TD").eq(0).html();
                customer.G_MiddleName = row.find("TD").eq(1).html();
                customer.G_LastName = row.find("TD").eq(2).html();
                customer.G_Gender = row.find("TD").eq(3).html();
                customer.G_DOB = row.find("TD").eq(4).html();
                customer.G_Marital_Status = row.find("TD").eq(5).html();


                customer.G_PresentAddress = row.find("TD").eq(6).html();
                customer.G_PresentPinCode = row.find("TD").eq(7).html();
                customer.G_PresentStateId = row.find("TD").eq(8).html();
                customer.G_PresentCityId = row.find("TD").eq(9).html();




                customer.G_PermanentAddress = row.find("TD").eq(10).html();
                customer.G_PermanentPincode = row.find("TD").eq(11).html();
                customer.G_P_State = row.find("TD").eq(11).html(12);
                customer.G_P_City = row.find("TD").eq(12).html(13);

                customer.G_Mobile_No = row.find("TD").eq(14).html();
                customer.G_EmailId = row.find("TD").eq(15).html();
                customer.G_PanNo = row.find("TD").eq(16).html();
                customer.G_AadharNo = row.find("TD").eq(17).html();
                customer.G_CibilScore = row.find("TD").eq(18).html();
                
                customers.push(customer);
                
            });
            if (FName.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer first name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (LName.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer last name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (FatherName.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer father name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (MotherName.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer mother name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (MartialStatus == "Married" && SpouseName.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer spouse name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (Gender.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer gender",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (Dob.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer dob",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (underAgeValidate(Dob) < 18) {

                swal({
                    title: "Error",
                    text: "customer is not 18 years",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (MartialStatus.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer material status",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (AadharNo.length == 0) {
                swal({
                    title: "Error",
                    text: "Please enter customer aadhar no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (AadharNo.length != 12) {
                swal({
                    title: "Error",
                    text: "Customer invalid aadhar no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (PanNo.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer pan no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (PanNo.length != 10) {

                swal({
                    title: "Error",
                    text: "Customer invalid pan no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (PresentAddress.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer present address",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (PresentPincode.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer present pincode",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (PresentPincode.length != 6) {

                swal({
                    title: "Error",
                    text: "Customer invalid present pincode",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (PermanentAddress.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer permanent address",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (PermanentPincode.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer permanent pincode",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (PermanentPincode.length != 6) {

                swal({
                    title: "Error",
                    text: " Customer invalid permanent pincode",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (CibilScore.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter custome cibil score",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (CibilScore > 900) {

                swal({
                    title: "Error",
                    text: "Custome invalid cibil score",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (MobileNumber1.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer mobile number",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (FatherMobileNumber.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer father mobile number",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (MotherMobileNumber.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer mother mobile number",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (MartialStatus == "Married" && SpouseMobileNumber.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter spouse mobile number",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (EmailId.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter customer email id",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });





            }
            else if (customers.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter gurantor details",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (CO_CibilScore > 900) {

                swal({
                    title: "Error",
                    text: "Invalid co aplicant cibil score",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (ReuestedLoanAmount.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter ReuestedLoanAmount",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });
            }
            else if (ReuestedLoanTenure.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter ReuestedLoanTenure",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });

            }
            else if (ReuestedLoanTenure.length > 100) {

                swal({
                    title: "Error",
                    text: "Invalid ReuestedLoanTenure",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (LoanPurpose.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter purpose of loan",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (RefernceName.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter refrence person name",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (RefenceRelation.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter refrence person with relationship",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (RefenceMobileNo.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter refrence person mobile no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (RefenceMobileNo.length != 10) {

                swal({
                    title: "Error",
                    text: "Invalid refrence person mobile no",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (NoofDependent.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter no of dependent person",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (NoofDependent.length > 10) {

                swal({
                    title: "Error",
                    text: "Invalid no of dependent person",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (EstMonthIncome.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter est month income",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }
            else if (EstMonthExpense.length == 0) {

                swal({
                    title: "Error",
                    text: "Please enter est month expense",
                    icon: "error",
                    button: true,

                })
                    .then((willConfirm) => {
                        if (willConfirm) {

                        }
                    });


            }

            else {


                AllDataArray = {
                    "ReqType": ReqType,
                    "MainProductId": MainProductId,
                    "ProductId": ProductId,
                    "FirstName": FName,
                    "MiddleName": MName,
                    "LastName": LName,
                    "FastherName": FatherName,
                    "MotherName": MotherName,
                    "SpouseName": SpouseName,
                    "Gender": Gender,
                    "DateofBirth": Dob,
                    "MartialStatus": MartialStatus,
                    "PresentAddress": PresentAddress,
                    "PresentPincode": PresentPincode,
                    "PresentStateId": PresentStateId,
                    "PresentCityId": PresentCityId,
                    "PermanentAddress": PermanentAddress,
                    "PermanentPincode": PermanentPincode,
                    "PermanentStateId": PermanentStateId,
                    "PermanentCityId": PermanentCityId,
                    "CibilScore": CibilScore,
                    "MobileNo1": MobileNumber1,

                    /*"MobileNo2": MobileNumber2,*/
                    "FatherMobileNo": FatherMobileNumber,
                    "MotherMobileNo": MotherMobileNumber,
                    "SpouseMobileNo": SpouseMobileNumber,
                    "AadharNo": AadharNo,
                    "PanNo": PanNo,
                    "CompanyId": CompanyID,
                    "Hdn_type": hdn_type,
                    "EmailId": EmailId,
                    "CIFID": CIFID,
                    "AAdharverfiy": hdn_customer_aadhar_verify,



                    "CO_FirstName": "",
                    "CO_MiddleName": "",
                    "CO_LastName": "",
                    "CO_DOB": "",
                    "CO_Marital_Status": "",
                    "CO_Gender": "",
                    "CO_PresentAddress": "",
                    "CO_PresentPinCode": "",
                    "CO_PresentStateId": 0,
                    "CO_PresentCityId": 0,
                    "CO_PermanentAddress": "",
                    "CO_PermanentPincode": "",
                    "CO_PermanentStateId": 0,
                    "CO_PermanentCityId": 0,
                    "CO_Mobile_No": "",
                    "CO_Email_Id": "",
                    "CO_PAN": "",
                    "CO_Adhaar": "",
                    "CO_CIBIL": "",



                    "ReuestedLoanAmount": ReuestedLoanAmount,
                    "ReuestedLoanTenure": ReuestedLoanTenure,
                    "EstValueViechle": EstValueViechle,
                    "EstMonthIncome": EstMonthIncome,
                    "EstMonthExpense": EstMonthExpense,
                    "CurMonthObligation": CurMonthObligation,
                    "FORecomedAmt": FORecomedAmt,
                    "NoofDependent": NoofDependent,
                    "ViechleNo": ViechleNo,
                    "ViechleRegYear": ViechleRegYear,
                    "MFGYear": MFGYear,
                    "ViechleModel": ViechleModel,
                    "ViechleColor": ViechleColor,
                    "ViechleCompany": ViechleCompany,
                    "ViechleOwner": ViechleOwner,
                    "RefernceName": RefernceName,
                    "RefenceMobileNo": RefenceMobileNo,
                    "RefenceRelation": RefenceRelation,
                    "LoanPurpose": LoanPurpose,
                    "ColletralSecurityType": ColletralSecurityType,


                }

                filedata.append('AllDataArray', JSON.stringify(AllDataArray));
                filedata.append('Gurantor_Details', JSON.stringify(customers));
                $.ajax({
                    url: "/LeadGeneration/AddRequestLeadGeneration",
                    type: "POST",
                    contentType: false,
                    processData: false,
                    data: filedata,

                    success: function (result) {
                        debugger

                        var message = JSON.parse(result)[0].ReturnMessage;

                        if (message == "Lead saved succussfully") {
                            swal({
                                title: "Success",
                                text: message + " Your Lead No: " + JSON.parse(result)[0].LeadNo,
                                icon: "success",
                                button: true,

                            })
                                .then((willConfirm) => {
                                    if (willConfirm) {
                                        window.location.pathname = 'Lead/LeadView';

                                    }
                                });




                        } else {
                            swal({
                                title: "Error",
                                text: "Login Error",
                                icon: "error",
                                button: true,

                            })
                                .then((willConfirm) => {
                                    if (willConfirm) {

                                    }
                                });

                        }



                    }



                })



            }


        }
        debugger



    }

}




function underAgeValidate(birthday) {


        // it will accept two types of format yyyy-mm-dd and yyyy/mm/dd
        var optimizedBirthday = birthday.replace(/-/g, "/");

        //set date based on birthday at 01:00:00 hours GMT+0100 (CET)
        var myBirthday = new Date(optimizedBirthday);

        // set current day on 01:00:00 hours GMT+0100 (CET)
        var currentDate = new Date().toJSON().slice(0, 10) + ' 01:00:00';

        // calculate age comparing current date and borthday
        var myAge = ~~((Date.now(currentDate) - myBirthday) / (31557600000));

        if (myAge < 18) {
            return myAge;
        } else {
            return myAge;
        }

    
}


function AAdharVerification() {
    debugger
    var AadharNo = $("#AadharNo").val();
    var emailid = "";

    debugger
    var urlvariable;

    urlvariable = "https://sm-kyc-sandbox.scoreme.in/kyc/external/aadhaarverificationdetails";

    var ItemJSON;

    ItemJSON = '{"aadhaarNumber": "' + AadharNo + '","email":  "' + emailid + '"}';
    debugger
    URL = urlvariable;  //Your URL

    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = callbackFunction(xmlhttp);
    xmlhttp.open("POST", URL, false);
    xmlhttp.setRequestHeader("Content-Type", "application/json");
    xmlhttp.setRequestHeader('ClientId', '9b7f56d730cb292199b7a49620fa80f6');
    xmlhttp.setRequestHeader('ClientSecret', '60812117e31f68b0475960d167a6fc856a09de16cc89f17f8ece51e29f216b15');//in prod, you should encrypt user name and password and provide encrypted keys here instead
    xmlhttp.onreadystatechange = callbackFunction(xmlhttp);
    xmlhttp.send(ItemJSON);
    debugger

    var data = JSON.parse(xmlhttp.responseText);

    if (data.responseMessage == "OTP successfully sent to mobile number.") {
        document.getElementById("referenceId").value = data.data.referenceId;
        swal({
            title: "Success",
            text: data.responseMessage,
            icon: "success",
            button: true,

        })
            .then((willConfirm) => {
                if (willConfirm) {

                    $("#myModal").modal()
                }
            });

    } else {
        swal({
            title: "Error",
            text: data.responseMessage,
            icon: "error",
            button: true,

        })
            .then((willConfirm) => {
                if (willConfirm) {

                }
            });
    }
}
function callbackFunction(xmlhttp) {
    //alert(xmlhttp.responseXML);
}
function ChkAadharOTP() {
    debugger
    var OTP = $("#OTP1").val() + $("#OTP2").val() + $("#OTP3").val() + $("#OTP4").val() + $("#OTP5").val() + $("#OTP6").val();
    if (OTP.length != 6) {
        swal({
            title: "Error",
            text: "Please enter valid OTP",
            icon: "error",
            button: true,

        })
            .then((willConfirm) => {
                if (willConfirm) {

                }
            });


    } else {
        
      
        debugger
        var referenceId = $("#referenceId").val();
        var urlvariable;

        urlvariable = "https://sm-kyc-sandbox.scoreme.in/kyc/external/aadhaarotpverification";

        var ItemJSON;

        ItemJSON = '{"otp": "' + OTP + '","referenceId":  "' + referenceId + '"}';
     
        URL = urlvariable;  //Your URL

        var xmlhttp = new XMLHttpRequest();
        xmlhttp.onreadystatechange = callbackFunction(xmlhttp);
        xmlhttp.open("POST", URL, false);
        xmlhttp.setRequestHeader("Content-Type", "application/json");
        xmlhttp.setRequestHeader('ClientId', '9b7f56d730cb292199b7a49620fa80f6');
        xmlhttp.setRequestHeader('ClientSecret', '60812117e31f68b0475960d167a6fc856a09de16cc89f17f8ece51e29f216b15');//in prod, you should encrypt user name and password and provide encrypted keys here instead
        xmlhttp.onreadystatechange = callbackFunction(xmlhttp);
        debugger

        xmlhttp.send(ItemJSON);
       
        var data = JSON.parse(xmlhttp.responseText);

        if (data.responseMessage == "Successfully Completed.") {

            swal({
                title: "Success",
                text: "Aadhar verify successfully",
                icon: "success",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {
                        document.getElementById("hdn_customer_aadhar_verify").value = "Y";
                        $("#myModal").modal("hide");
                    }
                });


        } else {
            swal({
                title: "Error",
                text: data.responseMessage,
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {
                     
                    }
                });



        }
        
        

    }
    
}


function PanVerification() {
    debugger
    var panNumber = $("#PanNo").val();
    var fullName = $("#FName").val() + " " + $("#MName").val() + " " + $("#LName").val();
    var dob = moment($("#Dob").val()).format('DD-MMM-YYYY');


    debugger
    var urlvariable;

    urlvariable = "https://sm-kyc-sandbox.scoreme.in/kyc/external/panverification";

    var ItemJSON;

    ItemJSON = '{"panNumber": "' + panNumber + '","fullName":  "' + fullName + '", "dateOfBirth":  "' + dob + '", "status":  "' + "individual" + '"}';

    debugger
    alert(ItemJSON)
    
    URL = urlvariable;  //Your URL

    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = callbackFunction(xmlhttp);
    xmlhttp.open("POST", URL, false);
    xmlhttp.setRequestHeader("Content-Type", "application/json");
    xmlhttp.setRequestHeader('ClientId', '9b7f56d730cb292199b7a49620fa80f6');
    xmlhttp.setRequestHeader('ClientSecret', '60812117e31f68b0475960d167a6fc856a09de16cc89f17f8ece51e29f216b15');//in prod, you should encrypt user name and password and provide encrypted keys here instead
    xmlhttp.onreadystatechange = callbackFunction(xmlhttp);
    xmlhttp.send(ItemJSON);
    debugger

    var data = JSON.parse(xmlhttp.responseText);

    if (data.responseMessage == "Successfully Submitted.") {
        document.getElementById("referenceId").value = data.data.referenceId;
        swal({
            title: "Success",
            text: data.responseMessage,
            icon: "success",
            button: true,

        })
            .then((willConfirm) => {
                if (willConfirm) {
                    debugger
                    data = JSON.parse(xmlhttp.responseText);
                    var rid = data.data.referenceId;
                    debugger

                    $.ajax({
                        url: "https://sm-kyc-sandbox.scoreme.in/kyc/external/getkycrequestresponse?referenceId=" + rid,
                        type: 'GET',
                        dataType: 'json',
                        headers: {
                            'ClientId': '9b7f56d730cb292199b7a49620fa80f6',
                            'ClientSecret': '60812117e31f68b0475960d167a6fc856a09de16cc89f17f8ece51e29f216b15'
                        },
                        contentType: 'application/json; charset=utf-8',
                        success: function (result) {
                            // CallBack(result);
                            debugger

                            if (data.responseMessage == "Successfully Submitted.") {

                                swal({
                                    title: "Success",
                                    text: "Pan verify successfully",
                                    icon: "success",
                                    button: true,

                                })
                                    .then((willConfirm) => {
                                        if (willConfirm) {
                                            document.getElementById("hdn_customer_aadhar_verify").value = "Y";
                                           
                                        }
                                    });


                            } else {
                                swal({
                                    title: "Error",
                                    text: data.responseMessage,
                                    icon: "error",
                                    button: true,

                                })
                                    .then((willConfirm) => {
                                        if (willConfirm) {

                                        }
                                    });



                            }




                            
                        },
                        error: function (error) {
                            debugger
                            alert(error);
                        }
                    })

                
                    
                    
                   
                }
            });

    } else {
        swal({
            title: "Error",
            text: data.responseMessage,
            icon: "error",
            button: true,

        })
            .then((willConfirm) => {
                if (willConfirm) {

                }
            });
    }
}




$('#MartialStatus').change(function () {
    debugger;

    var MartialStatus = $("#MartialStatus option:selected").val();

    
    if (MartialStatus == "0") {
        document.getElementById("SpouseName").disabled = false;
        document.getElementById("SpouseMobileNumber").disabled = false;
    } else if (MartialStatus == "Single") {
        document.getElementById("SpouseName").disabled = true;
        document.getElementById("SpouseMobileNumber").disabled = true;
    } else if (MartialStatus == "Married") {
        document.getElementById("SpouseName").disabled = false;
        document.getElementById("SpouseMobileNumber").disabled = false;

    }
  

});

function mytest() {
    var yes = document.getElementById("vehicle1").checked;
    if (yes == true) {
        var PresentAddress = $("#PresentAddress").val();
        var PresentPincode = $("#PresentPincode").val();
        var PresentStateId = $("#customerpresentState option:selected").val();
        var PresentCityId = $("#customerpresentcity option:selected").val();

        document.getElementById("PermanentAddress").value = PresentAddress;
        document.getElementById("PermanentPincode").value = PresentPincode;
        document.getElementById("customerpermanentstate").value = PresentStateId;
        var stateid = PresentStateId;
        if (stateid.length == 0) {
            var s = '<option value="">- Select City -</option>'
            $('#customerpermanentcity').html(s);
        } else {
            var s = '<option value="">- Select City -</option>'
            $('#customerpermanentcity').html(s);
            $.ajax({
                url: "/City/GetCity",
                type: "Get",
                /* url: '@Url.Action("GetCity", "City")',*/
                dataType: "json",
                data: {
                    StateId: stateid
                },
                success: function (result) {
                    debugger
                    var data = JSON.parse(result);
                    for (var i = 0; i < data.length; i++) {
                        var opt = new Option(data[i].CityName, data[i].Cityid);
                        $('#customerpermanentcity').append(opt);

                    }
                    document.getElementById("customerpermanentcity").value = PresentCityId;
                }

            });
        }
        document.getElementById("PermanentAddress").disabled = true;
        document.getElementById("PermanentPincode").disabled = true;
        document.getElementById("customerpermanentstate").disabled = true;
        document.getElementById("customerpermanentcity").disabled = true;

    } else {
        document.getElementById("PermanentAddress").value = "";
        document.getElementById("PermanentPincode").value = "";
        document.getElementById("customerpermanentstate").value = "";
        document.getElementById("customerpermanentcity").value = "";
        document.getElementById("PermanentAddress").disabled = false;
        document.getElementById("PermanentPincode").disabled = false;
        document.getElementById("customerpermanentstate").disabled = false;
        document.getElementById("customerpermanentcity").disabled = false;
    }

}
function SetValues() {
    var yes = document.getElementById("vehicle1").checked;
    if (yes == true) {
        var PresentAddress = $("#PresentAddress").val();
        
        document.getElementById("PermanentAddress").value = PresentAddress;
        
        document.getElementById("PermanentAddress").disabled = true;
     
    } else {
        document.getElementById("PermanentAddress").value = "";
        document.getElementById("PermanentAddress").disabled = false;
     
    }

}
function SetValues1() {
    var yes = document.getElementById("vehicle1").checked;
    if (yes == true) {
        var PresentPincode = $("#PresentPincode").val();

        document.getElementById("PermanentPincode").value = PresentPincode;

        document.getElementById("PermanentPincode").disabled = true;

    } else {
        document.getElementById("PermanentPincode").value = "";
        document.getElementById("PermanentPincode").disabled = false;

    }

}
function SetValues2() {
    var yes = document.getElementById("vehicle1").checked;
    if (yes == true) {
        var PresentStateId = $("#customerpresentState option:selected").val();
        document.getElementById("customerpermanentstate").value = PresentStateId;
        document.getElementById("customerpermanentstate").disabled = true;

    } else {
        document.getElementById("customerpermanentstate").value = "";
        document.getElementById("customerpermanentstate").disabled = false;

    }

}
function SetValues3() {
    debugger
    var yes = document.getElementById("vehicle1").checked;
    if (yes == true) {
        var PresentStateId = $("#customerpresentState option:selected").val();
        var PresentCityId = $("#customerpresentcity option:selected").val();
        var stateid = PresentStateId;
        if (stateid.length == 0) {
            var s = '<option value="">- Select City -</option>'
            $('#customerpermanentcity').html(s);
        } else {
            var s = '<option value="">- Select City -</option>'
            $('#customerpermanentcity').html(s);
            $.ajax({
                url: "/City/GetCity",
                type: "Get",
                /* url: '@Url.Action("GetCity", "City")',*/
                dataType: "json",
                data: {
                    StateId: stateid
                },
                success: function (result) {
                    debugger
                    var data = JSON.parse(result);
                    for (var i = 0; i < data.length; i++) {
                        var opt = new Option(data[i].CityName, data[i].Cityid);
                        $('#customerpermanentcity').append(opt);

                    }
                    document.getElementById("customerpermanentcity").value = PresentCityId;
                    document.getElementById("customerpermanentcity").disabled = true;
                }

            });
        }

    } else {
        document.getElementById("customerpermanentcity").value = "";
        document.getElementById("customerpermanentcity").disabled = false;

    }

}






function Co_Applicantpermascorr() {
    var yes = document.getElementById("co_chlpercorr").checked;
    if (yes == true) {
        var PresentAddress = $("#CO_PresentAddress").val();
        var PresentPincode = $("#CO_PresentPincode").val();
        var PresentStateId = $("#Co_State option:selected").val();
        var PresentCityId = $("#CO_City option:selected").val();

        document.getElementById("CO_PermanentAddress").value = PresentAddress;
        document.getElementById("CO_PermanentPincode").value = PresentPincode;
        document.getElementById("CO_permanentstate").value = PresentStateId;
        var stateid = PresentStateId;
        if (stateid.length == 0) {
            var s = '<option value="">- Select City -</option>'
            $('#CO_permanentcity').html(s);
        } else {
            var s = '<option value="">- Select City -</option>'
            $('#CO_permanentcity').html(s);
            $.ajax({
                url: "/City/GetCity",
                type: "Get",
                /* url: '@Url.Action("GetCity", "City")',*/
                dataType: "json",
                data: {
                    StateId: stateid
                },
                success: function (result) {
                    debugger
                    var data = JSON.parse(result);
                    for (var i = 0; i < data.length; i++) {
                        var opt = new Option(data[i].CityName, data[i].Cityid);
                        $('#CO_permanentcity').append(opt);

                    }
                    document.getElementById("CO_permanentcity").value = PresentCityId;
                }

            });
        }
        document.getElementById("CO_PermanentAddress").disabled = true;
        document.getElementById("CO_PermanentPincode").disabled = true;
        document.getElementById("CO_permanentstate").disabled = true;
        document.getElementById("CO_permanentcity").disabled = true;

    } else {
        document.getElementById("CO_PermanentAddress").value = "";
        document.getElementById("CO_PermanentPincode").value = "";
        document.getElementById("CO_permanentstate").value = "";
        document.getElementById("CO_permanentcity").value = "";
        document.getElementById("CO_PermanentAddress").disabled = false;
        document.getElementById("CO_PermanentPincode").disabled = false;
        document.getElementById("CO_permanentstate").disabled = false;
        document.getElementById("CO_permanentcity").disabled = false;
    }

}
function SetValues_CO() {
    var yes = document.getElementById("co_chlpercorr").checked;
    if (yes == true) {
        var PresentAddress = $("#CO_PresentAddress").val();

        document.getElementById("CO_PermanentAddress").value = PresentAddress;

        document.getElementById("CO_PermanentAddress").disabled = true;

    } else {
        document.getElementById("CO_PermanentAddress").value = "";
        document.getElementById("CO_PermanentAddress").disabled = false;

    }

}
function SetValues1_CO() {
    var yes = document.getElementById("co_chlpercorr").checked;
    if (yes == true) {
        var PresentPincode = $("#CO_PresentPincode").val();

        document.getElementById("CO_PermanentPincode").value = PresentPincode;

        document.getElementById("CO_PermanentPincode").disabled = true;

    } else {
        document.getElementById("CO_PermanentPincode").value = "";
        document.getElementById("CO_PermanentPincode").disabled = false;

    }

}
function SetValues2_CO() {
    var yes = document.getElementById("co_chlpercorr").checked;
    if (yes == true) {
        var PresentStateId = $("#Co_State option:selected").val();
        document.getElementById("CO_permanentstate").value = PresentStateId;
        document.getElementById("CO_permanentstate").disabled = true;

    } else {
        document.getElementById("CO_permanentstate").value = "";
        document.getElementById("CO_permanentstate").disabled = false;

    }

}
function SetValues3_CO() {
    debugger
    var yes = document.getElementById("co_chlpercorr").checked;
    if (yes == true) {
        var PresentStateId = $("#Co_State option:selected").val();
        var PresentCityId = $("#CO_City option:selected").val();
        var stateid = PresentStateId;
        if (stateid.length == 0) {
            var s = '<option value="">- Select City -</option>'
            $('#CO_permanentcity').html(s);
        } else {
            var s = '<option value="">- Select City -</option>'
            $('#CO_permanentcity').html(s);
            $.ajax({
                url: "/City/GetCity",
                type: "Get",
                /* url: '@Url.Action("GetCity", "City")',*/
                dataType: "json",
                data: {
                    StateId: stateid
                },
                success: function (result) {
                    debugger
                    var data = JSON.parse(result);
                    for (var i = 0; i < data.length; i++) {
                        var opt = new Option(data[i].CityName, data[i].Cityid);
                        $('#CO_permanentcity').append(opt);

                    }
                    document.getElementById("CO_permanentcity").value = PresentCityId;
                    document.getElementById("CO_permanentcity").disabled = true;
                }

            });
        }

    } else {
        document.getElementById("CO_permanentcity").value = "";
        document.getElementById("CO_permanentcity").disabled = false;

    }

}









function G_Applicantpermascorr() {
    var yes = document.getElementById("G_chlpercorr").checked;
    if (yes == true) {
        var PresentAddress = $("#G_PresentAddress").val();
        var PresentPincode = $("#G_PresentPincode").val();
        var PresentStateId = $("#G_C_State option:selected").val();
        var PresentCityId = $("#G_C_City option:selected").val();

        document.getElementById("G_PermanentAddress").value = PresentAddress;
        document.getElementById("G_PermanentPincode").value = PresentPincode;
        document.getElementById("G_P_State").value = PresentStateId;
        var stateid = PresentStateId;
        if (stateid.length == 0) {
            var s = '<option value="">- Select City -</option>'
            $('#G_P_City').html(s);
        } else {
            var s = '<option value="">- Select City -</option>'
            $('#G_P_City').html(s);
            $.ajax({
                url: "/City/GetCity",
                type: "Get",
                /* url: '@Url.Action("GetCity", "City")',*/
                dataType: "json",
                data: {
                    StateId: stateid
                },
                success: function (result) {
                    debugger
                    var data = JSON.parse(result);
                    for (var i = 0; i < data.length; i++) {
                        var opt = new Option(data[i].CityName, data[i].Cityid);
                        $('#G_P_City').append(opt);

                    }
                    document.getElementById("G_P_City").value = PresentCityId;
                }

            });
        }
        document.getElementById("G_PermanentAddress").disabled = true;
        document.getElementById("G_PermanentPincode").disabled = true;
        document.getElementById("G_P_State").disabled = true;
        document.getElementById("G_P_City").disabled = true;

    } else {
        document.getElementById("G_PermanentAddress").value = "";
        document.getElementById("G_PermanentPincode").value = "";
        document.getElementById("G_P_State").value = "";
        document.getElementById("G_P_City").value = "";
        document.getElementById("G_PermanentAddress").disabled = false;
        document.getElementById("G_PermanentPincode").disabled = false;
        document.getElementById("G_P_State").disabled = false;
        document.getElementById("G_P_City").disabled = false;
    }

}
function SetValues_G() {
    var yes = document.getElementById("G_chlpercorr").checked;
    if (yes == true) {
        var PresentAddress = $("#G_PresentAddress").val();

        document.getElementById("G_PermanentAddress").value = PresentAddress;

        document.getElementById("G_PermanentAddress").disabled = true;

    } else {
        document.getElementById("G_PermanentAddress").value = "";
        document.getElementById("G_PermanentAddress").disabled = false;

    }

}
function SetValues1_G() {
    var yes = document.getElementById("G_chlpercorr").checked;
    if (yes == true) {
        var PresentPincode = $("#G_PresentPincode").val();

        document.getElementById("G_PermanentPincode").value = PresentPincode;

        document.getElementById("G_PermanentPincode").disabled = true;

    } else {
        document.getElementById("G_PermanentPincode").value = "";
        document.getElementById("G_PermanentPincode").disabled = false;

    }

}
function SetValues2_G() {
    var yes = document.getElementById("G_chlpercorr").checked;
    if (yes == true) {
        var PresentStateId = $("#G_C_State option:selected").val();
        document.getElementById("G_P_State").value = PresentStateId;
        document.getElementById("G_P_State").disabled = true;

    } else {
        document.getElementById("G_P_State").value = "";
        document.getElementById("G_P_State").disabled = false;

    }

}
function SetValues3_G() {
    debugger
    var yes = document.getElementById("G_chlpercorr").checked;
    if (yes == true) {
        var PresentStateId = $("#G_C_State option:selected").val();
        var PresentCityId = $("#G_C_City option:selected").val();
        var stateid = PresentStateId;
        if (stateid.length == 0) {
            var s = '<option value="">- Select City -</option>'
            $('#G_P_City').html(s);
        } else {
            var s = '<option value="">- Select City -</option>'
            $('#G_P_City').html(s);
            $.ajax({
                url: "/City/GetCity",
                type: "Get",
                /* url: '@Url.Action("GetCity", "City")',*/
                dataType: "json",
                data: {
                    StateId: stateid
                },
                success: function (result) {
                    debugger
                    var data = JSON.parse(result);
                    for (var i = 0; i < data.length; i++) {
                        var opt = new Option(data[i].CityName, data[i].Cityid);
                        $('#G_P_City').append(opt);

                    }
                    document.getElementById("G_P_City").value = PresentCityId;
                    document.getElementById("G_P_City").disabled = true;
                }

            });
        }

    } else {
        document.getElementById("G_P_City").value = "";
        document.getElementById("G_P_City").disabled = false;

    }

}