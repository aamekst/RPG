using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class MigracaoDisputa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "personagens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Disputas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDisputa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtacanteId = table.Column<int>(type: "int", nullable: false),
                    OponenteId = table.Column<int>(type: "int", nullable: false),
                    Narracao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disputas", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 12, 141, 64, 182, 187, 79, 126, 29, 49, 87, 78, 132, 138, 38, 13, 34, 132, 38, 116, 216, 141, 96, 191, 60, 116, 67, 72, 144, 91, 162, 167, 175, 52, 165, 192, 33, 131, 250, 110, 202, 206, 73, 241, 221, 2, 83, 52, 214, 183, 131, 165, 176, 188, 72, 116, 0, 19, 91, 172, 1, 63, 95, 171, 118 }, new byte[] { 112, 178, 184, 75, 110, 133, 12, 76, 250, 218, 10, 144, 185, 82, 62, 70, 80, 206, 155, 250, 56, 16, 102, 53, 203, 152, 165, 165, 190, 19, 28, 129, 199, 159, 99, 69, 63, 182, 58, 69, 116, 192, 108, 6, 103, 119, 109, 186, 129, 249, 133, 145, 141, 249, 20, 149, 193, 202, 211, 178, 94, 171, 243, 178, 162, 25, 149, 44, 101, 158, 199, 41, 183, 81, 225, 188, 11, 62, 129, 71, 236, 18, 169, 144, 46, 249, 27, 134, 176, 198, 96, 27, 38, 29, 149, 158, 185, 70, 42, 37, 211, 88, 235, 156, 174, 175, 140, 153, 4, 87, 216, 177, 215, 212, 173, 174, 30, 158, 173, 116, 78, 222, 5, 32, 49, 51, 88, 243 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disputas");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "personagens");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "personagens");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "personagens");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 119, 213, 19, 188, 113, 183, 167, 239, 33, 50, 18, 51, 220, 195, 238, 167, 117, 128, 218, 38, 190, 248, 39, 110, 92, 208, 146, 51, 185, 77, 150, 243, 36, 160, 180, 228, 113, 223, 179, 67, 243, 47, 207, 108, 250, 255, 187, 77, 143, 106, 229, 147, 75, 187, 142, 246, 131, 46, 77, 147, 237, 29, 33, 121 }, new byte[] { 224, 143, 23, 247, 132, 86, 6, 118, 20, 37, 127, 201, 1, 64, 201, 24, 48, 34, 124, 86, 178, 134, 222, 197, 185, 206, 68, 147, 21, 14, 115, 5, 247, 40, 100, 207, 198, 255, 116, 8, 21, 179, 94, 198, 46, 132, 32, 202, 42, 194, 56, 76, 215, 191, 61, 233, 243, 246, 254, 143, 116, 225, 72, 199, 42, 100, 66, 253, 5, 41, 202, 22, 219, 82, 221, 88, 39, 140, 40, 219, 117, 139, 47, 226, 69, 194, 125, 40, 21, 223, 188, 169, 36, 100, 54, 19, 254, 45, 174, 123, 2, 52, 5, 1, 235, 180, 130, 164, 211, 254, 83, 21, 16, 214, 81, 152, 30, 178, 144, 132, 244, 78, 60, 139, 114, 235, 210, 60 } });
        }
    }
}
