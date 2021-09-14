using CineTeatroItalianoLobos.Entities;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioVentas:IRepositorio<Venta>
    { 
        Venta GetVenta(string nombreVenta);
        List<Venta> BuscarVenta(string text);
        void AnularVenta(int ventaId);
    }
}
