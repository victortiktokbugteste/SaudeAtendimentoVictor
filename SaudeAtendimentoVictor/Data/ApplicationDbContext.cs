using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SaudeAtendimentoVictor.Models;

namespace SaudeAtendimentoVictor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Atendimento> Atendimento { get; set; }
        public DbSet<Triagem> Triagem { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Status> Status { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ConfigurePaciente(modelBuilder);
            ConfigureTriagem(modelBuilder);
            ConfigureAtendimento(modelBuilder);
            ConfigureEspecialidade(modelBuilder);
            ConfigureStatus(modelBuilder);
        }

        private void ConfigurePaciente(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paciente>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Paciente>()
                .Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Paciente>()
            .Property(x => x.Telefone)
            .HasMaxLength(20);

            modelBuilder.Entity<Paciente>()
            .Property(x => x.Sexo)
            .HasMaxLength(20);

            modelBuilder.Entity<Paciente>()
            .Property(x => x.Email)
            .HasMaxLength(100);
        }
        private void ConfigureTriagem(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Triagem>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Triagem>()
             .Property(x => x.AtendimentoID)
             .IsRequired();

            modelBuilder.Entity<Triagem>()
            .HasOne(x => x.Atendimento)
            .WithMany()
            .HasForeignKey(x => x.AtendimentoID)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Triagem>()
            .Property(m => m.PressaoArterial)
            .HasColumnType("nvarchar(10)");

            modelBuilder.Entity<Triagem>()
           .Property(p => p.Peso)
           .HasColumnType("nvarchar(10)");

            modelBuilder.Entity<Triagem>()
             .Property(p => p.Altura)
             .HasColumnType("nvarchar(10)");

            modelBuilder.Entity<Triagem>()
            .Property(x => x.EspecialidadeID)
            .IsRequired();

            modelBuilder.Entity<Triagem>()
            .HasOne(x => x.Especialidade)
            .WithMany()
            .HasForeignKey(x=> x.EspecialidadeID)
            .OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigureAtendimento(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atendimento>()
            .HasKey(x => x.Id);

            modelBuilder.Entity<Atendimento>()
            .Property(x => x.NumeroSequencial)
            .IsRequired();

            modelBuilder.Entity<Atendimento>()
             .Property(x => x.PacienteID)
             .IsRequired();

            modelBuilder.Entity<Atendimento>()
            .Property(e => e.DataHoraChegada)
            .HasColumnType("datetime");

            modelBuilder.Entity<Atendimento>()
            .HasOne(x => x.Paciente)
            .WithMany()
            .HasForeignKey(x => x.PacienteID)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Atendimento>()
             .Property(x => x.StatusID)
             .IsRequired();

            modelBuilder.Entity<Atendimento>()
              .HasOne(x => x.Status)
              .WithMany()
              .HasForeignKey(x => x.StatusID)
              .OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigureEspecialidade(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidade>()
            .HasKey(x => x.Id);
        }

        private void ConfigureStatus(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>()
                        .HasKey(x => x.Id);
        }

    }
}
