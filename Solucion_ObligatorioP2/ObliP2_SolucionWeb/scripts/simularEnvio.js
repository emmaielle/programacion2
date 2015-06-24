function validaciones() {
    retorno = false;

    peso = $("#ContentPlaceHolder1_txt_simularEnvio_peso").val();
  
    largoPaq = $("#ContentPlaceHolder1_txt_simularEnvio_largoPaquete").val();
    anchoPaq = $("#ContentPlaceHolder1_txt_simularEnvio_anchoPaquete").val();
    altoPaq = $("#ContentPlaceHolder1_txt_simularEnvio_altoPaquete").val();
    costoBasePaq = $("#ContentPlaceHolder1_txt_simularEnvio_costoBase").val();
    valDeclPaq = $("#ContentPlaceHolder1_txt_simularEnvio_valorDeclaradoPaquete").val();

    p_errores = $("#ContentPlaceHolder1_p_simularEnvio_errores");

    if (peso.trim() != "" && $('input[type="radio"]:checked').length) {

        if (isNaN(peso)) {
            p_errores.text("El peso debe ser un número");
        }

        else if ($("#ContentPlaceHolder1_radiobtn_simularEnvio_esPaquete").is(':checked')) {

            if (largoPaq.trim() != "" && anchoPaq.trim() != "" && altoPaq != "" && costoBasePaq.trim() != "" && valDeclPaq.trim() != "") {

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
        else retorno = true;
    }

    else p_errores.text("Todos los campos son obligatorios");

    return retorno;
}