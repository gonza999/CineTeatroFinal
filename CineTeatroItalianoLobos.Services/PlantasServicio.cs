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
    public class PlantasServicio:IPlantasServicio
    {
        private readonly IRepositorioPlantas _repositorio;
        private readonly IUnitOfWork _unitOfWork;

        public PlantasServicio(IRepositorioPlantas repositorio, IUnitOfWork unitOfWork)
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

        public List<Planta> BuscarPlanta(string planta)
        {
            try
            {
                return _repositorio.BuscarPlanta(planta);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Planta planta)
        {
            try
            {
                return _repositorio.EstaRelacionado(planta);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Planta planta)
        {
            try
            {
                return _repositorio.Existe(planta);
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

        public List<Planta> GetLista(int registros, int pagina)
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

        public Planta GetTEntityPorId(int id)
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

        public Planta GetPlanta(string nombrePlanta)
        {
            try
            {
                return _repositorio.GetPlanta(nombrePlanta);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Planta planta)
        {
            try
            {
                _repositorio.Guardar(planta);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
