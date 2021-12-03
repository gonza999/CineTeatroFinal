using CineTeatroItalianoLobos.DataComun.Facades;
using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Data.Repositories
{
    public class TicketsRepositorio : IRepositorioTickets
    {
        private readonly CineTeatroDbContext _context;

        public TicketsRepositorio(CineTeatroDbContext context)
        {
            _context = context;
        }
        public void AnularTicket(int ticketId)
        {
            throw new NotImplementedException();
        }

        public void Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public void BorrarPorHorario(int id)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(Ticket TEntity)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Localidad localidad, Horario horario)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Ticket TEntity)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad()
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetLista(List<Horario> horarios)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetLista(Horario horario)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetLista(int registros, int pagina)
        {
            throw new NotImplementedException();
        }

        public Ticket GetTEntityPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Ticket ticket)
        {
            try
            {
                if (ticket.Localidad != null)
                {
                    ticket.Localidad = _context.Localidades.FirstOrDefault(l => l.LocalidadId == ticket.LocalidadId);
                    _context.Localidades.Attach(ticket.Localidad);
                }
                if (ticket.Horario != null)
                {
                    ticket.Horario = _context.Horarios.FirstOrDefault(h => h.HorarioId == ticket.HorarioId);
                    _context.Horarios.Attach(ticket.Horario);
                }
                if (ticket.FormaVenta != null)
                {
                    ticket.FormaVenta = _context.FormasVentas.FirstOrDefault(fv => fv.FormaVentaId == ticket.FormaVentaId);
                    _context.FormasVentas.Attach(ticket.FormaVenta);
                }
                if (ticket.FormaPago != null)
                {
                    ticket.FormaPago = _context.FormasPagos.FirstOrDefault(fp => fp.FormaPagoId == ticket.FormaPagoId);
                    _context.FormasPagos.Attach(ticket.FormaPago);
                }
                _context.Tickets.Add(ticket);
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar guardar un registro");
            }
        }
    }
}
