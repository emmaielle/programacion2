function validarCampos() {
    doc = $("#ContentPlaceHolder1_txt_crearAdmin_doc").val();
    tel = $("#ContentPlaceHolder1_txt_crearAdmin_telefono").val();
    nroPuerta = $("#ContentPlaceHolder1_txt_crearAdmin_numero").val();
    passwd = $("#ContentPlaceHolder1_txt_crearAdmin_password").val();
    mail = $("#ContentPlaceHolder1_txt_crearAdmin_mail").val();

    mensajes = $("#ContentPlaceHolder1_p_crearAdmin_mensajes");

    retorno = false;

    if ($(":text").val() != "" && $(":password").val() != ""){
        if (isNaN(doc)) {
            mensajes.text("El documento debe ser un número");
        }
        else if (isNaN(tel)) {
            mensajes.text("El teléfono debe ser un número");
        }
        else if (isNaN(nroPuerta)) {
            mensajes.text("El número de puerta debe tener sólo numeros");
        }
        else if (passwd.length < 6) {
            mensajes.text("La contraseña debe tener 6 o más caracteres");
        }
        else if (!esMail(mail)) {
            mensajes.text("El mail debe tener el formato correcto");
        }
        else retorno = true;
    
    }
    else mensajes.text("Todos los campos son obligatorios");


    return retorno;
}


function esMail(pMail) {
    exp = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i

    return exp.test(pMail);
}