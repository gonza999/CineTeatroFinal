using CineTeatroItalianoLobos.DataComun.Facades;
using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Data.Repositories
{
    public class VentasRepositorio : IRepositorioVentas
    {
        private readonly CineTeatroDbContext _context;

        public VentasRepositorio(CineTeatroDbContext context)
        {
            _context = context;
        }
        public void AnularVenta(int ventaId)
        {
            throw new NotImplementedException();
        }

        public void Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Venta> BuscarVenta(string text)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(Venta TEntity)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Venta TEntity)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad()
        {
            try
            {
                return _context.Ventas.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Venta> GetLista(int registros, int pagina)
        {
            try
            {
                return _context.Ventas
                    .OrderBy(v => v.Fecha)
                    .Skip(registros * (pagina - 1))
                    .Take(registros)
                    .ToList();

            }
            catch (Exception e)
            {

                throw new Exception("Error al leer");

            }
        }

        public List<Venta> GetLista(Empleado empleado)
        {
            try
            {
                return _context.Ventas
                    .OrderBy(v => v.Fecha)
                    .Where(v=>v.EmpleadoId==empleado.EmpleadoId)
                    .ToList();

            }
            catch (Exception e)
            {

                throw new Exception("Error al leer");

            }
        }

        public Venta GetTEntityPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Venta GetVenta(string nombreVenta)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Venta venta)
        {
            try
            {
                var listaVentasTickets = new List<VentaTicket>();
                if (venta.Empleado != null)
                {
                    venta.Empleado = _context.Empleados.FirstOrDefault(e => e.EmpleadoId == venta.EmpleadoId);
                    _context.Empleados.Attach(venta.Empleado);
                }
                _context.Configuration.AutoDetectChangesEnabled = false;
                foreach (var vt in venta.VentasTickets)
                {
                    if (vt.TicketId > 0)
                    {
                        var ticket = _context.Tickets.FirstOrDefault(t => t.TicketId == vt.TicketId);
                        _context.Tickets.Attach(vt.Ticket);
                        var ventaTicket = vt;
                        ventaTicket.Ticket = ticket;
                        listaVentasTickets.Add(ventaTicket);
                    }
                }
                _context.Configuration.AutoDetectChangesEnabled = true;

                venta.VentasTickets = listaVentasTickets;
                _context.Ventas.Add(venta);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
