
function validarNumerosyRangos() {
    ci = $("#txt_registro_CI").val();
    tel = $("#txt_registro_tel").val();
    puerta = $("#txt_nroPt_registro").val();
    password = $("#txt_registro_passwd").val();
    mail = $("#txt_registro_mail").val();

    p_mensaje = $("#p_registro_message");
    p_mensaje.text("");

    retorno = false;

    if ($(":text").val() != "" && $(":password").val() !="") {
        if (isNaN(ci)) {
            p_mensaje.text("El documento debe tener sólo números");
        }
        else if (isNaN(tel)) {
            p_mensaje.text("El teléfono debe de tener sólo números");
        }
        else if (isNaN(puerta)) {
            p_mensaje.text("El número de puerta debe tener sólo números");
        }
        else if (password.length < 6) {
            p_mensaje.text("La contraseña debe tener un mínimo de 6 caracteres");
        }
        else if (!validarMail(mail)) {
            p_mensaje.text("El mail debe estar en el formato correcto");
        }
        else {
            retorno = true;
        }
    }
    else {
        p_mensaje.text("Todos los campos deben ser completados");
    }

    return retorno;
}

function validarMail(pMail) {
    exp = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i

    return exp.test(pMail);
};