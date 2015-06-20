function validarTxt() {
    errorMsj = $("#ContentPlaceHolder1_p_rastrearEnvio_error");
    valTxtbox = $("#ContentPlaceHolder1_txt_rastrearEnvio_nroEnvio").val();
    
    retorno = false;
    errorMsj.text("");

    if (valTxtbox != "") {
        if (isNaN(valTxtbox)) {
            errorMsj.text("El envío debe ser un número");
        }
        else retorno = true;
    }
    else errorMsj.text("Debes introducir un número de envio");

    return retorno;
}