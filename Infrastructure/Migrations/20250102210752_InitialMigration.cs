using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conductor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Telefono = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Licencia = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    Tipo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Marca = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Modelo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Placa = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ProveedorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Capacidad = table.Column<int>(type: "integer", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenServicio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    UbicacionIncidente = table.Column<string>(type: "text", nullable: false),
                    UbicacionDestino = table.Column<string>(type: "text", nullable: false),
                    KilometrosRecorridos = table.Column<int>(type: "integer", nullable: false),
                    CostoTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    ConductorId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProveedorId = table.Column<Guid>(type: "uuid", nullable: true),
                    VehiculoId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenServicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenServicio_Conductor_ConductorId",
                        column: x => x.ConductorId,
                        principalTable: "Conductor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenServicio_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdenServicio_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CostoAdicional",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Monto = table.Column<decimal>(type: "numeric", nullable: false),
                    OrdenId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostoAdicional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostoAdicional_OrdenServicio_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "OrdenServicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostoAdicional_OrdenId",
                table: "CostoAdicional",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicio_ConductorId",
                table: "OrdenServicio",
                column: "ConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicio_ProveedorId",
                table: "OrdenServicio",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicio_VehiculoId",
                table: "OrdenServicio",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_ProveedorId",
                table: "Vehiculos",
                column: "ProveedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostoAdicional");

            migrationBuilder.DropTable(
                name: "OrdenServicio");

            migrationBuilder.DropTable(
                name: "Conductor");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Proveedor");
        }
    }
}
