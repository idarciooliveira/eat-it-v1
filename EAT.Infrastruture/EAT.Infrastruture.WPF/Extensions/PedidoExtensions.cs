using System;
using EAT.Models.Entities;
using System.Windows.Controls;

namespace EAT.Infrastruture.WPF.Extensions
{
    public static class PedidoExtensions
    {
        public static void SeachOnDataGrid(ItemCollection itemCollection, int codePedido)
        {
            if (codePedido == 0)
                itemCollection.Filter = a => (a as Pedido)?.Id != 0;
            else
                itemCollection.Filter = o => (o as Pedido)?.Id == codePedido;
        }

        public static void SeachByDateOnDataGrid(ItemCollection itemCollection, DateTime date)
        {
            itemCollection.Filter = o => (o as Pedido)?.DataDoPedido
                                         .ToString().Contains(date.ToString()) ?? false;
        }
    }
}
