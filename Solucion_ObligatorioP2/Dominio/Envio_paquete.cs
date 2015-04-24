using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Envio_paquete : Envio
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
            get { return Envio_paquete.costoBasePorGramo; }
            set { Envio_paquete.costoBasePorGramo = value; }
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

        public Envio_paquete(string pNomRecibio, string pFirma, Cliente pCliente, Direccion pDirOrigen, string pNomDestinatario,
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
            // El atributo peso e encuentra común en la clase base Envio, para ambos tipos de envíos. En el caso de 
            // los paquetes, no hay ninguna transformación porque se guarda en KG.
            this.Descripcion = pDescripcion;        
            base.PrecioFinal = CalcularPrecioFinal();
        }

        #endregion

        #region Comportamiento
        // ver si todos los metodos necesitan ser publicos o si puedo hacer privado alguno, como calcularPrecios
        
        public override decimal CalcularPrecioFinal()
        {
            // asigno a final el valor del precioPorPeso, y si es menor que el volumetrico, lo cambio
            decimal final = this.CalcularPrecioPorPeso();
            decimal volumetrico = this.CalcularPrecioVolumetrico();
            if (volumetrico > final) final = volumetrico;

            if (this.TieneSeguro) final = final + (this.ValorDeclarado * Convert.ToDecimal(0.01));
            return final;
        }

        // precioPorPeso = costoBase/gr X peso en Kg
        private decimal CalcularPrecioPorPeso()
        {
            return Envio_paquete.CostoBasePorGramo * 1000 * Convert.ToDecimal(base.Peso);
        }

        // precioVolumetrico = (volumen de paquete en cm3) / 6000
        private decimal CalcularPrecioVolumetrico()
        {
            return Convert.ToDecimal(this.Alto * this.Ancho * this.Largo) / 6000;
        }

        #endregion

    }
}
