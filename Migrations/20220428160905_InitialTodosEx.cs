using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RpgApi.Migrations
{
    public partial class InitialTodosEx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 204, 235, 27, 41, 200, 49, 140, 227, 132, 131, 39, 78, 211, 172, 159, 42, 134, 199, 57, 190, 124, 28, 127, 155, 35, 18, 209, 134, 28, 199, 242, 168, 45, 250, 86, 139, 195, 245, 109, 61, 140, 141, 189, 66, 174, 23, 161, 136, 65, 193, 230, 174, 180, 194, 33, 179, 111, 156, 138, 133, 155, 6, 253, 100 }, new byte[] { 211, 113, 81, 236, 204, 75, 133, 16, 211, 250, 251, 156, 252, 69, 79, 120, 252, 97, 60, 182, 254, 133, 50, 127, 76, 45, 59, 239, 52, 197, 89, 76, 241, 160, 204, 107, 105, 161, 83, 128, 147, 137, 59, 24, 212, 161, 127, 131, 206, 91, 65, 15, 192, 219, 86, 137, 117, 62, 162, 207, 118, 240, 221, 211, 88, 133, 31, 125, 143, 191, 186, 21, 47, 194, 37, 126, 93, 14, 117, 217, 51, 69, 33, 134, 178, 100, 9, 10, 166, 14, 73, 46, 195, 57, 35, 83, 69, 52, 175, 196, 254, 241, 183, 38, 164, 67, 0, 200, 60, 86, 107, 24, 30, 29, 86, 71, 79, 2, 157, 236, 123, 98, 121, 55, 18, 229, 106, 221 } });

            migrationBuilder.CreateIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas",
                column: "PersonagemId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 136, 207, 34, 169, 15, 181, 139, 48, 127, 249, 1, 141, 211, 114, 38, 219, 255, 246, 203, 32, 42, 241, 174, 100, 32, 155, 225, 54, 253, 242, 131, 32, 72, 115, 47, 233, 118, 92, 243, 157, 73, 253, 87, 1, 167, 83, 196, 83, 131, 64, 58, 36, 196, 250, 117, 163, 189, 188, 220, 253, 113, 147, 202, 132 }, new byte[] { 147, 189, 140, 142, 104, 189, 6, 34, 154, 22, 18, 184, 214, 143, 50, 65, 83, 164, 144, 59, 138, 49, 148, 224, 56, 44, 89, 20, 108, 175, 218, 17, 246, 158, 33, 248, 55, 233, 106, 226, 187, 212, 161, 183, 215, 222, 101, 184, 134, 206, 176, 74, 174, 10, 239, 6, 31, 66, 112, 139, 253, 82, 102, 148, 247, 195, 215, 125, 236, 72, 137, 22, 109, 164, 102, 140, 167, 149, 228, 3, 192, 8, 235, 103, 28, 216, 203, 167, 38, 74, 252, 174, 37, 164, 49, 58, 110, 187, 170, 173, 75, 86, 209, 8, 190, 254, 157, 115, 184, 6, 254, 152, 109, 84, 247, 254, 197, 124, 242, 225, 148, 9, 135, 185, 225, 247, 193, 140 } });

            migrationBuilder.CreateIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas",
                column: "PersonagemId");
        }
    }
}
