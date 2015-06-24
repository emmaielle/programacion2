using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class Sistema
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

            this.AltaAdministrador("admin1", "admin", "Administrador", "Administrador", "44893217", "25005050", "Somewhere st.", "0", "11034", "Montevideo", "Uruguay", "algo@gmail.com");
            this.AltaCliente("cliente1", "cliente", "Ceiling", "Cat", "41954388", "101010101", "Some St.", "123", "90210", "Miami", "USA", "this@sth.com");
            this.AltaCliente("cliente2", "cliente", "Marcela", "Snickers", "29394865", "294759200", "", "298", "AA5783", "Montevideo", "Uruguay", "cli@gmail.com");
            this.AltaCliente("cliente3", "cliente", "Ruben", "KitKat", "43329672", "101010101", "Some St.", "123", "90210", "Miami", "USA", "something@sth.com.uy");
            this.AltaCliente("emmaielle", "emmaielle", "Emme", "Elle", "44899895", "196435", "Secret st.", "333", "11700", "Montevideo", "Uruguay", "emm@sth.com");
            this.AltaCliente("magaxine", "magaxine", "Victoria", "Armario", "43838933", "099308375", "AvItalia", "4780", "11500", "Montevideo", "Uruguay", "mail@mail.com");
            this.AltaOficina("Miami", "Ocean Drive", "J134,", "Estados Unidos", "1234");
            this.AltaOficina("Montevideo", "Cuareim", "11200,", "Uruguay", "2234");
            this.AltaOficina("Buenos Aires", "9 de Julio", "1345,", "Argentina", "2346");
            this.AltaOficina("Berlin", "calle", "A134", "Alemania", "1345");
            this.AltaOficina("Montreal", "Calle", "A231", "Canada", "4321,");
            // 0
            this.AltaEnvioDocumento("43329672", "18 de Julio", "1203", "11700", "Montevideo", "Uruguay", "Jose Rodriguez", "Montevideo",
                "1503", "AA039", "Buenos Aires", "Argentina", new DateTime(2015, 5, 12), 1, 1.5F, true);
            // 1
            this.AltaEnvioDocumento("29394865", "18 de Julio", "1203", "11700", "Montevideo", "Uruguay", "Jose Rodriguez", "Montevideo",
                "1503", "AA039", "Buenos Aires", "Argentina", new DateTime(2015, 5, 12), 1, 1.5F, true);
            // 2
            this.AltaEnvioPaquete("41954388", "Jose Rodriguez", "18 de Julio", "1203", "11700", "Montevideo", "Uruguay", new DateTime(2015, 3, 15),
                                1, 12.3F, 13.2F, 40F, 12M, true, 1F, "Es una caja");
            // 3
            this.AltaEnvioPaquete("41954388", "Ariel Arrosa", "Mercedes", "1023", "1400", "Montevideo", "Uruguay", new DateTime(2015, 2, 10),
                                3, 10.3F, 3.2F, 7F, 10, false, 6F, "Es un paquete");
            // 4
            this.AltaEnvioPaquete("41954388", "Mateo Benitez", "Paraguay", "1023", "1400", "Montevideo", "Uruguay", new DateTime(2015, 1, 3),
                                3, 10.3F, 3.2F, 7F, 10M, false, 6F, "Es un paquete");
            // 5
            this.AltaEnvioPaquete("41954388", "Neko MrMuffin", "San Martin", "3384", "11700", "Montevideo", "Uruguay", new DateTime(2015, 1, 3),
                                3, 10.3F, 3.2F, 7F, 10M, false, 8F, "Es una caja con comida de gatos, catnip y un rascador");

            //Actualizo envio
            // datos agregados para consulta de envios en transito ingresados hace mas de 5 dias y para consulta de envios paraEntregar
            string result;
            this.listaEnvios[0].AgregarEtapa(new DateTime(2015, 6, 10), EtapaEnvio.Etapas.EnTransito, this.listaOficinasPostales[1], "", "", out result);
            this.listaEnvios[1].AgregarEtapa(new DateTime(2015, 6, 1), EtapaEnvio.Etapas.EnTransito, this.listaOficinasPostales[2], "", "", out result);
            this.listaEnvios[2].AgregarEtapa(new DateTime(2015, 6, 6), EtapaEnvio.Etapas.EnTransito, this.listaOficinasPostales[4], "", "", out result);
            this.listaEnvios[3].AgregarEtapa(new DateTime(2015, 6, 8), EtapaEnvio.Etapas.EnTransito, this.listaOficinasPostales[0], "", "", out result);
            this.listaEnvios[4].AgregarEtapa(new DateTime(2015, 5, 9), EtapaEnvio.Etapas.EnTransito, this.listaOficinasPostales[1], "", "", out result);
            this.listaEnvios[4].AgregarEtapa(new DateTime(2015, 6, 11), EtapaEnvio.Etapas.ParaEntregar, this.listaOficinasPostales[0], "", "", out result);
            this.listaEnvios[4].AgregarEtapa(new DateTime(2015, 6, 11), EtapaEnvio.Etapas.Entregado, this.listaOficinasPostales[0], "21234.png", "Mateo Benitez", out result);
            this.listaEnvios[5].AgregarEtapa(new DateTime(2015, 3, 12), EtapaEnvio.Etapas.EnTransito, this.listaOficinasPostales[3], "", "", out result);
            this.listaEnvios[5].AgregarEtapa(new DateTime(2015, 5, 15), EtapaEnvio.Etapas.ParaEntregar, this.listaOficinasPostales[1], "", "", out result);
        }

        #endregion

        #region Clientes

        /*TODO: agregar controles y manejar exceptions */

        // Recibe datos para crear un cliente, crea el cliente y su dirección, lo agrega a la lista de usuarios y de clientes y devuelve el 
        // cliente nuevo o el ya existente
        public Usuario AltaCliente(string pUsr, string pPass, string pNom, string pApell, string pDoc, string pTel, string pCalle, string pNum,
                                string pCP, string pCiu, string pPais, string pMail)
        {
            Usuario encontro = BuscarCliente(pDoc);
            Usuario cli = null;

            if (encontro == null)
            {
                Direccion dir = new Direccion(pCalle, pNum, pCP, pCiu, pPais);
                cli = new Usuario(pUsr, pPass, pNom, pApell, pDoc, pTel, dir, false, pMail);

                if (this.listaClientes == null) this.listaClientes = new List<Usuario>();
                this.listaClientes.Add(cli);
                if (this.listaUsuarios == null) this.listaUsuarios = new List<Usuario>();
                this.listaUsuarios.Add(cli);
            }
            else cli = encontro;

            return cli;

        }

        /*Dado una cedula, se recorre la lista de clientes para buscarlo. Retorna cliente encontrado o null*/
        public Usuario BuscarCliente(string pCi)
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

        #endregion

        #region Administradores

        /*TODO: agregar controles y manejar exceptions*/

        // Recibe datos para crear un Admin, crea el admin y lo agrega a la lista de usuarios y de admins. Devuelve el admin nuevo o 
        // el ya existente
        public Usuario AltaAdministrador(string pUsr, string pPass, string pNombre, string pApellido, string pDoc, string pTelefono,
            string pCalle, string pNum, string pCP, string pCiu, string pPais, string pMail)
        {
            Usuario encontro = BuscarAdmin(pDoc);
            Usuario admin = null;

            if (encontro == null)
            {
                Direccion dir = new Direccion(pCalle, pNum, pCP, pCiu, pPais);
                admin = new Usuario(pUsr, pPass, pNombre, pApellido, pDoc, pTelefono, dir, true, pMail);

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

        // busca usuario (ya sea admin o cliente) por su nombre de usuario elegido. Devuelve el usuario o null //
        public Usuario BuscarUsuarioPorUsername(string pUser)
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

        // toma parametros que corresponden a las propiedades de todos los atributos del usuario (inclusive su direccion) para modificar
        // alguno de ellos o todos
        public void ModificarUsuario(string pUsr, string pPass, string pNom, string pApell, string pTel, string pCalle, string pNum,
                                string pCP, string pCiu, string pPais, string pMail)
        {
            Usuario usr = this.BuscarUsuarioPorUsername(pUsr);

            usr.Nombre = pNom;
            usr.Password = pPass;
            usr.Apellido = pApell;
            usr.Telefono = pTel;
            usr.DireccionUsuario.Calle = pCalle;
            usr.DireccionUsuario.Numero = pNum;
            usr.DireccionUsuario.CodPostal = pCP;
            usr.DireccionUsuario.Ciudad = pCiu;
            usr.DireccionUsuario.Pais = pPais;
            usr.Mail = pMail;
        }

        public bool MailYaUsado(string pMail, string pMailAnterior)
        {
            bool retorno = false;

            if (this.listaUsuarios != null)
            {
                int i = 0;
                while (retorno == false && i < this.listaUsuarios.Count)
                {
                    if (this.listaUsuarios[i].Mail.ToLower() == pMail.ToLower())
                    {
                        if (this.listaUsuarios[i].Mail.ToLower() != pMailAnterior.ToLower())
                        {
                            retorno = true;
                        }
                    }
                    i++;
                }
            }

            return retorno;
        }

        #endregion

        #region Envios

        /* TODO: agregar controles y manejar exceptions */

        /* Busca el cliente con el numero de documento del usuario, si lo encuentra, recibe parametros para crear envio de documento, 
         * y lo agrega a la lista de envios. Y por ultimo, ese cliente agrega ese envio a su propia lista de envios */
        public int AltaEnvioDocumento(string pCliente, string pCalleOrigen, string pNroPtaOrigen, string pCPorigen, string pCiudOrigen,
                                    string pPaisOrigen, string pNomDestinatario, string pCalleDestino, string pNroPtaDestino,
                                    string pCPDestino, string pCiudDestino, string pPaisDestino, DateTime pFechaIngreso,
                                    int pNroOficinaIngreso, float pPesoKilos, bool pLegal)
        {
            Usuario cli = this.BuscarCliente(pCliente);
            int numeroEnvio = 0;

            if (cli != null)
            {
                Direccion dirOrigen = new Direccion(pCalleOrigen, pNroPtaOrigen, pCPorigen, pCiudOrigen, pPaisOrigen);
                Direccion dirDestino = new Direccion(pCalleDestino, pNroPtaDestino, pCPDestino, pCiudDestino, pPaisDestino);

                OficinaPostal oficinaIngreso = this.BuscarOficinaXID(pNroOficinaIngreso);

                EnvioDocumento env = new EnvioDocumento(dirOrigen, pNomDestinatario, dirDestino,
                                                       pFechaIngreso, oficinaIngreso, pPesoKilos, pLegal);

                if (this.listaEnvios == null) { this.listaEnvios = new List<Envio>(); }
                this.listaEnvios.Add(env);

                cli.AgregarEnvio(env);
                numeroEnvio = env.NroEnvio;
            }
            return numeroEnvio;
        }

        /* TODO: agregar controles y manejar exceptions */

        /* Busca el cliente con el numero de documento del usuario, si lo encuentra, recibe parametros para crear envio de paquetes, 
         * y lo agrega a la lista de envios. Y por ultimo, ese cliente agrega ese envio a su propia lista de envios */
        public int AltaEnvioPaquete(string pCliente, string pNomDestinatario, string pCalleDestino, string pNroPtaDestino,
                                    string pCPDestino, string pCiudDestino, string pPaisDestino, DateTime pFechaIngreso,
                                    int pNroOficinaIngreso, float pAlto, float pAncho, float pLargo,
                                    decimal pValorDecl, bool pSeguro, float pPesoKg, string pDescr)
        {
            Usuario cli = this.BuscarCliente(pCliente);
            int numeroEnvio = 0;

            if (cli != null)
            {
                Direccion dirDestino = new Direccion(pCalleDestino, pNroPtaDestino, pCPDestino, pCiudDestino, pPaisDestino);
                OficinaPostal oficinaIngreso = this.BuscarOficinaXID(pNroOficinaIngreso);

                EnvioPaquete env = new EnvioPaquete(pNomDestinatario, dirDestino, pFechaIngreso, oficinaIngreso,
                                                    pAlto, pAncho, pLargo, pValorDecl, pSeguro, pPesoKg, pDescr);

                if (this.listaEnvios == null) { this.listaEnvios = new List<Envio>(); }
                this.listaEnvios.Add(env);
                cli.AgregarEnvio(env);
                numeroEnvio = env.NroEnvio;

            }
            return numeroEnvio;
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

        // dandole de parámetro el numero de envio, busca si existe el envio. Si existe, 
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

        // retorna una lista de los envios de un cliente, dado como parámetro, que ya fueron entregados
        public List<Envio> ListarEnviosEntregados(string pDoc)
        {
            List<Envio> envEntregados = null;

            if (this.BuscarCliente(pDoc) != null)
            {
                Usuario cli = this.BuscarCliente(pDoc);
                envEntregados = cli.ListarEnviosEntregados();

            }
            return envEntregados;
        }

        // arma una lista de todos los envios enTrasito y que fueron ingresados hace mas de 5 dias para todos los clientes, 
        // esto lo hace llamando al metodo del mismo nombre en Usuario
        public List<Envio> EnviosEnTransitoAtrasados()
        {
            List<Envio> listaEnvAtrasados = new List<Envio>();

            if (this.listaClientes != null)
            {
                foreach (Usuario cli in this.listaClientes)
                {
                    List<Envio> listaClienteAtrasados = new List<Envio>();
                    listaClienteAtrasados = cli.EnviosEnTransitoAtrasados();

                    if (listaClienteAtrasados != null)
                    {
                        foreach (Envio env in listaClienteAtrasados)
                        {
                            listaEnvAtrasados.Add(env);
                        }
                    }
                }
            }
            Comparer_FechaIngresoASCdocDESC fchASCdocDESC = new Comparer_FechaIngresoASCdocDESC();

            if (listaEnvAtrasados != null)
            {
                listaEnvAtrasados.Sort(fchASCdocDESC);
            }

            return listaEnvAtrasados;
        }

        // Busca al cliente y si lo encuentra, le pide que le devuelva el decimal resultante del método TotalFacturadoEnIntervalo (en Usuario)    
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

        public List<Envio> EnviosQueSuperanMontoParaCliente(string pDoc, decimal pMonto)
        {
            List<Envio> listaEnvSuperanMonto = new List<Envio>();

            Usuario clienteDeInteres = this.BuscarCliente(pDoc);

            if (clienteDeInteres != null)
            {
                listaEnvSuperanMonto = clienteDeInteres.EnviosQueSuperanMonto(pMonto);
            }

            return listaEnvSuperanMonto;
        }

        // Utiliza el constructor alternativo de EnvioPaquete, que toma solo datos necesarios para calcular el precio final del envio.
        // Crea el objeto para devolver un decimal que corresponde al PrecioFinal del EnvioPaquete
        public decimal SimularEnvioPaquete(float pAlto, float pAncho, float pLargo, decimal pValorDecl,
                                            bool pSeguro, float pPesoKg)
        {
            EnvioPaquete simulPaquete = new EnvioPaquete(pAlto, pAncho, pLargo, pValorDecl, pSeguro, pPesoKg);
            decimal precioSimulado = simulPaquete.PrecioFinal;

            return precioSimulado;
        }

        // Utiliza el constructor alternativo de EnvioDocumento, que toma solo datos necesarios para calcular el precio final del envio.
        // Crea el objeto para devolver un decimal que corresponde al PrecioFinal del EnvioDocumento
        public decimal SimularEnvioDocumento(float pPesoKilos, bool pLegal)
        {
            EnvioDocumento simulDoc = new EnvioDocumento(pPesoKilos, pLegal);
            decimal precioSimulado = simulDoc.PrecioFinal;

            return precioSimulado;
        }

        public string BuscarClienteParaUnEnvio(int pNroEnvio) // <<<<<---------
        {
            string idCliente = "";

            Envio pEnvio = this.BuscarEnvio(pNroEnvio);

            if (this.listaClientes != null)
            {
                foreach (Usuario cli in this.listaClientes)
                {
                    if (cli.EnviosCliente != null)
                    {
                        foreach (Envio env in cli.EnviosCliente)
                        {

                            if (env.NroEnvio == pEnvio.NroEnvio)
                            {
                                idCliente = cli.Documento;
                            }
                        }
                    }
                }
            }
            return idCliente;
        }

        #endregion

        #region OficinaPostal

        // Crea una oficina postal luego de revisar si existe una oficina con los mismos datos, 
        // y la suma a la lista de oficinas postales del sistema. No devuelve nada.
        public void AltaOficina(string pCiudad, string pCalle, string pCP, string pPais, string pNro)
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
        public OficinaPostal BuscarOficinaXDatos(string pCiudad, string pCalle, string pCP, string pPais, string pNroCalle)
        {
            OficinaPostal ofi = null;

            if (this.listaOficinasPostales != null)
            {
                foreach (OficinaPostal item in this.listaOficinasPostales)
                {
                    if (item.DireccionOfiPostal.Ciudad.ToLower() == pCiudad.ToLower() &&
                        item.DireccionOfiPostal.Calle.ToLower() == pCalle.ToLower() &&
                        item.DireccionOfiPostal.CodPostal.ToLower() == pCP.ToLower() &&
                        item.DireccionOfiPostal.Pais.ToLower() == pPais.ToLower() && item.DireccionOfiPostal.Numero == pNroCalle)
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

        public List<int> TraerNrosDeOficinasPostales()
        {
            List<int> oficinasRetornadas = new List<int>();

            foreach (OficinaPostal ofi in this.listaOficinasPostales)
            {
                oficinasRetornadas.Add(ofi.NroOficina);
            }

            return oficinasRetornadas;
        }

        #endregion
    }

}

