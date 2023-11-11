using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTZ_Transports.Data.Migrations
{
    public partial class AddMotoristaTableOnDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "motorista",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    numero_cnh = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    categoria_cnh = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_motorista", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "motorista");
        }
    }
}
