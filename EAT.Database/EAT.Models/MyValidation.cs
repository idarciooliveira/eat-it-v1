using System;
using System.Text.RegularExpressions;

namespace EAT.Models
{
    public class MyValidation
    {
        public static void ValidateTelefone(string value)
        {
            if (string.IsNullOrEmpty(value))
                return;
            var regex = new Regex(@"^\D?(\d{3})\D?\D?(\d{3})\D?(\d{3})$");
            if (regex.Match(value) == Match.Empty)
                throw new ArgumentException("Número Inválido");
        }


    }
}
