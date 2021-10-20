using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Services.Facades
{
    public interface ITiposDocumentosServicio
    {
        List<TipoDocumento> GetLista(int registros, int pagina);
        TipoDocumento GetTEntityPorId(int id);
        void Guardar(TipoDocumento TEntity);
        bool Existe(TipoDocumento TEntity);
        bool EstaRelacionado(TipoDocumento TEntity);
        int GetCantidad();
        void Borrar(int id);
        TipoDocumento GetTipoDocumento(string nombreTipoDocumento);
        List<TipoDocumento> BuscarTipoDocumento(string tipodocumento);
    }
}
