using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Services.Facades
{
    public interface ILocalidadesServicio
    {
        List<Localidad> GetLista(int registros, int pagina);
        Localidad GetLocalidadPorId(int id);
        void Guardar(Localidad localidad);
        bool Existe(Localidad localidad);
        bool EstaRelacionado(Localidad localidad);
        int GetCantidad();
        void Borrar(int id);
        List<Localidad> GetLista(Ubicacion ubicacion);
        List<Localidad> GetLista(int fila);
    }
}
