using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.Empleado
{
    public class EmpleadoListVm
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string Mail { get; set; }
    }
}