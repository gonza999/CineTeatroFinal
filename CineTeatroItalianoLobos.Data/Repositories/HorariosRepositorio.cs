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
    public class HorariosRepositorio : IRepositorioHorarios
    {
        private readonly CineTeatroDbContext _context;

        public HorariosRepositorio(CineTeatroDbContext context)
        {
            _context = context;
        }
        public void Borrar(int id)
        {
            Horario horarioInDb = null;
            try
            {
                horarioInDb = _context.Horarios
                    .SingleOrDefault(h => h.HorarioId == id);
                if (horarioInDb == null) return;
                _context.Entry(horarioInDb).State = EntityState.Deleted;
            }
            catch (Exception e)
            {
                _context.Entry(horarioInDb).State = EntityState.Unchanged;
                throw new Exception(e.Message);
            }
        }

        public List<Horario> BuscarHorario(int eventoId)
        {
            try
            {
                return _context.Horarios
                  .OrderBy(h => h.Fecha)
                  .Where(h => h.EventoId == eventoId)
                  .AsNoTracking()
                  .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Horario horario)
        {
            try
            {
                return _context.Tickets.Any(t => t.HorarioId == horario.HorarioId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Horario horario)
        {
            try
            {
                if (horario.HorarioId == 0)
                {
                    return _context.Horarios.Any(h=>h.EventoId != horario.EventoId
                    && h.Hora == horario.Hora);
                }

                return _context.Horarios.Any(h => h.HorarioId!=horario.HorarioId
                        && h.Hora == horario.Hora
                       && h.EventoId != horario.EventoId);
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
                return _context.Horarios.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Horario> GetLista(int registros, int pagina)
        {
            try
            {
                return _context.Horarios
                    .OrderBy(h => h.Fecha)
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

        public Horario GetTEntityPorId(int id)
        {
            try
            {
                return _context.Horarios.SingleOrDefault(h => h.HorarioId == id);
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }

        public void Guardar(Horario horario)
        {
            try
            {
                if (horario.Evento != null)
                {
                    horario.Evento = _context.Eventos.FirstOrDefault(e => e.EventoId == horario.EventoId);
                    _context.Eventos.Attach(horario.Evento);
                }
                if (horario.HorarioId == 0)
                {
                    _context.Horarios.Add(horario);
                }
                else
                {
                    var horarioInDb =
                        _context.Horarios.SingleOrDefault(h => h.HorarioId == horario.HorarioId);
                    if (horarioInDb == null)
                    {
                        throw new Exception("Horario inexistente");
                    }

                    horarioInDb.Fecha = horario.Fecha;
                    horarioInDb.Hora = horario.Hora;
                    horarioInDb.Evento = horario.Evento;
                    _context.Entry(horarioInDb).State = EntityState.Modified;

                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar guardar un registro");
            }
        }

        public List<Horario> GetLista()
        {
            try
            {
                return _context.Horarios
                    .OrderBy(h => h.Fecha)
                    .AsNoTracking()
                    .ToList();

            }
            catch (Exception e)
            {

                throw new Exception("Error al leer");

            }
        }

        public List<Horario> GetLista(Evento evento)
        {
            try
            {
                return _context.Horarios
                    .Where(h => h.EventoId == evento.EventoId)
                    .OrderBy(h => h.Fecha)
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
