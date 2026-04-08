<<<<<<< HEAD
﻿using SuperMercadoWebApplication.Entities.Supermercado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
=======
﻿using Microsoft.EntityFrameworkCore;
>>>>>>> ce25912481bb92e7f930e96c7e3f7667d7705ed4

namespace SuperMercadoWebApplication.Infraestructure.Database
{
    public class SuperDbContext : DbContext

    {
<<<<<<< HEAD
        public SuperDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Empleado> Empleados => Set<Empleado>();
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Categoria> Categorias => Set<Categoria>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
=======
        public SuperDbContext(DbContextOptions<SuperDbContext> options) : base(options)
        {
        }
        public DbSet<Entities.Supermercado.Cliente> Clientes { get; set; }
        public DbSet<Entities.Supermercado.Empleado> Empleados { get; set; }
        public DbSet<Entities.Supermercado.Producto> Productos { get; set; }
        public DbSet<Entities.Supermercado.Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Supermercado.Cliente>(entity =>
>>>>>>> ce25912481bb92e7f930e96c7e3f7667d7705ed4
            {
                entity.ToTable("Clientes");
                entity.HasKey(e => e.ClienteId);

                entity.Property(e => e.ClienteId)
                .HasColumnName("ClienteID")
                .HasColumnType("INT");
                entity.Property(e => e.NombreCliente)
                .HasColumnName("Nombre")
                .HasColumnType("NVARCHAR(100)");
                entity.Property(e => e.ApellidoCliente)
                .HasColumnName("Apellido")
                .HasColumnType("NVARCHAR(100)");
                entity.Property(e => e.RTN)
                .HasColumnName("RTN")
                .HasColumnType("NVARCHAR(20)");
                entity.Property(e => e.CorreoElectronico)
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR(100)");
                entity.Property(e => e.Telefono)
                .HasColumnName("Telefono")
                .HasColumnType("NVARCHAR(20)");
                entity.Property(e => e.Activo)
                .HasColumnName("Activo")
                .HasColumnType("BIT")
                .HasDefaultValue(true);
            });
            modelBuilder.Entity<Entities.Supermercado.Empleado>(entity =>
            {
                entity.ToTable("Empleados");
                entity.HasKey(e => e.EmpleadoId);

                entity.Property(e => e.EmpleadoId)
                .HasColumnName("EmpleadoID")
                .HasColumnType("INT");
                entity.Property(e => e.NombreEmpleado)
                .HasColumnName("Nombre")
                .HasColumnType("NVARCHAR(100)");
                entity.Property(e => e.ApellidoEmpleado)
                .HasColumnName("Apellido")
                .HasColumnType("NVARCHAR(100)");
                entity.Property(e => e.Cargo)
                .HasColumnName("Cargo")
                .HasColumnType("NVARCHAR(50)");
                entity.Property(e => e.FechaContratacion)
                .HasColumnName("FechaContratacion")
                .HasColumnType("DATETIME");
                entity.Property(e => e.Activo)
                .HasColumnName("Activo")
                .HasColumnType("BIT")
                .HasDefaultValue(true);
            });
            modelBuilder.Entity<Entities.Supermercado.Categoria>(entity =>
            {
                entity.ToTable("Categorias");
                entity.HasKey(e => e.CategoriaId);
                entity.Property(e => e.CategoriaId)
                .HasColumnName("CategoriaID")
                .HasColumnType("INT");
                entity.Property(e => e.NombreCategoria)
                .HasColumnName("Nombre")
                .HasColumnType("NVARCHAR(100)");
                entity.Property(e => e.Descripcion)
                .HasColumnName("Descripcion")
                .HasColumnType("NVARCHAR(255)");
                entity.Property(e => e.Activo)
                .HasColumnName("Activo")
                .HasColumnType("BIT")
                .HasDefaultValue(true);
            });
            modelBuilder.Entity<Entities.Supermercado.Producto>(entity =>
            {
                entity.ToTable("Productos");
                entity.HasKey(e => e.ProductoId);

                entity.Property(e => e.ProductoId)
                .HasColumnName("ProductoID")
                .HasColumnType("INT");
                entity.Property(e => e.NombreProducto)
                .HasColumnName("Nombre")
                .HasColumnType("NVARCHAR(100)");
                entity.Property(e => e.Precio)
                .HasColumnName("Precio")
                .HasColumnType("DECIMAL(18,2)");
                entity.Property(e => e.Stock)
                .HasColumnName("Stock")
                .HasColumnType("INT");
                entity.Property(e => e.IdCategoria)
                .HasColumnName("CategoriaID")
                .HasColumnType("INT");
                entity.Property(e => e.Activo)
                .HasColumnName("Activo")
                .HasColumnType("BIT")
                .HasDefaultValue(true);
            });
        }
    }
}
