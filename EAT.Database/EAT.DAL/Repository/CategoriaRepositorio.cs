using System.Linq;
using EAT.DAL.Interfaces;
using EAT.Models.Entities;

namespace EAT.DAL.Repository
{
    public class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {
        public override bool CanRemove(int entityid)
        {
            using (var context = new EatContext())
            {
                return context.Produto.Any(a => a.CategoriaId.Equals(entityid));
            }
        }
    }
}