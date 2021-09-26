using System.Collections.Generic;
using EAT.Models.Entities;

namespace EAT.DAL.Interfaces
{
    public interface IProdutoRepositorio : IRepositorio<Produto>
    {
        List<Produto> GetMostSellerProduct();
        List<Produto> GetProdutoWithCategory();
    }
}