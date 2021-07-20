using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Data.EntityTypeConfigurations
{
    public class EmpleadoEntityTypeConfiguration:EntityTypeConfiguration<Empleado>
    {
        public EmpleadoEntityTypeConfiguration()
        {
            ToTable("Empleados");
            HasKey(e=>e.EmpleadoId);
            Property(e=>e.Nombre).IsRequired().HasMaxLength(100);
            Property(e => e.Apellido).IsRequired().HasMaxLength(100);
            Property(e => e.NroDocumento).IsRequired().HasMaxLength(100);
            Property(e => e.TelefonoFijo).HasMaxLength(20);
            Property(e => e.TelefonoMovil).HasMaxLength(20);
            Property(e => e.Mail).HasMaxLength(150);
        }
    }
}
