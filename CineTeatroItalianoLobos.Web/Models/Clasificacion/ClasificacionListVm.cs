using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.Clasificacion
{
    public class ClasificacionListVm
    {
        public int ClasificacionId { get; set; }
        public string Descripcion { get; set; }
        public int CantidadEventos { get; set; }

    }
}