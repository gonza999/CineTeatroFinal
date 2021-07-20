using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Data.EntityTypeConfigurations
{
    public class EventoEntityTypeConfiguration:EntityTypeConfiguration<Evento>
    {
        public EventoEntityTypeConfiguration()
        {
            ToTable("Eventos");
            HasKey(e=>e.EventoId);
            Property(e=>e.NombreEvento).HasColumnName("Evento").
                IsRequired().HasMaxLength(120);
            Property(e=>e.Descripcion).IsRequired().HasMaxLength(250);
        }
    }
}
