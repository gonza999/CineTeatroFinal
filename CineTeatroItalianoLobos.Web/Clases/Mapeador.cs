using CineTeatroItalianoLobos.Entities;
using CineTeatroItalianoLobos.Web.Models.Evento;
using CineTeatroItalianoLobos.Web.Models.TipoEvento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Clases
{
    public class Mapeador
    {
        #region TipoEventos
        public static List<TipoEventoListVm> ConstruirListaTipoEventoVm(List<TipoEvento> lista)
        {
            var listaVm = new List<TipoEventoListVm>();
            foreach (var te in lista)
            {
                var tipoEventoListVm = ConstruirTipoEventoListVm(te);
                listaVm.Add(tipoEventoListVm);
            }
            return listaVm;
        }

        public static TipoEventoListVm ConstruirTipoEventoListVm(TipoEvento te)
        {
            return new TipoEventoListVm()
            {
                TipoEventoId = te.TipoEventoId,
                Descripcion=te.Descripcion
            };
        }

        public static TipoEvento ContruirTipoEvento(TipoEventoEditVm tipoEventoEditVm)
        {
            return new TipoEvento()
            {
                TipoEventoId = tipoEventoEditVm.TipoEventoId,
                Descripcion = tipoEventoEditVm.Descripcion
            };
        }

        public static TipoEventoEditVm ConstruirTipoEventoEditVm(TipoEvento tipoEvento)
        {
            return new TipoEventoEditVm()
            {
                TipoEventoId = tipoEvento.TipoEventoId,
                Descripcion = tipoEvento.Descripcion
            };
        }

        public static TipoEventoDetail ConstruirTipoEventoDetailsVm(TipoEvento tipoEvento)
        {
            return new TipoEventoDetail()
            {
                TipoEventoId = tipoEvento.TipoEventoId,
                Descripcion = tipoEvento.Descripcion
            };
        }

        #endregion

        #region Eventos
        public static List<EventoListVm> ConstruirListaEventosVm(List<Evento> lista)
        {
            var listaVm = new List<EventoListVm>();
            foreach (var e in lista)
            {
                var eventoListVm = ConstruirEventoListVm(e);
                listaVm.Add(eventoListVm);
            }
            return listaVm;
        }

        public static EventoListVm ConstruirEventoListVm(Evento e)
        {
            return new EventoListVm()
            {
                EventoId = e.EventoId,
                NombreEvento=e.NombreEvento,
                Descripcion=e.Descripcion,
                Suspendido=e.Suspendido,
                TipoEvento=e.TipoEvento.Descripcion,
                Clasificacion=e.Clasificacion.Descripcion,
                Distribucion=e.Distribucion.Descripcion
            };
        }
        #endregion
    }
}