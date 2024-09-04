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
                    categoriaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombreCategoria = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.categoriaID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    usuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombreUsuario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellidoUsuario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dni = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ganancia = table.Column<float>(type: "float", nullable: false),
                    domicilio = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    roles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.usuarioID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ListaProductos",
                columns: table => new
                {
                    idListaProductos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombreProducto = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    categoriaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaProductos", x => x.idListaProductos);
                    table.ForeignKey(
                        name: "FK_ListaProductos_Categorias_categoriaID",
                        column: x => x.categoriaID,
                        principalTable: "Categorias",
                        principalColumn: "categoriaID",
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
                    estadoProducto = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    precioBase = table.Column<double>(type: "double", nullable: false),
                    ofertas = table.Column<int>(type: "int", nullable: false),
                    habilitacionProducto = table.Column<int>(type: "int", nullable: false),
                    idListaProductos = table.Column<int>(type: "int", nullable: false),
                    usuarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoID);
                    table.ForeignKey(
                        name: "FK_Productos_ListaProductos_idListaProductos",
                        column: x => x.idListaProductos,
                        principalTable: "ListaProductos",
                        principalColumn: "idListaProductos",
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
                name: "Ofertas",
                columns: table => new
                {
                    OfertaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    montoOferta = table.Column<int>(type: "int", nullable: false),
                    estadoOferta = table.Column<int>(type: "int", nullable: false),
                    usuarioID = table.Column<int>(type: "int", nullable: false),
                    productoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofertas", x => x.OfertaID);
                    table.ForeignKey(
                        name: "FK_Ofertas_Productos_productoID",
                        column: x => x.productoID,
                        principalTable: "Productos",
                        principalColumn: "ProductoID",
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
                name: "Subastas",
                columns: table => new
                {
                    subastaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    titulo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fechaInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    fechaFinalizado = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    estadoSubasta = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    cantidadProduct = table.Column<int>(type: "int", nullable: false),
                    metodosdePago = table.Column<int>(type: "int", nullable: false),
                    usuarioCreadorID = table.Column<int>(type: "int", nullable: false),
                    productoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subastas", x => x.subastaID);
                    table.ForeignKey(
                        name: "FK_Subastas_Productos_productoID",
                        column: x => x.productoID,
                        principalTable: "Productos",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subastas_Usuarios_usuarioCreadorID",
                        column: x => x.usuarioCreadorID,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    facturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    metodoPago = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fechaEmision = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    tipoFactura = table.Column<int>(type: "int", nullable: false),
                    dni = table.Column<int>(type: "int", nullable: false),
                    montoOferta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.facturaId);
                    table.ForeignKey(
                        name: "FK_Facturas_Ofertas_montoOferta",
                        column: x => x.montoOferta,
                        principalTable: "Ofertas",
                        principalColumn: "OfertaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Facturas_Usuarios_dni",
                        column: x => x.dni,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_dni",
                table: "Facturas",
                column: "dni");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_montoOferta",
                table: "Facturas",
                column: "montoOferta");

            migrationBuilder.CreateIndex(
                name: "IX_ListaProductos_categoriaID",
                table: "ListaProductos",
                column: "categoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_productoID",
                table: "Ofertas",
                column: "productoID");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_usuarioID",
                table: "Ofertas",
                column: "usuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_idListaProductos",
                table: "Productos",
                column: "idListaProductos");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_usuarioID",
                table: "Productos",
                column: "usuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Subastas_productoID",
                table: "Subastas",
                column: "productoID");

            migrationBuilder.CreateIndex(
                name: "IX_Subastas_usuarioCreadorID",
                table: "Subastas",
                column: "usuarioCreadorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Subastas");

            migrationBuilder.DropTable(
                name: "Ofertas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "ListaProductos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
