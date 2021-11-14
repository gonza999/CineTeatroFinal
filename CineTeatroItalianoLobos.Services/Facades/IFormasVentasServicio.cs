using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Services.Facades
{
    public interface IFormasVentasServicio
    {
        List<FormaVenta> GetLista(int registros, int pagina);
        FormaVenta GetTEntityPorId(int id);
        void Guardar(FormaVenta formaVenta);
        bool Existe(FormaVenta formaVenta);
        bool EstaRelacionado(FormaVenta formaVenta);
        int GetCantidad();
        void Borrar(int id);
        FormaVenta GetFormaVenta(string nombreFormaVenta);
        List<FormaVenta> BuscarFormaVenta(string formaVenta);
        List<FormaVenta> GetLista();
    }
}
