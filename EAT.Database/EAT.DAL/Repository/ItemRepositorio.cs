using System.Collections.Generic;
using System.Linq;
using EAT.DAL.Interfaces;
using EAT.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EAT.DAL.Repository
{
    public class ItemRepositorio : Repositorio<Item>, IItemRepositorio
    {
        public List<Item> GetItemsWithProdutos()
        {
            using (var context = new EatContext())
            {
                return context.Item.Include(a => a.Produto).ToList();
            }
        }
    }
}
