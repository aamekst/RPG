using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class MigracaoUmParaUm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "Armas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Armas",
                columns: new[] { "Id", "Dano", "Nome", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 35, "Arco e Flecha", 1 },
                    { 2, 33, "Espada", 2 },
                    { 3, 31, "Machado", 3 }
                });

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 199, 28, 183, 165, 201, 36, 238, 38, 179, 231, 114, 244, 241, 129, 253, 181, 69, 42, 244, 234, 82, 6, 111, 228, 157, 43, 129, 92, 247, 53, 73, 229, 92, 231, 29, 69, 117, 146, 46, 75, 151, 147, 111, 212, 100, 157, 129, 89, 155, 63, 87, 143, 206, 91, 62, 19, 168, 74, 133, 172, 3, 202, 190, 50 }, new byte[] { 182, 24, 46, 187, 8, 141, 178, 251, 121, 58, 106, 55, 38, 19, 100, 173, 117, 197, 160, 86, 246, 2, 205, 154, 71, 50, 115, 158, 107, 143, 183, 85, 156, 32, 3, 164, 111, 66, 86, 248, 162, 61, 82, 180, 185, 3, 77, 102, 61, 48, 144, 3, 57, 243, 131, 92, 243, 206, 97, 6, 120, 244, 12, 242, 150, 46, 13, 19, 31, 136, 24, 105, 65, 23, 249, 234, 226, 24, 109, 176, 49, 116, 247, 212, 1, 22, 171, 79, 62, 196, 87, 255, 197, 254, 109, 135, 112, 254, 203, 210, 168, 236, 10, 231, 254, 253, 216, 241, 52, 167, 152, 146, 225, 125, 143, 97, 115, 128, 38, 109, 196, 203, 9, 200, 198, 135, 61, 24 } });

            migrationBuilder.CreateIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas",
                column: "PersonagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Armas_personagens_PersonagemId",
                table: "Armas",
                column: "PersonagemId",
                principalTable: "personagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Armas_personagens_PersonagemId",
                table: "Armas");

            migrationBuilder.DropIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas");

            migrationBuilder.DeleteData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Armas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "Armas");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 236, 238, 232, 157, 121, 115, 190, 80, 214, 24, 192, 139, 208, 97, 65, 57, 8, 91, 121, 137, 165, 251, 171, 220, 70, 93, 176, 101, 101, 27, 142, 154, 155, 208, 174, 177, 138, 39, 153, 187, 84, 161, 33, 189, 9, 134, 6, 67, 84, 158, 112, 47, 127, 126, 250, 3, 242, 237, 72, 88, 59, 33, 127, 227 }, new byte[] { 209, 23, 116, 217, 52, 254, 243, 228, 206, 155, 165, 107, 60, 190, 206, 254, 22, 246, 137, 146, 230, 25, 122, 183, 86, 253, 175, 190, 119, 3, 101, 18, 135, 92, 222, 99, 158, 77, 21, 184, 189, 100, 27, 48, 227, 63, 252, 162, 162, 37, 72, 235, 140, 175, 115, 77, 237, 196, 228, 66, 212, 83, 236, 70, 117, 164, 189, 165, 162, 108, 88, 45, 25, 183, 189, 75, 174, 208, 55, 65, 66, 70, 118, 42, 189, 76, 175, 132, 230, 121, 235, 94, 216, 50, 218, 182, 81, 205, 63, 130, 25, 251, 159, 94, 168, 84, 204, 0, 197, 90, 100, 223, 205, 217, 32, 50, 138, 60, 18, 223, 54, 201, 53, 111, 121, 115, 182, 232 } });
        }
    }
}
