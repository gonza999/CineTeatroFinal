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
    public class FormasPagosRepositorio:IRepositorioFormasPagos
    {
        private readonly CineTeatroDbContext _context;

        public FormasPagosRepositorio(CineTeatroDbContext context)
        {
            _context = context;
        }
        public void Borrar(int id)
        {
            FormaPago formaPagoInDb = null;
            try
            {
                formaPagoInDb = _context.FormasPagos
                    .SingleOrDefault(fv => fv.FormaPagoId == id);
                if (formaPagoInDb == null) return;
                _context.Entry(formaPagoInDb).State = EntityState.Deleted;
            }
            catch (Exception e)
            {
                _context.Entry(formaPagoInDb).State = EntityState.Unchanged;
                throw new Exception(e.Message);
            }
        }

        public List<FormaPago> BuscarFormaPago(string formaPago)
        {
            try
            {
                return _context.FormasPagos
                  .OrderBy(te => te.Descripcion)
                  .Where(te => te.Descripcion.Contains(formaPago))
                  .AsNoTracking()
                  .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(FormaPago formaPago)
        {
            try
            {
                return _context.Tickets.Any(t => t.FormaPagoId == formaPago.FormaPagoId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(FormaPago formaPago)
        {
            try
            {
                if (formaPago.FormaPagoId == 0)
                {
                    return _context.FormasPagos.Any(fv => fv.Descripcion == formaPago.Descripcion);
                }

                return _context.FormasPagos.Any(fv => fv.Descripcion == formaPago.Descripcion
                                                         && fv.FormaPagoId != formaPago.FormaPagoId);
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
                return _context.FormasPagos.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<FormaPago> GetLista(int registros, int pagina)
        {
            try
            {
                return _context.FormasPagos
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

        public FormaPago GetTEntityPorId(int id)
        {
            try
            {
                return _context.FormasPagos.SingleOrDefault(fv => fv.FormaPagoId == id);
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }

        public FormaPago GetFormaPago(string nombreFormaPago)
        {
            throw new System.NotImplementedException();
        }

        public void Guardar(FormaPago formaPago)
        {
            try
            {
                if (formaPago.FormaPagoId == 0)
                {
                    _context.FormasPagos.Add(formaPago);
                }
                else
                {
                    var formaPagoInDb =
                        _context.FormasPagos.SingleOrDefault(fv => fv.FormaPagoId == formaPago.FormaPagoId);
                    if (formaPagoInDb == null)
                    {
                        throw new Exception("FormaPago inexistente");
                    }

                    formaPagoInDb.Descripcion = formaPago.Descripcion;
                    formaPagoInDb.Tickets = formaPago.Tickets;
                    _context.Entry(formaPagoInDb).State = EntityState.Modified;

                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar guardar un registro");
            }
        }

        public List<FormaPago> GetLista()
        {
            try
            {
                return _context.FormasPagos
                    .OrderBy(fv => fv.Descripcion)
                    .AsNoTracking()
                    .ToList();

            }
            catch (Exception e)
            {

                throw new Exception("Error al leer");

            }
        }
    }
}
