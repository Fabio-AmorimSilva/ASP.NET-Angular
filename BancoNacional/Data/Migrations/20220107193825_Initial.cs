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
                    GERENTE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGENCIAS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTES",
                columns: table => new
                {
                    CODIGO_CLIENTE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO_AGENCIA = table.Column<int>(type: "int", nullable: false),
                    TIPO_CONTA = table.Column<int>(type: "int", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SALDO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES", x => x.CODIGO_CLIENTE);
                });

            migrationBuilder.CreateTable(
                name: "CONTA_CORRENTE",
                columns: table => new
                {
                    CODIGO_CONTA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DONO = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTA_CORRENTE", x => x.CODIGO_CONTA);
                });

            migrationBuilder.CreateTable(
                name: "CONTA_POUPANCA",
                columns: table => new
                {
                    CODIGO_CONTA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DONO = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTA_POUPANCA", x => x.CODIGO_CONTA);
                });

            migrationBuilder.CreateTable(
                name: "GERENTES",
                columns: table => new
                {
                    CODIGO_GERENTE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODIGO_AGENCIA = table.Column<int>(type: "int", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GERENTES", x => x.CODIGO_GERENTE);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AGENCIAS");

            migrationBuilder.DropTable(
                name: "CLIENTES");

            migrationBuilder.DropTable(
                name: "CONTA_CORRENTE");

            migrationBuilder.DropTable(
                name: "CONTA_POUPANCA");

            migrationBuilder.DropTable(
                name: "GERENTES");
        }
    }
}
