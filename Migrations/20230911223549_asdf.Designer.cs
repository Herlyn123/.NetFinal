﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TallerFinal.Data;

#nullable disable

namespace TallerFinal.Migrations
{
    [DbContext(typeof(DBentregaFinalContext))]
    [Migration("20230911223549_asdf")]
    partial class asdf
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TallerFinal.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<bool?>("Estado")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("TallerFinal.Models.Compra", b =>
                {
                    b.Property<int>("CompraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompraId"), 1L, 1);

                    b.Property<bool?>("Estado")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("bit");

                    b.Property<DateTime?>("FechaCompra")
                        .IsRequired()
                        .HasColumnType("date");

                    b.Property<double?>("PrecioTotal")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<int?>("ProveedorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("CompraId");

                    b.HasIndex("ProveedorId");

                    b.ToTable("Compra", (string)null);
                });

            modelBuilder.Entity("TallerFinal.Models.Proveedor", b =>
                {
                    b.Property<int>("ProveedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProveedorId"), 1L, 1);

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<bool?>("Estado")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProveedorId");

                    b.ToTable("Proveedor", (string)null);
                });

            modelBuilder.Entity("TallerFinal.Models.Ventum", b =>
                {
                    b.Property<int>("VentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VentaId"), 1L, 1);

                    b.Property<int?>("ClienteId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool?>("Estado")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Fecha")
                        .IsRequired()
                        .HasColumnType("date");

                    b.Property<double?>("PrecioTotal")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<string>("Producto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VentaId")
                        .HasName("PK__Venta__5B4150ACAA869BCA");

                    b.HasIndex("ClienteId");

                    b.ToTable("Venta");
                });

            modelBuilder.Entity("TallerFinal.Models.Compra", b =>
                {
                    b.HasOne("TallerFinal.Models.Proveedor", "Proveedor")
                        .WithMany("Compras")
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Compra__Proveedo__2B3F6F97");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("TallerFinal.Models.Ventum", b =>
                {
                    b.HasOne("TallerFinal.Models.Cliente", "Cliente")
                        .WithMany("Venta")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Venta__ClienteId__267ABA7A");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("TallerFinal.Models.Cliente", b =>
                {
                    b.Navigation("Venta");
                });

            modelBuilder.Entity("TallerFinal.Models.Proveedor", b =>
                {
                    b.Navigation("Compras");
                });
#pragma warning restore 612, 618
        }
    }
}
