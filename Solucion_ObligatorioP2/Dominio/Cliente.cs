﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Cliente : Usuario
    {
        #region Atributos

        private string telefono;
        private Direccion direccion;

        #endregion

        #region Properties

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }


        internal Direccion Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        #endregion

        #region Constructor

        public Cliente(string pUser, string pPassword, string pNombre, string pApellido, string pTelefono, string pDocumento, Direccion pDireccion)
            : base(pUser, pDocumento, pPassword, pNombre, pApellido)
        {
            this.telefono = pTelefono;
            this.direccion = pDireccion;
        }

        #endregion

        #region Comportamiento
        #endregion
    }
}