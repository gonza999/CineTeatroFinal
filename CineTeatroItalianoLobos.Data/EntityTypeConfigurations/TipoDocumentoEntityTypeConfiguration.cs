using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Data.EntityTypeConfigurations
{
    public class TipoDocumentoEntityTypeConfiguration:EntityTypeConfiguration<TipoDocumento>
    {
        public TipoDocumentoEntityTypeConfiguration()
        {
            ToTable("TiposDocumentos");
            HasKey(td=>td.TipoDocumentoId);
            Property(td=>td.Descripcion).HasColumnName("TipoDocumento").HasMaxLength(50);
        }
    }
}
