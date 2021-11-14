using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Services.Facades
{
    public interface IEmpleadosServicio
    {
        List<Empleado> GetLista(int registros, int pagina);
        Empleado GetTEntityPorId(int id);
        void Guardar(Empleado empleado);
        bool Existe(Empleado empleado);
        bool EstaRelacionado(Empleado empleado);
        int GetCantidad();
        void Borrar(int id);
        Empleado GetEmpleado(string nombreEmpleado);
        List<Empleado> BuscarEmpleado(string empleado, int v);
        int GetCantidad(Func<Empleado, bool> p);
        List<Empleado> Find(Func<Empleado, bool> p, int? cantidadPorPagina, int? paginaActual);
    }
}
