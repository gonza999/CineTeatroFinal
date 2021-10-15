using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Services.Facades
{
    public interface IClasificacionesServicio
    {
        List<Clasificacion> GetLista(int registros, int pagina);
        Clasificacion GetTEntityPorId(int id);
        void Guardar(Clasificacion clasificacion);
        bool Existe(Clasificacion clasificacion);
        bool EstaRelacionado(Clasificacion clasificacion);
        int GetCantidad();
        void Borrar(int id);
        Clasificacion GetClasificacion(string nombreClasificacion);
        List<Clasificacion> BuscarClasificacion(string clasificacion);
    }
}
