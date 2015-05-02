using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Administrador : Usuario
    {

        #region Constructor

        public Administrador(string pUser, string pPassword, string pNombre, string pApellido)
            : base(pUser, pPassword, pNombre, pApellido)
        {

        }
        #endregion

    }

}