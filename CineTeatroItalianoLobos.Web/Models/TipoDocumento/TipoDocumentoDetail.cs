using CineTeatroItalianoLobos.Web.Models.Empleado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.TipoDocumento
{
    public class TipoDocumentoDetail
    {
        public int TipoDocumentoId { get; set; }
        public string Descripcion { get; set; }
        public int CantidadEmpleados { get; set; }
        public List<EmpleadoListVm> Empleados { get; set; }
    }
}