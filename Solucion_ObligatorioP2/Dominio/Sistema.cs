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
        }

        private Sistema() 
        {
            CargarDatosIniciales();
        }

        #endregion

        #region Listas

        private List<Cliente> listaClientes;
        private List<Administrador> listaAdmins;
        private List<Envio> listaEnvios;
        private List<OficinaPostal> listaOficinasPostales;

        #endregion

        #region Datos Iniciales

        void CargarDatosIniciales()
        {
        }

        #endregion

        #region Clientes

        /*TODO: agregar controles y manejar exceptions. Ej: if ci no esta en la lista, add*/
        /*Recibe datos para crear un cliente, crea el cliente y su dirección, lo agrega a la lista y devuelve el cliente nuevo o ya existente */
        public Cliente AltaCliente(string pUsr, string pPass, string pNom, string pApell, string pTel, string pDoc, string pCalle, int pNum, 
                                string pCP, string pCiu, string pPais) 
        {
            Cliente encontro = BuscarCliente(pDoc);
            Cliente cli = null;

            if (encontro == null)
            {
                Direccion dir = new Direccion(pCalle, pNum, pCP, pCiu, pPais);
                cli = new Cliente(pUsr, pPass, pNom, pApell, pTel, pDoc, dir);
                
                if (this.listaClientes == null) this.listaClientes = new List<Cliente>();
                this.listaClientes.Add(cli);
            }
            else cli = encontro;

            return cli;
            
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

        /*TODO: agregar controles y manejar exceptions. Ej: if ci no esta en la lista, add*/
        /*Recibe datos para crear un Admin, crea el admin y lo agrega a la lista*/
        public Administrador AltaAdministrador(string pUsr, string pPass, string pNom, string pApell)
        {
            Administrador encontro = BuscarAdmin(pUsr);
            Administrador admin = null;

            if (encontro == null)
            {
                admin = new Administrador(pUsr, pPass, pNom, pApell);

                if (this.listaAdmins == null) this.listaAdmins = new List<Administrador>();
                this.listaAdmins.Add(admin);
            }
            else admin = encontro;

            return admin;
        }

        /*Dado un nombre de usuario, se recorre la lista de admins para buscarlo. Retorna admin encontrado o null*/
        public Administrador BuscarAdmin(string pUser) // <------------- here
        {
            Administrador aux = null;

            int i = 0;
            // foreach
            while (i < this.listaAdmins.Count && aux == null)
            {
                Administrador admin = this.listaAdmins[i];
                if (admin.User == pUser) // <-------- here. Documento para admin?
                {
                    aux = admin;
                }
                i++;
            }
            return aux;
        }

        #endregion

        #region Envios

        /* TODO: agregar controles y manejar exceptions */
        /* Recibe parametros para crear envio de documentos, y lo agrega a la lista de envios */
        public void AltaEnvioDocumento(string pNomRecibio, string pFirma, Cliente pCliente, Direccion pDirOrigen, string pNomDestinatario, 
                                 Direccion pDirDestino, DateTime pFechaIngreso, OficinaPostal pOficinaIngreso, float pPesoKilos, bool pLegal)
        {
            Envio_documento env = new Envio_documento(pNomRecibio, pFirma, pCliente, pDirOrigen, pNomDestinatario, pDirDestino, 
                                                            pFechaIngreso, pOficinaIngreso, pPesoKilos, pLegal);
            this.listaEnvios.Add(env);
         
        } // <<<--------- pensar de otra manera para unir ambos envios??


        /* TODO: agregar controles y manejar exceptions */
        /* Recibe parametros para crear envio de paquetes, y lo agrega a la lista de envios */
        public void AltaEnvioDocumento(string pNomRecibio, string pFirma, Cliente pCliente, Direccion pDirOrigen, string pNomDestinatario,
                                 Direccion pDirDestino, DateTime pFechaIngreso, OficinaPostal pOficinaIngreso, float pAlto, float pAncho,
                                 float pLargo, decimal pValorDecl, bool pSeguro, float pPesoKg, string pDescr)
        {
            Envio_paquete env = new Envio_paquete(pNomRecibio, pFirma, pCliente, pDirOrigen, pNomDestinatario, pDirDestino,
                                                  pFechaIngreso, pOficinaIngreso,pAlto, pAncho, pLargo, pValorDecl, pSeguro, pPesoKg, pDescr);
            this.listaEnvios.Add(env);

        } // <<<--------- pensar de otra manera para unir ambos envios??

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

        // dandole de input el numero de envio, busca si existe el envio. Si existe, 
        // busca las etapas de envio a partir de ese objeto, para procesarse luego.
        // Si no existe el envio, devuelve una lista vacia.
        public List<EtapaEnvio> RastrearEnvio(int pNroEnvio)
        {
            Envio envioEncontrado = BuscarEnvio(pNroEnvio);
            List<EtapaEnvio> listaEtapas = new List<EtapaEnvio>();

            if (envioEncontrado != null)
            {
                listaEtapas = envioEncontrado.RastrearEnvio();
            }
            return listaEtapas;
        }

        #endregion

        #region OficinaPostal

        // Crea una oficina postal luego de revisar si existe una oficina con los mismos datos, 
        // y la suma a la lista de oficinas postales del sistema. No devuelve nada.
        public void AltaOficina(string pCiudad, string pCalle, string pCP, string pPais, int pNro)
        {
            OficinaPostal encontro = BuscarOficinaXDatos(pCiudad, pCalle, pCP, pPais, pNro);
            OficinaPostal ofi = null;

            if (encontro == null)
            {
                ofi = new OficinaPostal(pPais, pNro, pCalle, pCiudad, pCP);
                if (this.listaOficinasPostales == null) this.listaOficinasPostales = new List<OficinaPostal>();
                this.listaOficinasPostales.Add(ofi);
            }
        }

        // Busca la oficina postal por la identidad de todos sus atributos, porque lo que no queremos es que se repitan oficinas al dar
        // altas, ya que el identificador de las oficinas es un autonumerado y eso no lo podemos controlar en la creación.
        // Devuelve la oficina encontrada o NULL
        public OficinaPostal BuscarOficinaXDatos(string pCiudad, string pCalle, string pCP, string pPais, int pNroCalle)
        {
            OficinaPostal ofi = null;

            foreach(OficinaPostal item in this.listaOficinasPostales)
            {
                if (item.Ciudad.ToLower() == pCiudad.ToLower() && item.Calle.ToLower() == pCalle.ToLower() &&
                    item.CodPostal.ToLower() == pCP.ToLower() && item.Pais.ToLower() == pPais.ToLower() && item.Numero == pNroCalle) 
                {
                    ofi = item;
                }
            }

            return ofi;
        }

        // Busca la oficina postal por NumeroOficina, devuelve la oficina encontrada o null si no existe
        public OficinaPostal BuscarOficinaXID(int pNroOficina)
        {
            OficinaPostal ofi = null;

            foreach (OficinaPostal item in this.listaOficinasPostales)
            {
                if (item.NroOficina == pNroOficina) ofi = item;
            }

            return ofi;
        }

        #endregion
    }

    }

