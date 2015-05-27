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
        private Direccion direccion;
        private bool esAdmin; 
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

          public bool EsAdmin
        {
            get { return esAdmin; }
            set { esAdmin = value; }
              
        }

        public Direccion Direccion
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
            string pTelefono, Direccion direccion, bool esAdmin)
        {
            this.user = pUser;
            this.documento = pDocumento;
            this.password = pPassword;
            this.nombre = pNombre;
            this.apellido = pApellido;
            this.documento = pDocumento;
            this.telefono = pTelefono;
            this.direccion = direccion;
            this.esAdmin = esAdmin;
        }

        #endregion

        #region Comportamiento

        /*Return lista de envios que superen el monto ingresado */
        public List<Envio> EnviosQueSuperanMonto(decimal pMonto)
        {
            List<Envio> lista=null;

            foreach (Envio env in enviosCliente)
            {
                if (env.PrecioFinal > pMonto)
                {
                    lista.Add(env);
                }
            }

            return lista;
        }

        /*Agrega un envio a la lista de envios que tiene el cliente */
        public void AgregarEnvio(Envio pEnvio)
        {
            enviosCliente.Add(pEnvio);
        }

        /*Lista todos los envios del cliente que fueron entregados
        public List<Envio> ListarEnviosEntregados()
        {
            List<Envio> lista=null;

            foreach (Envio env in enviosCliente)

            {

                if (EtapaEnvio.etapa.Entregado.Equals (env.EtapasDelEnvio) ) {
                   lista.Add (env);
                  
                }
                return lista;
            }*/
        }
        #endregion
    }






