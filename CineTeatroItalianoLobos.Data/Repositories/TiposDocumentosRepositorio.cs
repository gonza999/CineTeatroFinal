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
    public class TiposDocumentosRepositorio:IRepositorioTiposDocumentos
    {
        private readonly CineTeatroDbContext _context;

        public TiposDocumentosRepositorio(CineTeatroDbContext context)
        {
            _context = context;
        }
        public void Borrar(int id)
        {
            TipoDocumento tipoDocumentoInDb = null;
            try
            {
                tipoDocumentoInDb = _context.TiposDocumentos
                    .SingleOrDefault(td => td.TipoDocumentoId == id);
                if (tipoDocumentoInDb == null) return;
                _context.Entry(tipoDocumentoInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception e)
            {
                _context.Entry(tipoDocumentoInDb).State = EntityState.Unchanged;
                throw new Exception(e.Message);
            }
        }

        public List<TipoDocumento> BuscarTipoDocumento(string tipodocumento)
        {
            try
            {
                return _context.TiposDocumentos
                  .OrderBy(td => td.Descripcion)
                  .Where(td => td.Descripcion.Contains(tipodocumento))
                  .AsNoTracking()
                  .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoDocumento tipoDocumento)
        {
            try
            {
                return _context.Empleados.Any(e => e.TipoDocumentoId == tipoDocumento.TipoDocumentoId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoDocumento tipoDocumento)
        {
            try
            {
                if (tipoDocumento.TipoDocumentoId == 0)
                {
                    return _context.TiposDocumentos.Any(td => td.Descripcion == tipoDocumento.Descripcion);
                }

                return _context.TiposDocumentos.Any(td => td.Descripcion == tipoDocumento.Descripcion
                                                         && td.TipoDocumentoId != tipoDocumento.TipoDocumentoId);
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
                return _context.TiposDocumentos.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TipoDocumento> GetLista(int registros, int pagina)
        {
            try
            {
                return _context.TiposDocumentos
                    .OrderBy(td => td.Descripcion)
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

        public TipoDocumento GetTEntityPorId(int id)
        {
            try
            {
                return _context.TiposDocumentos.SingleOrDefault(td => td.TipoDocumentoId == id);
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }

        public TipoDocumento GetTipoDocumento(string nombreTipoDocumento)
        {
            try
            {
                return _context.TiposDocumentos.FirstOrDefault(td => td.Descripcion == nombreTipoDocumento);
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }

        public void Guardar(TipoDocumento tipoDocumento)
        {
            try
            {
                if (tipoDocumento.TipoDocumentoId == 0)
                {
                    _context.TiposDocumentos.Add(tipoDocumento);
                }
                else
                {
                    var tipoDocumentoInDb =
                        _context.TiposDocumentos.SingleOrDefault(td => td.TipoDocumentoId == tipoDocumento.TipoDocumentoId);
                    if (tipoDocumentoInDb == null)
                    {
                        throw new Exception("Tipo de documento inexistente");
                    }

                    tipoDocumentoInDb.Descripcion = tipoDocumento.Descripcion;
                    tipoDocumentoInDb.Empleados = tipoDocumento.Empleados;
                    _context.Entry(tipoDocumentoInDb).State = EntityState.Modified;

                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar guardar un registro");
            }
        }
    }
}
