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

        private List<Usuario> listaClientes;
        private List<Usuario> listaAdmins;
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
       
        /*Reveer constructores*/
        public Usuario AltaCliente(string pUsr, string pPass, string pNom, string pApell, string pTel, string pDoc, string pCalle, int pNum, 
                                string pCP, string pCiu, string pPais) 
        {
            Usuario encontro = BuscarCliente(pDoc);
            Usuario cli = null;

            if (encontro == null)
            {
                Direccion dir = new Direccion(pCalle, pNum, pCP, pCiu, pPais);
               // cli = new Usuario(pUsr, pPass, pNom, pApell, pTel, pDoc, pDir, pEsAdmin);

          
                
                if (this.listaClientes == null) this.listaClientes = new List<Usuario>();
                this.listaClientes.Add(cli);
            }
            else cli = encontro;

            return cli;
            
        }

        /*Dado una cedula, se recorre la lista de clientes para buscarlo. Retorna cliente encontrado o null*/
        public Usuario BuscarCliente (string pCi) 
        {
            Usuario aux = null;
           
            int i = 0;
            // foreach
            while (i < this.listaClientes.Count && aux == null)
            {
                Usuario cli = this.listaClientes[i];
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
        public Usuario AltaAdministrador(string pUsr, string pPass, string pNombre, string pApellido, string pDoc, string pTelefono, string pDir, bool pEsAdmin)
        {
            Usuario encontro = BuscarAdmin(pDoc);
            Usuario admin = null;

            if (encontro == null)
            {
                //admin = new Usuario(pUsr, pPass, pNombre, pApellido, pDoc, pTelefono, pDir, pEsAdmin);

          

                if (this.listaAdmins == null) this.listaAdmins = new List<Usuario>();
                this.listaAdmins.Add(admin);
            }
            else admin = encontro;

            return admin;
        }

        /*Dado un documento, se recorre la lista de admins para buscarlo. Retorna admin encontrado o null*/
        public Usuario BuscarAdmin(string pDocumento) 
        {
            Usuario aux = null;

            int i = 0;
            // foreach
            while (i < this.listaAdmins.Count && aux == null)
            {
                Usuario admin = this.listaAdmins[i];
                if (admin.User == pDocumento) 
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
        public void AltaEnvioDocumento(string pNomRecibio, string pFirma, Usuario pCliente, Direccion pDirOrigen, string pNomDestinatario, 
                                 Direccion pDirDestino, DateTime pFechaIngreso, OficinaPostal pOficinaIngreso, float pPesoKilos, bool pLegal)
        {
            EnvioDocumento env = new EnvioDocumento(pNomRecibio, pFirma, pCliente, pDirOrigen, pNomDestinatario, pDirDestino, 
                                                            pFechaIngreso, pOficinaIngreso, pPesoKilos, pLegal);
            this.listaEnvios.Add(env);
         
        } // <<<--------- pensar de otra manera para unir ambos envios??


        /* TODO: agregar controles y manejar exceptions */
        /* Recibe parametros para crear envio de paquetes, y lo agrega a la lista de envios */
        public void AltaEnvioDocumento(string pNomRecibio, string pFirma, Usuario pCliente, Direccion pDirOrigen, string pNomDestinatario,
                                 Direccion pDirDestino, DateTime pFechaIngreso, OficinaPostal pOficinaIngreso, float pAlto, float pAncho,
                                 float pLargo, decimal pValorDecl, bool pSeguro, float pPesoKg, string pDescr)
        {
            EnvioPaquete env = new EnvioPaquete(pNomRecibio, pFirma, pCliente, pDirOrigen, pNomDestinatario, pDirDestino,
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
             //   listaEtapas = envioEncontrado.RastrearEnvio();
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

