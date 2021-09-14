using CineTeatroItalianoLobos.Entities;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioUbicaciones : IRepositorio<Ubicacion>
    {
        Ubicacion GetUbicacion(string nombreUbicacion);
        List<Ubicacion> BuscarUbicacion(string ubicacion);
    }
}
