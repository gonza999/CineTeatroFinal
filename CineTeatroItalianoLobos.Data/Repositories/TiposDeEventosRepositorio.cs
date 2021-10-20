using CineTeatroItalianoLobos.DataComun.Facades;
using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CineTeatroItalianoLobos.Data.Repositories
{
    public class TiposDeEventosRepositorio : IRepositorioTipoEventos
    {
        private readonly CineTeatroDbContext _context;

        public TiposDeEventosRepositorio(CineTeatroDbContext context)
        {
            _context=context;
        }
        public void Borrar(int id)
        {
            TipoEvento tipoEventoInDb = null;
            try
            {
                tipoEventoInDb = _context.TiposEventos
                    .SingleOrDefault(p => p.TipoEventoId == id);
                if (tipoEventoInDb == null) return;
                _context.Entry(tipoEventoInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception e)
            {
                _context.Entry(tipoEventoInDb).State = EntityState.Unchanged;
                throw new Exception(e.Message);
            }
        }

        public List<TipoEvento> BuscarTipoEvento(string tipoevento)
        {
            try
            {
                return _context.TiposEventos
                  .OrderBy(te => te.Descripcion)
                  .Where(te=>te.Descripcion.Contains(tipoevento))
                  .AsNoTracking()
                  .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoEvento tipoEvento)
        {
            try
            {
                return _context.Eventos.Any(e => e.TipoEventoId == tipoEvento.TipoEventoId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoEvento tipoEvento)
        {
            try
            {
                if (tipoEvento.TipoEventoId == 0)
                {
                    return _context.TiposEventos.Any(te => te.Descripcion == tipoEvento.Descripcion);
                }

                return _context.TiposEventos.Any(te => te.Descripcion == tipoEvento.Descripcion
                                                         && te.TipoEventoId != tipoEvento.TipoEventoId);
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
                return _context.TiposEventos.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TipoEvento> GetLista(int registros, int pagina)
        {
            try
            {
                return _context.TiposEventos
                    .OrderBy(te => te.Descripcion)
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

        public TipoEvento GetTEntityPorId(int id)
        {
            try
            {
                return _context.TiposEventos.SingleOrDefault(p => p.TipoEventoId == id);
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }

        public TipoEvento GetTipoEvento(string nombreTipoEvento)
        {
            throw new System.NotImplementedException();
        }

        public void Guardar(TipoEvento tipoEvento)
        {
            try
            {
                if (tipoEvento.TipoEventoId == 0)
                {
                    _context.TiposEventos.Add(tipoEvento);
                }
                else
                {
                    var tipoEventoInDb =
                        _context.TiposEventos.SingleOrDefault(p => p.TipoEventoId == tipoEvento.TipoEventoId);
                    if (tipoEventoInDb == null)
                    {
                        throw new Exception("Tipo de evento inexistente");
                    }

                    tipoEventoInDb.Descripcion = tipoEvento.Descripcion;
                    tipoEventoInDb.Eventos = tipoEvento.Eventos;
                    _context.Entry(tipoEventoInDb).State = EntityState.Modified;

                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar guardar un registro");
            }
        }
    }
}
