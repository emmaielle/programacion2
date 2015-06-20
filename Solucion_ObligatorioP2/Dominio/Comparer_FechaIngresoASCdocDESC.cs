using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Comparer_FechaIngresoASCdocDESC : IComparer<Envio>
    {
        //Metodo listar envios en transito y con demora de 5 dias. Ordeno por fecha de ingreso del envio (ASC) y por doc del cliente (DESC)
        public int Compare(Envio a, Envio b)
        {
            int resultado = 0;

            Envio uno = a as Envio;
            Envio otro = b as Envio;

            if (uno != null && otro != null)
            {
                resultado = uno.FechaIngreso.CompareTo(otro.FechaIngreso);

                if (resultado == 0)
                {
                    // no necesito verificar que no sea null, ni que sea un nro porque ya lo hice
                    int docUno = int.Parse(uno.DocCliente);
                    int docOtro = int.Parse(otro.DocCliente);

                    resultado = docOtro - docUno;
                }

            }

            return resultado;
        }

    }
}
