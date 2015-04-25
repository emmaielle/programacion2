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
        private string nombreCompleto;

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

        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set { nombreCompleto = value; }
        }

        #endregion

        #region Constructor

        public Usuario(string pUser, string pPassword, string pNombreCompleto)
        {
            this.user = pUser;
            this.Password = pPassword;
            this.nombreCompleto = pNombreCompleto;
        }

        #endregion




    }
}


