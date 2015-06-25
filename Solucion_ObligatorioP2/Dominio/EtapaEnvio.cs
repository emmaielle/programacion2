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

        public enum Etapas
        {
            EnOrigen,
            EnTransito,
            ParaEntregar,
            Entregado
        }

        private DateTime fechaIngreso;
        private Etapas etapa;
        private OficinaPostal ubicacion;
       
        #endregion

        #region Properties

        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }

        public Etapas Etapa
        {
            get { return etapa; }
            set { etapa = value; }
        }

        public OficinaPostal Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }
        
        #endregion

        #region Constructor

        public EtapaEnvio(DateTime pFechaIng, Etapas pEtp, OficinaPostal pUbicacion) 
        {
            this.etapa = pEtp;
            this.fechaIngreso = pFechaIng;
            this.ubicacion = pUbicacion;
        }

        #endregion

    }
}
