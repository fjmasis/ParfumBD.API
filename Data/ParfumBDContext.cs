using Microsoft.EntityFrameworkCore;
using ParfumBD.API.Models;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace ParfumBD.API.Data

{
    public class ParfumBDContext : DbContext 
    {
        public ParfumBDContext(DbContextOptions<ParfumBDContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfume> Perfumes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<DetalleCarrito> DetallesCarrito { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallesPedido { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<HistorialStock> HistorialStock { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<LogAdmin> LogsAdmin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships and constraints

            // Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);
                entity.Property(e => e.Correo).IsRequired().HasMaxLength(100);
                entity.HasIndex(e => e.Correo).IsUnique();
            });

            // Perfume
            modelBuilder.Entity<Perfume>(entity =>
            {
                entity.HasKey(e => e.IdPerfume);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            });

            // Categoria
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            });

            // Carrito
            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(e => e.IdCarrito);
                entity.HasOne(e => e.Usuario)
                      .WithMany(u => u.Carritos)
                      .HasForeignKey(e => e.IdUsuario);
            });

            // DetalleCarrito
            modelBuilder.Entity<DetalleCarrito>(entity =>
            {
                entity.HasKey(e => e.IdDetalle);
                entity.HasOne(e => e.Carrito)
                      .WithMany(c => c.DetallesCarrito)
                      .HasForeignKey(e => e.IdCarrito);
                entity.HasOne(e => e.Perfume)
                      .WithMany(p => p.DetallesCarrito)
                      .HasForeignKey(e => e.IdPerfume);
                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            });

            // Pedido
            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido);
                entity.HasOne(e => e.Usuario)
                      .WithMany(u => u.Pedidos)
                      .HasForeignKey(e => e.IdUsuario);
                entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            });

            // DetallePedido
            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.HasKey(e => e.IdDetalle);
                entity.HasOne(e => e.Pedido)
                      .WithMany(p => p.DetallesPedido)
                      .HasForeignKey(e => e.IdPedido);
                entity.HasOne(e => e.Perfume)
                      .WithMany(p => p.DetallesPedido)
                      .HasForeignKey(e => e.IdPerfume);
                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            });

            // Pago
            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago);
                entity.HasOne(e => e.Pedido)
                      .WithMany(p => p.Pagos)
                      .HasForeignKey(e => e.IdPedido);
            });

            // HistorialStock
            modelBuilder.Entity<HistorialStock>(entity =>
            {
                entity.HasKey(e => e.IdHistorial);
                entity.HasOne(e => e.Perfume)
                      .WithMany(p => p.HistorialStock)
                      .HasForeignKey(e => e.IdPerfume);
            });

            // Direccion
            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.HasKey(e => e.IdDireccion);
                entity.HasOne(e => e.Usuario)
                      .WithMany(u => u.Direcciones)
                      .HasForeignKey(e => e.IdUsuario);
            });

            // LogAdmin
            modelBuilder.Entity<LogAdmin>(entity =>
            {
                entity.HasKey(e => e.IdLog);
                entity.HasOne(e => e.Admin)
                      .WithMany(u => u.LogsAdmin)
                      .HasForeignKey(e => e.IdAdmin);
            });
        }
    }
}
