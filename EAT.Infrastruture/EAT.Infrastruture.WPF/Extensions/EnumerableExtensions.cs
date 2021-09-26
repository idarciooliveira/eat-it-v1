using System;
using System.Collections.Generic;

namespace EAT.Infrastruture.WPF.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ParaCada<T>(this IEnumerable<T> colecao, Action<T> acao)
        {
            foreach (var item in colecao)
            {
                acao.Invoke(item);
            }
        }
        public static bool PeloMenosUm<T>(this IEnumerable<T> colecao, Func<T,bool> filtro)
        {
            var resultado = false;
            foreach (var item in colecao)
            {
                resultado = filtro.Invoke(item);
                if(resultado) break;
            }
            return resultado;
        }
    }
}
