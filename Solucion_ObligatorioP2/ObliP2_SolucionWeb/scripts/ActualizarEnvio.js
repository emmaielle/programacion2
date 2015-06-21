
function validarCampos() {
    nroEnv = $("#ContentPlaceHolder1_txt_actualizarEnv_nroEnv").val();
    recibido = $("#ContentPlaceHolder1_txt_actualizarEnv_nomRecibio").val();
    validSummary = $("#ContentPlaceHolder1_p_actualizarEnv_message");

    retorno = false;

    if (nroEnv.trim() != "" && recibido.trim() != "") {
        if (isNaN(nroEnv)) {
            validSummary.text("El número de envío debe estar compuesto unicamente por números");
        }
        else retorno = true;
    }
    else
    {
        validSummary.text("Todos los campos son obligatorios");
    }

    return retorno;
}