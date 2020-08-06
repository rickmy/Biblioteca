using Biblioteca.Negocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Biblioteca.AccesoDatos
{
    public class ApplicationDbContext : DbContext
    {
        //aplicacion del Fluent API
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appconfig.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrestamoLibros>()
                .ToTable("DetallePrestamoLibro")
                .HasKey(pl => new { pl.LibroId, pl.PrestamoId });


            modelBuilder.Entity<Prestamo>()
                .HasKey(p => new { p.PrestamoId });

            modelBuilder.Entity<Libro>()
                .HasKey(lb => new {lb.Id });

            modelBuilder.Entity<Bibliotec>()
                .HasKey(bl => new { bl.Id });

            modelBuilder.Entity<Devolucion>()
                .HasKey(d => new { d.DevolucionId });
        }
        //crear los dbset
        public DbSet<Bibliotec> Bibliotecs { get; set; }
        public DbSet<Bibliotecario> Bibliotecarios { get; set; }
        public DbSet<Lector> Lectores { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Devolucion> Devoluciones { get; set; }
        public DbSet<PrestamoLibros> PrestamoLibros { get; set; }
    }
}
