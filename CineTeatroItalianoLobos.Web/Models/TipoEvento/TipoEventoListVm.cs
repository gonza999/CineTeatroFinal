using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.TipoEvento
{
    public class TipoEventoListVm
    {
        public int TipoEventoId { get; set; }
        public string Descripcion { get; set; }
        public int CantidadEventos { get; set; }
    }
}