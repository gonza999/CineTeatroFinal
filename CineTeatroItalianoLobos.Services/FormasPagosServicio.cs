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
    public class FormasPagosServicio:IFormasPagosServicio
    {
        private readonly IRepositorioFormasPagos _repositorio;
        private readonly IUnitOfWork _unitOfWork;

        public FormasPagosServicio(IRepositorioFormasPagos repositorio, IUnitOfWork unitOfWork)
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

        public List<FormaPago> BuscarFormaPago(string formaPago)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(FormaPago formaPago)
        {
            try
            {
                return _repositorio.EstaRelacionado(formaPago);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(FormaPago formaPago)
        {
            try
            {
                return _repositorio.Existe(formaPago);
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

        public List<FormaPago> GetLista(int registros, int pagina)
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

        public FormaPago GetTEntityPorId(int id)
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

        public FormaPago GetFormaPago(string nombreFormaPago)
        {
            try
            {
                return _repositorio.GetFormaPago(nombreFormaPago);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(FormaPago formaPago)
        {
            try
            {
                _repositorio.Guardar(formaPago);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
