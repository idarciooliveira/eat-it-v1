using System.Collections.Generic;
using EAT.Models.Entities;

namespace EAT.DAL.Interfaces
{
    public interface IPedidoRepositorio : IRepositorio<Pedido>
    {
        bool CanMakePedido(int clienteid);
        List<Pedido> GetRequestWithEstado();
        List<Pedido> GetSoldRequests();
        List<Pedido> GetRequestWithEstadoAndCliente();
        List<Pedido> GetRequestWithEstadoClienteAndMorada();
        bool EmptyTable(int tableNumber);
    }
}