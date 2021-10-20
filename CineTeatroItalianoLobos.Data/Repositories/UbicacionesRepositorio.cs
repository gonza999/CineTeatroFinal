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
    public class UbicacionesRepositorio:IRepositorioUbicaciones
    {
        private readonly CineTeatroDbContext _context;

        public UbicacionesRepositorio(CineTeatroDbContext context)
        {
            _context = context;
        }
        public void Borrar(int id)
        {
            Ubicacion ubicacionInDb = null;
            try
            {
                ubicacionInDb = _context.Ubicaciones
                    .SingleOrDefault(u => u.UbicacionId == id);
                if (ubicacionInDb == null) return;
                _context.Entry(ubicacionInDb).State = EntityState.Deleted;
            }
            catch (Exception e)
            {
                _context.Entry(ubicacionInDb).State = EntityState.Unchanged;
                throw new Exception(e.Message);
            }
        }

        public List<Ubicacion> BuscarUbicacion(string ubicacion)
        {
            try
            {
                return _context.Ubicaciones
                  .OrderBy(te => te.Descripcion)
                  .Where(te => te.Descripcion.Contains(ubicacion))
                  .AsNoTracking()
                  .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Ubicacion ubicacion)
        {
            try
            {
                return _context.Localidades.Any(l => l.UbicacionId == ubicacion.UbicacionId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Ubicacion ubicacion)
        {
            try
            {
                if (ubicacion.UbicacionId == 0)
                {
                    return _context.Ubicaciones.Any(u => u.Descripcion == ubicacion.Descripcion);
                }

                return _context.Ubicaciones.Any(u => u.Descripcion == ubicacion.Descripcion
                                                         && u.UbicacionId != ubicacion.UbicacionId);
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
                return _context.Ubicaciones.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Ubicacion> GetLista(int registros, int pagina)
        {
            try
            {
                return _context.Ubicaciones
                    .OrderBy(u => u.Descripcion)
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

        public Ubicacion GetTEntityPorId(int id)
        {
            try
            {
                return _context.Ubicaciones.SingleOrDefault(u => u.UbicacionId == id);
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }

        public Ubicacion GetUbicacion(string nombreUbicacion)
        {
            throw new System.NotImplementedException();
        }

        public void Guardar(Ubicacion ubicacion)
        {
            try
            {
                if (ubicacion.UbicacionId == 0)
                {
                    _context.Ubicaciones.Add(ubicacion);
                }
                else
                {
                    var ubicacionInDb =
                        _context.Ubicaciones.SingleOrDefault(u => u.UbicacionId == ubicacion.UbicacionId);
                    if (ubicacionInDb == null)
                    {
                        throw new Exception("Ubicacion inexistente");
                    }

                    ubicacionInDb.Descripcion = ubicacion.Descripcion;
                    ubicacionInDb.Localidades = ubicacion.Localidades;
                    _context.Entry(ubicacionInDb).State = EntityState.Modified;

                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar guardar un registro");
            }
        }
    }
}
