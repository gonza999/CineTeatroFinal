using CineTeatroItalianoLobos.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;

namespace CineTeatroItalianoLobos.Data
{
    public partial class CineTeatroDbContext : DbContext
    {
        public CineTeatroDbContext()
            : base("name=CineTeatroDbContext")
        {
        }

        public virtual DbSet<Clasificacion> Clasificaciones { get; set; }
        public virtual DbSet<Distribucion> Distribuciones { get; set; }
        public virtual DbSet<DistribucionLocalidad> DistribucionesLocalidades { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<FormaPago> FormasPagos { get; set; }
        public virtual DbSet<FormaVenta> FormasVentas { get; set; }
        public virtual DbSet<Horario> Horarios { get; set; }
        public virtual DbSet<Localidad> Localidades { get; set; }
        public virtual DbSet<Planta> Plantas { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TipoDocumento> TiposDocumentos { get; set; }
        public virtual DbSet<TipoEvento> TiposEventos { get; set; }
        public virtual DbSet<Ubicacion> Ubicaciones { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }
        public virtual DbSet<VentaTicket> VentasTickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<CineTeatroDbContext>(null);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
