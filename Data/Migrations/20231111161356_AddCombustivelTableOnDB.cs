using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTZ_Transports.Data.Migrations
{
    public partial class AddCombustivelTableOnDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "numero_cnh",
                table: "motorista",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "motorista",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "motorista",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "categoria_cnh",
                table: "motorista",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

            migrationBuilder.CreateTable(
                name: "combustivel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    preco = table.Column<decimal>(type: "decimal(18,2)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_combustivel", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "combustivel",
                columns: new[] { "id", "nome", "preco" },
                values: new object[] { 1, "Gasolina", 4.29m });

            migrationBuilder.InsertData(
                table: "combustivel",
                columns: new[] { "id", "nome", "preco" },
                values: new object[] { 2, "Etanol", 2.99m });

            migrationBuilder.InsertData(
                table: "combustivel",
                columns: new[] { "id", "nome", "preco" },
                values: new object[] { 3, "Diesel", 2.09m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "combustivel");

            migrationBuilder.AlterColumn<string>(
                name: "numero_cnh",
                table: "motorista",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "motorista",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "motorista",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "categoria_cnh",
                table: "motorista",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1,
                oldNullable: true);
        }
    }
}
