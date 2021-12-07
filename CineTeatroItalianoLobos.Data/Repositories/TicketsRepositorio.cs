using CineTeatroItalianoLobos.DataComun.Facades;
using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            try
            {
                return _context.Tickets.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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
            try
            {
                return _context.Tickets
                    .OrderBy(t => t.FechaVenta)
                    .Skip(registros * (pagina - 1))
                    .Take(registros)
                    .ToList();

            }
            catch (Exception e)
            {

                throw new Exception("Error al leer");

            }
        }

        public List<Ticket> GetLista(Evento evento)
        {
            try
            {
                return _context.Tickets
                    .OrderBy(t => t.FechaVenta)
                    .Where(t=>t.Horario.EventoId==evento.EventoId)
                    .ToList();

            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }

        public List<Ticket> GetLista(Venta venta)
        {
            try
            {
                List<Ticket> lista = new List<Ticket>();
                foreach (var vt in venta.VentasTickets)
                {
                    Ticket t = vt.Ticket;
                    lista.Add(t);
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
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
                if (ticket.TicketId == 0)
                {
                    _context.Tickets.Add(ticket);
                }
                else
                {
                    var ticketInDb =
                        _context.Tickets.SingleOrDefault(t => t.TicketId == ticket.TicketId);
                    if (ticketInDb == null)
                    {
                        throw new Exception("Ticket inexistente");
                    }

                    ticketInDb.Anulada = ticket.Anulada;
                    ticketInDb.FechaVenta = ticket.FechaVenta;
                    ticketInDb.FormaPago = ticket.FormaPago;
                    ticketInDb.FormaVenta = ticket.FormaVenta;
                    ticketInDb.Horario = ticket.Horario;
                    ticketInDb.Importe = ticket.Importe;
                    ticketInDb.Localidad = ticket.Localidad;
                    ticketInDb.VentasTickets = ticket.VentasTickets;
                    _context.Entry(ticketInDb).State = EntityState.Modified;

                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar guardar un registro");
            }
        }
    }
}
