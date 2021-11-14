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
    public class EventosRepositorio:IRepositorioEventos
    {
        private readonly CineTeatroDbContext _context;

        public EventosRepositorio(CineTeatroDbContext context)
        {
            _context = context;
        }
        public void Borrar(int id)
        {
            Evento eventoInDb = null;
            try
            {
                eventoInDb = _context.Eventos
                    .SingleOrDefault(e => e.EventoId == id);
                if (eventoInDb == null) return;
                _context.Entry(eventoInDb).State = EntityState.Deleted;
            }
            catch (Exception e)
            {
                _context.Entry(eventoInDb).State = EntityState.Unchanged;
                throw new Exception(e.Message);
            }
        }

        public List<Evento> BuscarEvento(string evento)
        {
            try
            {
                return _context.Eventos
                  .OrderBy(e => e.NombreEvento)
                  .Where(e => e.NombreEvento.Contains(evento))
                  .AsNoTracking()
                  .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Evento evento)
        {
            try
            {
                return _context.Horarios.Any(h => h.EventoId == evento.EventoId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Evento evento)
        {
            try
            {
                if (evento.EventoId == 0)
                {
                    return _context.Eventos.Any(e => e.FechaEvento == evento.FechaEvento);
                }

                return _context.Eventos.Any(e => e.FechaEvento == evento.FechaEvento
                                                         && e.EventoId != evento.EventoId);
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
                return _context.Eventos.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Evento> GetLista(int registros, int pagina)
        {
            try
            {
                return _context.Eventos
                    .OrderBy(e => e.NombreEvento)
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

        public Evento GetTEntityPorId(int id)
        {
            try
            {
                return _context.Eventos.SingleOrDefault(e => e.EventoId == id);
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }
        public void Guardar(Evento evento)
        {
            try
            {
                if (evento.Clasificacion != null)
                {
                    _context.Clasificaciones.Attach(evento.Clasificacion);
                }
                if (evento.Distribucion != null)
                {
                    _context.Distribuciones.Attach(evento.Distribucion);
                }
                if (evento.TipoEvento != null)
                {
                    _context.TiposEventos.Attach(evento.TipoEvento);
                }
                foreach (var h in evento.Horarios)
                {
                    if (h.HorarioId>0)
                    {
                        _context.Horarios.Attach(h);
                    }
                }
                if (evento.EventoId == 0)
                {
                    _context.Eventos.Add(evento);
                }
                else
                {
                    var eventoInDb =
                        _context.Eventos.SingleOrDefault(e => e.EventoId == evento.EventoId);
                    if (eventoInDb == null)
                    {
                        throw new Exception("Evento inexistente");
                    }

                    eventoInDb.Clasificacion = evento.Clasificacion;
                    eventoInDb.Descripcion = evento.Descripcion;
                    eventoInDb.Distribucion = evento.Distribucion;
                    eventoInDb.FechaEvento = evento.FechaEvento;
                    //eventoInDb.Horarios = evento.Horarios;
                    eventoInDb.NombreEvento = evento.NombreEvento;
                    eventoInDb.Suspendido = evento.Suspendido;
                    eventoInDb.TipoEvento = evento.TipoEvento;
                    _context.Entry(eventoInDb).State = EntityState.Modified;

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void AnularEvento(int eventoId)
        {
            throw new NotImplementedException();
        }

        public List<Evento> GetLista()
        {
            try
            {
                return _context.Eventos
                    .OrderBy(e => e.NombreEvento)
                    .AsNoTracking()
                    .ToList();

            }
            catch (Exception e)
            {

                throw new Exception("Error al leer");

            }
        }

        public int GetCantidad(Func<Evento, bool> p)
        {
            try
            {
                return _context.Eventos.Count(p);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Evento> Find(Func<Evento, bool> predicate, int? cantidadPorPagina, int? paginaActual)
        {
            try
            {
                IEnumerable<Evento> query = _context.Eventos
                   .Include(c => c.TipoEvento).AsEnumerable()
                   .Where(predicate)
                   .OrderBy(p => p.NombreEvento);
                if (cantidadPorPagina.HasValue && paginaActual.HasValue)
                {
                    query = query.Skip(cantidadPorPagina.Value * (paginaActual.Value - 1))
                        .Take(cantidadPorPagina.Value);
                }
                return query.ToList();

            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }
    }
}
