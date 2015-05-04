using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class OficinaPostal
    {
        #region atributos

        private int nroOficina;
        private static int ultNroOficina;
        private string pais;
        private int numero;
        private string calle;
        private string ciudad;
        private string codPostal;

        #endregion

        #region propiedades

        public int NroOficina
        {
            get { return nroOficina; }
            set { nroOficina = value; }
        }

        public static int UltNroOficina
        {
            get { return OficinaPostal.ultNroOficina; } // no tiene set
        }

        public string Pais 
        {
            get { return pais; }
            set { pais = value; }
        }

        public int Numero
        {
            get { return numero; }
            set {numero = value;}
        }

        public string Calle
        {
            get { return calle; }
            set { calle = value; }
        }

        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        public string CodPostal
        {
            get { return codPostal; }
            set { codPostal = value; }
        }

        #endregion

        #region Constructor

        public OficinaPostal(string pPais, int pNumero, string pCalle, string pCiudad, string pCodPost)
        {
            OficinaPostal.ultNroOficina += 1;
            this.nroOficina = OficinaPostal.ultNroOficina;
            this.Pais = pPais;
            this.Numero = pNumero;
            this.Calle = pCalle;
            this.Ciudad = pCiudad;
            this.CodPostal = pCodPost;
        }

        #endregion
    }
}
