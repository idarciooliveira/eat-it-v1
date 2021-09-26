using System.Collections.Generic;
using System.Linq;
using EAT.DAL.Interfaces;
using EAT.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EAT.DAL.Repository
{
    public class ProdutoRepositorio : Repositorio<Produto>,IProdutoRepositorio
    {
        public List<Produto> GetProdutoWithCategory()
        {
            using (var context = new EatContext())
            {
                return context.Produto.Include(a=>a.Categoria).ToList();
            }
        }

        public override bool CanRemove(int entityid)
        {
            using (var context = new EatContext())
            {
                return context.Categoria.Any(a => a.Id.Equals(entityid));
            }
        }

        public List<Produto> GetMostSellerProduct()
        {
            using (var context = new EatContext())
            {
                var pedidos = context.Pedido.Where(a => a.EstadoId == 4);
                var items = pedidos.SelectMany(a => a.Item).Include(a=>a.Produto.Categoria);
                var produtos = items.Select(a => a.Produto).Include(a=>a.Categoria).ToList();
                return produtos;
            }
        }
    }
}
