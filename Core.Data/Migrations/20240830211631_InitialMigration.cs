using System;
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
                name: "Categorias",
                columns: table => new
                {
                    CategoriaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombreCategoria = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Historial",
                columns: table => new
                {
                    HistorialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historial", x => x.HistorialID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombreUsuario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellidoUsuario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dni = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ganancia = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ListaProductos",
                columns: table => new
                {
                    IdListaProductos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreProducto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoriaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaProductos", x => x.IdListaProductos);
                    table.ForeignKey(
                        name: "FK_ListaProductos_Categorias_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombreProducto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    estadoProducto = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    precioBase = table.Column<double>(type: "double", nullable: false),
                    ofertas = table.Column<int>(type: "int", nullable: false),
                    IdListaProductos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoID);
                    table.ForeignKey(
                        name: "FK_Productos_ListaProductos_IdListaProductos",
                        column: x => x.IdListaProductos,
                        principalTable: "ListaProductos",
                        principalColumn: "IdListaProductos",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ofertas",
                columns: table => new
                {
                    OfertaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MontoOferta = table.Column<int>(type: "int", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    ProductoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofertas", x => x.OfertaID);
                    table.ForeignKey(
                        name: "FK_Ofertas_Productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ofertas_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Subastas",
                columns: table => new
                {
                    SubastaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    titulo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fechaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    fechaFinalizado = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    estadoSubasta = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cantidadProduct = table.Column<int>(type: "int", nullable: false),
                    UsuarioCreadorID = table.Column<int>(type: "int", nullable: false),
                    ProductoID = table.Column<int>(type: "int", nullable: false),
                    HistorialID = table.Column<int>(type: "int", nullable: true),
                    HistorialID1 = table.Column<int>(type: "int", nullable: true),
                    HistorialID2 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subastas", x => x.SubastaID);
                    table.ForeignKey(
                        name: "FK_Subastas_Historial_HistorialID",
                        column: x => x.HistorialID,
                        principalTable: "Historial",
                        principalColumn: "HistorialID");
                    table.ForeignKey(
                        name: "FK_Subastas_Historial_HistorialID1",
                        column: x => x.HistorialID1,
                        principalTable: "Historial",
                        principalColumn: "HistorialID");
                    table.ForeignKey(
                        name: "FK_Subastas_Historial_HistorialID2",
                        column: x => x.HistorialID2,
                        principalTable: "Historial",
                        principalColumn: "HistorialID");
                    table.ForeignKey(
                        name: "FK_Subastas_Productos_ProductoID",
                        column: x => x.ProductoID,
                        principalTable: "Productos",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subastas_Usuarios_UsuarioCreadorID",
                        column: x => x.UsuarioCreadorID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ListaProductos_CategoriaID",
                table: "ListaProductos",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_ProductoID",
                table: "Ofertas",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_UsuarioID",
                table: "Ofertas",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdListaProductos",
                table: "Productos",
                column: "IdListaProductos");

            migrationBuilder.CreateIndex(
                name: "IX_Subastas_HistorialID",
                table: "Subastas",
                column: "HistorialID");

            migrationBuilder.CreateIndex(
                name: "IX_Subastas_HistorialID1",
                table: "Subastas",
                column: "HistorialID1");

            migrationBuilder.CreateIndex(
                name: "IX_Subastas_HistorialID2",
                table: "Subastas",
                column: "HistorialID2");

            migrationBuilder.CreateIndex(
                name: "IX_Subastas_ProductoID",
                table: "Subastas",
                column: "ProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_Subastas_UsuarioCreadorID",
                table: "Subastas",
                column: "UsuarioCreadorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ofertas");

            migrationBuilder.DropTable(
                name: "Subastas");

            migrationBuilder.DropTable(
                name: "Historial");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "ListaProductos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
