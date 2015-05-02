using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class  Sistema
    {
        #region Atributos
        private static Sistema instancia;
        private List<Cliente> listaClientes;
        private List<Administrador> listaAdmins;
        private List<Envio> listaEnvios;
        private List<EtapaEnvio> listaEtapasEnvio;
        private List<OficinaPostal> listaOficinasPostales;


        #endregion

        #region Properties
        public Sistema Instancia
        {
            get { return instancia; }
            set { instancia = value; }
        }
        #endregion

        #region Constructor
        public static Sistema InstanciaSistema() {

            if(Sistema.instancia == null)
            {
                Sistema.instancia = new Sistema();
            }
                return Sistema.instancia;


        }


        #endregion


    }

    }

