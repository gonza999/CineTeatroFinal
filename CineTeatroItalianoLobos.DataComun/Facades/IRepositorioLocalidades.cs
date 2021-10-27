using CineTeatroItalianoLobos.Entities;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioLocalidades:IRepositorio<Localidad>
    {
      
        List<Localidad> GetLista(Ubicacion ubicacion);

        List<Localidad> GetLista(int fila);
    }
}
