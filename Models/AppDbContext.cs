using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // ============================
        // TABLAS (DbSet)
        // ============================

        public DbSet<Tema> Temas { get; set; }

        public DbSet<Logro> Logros { get; set; }

        public DbSet<Jugador> Jugadores { get; set; }

        public DbSet<Partida> Partidas { get; set; }

        public DbSet<Pregunta> Preguntas { get; set; }

        public DbSet<LogroPartida> LogrosPartidas { get; set; }

        // ============================
        // CONFIGURACIÓN MODELOS
        // ============================

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ============================
            // TABLA TEMAS
            // ============================

            modelBuilder.Entity<Tema>(entity =>
            {
                entity.ToTable("Temas");

                entity.HasKey(t => t.Id);

                entity.Property(t => t.NombreTema)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            // ============================
            // TABLA LOGROS
            // ============================

            modelBuilder.Entity<Logro>(entity =>
            {
                entity.ToTable("Logros");

                entity.HasKey(l => l.Id);

                entity.Property(l => l.NombreLogro)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(l => l.Descripcion)
                    .HasMaxLength(300);

                entity.HasOne(l => l.Tema)
                    .WithMany(t => t.Logros)
                    .HasForeignKey(l => l.IdTema)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ============================
            // TABLA JUGADORES
            // ============================

            modelBuilder.Entity<Jugador>(entity =>
            {
                entity.ToTable("Jugadores");

                entity.HasKey(j => j.IdJugador);

                entity.Property(j => j.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(j => j.Apellido)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(j => j.Correo)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(j => j.Password)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            // ============================
            // TABLA PARTIDAS
            // ============================

            modelBuilder.Entity<Partida>(entity =>
            {
                entity.ToTable("Partidas");

                entity.HasKey(p => p.IdPartida);

                entity.Property(p => p.Estado)
                    .HasMaxLength(50);

                entity.HasOne<Jugador>()
                    .WithMany()
                    .HasForeignKey(p => p.IdJugador)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ============================
            // TABLA PREGUNTAS
            // ============================

            modelBuilder.Entity<Pregunta>(entity =>
            {
                entity.ToTable("Preguntas");

                entity.HasKey(p => p.IdPregunta);

                entity.Property(p => p.PreguntaTexto)
                    .IsRequired();

                entity.Property(p => p.OpcionA)
                    .HasMaxLength(200);

                entity.Property(p => p.OpcionB)
                    .HasMaxLength(200);

                entity.Property(p => p.OpcionC)
                    .HasMaxLength(200);

                entity.Property(p => p.OpcionD)
                    .HasMaxLength(200);

                entity.Property(p => p.Correcta)
                    .HasMaxLength(200);

                entity.HasOne<Tema>()
                    .WithMany()
                    .HasForeignKey(p => p.IdTema)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ============================
            // TABLA LOGROSPARTIDAS
            // ============================

            modelBuilder.Entity<LogroPartida>(entity =>
            {
                entity.ToTable("LogrosPartidas");

                entity.HasKey(lp => lp.IdLogroPartida);

                entity.HasOne<Logro>()
                    .WithMany()
                    .HasForeignKey(lp => lp.IdLogro)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<Partida>()
                    .WithMany()
                    .HasForeignKey(lp => lp.IdPartida)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}