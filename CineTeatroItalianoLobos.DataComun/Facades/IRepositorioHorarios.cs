using CineTeatroItalianoLobos.Entities;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioHorarios:IRepositorio<Horario>
    {
   
     
        List<Horario> GetLista(Evento evento);
   
        Horario GetHorarioPorId(int v);
    }
}
