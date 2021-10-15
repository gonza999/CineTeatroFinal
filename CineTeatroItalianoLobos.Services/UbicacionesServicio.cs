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
    public class UbicacionesServicio:IUbicacionesServicio
    {
        private readonly IRepositorioUbicaciones _repositorio;
        private readonly IUnitOfWork _unitOfWork;

        public UbicacionesServicio(IRepositorioUbicaciones repositorio, IUnitOfWork unitOfWork)
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

        public List<Ubicacion> BuscarUbicacion(string ubicacion)
        {
            throw new NotImplementedException();
        }

        public bool EstaRelacionado(Ubicacion ubicacion)
        {
            try
            {
                return _repositorio.EstaRelacionado(ubicacion);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Ubicacion ubicacion)
        {
            try
            {
                return _repositorio.Existe(ubicacion);
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

        public List<Ubicacion> GetLista(int registros, int pagina)
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

        public Ubicacion GetTEntityPorId(int id)
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

        public Ubicacion GetUbicacion(string nombreUbicacion)
        {
            try
            {
                return _repositorio.GetUbicacion(nombreUbicacion);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Ubicacion ubicacion)
        {
            try
            {
                _repositorio.Guardar(ubicacion);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
