using CineTeatroItalianoLobos.Entities;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioHorarios:IRepositorio<Horario>
    {

        List<Horario> BuscarHorario(int eventoId);
        List<Horario> GetLista(Evento evento);
        List<Horario> GetLista();
    }
}
