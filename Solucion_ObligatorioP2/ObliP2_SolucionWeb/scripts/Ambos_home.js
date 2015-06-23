function validMail() {
    mail = $("#ContentPlaceHolder1_txt_homes_Mail").val();
    nroPuerta = $("#ContentPlaceHolder1_txt_nroPt_homes").val();
    telefono = $("#ContentPlaceHolder1_txt_homes_tel").val();

    valid_summary = $("#ContentPlaceHolder1_valid_summary_registro");
    exp = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i

    retorno = false;

    if ($(":text").val().trim() != "" && $(":password").val().trim() != "") {
        if (!exp.test(mail)) {
            valid_summary.show();
            valid_summary.text("El mail no tiene el formato correcto");
        }
        else if (isNaN(nroPuerta)) {
            valid_summary.show();
            valid_summary.text("El número de puerta debe contener sólo números");
        }
        else if (isNaN(telefono)) {
            valid_summary.show();
            valid_summary.text("El teléfono debe contener sólo números");
        }
        else {
            retorno = true;
        }
    }
    else {
        valid_summary.show();
        valid_summary.text("Debes completar los campos señalados");
    }

    return retorno;

}
