
function Validation() {
    var ReqType = "Check";
    var Uname = $("#txtUserName").val();
    var Pass = $("#txtPassword").val();
    $("#txtUserName").val("");
    $("#txtPassword").val("");
    if (Uname.length == 0) {
        swal("TDH", "Please Enter User Name","error");
    } else if (Pass.length == 0) {
        swal("TDH", "Please Enter Password", "error");
    } 
     else {
        var filedata = new FormData();

        var UserName = Uname;
        var UserPassword = Pass;
        
        var AllDataArray = {
            "ReqType": ReqType,
            "UserName": UserName,
            "UserPassword": UserPassword
        }

        filedata.append('AllDataArray', JSON.stringify(AllDataArray));

        $.ajax({
            url: "/Login/ChecKLogin",
            type: "POST",
            contentType: false,
            processData: false,
            data: filedata,

            success: function (result) {
                if (result.length > 2) {
                    debugger
                    ReqType = "Update";
                    var UserID = JSON.parse(result)[0].UserID;
                    var Type = JSON.parse(result)[0].Type;
                    var RefID = JSON.parse(result)[0].RefID;

                    if (UserID != "") {
                        var LoginDetails = {
                            "ReqType": ReqType,
                            "Type": Type,
                            "UserID": UserID,
                            "RefID": RefID
                        }
                        filedata.append('LoginDetails', JSON.stringify(LoginDetails));
                        $.ajax({
                            url: "/Login/UpdateLogin",
                            type: "POST",
                            contentType: false,
                            processData: false,
                            data: filedata,
                            success: function (result) {
                                debugger
                                var msgdata = JSON.parse(result.Data).Msg;
                                if (msgdata == "Success") {

                                    swal({
                                        title: "Success",
                                        text: "Login Successfully",
                                        icon: "success",
                                        button: true,

                                    })
                                        .then((willConfirm) => {
                                            if (willConfirm) {
                                                window.location.pathname = 'Home/Index';

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
                else {
                    swal("TDH", "Please Enter Coorect UserId and Password", "error");
                }

            }



        })



    }

}