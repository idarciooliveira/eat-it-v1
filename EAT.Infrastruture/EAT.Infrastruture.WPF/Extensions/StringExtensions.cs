using System;

namespace EAT.Infrastruture.WPF.Extensions
{
    public static class StringExtensions
    {
        public static NomeCompleto Extrair(this string Nome)
        {
            if (string.IsNullOrEmpty(Nome)) throw new NomeInvalidoException();
            Nome = Nome.Trim();
            var indice = Nome.IndexOf(" ", StringComparison.Ordinal);
            if (indice < 1) throw new NomeInvalidoException();
            var nomeCompleto = new NomeCompleto
            {
                Nome = Nome.Substring(0, indice).Trim(),
                SobreNome = Nome.Substring(indice).Trim()
            };
            return nomeCompleto;
        }
    }

    public struct NomeCompleto
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
    }
    public class NomeInvalidoException : InvalidOperationException
    {
        public NomeInvalidoException():base("So e permitido mais de um Nome")
        {
            
        }
    }
}
