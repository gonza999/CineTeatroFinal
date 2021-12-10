using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.Horario
{
    public class HorarioListVm
    {
        public HorarioListVm()
        {
            SetearFechaYHora();
        }
        public int HorarioId { get; set; }
        [DataType(DataType.Date)]

        public DateTime Fecha { get; set; }
        [DataType(DataType.Time)]

        public DateTime Hora { get; set; }
        public string Evento { get; set; }
        public string FechaYHora { get; set; }

        public void SetearFechaYHora()
        {
            string minutos = "";
            string hora = "";
            if (Hora.TimeOfDay.Minutes < 10)
            {
                minutos = "0" + Hora.TimeOfDay.Minutes;
            }
            else
            {
                minutos = Hora.TimeOfDay.Minutes.ToString();
            }
            if (Hora.TimeOfDay.Hours < 10)
            {
                hora = "0" + Hora.TimeOfDay.Hours;
            }
            else
            {
                hora = Hora.TimeOfDay.Hours.ToString();
            }
            FechaYHora = Fecha.Year + "/" +
Fecha.Month + "/" +
Fecha.Day + " " + hora + ":" + minutos;
        }
    }
}