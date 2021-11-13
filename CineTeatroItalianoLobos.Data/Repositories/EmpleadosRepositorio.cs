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
    public class EmpleadosRepositorio : IRepositorioEmpleados
    {
        private readonly CineTeatroDbContext _context;

        public EmpleadosRepositorio(CineTeatroDbContext context)
        {
            _context = context;
        }
        public void Borrar(int id)
        {
            Empleado empleadoInDb = null;
            try
            {
                empleadoInDb = _context.Empleados
                    .SingleOrDefault(e => e.EmpleadoId == id);
                if (empleadoInDb == null) return;
                _context.Entry(empleadoInDb).State = EntityState.Deleted;
            }
            catch (Exception e)
            {
                _context.Entry(empleadoInDb).State = EntityState.Unchanged;
                throw new Exception(e.Message);
            }
        }

        public List<Empleado> BuscarEmpleado(string empleado, int opcion)
        {
            try
            {
                if (opcion == 0)
                {
                    return _context.Empleados
                        .OrderBy(e => e.Apellido)
                        .Where(e => e.Apellido.Contains(empleado))
                        .AsNoTracking()
                        .ToList();
                }
                else if (opcion == 1)
                {
                    return _context.Empleados
                        .OrderBy(e => e.Apellido)
                        .Where(e => e.Nombre.Contains(empleado))
                        .AsNoTracking()
                        .ToList();
                }
                else
                {
                    return _context.Empleados
                        .Include(e=>e.TipoDocumento)
                        .OrderBy(e => e.Apellido)
                        .Where(e => e.TipoDocumento.Descripcion==empleado)
                        .AsNoTracking()
                        .ToList();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Empleado empleado)
        {
            try
            {
                return _context.Ventas.Any(v => v.EmpleadoId == empleado.EmpleadoId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Empleado empleado)
        {
            try
            {
                if (empleado.EmpleadoId == 0)
                {
                    return _context.Empleados.Any(e => e.TipoDocumentoId == empleado.TipoDocumentoId
                    && e.NroDocumento == empleado.NroDocumento);
                }

                return _context.Empleados.Any(e => e.TipoDocumentoId == empleado.TipoDocumentoId
                    && e.NroDocumento == empleado.NroDocumento && e.EmpleadoId != empleado.EmpleadoId);
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
                return _context.Empleados.Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Empleado> GetLista(int registros, int pagina)
        {
            try
            {
                return _context.Empleados
                    .Include(e=>e.TipoDocumento)
                    .OrderBy(p => p.Apellido)
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

        public Empleado GetTEntityPorId(int id)
        {
            try
            {
                return _context.Empleados.SingleOrDefault(p => p.EmpleadoId == id);
            }
            catch (Exception e)
            {
                throw new Exception("Error al leer");
            }
        }

        public Empleado GetEmpleado(string nombreEmpleado)
        {
            throw new System.NotImplementedException();
        }

        public void Guardar(Empleado empleado)
        {
            try
            {
                if (empleado.TipoDocumento != null)
                {
                    empleado.TipoDocumento = _context.TiposDocumentos.FirstOrDefault(td=>td.TipoDocumentoId==empleado.TipoDocumentoId);
                    _context.TiposDocumentos.Attach(empleado.TipoDocumento);
                }
                if (empleado.EmpleadoId == 0)
                {
                    _context.Empleados.Add(empleado);
                }
                else
                {
                    var empleadoInDb =
                        _context.Empleados.SingleOrDefault(p => p.EmpleadoId == empleado.EmpleadoId);
                    if (empleadoInDb == null)
                    {
                        throw new Exception("Empleado inexistente");
                    }

                    empleadoInDb.Nombre = empleado.Nombre;
                    empleadoInDb.Apellido = empleado.Apellido;
                    empleadoInDb.Mail = empleado.Mail;
                    empleadoInDb.NroDocumento = empleado.NroDocumento;
                    empleadoInDb.TelefonoFijo = empleado.TelefonoFijo;
                    empleadoInDb.TelefonoMovil = empleado.TelefonoMovil;
                    empleadoInDb.TipoDocumentoId = empleado.TipoDocumentoId;

                    _context.Entry(empleadoInDb).State = EntityState.Modified;

                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar guardar un registro");
            }
        }
    }
}
