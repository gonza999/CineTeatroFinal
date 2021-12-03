using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Services.Facades
{
    public interface ITicketsServicio
    {
        List<Ticket> GetLista(int registros, int pagina);
        void Guardar(Ticket ticket);
    }
}
