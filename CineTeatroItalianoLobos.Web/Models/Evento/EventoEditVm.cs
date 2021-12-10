using CineTeatroItalianoLobos.Web.Models.Clasificacion;
using CineTeatroItalianoLobos.Web.Models.Distribucion;
using CineTeatroItalianoLobos.Web.Models.Horario;
using CineTeatroItalianoLobos.Web.Models.TipoEvento;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.Evento
{
    public class EventoEditVm
    {
        public int EventoId { get; set; }
        [Display(Name = "Evento")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(120, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string NombreEvento { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(250, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Descripcion { get; set; }
        [Display(Name = "Tipos de Eventos")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de evento")]
        public int TipoEventoId { get; set; }
        public TipoEventoListVm TipoEvento { get; set; }
        public List<TipoEventoListVm> TiposEventos { get; set; }
        [Display(Name = "Clasificaciones")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una clasificación")]
        public int ClasificacionId { get; set; }
        public ClasificacionListVm Clasificacion { get; set; }
        public List<ClasificacionListVm> Clasificaciones { get; set; }
        [Display(Name = "Distribuciones")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una distribución")]
        public int DistribucionId { get; set; }
        public DistribucionListVm Distribucion { get; set; }
        public List<DistribucionListVm> Distribuciones { get; set; }
        [Display(Name = "Fecha del Evento")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime FechaEvento { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public bool Suspendido { get; set; }
        [Display(Name = "Lista de Horarios")]
        public List<HorarioEditVm> Horarios { get; set; }
    }
}