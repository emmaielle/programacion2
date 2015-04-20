using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class EtapaEnvio
    {
        #region Atributos

        private DateTime fechaIngreso;
        private int etapa;
        private OficinaPostal ubicacion;

        #endregion

        #region Properties

        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }
        public int Etapa
        {
            get { return etapa; }
            set { etapa = value; }
        }
        internal OficinaPostal Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        #endregion

        #region Constructor

        public EtapaEnvio(DateTime pFechaIng, int pEtapa, OficinaPostal pUbicacion) 
        {
            this.FechaIngreso = pFechaIng;
            this.Etapa = pEtapa;
            this.Ubicacion = pUbicacion;
        }

        #endregion

        #region Comportamiento



        #endregion
    }
}
