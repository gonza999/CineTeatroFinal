using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.Planta
{
    public class PlantaListVm
    {
        public int PlantaId { get; set; }
        public string Descripcion { get; set; }
        public int CantidadLocalidades { get; set; }

    }
}