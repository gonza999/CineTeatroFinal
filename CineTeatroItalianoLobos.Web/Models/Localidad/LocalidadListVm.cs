using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.Localidad
{
    public class LocalidadListVm
    {
        public int LocalidadId { get; set; }
        [Display(Name ="Planta")]
        public string Planta { get; set; }
        [Display(Name = "Numero")]
        public int Numero { get; set; }
        [Display(Name = "Ubicacion")]
        public string Ubicacion { get; set; }
        [Display(Name = "Fila")]
        public int Fila { get; set; }
        public bool Ocupado { get; set; }

        public string Detalles { get; set; }

        public void SetearDetalles()
        {
            var detalles = $"Planta : {Planta}, Ubicacion : {Ubicacion}, Fila : {Fila}, Numero : {Numero}";
            Detalles = detalles;
        }
    }
}