using System;
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
            migrationBuilder.CreateTable(
                name: "Subastas",
                columns: table => new
                {
                    subastaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaFinalizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estadoSubasta = table.Column<int>(type: "int", nullable: false),
                    metodosdePago = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subastas", x => x.subastaID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    usuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashPassword = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.usuarioID);
                });

            migrationBuilder.CreateTable(
                name: "Datos_usuario",
                columns: table => new
                {
                    usuarioID = table.Column<int>(type: "int", nullable: false),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codigoArea = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datos_usuario", x => x.usuarioID);
                    table.ForeignKey(
                        name: "FK_Datos_usuario_Usuarios_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    productoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estadoProducto = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precioBase = table.Column<double>(type: "float", nullable: false),
                    metodoEntrega = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estadoSolicitud = table.Column<int>(type: "int", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuarioID = table.Column<int>(type: "int", nullable: true),
                    subastaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.productoID);
                    table.ForeignKey(
                        name: "FK_Productos_Subastas_subastaID",
                        column: x => x.subastaID,
                        principalTable: "Subastas",
                        principalColumn: "subastaID");
                    table.ForeignKey(
                        name: "FK_Productos_Usuarios_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioID");
                });

            migrationBuilder.CreateTable(
                name: "Ofertas",
                columns: table => new
                {
                    ofertaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    montoOferta = table.Column<float>(type: "real", nullable: false),
                    fechaOferta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estadoOferta = table.Column<int>(type: "int", nullable: false),
                    usuarioID = table.Column<int>(type: "int", nullable: true),
                    productoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofertas", x => x.ofertaID);
                    table.ForeignKey(
                        name: "FK_Ofertas_Productos_productoID",
                        column: x => x.productoID,
                        principalTable: "Productos",
                        principalColumn: "productoID");
                    table.ForeignKey(
                        name: "FK_Ofertas_Usuarios_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioID");
                });

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
                name: "Datos_usuario");

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
