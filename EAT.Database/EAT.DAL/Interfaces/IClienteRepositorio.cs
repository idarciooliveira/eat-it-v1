using System.Collections.Generic;
using EAT.Models.Entities;

namespace EAT.DAL.Interfaces
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        List<Cliente> GetClienteWithPedido();
        List<Cliente> GetClienteWithMorada();
    }
}