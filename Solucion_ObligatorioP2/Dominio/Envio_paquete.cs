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
        private float pesoKG;
        private string descripcion;
        private decimal precioFinal;

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
        public float PesoKG
        {
            get { return pesoKG; }
            set { pesoKG = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public decimal PrecioFinal
        {
            get { return precioFinal; }
            set { precioFinal = value; }
        }

        #endregion

        #region Constructor

        public Envio_paquete(string pNomRecibio, string pFirma, Cliente pCliente, Direccion pDirOrigen, string pNomDestinatario,
                                Direccion pDirDestino, DateTime pFechaIngreso, OficinaPostal pOficinaIngreso, float pAlto, float pAncho,
                                float pLargo, decimal pValorDeclarado, bool pSeguro, float pPesoKG, string pDescripcion)
            : base (pNomRecibio, pFirma, pCliente, pDirOrigen, pNomDestinatario, pDirDestino, pFechaIngreso, pOficinaIngreso)
        {
            // alto, largo y ancho tienen que ser en cm!!!
            this.Alto = pAlto;
            this.Ancho = pAncho;
            this.Largo = pLargo;
            this.ValorDeclarado = pValorDeclarado;
            this.TieneSeguro = pSeguro;
            this.PesoKG = pPesoKG;
            this.Descripcion = pDescripcion;        
            this.PrecioFinal = CalcularPrecioFinal();
        }

        #endregion

        #region Comportamiento
        // ver si todos los metodos necesitan ser publicos o si puedo hacer privado alguno, como calcularPrecios
        
        private override decimal CalcularPrecioFinal()
        {
            // asigno a final el valor del precioPorPeso, y si es menor que el volumetrico, lo cambio
            decimal final = this.CalcularPrecioPorPeso();
            decimal volumetrico = this.CalcularPrecioVolumetrico();
            
            if (volumetrico > final) final = volumetrico;

            return final;
        }

        private decimal CalcularPrecioPorPeso()
        {
            return (Envio_paquete.CostoBasePorGramo / 1000) * Convert.ToDecimal(this.PesoKG);
        }

        private decimal CalcularPrecioVolumetrico()
        {
            return Convert.ToDecimal(this.Alto * this.Ancho * this.Largo);
        }

        #endregion

    }
}
