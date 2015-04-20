using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Envio_documento : Envio
    {
        #region Atributos

        private float pesoGRAMOS;
        private static decimal costoBase = 100M;
        private bool esDocLegal;
        private decimal precioFinal;

        #endregion

        #region Properties

        public float PesoGRAMOS
        {
            get { return pesoGRAMOS; }
            set { pesoGRAMOS = value; }
        }
        public static decimal CostoBase
        {
            get { return Envio_documento.costoBase; }
            set { Envio_documento.costoBase = value; }
        }
        public bool EsDocLegal
        {
            get { return esDocLegal; }
            set { esDocLegal = value; }
        }
        public decimal PrecioFinal
        {
            get { return precioFinal; }
            set { precioFinal = value; }
        }

        #endregion

        #region Constructor

        public Envio_documento(string pNomRecibio, string pFirma, Cliente pCliente, Direccion pDirOrigen, string pNomDestinatario, 
                                Direccion pDirDestino, DateTime pFechaIngreso, OficinaPostal pOficinaIngreso, float pPesoGramos, bool pLegal) 
            : base(pNomRecibio, pFirma, pCliente, pDirOrigen, pNomDestinatario, pDirDestino, pFechaIngreso, pOficinaIngreso)
        {
            this.PesoGRAMOS = pPesoGramos;
            this.EsDocLegal = pLegal;
            this.PrecioFinal = CalcularPrecioFinal();
        }

        #endregion

        #region Comportamiento

        public override decimal CalcularPrecioFinal()
        {
            decimal final = Envio_documento.CostoBase * Convert.ToDecimal(this.PesoGRAMOS); // <-- ver si es la mejor forma de convertirlo <--
            
            if (this.EsDocLegal)
            {
                final += final * 0.05M;
            }

            return final;
            
        }

        #endregion

    }
}
