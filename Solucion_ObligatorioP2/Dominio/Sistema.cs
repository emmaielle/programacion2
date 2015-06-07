using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


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
        private List<Usuario> listaUsuarios;
        private List<Envio> listaEnvios;
        private List<OficinaPostal> listaOficinasPostales;

        #endregion

        #region Datos Iniciales

        void CargarDatosIniciales()
        {
            this.AltaAdministrador("admin1", "admin", "Administrador", "Administrador", "123456-7", "25005050", "Somewhere st.", "0", "11034", "Montevideo", "Uruguay");
            this.AltaCliente("cliente1", "cliente", "ElCliente", "ApellidoCliente", "1234567-8", "101010101", "Some St.", "123", "90210", "Miami", "USA");
            this.AltaCliente("cliente2", "cliente", "Jesus", "Livestrong", "2939486-5", "294759200", "", "298", "AA5783", "Montevideo", "Uruguay");
        }

        #endregion

        #region Clientes

        /*TODO: agregar controles y manejar exceptions. Ej: if ci no esta en la lista, add*/
        /*Recibe datos para crear un cliente, crea el cliente y su dirección, lo agrega a la lista y devuelve el cliente nuevo o ya existente */
       
        /*Reveer constructores*/
        public Usuario AltaCliente(string pUsr, string pPass, string pNom, string pApell, string pDoc, string pTel, string pCalle, string pNum, 
                                string pCP, string pCiu, string pPais)  
        {
            Usuario encontro = BuscarCliente(pDoc);
            Usuario cli = null;

            if (encontro == null)
            {
                Direccion dir = new Direccion(pCalle, pNum, pCP, pCiu, pPais);
                cli = new Usuario(pUsr, pPass, pNom, pApell, pDoc, pTel, dir, false);
                
                if (this.listaClientes == null) this.listaClientes = new List<Usuario>();
                this.listaClientes.Add(cli);
                if (this.listaUsuarios == null) this.listaUsuarios = new List<Usuario>();
                this.listaUsuarios.Add(cli);
            }
            else cli = encontro;

            return cli;
            
        }

        /*Dado una cedula, se recorre la lista de clientes para buscarlo. Retorna cliente encontrado o null*/
        public Usuario BuscarCliente (string pCi) 
        {
            Usuario aux = null;
           
            if (this.listaClientes != null)
            {
                foreach (Usuario cli in this.listaClientes)
                {
                    if (cli.Documento == pCi && cli.EsAdmin == false)
                    {
                        aux = cli;
                    }
                }
            }
            return aux;
        }

        public void ModificarUsuario(string pUsr, string pPass, string pNom, string pApell, string pTel, string pCalle, string pNum,
                                string pCP, string pCiu, string pPais)
        {
            Usuario usr = this.buscarUsuarioPorUsername(pUsr);

            usr.Nombre = pNom;
            usr.Password = pPass;
            usr.Apellido = pApell;
            usr.Telefono = pTel;
            usr.DireccionUsuario.Calle = pCalle;
            usr.DireccionUsuario.Numero = pNum;
            usr.DireccionUsuario.CodPostal = pCP;
            usr.DireccionUsuario.Ciudad = pCiu;
            usr.DireccionUsuario.Pais = pPais;
        }

        public List<Envio> ListarEnviosEntregados(string pDoc)
        {
            if (this.BuscarCliente (pDoc) != null)  {
               
                Usuario cli = this.BuscarCliente(pDoc);
                cli.ListarEnviosEntregados();
            
            }

            List<Envio> envEntregados = null;
            return envEntregados;
        }


        // Busca al cliente y si lo encuentra, le pide que le devuelva el decimal resultante del método TotalFacturadoEnIntervalo //    
        public decimal TotalFacturadoAClientePorIntervalo(string pDoc, DateTime pFechaInicio, DateTime pFechaFinal)
        {
            decimal total = 0M;

            Usuario cli = this.BuscarCliente(pDoc);

            if (cli != null)
            {
                total = cli.TotalFacturadoEnIntervalo(pFechaInicio, pFechaFinal);
            }

            return total;
        }

        #endregion

        #region Administradores

        /*TODO: agregar controles y manejar exceptions. Ej: if ci no esta en la lista, add*/
        /*Recibe datos para crear un Admin, crea el admin y lo agrega a la lista*/
        public Usuario AltaAdministrador(string pUsr, string pPass, string pNombre, string pApellido, string pDoc, string pTelefono, 
            string pCalle, string pNum, string pCP, string pCiu, string pPais)
        {
            Usuario encontro = BuscarAdmin(pDoc);
            Usuario admin = null;

            if (encontro == null)
            {
                Direccion dir = new Direccion(pCalle, pNum,pCP,pCiu,pPais);
                admin = new Usuario(pUsr, pPass, pNombre, pApellido, pDoc, pTelefono, dir, true);

                if (this.listaAdmins == null) this.listaAdmins = new List<Usuario>();
                this.listaAdmins.Add(admin);
                if (this.listaUsuarios == null) this.listaUsuarios = new List<Usuario>();
                this.listaUsuarios.Add(admin);
            }
            else admin = encontro;

            return admin;
        }

        /*Dado un documento, se recorre la lista de admins para buscarlo. Retorna admin encontrado o null*/
        public Usuario BuscarAdmin(string pDocumento) 
        {
            Usuario aux = null;

            if (this.listaAdmins != null)
            {
                foreach (Usuario adminAux in this.listaAdmins)
                {
                    if (adminAux.User == pDocumento && adminAux.EsAdmin == true)
                    {
                        aux = adminAux;
                    }
                }
            }
            return aux;
        }

        #endregion

        #region Usuario

        public Usuario buscarUsuarioPorUsername(string pUser)
        {
            Usuario usr = null;

            if (this.listaUsuarios != null)
            {
                foreach (Usuario usuLista in this.listaUsuarios)
                {
                    if (usuLista.User == pUser)
                    {
                        usr = usuLista;
                    }
                }
            }

            return usr;
        }

        #endregion

        #region Envios

        /* TODO: agregar controles y manejar exceptions */
        /* Busca el cliente con el numero de documento del usuario, si lo encuentra, recibe parametros para crear envio de documento, 
         * y lo agrega a la lista de envios. Y por ultimo, ese cliente agrega ese envio a su propia lista de envios */
        public void AltaEnvioDocumento(string pNomRecibio, string pFirma, string pCliente, Direccion pDirOrigen, string pNomDestinatario, 
                                 Direccion pDirDestino, DateTime pFechaIngreso, OficinaPostal pOficinaIngreso, float pPesoKilos, bool pLegal)
        {
            Usuario cli = this.BuscarCliente(pCliente);
            if (cli != null)
            {
                EnvioDocumento env = new EnvioDocumento(pNomRecibio, pFirma, pDirOrigen, pNomDestinatario, pDirDestino,
                                                                pFechaIngreso, pOficinaIngreso, pPesoKilos, pLegal);

                if (this.listaEnvios == null) { this.listaEnvios = new List<Envio>(); }
                this.listaEnvios.Add(env);

                cli.AgregarEnvio(env);

            }
         
        } 

        /* TODO: agregar controles y manejar exceptions */
        /* Busca el cliente con el numero de documento del usuario, si lo encuentra, recibe parametros para crear envio de paquetes, 
         * y lo agrega a la lista de envios. Y por ultimo, ese cliente agrega ese envio a su propia lista de envios */
        public void AltaEnvioPaquete(string pNomRecibio, string pFirma, string pCliente, string pNomDestinatario,
                                 Direccion pDirDestino, DateTime pFechaIngreso, OficinaPostal pOficinaIngreso, float pAlto, float pAncho,
                                 float pLargo, decimal pCostoBaseGr,decimal pValorDecl, bool pSeguro, float pPesoKg, string pDescr)
        {
            Usuario cli = this.BuscarCliente(pCliente);
           
            if (cli != null)
            {
                EnvioPaquete env = new EnvioPaquete(pNomRecibio, pFirma, pNomDestinatario, pDirDestino, pFechaIngreso, pOficinaIngreso,
                                                    pAlto, pAncho, pLargo, pCostoBaseGr, pValorDecl, pSeguro, pPesoKg, pDescr);

                if (this.listaEnvios == null) { this.listaEnvios = new List<Envio>(); }
                this.listaEnvios.Add(env);

                cli.AgregarEnvio(env);

            }

        }

        /*Dado un Nro de envio se recorre la lista de envios para buscarlo. Retorna Envio encontrado o null*/
        public Envio BuscarEnvio(int pId)
        {
            Envio aux = null;
            int i = 0;

            if (this.listaEnvios != null)
            {
                while (i < this.listaEnvios.Count && aux == null)
                {
                    Envio env = this.listaEnvios[i];
                    if (env.NroEnvio == pId)
                    {
                        aux = env;
                    }
                    i++;
                }
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
                listaEtapas = envioEncontrado.EtapasDelEnvio;
            }
            return listaEtapas;
        }
        // arma una lista de todos los envios que se encuentran en estado actual "EnTransito" (de acuerdo con el metodo
        // ObtenerEstadoActual, en Envio), y de ellos, toma aquellos que fueron ingresados hace mas de 5 dias en
        // la primer oficinaPostal por el cliente.
        public List<Envio> EnviosEnTransitoAtrasados()
        {
            List<Envio> listEnvios = null;

            if (this.listaEnvios != null)
            {
                foreach (Envio env in this.listaEnvios)
                {
                    if (env.ObtenerEtapaActual().Etapa == EtapaEnvio.Etapas.EnTransito)
                    {
                        int diasDesdeIngreso = env.ObtenerDiasDesdeIngreso();
                        if (diasDesdeIngreso > 5) { listEnvios.Add(env); }
                    }
                }
            }
            return listEnvios;
        }

        // Utiliza el constructor alternativo de EnvioPaquete, que toma solo datos necesarios para calcular el precio final del envio.
        // Crea el objeto para devolver un decimal que corresponde al PrecioFinal del EnvioPaquete
        public decimal simularEnvioPaquete(float pAlto, float pAncho, float pLargo, decimal pCostoBaseGr, decimal pValorDecl, 
                                            bool pSeguro, float pPesoKg)
        {
            EnvioPaquete simulPaquete = new EnvioPaquete(pAlto, pAncho, pLargo, pCostoBaseGr, pValorDecl, pSeguro, pPesoKg);
            decimal precioSimulado = simulPaquete.PrecioFinal;

            return precioSimulado;
        }

        // Utiliza el constructor alternativo de EnvioDocumento, que toma solo datos necesarios para calcular el precio final del envio.
        // Crea el objeto para devolver un decimal que corresponde al PrecioFinal del EnvioDocumento
        public decimal simularEnvioDocumento(float pPesoKilos, bool pLegal)
        {
            EnvioDocumento simulDoc = new EnvioDocumento(pPesoKilos, pLegal);
            decimal precioSimulado = simulDoc.PrecioFinal;

            return precioSimulado;
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

            if (this.listaOficinasPostales != null)
            {
                foreach (OficinaPostal item in this.listaOficinasPostales)
                {
                    if (item.Ciudad.ToLower() == pCiudad.ToLower() && item.Calle.ToLower() == pCalle.ToLower() &&
                        item.CodPostal.ToLower() == pCP.ToLower() && item.Pais.ToLower() == pPais.ToLower() && item.Numero == pNroCalle)
                    {
                        ofi = item;
                    }
                }
            }
            return ofi;
        }

        // Busca la oficina postal por NumeroOficina, devuelve la oficina encontrada o null si no existe
        public OficinaPostal BuscarOficinaXID(int pNroOficina)
        {
            OficinaPostal ofi = null;

            if (this.listaOficinasPostales != null)
            {
                foreach (OficinaPostal item in this.listaOficinasPostales)
                {
                    if (item.NroOficina == pNroOficina) ofi = item;
                }
            }
            return ofi;
        }

        #endregion

        #region Validaciones

        public bool ChequearEsSoloNumero(string pString)
        {
            int nroDelString;
            bool resultado = int.TryParse(pString, out nroDelString);

            return resultado;
        }

        public bool ChequearEsFormatoCedula(string pString)
        {
            string regEx = @"\d{7}-\d";
            var match = Regex.Match(pString, regEx);

            return match.Success;
        }

        #endregion
    }

    }

