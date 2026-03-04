using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Data
{
    public class HechizoDbContext : DbContext
    {
        public HechizoDbContext(DbContextOptions<HechizoDbContext> options)
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


            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Id)
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(c => c.Nombre)
                      .HasMaxLength(150)
                      .IsRequired();

                entity.Property(c => c.Descripcion)
                      .HasMaxLength(300);
            });


            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Nombre)
                      .HasMaxLength(150)
                      .IsRequired();

                entity.Property(p => p.Precio)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                entity.Property(p => p.Descripcion)
                      .HasMaxLength(300);

                entity.Property(p => p.Categoria)
                      .HasMaxLength(100)
                      .IsRequired();
            });



            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Nombre)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(c => c.Apellido)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(c => c.Email)
                      .HasMaxLength(150)
                      .IsRequired();

                entity.Property(c => c.Telefono)
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(c => c.FechaRegistro)
                      .IsRequired();
            });



            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Total)
                      .HasColumnType("decimal(18,2)");

                entity.Property(p => p.Estado)
                      .HasConversion<int>();

                entity.HasOne(p => p.Cliente)
                      .WithMany()
                      .HasForeignKey(p => p.ClienteId)
                      .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.HasKey(d => d.Id);

                entity.Property(d => d.PrecioUnitario)
                      .HasColumnType("decimal(18,2)");

                entity.Ignore(d => d.Subtotal); // Es calculado

                entity.HasOne<Pedido>()
                      .WithMany(p => p.Detalles)
                      .HasForeignKey("PedidoId")
                      .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.Property(r => r.Estado)
                      .HasConversion<int>();

                entity.HasOne(r => r.Cliente)
                      .WithMany()
                      .HasForeignKey(r => r.ClienteId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}