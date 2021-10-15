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
    public class ClasificacionesRepositorio:IRepositorioClasificaciones
    {
        private readonly CineTeatroDbContext _context;

        public ClasificacionesRepositorio(CineTeatroDbContext context)
        {
            _context = context;
        }
        public void Borrar(int id)
        {
            Clasificacion clasificacionInDb = null;
            try
            {
                clasificacionInDb = _context.Clasificaciones
                    .SingleOrDefault(c => c.ClasificacionId == id);
                if (clasificacionInDb == null) return;
                _context.Entry(clasificacionInDb).State = EntityState.Deleted;
            }
            catch (Exception e)
            {
                _context.Entry(clasificacionInDb).State = EntityState.Unchanged;
                throw new Exception(e.Message);
            }
        }

        public List<Clasificacion> BuscarClasificacion(string clasificacion)
        {
            throw new System.NotImplementedException();
        }

        public bool EstaRelacionado(Clasificacion clasificacion)
        {
            try
            {
                return _context.Eventos.Any(e => e.ClasificacionId == clasificacion.ClasificacionId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Clasificacion clasificacion)
        {
            try
            {
                if (clasificacion.ClasificacionId == 0)
                {
                    return _context.Clasificaciones.Any(c => c.Descripcion == clasificacion.Descripcion);
                }

                return _context.Clasificaciones.Any(c => c.Descripcion == clasificacion.Descripcion
                                                         && c.ClasificacionId != clasificacion.ClasificacionId);
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
                return _context.Clasificaciones.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Clasificacion> GetLista(int registros, int pagina)
        {
            try
            {
                return _context.Clasificaciones
                    .OrderBy(c => c.Descripcion)
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

        public Clasificacion GetTEntityPorId(int id)
        {
            try
            {
                return _context.Clasificaciones.SingleOrDefault(c => c.ClasificacionId == id);
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }

        public Clasificacion GetClasificacion(string nombreClasificacion)
        {
            throw new System.NotImplementedException();
        }

        public void Guardar(Clasificacion clasificacion)
        {
            try
            {
                if (clasificacion.ClasificacionId == 0)
                {
                    _context.Clasificaciones.Add(clasificacion);
                }
                else
                {
                    var clasificacionInDb =
                        _context.Clasificaciones.SingleOrDefault(c => c.ClasificacionId == clasificacion.ClasificacionId);
                    if (clasificacionInDb == null)
                    {
                        throw new Exception("Clasificacion inexistente");
                    }

                    clasificacionInDb.Descripcion = clasificacion.Descripcion;
                    clasificacionInDb.Eventos = clasificacion.Eventos;
                    _context.Entry(clasificacionInDb).State = EntityState.Modified;

                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar guardar un registro");
            }
        }
    }
}
