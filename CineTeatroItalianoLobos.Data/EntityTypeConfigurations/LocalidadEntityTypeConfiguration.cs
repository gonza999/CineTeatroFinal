using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Data.EntityTypeConfigurations
{
    public class LocalidadEntityTypeConfiguration:EntityTypeConfiguration<Localidad>
    {
        public LocalidadEntityTypeConfiguration()
        {
            ToTable("Localidades");
            HasKey(l=>l.LocalidadId);
            Property(l => l.UbicacionId).IsRequired();
            Property(l => l.LocalidadId).IsRequired();

        }
    }
}
