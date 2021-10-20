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
    public class FormasVentasRepositorio:IRepositorioFormasVentas
    {
        private readonly CineTeatroDbContext _context;

        public FormasVentasRepositorio(CineTeatroDbContext context)
        {
            _context = context;
        }
        public void Borrar(int id)
        {
            FormaVenta formaVentaInDb = null;
            try
            {
                formaVentaInDb = _context.FormasVentas
                    .SingleOrDefault(fv => fv.FormaVentaId == id);
                if (formaVentaInDb == null) return;
                _context.Entry(formaVentaInDb).State = EntityState.Deleted;
            }
            catch (Exception e)
            {
                _context.Entry(formaVentaInDb).State = EntityState.Unchanged;
                throw new Exception(e.Message);
            }
        }

        public List<FormaVenta> BuscarFormaVenta(string formaVenta)
        {
            try
            {
                return _context.FormasVentas
                  .OrderBy(te => te.Descripcion)
                  .Where(te => te.Descripcion.Contains(formaVenta))
                  .AsNoTracking()
                  .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(FormaVenta formaVenta)
        {
            try
            {
                return _context.Tickets.Any(t => t.FormaVentaId == formaVenta.FormaVentaId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(FormaVenta formaVenta)
        {
            try
            {
                if (formaVenta.FormaVentaId == 0)
                {
                    return _context.FormasVentas.Any(fv => fv.Descripcion == formaVenta.Descripcion);
                }

                return _context.FormasVentas.Any(fv => fv.Descripcion == formaVenta.Descripcion
                                                         && fv.FormaVentaId != formaVenta.FormaVentaId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int GetCantidad()
        {
            try
            {
                return _context.FormasVentas.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<FormaVenta> GetLista(int registros, int pagina)
        {
            try
            {
                return _context.FormasVentas
                    .OrderBy(fv => fv.Descripcion)
                    .Skip(registros * (pagina - 1))
                    .Take(registros)
                    .AsNoTracking()
                    .ToList();

            }
            catch (Exception e)
            {

                throw new Exception("Error al leer");

            }
        }

        public FormaVenta GetTEntityPorId(int id)
        {
            try
            {
                return _context.FormasVentas.SingleOrDefault(fv => fv.FormaVentaId == id);
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }

        public FormaVenta GetFormaVenta(string nombreFormaVenta)
        {
            throw new System.NotImplementedException();
        }

        public void Guardar(FormaVenta formaVenta)
        {
            try
            {
                if (formaVenta.FormaVentaId == 0)
                {
                    _context.FormasVentas.Add(formaVenta);
                }
                else
                {
                    var formaVentaInDb =
                        _context.FormasVentas.SingleOrDefault(fv => fv.FormaVentaId == formaVenta.FormaVentaId);
                    if (formaVentaInDb == null)
                    {
                        throw new Exception("FormaVenta inexistente");
                    }

                    formaVentaInDb.Descripcion = formaVenta.Descripcion;
                    formaVentaInDb.Tickets = formaVenta.Tickets;
                    _context.Entry(formaVentaInDb).State = EntityState.Modified;

                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar guardar un registro");
            }
        }
    }
}
