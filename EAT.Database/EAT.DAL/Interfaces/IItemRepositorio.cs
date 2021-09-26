using System.Collections.Generic;
using EAT.Models.Entities;

namespace EAT.DAL.Interfaces
{
    public interface IItemRepositorio : IRepositorio<Item>
    {
        List<Item> GetItemsWithProdutos();
    }
}