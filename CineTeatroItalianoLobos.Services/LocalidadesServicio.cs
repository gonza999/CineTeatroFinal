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
    public class LocalidadesServicio:ILocalidadesServicio
    {
        private readonly IRepositorioLocalidades _repositorio;
        private readonly IUnitOfWork _unitOfWork;

        public LocalidadesServicio(IRepositorioLocalidades repositorio, IUnitOfWork unitOfWork)
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

        public bool EstaRelacionado(Localidad localidad)
        {
            try
            {
                return _repositorio.EstaRelacionado(localidad);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Localidad localidad)
        {
            try
            {
                return _repositorio.Existe(localidad);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Localidad> Find(Func<Localidad, bool> p, int? cantidadPorPagina, int? paginaActual)
        {
            try
            {
                return _repositorio.Find(p, cantidadPorPagina, paginaActual);
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

        public int GetCantidad(Func<Localidad, bool> p)
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

        public List<string> GetFilas()
        {
            try
            {
                return _repositorio.GetFilas();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Localidad> GetLista(int registros, int pagina)
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

        public List<Localidad> GetLista(Ubicacion ubicacion)
        {
            try
            {
                return _repositorio.GetLista(ubicacion);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Localidad> GetLista(int fila)
        {
            try
            {
                return _repositorio.GetLista(fila);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public Localidad GetLocalidadPorId(int id)
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
        public void Guardar(Localidad localidad)
        {
            try
            {
                _repositorio.Guardar(localidad);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
