using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTZ_Transports.Data.Migrations
{
    public partial class AddVeiculoTableOnDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "veiculo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    placa = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    nome_veiculo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    fabricante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ano_fabricacao = table.Column<int>(type: "int", nullable: false),
                    capacidade_max_tanque = table.Column<int>(type: "int", nullable: false),
                    observacoes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    combustivelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo", x => x.id);
                    table.ForeignKey(
                        name: "FK_veiculo_combustivel_combustivelId",
                        column: x => x.combustivelId,
                        principalTable: "combustivel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_veiculo_combustivelId",
                table: "veiculo",
                column: "combustivelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "veiculo");
        }
    }
}
