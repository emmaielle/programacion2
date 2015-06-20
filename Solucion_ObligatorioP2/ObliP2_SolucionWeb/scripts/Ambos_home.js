function validMail() {
    mail = $("#ContentPlaceHolder1_txt_homes_Mail").val();
    valid_summary = $("#ContentPlaceHolder1_valid_summary_registro");
    exp = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i

    retorno = false;

    if (mail != "") {
        if (exp.test(mail)) {
            retorno = true;
        }
        else {
            valid_summary.show();
            valid_summary.text("El mail no tiene el formato correcto");
        }
    }
    else {
        valid_summary.show();
        valid_summary.text("Debes completar los campos señalados");
    }

    return retorno;

}
