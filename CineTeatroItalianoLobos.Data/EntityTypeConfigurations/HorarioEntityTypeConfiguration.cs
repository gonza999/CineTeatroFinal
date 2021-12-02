using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Data.EntityTypeConfigurations
{
    public class HorarioEntityTypeConfiguration:EntityTypeConfiguration<Horario>
    {
        public HorarioEntityTypeConfiguration()
        {
            ToTable("Horarios");
            HasKey(h=>h.HorarioId);
            Property(h => h.EventoId).IsRequired();
            Property(h => h.Fecha).HasColumnName("Fecha");
            Property(h => h.Hora).HasColumnName("Hora");
            Ignore(h => h.FechaYHora);
        }
    }
}
