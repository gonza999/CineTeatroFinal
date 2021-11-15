using CineTeatroItalianoLobos.Web.Models.TipoDocumento;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.Empleado
{
    public class EmpleadoEditVm
    {
        public int EmpleadoId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Apellido { get; set; }
        [Display(Name = "Tipos de Documentos")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de documento")]
        public int TipoDocumentoId { get; set; }
        public TipoDocumentoListVm TipoDocumento { get; set; }
        public List<TipoDocumentoListVm> TiposDocumentos { get; set; }
        [Display(Name = "Número de Documento")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(10, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 1)]
        public string NroDocumento { get; set; }
        [Display(Name = "Teléfono Fijo")]
        [StringLength(20, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres")]
        public string TelefonoFijo { get; set; }
        [Display(Name = "Teléfono Movil")]
        [StringLength(20, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres")]
        public string TelefonoMovil { get; set; }
        [StringLength(150, ErrorMessage = "El campo {0} no puede contener más de {1} caracteres")]
        public string Mail { get; set; }
    }
}