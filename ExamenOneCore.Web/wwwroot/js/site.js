$(document).ready(function () {
    $("#div_ShowNotification").hide();
});
function ShowNotification(pantalla, error, message, successCallback, errorCallback) {
    if (error == true) {
        $('.alert-autocloseable-danger').html(message);
        $('.alert-autocloseable-danger').slideDown(800, function () {
            $("#alert_Success" + pantalla).hide();
            $("#alert_Error" + pantalla).show();
        });
        $('.alert-autocloseable-danger').delay(4000).slideUp("slow");
    } else {
        $('.alert-autocloseable-success').html(message);
        $('.alert-autocloseable-success').slideDown(800, function () {
            $("#alert_Success" + pantalla).show();
            $("#alert_Error" + pantalla).hide();
            successCallback();
        });
        $('.alert-autocloseable-success').delay(4000).slideUp("slow");
    }
    $("#div_ShowNotification" + pantalla).show();
}
