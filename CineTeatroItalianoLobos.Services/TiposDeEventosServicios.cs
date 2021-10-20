using CineTeatroItalianoLobos.Data.Repositories;
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
    public class TiposDeEventosServicios : ITiposDeEventosServicios
    {
        private readonly IRepositorioTipoEventos _repositorio;
        private readonly IUnitOfWork _unitOfWork;

        public TiposDeEventosServicios(IRepositorioTipoEventos repositorio, IUnitOfWork unitOfWork)
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

        public List<TipoEvento> BuscarTipoEvento(string tipoevento)
        {
            try
            {
               return _repositorio.BuscarTipoEvento(tipoevento);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoEvento tipoEvento)
        {
            try
            {
                return _repositorio.EstaRelacionado(tipoEvento);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoEvento tipoEvento)
        {
            try
            {
                return _repositorio.Existe(tipoEvento);
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

        public List<TipoEvento> GetLista(int registros, int pagina)
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

        public TipoEvento GetTEntityPorId(int id)
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

        public TipoEvento GetTipoEvento(string nombreTipoEvento)
        {
            try
            {
                return _repositorio.GetTipoEvento(nombreTipoEvento);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipoEvento tipoEvento)
        {
            try
            {
                _repositorio.Guardar(tipoEvento);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
