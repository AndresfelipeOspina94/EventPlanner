using EventPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Data
{
    public class EventPlannerContext : DbContext
    {
        public EventPlannerContext(DbContextOptions<EventPlannerContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Registro> Registros { get; set; }
        public DbSet<Recurso> Recursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>()
                .HasOne(e => e.Ubicacion)
                .WithMany(u => u.Eventos)
                .HasForeignKey(e => e.IdUbicacion);

            modelBuilder.Entity<Registro>()
                .HasOne(r => r.Evento)
                .WithMany(e => e.Registros)
                .HasForeignKey(r => r.IdEvento);

            modelBuilder.Entity<Registro>()
                .HasOne(r => r.Participante)
                .WithMany(p => p.Registros)
                .HasForeignKey(r => r.IdParticipante);

            modelBuilder.Entity<Recurso>()
                .HasOne(r => r.Evento)
                .WithMany(e => e.Recursos)
                .HasForeignKey(r => r.IdEvento);
        }
    }
}
