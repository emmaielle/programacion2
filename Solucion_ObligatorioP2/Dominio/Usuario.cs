using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        #region Atributos

        private string user;
        private string password;
        private string nombre;
        private string apellido;
        private string documento;
        private string telefono;
        private Direccion direccionUsuario;
        private bool esAdmin;
        private string mail;

        #endregion

        #region Properties

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public bool EsAdmin
        {
            get { return esAdmin; }
            set { esAdmin = value; }
        }

        public Direccion DireccionUsuario
        {
            get { return direccionUsuario; }
            set { direccionUsuario = value; }
        }

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        #endregion

        #region Constructor

        public Usuario(string pUser, string pPassword, string pNombre, string pApellido, string pDocumento,
            string pTelefono, Direccion pDireccion, bool esAdmin, string pMail)
        {
            this.user = pUser;
            this.documento = pDocumento;
            this.password = pPassword;
            this.nombre = pNombre;
            this.apellido = pApellido;
            this.telefono = pTelefono;
            this.direccionUsuario = pDireccion;
            this.esAdmin = esAdmin;
            this.mail = pMail;
        }

        #endregion

    }
}




