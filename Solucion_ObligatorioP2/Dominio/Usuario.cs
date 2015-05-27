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
        private string nombre;
        private string apellido;
        private string documento;
        private string telefono;
        private Direccion direccion;
        private List<Envio> enviosCliente;

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


        internal Direccion Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public List<Envio> EnviosCliente
        {
            get { return enviosCliente; }
            set { enviosCliente = value; }
        }

        #endregion

        #region Constructor

        public Usuario(string pUser, string pPassword, string pNombre, string pApellido, string pDocumento, 
            string pTelefono, Direccion direccion)
        {
            this.user = pUser;
            this.documento = pDocumento;
            this.password = pPassword;
            this.nombre = pNombre;
            this.apellido = pApellido;
            this.documento = pDocumento;
            this.telefono = pTelefono;
            this.direccion = Direccion;
        }

        #endregion


        #region Comportamiento


        public List<Envio> EnviosQueSuperanMonto(decimal pMonto)
        {
            List<Envio> lista = null;

            foreach (Envio env in enviosCliente)
            {
                if (env.PrecioFinal > pMonto)
                {
                    lista.Add(env);
                }
            }

            return lista;
        }
    
        #endregion
    }


}



