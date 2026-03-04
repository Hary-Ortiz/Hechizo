using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Infraestructura.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallesPedido { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Producto>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Pedido>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Reserva>()
                .HasKey(r => r.Id);
        }
    }
}
