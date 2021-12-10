using CineTeatroItalianoLobos.Web.Models.Evento;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.Horario
{
    public class HorarioEditVm
    {
        public int HorarioId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Time)]
        public DateTime Hora { get; set; }
        [Display(Name = "Evento")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int EventoId { get; set; }
        public EventoEditVm Evento { get; set; }

    }
}