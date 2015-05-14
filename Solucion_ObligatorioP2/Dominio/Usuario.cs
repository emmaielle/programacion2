using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Usuario
    {
        #region Atributos

        private string user;
        private string password;
        private string nombres;
        private string apellidos;
        private string documento;

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
            get { return nombres; }
            set { nombres = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        #endregion

        #region Constructor

        public Usuario(string pUser, string pPassword, string pNombres, string pApellidos)
        {
            this.user = pUser;
            this.Password = pPassword;
            this.nombres = pNombres;
            this.apellidos = pApellidos;
        }

        #endregion

    }
}


