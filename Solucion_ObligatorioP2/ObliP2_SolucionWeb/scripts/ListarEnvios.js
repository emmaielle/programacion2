function validarNros() {
    docCli = $("#ContentPlaceHolder1_txt_superanMonto_usrName").val();
    monto = $("#ContentPlaceHolder1_txt_superanMonto_monto").val();
    summary = $("#ContentPlaceHolder1_lbl_superanMonto_messageServer");

    retorno = false;

    if (docCli.trim() != "" && monto.trim() != "") {
        if (isNaN(docCli)) {
            summary.text("El documento debe ser un número");
        }
        else if (isNaN(monto)) {
            summary.text("El monto debe ser un número");
        }
        else retorno = true;
    }
    else summary.text("Debes completar todos los campos");


    return retorno;

}

function validarCli_nro() {
    docCli = $("#ContentPlaceHolder1_txt_listarEnv_paraEntregar_usrName").val();
    summary = $("#ContentPlaceHolder1_lbl_paraEntregar_messageServer");

    retorno = false;

    if (docCli.trim() != "") {
        if (isNaN(docCli)) {
            summary.text("El documento debe ser un número");
        }
        else retorno = true;
    }
    else summary.text("Debes ingresar un número de documento");

    return retorno;
}