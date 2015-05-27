using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class EtapaEnvio
    {
        #region Atributos

        private DateTime fechaIngreso;

        public enum etapa {
            EnOrigen,
            EnTransito,
            ParaEntregar,
            Entregado
        }
        private OficinaPostal ubicacion;
        #endregion

        #region Properties

        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }
               
        public OficinaPostal Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }
        
        #endregion

        #region Constructor

        /*Me falta la etapa, no deberia ser con property o si?*/
        public EtapaEnvio(DateTime pFechaIng, int pEtapa, OficinaPostal pUbicacion) 
        {
            this.FechaIngreso = pFechaIng;
            this.Ubicacion = pUbicacion;
        }

        #endregion

        #region Comportamiento



        #endregion
    }
}
