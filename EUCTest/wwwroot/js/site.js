
//Nastavení datumu natození
$('#IdentityNumber').on('change', function () {

    var value = this.value;
    if (value.length > 5 && value.substring(0, 6).match(/^[0-9]+$/) != null) {

        $('#txtDate').datepicker('setDate', new Date(19 + value.substring(0, 2), (value.substring(2, 4) - 1), value.substring(4, 6)));
    }
});



