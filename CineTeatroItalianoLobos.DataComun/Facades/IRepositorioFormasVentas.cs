using CineTeatroItalianoLobos.Entities;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioFormasVentas:IRepositorio<FormaVenta>
    {
        FormaVenta GetFormaVenta(string nombreFormaVenta);
        List<FormaVenta> BuscarFormaVenta(string formaVenta);
    }
}
