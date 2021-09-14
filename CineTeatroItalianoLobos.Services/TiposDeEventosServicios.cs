using CineTeatroItalianoLobos.Data.Repositories;
using CineTeatroItalianoLobos.DataComun;
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
        private readonly TiposDeEventosRepositorio _repositorio;
        private readonly IUnitOfWork _unitOfWork;

        public TiposDeEventosServicios(TiposDeEventosRepositorio repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
        }
        public void Borrar(int id)
        {
            throw new NotImplementedException();
        }

        public List<TipoEvento> BuscarTipoEvento(string tipoevento)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(TipoEvento TEntity)
        {
            throw new NotImplementedException();
        }

        public bool Existe(TipoEvento TEntity)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public TipoEvento GetTipoEvento(string nombreTipoEvento)
        {
            throw new NotImplementedException();
        }

        public void Guardar(TipoEvento TEntity)
        {
            throw new NotImplementedException();
        }
    }
}
