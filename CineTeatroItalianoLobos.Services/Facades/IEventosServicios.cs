using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Services.Facades
{
    public interface IEventosServicios
    {
        List<Evento> GetLista(int registros, int pagina);
        Evento GetTEntityPorId(int id);
        void Guardar(Evento evento, List<Horario> listaHorariosBorrados);
        bool Existe(Evento evento);
        bool EstaRelacionado(Evento evento);
        int GetCantidad();
        void Borrar(int id);
        List<Evento> BuscarEvento(string evento);
        List<Evento> GetLista();
    }
}
