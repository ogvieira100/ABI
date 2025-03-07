using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DeveloperEvaluation.Core.Utils
{
    public class CommonMethods
    {
        #region   " Strings "
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string OnlyNumbers(string? input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            int length = input.Length;
            char[] resultado = new char[length];
            int index = 0;

            for (int i = 0; i < length; i++)
            {
                char c = input[i];
                if (c >= '0' && c <= '9')
                {
                    resultado[index++] = c;
                }
            }
            return new string(resultado, 0, index);
        }


        public static string FormatCNPJ(string? cnpj)
        {
            string cnpjStr = OnlyNumbers(cnpj);
            if (string.IsNullOrEmpty(cnpjStr))
                return cnpjStr;

            int length = cnpjStr.Length;

            if (length == 0) return "0";

            if (length <= 2) return cnpjStr;

            if (length <= 5)
                return cnpjStr.Insert(length - 2, ".");

            if (length <= 8)
                return cnpjStr.Insert(length - 2, ".").Insert(length - 5, ".");

            if (length <= 12)
                return cnpjStr.Insert(length - 2, "/").Insert(length - 6, ".").Insert(length - 9, ".");

            return cnpjStr.Insert(length - 2, "-").Insert(length - 6, "/").Insert(length - 9, ".").Insert(length - 12, ".");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CPF"></param>
        /// <returns></returns>
        public static string FormatCPF(string CPF)
        {
            var cpf = OnlyNumbers(CPF);
            if (string.IsNullOrEmpty(cpf))
                return CPF;

            string cpfStr = cpf.ToString();
            int length = cpfStr.Length;

            if (length == 0) return "0";

            if (length <= 3) return cpfStr;

            if (length <= 6)
                return cpfStr.Insert(length - 3, ".");

            if (length <= 9)
                return cpfStr.Insert(length - 3, ".").Insert(length - 6, ".");

            return cpfStr.Insert(length - 2, "-").Insert(length - 5, ".").Insert(length - 8, ".");
        }

        public static string FormatRG(string texto)
        {

            string rgStr = OnlyNumbers(texto);
            if (string.IsNullOrEmpty(rgStr))
                return null;

            int length = rgStr.Length;

            if (length == 0) return "0"; // Garante pelo menos um dígito

            if (length <= 2) return rgStr; // Se tiver até 2 dígitos, retorna como está

            if (length <= 5)
                return rgStr.Insert(length - 2, ".");

            if (length <= 8)
                return rgStr.Insert(length - 2, ".").Insert(length - 5, ".");

            return rgStr.Insert(length - 1, "-").Insert(length - 4, ".").Insert(length - 7, ".");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static bool IsCpf(string cpf)
        {

            cpf = OnlyNumbers(cpf);

            if (string.IsNullOrEmpty(cpf))
                return false;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string email)
        {

            if (string.IsNullOrWhiteSpace(email)) return false;

            int atIndex = email.IndexOf('@');
            if (atIndex <= 0 || atIndex != email.LastIndexOf('@')) return false; // Deve ter apenas um '@' e não ser o primeiro caractere

            int dotIndex = email.LastIndexOf('.');
            if (dotIndex <= atIndex + 1 || dotIndex == email.Length - 1) return false; // Ponto deve vir após o '@' e não ser o último caractere

            return true;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        public static bool IsCnpj(string cnpj)
        {
            cnpj = OnlyNumbers(cnpj);

            if (string.IsNullOrEmpty(cnpj))
                return false;


            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);

        }

        #endregion



    }
}
