using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Dominio
{
    public abstract class Envio
    {
        #region Atributos
        protected int nroEnvio;
        protected static int ultNroEnvio; //necesito hacer una propiedad de esto? creo que lo uso solo internamente
        protected string estado;
        protected string nombreRecibio;
        protected string firmaRecibio; // IMAGEN!!!
        protected Usuario cliente;
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

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
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

        public Usuario Cliente
        {
            get { return cliente; }
            set { cliente = value; }
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

        public Envio(string pNomRecibio, string pFirma, Usuario pCliente, string pNomDestinatario, Direccion pDirDestino, DateTime pFechaIngreso, OficinaPostal pOficinaIngreso) // <-- firmaRecibio: imagen!
        {
            this.NroEnvio = Envio.ultNroEnvio;
            Envio.ultNroEnvio += 1; // si pongo una propiedad en el atributo, cambiar aca <---
            this.Estado = "En origen";
            this.NombreRecibio = pNomRecibio;
            this.FirmaRecibio = pFirma; // <<---- firma: imagen!
            this.Cliente = pCliente;
            this.NombreDestinatario = pNomDestinatario;
            this.DirDestinatario = pDirDestino;
            this.EtapasDelEnvio = new List<EtapaEnvio>();
            
            // si se crea un envio nuevo, en el constructor, de forma automática, se crea la primer 
            // etapa del envio, por eso este constructor toma como parametros tambien la fecha de ingreso
            // y la oficina en la que ingresó:
            EtapaEnvio unaEtapa = new EtapaEnvio(pFechaIngreso, 1, pOficinaIngreso);
           
            // agrego esa etapa en la lista de etapas recorridas de este envío
            this.EtapasDelEnvio.Add(unaEtapa);

        }

        #endregion

        #region Comportamiento

        public abstract decimal CalcularPrecioFinal();

        public EtapaEnvio CrearNuevaEtapa(DateTime pFecha, int nroEtapa, OficinaPostal pOficinaUbicada)
        {
            EtapaEnvio otraEtapa = new EtapaEnvio(pFecha, nroEtapa, pOficinaUbicada);
            return otraEtapa;
        }

        public void AgregarEtapa(EtapaEnvio pNuevaEtapa)
        {
            this.EtapasDelEnvio.Add(pNuevaEtapa);
        }

        #endregion
    }
}
