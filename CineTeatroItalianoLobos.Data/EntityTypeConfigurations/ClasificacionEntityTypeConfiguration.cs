using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Data.EntityTypeConfigurations
{
    public class ClasificacionEntityTypeConfiguration:EntityTypeConfiguration<Clasificacion>
    {
        public ClasificacionEntityTypeConfiguration()
        {
            ToTable("Clasificaciones");
            HasKey(c=>c.ClasificacionId);
            Property(c=>c.Descripcion).HasColumnName("Clasificacion").IsRequired().HasMaxLength(50);
        }
    }
}
