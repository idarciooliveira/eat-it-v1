using System.Collections.Generic;
using EAT.Models.Entities;

namespace EAT.DAL.Interfaces
{
    public interface IFuncionarioRepositorio : IRepositorio<Funcionario>
    {
        List<Funcionario> GetFuncionariosWithUserType();
        Funcionario CheckFuncionarioLogin(Funcionario funcionario);
    }
}
