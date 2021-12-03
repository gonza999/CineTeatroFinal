using CineTeatroItalianoLobos.DataComun;
using CineTeatroItalianoLobos.DataComun.Facades;
using CineTeatroItalianoLobos.Entities;
using CineTeatroItalianoLobos.Services.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Services
{
    public class TicketsServicio:ITicketsServicio
    {
        private readonly IRepositorioTickets _repositorio;
        private readonly IUnitOfWork _unitOfWork;

        public TicketsServicio(IRepositorioTickets repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
        }

        public List<Ticket> GetLista(int registros, int pagina)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
