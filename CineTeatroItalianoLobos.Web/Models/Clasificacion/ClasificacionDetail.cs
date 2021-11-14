using CineTeatroItalianoLobos.Web.Models.Evento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.Clasificacion
{
    public class ClasificacionDetail
    {
        public int ClasificacionId { get; set; }
        public string Descripcion { get; set; }
        public int CantidadEventos { get; set; }
        public List<EventoListVm> Eventos { get; set; }
    }
}