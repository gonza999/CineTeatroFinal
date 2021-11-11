using CineTeatroItalianoLobos.DataComun;
using CineTeatroItalianoLobos.DataComun.Facades;
using CineTeatroItalianoLobos.Entities;
using CineTeatroItalianoLobos.Services.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CineTeatroItalianoLobos.Services
{
    public class DistribucionesServicio:IDistribucionesServicio
    {
        private readonly IRepositorioDistribuciones _repositorio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositorioDistribucionesLocalidades _repositorioDistribucionesLocalidades;

        public DistribucionesServicio(IRepositorioDistribuciones repositorio, IUnitOfWork unitOfWork,
            IRepositorioDistribucionesLocalidades repositorioDistribucionesLocalidades)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
            _repositorioDistribucionesLocalidades = repositorioDistribucionesLocalidades;
        }
        public void Borrar(int id)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    _repositorioDistribucionesLocalidades.Borrar(id);
                    _repositorio.Borrar(id);
                    _unitOfWork.Save();
                    scope.Complete();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public bool EstaRelacionado(Distribucion distribucion)
        {
            try
            {
                return _repositorio.EstaRelacionado(distribucion);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Distribucion distribucion)
        {
            try
            {
                return _repositorio.Existe(distribucion);
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

        public List<Distribucion> GetLista(int registros, int pagina)
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

        public List<Distribucion> GetLista()
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

        public Distribucion GetTEntityPorId(int id)
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
        public void Guardar(Distribucion distribucion)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    _repositorio.Guardar(distribucion);
                    _unitOfWork.Save();
                    foreach (var dl in distribucion.DistribucionesLocalidades)
                    {
                        dl.DistribucionId = distribucion.DistribucionId;
                        _repositorioDistribucionesLocalidades.Guardar(dl);
                    }
                    _unitOfWork.Save();
                    scope.Complete();
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }
        }
    }
}
