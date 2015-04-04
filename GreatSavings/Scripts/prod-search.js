$(document).ready(function () {

    $("#txtDaysRange").slider().on('slideStop', function (e) {
        var $this = $(this);
        var values = JSON.parse(JSON.stringify($this.data('slider').getValue()));
        $('#start_range').val(values[0]);
        $('#end_range').val(values[1]);
    });


});