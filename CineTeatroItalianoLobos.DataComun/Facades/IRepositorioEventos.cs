using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioEventos:IRepositorio<Evento>
    {
        List<Evento> BuscarEvento(string text);
        void AnularEvento(int eventoId);
        List<Evento> GetLista();
        int GetCantidad(Func<Evento, bool> p);
    }
}
