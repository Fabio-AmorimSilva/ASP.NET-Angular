using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoNacional.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AGENCIAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LOCALIZACAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NUMERO_CLIENTES = table.Column<int>(type: "int", nullable: false),
                    GerenteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGENCIAS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgenciaId = table.Column<int>(type: "int", nullable: false),
                    TIPO_CONTA = table.Column<int>(type: "int", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SALDO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CLIENTES_AGENCIAS_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "AGENCIAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GERENTES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgenciaId = table.Column<int>(type: "int", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GerenteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GERENTES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GERENTES_AGENCIAS_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "AGENCIAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GERENTES_GERENTES_GerenteId",
                        column: x => x.GerenteId,
                        principalTable: "GERENTES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CONTA_CORRENTE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DONO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTA_CORRENTE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CONTA_CORRENTE_CLIENTES_DONO",
                        column: x => x.DONO,
                        principalTable: "CLIENTES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CONTA_POUPANCA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DONO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTA_POUPANCA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CONTA_POUPANCA_CLIENTES_DONO",
                        column: x => x.DONO,
                        principalTable: "CLIENTES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTES_AgenciaId",
                table: "CLIENTES",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_CORRENTE_DONO",
                table: "CONTA_CORRENTE",
                column: "DONO");

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_POUPANCA_DONO",
                table: "CONTA_POUPANCA",
                column: "DONO");

            migrationBuilder.CreateIndex(
                name: "IX_GERENTES_AgenciaId",
                table: "GERENTES",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_GERENTES_GerenteId",
                table: "GERENTES",
                column: "GerenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTA_CORRENTE");

            migrationBuilder.DropTable(
                name: "CONTA_POUPANCA");

            migrationBuilder.DropTable(
                name: "GERENTES");

            migrationBuilder.DropTable(
                name: "CLIENTES");

            migrationBuilder.DropTable(
                name: "AGENCIAS");
        }
    }
}
