using CineTeatroItalianoLobos.Web.Models.Localidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.Ubicacion
{
    public class UbicacionDetail
    {
        public int UbicacionId { get; set; }
        public string Descripcion { get; set; }
        public int CantidadLocalidades { get; set; }
        public List<LocalidadListVm> Localidades { get; set; }
    }
}