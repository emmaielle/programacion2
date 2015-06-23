using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Dominio.Utilidades
{
    public class Utilidades
    {
        #region Validaciones

        public static bool ChequearEsSoloNumero(string pString)
        {
            double nroDelString;
            bool resultado = double.TryParse(pString, out nroDelString);

            return resultado;
        }


        public static bool EsMail(string pMail)
        {
            bool resultado;
            resultado = Regex.IsMatch(pMail, @"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$", RegexOptions.IgnoreCase);

            return resultado;
        }

        #endregion
    }
}
