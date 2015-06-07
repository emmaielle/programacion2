using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Direccion
    {
        #region Atributos

        private string calle;
        private string numero;
        private string codPostal;
        private string ciudad;
        private string pais;

        #endregion

        #region Properties

        public string Calle
        {
            get { return calle; }
            set { calle = value; }
        }
        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string CodPostal
        {
            get { return codPostal; }
            set { codPostal = value; }
        }

        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }

        #endregion

        #region Constructor

        public Direccion(string pCalle, string pNumero, string pCodPostal, string pCiudad, string pPais)
        {
            this.calle = pCalle;
            this.numero = pNumero;
            this.codPostal = pCodPostal;
            this.ciudad = pCiudad;
            this.pais = pPais;
        }

        #endregion

    }
}

