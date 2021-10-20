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
    public class ClasificacionesServicio:IClasificacionesServicio
    {
        private readonly IRepositorioClasificaciones _repositorio;
        private readonly IUnitOfWork _unitOfWork;

        public ClasificacionesServicio(IRepositorioClasificaciones repositorio, IUnitOfWork unitOfWork)
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

        public List<Clasificacion> BuscarClasificacion(string clasificacion)
        {
            try
            {
                return _repositorio.BuscarClasificacion(clasificacion);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Clasificacion clasificacion)
        {
            try
            {
                return _repositorio.EstaRelacionado(clasificacion);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Clasificacion clasificacion)
        {
            try
            {
                return _repositorio.Existe(clasificacion);
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

        public List<Clasificacion> GetLista(int registros, int pagina)
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

        public Clasificacion GetTEntityPorId(int id)
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

        public Clasificacion GetClasificacion(string nombreClasificacion)
        {
            try
            {
                return _repositorio.GetClasificacion(nombreClasificacion);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Clasificacion clasificacion)
        {
            try
            {
                _repositorio.Guardar(clasificacion);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
