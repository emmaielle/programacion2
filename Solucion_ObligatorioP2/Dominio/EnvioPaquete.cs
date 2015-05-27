using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class EnvioPaquete : Envio
    {

        #region Atributos

        private float alto;
        private float ancho;
        private float largo;
        private static decimal costoBasePorGramo = 300M;
        private decimal valorDeclarado;
        private bool tieneSeguro;
        private string descripcion;

        #endregion

        #region Propiedades

        public float Alto
        {
            get { return alto; }
            set { alto = value; }
        }
        public float Ancho
        {
            get { return ancho; }
            set { ancho = value; }
        }
        public float Largo
        {
            get { return largo; }
            set { largo = value; }
        }
        public static decimal CostoBasePorGramo
        {
            get { return EnvioPaquete.costoBasePorGramo; }
            set { EnvioPaquete.costoBasePorGramo = value; }
        }
        public decimal ValorDeclarado
        {
            get { return valorDeclarado; }
            set { valorDeclarado = value; }
        }
        public bool TieneSeguro
        {
            get { return tieneSeguro; }
            set { tieneSeguro = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        #endregion

        #region Constructor

        public EnvioPaquete(string pNomRecibio, string pFirma, Cliente pCliente, Direccion pDirOrigen, string pNomDestinatario,
                                Direccion pDirDestino, DateTime pFechaIngreso, OficinaPostal pOficinaIngreso, float pAlto, float pAncho,
                                float pLargo, decimal pValorDeclarado, bool pSeguro, float pPesoKilos, string pDescripcion)
            : base (pNomRecibio, pFirma, pCliente, pDirOrigen, pNomDestinatario, pDirDestino, pFechaIngreso, pOficinaIngreso)
        {
            // alto, largo y ancho tienen que ser en cm!!!
            this.Alto = pAlto;
            this.Ancho = pAncho;
            this.Largo = pLargo;
            this.ValorDeclarado = pValorDeclarado;
            this.TieneSeguro = pSeguro;
            base.Peso = pPesoKilos;         
            // El atributo peso se encuentra común en la clase base Envio, para ambos tipos de envíos. En el caso de 
            // los paquetes, no hay ninguna transformación porque se guarda en KG.
            this.Descripcion = pDescripcion;        
            base.PrecioFinal = CalcularPrecioFinal();
        }

        #endregion

        // ver si todos los metodos necesitan ser publicos o si puedo hacer privado alguno, como calcularPrecios
        #region Comportamiento
        
        //toma el peso Volumetrico como el peso final, a no ser que sea menor que el peso en Kg. Multiplica el peso elegido por el costoBasexGramo
        //para paquetes y por 100, y si tiene seguro, le suma el 1% del valor declarado
        public override decimal CalcularPrecioFinal()
        {
            float pesoUsado = CalcularPesoVolumetrico();
            if (base.Peso > pesoUsado) pesoUsado = base.Peso;

            decimal precioFinal = EnvioPaquete.CostoBasePorGramo * 1000 * Convert.ToDecimal(pesoUsado);

            if (this.TieneSeguro) precioFinal = precioFinal + (this.ValorDeclarado * 0.01M);
            return precioFinal;
        }

        // pesoVolumetrico = (volumen de paquete en cm3) / 6000
        private float CalcularPesoVolumetrico()
        {
            return (this.Alto * this.Ancho * this.Largo) / 6000;
        }

        #endregion

    }
}
