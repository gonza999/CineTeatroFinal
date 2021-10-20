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
    public class TiposDocumentosServicio:ITiposDocumentosServicio
    {
        private readonly IRepositorioTiposDocumentos _repositorio;
        private readonly IUnitOfWork _unitOfWork;

        public TiposDocumentosServicio(IRepositorioTiposDocumentos repositorio, IUnitOfWork unitOfWork)
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

        public List<TipoDocumento> BuscarTipoDocumento(string tipodocumento)
        {
            try
            {
                return _repositorio.BuscarTipoDocumento(tipodocumento);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoDocumento tipoDocumento)
        {
            try
            {
                return _repositorio.EstaRelacionado(tipoDocumento);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoDocumento tipoDocumento)
        {
            try
            {
                return _repositorio.Existe(tipoDocumento);
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

        public List<TipoDocumento> GetLista(int registros, int pagina)
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

        public TipoDocumento GetTEntityPorId(int id)
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

        public TipoDocumento GetTipoDocumento(string nombreTipoDocumento)
        {
            try
            {
                return _repositorio.GetTipoDocumento(nombreTipoDocumento);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipoDocumento tipoDocumento)
        {
            try
            {
                _repositorio.Guardar(tipoDocumento);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
