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
    public class PlantasRepositorio:IRepositorioPlantas
    {
        private readonly CineTeatroDbContext _context;

        public PlantasRepositorio(CineTeatroDbContext context)
        {
            _context = context;
        }
        public void Borrar(int id)
        {
            Planta plantaInDb = null;
            try
            {
                plantaInDb = _context.Plantas
                    .SingleOrDefault(p => p.PlantaId == id);
                if (plantaInDb == null) return;
                _context.Entry(plantaInDb).State = EntityState.Deleted;
            }
            catch (Exception e)
            {
                _context.Entry(plantaInDb).State = EntityState.Unchanged;
                throw new Exception(e.Message);
            }
        }

        public List<Planta> BuscarPlanta(string planta)
        {
            try
            {
                return _context.Plantas
                  .OrderBy(p => p.Descripcion)
                  .Where(p => p.Descripcion.Contains(planta))
                  .AsNoTracking()
                  .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Planta planta)
        {
            try
            {
                return _context.Localidades.Any(l => l.PlantaId == planta.PlantaId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Planta planta)
        {
            try
            {
                if (planta.PlantaId == 0)
                {
                    return _context.Plantas.Any(p => p.Descripcion == planta.Descripcion);
                }

                return _context.Plantas.Any(p => p.Descripcion == planta.Descripcion
                                                         && p.PlantaId != planta.PlantaId);
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
                return _context.Plantas.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Planta> GetLista(int registros, int pagina)
        {
            try
            {
                return _context.Plantas
                    .OrderBy(p => p.Descripcion)
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

        public Planta GetTEntityPorId(int id)
        {
            try
            {
                return _context.Plantas.SingleOrDefault(p => p.PlantaId == id);
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }

        public Planta GetPlanta(string nombrePlanta)
        {
            throw new System.NotImplementedException();
        }

        public void Guardar(Planta planta)
        {
            try
            {
                if (planta.PlantaId == 0)
                {
                    _context.Plantas.Add(planta);
                }
                else
                {
                    var plantaInDb =
                        _context.Plantas.SingleOrDefault(p => p.PlantaId == planta.PlantaId);
                    if (plantaInDb == null)
                    {
                        throw new Exception("Planta inexistente");
                    }

                    plantaInDb.Descripcion = planta.Descripcion;
                    plantaInDb.Localidades = planta.Localidades;
                    _context.Entry(plantaInDb).State = EntityState.Modified;

                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar guardar un registro");
            }
        }
    }
}
