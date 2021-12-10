using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.Evento
{
    public class EventoListVm
    {
        public int EventoId { get; set; }
        [Display(Name = "Evento")]
        public string NombreEvento { get; set; }
        [Display(Name = "Tipo de Evento")]
        public string TipoEvento { get; set; }
        [Display(Name = "Clasificacion")]
        public string Clasificacion { get; set; }
        [Display(Name = "Suspendido")]
        public bool Suspendido { get; set; }
        [Display(Name = "Distribucion")]
        public string Distribucion { get; set; }

        [Display(Name = "Horarios")]
        public int CantidadHorarios { get; set; }
    }
}