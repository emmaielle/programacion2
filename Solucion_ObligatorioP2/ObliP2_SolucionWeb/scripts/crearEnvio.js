function validaciones() {
    retorno = false;

    idCliente = $("#ContentPlaceHolder1_txt_crearEnvio_idCliente").val();
    peso = $("#ContentPlaceHolder1_txt_crearEnvio_peso").val();
    nomDest = $("#ContentPlaceHolder1_txt_crearEnvio_nomDest").val();
    calleDest = $("#ContentPlaceHolder1_txt_crearEnvio_calle").val();
    numPuerta = $("#ContentPlaceHolder1_txt_crearEnvio_numPuerta").val();
    paisDest = $("#ContentPlaceHolder1_txt_crearEnvio_pais").val();
    ciuDest = $("#ContentPlaceHolder1_txt_crearEnvio_ciudad").val();
    cpDest = $("#ContentPlaceHolder1_txt_crearEnvio_codPostal").val();


    largoPaq = $("#ContentPlaceHolder1_txt_crearEnvio_largoPaquete").val();
    anchoPaq = $("#ContentPlaceHolder1_txt_crearEnvio_anchoPaquete").val();
    altoPaq = $("#ContentPlaceHolder1_txt_crearEnvio_altoPaquete").val();
    costoBasePaq = $("#ContentPlaceHolder1_txt_crearEnvio_costoBase").val();
    valDeclPaq = $("#ContentPlaceHolder1_txt_crearEnvio_valorDeclaradoPaquete").val();
    dscPaq = $("#ContentPlaceHolder1_txt_crearEnvio_DescripPaquete").val();

    calleOri = $("#ContentPlaceHolder1_txt_crearEnvio_calleOrigen").val();
    nroPuertaOriDoc = $("#ContentPlaceHolder1_txt_crearEnvio_nroOrigen").val();
    paisOri = $("#ContentPlaceHolder1_txt_crearEnvio_paisOrigen").val();
    ciuOri = $("#ContentPlaceHolder1_txt_crearEnvio_ciudadOrigen").val();
    cpOri = $("#ContentPlaceHolder1_txt_crearEnvio_codPostalOrigen").val();

    p_errores = $("#ContentPlaceHolder1_p_crearEnvio_errores");

    if (idCliente != "" && peso != "" && nomDest != "" && calleDest != "" && numPuerta != "" &&
        paisDest != "" && ciuDest != "" && cpDest != "" && $('input[type="radio"]:checked').length) {

        if (isNaN(idCliente)) {
            p_errores.text("El id de cliente debe se un número");
        }
        else if (isNaN(peso)) {
            p_errores.text("El peso debe ser un número");
        }
        else if (isNaN(numPuerta)) {
            p_errores.text("El número de puerta de destino debe estar formado unicamente por números");
        }

        else if ($("#ContentPlaceHolder1_radiobtn_crearEnvio_esPaquete").is(':checked')) {

            if (largoPaq != "" && anchoPaq != "" && altoPaq != "" && costoBasePaq != "" && valDeclPaq != "" && dscPaq != "") {

                if (isNaN(largoPaq) || isNaN(anchoPaq) || isNaN(altoPaq)) {
                    p_errores.text("Las dimensiones del paquete deben ser números");
                }
                else if (isNaN(costoBasePaq)) {
                    p_errores.text("El costo base del paquete debe ser un número");
                }
                else if (isNaN(valDeclPaq)) {
                    p_errores.text("El valor declarado del paquete debe ser un número");
                }
                else retorno = true;

            }
            else p_errores.text("Es necesario completar todos los datos del paquete");
        }

        else if ($("#ContentPlaceHolder1_radiobtn_crearEnvio_esDoc").is(':checked')) {

            if (calleOri != "" && nroPuertaOriDoc != "" && paisOri != "" && ciuOri != "" && cpOri != "") {

                if (isNaN(nroPuertaOriDoc)) {
                    p_errores.text("El número de puerta de origen debe estar formado unicamente por números");
                }
                else retorno = true;
            }
            else p_errores.text("Es necesario completar todos los datos del documento");
        }
    }

    else p_errores.text("Todos los campos son obligatorios");

    return retorno;
}