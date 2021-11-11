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
    public class LocalidadesRepositorio:IRepositorioLocalidades
    {
        private readonly CineTeatroDbContext _context;

        public LocalidadesRepositorio(CineTeatroDbContext context)
        {
            _context = context;
        }
        public void Borrar(int id)
        {
            Localidad localidadInDb = null;
            try
            {
                localidadInDb = _context.Localidades
                    .SingleOrDefault(l => l.LocalidadId == id);
                if (localidadInDb == null) return;
                _context.Entry(localidadInDb).State = EntityState.Deleted;
            }
            catch (Exception e)
            {
                _context.Entry(localidadInDb).State = EntityState.Unchanged;
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Localidad localidad)
        {
            try
            {
                return _context.Tickets.Any(t => t.LocalidadId == localidad.LocalidadId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Localidad localidad)
        {
            try
            {
                if (localidad.LocalidadId == 0)
                {
                    return _context.Localidades.Any(l => l.Numero == localidad.Numero &&
                                                    l.UbicacionId==localidad.UbicacionId);
                }

                return _context.Localidades.Any(l => l.Numero == localidad.Numero &&
                                                    l.UbicacionId == localidad.UbicacionId
                                                         && l.LocalidadId != localidad.LocalidadId);
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
                return _context.Localidades.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Localidad> GetLista(int registros, int pagina)
        {
            try
            {
                return _context.Localidades
                    .OrderBy(l => l.UbicacionId).ThenBy(l=>l.Numero)
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

        public Localidad GetTEntityPorId(int id)
        {
            try
            {
                return _context.Localidades.SingleOrDefault(l => l.LocalidadId == id);
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }

        public Localidad GetLocalidad(string nombreLocalidad)
        {
            throw new System.NotImplementedException();
        }

        public void Guardar(Localidad localidad)
        {
            try
            {
                if (localidad.Planta != null)
                {
                    _context.Plantas.Attach(localidad.Planta);
                }
                if (localidad.Ubicacion != null)
                {
                    _context.Ubicaciones.Attach(localidad.Ubicacion);
                }
                if (localidad.LocalidadId == 0)
                {
                    _context.Localidades.Add(localidad);
                }
                else
                {
                    var localidadInDb =
                        _context.Localidades.SingleOrDefault(l => l.LocalidadId == localidad.LocalidadId);
                    if (localidadInDb == null)
                    {
                        throw new Exception("Localidad inexistente");
                    }

                    localidadInDb.Numero = localidad.Numero;
                    localidadInDb.PlantaId = localidad.PlantaId;
                    localidadInDb.UbicacionId = localidad.UbicacionId;
                    localidadInDb.Fila = localidad.Fila;
                    _context.Entry(localidadInDb).State = EntityState.Modified;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar guardar un registro");
            }
        }

        public List<Localidad> GetLista(Ubicacion ubicacion)
        {
            try
            {
                return _context.Localidades
                  .OrderBy(l => l.Numero)
                  .Where(p => p.UbicacionId==ubicacion.UbicacionId)
                  .AsNoTracking()
                  .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Localidad> GetLista(int fila)
        {
            try
            {
                return _context.Localidades
                  .OrderBy(l => l.Numero)
                  .Where(l => l.Fila==fila && l.UbicacionId==1)
                  .AsNoTracking()
                  .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<string> GetFilas()
        {
            try
            {
                List<String> lista=new List<string>();
                var grupo= _context.Localidades
                  .OrderBy(l => l.Fila)
                  .GroupBy(l=>l.Fila)
                  .ToList();
                foreach (var l in grupo)
                {
                    var fila = l.Key;
                    lista.Add(fila.ToString());
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
