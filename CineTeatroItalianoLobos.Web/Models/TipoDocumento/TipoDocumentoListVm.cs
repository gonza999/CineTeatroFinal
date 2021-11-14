using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.TipoDocumento
{
    public class TipoDocumentoListVm
    {
        public int TipoDocumentoId { get; set; }
        public string Descripcion { get; set; }
        public int CantidadEmpleados { get; set; }
    }
}