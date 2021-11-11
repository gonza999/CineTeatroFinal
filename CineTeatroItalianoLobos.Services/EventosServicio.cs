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
    public class EventosServicio:IEventosServicios
    {
        private readonly IRepositorioEventos _repositorio;
        private readonly IUnitOfWork _unitOfWork;

        public EventosServicio(IRepositorioEventos repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
        }
        public void Borrar(int id)
        {
            try
            {
                _repositorio.Borrar(id);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Evento> BuscarEvento(string evento)
        {
            try
            {
                return _repositorio.BuscarEvento(evento);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Evento evento)
        {
            try
            {
                return _repositorio.EstaRelacionado(evento);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Evento evento)
        {
            try
            {
                return _repositorio.Existe(evento);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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

        public List<Evento> GetLista(int registros, int pagina)
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

        public Evento GetTEntityPorId(int id)
        {
            try
            {
                return _repositorio.GetTEntityPorId(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Evento evento)
        {
            try
            {
                _repositorio.Guardar(evento);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
