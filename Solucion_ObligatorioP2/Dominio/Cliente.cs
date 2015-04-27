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
        private string documento;
        private Direccion direccion;

        #endregion

        #region Properties

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        internal Direccion Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        #endregion

        #region Constructor

        public Cliente(string pUser, string pPassword, string pNombreCompleto, string pTelefono, string pDocumento, Direccion pDireccion)
            : base(pUser, pPassword, pNombreCompleto)
        {
            this.telefono = pTelefono;
            this.documento = pDocumento;
            this.direccion = pDireccion;
        }

        #endregion

        #region Comportamiento

        public void AltaCliente()
        {
        }
        #endregion
    }
}
