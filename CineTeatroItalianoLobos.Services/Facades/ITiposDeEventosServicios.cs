using CineTeatroItalianoLobos.Entities;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.Services.Facades
{
    public interface ITiposDeEventosServicios
    {
        List<TipoEvento> GetLista(int registros, int pagina);
        TipoEvento GetTEntityPorId(int id);
        void Guardar(TipoEvento TEntity);
        bool Existe(TipoEvento TEntity);
        bool EstaRelacionado(TipoEvento TEntity);
        int GetCantidad();
        void Borrar(int id);
        TipoEvento GetTipoEvento(string nombreTipoEvento);
        List<TipoEvento> BuscarTipoEvento(string tipoevento);
    }
}
