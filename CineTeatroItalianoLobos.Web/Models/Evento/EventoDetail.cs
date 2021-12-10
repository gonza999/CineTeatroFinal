using CineTeatroItalianoLobos.Web.Models.Horario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.Evento
{
    public class EventoDetail
    {
        public int EventoId { get; set; }
        [Display(Name = "Tipo de Evento")]
        public string TipoEvento { get; set; }
        public string Clasificacion { get; set; }
        [Display(Name = "Evento")]
        public string NombreEvento { get; set; }
        [Display(Name = "Fecha del Evento")]
        public string FechaEvento { get; set; }
        public string Descripcion { get; set; }
        public bool Suspendido { get; set; }
        public string Distribucion { get; set; }
        public int CantidadHorarios { get; set; }

        public List<HorarioListVm> Horarios { get; set; }
    }
}