$('#State').change(function () {
    debugger;

    var stateid = $("#State option:selected").val();
    if (stateid.length == 0) {
    } else {
        var s = '<option value="">- Select City -</option>'
        $('#City').html(s);
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
                    $('#City').append(opt);

                }
            }
          

        });
    }
});

function Validation() {
    var regex = /^[a-zA-Z]*$/;
    var ReqType = "Insert";
    var Name = $("#Name").val();
    var Address = $("#Address").val();
    var City = $("#City").val();
    var State = $("#State").val();
    var Country = $("#Country").val();
    var Pincode = $("#Pincode").val();
    var PANNo = $("#PANNo").val();
    var GSTNo = $("#GSTNo").val();
    var CompanyType = $("#CompanyType").val();
    var CompanyDesc = $("#CompanyDesc").val();
    var CompanyOthDesc = $("#CompanyOthDesc").val();
    var PANregex = /[A-Z]{5}[0-9]{4}[A-Z]{1}$/;
    var GSTreggst = /^([0-9]){2}([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}([0-9]){1}([a-zA-Z]){1}([0-9]){1}?$/;
    var CompanyID = 1;
    var name = "";
  
    var fileUpload = $("#fileuploadapprovalmail").get(0);
    var files = fileUpload.files;
    for (var i = 0; i < files.length; i++) {
        
        var name = files[i].name;

    }
    if (Name.length == 0) {
        alert("Please enter company name");

    } else if (CompanyType.length == 0) {
        alert("Please enter company type");

    }  else if (Address.length == 0) {
        alert("Please enter address");

    } else if (PANNo.length == 0) {
        alert("Please enter PAN No.");

    } else if (!PANregex.test(PANNo)) {
        alert("Invalid PAN No.");

    } else if (GSTNo.length == 0) {
        alert("Please enter gstno");

    } else if (Country.length == 0) {
        alert("Please enter country");

    } else if (State.length == 0) {
        alert("Please enter state");

    } else if (City.length == 0) {
        alert("Please enter city");

    } else if (Pincode.length == 0) {
        alert("Please enter pincode");

    }  else if (CompanyDesc.length == 0) {
        alert("Please enter CompanyDesc");

    } else if (CompanyOthDesc.length == 0) {
        alert("Please enter CompanyOthDesc");

    } else {

        var filedata = new FormData();
        debugger
        for (var i = 0; i < files.length; i++) {

            filedata.append('LOGO', files[i]);
        }


        var AllDataArray = {
            "ReqType": ReqType,
            "CompanyName": Name,
            "Address": Address,
            "City": City,
            "State": State,
            "Country": Country,
            "Pincode": Pincode,
            "PANNo": PANNo,
            "GSTNo": GSTNo,
            "CompanyType": CompanyType,
            "CompanyDesc": CompanyDesc,
            "CompanyOthDesc": CompanyOthDesc,
            "CompanyId": CompanyID,
            "LOGO": name
        }
      
        filedata.append('AllDataArray', JSON.stringify(AllDataArray));

        $.ajax({
            url: "/Company/AddRequestCompany",
            type: "POST",
            contentType: false,
            processData: false,
            data: filedata,

            success: function (result) {
                debugger

                var message = JSON.parse(result)[0].ReturnMessage;
                alert(message);
                if (message == "Record saved succussfully") {

                    window.location.href = '@Url.Action("StatusView", "Status")'

                } else {


                }




            }



        })



    }

}
