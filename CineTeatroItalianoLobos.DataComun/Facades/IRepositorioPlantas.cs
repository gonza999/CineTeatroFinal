using CineTeatroItalianoLobos.Entities;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioPlantas:IRepositorio<Planta>
    {
        Planta GetPlanta(string nombrePlanta);
        List<Planta> BuscarPlanta(string planta);
        List<Planta> GetLista();
    }
}
