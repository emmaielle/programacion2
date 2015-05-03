using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class  Sistema
    {
        #region Singleton

        //hice una region aparte
        private static Sistema instancia;

        public static Sistema Instancia
        {
            get
            {
                if (Sistema.instancia == null)
                {
                    Sistema.instancia = new Sistema();
                }

                return Sistema.instancia;
            }
            //set { instancia = value; }
        }

        private Sistema() //privado
        {
        
        }

        #endregion

        #region Atributos

        private List<Cliente> listaClientes;
        private List<Administrador> listaAdmins;
        private List<Envio> listaEnvios;
        // private List<EtapaEnvio> listaEtapasEnvio; <--- lo elimino porque era clase asociacion, invisible para sistema
        private List<OficinaPostal> listaOficinasPostales;

        #endregion

        #region Properties
        // hay properties?


        #endregion

        #region Clientes

        /*TODO: agregar controles y manejar exceptions. Ej: if ci no esta en la lista, add*/
        /*Recibe un cliente y lo agrega a la lista*/
        public void AltaCliente(Cliente cliente)
        {

            this.listaClientes.Add(cliente);
        }

        /*Dado una cedula, se recorre la lista de clientes para buscarlo. Retorna cliente encontrado o null*/
        public Cliente BuscarCliente (string pCi) 
        {
            Cliente aux = null;
           
            int i = 0;
            // foreach
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

        #endregion

        #region Administradores

        public void AltaAdministrador(Administrador administrador)
        {
            this.listaAdmins.Add(administrador);
        }

        #endregion

        #region Envios

        /*TODO: agregar controles y manejar exceptions. */
        /*Recibe un envio y lo agrega a la lista*/
        public void AltaEnvio(Envio envio)
        {
            this.listaEnvios.Add(envio);
        }

        /*Dado una Nro de envio se recorre la lista de envios para buscarlo. Retorna Envio encontrado o null*/
        public Envio BuscarEnvio(int pId)
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

