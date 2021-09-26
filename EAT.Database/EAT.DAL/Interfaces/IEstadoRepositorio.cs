using System.Collections.Generic;
using EAT.Models.Entities;

namespace EAT.DAL.Interfaces
{
    public interface IEstadoRepositorio : IRepositorio<Estado>
    {
        List<Estado> GetRequestToChange();
    }
}