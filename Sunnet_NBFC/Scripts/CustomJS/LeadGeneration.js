/$('#MainProductId').change(function () {
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
    var AadharNo = $("#AadharNo").val();
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
    var CO_PresentStateId = $("#CO_PresentStateId option:selected").val();
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

    if (hdn_type == "b") {
        if (FName.length == 0) {
            
            swal({
                title: "Error",
                text: "Please enter first name",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });

        } else if (MName.length == 0) {
           
            swal({
                title: "Error",
                text: "Please enter middle name",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });

        } else if (LName.length == 0) {
            
            swal({
                title: "Error",
                text: "Please enter lastt name",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });
        } else if (FatherName.length == 0) {
           
            swal({
                title: "Error",
                text: "Please enter father name",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });
        } else if (MotherName.length == 0) {
            
            swal({
                title: "Error",
                text: "Please enter mother name",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });
        } else if (SpouseName.length == 0) {
            
            swal({
                title: "Error",
                text: "Please enter spouse name",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });
        } else if (Dob.length == 0) {
           
            swal({
                title: "Error",
                text: "Please enter dob",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });
        } else if (underAgeValidate(Dob) < 18) {

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

        }  else if (MartialStatus.length == 0) {
            
            swal({
                title: "Error",
                text: "Please enter material status",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });
        } else if (PresentAddress.length == 0) {
            
            swal({
                title: "Error",
                text: "Please enter present address",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });
        } else if (PresentPincode.length == 0) {
           
            swal({
                title: "Error",
                text: "Please enter present pincode",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });
        } else if (PresentPincode.length != 6) {

            swal({
                title: "Error",
                text: "Invalid pincode",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });
        } else if (PermanentAddress.length == 0) {
           
            swal({
                title: "Error",
                text: "Please enter permanent address",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });
        } else if (PermanentPincode.length == 0) {
           
            swal({
                title: "Error",
                text: "Please enter permanent pincode",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });
        } else if (PermanentPincode.length != 6) {

            swal({
                title: "Error",
                text: "Invalid pincode",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });
        } else if (CibilScore.length == 0) {
           
            swal({
                title: "Error",
                text: "Please enter cibil score",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });
        } else if (MobileNumber1.length == 0) {
           
            swal({
                title: "Error",
                text: "Please enter mobile number",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });
        } else if (FatherMobileNumber.length == 0) {
           
            swal({
                title: "Error",
                text: "Please enter father mobile number",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });
        } else if (MotherMobileNumber.length == 0) {
            
            swal({
                title: "Error",
                text: "Please enter mother mobile number",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });
        } else if (SpouseMobileNumber.length == 0) {
           
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
        } else if (AadharNo.length == 0) {
            swal({
                title: "Error",
                text: "Please enter aadhar no",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });
        } else if (AadharNo.length != 12) {
            swal({
                title: "Error",
                text: "Invalid aadhar no",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });
        } else if (PanNo.length == 0) {
          
            swal({
                title: "Error",
                text: "Please enter pan no",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });

        } else if (PanNo.length != 10) {
           
            swal({
                title: "Error",
                text: "Invalid pan no",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });

        } else if (CO_FName.length == 0) {
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

        } else if (CO_MName.length == 0) {

            swal({
                title: "Error",
                text: "Please enter co applicant middle name",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });
        } else if (CO_LName.length == 0) {

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
            
            
           
            
            
        } else if (CO_Gender.length == 0) {

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

        } else if (CO_Dob.length == 0) {

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

        } else if (underAgeValidate(CO_DOB) < 18) {

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

        } else if (CO_MartialStatus.length == 0) {

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
            

        } else if (CO_PresentAddress.length == 0) {

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

        } else if (CO_PresentPincode.length == 0) {

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

        } else if (CO_PresentPincode.length != 6) {

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
        } else if (CO_PresentStateId.length == 0) {
               

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


        } else if (CO_City.length == 0) {

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


        } else if (CO_PermanentAddress.length == 0) {
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


        } else if (CO_PermanentPincode.length == 0) {

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


        } else if (CO_PermanentPincode.length != 6) {

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
        } else if (CO_permanentstate.length == 0) {
           
            

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



        } else if (CO_permanentcity.length == 0) {

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



        } else if (CO_MObileNO.length == 0) {

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



        } else if (CO_EmailId.length == 0) {

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





        } else if (CO_PanNo.length != 10) {

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





        } else if (!PANregex.test(CO_PanNo)) {

            swal({
                title: "Error",
                text: "Invalid PAN pan no",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });




        } else if (CO_AadharNo.length != 12) {

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



        } else if (CO_CibilScore.length == 0) {

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



        }else if (customers.length != 0) {
            alert("Please enter gurantor details");
        }else {

            
            
            $("#example1 TBODY TR").each(function () {
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
                if (customer.G_FirstName != "No data available in table") {
                    customers.push(customer);
                }
            });
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
        }


    }else if (hdn_type == "c") {
        if (FName.length == 0) {
            alert("Please enter first name");
        } else if (MName.length == 0) {
            alert("Please enter middle name");
        } else if (LName.length == 0) {
            alert("Please enter last name");
        } else if (FatherName.length == 0) {
            alert("Please enter father name");
        } else if (MotherName.length == 0) {
            alert("Please enter mother name");
        } else if (SpouseName.length == 0) {
            alert("Please enter spouse name");
        } else if (Dob.length == 0) {
            alert("Please enter Dob");
        } else if (MartialStatus.length == 0) {
            alert("Please enter material status");
        } else if (PresentAddress.length == 0) {
            alert("Please enter present address");
        } else if (PresentPincode.length == 0) {
            alert("Please enter present pincode");
        } else if (PermanentAddress.length == 0) {
            alert("Please enter permanent address");
        } else if (PermanentPincode.length == 0) {
            alert("Please enter permanent pincode");
        } else if (CibilScore.length == 0) {
            alert("Please enter cibil score");
        } else if (MobileNumber1.length == 0) {
            alert("Please enter mobile number1");
        } else if (FatherMobileNumber.length == 0) {
            alert("Please enter father mobile number");
        } else if (MotherMobileNumber.length == 0) {
            alert("Please enter mother mobile number");
        } else if (SpouseMobileNumber.length == 0) {
            alert("Please enter spouse mobile number");
        } else if (AadharNo.length == 0) {
            alert("Please enter Aadhar no");
        } else if (AadharNo.length != 12) {
            alert("Please enter valid aadhar no");
        } else if (PanNo.length == 0) {
            alert("Please enter Pan no");
        } else if (PanNo.length != 10) {
            alert("Please enter valid pan no");
        } else if (CO_FName.length == 0) {
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

        } else if (CO_MName.length == 0) {

            swal({
                title: "Error",
                text: "Please enter co applicant middle name",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });
        } else if (CO_LName.length == 0) {

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





        } else if (CO_Gender.length == 0) {

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

        } else if (CO_Dob.length == 0) {

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

        } else if (underAgeValidate(CO_DOB) < 18) {

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

        } else if (CO_MartialStatus.length == 0) {

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


        } else if (CO_PresentAddress.length == 0) {

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

        } else if (CO_PresentPincode.length == 0) {

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

        } else if (CO_PresentStateId.length == 0) {


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


        } else if (CO_City.length == 0) {

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


        } else if (CO_PermanentAddress.length == 0) {
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


        } else if (CO_PermanentPincode.length == 0) {

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


        } else if (CO_permanentstate.length == 0) {



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



        } else if (CO_permanentcity.length == 0) {

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



        } else if (CO_MObileNO.length == 0) {

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



        } else if (CO_EmailId.length == 0) {

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





        } else if (CO_PanNo.length != 10) {

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





        } else if (!PANregex.test(CO_PanNo)) {

            swal({
                title: "Error",
                text: "Invalid PAN pan no",
                icon: "error",
                button: true,

            })
                .then((willConfirm) => {
                    if (willConfirm) {

                    }
                });




        } else if (CO_AadharNo.length != 12) {

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



        } else if (CO_CibilScore.length == 0) {

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



        }else {
                      
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
        }


    } else if (hdn_type == "g") {
        $("#example1 TBODY TR").each(function () {
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
            if (customer.G_FirstName != "No data available in table") {
                customers.push(customer);
            }
        });
        if (FName.length == 0) {
            alert("Please enter first name");
        } else if (MName.length == 0) {
            alert("Please enter middle name");
        } else if (LName.length == 0) {
            alert("Please enter last name");
        } else if (FatherName.length == 0) {
            alert("Please enter father name");
        } else if (MotherName.length == 0) {
            alert("Please enter mother name");
        } else if (SpouseName.length == 0) {
            alert("Please enter spouse name");
        } else if (Dob.length == 0) {
            alert("Please enter Dob");
        } else if (MartialStatus.length == 0) {
            alert("Please enter material status");
        } else if (PresentAddress.length == 0) {
            alert("Please enter present address");
        } else if (PresentPincode.length == 0) {
            alert("Please enter present pincode");
        } else if (PermanentAddress.length == 0) {
            alert("Please enter permanent address");
        } else if (PermanentPincode.length == 0) {
            alert("Please enter permanent pincode");
        } else if (CibilScore.length == 0) {
            alert("Please enter cibil score");
        } else if (MobileNumber1.length == 0) {
            alert("Please enter mobile number1");
        } else if (FatherMobileNumber.length == 0) {
            alert("Please enter father mobile number");
        } else if (MotherMobileNumber.length == 0) {
            alert("Please enter mother mobile number");
        } else if (SpouseMobileNumber.length == 0) {
            alert("Please enter spouse mobile number");
        } else if (AadharNo.length == 0) {
            alert("Please enter Aadhar no");
        } else if (AadharNo.length != 12) {
            alert("Please enter valid aadhar no");
        } else if (PanNo.length == 0) {
            alert("Please enter Pan no");
        } else if (PanNo.length != 10) {
            alert("Please enter valid pan no");
        } else if (customers.length != 0) {
            alert("Please enter gurantor details");
        } else {

         
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
        }


    }
    debugger
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