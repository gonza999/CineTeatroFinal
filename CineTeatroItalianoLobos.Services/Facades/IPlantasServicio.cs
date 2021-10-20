using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Services.Facades
{
    public interface IPlantasServicio
    {
        List<Planta> GetLista(int registros, int pagina);
        Planta GetTEntityPorId(int id);
        void Guardar(Planta planta);
        bool Existe(Planta planta);
        bool EstaRelacionado(Planta planta);
        int GetCantidad();
        void Borrar(int id);
        Planta GetPlanta(string nombrePlanta);
        List<Planta> BuscarPlanta(string planta);
    }
}
