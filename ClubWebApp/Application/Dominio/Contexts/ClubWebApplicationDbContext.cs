using ClubWebApp.Application.Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClubWebApp.Aplication.Dominio.Contexts
{
    public class ClubWebApplicationDbContext : DbContext
    {
        public ClubWebApplicationDbContext(DbContextOptions<ClubWebApplicationDbContext> options) : base(options) { }
        
        public virtual DbSet<Eventos> Eventos { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }


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
        }

        #endregion
    }
}
