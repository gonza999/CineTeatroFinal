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
    public class EventosServicio:IEventosServicios
    {
        private readonly IRepositorioEventos _repositorio;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepositorioHorarios _repositorioHorarios;
        private readonly IRepositorioVentas _repositorioVentas;
        private readonly IRepositorioTickets _repositorioTickets;


        public EventosServicio(IRepositorioEventos repositorio, IUnitOfWork unitOfWork,
            IRepositorioHorarios repositorioHorarios,
            IRepositorioVentas repositorioVentas,
            IRepositorioTickets repositorioTickets)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
            _repositorioHorarios = repositorioHorarios;
            _repositorioVentas = repositorioVentas;
            _repositorioTickets = repositorioTickets;
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

        public void Desuspender(Evento evento)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    _repositorio.Guardar(evento);
                    _unitOfWork.Save();
                    List<Ticket> listaTickets = _repositorioTickets.GetLista(evento);
                    foreach (var t in listaTickets)
                    {
                        t.Anulada = false;
                        _repositorioTickets.Guardar(t);
                        _unitOfWork.Save();
                        foreach (var vt in t.VentasTickets)
                        {
                            vt.Venta.Estado = false;
                            _repositorioVentas.Guardar(vt.Venta);
                        }
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

        public List<Evento> Find(Func<Evento, bool> predicate, int? cantidadPorPagina, int? paginaActual)
        {
            try
            {
                return _repositorio.Find(predicate, cantidadPorPagina, paginaActual);
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

        public int GetCantidad(Func<Evento, bool> p)
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

        public List<Evento> GetLista()
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

        public List<Evento> GetLista(Distribucion distribucion, TipoEvento tipoEvento, 
            Clasificacion clasificacion)
        {
            try
            {
                return _repositorio.GetLista(distribucion, tipoEvento, clasificacion);
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

        public void Guardar(Evento evento,List<Horario> listaHorariosBorrados)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    _repositorio.Guardar(evento);
                    _unitOfWork.Save();
                    foreach (var h in evento.Horarios)
                    {
                        h.EventoId = h.EventoId;
                        _repositorioHorarios.Guardar(h);
                    }
                    foreach (var h in listaHorariosBorrados)
                    {
                        Borrar(h.HorarioId);
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

        public void Suspender(Evento evento)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    _repositorio.Guardar(evento);
                    _unitOfWork.Save();
                    List<Ticket> listaTickets= _repositorioTickets.GetLista(evento);
                    foreach (var t in listaTickets)
                    {
                        t.Anulada = true;
                        _repositorioTickets.Guardar(t);
                        _unitOfWork.Save();
                        foreach (var vt in t.VentasTickets)
                        {
                            vt.Venta.Estado = true;
                            _repositorioVentas.Guardar(vt.Venta);
                        }
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
