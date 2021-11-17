using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.Empleado
{
    public class EmpleadoDetail
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Display(Name ="Tipo de Documento")]
        public string TipoDocumento { get; set; }
        [Display(Name = "Número de Documento")]
        public string NroDocumento { get; set; }
        [Display(Name = "Teléfono Fijo")]
        public string TelefonoFijo { get; set; }
        [Display(Name = "Teléfono Movil")]
        public string TelefonoMovil { get; set; }
        public string Mail { get; set; }

        //public int CantidadVentas { get; set; }
    }
}