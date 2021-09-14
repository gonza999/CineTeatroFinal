using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorio<TEntity> where TEntity : class
    {

        List<TEntity> GetLista(int registros, int pagina);
        TEntity GetTEntityPorId(int id);
        void Guardar(TEntity TEntity);
        bool Existe(TEntity TEntity);
        bool EstaRelacionado(TEntity TEntity);
        int GetCantidad();
        void Borrar(int id);

    }
}
