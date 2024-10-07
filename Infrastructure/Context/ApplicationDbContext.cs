using Microsoft.EntityFrameworkCore;
using netchallenge.Domain.Entities;
using System.Collections.Generic;

namespace netchallenge.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Tratamento> Tratamentos { get; set; }
        public DbSet<Sinistro> Sinistros { get; set; }
        public DbSet<Recomendacao> Recomendacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Sinistro>()
                .HasOne(s => s.Paciente)
                .WithMany(p => p.Sinistros)
                .HasForeignKey(s => s.PacienteId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Sinistro>()
                .HasOne(s => s.Tratamento)
                .WithMany(t => t.Sinistros)
                .HasForeignKey(s => s.TratamentoId)
                .OnDelete(DeleteBehavior.Restrict);

           
            modelBuilder.Entity<Recomendacao>()
                .HasOne(r => r.Paciente)
                .WithMany(p => p.Recomendacoes)
                .HasForeignKey(r => r.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Recomendacao>()
                .HasOne(r => r.Tratamento)
                .WithMany(t => t.Recomendacoes)
                .HasForeignKey(r => r.TratamentoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}