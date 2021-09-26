using System.Collections.Generic;
using System.Linq;
using EAT.DAL.Interfaces;
using EAT.Models.Entities;

namespace EAT.DAL.Repository
{
    public class EstadoRepositorio : Repositorio<Estado>, IEstadoRepositorio
    {
        public List<Estado> GetRequestToChange()
        {
            using (var context = new EatContext())
            {
                return context.Estado.Where(a => a.Id == 2 && a.Id == 3 && a.Id == 4).ToList();
            }
        }
    }
}