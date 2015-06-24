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

        public EnvioDocumento(Direccion pDirOrigen, string pNomDestinatario, 
                                Direccion pDirDestino, DateTime pFechaIngreso, OficinaPostal pOficinaIngreso, float pPesoKilos, bool pLegal) 
            : base(pNomDestinatario, pDirDestino, pFechaIngreso, pOficinaIngreso)
            
        {
           if (base.dirDestinatario != pDirOrigen)
            {
                this.DirOrigen = pDirOrigen;
                base.Peso = TransformarPesoAGramos(pPesoKilos);
                this.EsDocLegal = pLegal;
                base.PrecioFinal = CalcularPrecioFinal();
            }
        }

        // constructor para simulacion de envioDocumento
        public EnvioDocumento(float pPesoKilos, bool pLegal) 
        {
            this.esDocLegal = pLegal;
            base.Peso = pPesoKilos;
            base.PrecioFinal = CalcularPrecioFinal();
 
        }

        // este constructor vacio para que está??
        public EnvioDocumento() { 
        
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
            decimal pesoDecimal;
            bool d = decimal.TryParse(base.peso.ToString(), out pesoDecimal);

            decimal final;
            
            if (d)
            {
                final = EnvioDocumento.CostoBasePorGramo * pesoDecimal;

                if (this.EsDocLegal)
                {
                    final += final * 0.05M;
                }
            }
            else final = 0M;

            return final;
            
        }

        // variante de método base AgregarEtapa, que corrobora si el documento es legal tiene que ser recibido (pNomRecibio) por el 
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
