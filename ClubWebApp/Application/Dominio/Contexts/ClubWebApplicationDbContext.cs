using ClubWebApp.Application.Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClubWebApp.Aplication.Dominio.Contexts
{
    public class ClubWebApplicationDbContext : DbContext
    {
        public ClubWebApplicationDbContext(DbContextOptions<ClubWebApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<EventosPublicos> EventosPublicos { get; set; }
        public virtual DbSet<Eventos> Eventos { get; set; }

        #region Método Override DbContext
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region CLIENTES
            modelBuilder.Entity<Clientes>(tb =>
            {
                tb.HasKey(col => col.ClienteId);
                tb.Property(col => col.ClienteId)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.ClienteId).IsRequired().IsUnicode(false);
                tb.Property(col => col.Codigo).IsRequired().IsUnicode(false).HasMaxLength(30);
                tb.Property(col => col.NombreCompleto).IsRequired().IsUnicode(false).HasMaxLength(250);
                tb.Property(col => col.Cedula).IsRequired().IsUnicode(false).HasMaxLength(50);
                tb.Property(col => col.Telefono).IsRequired().IsUnicode(false).HasMaxLength(30);
                tb.Property(col => col.Celular).IsRequired().IsUnicode(false).HasMaxLength(30);
                tb.Property(col => col.Email).IsRequired().IsUnicode(false).HasMaxLength(50);
                tb.Property(col => col.Direccion).IsRequired().IsUnicode(false).HasMaxLength(250);
                tb.Property(col => col.FechaIngreso).IsRequired().IsUnicode(false).HasColumnType("DateTime");
                tb.Property(col => col.Activo).IsRequired().IsUnicode(false).HasMaxLength(10);
                tb.Property(col => col.IsStatu).IsRequired().IsUnicode(false);
                //tb.Property(col => col.Usuario).IsRequired().IsUnicode(false).HasMaxLength(50);
                tb.Property(col => col.PasswordUser).IsRequired().IsUnicode(false).HasMaxLength(10);
                tb.Property(col => col.IsDeletedBy).IsUnicode(false);
                tb.Property(col => col.IsDeletedAt).IsUnicode(false).HasColumnType("DateTime");
                tb.Property(col => col.IsUpdatedBy).IsUnicode(false);
                tb.Property(col => col.IsUpdatedAt).IsUnicode(false).HasColumnType("DateTime");
                tb.HasQueryFilter(col => !col.IsDeletedBy);

            });

            modelBuilder.Entity<Clientes>().ToTable("Clientes");

            #endregion

            #region EVENTOS PUBLICOS 
            modelBuilder.Entity<EventosPublicos>(tb =>
            {
                tb.HasKey(col => col.EventoPublicoId);
                tb.Property(col => col.EventoPublicoId)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.ClienteId).IsRequired().IsUnicode(false);
                tb.Property(col => col.Nombre).IsRequired().IsUnicode(false).HasMaxLength(250);
                tb.Property(col => col.Lugar).IsRequired().IsUnicode(false).HasMaxLength(250);
                tb.Property(col => col.Atracciones).IsRequired().IsUnicode(false).HasMaxLength(250);
                tb.Property(col => col.Descripcion).IsRequired().IsUnicode(false).HasMaxLength(250);
                tb.Property(col => col.Fecha).IsRequired().IsUnicode(false).HasColumnType("DateTime");
                tb.Property(col => col.Tipo).IsRequired().IsUnicode(false).HasMaxLength(250);
                tb.Property(col => col.Direccion).IsRequired().IsUnicode(false).HasMaxLength(250);
                tb.Property(col => col.HoraInicio).IsRequired().IsUnicode(false).HasMaxLength(20);
                tb.Property(col => col.HoraFinalizacion).IsRequired().IsUnicode(false).HasMaxLength(20);
                tb.Property(col => col.IsDeletedAt).IsUnicode(false).HasColumnType("DateTime");
                tb.Property(col => col.IsDeletedBy).IsUnicode(false);
                tb.Property(col => col.IsUpdatedAt).IsUnicode(false).HasColumnType("DateTime");
                tb.Property(col => col.IsUpdatedBy).IsUnicode(false);

            });

            modelBuilder.Entity<Eventos>().ToTable("EventosPublicos");
            #endregion

            #region EVENTOS
            modelBuilder.Entity<Eventos>(tb =>
            {
                tb.HasKey(col => col.EventoId);
                tb.Property(col => col.EventoId)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

                tb.Property(col => col.ClienteId).IsRequired().IsUnicode(false);
                tb.Property(col => col.Codigo).IsRequired().IsUnicode(false).HasMaxLength(30);
                tb.Property(col => col.Descripcion).IsRequired().IsUnicode(false).HasMaxLength(250);
                tb.Property(col => col.Fecha_Evento).IsRequired().IsUnicode(false).HasColumnType("DateTime");
                tb.Property(col => col.Salon).IsRequired().IsUnicode(false).HasMaxLength(80);
                tb.Property(col => col.Numero_Salon).IsRequired().IsUnicode(false).HasMaxLength(20);
                tb.Property(col => col.Ubicacion).IsRequired().IsUnicode(false).HasMaxLength(100);
                tb.Property(col => col.Cantidad_Personas).IsRequired().IsUnicode(false);
                tb.Property(col => col.Nombre).IsRequired().IsUnicode(false).HasMaxLength(250);
                tb.Property(col => col.HoraInicio).IsRequired().IsUnicode(false).HasMaxLength(20);
                tb.Property(col => col.HoraFinalizacion).IsRequired().IsUnicode(false).HasMaxLength(20);
                tb.Property(col => col.IsDeletedBy).IsUnicode(false);
                tb.Property(col => col.IsDeletedAt).IsUnicode(false).HasColumnType("DateTime");
                tb.Property(col => col.IsUpdatedBy).IsUnicode(false);
                tb.Property(col => col.IsUpdatedAt).IsUnicode(false).HasColumnType("DateTime");
                tb.Property(col => col.Estado).IsRequired().IsUnicode(false).HasMaxLength(30);

            });

            modelBuilder.Entity<Eventos>().ToTable("Eventos");

            #endregion
        }

        #endregion
    }
}
