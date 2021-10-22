using CineTeatroItalianoLobos.Entities;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioEmpleados:IRepositorio<Empleado>
    {
        List<Empleado> BuscarEmpleado(string text, int opcion);

        Empleado GetEmpleado(string nombreEmpleado);
    }
}
