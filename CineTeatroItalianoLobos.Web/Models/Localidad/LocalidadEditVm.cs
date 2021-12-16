using CineTeatroItalianoLobos.Web.Models.Planta;
using CineTeatroItalianoLobos.Web.Models.Ubicacion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.Localidad
{
    public class LocalidadEditVm
    {
        public int LocalidadId { get; set; }
        [Display(Name = "Planta")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una planta")]
        public int PlantaId { get; set; }
        public PlantaListVm Planta { get; set; }
        public List<PlantaListVm> Plantas { get; set; }
        public int Numero { get; set; }
        [Display(Name = "Ubicacion")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una ubicacion")]
        public int UbicacionId { get; set; }
        public UbicacionListVm Ubicacion { get; set; }
        public List<UbicacionListVm> Ubicaciones { get; set; }

        [Display(Name = "Fila")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Fila { get; set; }
    }
}