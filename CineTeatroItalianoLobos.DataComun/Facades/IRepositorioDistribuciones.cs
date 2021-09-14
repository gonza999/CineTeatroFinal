using CineTeatroItalianoLobos.Entities;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioDistribuciones:IRepositorio<Distribucion>
    {
        Distribucion GetDistribucion(string nombreDistribucion);
        List<Distribucion> BuscarDistribucion(string distribucion);
    }
}
