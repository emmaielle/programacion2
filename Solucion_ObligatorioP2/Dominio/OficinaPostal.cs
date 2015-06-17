using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class OficinaPostal
    {
        #region Atributos

        private int nroOficina;
        private static int ultNroOficina;
        private Direccion direccionOfiPostal;

        #endregion

        #region Propiedades

        public int NroOficina
        {
            get { return nroOficina; }
            set { nroOficina = value; }
        }

        public static int UltNroOficina
        {
            get { return OficinaPostal.ultNroOficina; } // no tiene set
        }

        public Direccion DireccionOfiPostal
        {
            get { return direccionOfiPostal; }
            set { direccionOfiPostal = value; }
        }
        #endregion

        #region Constructor

        public OficinaPostal(string pPais, string pNumero, string pCalle, string pCiudad, string pCodPost)
        {
            OficinaPostal.ultNroOficina += 1;
            this.nroOficina = OficinaPostal.ultNroOficina;
            this.direccionOfiPostal = new Direccion(pCalle, pNumero, pCodPost, pCiudad, pPais);

        }

        #endregion

    }
}
