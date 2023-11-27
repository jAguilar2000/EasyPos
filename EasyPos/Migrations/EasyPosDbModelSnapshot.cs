﻿// <auto-generated />
using System;
using EasyPos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasyPos.Migrations
{
    [DbContext(typeof(EasyPosDb))]
    partial class EasyPosDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EasyPos.Models.CategoriaProducto", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.HasKey("CategoriaId");

                    b.ToTable("CategoriaProducto");
                });

            modelBuilder.Entity("EasyPos.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"), 1L, 1);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("EasyPos.Models.Estado", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoId"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoId");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("EasyPos.Models.Factura", b =>
                {
                    b.Property<int>("FacturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacturaId"), 1L, 1);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCrea")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Isv")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NumFactura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UsuarioCreaId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioModificaId")
                        .HasColumnType("int");

                    b.HasKey("FacturaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("UsuarioCreaId");

                    b.HasIndex("UsuarioModificaId");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("EasyPos.Models.FacturaDetalle", b =>
                {
                    b.Property<int>("FacturaDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacturaDetalleId"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int>("FacturaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Isv")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("FacturaDetalleId");

                    b.HasIndex("FacturaId");

                    b.HasIndex("ProductoId");

                    b.ToTable("FacturaDetalle");
                });

            modelBuilder.Entity("EasyPos.Models.Inventario", b =>
                {
                    b.Property<int>("InventarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InventarioId"), 1L, 1);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("StockDisponible")
                        .HasColumnType("int");

                    b.Property<int>("StockMax")
                        .HasColumnType("int");

                    b.Property<int>("StockMin")
                        .HasColumnType("int");

                    b.HasKey("InventarioId");

                    b.HasIndex("ProductoId");

                    b.ToTable("Inventario");
                });

            modelBuilder.Entity("EasyPos.Models.OrdenCompra", b =>
                {
                    b.Property<int>("OrdenCompraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrdenCompraId"), 1L, 1);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Isv")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("OrdenCompraId");

                    b.HasIndex("ProveedorId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("OrdenCompra");
                });

            modelBuilder.Entity("EasyPos.Models.OrdenCompraDetalle", b =>
                {
                    b.Property<int>("OrdenCompraDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrdenCompraDetalleId"), 1L, 1);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Isv")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrdenCompraId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("OrdenCompraDetalleId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("OrdenCompraId");

                    b.HasIndex("ProductoId");

                    b.ToTable("OrdenCompraDetalle");
                });

            modelBuilder.Entity("EasyPos.Models.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoId"), 1L, 1);

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<decimal>("Isv")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductoId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("EasyPos.Models.Proveedor", b =>
                {
                    b.Property<int>("ProveedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProveedorId"), 1L, 1);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProveedorId");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("EasyPos.Models.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolId"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.HasKey("RolId");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("EasyPos.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreIdentificador")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("EasyPos.Models.UsuarioRol", b =>
                {
                    b.Property<int>("UsuarioRolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioRolId"), 1L, 1);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioRolId");

                    b.HasIndex("RolId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioRol");
                });

            modelBuilder.Entity("EasyPos.Models.Factura", b =>
                {
                    b.HasOne("EasyPos.Models.Cliente", "Cliente")
                        .WithMany("Factura")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyPos.Models.Estado", "Estados")
                        .WithMany("Factura")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyPos.Models.Usuario", "UsuarioCrea")
                        .WithMany()
                        .HasForeignKey("UsuarioCreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyPos.Models.Usuario", "UsuarioModifica")
                        .WithMany()
                        .HasForeignKey("UsuarioModificaId");

                    b.Navigation("Cliente");

                    b.Navigation("Estados");

                    b.Navigation("UsuarioCrea");

                    b.Navigation("UsuarioModifica");
                });

            modelBuilder.Entity("EasyPos.Models.FacturaDetalle", b =>
                {
                    b.HasOne("EasyPos.Models.Factura", "Factura")
                        .WithMany("FacturaDetalle")
                        .HasForeignKey("FacturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyPos.Models.Producto", "Producto")
                        .WithMany("FacturaDetalle")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factura");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("EasyPos.Models.Inventario", b =>
                {
                    b.HasOne("EasyPos.Models.Producto", "Producto")
                        .WithMany("Inventario")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("EasyPos.Models.OrdenCompra", b =>
                {
                    b.HasOne("EasyPos.Models.Proveedor", "Proveedor")
                        .WithMany("OrdenCompra")
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyPos.Models.Usuario", "Usuario")
                        .WithMany("OrdenCompra")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("EasyPos.Models.OrdenCompraDetalle", b =>
                {
                    b.HasOne("EasyPos.Models.Estado", "Estados")
                        .WithMany("OrdenCompraDetalle")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyPos.Models.OrdenCompra", "OrdenCompra")
                        .WithMany("OrdenCompraDetalle")
                        .HasForeignKey("OrdenCompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyPos.Models.Producto", "Producto")
                        .WithMany("OrdenCompraDetalle")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estados");

                    b.Navigation("OrdenCompra");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("EasyPos.Models.Producto", b =>
                {
                    b.HasOne("EasyPos.Models.CategoriaProducto", "CategoriaProducto")
                        .WithMany("Productos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaProducto");
                });

            modelBuilder.Entity("EasyPos.Models.UsuarioRol", b =>
                {
                    b.HasOne("EasyPos.Models.Rol", "Rol")
                        .WithMany("UsuarioRol")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyPos.Models.Usuario", "Usuario")
                        .WithMany("UsuarioRol")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("EasyPos.Models.CategoriaProducto", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("EasyPos.Models.Cliente", b =>
                {
                    b.Navigation("Factura");
                });

            modelBuilder.Entity("EasyPos.Models.Estado", b =>
                {
                    b.Navigation("Factura");

                    b.Navigation("OrdenCompraDetalle");
                });

            modelBuilder.Entity("EasyPos.Models.Factura", b =>
                {
                    b.Navigation("FacturaDetalle");
                });

            modelBuilder.Entity("EasyPos.Models.OrdenCompra", b =>
                {
                    b.Navigation("OrdenCompraDetalle");
                });

            modelBuilder.Entity("EasyPos.Models.Producto", b =>
                {
                    b.Navigation("FacturaDetalle");

                    b.Navigation("Inventario");

                    b.Navigation("OrdenCompraDetalle");
                });

            modelBuilder.Entity("EasyPos.Models.Proveedor", b =>
                {
                    b.Navigation("OrdenCompra");
                });

            modelBuilder.Entity("EasyPos.Models.Rol", b =>
                {
                    b.Navigation("UsuarioRol");
                });

            modelBuilder.Entity("EasyPos.Models.Usuario", b =>
                {
                    b.Navigation("OrdenCompra");

                    b.Navigation("UsuarioRol");
                });
#pragma warning restore 612, 618
        }
    }
}
