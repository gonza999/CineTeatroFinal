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
    public class DistribucionesRepositorio : IRepositorioDistribuciones
    {
        private readonly CineTeatroDbContext _context;

        public DistribucionesRepositorio(CineTeatroDbContext context)
        {
            _context = context;
        }
        public void Borrar(int id)
        {
            Distribucion distribucionInDb = null;
            try
            {
                distribucionInDb = _context.Distribuciones
                    .SingleOrDefault(d => d.DistribucionId == id);
                if (distribucionInDb == null) return;
                _context.Entry(distribucionInDb).State = EntityState.Deleted;
            }
            catch (Exception e)
            {
                _context.Entry(distribucionInDb).State = EntityState.Unchanged;
                throw new Exception(e.Message);
            }
        }
        public bool EstaRelacionado(Distribucion distribucion)
        {
            try
            {
                return _context.Eventos.Any(e => e.DistribucionId == distribucion.DistribucionId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Distribucion distribucion)
        {
            try
            {
                if (distribucion.DistribucionId == 0)
                {
                    return _context.Distribuciones.Any(d => d.Descripcion == distribucion.Descripcion);
                }

                return _context.Distribuciones.Any(d => d.Descripcion == distribucion.Descripcion
                                                         && d.DistribucionId != distribucion.DistribucionId);
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
                return _context.Distribuciones.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Distribucion> GetLista(int registros, int pagina)
        {
            try
            {
                return _context.Distribuciones
                    .OrderBy(d => d.Descripcion)
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

        public Distribucion GetTEntityPorId(int id)
        {
            try
            {
                return _context.Distribuciones.SingleOrDefault(d => d.DistribucionId == id);
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }

        public Distribucion GetDistribucion(string nombreDistribucion)
        {
            throw new System.NotImplementedException();
        }

        public void Guardar(Distribucion distribucion)
        {
            try
            {
                //foreach (var dl in distribucion.DistribucionesLocalidades)
                //{
                //    if (dl != null)
                //    {
                //        _context.DistribucionesLocalidades.Attach(dl);
                //    }
                //}
                _context.Distribuciones.Add(distribucion);
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar guardar un registro");
            }
        }

        public List<Distribucion> GetLista()
        {
              try
            {
                return _context.Distribuciones
                    .OrderBy(u => u.Descripcion)
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
