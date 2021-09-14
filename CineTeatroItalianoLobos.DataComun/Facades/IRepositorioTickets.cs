using CineTeatroItalianoLobos.Entities;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioTickets:IRepositorio<Ticket>
    {
        bool Existe(Localidad localidad, Horario horario);
        void AnularTicket(int ticketId);
        List<Ticket> GetLista(List<Horario> horarios);
        void BorrarPorHorario(int id);
        List<Ticket> GetLista(Horario horario);
    }
}
