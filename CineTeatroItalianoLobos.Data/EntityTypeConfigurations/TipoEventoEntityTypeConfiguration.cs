using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Data.EntityTypeConfigurations
{
    public class TipoEventoEntityTypeConfiguration:EntityTypeConfiguration<TipoEvento>
    {
        public TipoEventoEntityTypeConfiguration()
        {
            ToTable("TiposEventos");
            HasKey(te=>te.TipoEventoId);
            Property(te=>te.Descripcion).HasColumnName("TipoEvento").HasMaxLength(50).IsRequired();
        }
    }
}
