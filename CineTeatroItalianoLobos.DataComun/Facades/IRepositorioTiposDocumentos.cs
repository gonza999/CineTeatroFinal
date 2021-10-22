using CineTeatroItalianoLobos.Entities;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioTiposDocumentos:IRepositorio<TipoDocumento>
    {
        TipoDocumento GetTipoDocumento(string nombreTipoDocumento);
        List<TipoDocumento> BuscarTipoDocumento(string tipoDocumento);
        List<TipoDocumento> GetLista();
    }
}
