using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Services.Facades
{
    public interface IHorariosServicio
    {
        List<Horario> GetLista(int registros, int pagina);
        Horario GetTEntityPorId(int id);
        void Guardar(Horario horario);
        bool Existe(Horario horario);
        bool EstaRelacionado(Horario horario);
        int GetCantidad();
        void Borrar(int id);
        List<Horario> GetLista(Evento evento);
    }
}
