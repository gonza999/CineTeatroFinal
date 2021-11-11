using CineTeatroItalianoLobos.Entities;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioDistribuciones : IRepositorio<Distribucion>
    {
        List<Distribucion> GetLista();
    }
}
