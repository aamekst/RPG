using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class MigracaoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FotoPersonagem",
                table: "personagens",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "personagens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Armas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "Id", "DataAcesso", "Foto", "Latitude", "Longitude", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, null, null, null, null, new byte[] { 236, 238, 232, 157, 121, 115, 190, 80, 214, 24, 192, 139, 208, 97, 65, 57, 8, 91, 121, 137, 165, 251, 171, 220, 70, 93, 176, 101, 101, 27, 142, 154, 155, 208, 174, 177, 138, 39, 153, 187, 84, 161, 33, 189, 9, 134, 6, 67, 84, 158, 112, 47, 127, 126, 250, 3, 242, 237, 72, 88, 59, 33, 127, 227 }, new byte[] { 209, 23, 116, 217, 52, 254, 243, 228, 206, 155, 165, 107, 60, 190, 206, 254, 22, 246, 137, 146, 230, 25, 122, 183, 86, 253, 175, 190, 119, 3, 101, 18, 135, 92, 222, 99, 158, 77, 21, 184, 189, 100, 27, 48, 227, 63, 252, 162, 162, 37, 72, 235, 140, 175, 115, 77, 237, 196, 228, 66, 212, 83, 236, 70, 117, 164, 189, 165, 162, 108, 88, 45, 25, 183, 189, 75, 174, 208, 55, 65, 66, 70, 118, 42, 189, 76, 175, 132, 230, 121, 235, 94, 216, 50, 218, 182, 81, 205, 63, 130, 25, 251, 159, 94, 168, 84, 204, 0, 197, 90, 100, 223, 205, 217, 32, 50, 138, 60, 18, 223, 54, 201, 53, 111, 121, 115, 182, 232 }, "UsuarioAdmin" });

            migrationBuilder.CreateIndex(
                name: "IX_personagens_UsuarioId",
                table: "personagens",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_personagens_usuarios_UsuarioId",
                table: "personagens",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personagens_usuarios_UsuarioId",
                table: "personagens");

            migrationBuilder.DropTable(
                name: "Armas");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropIndex(
                name: "IX_personagens_UsuarioId",
                table: "personagens");

            migrationBuilder.DropColumn(
                name: "FotoPersonagem",
                table: "personagens");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "personagens");
        }
    }
}
