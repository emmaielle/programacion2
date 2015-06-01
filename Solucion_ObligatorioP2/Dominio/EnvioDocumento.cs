using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class EnvioDocumento : Envio
    {
        #region Atributos

        private static decimal costoBasePorGramo = 100M;
        private bool esDocLegal;
        private Direccion dirOrigen;

        #endregion

        #region Properties

        public static decimal CostoBasePorGramo
        {
            get { return EnvioDocumento.costoBasePorGramo; }
            set { EnvioDocumento.costoBasePorGramo = value; }
        }
        public bool EsDocLegal
        {
            get { return esDocLegal; }
            set { esDocLegal = value; }
        }

        public Direccion DirOrigen
        {
            get { return dirOrigen; }
            set { dirOrigen = value; }
        }

        #endregion

        #region Constructor

        public EnvioDocumento(string pNomRecibio, string pFirma, Direccion pDirOrigen, string pNomDestinatario, 
                                Direccion pDirDestino, DateTime pFechaIngreso, OficinaPostal pOficinaIngreso, float pPesoKilos, bool pLegal) 
            : base(pNomRecibio, pFirma, pNomDestinatario, pDirDestino, pFechaIngreso, pOficinaIngreso)
            
        {
            base.Peso = TransformarPesoAGramos(pPesoKilos);
            this.EsDocLegal = pLegal;
            base.PrecioFinal = CalcularPrecioFinal();
            this.DirOrigen = pDirOrigen;
        }

        // constructor para simulacion de envioDocumento

        public EnvioDocumento(float pPesoKilos, bool pLegal)
        {
            base.Peso = TransformarPesoAGramos(pPesoKilos);
            this.EsDocLegal = pLegal;
            base.PrecioFinal = CalcularPrecioFinal();
        }

        #endregion

        #region Comportamiento

        // Transforma automáticamente el peso introducido por el admin en KG a Gramos, como se solicita en la letra para 
        // los documentos. El atributo peso e encuentra común en la clase base Envio, para ambos tipos de envíos. En el caso de 
        // los paquetes, no hay ninguna transformación porque se guarda en KG.
        private float TransformarPesoAGramos(float pPesoKG)
        {
            return pPesoKG * 1000;
        }

        // precioFinal = costoBase/gr X pesoGramos + 5% si es documento legal
        public override decimal CalcularPrecioFinal()
        {
            decimal final = EnvioDocumento.CostoBasePorGramo * Convert.ToDecimal(base.Peso); // <-- ver si es la mejor forma de convertirlo <--
            
            if (this.EsDocLegal)
            {
                final += final * 0.05M;
            }
            return final;
            
        }

        public override bool AgregarEtapa(DateTime pFechaIngreso, EtapaEnvio.Etapas pEtapa, OficinaPostal pUbicacion, string pNombreRecibio)
        {
            bool output = false;

            if (pEtapa == EtapaEnvio.Etapas.Entregado)
            {
                if (this.esDocLegal)
                {
                    if (pNombreRecibio == this.NombreDestinatario)
                    {
                        output = true;
                    }
                }
                else { output = true; }
            }
            else { output = true;}

            if (output) 
            {
                EtapaEnvio etp = new EtapaEnvio(pFechaIngreso, pEtapa, pUbicacion);
                this.EtapasDelEnvio.Add(etp);
            }

            return output;
        }

        #endregion

    }
}
