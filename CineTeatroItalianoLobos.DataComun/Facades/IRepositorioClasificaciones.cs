using CineTeatroItalianoLobos.Entities;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioClasificaciones:IRepositorio<Clasificacion>
    {
        Clasificacion GetClasificacion(string nombreClasificacion);
        List<Clasificacion> BuscarClasificacion(string clasificacion);
        List<Clasificacion> GetLista();
    }
}
