using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Services.Facades
{
    public interface IUbicacionesServicio
    {
        List<Ubicacion> GetLista(int registros, int pagina);
        Ubicacion GetTEntityPorId(int id);
        void Guardar(Ubicacion ubicacion);
        bool Existe(Ubicacion ubicacion);
        bool EstaRelacionado(Ubicacion ubicacion);
        int GetCantidad();
        void Borrar(int id);
        Ubicacion GetUbicacion(string nombreUbicacion);
        List<Ubicacion> BuscarUbicacion(string ubicacion);
    }
}
