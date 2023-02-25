
$('#EmpID').change(function () {
    //debugger;
    /*alert("a");*/
    var empid = $("#EmpID option:selected").val();
    if (empid.length == 0) {
    } else {
        //var s = '<option value="">- Select City -</option>'
        //$('#CityID').html(s);
        $.ajax({
            url: "/Employee/GetEmpdtl",
            type: "Get",
            /* url: '@Url.Action("GetCity", "City")',*/
            dataType: "json",
            data: {
                EmpId: empid
            },
            success: function (result) {
                //debugger
                var data = JSON.parse(result);
                //for (var i = 0; i < data.length; i++) {
                //    var opt = new Option(data[i].CityName, data[i].Cityid);
                //    $('#CityID').append(opt);
                //}
                $('#EmpCode').val(data[0].EmpCode);
                $('#EmpName').val(data[0].EmpName);
            }
            //var data = JSON.parse(result.Data);
            // var s = '<option value="">- Select City -</option>';
            // for (var i = 0; i < data.length; i++) {
            //     s += '<option value="' + data[i].Cityid + '">' + data[i].CityName + '</option>';
            // }
            // $("#DSACity").html(s);

        });
    }
});

function callfillemp() {
    var empid = $("#EmpID option:selected").val();
    if (empid.length == 0) {
    } else {
        //var s = '<option value="">- Select City -</option>'
        //$('#CityID').html(s);
        $.ajax({
            url: "/Employee/GetEmpdtl",
            type: "Get",
            /* url: '@Url.Action("GetCity", "City")',*/
            dataType: "json",
            data: {
                EmpId: empid
            },
            success: function (result) {
                //debugger
                var data = JSON.parse(result);
                $('#EmpCode').val(data[0].EmpCode);
                $('#EmpName').val(data[0].EmpName);
            }
        });
    }
}
function SubmitData() {
    debugger;
    //Loop through the Table rows and build a JSON array.
    var customers = new Array();
    var table = document.getElementById("example1");
    var rows = table.getElementsByTagName("INPUT");
    var rowCount = $("#example1 tr").length;
    
    for (var i = 1; i < rowCount; i++) {
        debugger
        var currentRow = rowCount[i];
        var Menuid = table.rows[i].cells[1].getElementsByTagName('input')[0].value;
        var SubMenuid = table.rows[i].cells[2].getElementsByTagName('input')[0].value;
        var IsSelected = table.rows[i].cells[3].getElementsByTagName('input')[0].checked;
        console.log('MenuId' + Menuid);
        console.log('SubMenuid' + SubMenuid);
        console.log("Selected" + IsSelected);
    }

    $("#example1 TBODY TR").each(function () {
        var row = $(this);
        alert(row);
        var customers = {};
        var id = row.find("input[name='hfMenuId']").val();
        alert(id);
        customers.MenuId = row.find("TD").eq(0).html();
        customers.SubMenuId = row.find("TD").eq(1).html();
        /*customers.push(customers);*/
    });
    console.log(Role);
    //Send the JSON array to Controller using AJAX.
    $.ajax({
        type: "POST",
        url: "/Home/InsertCustomers",
        data: JSON.stringify(customers),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            alert(r + " record(s) inserted.");
        }
    });
}
