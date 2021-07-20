using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Data.EntityTypeConfigurations
{
    public class FormaPagoEntityTypeConfiguration:EntityTypeConfiguration<FormaPago>
    {
        public FormaPagoEntityTypeConfiguration()
        {
            ToTable("FormasPagos");
            HasKey(fp => fp.FormaPagoId);
            Property(fp => fp.Descripcion).HasColumnName("FormaPago").IsRequired().HasMaxLength(50);
        }
    }
}
