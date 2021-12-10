using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Services.Facades
{
    public interface IVentasServicio
    {
        List<Venta> GetLista(int registros, int pagina);
        void Guardar(Venta venta);
        int GetCantidad();
        List<Venta> GetLista(Empleado empleado);
        List<Venta> GetLista();
    }
}
