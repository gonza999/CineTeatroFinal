using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioEmpleados:IRepositorio<Empleado>
    {
        List<Empleado> BuscarEmpleado(string text, int opcion);

        Empleado GetEmpleado(string nombreEmpleado);
        int GetCantidad(Func<Empleado, bool> p);
        List<Empleado> Find(Func<Empleado, bool> p, int? cantidadPorPagina, int? paginaActual);
        List<Empleado> GetLista();
    }
}
