using CineTeatroItalianoLobos.Entities;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioDistribucionesLocalidades:IRepositorio<DistribucionLocalidad>
    {
        List<DistribucionLocalidad> GetLista(int distribucionId);
    }
}
