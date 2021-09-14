using CineTeatroItalianoLobos.Entities;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioFormasPagos:IRepositorio<FormaPago>
    {
        FormaPago GetFormaPago(string nombreFormaPago);
        List<FormaPago> BuscarFormaPago(string formaPago);
    }
}
