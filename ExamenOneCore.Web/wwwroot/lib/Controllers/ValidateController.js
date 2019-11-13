function VerificaUsuario(controller,pantalla) {
    $.ajax({
        type: 'GET',
        url: controller + 'VerificaUsuario?username=' + $("#Username").val() + '&userid=' + $("#UserId").val(),
        processData: false,
        contentType: false,
        success: function (data) {
            if (data.returnCode == 200) {
                if (data.message == '"Usuario disponible"') {
                    ShowNotification(pantalla, false, data.message, function () { });
                } else {
                    ShowNotification(pantalla, true, data.message, function () { });
                }
            } else {
                ShowNotification(pantalla,true, data.message, function () {});
            }
        },
        error: function (jqXHR, error, errorThrown) {
            ShowNotification(pantalla,true, error.message, function () {});
        }
    });
}

function VerificaEmail(controller,pantalla) {
    $.ajax({
        type: 'GET',
        url: controller + 'VerificaEmail?email=' + $("#Email").val() + '&userid=' + $("#UserId").val(),
        processData: false,
        contentType: false,
        success: function (data) {
            if (data.returnCode == 200) {
                if (data.message == '"Correo electrónico disponible"') {
                    ShowNotification(pantalla, false, data.message, function () { });
                } else {
                    ShowNotification(pantalla, true, data.message, function () { });
                }
            } else {
                ShowNotification(pantalla,true, data.message, function () {});
            }
        },
        error: function (jqXHR, error, errorThrown) {
            ShowNotification(pantalla,true, error.message, function () {});
        }
    });
}
