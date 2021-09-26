using System.Collections.Generic;
using System.Linq;
using EAT.DAL.Interfaces;
using EAT.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EAT.DAL.Repository
{
    public class ClienteRepositorio : Repositorio<Cliente>,IClienteRepositorio
    {
        public List<Cliente> GetClienteWithMorada()
        {
            using (var context = new EatContext())
            {
                return context.Cliente.Include(a => a.Morada).ToList();
            }
        }

        public List<Cliente> GetClienteWithPedido()
        {
            using (var context = new EatContext())
            {
                return context.Cliente.Include(a => a.Morada).Include(a => a.Pedido).ToList();
            }
        }
    }
}
