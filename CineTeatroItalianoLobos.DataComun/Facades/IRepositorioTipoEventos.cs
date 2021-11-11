using CineTeatroItalianoLobos.Entities;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioTipoEventos:IRepositorio<TipoEvento>
    {
        TipoEvento GetTipoEvento(string nombreTipoEvento);
        List<TipoEvento> BuscarTipoEvento(string tipoevento);
        List<TipoEvento> GetLista();
    }
}
