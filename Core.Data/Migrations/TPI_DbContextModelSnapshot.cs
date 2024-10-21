﻿// <auto-generated />
using System;
using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Core.Data.Migrations
{
    [DbContext(typeof(TPI_DbContext))]
    partial class TPI_DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Certificado", b =>
                {
                    b.Property<int>("certificadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("certificadoId"));

                    b.Property<DateTime>("fechaEmision")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("metodoPago")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("certificadoId");

                    b.ToTable("Certificado");
                });

            modelBuilder.Entity("Core.Entities.Datos_usuario", b =>
                {
                    b.Property<int>("usuarioID")
                        .HasColumnType("int");

                    b.Property<int>("DNI")
                        .HasColumnType("int");

                    b.Property<string>("apellido")
                        .HasColumnType("longtext");

                    b.Property<int>("codigoArea")
                        .HasColumnType("int");

                    b.Property<string>("direccion")
                        .HasColumnType("longtext");

                    b.Property<string>("nombre")
                        .HasColumnType("longtext");

                    b.Property<int?>("productoID")
                        .HasColumnType("int");

                    b.Property<int>("telefono")
                        .HasColumnType("int");

                    b.HasKey("usuarioID");

                    b.HasIndex("productoID");

                    b.ToTable("Datos_usuario");
                });

            modelBuilder.Entity("Core.Entities.Oferta", b =>
                {
                    b.Property<int>("ofertaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ofertaID"));

                    b.Property<int>("estadoOferta")
                        .HasColumnType("int");

                    b.Property<float>("montoOferta")
                        .HasColumnType("float");

                    b.Property<int?>("productoID")
                        .HasColumnType("int");

                    b.Property<int?>("usuarioID")
                        .HasColumnType("int");

                    b.HasKey("ofertaID");

                    b.HasIndex("productoID");

                    b.HasIndex("usuarioID");

                    b.ToTable("Ofertas");
                });

            modelBuilder.Entity("Core.Entities.Producto", b =>
                {
                    b.Property<int>("productoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("productoID"));

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("estadoProducto")
                        .HasColumnType("int");

                    b.Property<int>("estadoSolicitud")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaSolicitud")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("metodoEntrega")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nombreProducto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("precioBase")
                        .HasColumnType("double");

                    b.Property<int?>("subastaID")
                        .HasColumnType("int");

                    b.Property<int?>("usuarioID")
                        .HasColumnType("int");

                    b.HasKey("productoID");

                    b.HasIndex("subastaID");

                    b.HasIndex("usuarioID");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Core.Entities.Subasta", b =>
                {
                    b.Property<int>("subastaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("subastaID"));

                    b.Property<int>("estadoSubasta")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaFinalizado")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("fechaInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("metodosdePago")
                        .HasColumnType("int");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("subastaID");

                    b.ToTable("Subastas");
                });

            modelBuilder.Entity("Core.Entities.Usuario", b =>
                {
                    b.Property<int>("usuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("usuarioID"));

                    b.Property<string>("contrasenia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("usuarioID");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Core.Entities.Datos_usuario", b =>
                {
                    b.HasOne("Core.Entities.Producto", null)
                        .WithMany("datosUsuario")
                        .HasForeignKey("productoID");

                    b.HasOne("Core.Entities.Usuario", "Usuario")
                        .WithOne("GetDatosUsuario")
                        .HasForeignKey("Core.Entities.Datos_usuario", "usuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Core.Entities.Oferta", b =>
                {
                    b.HasOne("Core.Entities.Producto", "producto")
                        .WithMany("listaOfertas")
                        .HasForeignKey("productoID");

                    b.HasOne("Core.Entities.Usuario", "usuario")
                        .WithMany("listaOfertas")
                        .HasForeignKey("usuarioID");

                    b.Navigation("producto");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("Core.Entities.Producto", b =>
                {
                    b.HasOne("Core.Entities.Subasta", "Subasta")
                        .WithMany("listaProductos")
                        .HasForeignKey("subastaID");

                    b.HasOne("Core.Entities.Usuario", "Usuario")
                        .WithMany("listaProductos")
                        .HasForeignKey("usuarioID");

                    b.Navigation("Subasta");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Core.Entities.Producto", b =>
                {
                    b.Navigation("datosUsuario");

                    b.Navigation("listaOfertas");
                });

            modelBuilder.Entity("Core.Entities.Subasta", b =>
                {
                    b.Navigation("listaProductos");
                });

            modelBuilder.Entity("Core.Entities.Usuario", b =>
                {
                    b.Navigation("GetDatosUsuario");

                    b.Navigation("listaOfertas");

                    b.Navigation("listaProductos");
                });
#pragma warning restore 612, 618
        }
    }
}
