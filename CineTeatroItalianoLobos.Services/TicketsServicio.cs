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

        public int GetCantidad()
        {
            try
            {
                return _repositorio.GetCantidad();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int GetCantidad(Func<Ticket, bool> p)
        {
            try
            {
                return _repositorio.GetCantidad(p);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Ticket> GetLista(int registros, int pagina)
        {
            try
            {
                return _repositorio.GetLista(registros, pagina);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Ticket> GetLista(Evento evento)
        {
            try
            {
                return _repositorio.GetLista(evento);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Ticket> GetLista(Venta venta)
        {
            try
            {
                return _repositorio.GetLista(venta);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Ticket> GetLista()
        {
            try
            {
                return _repositorio.GetLista();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
