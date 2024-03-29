﻿using CineTeatroItalianoLobos.DataComun;
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
    public class VentasServicio : IVentasServicio
    {
        private readonly IRepositorioVentas _repositorio;
        private readonly IRepositorioTickets _repositorioTickets;
        private readonly IRepositorioVentasTickets _repositorioVentaTickets;

        private readonly IUnitOfWork _unitOfWork;

        public VentasServicio(IRepositorioVentas repositorio,
            IRepositorioTickets repositorioTickets, IRepositorioVentasTickets repositorioVentaTickets, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
            _repositorioTickets = repositorioTickets;
            _repositorioVentaTickets = repositorioVentaTickets;
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

        public List<Venta> GetLista(int registros, int pagina)
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

        public List<Venta> GetLista(Empleado empleado)
        {
            try
            {
                return _repositorio.GetLista(empleado);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Venta> GetLista()
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

        public void Guardar(Venta venta)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    foreach (var vt in venta.VentasTickets)
                    {
                        _repositorioTickets.Guardar(vt.Ticket);
                        _unitOfWork.Save();
                        vt.TicketId = vt.Ticket.TicketId;
                    }
                    _repositorio.Guardar(venta);
                    //_unitOfWork.Save();
                    //foreach (var vt in venta.VentasTickets)
                    //{
                    //    vt.VentaId = venta.VentaId;
                    //    _repositorioVentaTickets.Guardar(vt);
                    //}
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

