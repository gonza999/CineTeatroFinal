using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Data.EntityTypeConfigurations
{
    public class PlantaEntityTypeConfiguration:EntityTypeConfiguration<Planta>
    {
        public PlantaEntityTypeConfiguration()
        {
            ToTable("Plantas");
            HasKey(p=>p.PlantaId);
            Property(p=>p.Descripcion).HasColumnName("Planta").HasMaxLength(30).IsRequired();
        }
    }
}
