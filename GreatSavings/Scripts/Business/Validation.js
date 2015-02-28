$(document).ready(function () {
    $('.timepicker').timepicker();
    $('#expiryDatePicker').datepicker();


    // Events for time picker
    $('#start_time').timepicker().on('changeTime.timepicker', function (e) {
        $('#StartTime').val(e.time.value);
    });

    $('#end_time').timepicker().on('changeTime.timepicker', function (e) {
        $('#EndTime').val(e.time.value);
    });

    // Events for date picker
    $("#expiryDatePicker").on("dp.change", function (e) {
        $('#ExpiryDate').data("DateTimePicker").getDate();
    });

    $('#confirmPwd').bind('blur', function () {
        var merchantPwd = $("input[name='Merchant.Password']").val();
        if (merchantPwd != $(this).val()) {
            $("#confirmPwdError").show();
        }
    });
});
