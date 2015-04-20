using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    abstract class Envio
    {
        #region Atributos
        //fijarme si protected estaba bien para las clases base, para que se pasen a sus derivadas
        protected int nroEnvio;
        protected static int ultNroEnvio; //necesito hacer una propiedad de esto? creo que lo uso solo internamente
        protected string estado;
        protected string nombreRecibio;
        protected string firmaRecibio; // IMAGEN!!!
        protected Cliente cliente;
        protected Direccion dirOrigen;
        protected string nombreDestinatario;
        protected Direccion dirDestino;
        protected List<EtapaEnvio> etapasDelEnvio;
        
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

        internal Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        internal Direccion DirOrigen
        {
            get { return dirOrigen; }
            set { dirOrigen = value; }
        }

        public string NombreDestinatario
        {
            get { return nombreDestinatario; }
            set { nombreDestinatario = value; }
        }

        internal Direccion DirDestino
        {
            get { return dirDestino; }
            set { dirDestino = value; }
        }

        internal List<EtapaEnvio> EtapasDelEnvio
        {
            get { return etapasDelEnvio; }
            set { etapasDelEnvio = value; }
        }

        #endregion

        #region Constructor

        public Envio(string pNomRecibio, string pFirma, Cliente pCliente, Direccion pDirOrigen, string pNomDestinatario, Direccion pDirDestino, DateTime pFechaIngreso, OficinaPostal pOficinaIngreso) // <-- firmaRecibio: imagen!
        {
            this.NroEnvio = Envio.ultNroEnvio;
            Envio.ultNroEnvio += 1; // si pongo una propiedad en el atributo, cambiar aca <---
            this.Estado = "En origen";
            this.NombreRecibio = pNomRecibio;
            this.FirmaRecibio = pFirma; // <<---- firma: imagen!
            this.Cliente = pCliente;
            this.DirOrigen = pDirOrigen;
            this.NombreDestinatario = pNomDestinatario;
            this.DirDestino = pDirDestino;
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
