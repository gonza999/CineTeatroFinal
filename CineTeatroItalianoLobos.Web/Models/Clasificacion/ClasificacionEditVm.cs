using CineTeatroItalianoLobos.Web.Models.Evento;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.Clasificacion
{
    public class ClasificacionEditVm
    {
        public int ClasificacionId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Descripcion { get; set; }


    }
}