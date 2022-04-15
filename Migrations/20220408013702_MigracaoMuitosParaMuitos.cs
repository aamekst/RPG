using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonagemHabilidades",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonagemHabilidades", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_PersonagemHabilidades_Habilidades_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "Habilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonagemHabilidades_personagens_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "personagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Habilidades",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 136, 207, 34, 169, 15, 181, 139, 48, 127, 249, 1, 141, 211, 114, 38, 219, 255, 246, 203, 32, 42, 241, 174, 100, 32, 155, 225, 54, 253, 242, 131, 32, 72, 115, 47, 233, 118, 92, 243, 157, 73, 253, 87, 1, 167, 83, 196, 83, 131, 64, 58, 36, 196, 250, 117, 163, 189, 188, 220, 253, 113, 147, 202, 132 }, new byte[] { 147, 189, 140, 142, 104, 189, 6, 34, 154, 22, 18, 184, 214, 143, 50, 65, 83, 164, 144, 59, 138, 49, 148, 224, 56, 44, 89, 20, 108, 175, 218, 17, 246, 158, 33, 248, 55, 233, 106, 226, 187, 212, 161, 183, 215, 222, 101, 184, 134, 206, 176, 74, 174, 10, 239, 6, 31, 66, 112, 139, 253, 82, 102, 148, 247, 195, 215, 125, 236, 72, 137, 22, 109, 164, 102, 140, 167, 149, 228, 3, 192, 8, 235, 103, 28, 216, 203, 167, 38, 74, 252, 174, 37, 164, 49, 58, 110, 187, 170, 173, 75, 86, 209, 8, 190, 254, 157, 115, 184, 6, 254, 152, 109, 84, 247, 254, 197, 124, 242, 225, 148, 9, 135, 185, 225, 247, 193, 140 } });

            migrationBuilder.InsertData(
                table: "PersonagemHabilidades",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 5 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 6 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonagemHabilidades_HabilidadeId",
                table: "PersonagemHabilidades",
                column: "HabilidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonagemHabilidades");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 199, 28, 183, 165, 201, 36, 238, 38, 179, 231, 114, 244, 241, 129, 253, 181, 69, 42, 244, 234, 82, 6, 111, 228, 157, 43, 129, 92, 247, 53, 73, 229, 92, 231, 29, 69, 117, 146, 46, 75, 151, 147, 111, 212, 100, 157, 129, 89, 155, 63, 87, 143, 206, 91, 62, 19, 168, 74, 133, 172, 3, 202, 190, 50 }, new byte[] { 182, 24, 46, 187, 8, 141, 178, 251, 121, 58, 106, 55, 38, 19, 100, 173, 117, 197, 160, 86, 246, 2, 205, 154, 71, 50, 115, 158, 107, 143, 183, 85, 156, 32, 3, 164, 111, 66, 86, 248, 162, 61, 82, 180, 185, 3, 77, 102, 61, 48, 144, 3, 57, 243, 131, 92, 243, 206, 97, 6, 120, 244, 12, 242, 150, 46, 13, 19, 31, 136, 24, 105, 65, 23, 249, 234, 226, 24, 109, 176, 49, 116, 247, 212, 1, 22, 171, 79, 62, 196, 87, 255, 197, 254, 109, 135, 112, 254, 203, 210, 168, 236, 10, 231, 254, 253, 216, 241, 52, 167, 152, 146, 225, 125, 143, 97, 115, 128, 38, 109, 196, 203, 9, 200, 198, 135, 61, 24 } });
        }
    }
}
