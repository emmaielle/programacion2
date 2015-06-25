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

        private static decimal costoBasePorGramo = 20M;
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

        public EnvioDocumento(Usuario pRemitente, Direccion pDirOrigen, string pNomDestinatario, 
                                Direccion pDirDestino, DateTime pFechaIngreso, OficinaPostal pOficinaIngreso, float pPesoKilos, bool pLegal) 
            : base(pRemitente, pNomDestinatario, pDirDestino, pFechaIngreso, pOficinaIngreso)
            
        {
           if (base.dirDestinatario != pDirOrigen)
            {
                this.dirOrigen = pDirOrigen;
                base.peso = TransformarPesoAGramos(pPesoKilos);
                this.esDocLegal = pLegal;
                base.precioFinal = CalcularPrecioFinal();
            }
        }

        // constructor para simulacion de envioDocumento
        public EnvioDocumento(float pPesoKilos, bool pLegal) 
        {
            this.esDocLegal = pLegal;
            base.peso = pPesoKilos;
            base.precioFinal = CalcularPrecioFinal();
 
        }

        #endregion

        #region Comportamiento

        // Transforma automáticamente el peso introducido por el admin en KG a Gramos, como se solicita en la letra para 
        // calcular el precio. El atributo peso se encuentra común en la clase base Envio, y para ambos tipos de envíos está en KG.
        // Solo se transforma para el calculo mencionado.
        private float TransformarPesoAGramos(float pPesoKG)
        {
            return pPesoKG * 1000;
        }

        // precioFinal = costoBase/gr X pesoGramos + 5% si es documento legal
        public override decimal CalcularPrecioFinal()
        {
            decimal pesoenGramosDecimal;
            bool d = decimal.TryParse(this.TransformarPesoAGramos(base.peso).ToString(), out pesoenGramosDecimal);

            decimal final;
            
            if (d)
            {
                final = EnvioDocumento.CostoBasePorGramo * pesoenGramosDecimal;

                if (this.EsDocLegal)
                {
                    final += final * 0.05M;
                }
            }
            else final = 0M;

            return final;
            
        }

        // variante de método base AgregarEtapa, que corrobora que si el documento es legal tiene que ser recibido (pNomRecibio) por el 
        // propio destinatario (base.NombreDestinatario), y devuelve un bool para éxito o fracaso.
        public override bool AgregarEtapa(DateTime pFechaIngreso, EtapaEnvio.Etapas pEtapa, OficinaPostal pUbicacion, 
                                            string pFirmaRecibio, string pNombreRecibio, out string pMensajeError)
        {
            bool seHace = true;
            bool exito = false;

            if (this.esDocLegal)
            {
                if (pEtapa == EtapaEnvio.Etapas.Entregado)
                {
                    if (pNombreRecibio != base.NombreDestinatario)
                    {
                        seHace = false;
                    }
                }
            }

            if (seHace)
            {
                exito = base.AgregarEtapa(pFechaIngreso, pEtapa, pUbicacion, pFirmaRecibio, pNombreRecibio, out pMensajeError);
            }
            else
            {
                pMensajeError = "El nombre de destinatario asociado a este envio no coincide con el nombre de quien lo recibe";
            }
            return exito;
        }

        #endregion

    }
}
