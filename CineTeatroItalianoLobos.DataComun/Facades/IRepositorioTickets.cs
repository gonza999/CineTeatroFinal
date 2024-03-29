﻿using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.DataComun.Facades
{
    public interface IRepositorioTickets:IRepositorio<Ticket>
    {
        bool Existe(Localidad localidad, Horario horario);
        void AnularTicket(int ticketId);
        List<Ticket> GetLista(List<Horario> horarios);
        void BorrarPorHorario(int id);
        List<Ticket> GetLista(Horario horario);
        List<Ticket> GetLista(Evento evento);
        List<Ticket> GetLista(Venta venta);
        int GetCantidad(Func<Ticket, bool> p);
        List<Ticket> GetLista();
    }
}
