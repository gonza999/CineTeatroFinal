using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Services.Facades
{
    public interface IDistribucionesServicio
    {
        List<Distribucion> GetLista(int registros, int pagina);
        Distribucion GetTEntityPorId(int id);
        void Guardar(Distribucion distribucion);
        bool Existe(Distribucion distribucion);
        bool EstaRelacionado(Distribucion distribucion);
        int GetCantidad();
        void Borrar(int id);
        List<Distribucion> GetLista();
    }
}
