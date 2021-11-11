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
    public class DistribucionesLocalidadesRepositorio:IRepositorioDistribucionesLocalidades
    {
        private readonly CineTeatroDbContext _context;

        public DistribucionesLocalidadesRepositorio(CineTeatroDbContext context)
        {
            _context = context;
        }

        public void Borrar(int id)
        {
            List<DistribucionLocalidad> listaDistribucionLocalidadInDb = null;
            try
            {
                listaDistribucionLocalidadInDb = _context.DistribucionesLocalidades
                  .Where(dl => dl.DistribucionId==id)
                  .ToList();
                if (listaDistribucionLocalidadInDb == null) return;
                foreach (var dl in listaDistribucionLocalidadInDb)
                {
                    _context.Entry(dl).State = EntityState.Deleted;
                }
            }
            catch (Exception e)
            {
                _context.Entry(listaDistribucionLocalidadInDb).State = EntityState.Unchanged;
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(DistribucionLocalidad TEntity)
        {
            return false;
        }

        public bool Existe(DistribucionLocalidad TEntity)
        {
            return false;
        }

        public int GetCantidad()
        {
            try
            {
                return _context.DistribucionesLocalidades.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<DistribucionLocalidad> GetLista(int registros, int pagina)
        {
            try
            {
                return _context.DistribucionesLocalidades
                    .OrderBy(dl => dl.DistribucionId)
                    .Skip(registros * (pagina - 1))
                    .Take(registros)
                    .ToList();

            }
            catch (Exception e)
            {

                throw new Exception("Error al leer");

            }
        }

        public List<DistribucionLocalidad> GetLista(int distribucionId)
        {
            try
            {
                return _context.DistribucionesLocalidades
                    .Where(dl => dl.DistribucionId == distribucionId)
                    .OrderBy(dl => dl.DistribucionId)
                    .AsNoTracking()
                    .ToList();

            }
            catch (Exception e)
            {

                throw new Exception("Error al leer");

            }
        }

        public DistribucionLocalidad GetTEntityPorId(int id)
        {
            try
            {
                return _context.DistribucionesLocalidades.SingleOrDefault(dl => dl.DistribucionId == id);
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }

        public void Guardar(DistribucionLocalidad distribucionLocalidad)
        {
            try
            {
                if (distribucionLocalidad.Localidad != null)
                {
                    _context.Localidades.Attach(distribucionLocalidad.Localidad);
                }

                //var localidadInDb =
                //     _context.Localidades.SingleOrDefault(l => l.LocalidadId == distribucionLocalidad.LocalidadId);
                //var distribucionInDb =
                //    _context.Distribuciones.SingleOrDefault(d => d.DistribucionId == distribucionLocalidad.DistribucionId);
                //distribucionLocalidad.DistribucionId = distribucionInDb.DistribucionId;
                //distribucionLocalidad.Distribucion = distribucionInDb;
                //distribucionLocalidad.Localidad = localidadInDb;
                //distribucionLocalidad.LocalidadId = localidadInDb.LocalidadId;

                _context.Entry(distribucionLocalidad.Localidad).State = EntityState.Modified;
                _context.Entry(distribucionLocalidad.Distribucion).State = EntityState.Modified;
                //distribucionLocalidad.Localidad.Ubicacion.UbicacionId =
                //    distribucionLocalidad.Localidad.LocalidadId;
                _context.Entry(distribucionLocalidad).State = EntityState.Added;
                //_context.DistribucionesLocalidades.Add(distribucionLocalidad);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
