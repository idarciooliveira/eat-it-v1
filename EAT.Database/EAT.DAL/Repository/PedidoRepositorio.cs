using System.Collections.Generic;
using System.Linq;
using EAT.DAL.Interfaces;
using EAT.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EAT.DAL.Repository
{
    public class PedidoRepositorio : Repositorio<Pedido>, IPedidoRepositorio
    {
        public bool CanMakePedido(int clienteid)
        {
            using (var context = new EatContext())
            {
                return context.Pedido.Any(a => a.ClienteId == clienteid 
                && a.EstadoId == 1 || a.EstadoId == 2);
            }
        }

        public List<Pedido> GetRequestWithEstadoClienteAndMorada()
        {
            using (var context = new EatContext())
            {
                return context.Pedido.Include(a => a.Estado).
                    Include(a => a.Cliente).Include(a=>a.Morada).ToList();
            }
        }

        public bool EmptyTable(int tableNumber)
        {
            using (var context = new EatContext())
            {
                return context.Pedido.Any(a => a.NumeroDaMesa == tableNumber && a.EstadoId == 2);
            }
        }

        public List<Pedido> GetRequestWithEstadoAndCliente()
        {
            using (var context = new EatContext())
            {
                return context.Pedido.Include(a => a.Estado).Include(a=>a.Cliente).ToList();
            }
        }

        public List<Pedido> GetRequestWithEstado()
        {
            using (var context = new EatContext())
            {
                return context.Pedido.Include(a => a.Estado).ToList();
            }
        }

        public List<Pedido> GetSoldRequests()
        {
            using (var context = new EatContext())
            {
                return context.Pedido.Where(a=>a.EstadoId == 4)
                    .Include(a => a.Estado).Include(a => a.Cliente).ToList();
            }
        }

    }
}
