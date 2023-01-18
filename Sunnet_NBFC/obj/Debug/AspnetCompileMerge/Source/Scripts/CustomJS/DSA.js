
$('#DSAState').change(function () {
    debugger;
    /*alert("a");*/
    var stateid = $("#DSAState option:selected").val();
    if (stateid.length == 0) {
    } else {
        var s = '<option value="">- Select City -</option>'
        $('#DSACity').html(s);
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
                    $('#DSACity').append(opt);

                }
            }
          

        });
    }
});

