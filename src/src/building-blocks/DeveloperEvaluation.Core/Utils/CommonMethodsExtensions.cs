using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperEvaluation.Core.Utils
{
   public static class CommonMethodsExtensions
    {
        public static string FormatRG(this string texto) => CommonMethods.FormatRG(texto);
        public static string OnlyNumbers(this string numeros) => CommonMethods.OnlyNumbers(numeros);

    }
}
