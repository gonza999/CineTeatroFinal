using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.Distribucion
{
    public class DistribucionListVm
    {
        public int DistribucionId { get; set; }
        public string Descripcion { get; set; }
        public int CantidadEventos { get; set; }

    }
}