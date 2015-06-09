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
        protected static int ultNroEnvio; //necesito hacer una propiedad de esto? creo que lo uso solo internamente
        protected string nombreRecibio;
        protected string firmaRecibio; // IMAGEN!!!
        protected string nombreDestinatario;
        protected Direccion dirDestinatario;
        protected List<EtapaEnvio> etapasDelEnvio;
        protected decimal precioFinal;
        private float peso; // para paquetes se guarda en Kg, para documentos en Gramos (pero en ambos se ingresa en Kg).

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
        
        #endregion

        #region Constructor

        // constructor convencional
        public Envio(string pNomRecibio, string pFirma, string pNomDestinatario, Direccion pDirDestino, DateTime pFechaIngreso, OficinaPostal pOficinaIngreso) // <-- firmaRecibio: imagen!
        {
            this.NroEnvio = Envio.ultNroEnvio;
            Envio.ultNroEnvio += 1; // si pongo una propiedad en el atributo, cambiar aca <---
            this.NombreRecibio = pNomRecibio;
            this.FirmaRecibio = pFirma; // <<---- firma: imagen!
            this.NombreDestinatario = pNomDestinatario;
            this.DirDestinatario = pDirDestino;
            this.EtapasDelEnvio = new List<EtapaEnvio>();
            
            // si se crea un envio nuevo, en el constructor, de forma automática, se crea la primer 
            // etapa del envio, por eso este constructor toma como parametros tambien la fecha de ingreso
            // y la oficina en la que ingresó:
            EtapaEnvio unaEtapa = new EtapaEnvio(pFechaIngreso, EtapaEnvio.Etapas.EnOrigen, pOficinaIngreso);
           
            // agrego esa etapa en la lista de etapas recorridas de este envío
            this.EtapasDelEnvio.Add(unaEtapa);

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
        public virtual bool AgregarEtapa(DateTime pFechaIngreso, EtapaEnvio.Etapas pEtapa, OficinaPostal pUbicacion, string pNombreRecibio) 
        {
            EtapaEnvio etp = new EtapaEnvio(pFechaIngreso, pEtapa, pUbicacion);
            this.EtapasDelEnvio.Add(etp);

            return true;
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
        
        #endregion

        #region Implementacion Interfaces
      
        //Metodo que me compara envios por fechas de manera descendente
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
