using System.Collections.Generic;
using System.Linq;
using EAT.DAL.Interfaces;
using EAT.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EAT.DAL.Repository
{
    public class FuncionarioRepositorio : Repositorio<Funcionario>, IFuncionarioRepositorio
    {
        public List<Funcionario> GetFuncionariosWithUserType()
        {
            using (var context = new EatContext())
            {
                return context.Funcionario.Include(a => a.TipoDeUsuario).ToList();
            }
        }

        public Funcionario CheckFuncionarioLogin(Funcionario funcionario)
        {
            using (var context = new EatContext())
            {
                var existFuncionario = context.Funcionario
                    .Include(a=>a.TipoDeUsuario)
                    .FirstOrDefault(a => a.SenhaDeUsuario == funcionario.SenhaDeUsuario &&
                    a.NomeDeUsuario == funcionario.NomeDeUsuario);
                return existFuncionario;
            }
        }

    }
}