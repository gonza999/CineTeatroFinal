using CineTeatroItalianoLobos.Entities;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioVentasTickets:IRepositorio<VentaTicket>
    {
        VentaTicket GetVentaTicketPorId(int ventaId, int ticketId);
        bool Existe(Venta venta, Ticket ticket);
        bool EstaRelacionado(Venta venta, Ticket ticket);
        VentaTicket GetVentaTicket(Venta venta, Ticket ticket);
        List<int> GetLista(int ventaId);
        List<int> GetListaVentas(List<Ticket> listaTickets);
    }
}
