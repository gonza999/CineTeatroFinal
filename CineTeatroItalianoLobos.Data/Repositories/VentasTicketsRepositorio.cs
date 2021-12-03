using CineTeatroItalianoLobos.DataComun.Facades;
using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Data.Repositories
{
    public class VentasTicketsRepositorio : IRepositorioVentasTickets
    {
        private readonly CineTeatroDbContext _context;

        public VentasTicketsRepositorio(CineTeatroDbContext context)
        {
            _context = context;
        }
        public void Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(Venta venta, Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(VentaTicket TEntity)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Venta venta, Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public bool Existe(VentaTicket TEntity)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad()
        {
            throw new NotImplementedException();
        }

        public List<int> GetLista(int ventaId)
        {
            throw new NotImplementedException();
        }

        public List<VentaTicket> GetLista(int registros, int pagina)
        {
            throw new NotImplementedException();
        }

        public List<int> GetListaVentas(List<Ticket> listaTickets)
        {
            throw new NotImplementedException();
        }

        public VentaTicket GetTEntityPorId(int id)
        {
            throw new NotImplementedException();
        }

        public VentaTicket GetVentaTicket(Venta venta, Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public VentaTicket GetVentaTicketPorId(int ventaId, int ticketId)
        {
            throw new NotImplementedException();
        }

        public void Guardar(VentaTicket ventaTicket)
        {
            try
            {
                if (ventaTicket.Ticket != null)
                {
                    ventaTicket.Ticket = _context.Tickets.FirstOrDefault(t => t.TicketId == ventaTicket.TicketId);
                    _context.Tickets.Attach(ventaTicket.Ticket);
                }
                if (ventaTicket.Venta != null)
                {
                    ventaTicket.Venta = _context.Ventas.FirstOrDefault(v => v.VentaId == ventaTicket.VentaId);
                    _context.Ventas.Attach(ventaTicket.Venta);
                }
                _context.VentasTickets.Add(ventaTicket);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
