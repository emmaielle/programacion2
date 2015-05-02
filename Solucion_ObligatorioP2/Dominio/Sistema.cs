using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class  Sistema
    {
        #region Atributos
        private static Sistema instancia;
        private List<Cliente> listaClientes;
        private List<Administrador> listaAdmins;
        private List<Envio> listaEnvios;
        private List<EtapaEnvio> listaEtapasEnvio;
        private List<OficinaPostal> listaOficinasPostales;


        #endregion

        #region Properties
        public Sistema Instancia
        {
            get { return instancia; }
            set { instancia = value; }
        }
        #endregion

        #region Constructor

        /*Se implementa Singleton*/
        public static Sistema InstanciaSistema() {

            if(Sistema.instancia == null)
            {
                Sistema.instancia = new Sistema();
            }
                return Sistema.instancia;


        }


        #endregion

        #region Comportamiento

        /*TODO: agregar controles y manejar exceptions. Ej: if ci no esta en la lista, add*/
        /*Recibe un cliente y lo agrega a la lista*/
        public void AltaCliente(Cliente cliente)
        {

            this.listaClientes.Add(cliente);
        }

        /*TODO: agregar controles y manejar exceptions. */
        /*Recibe un envio y lo agrega a la lista*/
        public void AltaEnvio(Envio envio)
        {
            this.listaEnvios.Add(envio);
        }

       
        public void  AltaAdministrador (Administrador administrador)

         {
             this.listaAdmins.Add(administrador);
         }

        /*Dado una cedula, se recorre la lista de clientes para buscarlo. Retorna cliente*/
        public Cliente BuscarCliente (string pCi) 
        {
            Cliente aux = null;
           
            int i = 0;
            while (i < this.listaClientes.Count && aux == null)
            {
                Cliente cli = this.listaClientes[i];
                if (cli.Documento == pCi)
                {
                    aux = cli;
                }
                i++;
            }
            return aux;
        }

        /*Dado una Nro de envio se recorre la lista de envios para buscarlo. Retorna Envio*/
        public Envio BuscarEnvio (int pId) 
        {
            Envio aux = null;
            int i = 0;
            while (i < this.listaEnvios.Count && aux == null)
            {
                Envio env = this.listaEnvios[i];
                if (env.NroEnvio == pId)
                {
                    aux = env;
                }
                i++;
            }
            return aux;
        }
        
        #endregion

    }

    }

