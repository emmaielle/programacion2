using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Cliente : Usuario
    {
        #region Atributos

        private string telefono;
        private Direccion direccion;

        #endregion

        #region Properties

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        internal Direccion Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        #endregion

        #region Constructor

        public Cliente(string pUser, string pPassword, string pNombres, string pApellidos, string pTelefono, string pDocumento, Direccion pDireccion)
            : base(pUser, pPassword, pNombres, pApellidos)
        {
            this.telefono = pTelefono;
            this.documento = pDocumento;
            this.direccion = pDireccion;
        }

        #endregion

        #region Comportamiento
        #endregion
    }
}