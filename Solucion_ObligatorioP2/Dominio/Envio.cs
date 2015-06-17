using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dominio
{
    public abstract class Envio :IComparable <Envio>, IComparer<Envio>
    {
        #region Atributos
        protected int nroEnvio;
        protected static int ultNroEnvio = 1; //necesito hacer una propiedad de esto? creo que lo uso solo internamente
        protected string nombreRecibio;
        protected string firmaRecibio; // IMAGEN!!!
        protected string nombreDestinatario;
        protected Direccion dirDestinatario;
        protected List<EtapaEnvio> etapasDelEnvio;
        protected decimal precioFinal;
        private float peso; // para paquetes se guarda en Kg, para documentos en Gramos (pero en ambos se ingresa en Kg).
        private DateTime fechaIngreso;

        #endregion
        
        #region Properties

        public int NroEnvio
        {
            get { return nroEnvio; }
            set { nroEnvio = value; } // si es un autonumerado, no deberia tener un set, no?
        }

        public string NombreRecibio
        {
            get { return nombreRecibio; }
            set { nombreRecibio = value; }
        }

        public string FirmaRecibio
        {
            get { return firmaRecibio; }
            set { firmaRecibio = value; }
        }

        public string NombreDestinatario
        {
            get { return nombreDestinatario; }
            set { nombreDestinatario = value; }
        }

        public Direccion DirDestinatario
        {
            get { return dirDestinatario; }
            set { dirDestinatario = value; }
        }

        public List<EtapaEnvio> EtapasDelEnvio
        {
            get { return etapasDelEnvio; }
            set { etapasDelEnvio = value; }
        }
        public decimal PrecioFinal
        {
            get { return precioFinal; }
            set { precioFinal = value; }
        }

        public float Peso
        {
            get { return peso; }
            set { peso = value; }
        }

        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }

        #endregion

        #region Constructor

        // constructor convencional
        public Envio(string pNomDestinatario, Direccion pDirDestino, DateTime pFechaIngreso, OficinaPostal pOficinaIngreso) // <-- firmaRecibio: imagen!
        {
            this.NroEnvio = Envio.ultNroEnvio;
            Envio.ultNroEnvio += 1; // si pongo una propiedad en el atributo, cambiar aca <---
            this.NombreDestinatario = pNomDestinatario;
            this.DirDestinatario = pDirDestino;
            this.EtapasDelEnvio = new List<EtapaEnvio>();
            
            // si se crea un envio nuevo, en el constructor, de forma automática, se crea la primer 
            // etapa del envio, por eso este constructor toma como parametros tambien la fecha de ingreso
            // y la oficina en la que ingresó:
            EtapaEnvio unaEtapa = new EtapaEnvio(pFechaIngreso, EtapaEnvio.Etapas.EnOrigen, pOficinaIngreso);
           
            // agrego esa etapa en la lista de etapas recorridas de este envío
            this.EtapasDelEnvio.Add(unaEtapa);
            this.FechaIngreso = this.etapasDelEnvio[0].FechaIngreso;

        }

        // constructor para simulación
        public Envio()
        {

        }

        #endregion

        #region Comportamiento

        // forma de implementación depende de tipo de envío
        public abstract decimal CalcularPrecioFinal();

        // agregar etapas de rastreo al envío. Es polimórfico para EnvioDocumento, porque Documento necesita corroborar quien 
        // recibe el envio para agregarla (ver metodo en EnvioDocumento)
        public virtual bool AgregarEtapa(DateTime pFechaIngreso, EtapaEnvio.Etapas pEtapa, OficinaPostal pUbicacion, 
                                        string pFirmaRecibio, string pNombreRecibio, out string pMensajeError) 
        {
            string mensajeError = "";
            bool sePuedeAgregar = false;
            EtapaEnvio etapaActual = this.ObtenerEtapaActual();

            if (pFechaIngreso >= etapaActual.FechaIngreso)
            {
                // como EnOrigen se crea automaticamente con la creación del envío, no se puede utilizar nunca
                if (pEtapa != EtapaEnvio.Etapas.EnOrigen)
                {
                    // revisa secuencialidad
                    if (pEtapa >= etapaActual.Etapa)
                    {
                        // revisa si la etapa actual es igual que la anterior, porque solo voy a permitir esto para la etapa enTransito
                        if (etapaActual.Etapa == pEtapa)
                        {
                            // si la etapa actual es enTransito, se va a poder solo si estan en != oficinas
                            if (pEtapa == EtapaEnvio.Etapas.EnTransito)
                            {
                                // si la oficina es la misma que la anterior no deja ingresar la etapa (esto es para todos menos pEtapa = Entregado)
                                if (etapaActual.Ubicacion != pUbicacion)
                                {
                                    sePuedeAgregar = true;
                                }
                                else mensajeError = "La oficina postal no puede ser igual a la etapa anterior excepto para Entregado";
                            }
                            else mensajeError = "La etapa de envío no puede ser igual a la anterior a menos que el envío esté en tránsito";
                        }
                        // si la anterior y la que se pretende ingresar no son iguales (o sea, la nueva es mayor que la actual)
                        else
                        {
                            // si la etapa actual es Origen o Transito y es != de la nueva
                            if (etapaActual.Etapa == EtapaEnvio.Etapas.EnOrigen || etapaActual.Etapa == EtapaEnvio.Etapas.EnTransito)
                            {
                                // no pasar a Entregado desde una etapa diferente que no sea ParaEntregar
                                if (pEtapa == EtapaEnvio.Etapas.Entregado)
                                {
                                    mensajeError = "Aún no se puede entregar este envío porque se encuentra enOrigen/enTránsito";
                                }
                                // si quiero pasar a ParaEntregar, tengo que checkear que la direccion de la oficina final sea
                                // distinta que donde entró el emvio inicialmente
                                else if (pEtapa == EtapaEnvio.Etapas.ParaEntregar)
                                {
                                    if (pUbicacion != this.DevolverEtapaEnOrigen().Ubicacion)
                                    {
                                        sePuedeAgregar = true;
                                    }
                                    else mensajeError = "No se puede entregar un envío en la misma oficina que la de origen";
                                }
                                else
                                {
                                    if (pUbicacion != etapaActual.Ubicacion)
                                    {
                                        sePuedeAgregar = true;
                                    }
                                    else mensajeError = "La oficina postal no puede ser igual a la etapa anterior excepto para Entregado";
                                }
                            }
                            // si voy a agregar etapa Entregado (estando en ParaEntregar), tiene que ser en la misma oficina
                            else if (etapaActual.Etapa == EtapaEnvio.Etapas.ParaEntregar)
                            {
                                if (etapaActual.Ubicacion == pUbicacion)
                                {
                                    sePuedeAgregar = true;
                                }
                                else mensajeError = "El envío se debe entregar en la misma oficina donde se categorizó Para Entregar";
                            }
                        }
                    }
                    else mensajeError = "La etapa seleccionada ya no se puede ingresar para este envio";
                }
                else mensajeError = "La etapa seleccionada ya no se puede ingresar para este envio";
            }
            else mensajeError = "La fecha ingresada tiene que ser igual o posterior a la ingresada en la etapa previa";
            
            if (sePuedeAgregar)
            {
                EtapaEnvio etp = new EtapaEnvio(pFechaIngreso, pEtapa, pUbicacion);
                if (pEtapa == EtapaEnvio.Etapas.Entregado)
                {
                    this.nombreRecibio = pNombreRecibio;
                    this.firmaRecibio = pFirmaRecibio;
                }

                this.EtapasDelEnvio.Add(etp);
                mensajeError = "Se ha agregado la nueva etapa exitosamente!!";
            }

            pMensajeError = mensajeError;
            return sePuedeAgregar;
        }

        // Busca la EtapaEnvio que representa el ingreso a oficina Postal, y retorna la fecha en que se realizó
        // y se obtiene la diferencia entre el día actual y la fecha de ingreso.
        public int ObtenerDiasDesdeIngreso()
        {
            DateTime fechaIng = DateTime.Now;

            foreach (EtapaEnvio etp in this.EtapasDelEnvio)
            {
                if (etp.Etapa == EtapaEnvio.Etapas.EnOrigen) 
                {
                    fechaIng = etp.FechaIngreso;
                }
            }
            TimeSpan time = DateTime.Now - fechaIng;

            int dias = time.Days;

            return dias;
        }

        // revisa las fechas de ingreso de cada etapaDeEnvio, para quedarse con la etapa que tiene la fecha más cercana al 
        // día actual (la ultima fecha encontrada), y devolver el enum de Etapas en que se encuentra esa Etapa, que es el estado 
        // actual del envio <----
        public EtapaEnvio ObtenerEtapaActual()
        {
            DateTime ultimaFecha = DateTime.MinValue;
            EtapaEnvio etapaActual = null;

            foreach (EtapaEnvio etp in this.etapasDelEnvio)
            {
                if (etp.FechaIngreso > ultimaFecha)
                {
                    etapaActual = etp;
                }
            }

            return etapaActual;
        }

        // devuelve la etapaEnvio que tiene el enum EnOrigen
        public EtapaEnvio DevolverEtapaEnOrigen ()
        {
            EtapaEnvio enOrigen = null;

            foreach (EtapaEnvio etapa in this.etapasDelEnvio)
            {
                if (etapa.Etapa == EtapaEnvio.Etapas.EnOrigen) enOrigen = etapa;
            }
            return enOrigen;
        }

        #endregion

        #region Implementacion Interfaces
      
        //Metodo que me compara envios por fechas de manera descendente
        //No es lógico ordenar por fecha de entregado si el envío puede no haberse entregado aún 
        //(si está para entregar en la oficina final). Por lo tanto, ordénenlos por fecha de ENVIADO de forma ascendente.
        int IComparable<Envio>.CompareTo(Envio env)
        {
            return this.EtapasDelEnvio[this.EtapasDelEnvio.Count - 1].FechaIngreso.CompareTo(env.EtapasDelEnvio[env.EtapasDelEnvio.Count - 1].FechaIngreso);      
        }

        //Me falta implementar este para el metodo listar envios en transito y con demora de 5 dias. Ordeno por fecha y por doc del cliente
        int IComparer<Envio>.Compare(Envio x, Envio y)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}
