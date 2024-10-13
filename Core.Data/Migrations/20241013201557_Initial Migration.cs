﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Subastas",
                columns: table => new
                {
                    subastaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    titulo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fechaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    fechaFinalizado = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    estadoSubasta = table.Column<int>(type: "int", nullable: false),
                    metodosdePago = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subastas", x => x.subastaID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    usuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contrasenia = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.usuarioID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    productoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombreProducto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    estadoProducto = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    precioBase = table.Column<double>(type: "double", nullable: false),
                    metodoEntrega = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fechaSolicitud = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    estadoSolicitud = table.Column<int>(type: "int", nullable: false),
                    motivo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    usuarioID = table.Column<int>(type: "int", nullable: false),
                    subastaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.productoID);
                    table.ForeignKey(
                        name: "FK_Productos_Subastas_subastaID",
                        column: x => x.subastaID,
                        principalTable: "Subastas",
                        principalColumn: "subastaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Usuarios_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Certificado",
                columns: table => new
                {
                    certificadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    metodoPago = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fechaEmision = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    productoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificado", x => x.certificadoId);
                    table.ForeignKey(
                        name: "FK_Certificado_Productos_productoID",
                        column: x => x.productoID,
                        principalTable: "Productos",
                        principalColumn: "productoID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Datos_vendedor",
                columns: table => new
                {
                    DNI = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    producID = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    direccion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    codigoArea = table.Column<int>(type: "int", nullable: false),
                    productoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datos_vendedor", x => new { x.DNI, x.producID });
                    table.ForeignKey(
                        name: "FK_Datos_vendedor_Productos_producID",
                        column: x => x.producID,
                        principalTable: "Productos",
                        principalColumn: "productoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Datos_vendedor_Productos_productoID",
                        column: x => x.productoID,
                        principalTable: "Productos",
                        principalColumn: "productoID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ofertas",
                columns: table => new
                {
                    ofertaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    montoOferta = table.Column<float>(type: "float", nullable: false),
                    estadoOferta = table.Column<int>(type: "int", nullable: false),
                    usuarioID = table.Column<int>(type: "int", nullable: false),
                    productoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofertas", x => x.ofertaID);
                    table.ForeignKey(
                        name: "FK_Ofertas_Productos_productoID",
                        column: x => x.productoID,
                        principalTable: "Productos",
                        principalColumn: "productoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ofertas_Usuarios_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Datos_ofertante",
                columns: table => new
                {
                    DNI = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    oferID = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    direccion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    codigoArea = table.Column<int>(type: "int", nullable: false),
                    ofertaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datos_ofertante", x => new { x.DNI, x.oferID });
                    table.ForeignKey(
                        name: "FK_Datos_ofertante_Ofertas_oferID",
                        column: x => x.oferID,
                        principalTable: "Ofertas",
                        principalColumn: "ofertaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Datos_ofertante_Ofertas_ofertaID",
                        column: x => x.ofertaID,
                        principalTable: "Ofertas",
                        principalColumn: "ofertaID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Certificado_productoID",
                table: "Certificado",
                column: "productoID");

            migrationBuilder.CreateIndex(
                name: "IX_Datos_ofertante_oferID",
                table: "Datos_ofertante",
                column: "oferID");

            migrationBuilder.CreateIndex(
                name: "IX_Datos_ofertante_ofertaID",
                table: "Datos_ofertante",
                column: "ofertaID");

            migrationBuilder.CreateIndex(
                name: "IX_Datos_vendedor_producID",
                table: "Datos_vendedor",
                column: "producID");

            migrationBuilder.CreateIndex(
                name: "IX_Datos_vendedor_productoID",
                table: "Datos_vendedor",
                column: "productoID");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_productoID",
                table: "Ofertas",
                column: "productoID");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_usuarioID",
                table: "Ofertas",
                column: "usuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_subastaID",
                table: "Productos",
                column: "subastaID");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_usuarioID",
                table: "Productos",
                column: "usuarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificado");

            migrationBuilder.DropTable(
                name: "Datos_ofertante");

            migrationBuilder.DropTable(
                name: "Datos_vendedor");

            migrationBuilder.DropTable(
                name: "Ofertas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Subastas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
