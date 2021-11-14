using CineTeatroItalianoLobos.Entities;
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

        #endregion
    }
}